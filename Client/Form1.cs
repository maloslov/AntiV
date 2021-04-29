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
        private bool closing;
        private Thread tPipe;
        private Queue<string> messageOut;
        private Queue<string> messageIn;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start();
            closing = false; 
            messageOut = new Queue<string>();
            messageIn = new Queue<string>();
            tPipe = (new Thread(pipeStreamer));
            tPipe.Start();
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
            lock (messageOut)
                messageOut.Enqueue("\u0000\u0002");
        }

        private void btnScanStop_Click(object sender, EventArgs e)
        {
            lock (messageOut)
                messageOut.Enqueue("\u0000\u0003");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
            while (tPipe.IsAlive) { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkService();
            commandParse();
        }

        private void pipeStreamer()
        {
            using (var pipe = new NamedPipeClientStream(
                ".", "antiv1",
                PipeDirection.InOut,
                PipeOptions.None))
            {
                    byte[] buf;
                while (!closing)
                {
                    if (!pipe.IsConnected)
                    {
                        pipe.Connect();
                        buf = new byte[] { 0, 11 };
                        pipe.Write(buf, 0, buf.Length);
                    }
                    buf = new byte[128];
                    pipe.Read(buf, 0, buf.Length);
                    if (buf[1] != 0)
                        lock (messageIn)
                            messageIn.Enqueue(
                                Encoding.UTF8.GetString(buf, 0, buf.Length));
                    lock (messageOut)
                    {
                        if (messageOut.Count > 0)
                            buf = Encoding.UTF8.GetBytes(messageOut.Dequeue());
                        else buf = new byte[] { 0, 0 };
                    }
                    pipe.Write(buf, 0, buf.Length);
                }
                buf = new byte[256];
                pipe.Read(buf, 0, buf.Length);
                lock (messageIn)
                    messageIn.Enqueue(
                        Encoding.UTF8.GetString(buf, 0, buf.Length));
                buf = new byte[] { 0, 1 };
                pipe.Write(buf, 0, buf.Length);
                pipe.WaitForPipeDrain();
            }
        }

        private void commandParse()
        {
            string str = "\u0000\u0000";
            if (messageIn.Count > 0)
                lock (messageIn)
                    str = messageIn.Dequeue();
            else return;
            switch (str[1])
            {
                case '\u0000':
                    break;
                case '\u0001': //error
                    textLog.Text += ("Error: " + str.Substring(2) + "\r\n");
                    break;
                case '\u0002': //file scanning
                    textLog.Text += ("Scanned file "+ str.Substring(2)+"\r\n");
                    break;
                case '\u0003': //monitored new file
                    textLog.AppendText("New file in "+str.Substring(2)+"\r\n");
                    break;
                case '\u0004': //if scanning
                    btnScanStart.Enabled = false;
                    btnScanStop.Enabled = true;
                    textLog.AppendText("Scanner is working\r\n");
                    break;
                case '\u0005': //if not scanning
                    btnScanStart.Enabled = true;
                    btnScanStop.Enabled = false;
                    textLog.AppendText("Scanner is stopped\r\n");
                    break;
                case '\u0006': //disconnect
                    tPipe.Abort();
                    tPipe.Start();
                    textLog.AppendText("Disconnected\r\n");
                    break;
                case '\u0007': //infected file
                    textLog.AppendText("Found a virus: " + str.Substring(2)+"\r\n");
                    var s = str.Substring(2).Split('|');
                    dataQarantine.Rows.Add(s[0], s[1]);
                    break;
                case '\u0008': //Connected
                    textLog.AppendText("Connected.\r\n");
                    btnScanStart.Enabled = true;
                    btnScanStop.Enabled = false;
                    break;
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
                lock (messageOut)
                    messageOut.Enqueue("\u0000\u0004" + textPath.Text);
            }
        }

        private void btnDelScan_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataScan.Rows)
            {
                if (r.Selected)
                    dataScan.Rows.Remove(r);
                lock (messageOut)
                    messageOut.Enqueue("\u0000\u0005" + textPath.Text);
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
                lock (messageOut)
                    messageOut.Enqueue("\u0000\u0006" + str);
            }
        }

        private void btnDelMonitor_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataMonitor.Rows)
            {
                if (r.Selected)
                {
                    dataMonitor.Rows.Remove(r);
                    lock (messageOut)
                        messageOut.Enqueue("\u0000\u0007" + r.Cells[0].Value);
                }
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
                lock (messageOut)
                    messageOut.Enqueue("\u0000\u0008" 
                        + textPath.Text + '|' + time);
            }

        }

        private void btnDelPlan_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataPlan.Rows)
            {
                if (r.Selected)
                {
                    dataPlan.Rows.Remove(r);
                    lock (messageOut)
                        messageOut.Enqueue("\u0000\u0009" 
                            + r.Cells[0].Value + '|' + r.Cells[1].Value);
                }
            }
        }
        #endregion

        private void comboHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
