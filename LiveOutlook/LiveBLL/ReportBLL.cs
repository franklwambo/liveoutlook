using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LiveOutlook.LiveUIL;
using LiveOutlook.LiveUIL.LiveCore;
using LiveOutlook.LiveDAL;
using LiveOutlook.LiveDAL.DsLiveReportTableAdapters;
using LiveOutlook.LiveApp.LiveReport;
namespace LiveOutlook.LiveBLL
{
    class ReportBLL
    {
        private static VisitScheduleTableAdapter daVist;
        private static DsLiveReport.VisitScheduleDataTable dtVisit;
        private static DsLiveReport.VisitScheduleRow drwVisit;

        private static ActiveTableAdapter daActive;
        private static DsLiveReport.ActiveDataTable dtActive;
        private static DsLiveReport.ActiveRow drwActive;

        private static VisitCountTableAdapter daVistC;
        private static DsLiveReport.VisitCountDataTable dtVisitC;
        private static DsLiveReport.VisitCountRow drwVisitC;

        private static rptVisit rptvisit1;
        private static rptActive rptavisit;
        private static rptDefaulter rptdefaulter;
        private static rptVisitCount rptvisitcount;

        #region Visit Schedule 1
        internal static rptVisit ViewAllVisitSchedule()
        {
            try
            {
                rptvisit1 = new rptVisit();
                daVist = new VisitScheduleTableAdapter();
                dtVisit = new DsLiveReport.VisitScheduleDataTable();
                daVist.Fill(dtVisit);
                rptvisit1.SetDataSource((DataTable)dtVisit);

            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Error occured when retriving data");
            }
            return rptvisit1;
        }
        internal static rptVisit ViewAllVisitScheduleRegNo(string reg)
        {
            try
            {
                rptvisit1 = new rptVisit();
                daVist = new VisitScheduleTableAdapter();
                dtVisit = new DsLiveReport.VisitScheduleDataTable();
                daVist.FillByRegNo(dtVisit,reg);
                rptvisit1.SetDataSource((DataTable)dtVisit);

            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Error occured when retriving data");
            }
            return rptvisit1;
        }
        internal static rptVisit ViewAllVisitSchedule(string strsearch)
        {
            try
            {
                rptvisit1 = new rptVisit();
                daVist = new VisitScheduleTableAdapter();
                dtVisit = new DsLiveReport.VisitScheduleDataTable();
                daVist.Fill(dtVisit);
                //rptvisit.DataDefinition.FormulaFields[2].Text = "\"" + paramValue + "\"";
                //strsearch = "{VisitSchedule.RegNo} <> ''AND Datediff('d',{VisitSchedule.Appointment},Cdate({@PeriodEnding}))>2 AND IsNull({VisitSchedule.ReturnDate})";
                rptvisit1.SetDataSource((DataTable)dtVisit);
                rptvisit1.RecordSelectionFormula = strsearch;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Error occured when retriving data");
            }
            return rptvisit1;
        }
        internal static rptActive ViewAllActive(string strsearch)
        {
            try
            {
                rptavisit = new rptActive();
                daActive = new ActiveTableAdapter();
                dtActive = new DsLiveReport.ActiveDataTable();
                daActive.FillByA(dtActive);
                rptavisit.SetDataSource((DataTable)dtActive);
                rptavisit.RecordSelectionFormula = strsearch;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Error occured when retriving data");
            }
            return rptavisit;
        }
        internal static rptActive ViewAllActive(string strsearch, DateTime start, DateTime stop)
        {
            try
            {
                rptavisit = new  rptActive();
                daActive = new ActiveTableAdapter();
                dtActive = new DsLiveReport.ActiveDataTable();
                daActive.Fill(dtActive,start.Date,stop.Date);
                rptavisit.SetDataSource((DataTable)dtActive);
                rptavisit.RecordSelectionFormula = strsearch;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Error occured when retriving data");
            }
            return rptavisit;
        }
        internal static rptVisit ViewAllVisitSchedule(string reg,string strsearch)
        {
            try
            {
                rptvisit1 = new rptVisit();
                daVist = new VisitScheduleTableAdapter();
                dtVisit = new DsLiveReport.VisitScheduleDataTable();
                daVist.FillByRegNo(dtVisit,reg);
                rptvisit1.SetDataSource((DataTable)dtVisit);
                rptvisit1.RecordSelectionFormula = strsearch;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Error occured when retriving data");
            }
            return rptvisit1;
        }
        internal static rptDefaulter ViewAllDefaulters(string strsearch, string paramValue)
        {
            try
            {
                rptdefaulter = new rptDefaulter();
                daVist = new VisitScheduleTableAdapter();
                dtVisit = new DsLiveReport.VisitScheduleDataTable();
                daVist.Fill(dtVisit);
                rptdefaulter.DataDefinition.FormulaFields[2].Text = "\"" + paramValue + "\"";
                //strsearch = "{VisitSchedule.RegNo} <> ''AND Datediff('d',{VisitSchedule.Appointment},Cdate({@PeriodEnding}))>2 AND IsNull({VisitSchedule.ReturnDate})";
                rptdefaulter.SetDataSource((DataTable)dtVisit);
                rptdefaulter.RecordSelectionFormula = strsearch;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Error occured when retriving data");
            }
            return rptdefaulter;
        }        
        internal static rptVisitCount ViewAllVisitCount(string strsearch, string paramValue1,string paramValue2)
        {
            try
            {
                rptvisitcount = new rptVisitCount();
                daVistC = new VisitCountTableAdapter();
                dtVisitC = new DsLiveReport.VisitCountDataTable();
                daVistC.FillByDates(dtVisitC,Convert.ToDateTime(paramValue1).Date,Convert.ToDateTime(paramValue2).Date);
                rptvisitcount.DataDefinition.FormulaFields[2].Text = "\"" + paramValue1 + "\"";
                rptvisitcount.DataDefinition.FormulaFields[4].Text = "\"" + paramValue2 + "\"";
                //strsearch = "{VisitSchedule.RegNo} <> ''AND Datediff('d',{VisitSchedule.Appointment},Cdate({@PeriodEnding}))>2 AND IsNull({VisitSchedule.ReturnDate})";
                rptvisitcount.SetDataSource((DataTable)dtVisitC);
                rptvisitcount.RecordSelectionFormula = strsearch;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Error occured when retriving data");
            }
            return rptvisitcount;
        }
        #endregion

    }
}
