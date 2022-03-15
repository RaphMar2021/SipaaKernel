using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SipaaKernel
{
    public partial class Boot : Form
    {
        bool showLoading = false;
        public Boot()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = new Point(0, 0);
            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.pictureBox1.Image = null;
            timer1.Start();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (!showLoading)
            {
                progressBar1.Increment(3);
                if (progressBar1.Value == 100)
                {
                    pictureBox1.Image = SipaaKernel.Properties.Resources._728;
                    progressBar1.Value = 0;
                    showLoading = true;
                }
            }
            else
            {
                progressBar1.Increment(3);
                if (progressBar1.Value == 100)
                {
                    SipaaKrnl.desktop.Show();
                    await Task.Delay(1000);
                    this.timer1.Stop();
                    this.Hide();
                }
            }
        }
    }
}
