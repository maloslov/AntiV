using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Pipes;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        //private NamedPipeClientStream pipe;
        private List<Task> threads;
        private string message;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            message = "";
            threads = new List<Task>();
            threads.Add(new Task(pipeStreamer));
            threads[0].Start();
            //pipeStreamer();
        }

        #region General
        private void checkService() 
        {
            using (var sc = new ServiceController("AVService"))
            {
                switch (sc.Status)
                {
                    case ServiceControllerStatus.Running:
                        lblStatus.Text = "Running";
                        btnSRun.Enabled = false;
                        btnSStop.Enabled = true;
                        break;
                    case ServiceControllerStatus.Stopped:
                        btnSRun.Enabled = true;
                        btnSStop.Enabled = false;
                        lblStatus.Text = "Stopped";
                        break;
                    default:
                        lblStatus.Text = "no data";
                        btnSRun.Enabled = false;
                        btnSStop.Enabled = false;
                        break;
                }
            }
        }

        private void btnSRun_Click(object sender, EventArgs e)
        {
            using(var p = new Process())
            {
                p.StartInfo = new ProcessStartInfo(
                        "c:\\Antiv\\servicecontrol.exe", 
                        "start");
                p.Start();
            }
        }

        private void btnSStop_Click(object sender, EventArgs e)
        {
            using (var p = new Process())
            {
                p.StartInfo = new ProcessStartInfo(
                        //"c:\\Antiv\\servicecontrol.exe","stop"
                    "c:\\antiv\\serviceconsole.exe"    
                    );
                try
                {
                    p.Start();
                }
                catch (Exception ex) 
                {
                    textLog.AppendText(ex.Message); 
                }
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {

        }

        private void btnFolder_Click(object sender, EventArgs e)
        {

        }

        private void btnScanStart_Click(object sender, EventArgs e)
        {

        }

        private void btnScanStop_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkService();
            lock (message)
            {
                textLog.AppendText(message);
                message = "";
            }
        }
        private void pipeStreamer()
        {
            using (var pipe = new NamedPipeClientStream(
                ".", "antiv1",
                PipeDirection.InOut,
                PipeOptions.None))
            {
                while (true)
                {
                    if (!pipe.IsConnected)
                    {
                        //try
                        {
                            pipe.Connect();
                        }
                        /*catch (Exception e)
                        {
                            lock (message)
                                message += e.ToString() + "\n";
                        }*/
                        var buf = new byte[32];
                        pipe.Read(buf, 0, buf.Length);
                        lock (message)
                            message += "Connected to service\n"
                                + Encoding.UTF8.GetString(buf);
                    }
                }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(var t in threads)
            {
                t.Wait();//Abort();
            }
        }
        #endregion

        #region Scanning

        #endregion

        #region Monitoring

        #endregion

        #region Planning

        #endregion

    }
}
