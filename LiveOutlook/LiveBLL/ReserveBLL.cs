using System;
using System.Collections.Generic;
using System.Text;
using LiveOutlook.LiveDAL.DsLiveOutlookTableAdapters;
using System.Data;
using LiveOutlook.LiveDAL;
using LiveOutlook.LiveUIL.LiveCore;
using LiveOutlook.LiveUIL;

namespace LiveOutlook.LiveBLL
{
    class ReserveBLL
    {
#region Declarations

        private static TblReserveTableAdapter daReserve;
        private static DsLiveOutlook.TblReserveDataTable dtReserve;
        private static DsLiveOutlook.TblReserveRow drwReserve;
        private static int n = 0;
        private static DataTable dt;

#endregion

#region Methods

        internal static DataTable GetAllReserves()
        {
            try
            {
                dt = new DataTable();
                daReserve = new TblReserveTableAdapter();
                dtReserve = new DsLiveOutlook.TblReserveDataTable();
                daReserve.Fill(dtReserve);
                dt = dtReserve;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Reserve Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllReservesByID()
        {
            try
            {
                ReserveInfo.Recs = false;
                dt = new DataTable();
                daReserve = new TblReserveTableAdapter();
                dtReserve = new DsLiveOutlook.TblReserveDataTable();
                daReserve.FillByID(dtReserve, ReserveInfo.Day, ReserveInfo.Month,ReserveInfo.Year);
                dt = dtReserve;
                if (dt.Rows.Count > 0)
                {
                    ReserveInfo.Recs = true;
                }
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Reserve Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static int DeleteReserve()
        {

            n = 0;
            try
            {
                daReserve = new TblReserveTableAdapter();
                n = daReserve.Delete1(ReserveInfo.Day, ReserveInfo.Month, ReserveInfo.Year);
                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not Deleted!");
                return n;
            }

        }
        internal static int AddReserve()
        {
            n = 0;
            try
            {
                daReserve = new TblReserveTableAdapter();
                dtReserve = new DsLiveOutlook.TblReserveDataTable();

                drwReserve = dtReserve.NewTblReserveRow();

                drwReserve.Day = ReserveInfo.Day;
                drwReserve.Month = ReserveInfo.Month;
                drwReserve.Year = ReserveInfo.Year;
                drwReserve.MaxAppointments = ReserveInfo.MaxAppointments;

                dtReserve.AddTblReserveRow(drwReserve);

                n = daReserve.Update(dtReserve);

                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not saved !");
                return n;
            }
        }
        internal static int UpdateReserve()
        {
            n = 0;
            try
            {
                daReserve = new TblReserveTableAdapter();
                dtReserve = new DsLiveOutlook.TblReserveDataTable();
                daReserve.FillByID(dtReserve, ReserveInfo.Day, ReserveInfo.Month, ReserveInfo.Year);

                drwReserve = dtReserve[0];

                drwReserve.BeginEdit();

                drwReserve.Day = ReserveInfo.NewDay;
                drwReserve.Month = ReserveInfo.NewMonth;
                drwReserve.Year = ReserveInfo.NewYear;
                drwReserve.MaxAppointments = ReserveInfo.MaxAppointments;

                drwReserve.EndEdit();

                n = daReserve.Update(dtReserve);

                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not saved !");
                return n;
            }

        }

        internal static bool IsReserve()
        {
            n = 0;
            try
            {
                dt = new DataTable();
                daReserve = new TblReserveTableAdapter();
                n = Convert.ToInt32(daReserve.ReserveApointments(AppointmentInfo.Appointment.Day, AppointmentInfo.Appointment.Month, AppointmentInfo.Appointment.Year));
               // System.Windows.Forms.MessageBox.Show(n.ToString());
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Reserve Information\n" + ex.Message, "Database connection failure");
            }
                if (AppointmentInfo.Capacity() > n)
                {
                    return true;
                }
                else
                {
                    return false;
                }
          

        }
        internal static bool IsReservedDay()
        {
            n = 0;
            try
            {
                dt = new DataTable();
                daReserve = new TblReserveTableAdapter();
                n = Convert.ToInt32(daReserve.GetReserveDay(AppointmentInfo.Appointment.Day, AppointmentInfo.Appointment.Month, AppointmentInfo.Appointment.Year));
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Reserve Information\n" + ex.Message, "Database connection failure");
            }
            if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
       


        }

#endregion
    }
}
