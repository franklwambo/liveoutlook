using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LiveOutlook.LiveUIL;

namespace LiveOutlook.LiveApp
{
    public partial class FrmReportVisit : Form
    {

        private static bool ActiveReport = false;
        private static bool ShowReg = false;
        private static bool TT = false;
        private static bool TF = false;
        private static bool FT = false;
        private static bool FF = false;
        private static int ReportType=-1;
        private static string RegNo = string.Empty;
        private static bool UseParam = false;
        private static string Param = string.Empty;
        private static string Param2 = string.Empty;

        public FrmReportVisit()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " [v" + Application.ProductVersion + "]  | " + this.Text;
            RegNo = string.Empty;
            ShowReg = false;
            ActiveReport = false;
            ReportType = -1;
        }
        public FrmReportVisit(string regno)
        {
            InitializeComponent();
            ActiveReport = false;
            RegNo = regno;
            ShowReg = true;
            ReportType = -1;
        }
        public FrmReportVisit(bool activereport)
        {
            InitializeComponent();
            RegNo = string.Empty;
            ShowReg = false;
            ActiveReport = activereport;
            ReportType = -1;
        }
        public FrmReportVisit(int reportType)
        {
            InitializeComponent();
            RegNo = string.Empty;
            ShowReg = false;
            ActiveReport = false;
            ReportType = reportType;
        }
        private static ReportInfo RptInfo;
        private static ClassificationInfo myC;
        private static DateTime SearchStartDate;
        private static DateTime SearchEndDate;
        private static DateTime SearchTempDate;
        private static string SearchSex;
        private static int SearchStartAge;
        private static int SearchEndAge;
        private static int SearchTempAge;
        private static string SearchRefBy;
        private static string SearchRefTo;
        private static string SearchART;
        private static string strSearch;

        private static int Section = 1;

