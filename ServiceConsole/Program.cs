using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceConsole
{
    class Program
    {
        private static bool closing;
        private static System.Timers.Timer timer1;
        private static Base mybase;
        private static SHA256 sha256;
        private static Dictionary<byte[], string> header;
        private static List<Thread> threads;
        private static List<FileSystemWatcher> monitoringDirs;
        private static List<string[]> planningScan;
        private static Queue<string> messageIn;
        public static Queue<string> messageOut;
        private static Task scanner;


        protected static void Main(string[] args)
        {
            ScanEngine.ScanEngineSetDefault();
            messageIn = new Queue<string>();
            messageOut = new Queue<string>();
            messageOut.Enqueue("\u0000\u0004");
            Console.WriteLine("Starting");
            closing = false;
            mybase = new Base("c:\\antiv\\avdb.avb");
            threads = new List<Thread>();
            threads.Add(new Thread(ListenPipe));
            threads.Add(new Thread(Base.load));
            threads.Add(new Thread(commandParse));
            scanner = new Task(ScanEngine.scan);
            monitoringDirs = new List<FileSystemWatcher>();
            planningScan = new List<string[]>();
            timer1 = new System.Timers.Timer(20000);
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(checkTime);
            foreach (var t in threads)
                t.Start();
        }

        protected static void OnStop()
        {
            closing = true;
            while (threads[0].IsAlive) { }

        }

        private static void ListenPipe()
        {
            var pipeSecurity = new PipeSecurity();
            pipeSecurity.SetAccessRule(
                new PipeAccessRule(
                    new SecurityIdentifier(
                        WellKnownSidType.BuiltinUsersSid
                        , null), PipeAccessRights.ReadWrite
                        , AccessControlType.Allow));
            using (var pipe = new NamedPipeServerStream(
                "\\.\\antiv1", PipeDirection.InOut, 1
                , PipeTransmissionMode.Message
                , PipeOptions.None, 128, 128
                , pipeSecurity))
            {
                byte[] buf;
                while (!closing)
                {
                    buf = new byte[256];
                    if (!pipe.IsConnected)
                    {
                        pipe.WaitForConnection();
                        pipe.Read(buf, 0, buf.Length);//zaglushka
                    }
                    lock (messageOut)
                    {
                        if (messageOut.Count > 0)
                            buf = Encoding.UTF8.GetBytes(messageOut.Dequeue());
                        else buf = new byte[] { 0, 0 };
                    }
                    pipe.Write(buf, 0, buf.Length);
                    buf = new byte[128];
                    pipe.Read(buf, 0, buf.Length);
                    if (buf[1] != 0)
                        lock (messageIn)
                        {
                            messageIn.Enqueue(
                                   Encoding.UTF8.GetString(buf, 0, buf.Length));

                            Console.WriteLine("encoding read...");
                        }
                }
                buf = new byte[] { 0, 6 };
                pipe.Write(buf, 0, buf.Length);
                pipe.WaitForPipeDrain();
            }
        }

        private static void commandParse()
        {
            while (!closing)
            {
                string str = "\u0000\u0000";
                lock (messageIn)
                    if (messageIn.Count > 0)
                    {
                        str = messageIn.Dequeue();
                        Console.WriteLine("parsing...");
                    }
                switch (str[1])
                {
                    case '\u0000':
                        break;
                    case '\u0001': //disconnect
                        lock (threads)
                        {
                            threads[0].Abort();
                            while (threads[0].IsAlive) { }
                            threads[0] = new Thread(ListenPipe);
                            threads[0].Start();
                        }
                        break;
                    case '\u0002': //scan start
                        lock (messageOut)
                            messageOut.Enqueue("\u0000\u0004");
                        ScanEngine.closing = 0;
                        scanner.Start();
                        break;
                    case '\u0003': //scan stop
                        lock (messageOut)
                            messageOut.Enqueue("\u0000\u0005");
                        ScanEngine.closing = 1;
                        break;
                    case '\u0004': //scan add
                        lock (ScanEngine.toScan)
                        {
                            if (!ScanEngine.toScan.Contains(str.Substring(2).Trim('\0')))
                                ScanEngine.toScan.Add(str.Substring(2).Trim('\0'));
                        }
                        break;
                    case '\u0005': //scan remove
                        lock (ScanEngine.toScan)
                            ScanEngine.toScan.Remove(str.Substring(2).Trim('\0'));
                        break;
                    case '\u0006': //monitor add
                        using (var fsw = new FileSystemWatcher(str.Substring(2).Trim('\0')))
                        {
                            fsw.Created += new FileSystemEventHandler(newMonitor);
                            if (!monitoringDirs.Contains(fsw))
                                monitoringDirs.Add(fsw);
                        }
                        break;
                    case '\u0007': //monitor remove
                        using (var fsw = new FileSystemWatcher(str.Substring(2).Trim('\0')))
                        {
                            fsw.Created += new FileSystemEventHandler(newMonitor);
                            monitoringDirs.Remove(fsw);
                        }
                        break;
                    case '\u0008': //plan add
                        if (!planningScan.Contains(
                            str.Substring(2).Trim('\0').Split('|')))
                            planningScan.Add(str.Substring(2).Trim('\0').Split('|'));
                        break;
                    case '\u0009': //plan remove
                        planningScan.Remove(str.Substring(2).Trim('\0').Split('|'));
                        break;
                    case '\u000A': //received
                        break;
                    case '\u000B': //ask status
                        lock (messageOut)
                            messageOut.Enqueue("\u0000\u0004");
                        break;
                }
            }

        }

        private static void newMonitor(object sender,FileSystemEventArgs e)
        {
            lock (ScanEngine.toScan)
                ScanEngine.toScan.Add(e.FullPath);
        }

        static void checkTime(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (var p in planningScan)
            {
                if (DateTime.Compare(DateTime.Parse(p[1]), DateTime.Now) == 0)
                {
                    lock (ScanEngine.toScan)
                        ScanEngine.toScan.Add(p[0]);
                }
            }

        }
    }
}
