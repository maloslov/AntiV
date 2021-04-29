using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

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
            var sr = File.OpenRead(path);
            {
                byte[] head = new byte[4];
                sr.Read(head, 0, head.Length);
                if (!(head[0] == 77 && head[1] == 90    //exe file
                    || head[0] == 80 && head[1] == 75)) //zip file
                    return;

                for (long i = Base.minOffStart; i < sr.Length - Base.maxLength; i++)
                {
                    sr.Position = i;
                    byte[] buf = new byte[Base.maxLength];
                    sr.Read(buf, 0, buf.Length);
                    check = Base.isFound(buf, (ulong)i);
                    if (check.Count > 0)
                    {
                        lock (infected)
                            infected.Add(path);
                        lock (Program.messageOut)
                            Program.messageOut.Enqueue("\u0000\u0007" 
                                + path + '|' + check.First());
                        sr = File.OpenWrite(path);

                        sr.Position = 0;
                        sr.WriteByte((byte)(sr.ReadByte() + 50));
                        sr.Position = 1;
                        sr.WriteByte((byte)(sr.ReadByte() + 50));
                        sr.Dispose();

                        File.Replace(path, "c:\\antiv\\quarantine\\" 
                            + path.Substring(path.LastIndexOf('\\')),"");
                    }
                }
            }
            /*
            if (check.Count > 0)
            {
                using(var f = File.OpenWrite(path))
                {
                    f.Position = 0;
                    f.WriteByte((byte)(f.ReadByte() + 50));
                    f.Position = 1;
                    f.WriteByte((byte)(f.ReadByte() + 50));
                }
                File.Replace(path, "c:\\antiv\\qarantine\\" 
                    + path.Substring(path.LastIndexOf('\\')+1), "c:\\antiv\\qarantine\\"
                    + path.Substring(path.LastIndexOf('\\')+1));
                return;
            }*/
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
    }
}
