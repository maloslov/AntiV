using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceControl
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
                return;
            var service = new System.ServiceProcess.ServiceController("AVService");
            switch (args[0])
            {
                case "start":
                    if(service.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                    try
                    {
                        service.Start();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    break;
                case "stop":
                    if(service.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                    try
                    {
                        service.Stop();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    break;
            }
        }
    }
}
