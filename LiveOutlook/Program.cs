using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace LiveOutlook
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LiveOutlook.LiveApp.LiveCore.frmLogin());
            

            //Application.Run(new LiveApp.FrmReportVisit(4));
        }
    }
}