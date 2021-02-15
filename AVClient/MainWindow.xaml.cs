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
        private NamedPipeClientStream Pipe { get; }
        private const int BUFSIZE = 128;
        public MainWindow()
        {
            InitializeComponent();
            Pipe =
                new NamedPipeClientStream(".",
                "antiv",
                PipeDirection.InOut,
                PipeOptions.None,
                System.Security.Principal.TokenImpersonationLevel.None);
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
            if(!Pipe.IsConnected)
                Pipe.Connect(10);
            var message = charToByte(msg.Text);
            var buffer = new byte[BUFSIZE];
            try
            {
                Pipe.Write(message, 0, message.Length);
                Pipe.Read(buffer, 0, buffer.Length);
                res.AppendText("Received message: "
                    + byteToChar(buffer) + "\r\n");
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Pipe connection has broken", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Pipe.IsConnected)
            {
                Pipe.Connect();
            }
            byte[] exit = charToByte("exit");
            Pipe.Write(exit, 0, exit.Length);
            Pipe.Close();
        }
    }
}
