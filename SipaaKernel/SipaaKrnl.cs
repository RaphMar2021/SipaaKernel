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
        // Please , don't break my Windows DLLs!
        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
        public override async void OnKernelStartup()
        {
            var args = Environment.GetCommandLineArgs();
            Console.WriteLine("Sipaa Technology Operating System Kernel v1.0");
            Console.WriteLine("Starting Log7cs...");
            await Task.Delay(1534);
            IntPtr hWnd = GetConsoleWindow();
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, 0); //hide
            }
            this.WriteLine("Started Log7cs!", "Logger");
            await Task.Delay(1328);
            this.WriteLine("Console Arguments : " + args, "dotNET");
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
            this.WriteLine("Loading assembly SipaaFramework v1.1.0...", "AssemblyLoader");
            this.WriteLine("Loading assembly SipaaSODE v4.0.0...", "AssemblyLoader");
            desktop = new SipaaSODE.Desktop(SipaaSODE.UI.Theme.Dark, this);
            this.WriteLine("Enabling visual styles...", "System.Windows.Forms");
            Application.EnableVisualStyles();
            this.WriteLine("Starting UI and boot of SipaaOS", "SipaaKernel");
            Application.Run(new Boot());
            //Thread.Sleep(3000);
            //Environment.Exit(0);
        }
    }
}
