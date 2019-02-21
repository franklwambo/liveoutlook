using System;
using System.Collections.Generic;
using System.Text;
using LiveOutlook.LiveDAL.DsLiveOutlookTableAdapters;
using LiveOutlook.LiveDAL;
using System.Data;
using LiveOutlook.LiveUIL;
using LiveOutlook.LiveUIL.LiveCore;

namespace LiveOutlook.LiveBLL
{
    class AppointmentBLL
    {

#region Declarations

        private static AllAppointmentsTableAdapter daAll;
        private static DsLiveOutlook.AllAppointmentsDataTable dtAll;
        private static SeenByTableAdapter daSBy;
        private static DsLiveOutlook.SeenByDataTable dtSBy;
        private static TblAppointmentTableAdapter daAppointment;
        private static DsLiveOutlook.TblAppointmentDataTable dtAppointment;
        private static DsLiveOutlook.TblAppointmentRow drwAppointment;
        private static int n = 0;
        private static DataTable dt;
        private static bool ok = false;
#endregion

#region Methods

        internal static DataTable GetAllAppointments()
        {
            try
            {
                dt = new DataTable();
                daAppointment = new TblAppointmentTableAdapter();
                dtAppointment = new DsLiveOutlook.TblAppointmentDataTable();
                daAppointment.Fill(dtAppointment);
                dt = dtAppointment;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Appointment Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllAppointmentsAll()
        {
            try
            {
                dt = new DataTable();
                daAll = new  AllAppointmentsTableAdapter();
                dtAll = new  DsLiveOutlook.AllAppointmentsDataTable();
                daAll.Fill(dtAll);
                dt = dtAll;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Appointment Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllAppointmentsByID()
        {
            try
            {
                AppointmentInfo.Recs = false;
                dt = new DataTable();
                daAppointment = new TblAppointmentTableAdapter();
                dtAppointment = new DsLiveOutlook.TblAppointmentDataTable();
                daAppointment.FillByID(dtAppointment,AppointmentInfo.AppointmentID);
                dt = dtAppointment;
                if (dt.Rows.Count > 0)
                {
                    AppointmentInfo.Recs = true;
                }
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Appointment Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllAppointmentsByRegNo()
        {
            try
            {
                AppointmentInfo.Recs = false;
                dt = new DataTable();
                daAppointment = new TblAppointmentTableAdapter();
                dtAppointment = new DsLiveOutlook.TblAppointmentDataTable();
                daAppointment.FillByRegNo(dtAppointment, AppointmentInfo.RegNo);
                dt = dtAppointment;
                if (dt.Rows.Count > 0)
                {
                    AppointmentInfo.Recs = true;
                }
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Appointment Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllSeenBy()
        {
            try
            {
                dt = new DataTable();
                daSBy = new SeenByTableAdapter();
                dtSBy = new DsLiveOutlook.SeenByDataTable();
                daSBy.Fill(dtSBy);
                dt = dtSBy;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Appointment Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static int DeleteAppointment()
        {
            n = 0;
            try
            {
                daAppointment = new TblAppointmentTableAdapter();
                n = daAppointment.Delete1(AppointmentInfo.AppointmentID);
                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not Deleted!");
                return n;
            }

        }
        internal static int AddAppointment()
        {
            n = 0;
            try
            {
                daAppointment = new TblAppointmentTableAdapter();
                dtAppointment = new DsLiveOutlook.TblAppointmentDataTable();

                drwAppointment = dtAppointment.NewTblAppointmentRow();

                drwAppointment.RegNo = AppointmentInfo.RegNo.Trim();
                drwAppointment.Appointment = AppointmentInfo.Appointment;
               
                
                drwAppointment.Period = AppointmentInfo.Period;
                drwAppointment.PeriodName = AppointmentInfo.PeriodName;
                drwAppointment.SeenBy = AppointmentInfo.SeenBy.Trim().ToUpper();
                drwAppointment.VisitDate = AppointmentInfo.VisitDate;
                drwAppointment.VisitStatus = AppointmentInfo.VisitStatus;
                drwAppointment.AStatus = AppointmentInfo.AStatus;
                
                dtAppointment.AddTblAppointmentRow(drwAppointment);

                n = daAppointment.Update(dtAppointment);
                daAppointment.UpdateDates();

                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not saved !");
                return n;
            }
        }
        internal static int UpdateAppointment()
        {
            n = 0;
            try
            {
                daAppointment = new TblAppointmentTableAdapter();
                dtAppointment = new DsLiveOutlook.TblAppointmentDataTable();
                daAppointment.FillByID(dtAppointment,AppointmentInfo.AppointmentID);

                drwAppointment = dtAppointment[0];

                drwAppointment.BeginEdit();

                drwAppointment.RegNo = AppointmentInfo.RegNo.Trim();
                
                    drwAppointment.Appointment = AppointmentInfo.Appointment;
                
                drwAppointment.Appointment = AppointmentInfo.Appointment;
                drwAppointment.Period = AppointmentInfo.Period;
                drwAppointment.PeriodName = AppointmentInfo.PeriodName;
                drwAppointment.SeenBy = AppointmentInfo.SeenBy.Trim().ToUpper();
                drwAppointment.VisitDate = AppointmentInfo.VisitDate;
                drwAppointment.VisitStatus = AppointmentInfo.VisitStatus;
                drwAppointment.AStatus = AppointmentInfo.AStatus;
                drwAppointment.EndEdit();

                n = daAppointment.Update(dtAppointment);
                daAppointment.UpdateDates();
                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not saved !");
                return n;
            }

        }
        internal static int UpdateAppointmentReturn()
        {
            n = 0;
            try
            {
                daAppointment = new TblAppointmentTableAdapter();
                dtAppointment = new DsLiveOutlook.TblAppointmentDataTable();
                n=daAppointment.UpdateVisit(AppointmentInfo.ReturnDate, AppointmentInfo.AppointmentID);
                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Appointment was not uypdated !");
                return n;
            }

        }
        internal static int Capacity()
        {
            n = 0;
            try
            {
                daAppointment = new TblAppointmentTableAdapter();
                n = Convert.ToInt32(daAppointment.GetNoOfAppointments(Convert.ToDateTime(AppointmentInfo.Appointment.ToString("dd/MM/yyyy"))));
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Appointment Information\n" + ex.Message, "Database connection failure");
            }
            return n+1;
        }

#endregion

    }
}
