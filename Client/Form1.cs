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
        private List<Thread> threads;
        private string message;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            message = "";
            threads = new List<Thread>();
            threads.Add(new Thread(pipeStreamer));
            threads[0].Start();
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
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            textPath.Text = openFileDialog1.FileName.ToLower();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            textPath.Text = folderBrowserDialog1.SelectedPath.ToLower();
        }

        private void btnScanStart_Click(object sender, EventArgs e)
        {

        }

        private void btnScanStop_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(var t in threads)
            {
                t.Abort();
            }
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
        #endregion

        #region Scanning

        private void btnAddScan_Click(object sender, EventArgs e)
        {
            if (textPath.Text.Length > 0)
            {
                foreach (DataGridViewRow r in dataScan.Rows)
                {
                    if (r.Cells[0].Value.Equals(textPath.Text))
                        return;
                }
                dataScan.Rows.Add(textPath.Text,"added");
            }
        }

        private void btnDelScan_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataScan.Rows)
            {
                if (r.Selected)
                    dataScan.Rows.Remove(r);
            }
        }
        #endregion

        #region Monitoring

        private void btnAddMonitor_Click(object sender, EventArgs e)
        {
            if (textPath.Text.Length > 0)
            {
                var str = textPath.Text.Substring(0,textPath.Text.LastIndexOf('\\'));
                foreach(DataGridViewRow r in dataMonitor.Rows)
                {
                    if (r.Cells[0].Value.Equals(str))
                        return;
                }
                dataMonitor.Rows.Add(str);
            }
        }

        private void btnDelMonitor_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataMonitor.Rows)
            {
                if (r.Selected)
                    dataMonitor.Rows.Remove(r);
            }
        }
        #endregion

        #region Planning

        private void btnAddPlan_Click(object sender, EventArgs e)
        {
            if (textPath.Text.Length > 0)
            {
                var time = String.Format("{0}:{1}{2}"
                    , comboHour.Text
                    , comboMinute1.Text
                    , comboMinute2.Text);
                foreach (DataGridViewRow r in dataPlan.Rows)
                {
                    if (r.Cells[0].Value.Equals(textPath.Text)
                        && r.Cells[1].Value.Equals(time))
                        return;
                }
                dataPlan.Rows.Add(textPath.Text, time);
            }

        }

        private void btnDelPlan_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow r in dataPlan.Rows)
            {
                if (r.Selected)
                    dataPlan.Rows.Remove(r);
            }
        }
        #endregion

        private void comboHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
