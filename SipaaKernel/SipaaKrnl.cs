using SipaaKernelCommunicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SipaaKernel
{

    public class SipaaKrnl : Kernel
    {
        public static SipaaSODE.Desktop desktop;
        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
        public override void OnKernelStartup()
        {
            var args = Environment.GetCommandLineArgs();
            Console.WriteLine("Sipaa Technology Operating System Kernel v1.0");
            IntPtr hWnd = GetConsoleWindow();
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, 0); //hide
            }
            foreach (string arg in args)
            {
                if (arg.Contains("--debugMode"))
                {
                    if (hWnd != IntPtr.Zero)
                    {
                        ShowWindow(hWnd, 1); //show
                    }
                }
                if (arg.Contains("--help"))
                {
                    Console.WriteLine("Optional arguments for boot SipaaOS :");
                    Console.WriteLine("How to use : stoskernel32.exe <arg>. Exemple : stoskernel32.exe --debugMode=true");
                    Console.WriteLine();
                    Console.WriteLine("--debugMode : Don't hide the kernel window");
                    Console.WriteLine("--help : Show all possible args");
                    Environment.Exit(0);
                }
            }
            BootOperatingSystem();
        }
        private void BootOperatingSystem()
        {
            desktop = new SipaaSODE.Desktop(SipaaSODE.UI.Theme.Dark, this);
            Application.Run(new Boot());
            //Thread.Sleep(3000);
            //Environment.Exit(0);
        }
    }
}
