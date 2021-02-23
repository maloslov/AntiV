using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AVBaseEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<BaseRecord> Base { get; set; }
        private string BaseDirectory { get; set; }
        private const string Sign = "basov";
        private const short recordCount = 512;

        public MainWindow()
        {
            InitializeComponent();
            Base = new List<BaseRecord>();
            dataGrid.ItemsSource = Base;
            //Test Example
            for (int i = 0; i < 5; i++)
            {
                Base.Add(new BaseRecord("Petya", "exe", 0b_1010_1010, 25, 5465656, 1, 56));
                Base.Add(new BaseRecord("Vanya", "txt", 0b_1110_1010, 25, 5465321, 2, 16));
                Base.Add(new BaseRecord("Sasha", "png", 0b_0110_1011, 27, 5466235, 21, 26));
                Base.Add(new BaseRecord("Misha", "mp3", 0b_1011_1011, 27, 5456173, 11, 26));
                Base.Add(new BaseRecord("Pasha", "mp4", 0b_1011_1111, 29, 5656213, 12, 15));
                Base.Add(new BaseRecord("Maxim", "pdf", 0b_1011_0110, 28, 4656978, 14, 51));
            }
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach(BaseRecord rec in dataGrid.SelectedItems)
            {
                Base.Remove(rec);
            }
            dataGrid.Items.Refresh();
            
        }

        private void LoadBaseFromDirectory(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "avb";
            openFileDialog.CheckFileExists = false;
            openFileDialog.Filter = "Directory|Directory|AntiV Base|*.avb";
            openFileDialog.FileName = "Directory";
            if (openFileDialog.ShowDialog() == true)
            {
                BaseDirectory = openFileDialog.FileName.Substring(0, 
                    openFileDialog.FileName.LastIndexOf('\\')+1);
            }
            FileStream fs = new FileStream(BaseDirectory + "base.avb", FileMode.Open);
            byte[] buffer = new byte[Sign.Length];
            fs.Read(buffer, 0, buffer.Length);
            if(!Sign.Equals(btos(buffer)))
            {
                MessageBox.Show("Base file is suspicious!", "Warning",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Base.Clear();
            int c = fs.ReadByte();
            while(c != -1)
            {
                if(c==10 || c == 13) //CR or LF
                {
                    c = fs.ReadByte();
                    if (buffer.Length > 7)
                        Base.Add(new BaseRecord(buffer));
                    buffer = new byte[0];
                    continue;
                }
                buffer = buffer.Append((byte)c).ToArray();

                c = fs.ReadByte();

            }
            dataGrid.Items.Refresh();
        }
        private void SaveBaseToDirectory(object sender, RoutedEventArgs e)
        {
            if (BaseDirectory == null)
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "avb";
                saveFileDialog.CheckFileExists = false;
                saveFileDialog.Filter = "Directory|Directory|AntiV Base|*.avb";
                saveFileDialog.FileName = "base";
                if (saveFileDialog.ShowDialog() == true)
                {
                    BaseDirectory = saveFileDialog.FileName.Substring(0,
                        saveFileDialog.FileName.LastIndexOf('\\') + 1);
                }
            }

            FileStream fs;
            //check file
            if (File.Exists(BaseDirectory + "base.avb"))
            {
                //check file header
                fs = new FileStream(BaseDirectory + "base.avb",
                    FileMode.Open);
                byte[] buf = new byte[Sign.Length];
                fs.Read(buf, 0, buf.Length);
                if (!Sign.Equals(btos(buf)))
                {
                    MessageBox.Show("Base file is suspicious!", "Warning",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else
            {
                //create & sign file
                fs = new FileStream(BaseDirectory + "base.avb",
                    FileMode.CreateNew);
                fs.Write(stob(Sign), 0, Sign.Length);
            }
            byte[] buffer = BitConverter.GetBytes(recordCount).Concat(stob("\r\n")).ToArray();
            fs.Write(buffer, 0, buffer.Length);
            foreach(var r in Base)
            {
                byte[] record = r.ToBytes();
                fs.Write(record, 0, record.Length);
                fs.Write(stob("\r\n"), 0, 2);
            }
        }
        public static string btos(byte[] bytes)
        {
            string res = "";
            foreach (char c in bytes)
                res += c;
            return res;
        }
        public static byte[] stob(string str)
        {
            byte[] res = new byte[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                res[i] = (byte)str[i];
            }
            return res;
        }
        private void AppendBaseRecord(object sender, RoutedEventArgs e)
        {
            if(boxName.Text.Length > 0 && boxType.Text.Length > 0
                && boxSign.Text.Length > 0 && boxLen.Text.Length > 0
                && boxHash.Text.Length  > 0 && boxStart.Text.Length > 0
                && boxEnd.Text.Length > 0)
            {
                var record = new BaseRecord(boxName.Text, boxType.Text,
                    Convert.ToByte(boxSign.Text),
                    Convert.ToUInt32(boxLen.Text),
                    Convert.ToUInt32(boxHash.Text),
                    Convert.ToUInt32(boxStart.Text),
                    Convert.ToUInt32(boxEnd.Text));

                if (Base.Exists(x => x.Signature == record.Signature
                    && x.Length == record.Length
                    && x.Hash == record.Hash))
                {
                    return;
                }

                Base.Add(record);
                dataGrid.Items.Refresh();
            }
        }
        private void CalculateFromSignature(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();

        }
    }
}
