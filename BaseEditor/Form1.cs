using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseEditor
{
    public partial class Form1 : Form
    {
        private string buf = "";
        public Form1(string[] args)
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Start();
            if (args.Length > 0)
                openfromfile(args[0]);
        }

        #region tab2
        private void readExe_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Executable file|*.exe|Zip file|*.zip";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            textCPath.Text = openFileDialog1.FileName;
            textExe.Text = "";
            Task load = Task.Run(() =>
            {
                using (var f = File.Open(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    while (f.Position<f.Length)
                    {
                        lock (buf)
                            buf += (Convert.ToString(f.ReadByte()) + '|');
                    }
                }
            });
        }

        private void textExe_SelectionChanged(object sender, EventArgs e)
        {
            if (textExe.SelectionLength < 1) return;
            
            int count = 0, start = 0, end = 0,
                a = textExe.SelectionStart,
                b = a + textExe.SelectionLength;
            for (int i = 0; i < a; i++)
                if (textExe.Text.ElementAt(i).Equals('|'))
                { 
                    count++;
                    start = i+1;
                }
            textCStart.Text = count.ToString(); //offset start
            for (int i = a; i <= b+1; i++)
                if (textExe.Text.ElementAt(i).Equals('|'))
                {
                    end = i;
                    count++;
                }
            textCEnd.Text = count.ToString(); //offset end
            textCSign.Text = textExe.Text.Substring(start, end - start);

        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (textCSign.Text.Split('|').Length>7)
            {
                textStart.Text = textCStart.Text;
                textEnd.Text = textCEnd.Text;
                var str = textCSign.Text.Split('|');
                textLength.Text = str.Length.ToString();
                textPrefix.Text = "";
                for(int i = 0; i < 8; i++)
                {
                    textPrefix.AppendText(str[i]+'|');
                }
                textPrefix.Text = textPrefix.Text.Trim('|');
                var buf = new byte[str.Length];
                for(int i = 0; i < str.Length; i++)
                {
                    buf[i] = Byte.Parse(str[i]);
                }
                using(var hash = SHA256.Create())
                {
                    textHash.Text 
                        = String.Format("{0}",
                        BitConverter.ToUInt64(hash.ComputeHash(buf),0));
                }
                textType.Text = textCPath.Text.Substring(textCPath.Text.LastIndexOf('.'));
                tabControl1.SelectedTab = tabPage2;
            }
        }
        #endregion
        #region tab1
        private void openBase_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            {
                openFileDialog1.Filter = "AVBase file|*.avb";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                openfromfile(openFileDialog1.FileName);
            }
        }

        private void saveBase_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "AV data base file|*.avb";
            if (dataGridView1.RowCount < 1
                || saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            using (var f = File.OpenWrite(saveFileDialog1.FileName))
            {
                f.Write(Encoding.ASCII.GetBytes("basov"), 0, 5);
                byte[] buf = BitConverter.GetBytes(dataGridView1.RowCount);
                f.Write(buf, 0, buf.Length);
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.Index == dataGridView1.RowCount) break;

                    //write name
                    string str = (string)r.Cells[0].Value;
                    f.WriteByte(Convert.ToByte(str.Length));
                    f.Write(Encoding.ASCII.GetBytes(str), 0, str.Length);

                    //write filetype
                    str = (string)r.Cells[1].Value;
                    f.WriteByte(Convert.ToByte(str.Length));
                    f.Write(Encoding.ASCII.GetBytes(str), 0, str.Length);

                    //write prefix
                    var s = ((string)r.Cells[2].Value).Split('|');
                    f.WriteByte((byte)s.Length);
                    for (int i = 0; i < s.Length; i++)
                    {
                        f.WriteByte(Byte.Parse(s[i]));
                    }

                    //write hash
                    var h = Convert.ToUInt64(r.Cells[3].Value);
                    buf = BitConverter.GetBytes(h);
                    f.WriteByte((byte)buf.Length);
                    f.Write(buf, 0, buf.Length);

                    //write length
                    h = Convert.ToUInt64(r.Cells[4].Value);
                    buf = BitConverter.GetBytes(h);
                    f.WriteByte((byte)buf.Length);
                    f.Write(buf, 0, buf.Length);

                    //write offset start
                    h = Convert.ToUInt64(r.Cells[5].Value);
                    buf = BitConverter.GetBytes(h);
                    f.WriteByte((byte)buf.Length);
                    f.Write(buf, 0, buf.Length);

                    //write offset end
                    h = Convert.ToUInt64(r.Cells[6].Value);
                    buf = BitConverter.GetBytes(h);
                    f.WriteByte((byte)buf.Length);
                    f.Write(buf, 0, buf.Length);
                }
            }
        }

        private void addRow_Click(object sender, EventArgs e)
        {
            if(textPrefix.Text.Trim('|').Split('|').Length!=8 
                || textName.Text.Length < 1 || textStart.Text.Length<1
                || textEnd.Text.Length<1 || textHash.Text.Length<1
                || textLength.Text.Length < 1) 
            { return; }

            try
            {
                dataGridView1.Rows.Add(textName.Text,
                    textType.Text,
                    textPrefix.Text,
                    Convert.ToUInt64(textHash.Text),
                    Convert.ToUInt64(textLength.Text),
                    Convert.ToUInt64(textStart.Text),
                    Convert.ToUInt64(textEnd.Text));
            }
            catch (Exception) { }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(buf.Length > 0)
                lock (buf)
                {
                    textExe.AppendText(buf);
                    buf = "";
                }
        }
        private void openfromfile(string file)
        {
            try
            {
                using (var f = File.Open(file, FileMode.Open, FileAccess.Read))
                {
                    byte[] buf = new byte[9];
                    for (int j = 0; j < buf.Length; j++)
                    {
                        buf[j] = (byte)f.ReadByte();
                    }
                    if (!(buf[0] == 'b' && buf[1] == 'a' && buf[2] == 's'
                        && buf[3] == 'o' && buf[4] == 'v'))
                        return;
                    int rows = BitConverter.ToInt32(buf, 5);
                    for (int i = 0; i < rows; i++)
                    {
                        dataGridView1.Rows.Add();
                        //read name
                        int len = f.ReadByte();
                        buf = new byte[len];
                        for (int j = 0; j < len; j++)
                        {
                            buf[j] = (byte)f.ReadByte();
                        }
                        dataGridView1.Rows[i].Cells[0].Value
                            = Encoding.ASCII.GetString(buf);

                        //read file type
                        len = f.ReadByte();
                        buf = new byte[len];
                        for (int j = 0; j < len; j++)
                        {
                            buf[j] = (byte)f.ReadByte();
                        }
                        dataGridView1.Rows[i].Cells[1].Value
                            = Encoding.ASCII.GetString(buf);

                        //read prefix
                        len = f.ReadByte();
                        var str = "";
                        for (int j = 0; j < len; j++)
                        {
                            str += Convert.ToString(f.ReadByte()) + '|';
                        }
                        dataGridView1.Rows[i].Cells[2].Value
                            = str.Substring(0, str.Length - 1);

                        //read hash
                        len = f.ReadByte();
                        buf = new byte[len];
                        for (int j = 0; j < len; j++)
                        {
                            buf[j] = (byte)f.ReadByte();
                        }
                        dataGridView1.Rows[i].Cells[3].Value
                            = (BitConverter.ToUInt64(buf, 0));

                        //read length
                        len = f.ReadByte();
                        buf = new byte[len];
                        for (int j = 0; j < len; j++)
                        {
                            buf[j] = (byte)f.ReadByte();
                        }
                        dataGridView1.Rows[i].Cells[4].Value
                            = (BitConverter.ToUInt64(buf, 0));

                        //read offset start
                        len = f.ReadByte();
                        buf = new byte[len];
                        for (int j = 0; j < len; j++)
                        {
                            buf[j] = (byte)f.ReadByte();
                        }
                        dataGridView1.Rows[i].Cells[5].Value
                            = BitConverter.ToUInt64(buf, 0);

                        //read offset end
                        len = f.ReadByte();
                        buf = new byte[len];
                        for (int j = 0; j < len; j++)
                        {
                            buf[j] = (byte)f.ReadByte();
                        }
                        dataGridView1.Rows[i].Cells[6].Value
                            = BitConverter.ToUInt64(buf, 0);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
