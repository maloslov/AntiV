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
        private string byteToChar(byte[] buf)
        {
            var res = "";
            for (int i = 0; i < buf.Length; i++)
                res += (char)buf[i];
            return res;
        }

        private void snd_Click(object sender, RoutedEventArgs e)
        {
            var message = charToByte(msg.Text);
            var pipe = 
                new NamedPipeClientStream(".",
                "avast",
                PipeDirection.InOut,
                PipeOptions.None,
                System.Security.Principal.TokenImpersonationLevel.None);
            pipe.Connect();
            pipe.Write(message, 0, message.Length);
            var buffer = new byte[128];
            pipe.Read(buffer, 0, buffer.Length);
            res.AppendText("Received message: " + byteToChar(buffer) + "\r\n");
            pipe.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var pipe =
                new NamedPipeClientStream(".",
                "avast",
                PipeDirection.InOut,
                PipeOptions.None,
                System.Security.Principal.TokenImpersonationLevel.None);
            pipe.Connect();
            byte[] exit = charToByte("exit");
            pipe.Write(exit, 0, exit.Length);
            pipe.Close();
        }
    }
}
