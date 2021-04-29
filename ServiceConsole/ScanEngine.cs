using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.IO.Compression;

namespace ServiceConsole
{
    class ScanEngine
    {
        public static List<Task> tasks;
        public static byte closing;
        public static List<string> scanned;
        public static List<string> infected;
        public static List<string> toScan;
        private static Queue<string> curpath;

        public static void ScanEngineSetDefault() { 
            tasks = new List<Task>(); 
            closing = 0;
            curpath = new Queue<string>();
            scanned = new List<string>();
            infected = new List<string>();
            toScan = new List<string>();
        }
        
        public static void scan()
        {
            var path = "";
            while (closing == 0)
            {
                //ZipArchive zip = ZipFile.Open(path, ZipArchiveMode.Read);   
                if (toScan.Count == 0)
                    continue;
                Console.WriteLine("scanning...");
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
            string path;
            if (curpath.Count == 0) { return; }
            lock (curpath)
            {
                path = curpath.Dequeue();
            }

            Console.WriteLine("Scan file " + path);
            List<string> check = new List<string>();
            var sr = File.Open(path, FileMode.Open, FileAccess.ReadWrite);
            {
                byte[] head = new byte[4];
                sr.Read(head, 0, head.Length);
                if (!(head[0] == 77 && head[1] == 90    //exe file
                    || head[0] == 80 && head[1] == 75)) //zip file
                    return;
                for(long i = Base.minOffStart;i<sr.Length-Base.maxLength;i++)
                {
                    sr.Position = i;
                    byte[] buf = new byte[Base.maxLength];
                    for(int j=0;j<buf.Length;j++)
                        buf[j] = (byte)sr.ReadByte();
                    check = Base.isFound(buf, (ulong)i);
                    if (check.Count > 0)
                    {
                        lock (infected)
                            infected.Add(path);
                        lock (Program.messageOut)
                            Program.messageOut.Enqueue("\u0000\u0007" 
                                + path + '|' + check.First());

                        sr.Position = 0;
                        buf = new byte[2]; 
                        sr.Read(buf,0,buf.Length);
                        buf[0] += 25; buf[1] += 25;
                        sr.Position = 0;
                        sr.Write(buf, 0, buf.Length);
                        sr.Close();

                        var destfile = "c:\\antiv\\quarantine\\"
                            + path.Substring(path.LastIndexOf('\\'));
                        File.Copy(path, destfile);
                        File.Delete(path);
                        return;
                    }
                }
            }
            lock (scanned)
                scanned.Add(path);
            lock (Program.messageOut)
                Program.messageOut.Enqueue("\u0000\u0002" + path);

        }
        private static void scanDir()
        {
            string path;
            if (curpath.Count == 0) return;
            lock (curpath)
                path = curpath.Dequeue();

            Console.WriteLine("scan dir "+path);
            var files = Directory.GetFiles(path);
            var dirs = Directory.GetDirectories(path);
            foreach (var f in files)
                lock (toScan)
                    toScan.Add(f);
            foreach (var d in dirs)
                lock (toScan)
                    toScan.Add(d);
        }
        private byte[] reArrange(byte[] origbuf, byte newbyte)
        {
            var res = origbuf;
            for(int i=0; i < origbuf.Length-1; i++)
            {
                res[i] = res[i + 1];
            }
            res[res.Length - 1] = newbyte;
            return res;
        }
    }
}
