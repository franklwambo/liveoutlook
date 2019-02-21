using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LiveOutlook.LiveUIL.LiveCore;
using LiveOutlook.LiveBLL.LiveCore;

namespace LiveOutlook.LiveApp.LiveCore
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        private static LiveStart LIS;
        
        private void bgWLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            
            LIS.LoadISInteractive();
        }

          private void Splash_Load(object sender, EventArgs e)
        {
            Interactive.STATUS = "Initialzing...";
            lblLoad.Text = Interactive.STATUS;
            label3.Text = "Version " + Application.ProductVersion;

            LIS = new LiveStart(bgWLoad); 
            bgWLoad.RunWorkerAsync();
        }

        private void bgWLoad_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblLoad.Text = Interactive.STATUS;
            pBLoad.Value = e.ProgressPercentage;
            if (pBLoad.Value==pBLoad.Maximum) 
            {
                StartHRS();
            }
        }

        private void bgWLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgWLoad.Dispose();
            LIS = null;
            this.Hide();
        }
        private void StartHRS()
        {
            FrmMain f = new  FrmMain();
            f.Show();
            this.TopMost = true;
            this.Activate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}