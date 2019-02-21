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
    class PublicHolidayBLL
    {

#region Declarations

        private static TblPublicHolidayTableAdapter daPublicHoliday;
        private static DsLiveOutlook.TblPublicHolidayDataTable dtPublicHoliday;
        private static DsLiveOutlook.TblPublicHolidayRow drwPublicHoliday;
        private static int n = 0;
        private static DataTable dt;

#endregion

#region Methods

        internal static DataTable GetAllPublicHolidays()
        {
            try
            {
                dt = new DataTable();
                daPublicHoliday = new TblPublicHolidayTableAdapter();
                dtPublicHoliday = new DsLiveOutlook.TblPublicHolidayDataTable();
                daPublicHoliday.Fill(dtPublicHoliday);
                dt = dtPublicHoliday;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load PublicHoliday Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllPublicHolidaysByID()
        {
            try
            {
                PublicHolidayInfo.Recs = false;
                dt = new DataTable();
                daPublicHoliday = new TblPublicHolidayTableAdapter();
                dtPublicHoliday = new DsLiveOutlook.TblPublicHolidayDataTable();
                daPublicHoliday.FillByID(dtPublicHoliday, PublicHolidayInfo.Day, PublicHolidayInfo.Month);
                dt = dtPublicHoliday;
                if (dt.Rows.Count > 0)
                {
                    PublicHolidayInfo.Recs = true;
                }
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load PublicHoliday Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static int DeletePublicHoliday()
        {

            n = 0;
            try
            {
                daPublicHoliday = new TblPublicHolidayTableAdapter();
                n = daPublicHoliday.Delete1(PublicHolidayInfo.Day, PublicHolidayInfo.Month);
                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not Deleted!");
                return n;
            }

        }
        internal static int AddPublicHoliday()
        {
            n = 0;
            try
            {
                daPublicHoliday = new TblPublicHolidayTableAdapter();
                dtPublicHoliday = new DsLiveOutlook.TblPublicHolidayDataTable();

                drwPublicHoliday = dtPublicHoliday.NewTblPublicHolidayRow();

                drwPublicHoliday.Day = PublicHolidayInfo.Day;
                drwPublicHoliday.Month = PublicHolidayInfo.Month;

                dtPublicHoliday.AddTblPublicHolidayRow(drwPublicHoliday);

                n = daPublicHoliday.Update(dtPublicHoliday);

                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not saved !");
                return n;
            }
        }
        internal static int UpdatePublicHoliday()
        {
            n = 0;
            try
            {
                daPublicHoliday = new TblPublicHolidayTableAdapter();
                dtPublicHoliday = new DsLiveOutlook.TblPublicHolidayDataTable();
                daPublicHoliday.FillByID(dtPublicHoliday, PublicHolidayInfo.Day, PublicHolidayInfo.Month);

                drwPublicHoliday = dtPublicHoliday[0];

                drwPublicHoliday.BeginEdit();

                drwPublicHoliday.Day = PublicHolidayInfo.NewDay;
                drwPublicHoliday.Month = PublicHolidayInfo.NewMonth;
      
                drwPublicHoliday.EndEdit();

                n = daPublicHoliday.Update(dtPublicHoliday);

                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not saved !");
                return n;
            }

        }
        internal static bool IsHoliday()
        {
            n = 0;
            try
            {
                dt = new DataTable();
                daPublicHoliday = new TblPublicHolidayTableAdapter();
                n = Convert.ToInt32(daPublicHoliday.IsHoliday(AppointmentInfo.Appointment.Day, AppointmentInfo.Appointment.Month));
                //System.Windows.Forms.MessageBox.Show(AppointmentInfo.Appointment.ToString("dd/MM/yyy")+"\n"+ " Holiday:" + n.ToString());
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load PublicHoliday Information\n" + ex.Message, "Database connection failure");
            }
        if (AppointmentInfo.Capacity() > n)
                {
                    return false;
                }
                else
                {
                    return true;
                }

        }
#endregion

    }
}
