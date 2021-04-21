using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace ServiceConsole
{
    class Program
    {
        private static byte status;
        private static Base mybase;
        private static List<Thread> threads;
        private static List<string> pendingFiles;
        private static List<string> monitoringDirs;
        private static List<string[]> planningScan;


        protected static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            status = 1;
            mybase = new Base("c:\\antiv\\avdb.avb");
            threads = new List<Thread>();
            threads.Add(new Thread(ListenPipe));
            threads.Add(new Thread(mybase.load));
            pendingFiles = new List<string>();
            monitoringDirs = new List<string>();
            planningScan = new List<string[]>();
            foreach (var t in threads)
                t.Start();
        }

        protected static void OnStop()
        {
            foreach (var t in threads)
                if (t.IsAlive)
                    t.Abort();
        }

        private static void ListenPipe()
        {
            var pipeSecurity = new PipeSecurity();
            pipeSecurity.SetAccessRule(
                new PipeAccessRule(
                    new SecurityIdentifier(
                        WellKnownSidType.BuiltinUsersSid
                        , null
                        ), PipeAccessRights.ReadWrite
                        , AccessControlType.Allow));
            using (var pipe = new NamedPipeServerStream(
                "\\.\\antiv1"
                , PipeDirection.InOut
                , 1
                , PipeTransmissionMode.Message
                , PipeOptions.None
                , 32, 32
                , pipeSecurity
                ))
            {
                while (status != 0)
                {
                    if (!pipe.IsConnected)
                        pipe.WaitForConnection();
                    var str = Encoding.UTF8.GetBytes("AVService is running...");
                    if(pipe.IsConnected)
                    pipe.Write(str, 0, str.Length);
                }
            }
        }
    }
}