        private void FrmReportVisit_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoadDefaults(ReportType);
            if (ShowReg)
            {
                chkAge.Enabled = false;
                lvSex.Enabled = false;
                nudStartAge.Enabled = false;

                nudEndAge.Enabled = false;
                RptInfo = new ReportInfo(bgWLive);
                Section = 4;
                bgWLive.RunWorkerAsync();
            }
            this.Cursor = Cursors.Default;
            
        }

        private void bgWLive_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (Section)
            {
                case 1:
                    RptInfo.ViewReport(LiveReportViewer, Section);
                    break;
                case 2:
                    RptInfo.ViewReport(LiveReportViewer, Section, strSearch);
                    break;
                case 3:
                    if (ShowReg)
                    {
                        RptInfo.ViewReport(LiveReportViewer, Section, strSearch,RegNo);
                    }
                    else
                    {
                        if (ActiveReport)
                        {
                            if (TT)
                            {
                                RptInfo.ViewReport(LiveReportViewer, Section, strSearch, SearchStartDate, SearchEndDate);
                            }
                            else if (FT)
                            {
                                RptInfo.ViewReport(LiveReportViewer, Section, strSearch, SearchStartDate, SearchStartDate);
                            }
                            else if (TF)
                            {
                                RptInfo.ViewReport(LiveReportViewer, Section, strSearch, SearchEndDate, SearchEndDate);
                            }
                            else if(FF)
                            {
                                RptInfo.ViewReportA(LiveReportViewer, Section, strSearch);
                            }
                        }
                        else
                        {
                            switch (ReportType)
                            {
                                case 3:
                                    RptInfo.ViewReport(LiveReportViewer, Section, strSearch, UseParam, Param);
                                    break;
                                case 4:
                                    RptInfo.ViewReport(LiveReportViewer, Section, strSearch, UseParam, Param,Param2);
                                    break;
                                default:
                                    RptInfo.ViewReport(LiveReportViewer, Section, strSearch);
                                    break;
                            }
                        }
                    }
                    break;
                case 4:
                    RptInfo.ViewReportRegNo(LiveReportViewer,Section,RegNo);
                    break;

            }
        }

        private void bgWLive_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = "Please wait...";
            pbStatus.MarqueeAnimationSpeed = 100;
        }

        private void bgWLive_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblStatus.Text = "Ready";
            pbStatus.Style = ProgressBarStyle.Blocks;
            pbStatus.Value = 0;
            RptInfo = null;
            bgWLive.Dispose();
            btnGenerate.Enabled = true;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Section = 3;
            
            this.Cursor = Cursors.WaitCursor;
            
            //DID NOT ATTEND strSearch = @"IsNull({VisitSchedule.Days Missed})"; 
            //ATTEND strSearch = @"{VisitSchedule.Days Missed}<=0 OR {VisitSchedule.Days Missed}>=0 ";
            //UNSCHEDULED strSearch = @"{VisitSchedule.Days Missed}<0 ";
            //LATE strSearch = @"{VisitSchedule.Days Missed}>0 ";
            //SCHEDULED strSearch = @"{VisitSchedule.Days Missed}=0 ";

            Search();
            RptInfo = new ReportInfo(bgWLive);
            bgWLive.RunWorkerAsync();
        }

        private void LoadDefaults()
        {
            myC.lvClassification(lvRefBy, "ReferredBy", false);
            myC.lvClassification(lvRefTo, "ReferredTo", false);
            myC.lvClassification(lvART, "Category", false);
            myC.lvClassification(lvAppointment, "Appointments", true);
        }
        private void LoadDefaults(int reportType)
        {
            myC = new ClassificationInfo();
            myC.lvClassification(lvRefBy, "ReferredBy", false);
            myC.lvClassification(lvRefTo, "ReferredTo", false);
            myC.lvClassification(lvART, "Category", false);
            myC.lvClassification(lvState, "Outcome", false);
            switch (reportType)
            {
                case 3:
                    myC.lvClassification(lvAppointment, "Appointments", "ID='DEFAULTER'", true);
                    dtpStart.Checked = false;
                    dtpStart.Enabled = false;
                    try
                    {
                        foreach (ListViewItem l in lvAppointment.Items)
                        {
                            l.Checked = true;
                        }
                    }
                    catch { }
                    lvAppointment.Enabled = false;
                    dtpEnd.Checked = true;
                    lvRefBy.Enabled = false;
                    lvRefTo.Enabled = false;
                    break;
                default:
                    myC.lvClassification(lvAppointment, "Appointments", "ID<>'DEFAULTER'", true);
                    //myC.lvClassification(lvAppointment, "Appointments", true);
                    break;
            }
        }
        private void Search()
        {
            bool Sdate = false;
            bool Edate = false;
            int SexCount = lvSex.CheckedItems.Count;
            int RefByCount = lvRefBy.CheckedItems.Count;
            int RefToCount = lvRefTo.CheckedItems.Count;
            int ARTCount = lvART.CheckedItems.Count;
            int AppointmentCount = lvAppointment.CheckedItems.Count;
            int StateCount = lvState.CheckedItems.Count;
            SearchStartDate = SearchEndDate = SearchTempDate = DateTime.Today;
            SearchStartAge = SearchEndAge = SearchTempAge = 0;

            strSearch = "({VisitSchedule.RegNo} <> '')";

            #region Date

            switch (ReportType)
            {
                case 3:
                    if (dtpEnd.Checked)
                    {
                        UseParam = true;
                        Param = dtpEnd.Value.ToString("dd MMM yyyy");
                    }
                    break;
                case 4:
                    UseParam = true;
                    if (dtpStart.Checked)
                    {
                        Param = dtpStart.Value.ToString("dd MMM yyyy");
                    }
                    if (dtpEnd.Checked)
                    {
                        Param2 = dtpEnd.Value.ToString("dd MMM yyyy");
                    }
                    break;
                default:
                    if (dtpStart.Checked && dtpEnd.Checked)
                    {
                        SearchStartDate = dtpStart.Value.Date;
                        SearchEndDate = dtpEnd.Value.Date;
                        if (SearchStartDate > SearchEndDate)
                        {
                            SearchTempDate = SearchStartDate;
                            SearchStartDate = SearchEndDate;
                            SearchEndDate = SearchTempDate;
                        }

                        strSearch += " AND ({VisitSchedule.Appointment} >=CDate('" + SearchStartDate + "') AND {VisitSchedule.Appointment} <=CDate('" + SearchEndDate + "') ) ";
                    }
                    else
                    {
                        if (dtpStart.Checked)
                        {
                            SearchStartDate = dtpStart.Value.Date;
                            strSearch += " AND ({VisitSchedule.Appointment} =CDate('" + SearchStartDate + "'))";
                        }
                        if (dtpEnd.Checked)
                        {
                            SearchEndDate = dtpEnd.Value.Date;
                            strSearch += " AND ({VisitSchedule.Appointment} =CDate('" + SearchEndDate + "'))";
                        }
                    }
                    if (ActiveReport)
                    {
                        if (dtpEnd.Checked && dtpStart.Checked)
                        {
                            TT = true;
                        }
                        else if (!dtpEnd.Checked && dtpStart.Checked)
                        {
                            FT = true;
                        }
                        else if (dtpEnd.Checked && !dtpStart.Checked)
                        {
                            TF = true;
                        }
                        else
                        {
                            FF = true;
                        }
                        strSearch = "({VisitSchedule.RegNo} <> '')";
                    }
                    break;
            }
            #endregion
            #region Sex
            if (SexCount > 0)
            {
                int n = 0;
                strSearch += " AND (";
                foreach (ListViewItem l in lvSex.CheckedItems)
                {
                    if (n > 0)
                    {
                        strSearch += " OR {VisitSchedule.Sex}='" + l.Text + "'";
                    }
                    else
                    {
                        strSearch += " {VisitSchedule.Sex}='" + l.Text + "'";
                    }
                    n += 1;
                }
                strSearch += " ) ";
            }
            #endregion
            #region Age
            if (chkAge.Checked)
            {
                SearchStartAge = (int)nudStartAge.Value;
                SearchEndAge = (int)nudEndAge.Value;

                if (SearchStartAge > SearchEndAge)
                {
                    SearchTempAge = SearchStartAge;
                    SearchStartAge = SearchEndAge;
                    SearchEndAge = SearchTempAge;
                }
                if (SearchStartAge == 0)
                {
                    strSearch += " AND ({VisitSchedule.Age} >=" + SearchStartAge + " AND {VisitSchedule.Age} <=" + SearchEndAge + " ) ";
                }
                else
                {
                    strSearch += " AND ({VisitSchedule.Age} >=" + SearchStartAge + " AND {VisitSchedule.Age} <=" + SearchEndAge + " ) AND ({VisitSchedule.AgeUnit}='Y')";
                }
            }
            #endregion
            #region RefBy
            if (RefByCount > 0)
            {
                int n = 0;
                strSearch += " AND (";
                foreach (ListViewItem l in lvRefBy.CheckedItems)
                {
                    if (n > 0)
                    {
                        strSearch += " OR {VisitSchedule.Referred By}='" + l.Text + "'";
                    }
                    else
                    {
                        strSearch += " {VisitSchedule.Referred By}='" + l.Text + "'";
                    }
                    n += 1;
                }
                strSearch += " ) ";
            }
            #endregion
            #region RefTo
            if (RefToCount > 0)
            {
                int n = 0;
                strSearch += " AND (";
                foreach (ListViewItem l in lvRefTo.CheckedItems)
                {
                    if (n > 0)
                    {
                        strSearch += " OR {VisitSchedule.Referred To}='" + l.Text + "'";
                    }
                    else
                    {
                        strSearch += " {VisitSchedule.Referred To}='" + l.Text + "'";
                    }
                    n += 1;
                }
                strSearch += " ) ";
            }
            #endregion
            #region ART
            if (ARTCount > 0)
            {
                int n = 0;
                strSearch += " AND (";
                foreach (ListViewItem l in lvART.CheckedItems)
                {
                    if (n > 0)
                    {
                        strSearch += " OR {VisitSchedule.ART}='" + l.Text + "' ";
                    }
                    else
                    {
                        strSearch += " {VisitSchedule.ART}='" + l.Text + "' ";
                    }
                    n += 1;
                }
                strSearch += " ) ";
            }
            #endregion
            #region State
            if (StateCount > 0)
            {
                int n = 0;
                strSearch += " AND (";
                foreach (ListViewItem l in lvState.CheckedItems)
                {
                    if (n > 0)
                    {
                        strSearch += " OR {VisitSchedule.CurrentStatus}='" + l.Text + "' ";
                    }
                    else
                    {
                        strSearch += " {VisitSchedule.CurrentStatus}='" + l.Text + "' ";
                    }
                    n += 1;
                }
                strSearch += " ) ";
            }
            #endregion
            #region Appointment
            if (AppointmentCount > 0 && (!ActiveReport))
            {
                int n = 0;
                strSearch += " AND (";
                foreach (ListViewItem l in lvAppointment.CheckedItems)
                {
                    if (n > 0)
                    {
                        strSearch += " OR " + l.SubItems[1].Text + " ";
                    }
                    else
                    {
                        strSearch += " " + l.SubItems[1].Text + " ";
                    }
                    n += 1;
                }
                strSearch += " ) ";
            }
            #endregion
        }

    }
}