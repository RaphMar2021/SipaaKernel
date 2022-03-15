using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SipaaKernelCommunicationServices
{
    public class Kernel
    {
        public Kernel() { OnKernelStartup(); }
        public virtual void OnKernelStartup()
        {
        }
        public virtual void OnKernelShutdownOrReboot()
        {
        }
        public void WriteLine(string text, string state)
        {
            Console.WriteLine("[" + DateTime.Now.ToString("g") + "," + state + "] " + text);
        }
        /// <summary>
        /// Shutdown the kernel by SipaaPowerAPI
        /// </summary>
        public virtual async void SPAShutdown(int shutdownCode)
        {
            WriteLine("Shutting down...", "SPAShutdown");
            await Task.Delay(1000);
            OnKernelShutdownOrReboot();
            Environment.Exit(shutdownCode);
        }
        /// <summary>
        /// Reboot the kernel by SipaaPowerAPI
        /// </summary>
        public virtual async void SPAReboot()
        {
            WriteLine("Rebooting...", "SPAReboot");
            await Task.Delay(1000);
            OnKernelShutdownOrReboot();
            Application.Restart();
            //System.Diagnostics.Process.Start(Assembly.GetExecutingAssembly().Location);
            //Environment.Exit(0);
        }
    }
}
