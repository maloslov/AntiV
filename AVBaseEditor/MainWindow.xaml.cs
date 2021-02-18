using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        private List<BaseRecord> Base { get; set; }
        private string BasePath { get; set; }

        //public List<Phone> Phones { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            App.Phones = new List<Phone>();
            Base = new List<BaseRecord>();
            dataGrid.ItemsSource = Base;
            //Test Example
            Base.Add(new BaseRecord("Petya", "exe", 10101010, 25, 5465656, 1, 56));
            Base.Add(new BaseRecord("Vanya", "txt", 11101010, 25, 5465321, 2, 16));
            Base.Add(new BaseRecord("Sasha", "png", 01101011, 27, 5466235, 21, 26));
            Base.Add(new BaseRecord("Misha", "mp3", 10111011, 27, 5456173, 11, 26));
            Base.Add(new BaseRecord("Pasha", "mp4", 10111111, 29, 5656213, 12, 15));
            Base.Add(new BaseRecord("Maxim", "pdf", 10110110, 28, 4656978, 14, 51));
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(dataGrid.CurrentItem.ToString());
            BaseRecord data = (BaseRecord)dataGrid.CurrentItem;
            Base.Remove(Base.Find(x => 
                x.VirusName.Equals(data.VirusName)));
            dataGrid.Items.Refresh();
            
        }

        private void LoadBaseFromDirectory(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "directory";
            openFileDialog.CheckFileExists = false;
            openFileDialog.Filter = "Directory|Directory";
            openFileDialog.FileName = "Directory";
            if (openFileDialog.ShowDialog() == true)
            {
                BasePath = openFileDialog.FileName.TrimEnd("Directory.directory".ToCharArray());

            }
        }
        private void SaveBaseToDirectory(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void AppendBaseRecord(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void DeleteRecordsInRange(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void CalculateMalwareData(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
