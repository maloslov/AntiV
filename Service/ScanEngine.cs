using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.IO.Compression;

namespace Service
{
    class ScanEngine
    {
        public static List<Task> tasks;
        public static byte closing;
        public static List<string> scanned;
        public static Dictionary<string, string> infected;
        public static List<string> toScan;
        private static Queue<string> curpath;

        public static void ScanEngineSetDefault()
        {
            tasks = new List<Task>();
            closing = 0;
            curpath = new Queue<string>();
            scanned = new List<string>();
            infected = new Dictionary<string, string>();
            toScan = new List<string>();
        }

        public static void scan()
        {
            var path = "";
            while (closing == 0)
            {  
                if (toScan.Count == 0)
                    continue;
                lock (curpath)
                {
                    curpath.Enqueue(path = toScan.First());
                    toScan.RemoveAt(0);
                }
                switch (File.Exists(path))
                {
                    case true:
                        lock (tasks)
                        {
                            tasks.Add(new Task(new Action(scanFile)));
                            tasks.Last().Start();
                        }
                        break;
                    case false:
                        scanDir();
                        break;
                }
            }
        }
        private static void scanFile()
        {
            string path, type = "";
            if (curpath.Count == 0) { return; }
            lock (curpath)
            {
                path = curpath.Dequeue();
            }

            List<string> check = new List<string>();
            var sr = File.Open(path, FileMode.Open, FileAccess.ReadWrite);
            {
                byte[] head = new byte[4];
                sr.Read(head, 0, head.Length);
                if ((head[0] == 77 && head[1] == 90))    //exe file
                    type = "exe";
                else if ((head[0] == 80 && head[1] == 75)) //zip file
                    type = "zip";
                else
                    return;
                for (long i = Base.minOffStart; i < sr.Length - Base.maxLength; i++)
                {
                    if (closing == 1)
                        return;
                    sr.Position = i;
                    byte[] buf = new byte[Base.maxLength];
                    for (int j = 0; j < buf.Length; j++)
                        buf[j] = (byte)sr.ReadByte();
                    check = Base.isFound(buf, (ulong)i, type);
                    if (check.Count > 0)
                    {

                        sr.Position = 0;
                        buf = new byte[2];
                        sr.Read(buf, 0, buf.Length);
                        buf[0] += 25; buf[1] += 25;
                        sr.Position = 0;
                        sr.Write(buf, 0, buf.Length);
                        sr.Close();

                        var destfile = "c:\\antiv\\quarantine\\"
                            + path.Substring(path.LastIndexOf('\\'));
                        int n = 0;
                        while (File.Exists(destfile))
                        {
                            destfile = "c:\\antiv\\quarantine\\(" + n + ")"
                                + path.Substring(path.LastIndexOf('\\'));
                            n++;
                        }
                        File.Copy(path, destfile);
                        File.Delete(path);
                        lock (infected)
                            infected.Add(destfile, path);
                        lock (Service1.messageOut)
                            Service1.messageOut.Enqueue("\u0000\u0007"
                                + path + '|' + check.First() + '|' + destfile);
                        return;
                    }
                }
            }
            lock (scanned)
                scanned.Add(path);
            lock (Service1.messageOut)
                Service1.messageOut.Enqueue("\u0000\u0002" + path);

        }
        private static void scanDir()
        {
            string path;
            if (curpath.Count == 0) return;
            lock (curpath)
                path = curpath.Dequeue();

            Console.WriteLine("scan dir " + path);
            var files = Directory.GetFiles(path);
            var dirs = Directory.GetDirectories(path);
            foreach (var f in files)
                lock (toScan)
                    toScan.Add(f);
            foreach (var d in dirs)
                lock (toScan)
                    toScan.Add(d);
        }

        public static void restore(string path)
        {
            var sr = File.Open(path, FileMode.Open, FileAccess.ReadWrite);
            {
                sr.Position = 0;
                var buf = new byte[2];
                sr.Read(buf, 0, buf.Length);
                buf[0] -= 25; buf[1] -= 25;
                sr.Position = 0;
                sr.Write(buf, 0, buf.Length);
            }
        }
        public static void delete(string path)
        {
            try { File.Delete(path); }
            catch (Exception ex)
            {

            }
        }
    }
}
