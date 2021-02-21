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
            Base.Add(new BaseRecord("Petya", "exe", 0b_1010_1010, 25, 5465656, 1, 56));
            Base.Add(new BaseRecord("Vanya", "txt", 0b_1110_1010, 25, 5465321, 2, 16));
            Base.Add(new BaseRecord("Sasha", "png", 0b_0110_1011, 27, 5466235, 21, 26));
            Base.Add(new BaseRecord("Misha", "mp3", 0b_1011_1011, 27, 5456173, 11, 26));
            Base.Add(new BaseRecord("Pasha", "mp4", 0b_1011_1111, 29, 5656213, 12, 15));
            Base.Add(new BaseRecord("Maxim", "pdf", 0b_1011_0110, 28, 4656978, 14, 51));
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
            openFileDialog.DefaultExt = "Directory";
            openFileDialog.CheckFileExists = false;
            openFileDialog.Filter = "Directory|Directory";
            openFileDialog.FileName = "Directory";
            if (openFileDialog.ShowDialog() == true)
            {
                BaseDirectory = openFileDialog.FileName.Substring(0, 
                    openFileDialog.FileName.LastIndexOf('\\')+1);
                MessageBox.Show(BaseDirectory);
            }
        }
        private void SaveBaseToDirectory(object sender, RoutedEventArgs e)
        {
            if (BaseDirectory == null)
                LoadBaseFromDirectory(sender, e);

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
            throw new NotImplementedException();
        }
        private void CalculateMalwareData(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
