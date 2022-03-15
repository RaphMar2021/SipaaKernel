using SipaaKernelCommunicationServices;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SipaaKernel
{
    internal class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
            var kernel = new SipaaKrnl();
            Console.ReadKey();
        }
    }
}
