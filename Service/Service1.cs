using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public partial class Service1 : ServiceBase
    {
        private NamedPipeServerStream pipe;
        private Thread listener;

        public Service1()
        {
            InitializeComponent();
            listener = new Thread(ListenPipe);
            pipe = new NamedPipeServerStream("antiv", PipeDirection.InOut, 2);
        }

        protected override void OnStart(string[] args)
        {
            listener.Start();
        }

        protected override void OnStop()
        {
            listener.Abort();
        }

        private void ListenPipe()
        {
            
            pipe.WaitForConnection();
            var str = Encoding.UTF8.GetBytes("AVService is running...");
            pipe.Write(str, 0, str.Length);

        }
    }
}
