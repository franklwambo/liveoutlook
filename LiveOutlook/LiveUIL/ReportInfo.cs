using System;
using System.Collections.Generic;
using System.Text;
using LiveOutlook.LiveBLL;
using System.ComponentModel;
using CrystalDecisions.Windows.Forms;
using System.Windows.Forms;

namespace LiveOutlook.LiveUIL
{
    class ReportInfo:ReportBLL
    {
        private static BackgroundWorker bw;
        
        public ReportInfo()
        {
        }
        public ReportInfo(BackgroundWorker b)
        {
            bw = b;
        }
        
        public void ViewReport(CrystalReportViewer LRptV, int type)
        {
            bw.ReportProgress(1);
            switch (type)
            {
                case 1: // Visit Schedule [1]
                    if (LRptV.InvokeRequired)
                    {
                        LRptV.Invoke(new MethodInvoker(delegate { LRptV.ReportSource =ViewAllVisitSchedule(); }));
                    }
                    break;
            }
            bw.ReportProgress(100);
        }
        public void ViewReportRegNo(CrystalReportViewer LRptV, int type,string regno)
        {
            bw.ReportProgress(1);
            switch (type)
            {
                case 4: // Visit Schedule [1]
                    if (LRptV.InvokeRequired)
                    {
                        LRptV.Invoke(new MethodInvoker(delegate { LRptV.ReportSource = ViewAllVisitScheduleRegNo(regno); }));
                    }
                    break;
            }
            bw.ReportProgress(100);
        }
        public void ViewReport(CrystalReportViewer LRptV, int type,string strsearch)
        {
            bw.ReportProgress(1);
            switch (type)
            {
                case 3: // Visit Schedule [1]
                    if (LRptV.InvokeRequired)
                    {
                        LRptV.Invoke(new MethodInvoker(delegate { LRptV.ReportSource = ViewAllVisitSchedule(strsearch); }));
                    }
                    break;
            }
            bw.ReportProgress(100);
        }
        public void ViewReport(CrystalReportViewer LRptV, int type, string strsearch,bool useparam,string param)
        {
            bw.ReportProgress(1);
            switch (type)
            {
                case 3: // Visit Schedule [1]
                    if (LRptV.InvokeRequired)
                    {
                        LRptV.Invoke(new MethodInvoker(delegate { LRptV.ReportSource = ViewAllDefaulters(strsearch,param); }));
                    }
                    break;
            }
            bw.ReportProgress(100);
        }
        public void ViewReport(CrystalReportViewer LRptV, int type, string strsearch, bool useparam, string param1,string param2)
        {
            bw.ReportProgress(1);
            switch (type)
            {
                case 3: // Visit Schedule [1]
                    if (LRptV.InvokeRequired)
                    {
                        LRptV.Invoke(new MethodInvoker(delegate { LRptV.ReportSource = ViewAllVisitCount(strsearch, param1, param2); }));
                    }
                    break;
            }
            bw.ReportProgress(100);
        }
        public void ViewReportA(CrystalReportViewer LRptV, int type, string strsearch)
        {
            bw.ReportProgress(1);
            switch (type)
            {
                case 3: // Visit Schedule [1]
                    if (LRptV.InvokeRequired)
                    {
                        LRptV.Invoke(new MethodInvoker(delegate { LRptV.ReportSource = ViewAllActive(strsearch); }));
                    }
                    break;
            }
            bw.ReportProgress(100);
        }
        public void ViewReport(CrystalReportViewer LRptV, int type, string strsearch,DateTime startdate,DateTime stopdate)
        {
            bw.ReportProgress(1);
            switch (type)
            {
                case 3: // Visit Schedule [1]
                    if (LRptV.InvokeRequired)
                    {
                        LRptV.Invoke(new MethodInvoker(delegate { LRptV.ReportSource = ViewAllActive(strsearch, startdate, stopdate); }));
                    }
                    break;
            }
            bw.ReportProgress(100);
        }
        public void ViewReport(CrystalReportViewer LRptV, int type, string strsearch,string regno)
        {
            bw.ReportProgress(1);
            switch (type)
            {
                case 3: // Visit Schedule [1]
                    if (LRptV.InvokeRequired)
                    {
                        LRptV.Invoke(new MethodInvoker(delegate { LRptV.ReportSource = ViewAllVisitSchedule(strsearch,regno); }));
                    }
                    break;
            }
            bw.ReportProgress(100);
        }
    }
}
