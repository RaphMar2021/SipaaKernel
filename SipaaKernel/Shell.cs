using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SipaaKernel
{
    public class Shell
    {
        public Shell()
        {
            Console.Title = "SipaaOS";
            Console.WriteLine("SipaaOS");
            Console.WriteLine("Copyright Sipa Env. " + DateTime.Now.ToString("yyyy"));
            GetImput();
        }

        private void GetImput()
        {
            Console.WriteLine();
            Console.Write("root:>");
            var im = Console.ReadLine();
            Console.WriteLine();
            if (im == "help")
            {
                Console.WriteLine("All commands\n" +
                    "help : Show all commands\n" +
                    "startsode : Start SODE\n" +
                    "cls : Clear console\n" +
                    "reboot : Reboot SipaaOS\n" +
                    "shutdown : Shutdown SipaaOS");
            }else if (im == "startsode")
            {
                new SipaaSODE.Desktop(SipaaSODE.UI.Theme.Dark, null, null, null).Show();
            }else if(im == "cls")
            {
                Console.Clear();
            }else if (im == "reboot")
            {
                Application.Restart();
                Environment.Exit(0);
            }else if(im == "shutdown")
            {
                Application.Exit();
            }
            Console.WriteLine();
            GetImput();
        }
    }
}
