using System;
using System.Collections.Generic;
using System.IO.Pipes;
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

namespace AVClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private byte[] charToByte(String str)
        {
            var res = new byte[str.Length];
            for(int i = 0; i < str.Length; i++)
            {
                res[i] = (byte)str[i];
            }


            return res;
        }

        private void snd_Click(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start("C:\\Users\\Maloslov\\source\\repos\\AntiV\\Debug\\AVService.exe");

            var message = charToByte(msg.Text);
            //byte[] text = message;
            var pipe = 
                new NamedPipeClientStream(".",
                "avast",
                PipeDirection.InOut,
                PipeOptions.None,
                System.Security.Principal.TokenImpersonationLevel.None);
            pipe.Connect();
            //cannot write: ArgumentException
            pipe.Write(message, message.Length-1, message.Length);
            pipe.Close();
        }
    }
}
