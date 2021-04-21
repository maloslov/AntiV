﻿using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace Service
{
    public partial class Service1 : ServiceBase
    {
        private byte status;
        private Base mybase;
        private List<Thread> threads;
        private List<string> pendingFiles;
        private List<string> monitoringDirs;
        private List<string[]> planningScan;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
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

        protected override void OnStop()
        {
            foreach (var t in threads)
                if (t.IsAlive)
                    t.Abort();
        }

        private void ListenPipe()
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
                ,PipeDirection.InOut
                ,1
                ,PipeTransmissionMode.Message
                ,PipeOptions.None
                ,32,32
                ,pipeSecurity
                ))
            {
                while (status != 0)
                {
                    if(!pipe.IsConnected)
                        pipe.WaitForConnection();
                    var str = Encoding.UTF8.GetBytes("AVService is running...");
                    pipe.Write(str, 0, str.Length);
                }
            }
        }
    }
}
