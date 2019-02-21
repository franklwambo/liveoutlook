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
    class SettingsBLL
    {

#region Declarations

        private static TblSettingsTableAdapter daSettings;
        private static DsLiveOutlook.TblSettingsDataTable dtSettings;
        private static DsLiveOutlook.TblSettingsRow drwSettings;
        private static int n = 0;
        private static DataTable dt;

#endregion

#region Methods

        internal static DataTable GetAllSettingss()
        {
            try
            {
                SettingsInfo.Recs = false;
                dt = new DataTable();
                daSettings = new TblSettingsTableAdapter();
                dtSettings = new DsLiveOutlook.TblSettingsDataTable();
                daSettings.Fill(dtSettings);
                dt = dtSettings;
                if (dt.Rows.Count > 0)
                {
                    SettingsInfo.Recs = true;
                }
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Settings Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllSettingssByID()
        {
            try
            {
                SettingsInfo.Recs = false;
                dt = new DataTable();
                daSettings = new TblSettingsTableAdapter();
                dtSettings = new DsLiveOutlook.TblSettingsDataTable();
                daSettings.FillByID(dtSettings, SettingsInfo.ADay);
                dt = dtSettings;
                if (dt.Rows.Count > 0)
                {
                    SettingsInfo.Recs = true;
                }
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Settings Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static int DeleteSettings()
        {

            n = 0;
            try
            {
                daSettings = new TblSettingsTableAdapter();
                n = daSettings.Delete1(SettingsInfo.ADay);
                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not Deleted!");
                return n;
            }

        }
        internal static int UpdateSettings()
        {
            n = 0;
            try
            {
                daSettings = new TblSettingsTableAdapter();
                dtSettings = new DsLiveOutlook.TblSettingsDataTable();
                daSettings.FillByID(dtSettings, SettingsInfo.ADay);

                drwSettings = dtSettings[0];

                drwSettings.BeginEdit();

                drwSettings.MaxAppointments = SettingsInfo.MaxAppointments;
                                
                drwSettings.EndEdit();
                
                n = daSettings.Update(dtSettings);

                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not saved !");
                return n;
            }

        }
        internal static bool WorkingDayOK()
        {
            n = 0;
            try
            {
                dt = new DataTable();
                daSettings = new  TblSettingsTableAdapter();
                n = Convert.ToInt32(daSettings.GetCapacity(AppointmentInfo.Appointment.ToString("dddd")));
               // System.Windows.Forms.MessageBox.Show(AppointmentInfo.Appointment.ToString("dd/MM/yyy") + "\n" + "Capacity" + AppointmentInfo.Appointment.ToString("dddd") + " :" + n.ToString());
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Reserve Information\n" + ex.Message, "Database connection failure");
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
        internal static bool WorkingDayOK(string ageunit, int age)
        {
            n = 0;
            try
            {
                dt = new DataTable();
                daSettings = new TblSettingsTableAdapter();
                n = Convert.ToInt32(daSettings.GetCapacity(AppointmentInfo.Appointment.ToString("dddd")));
                // System.Windows.Forms.MessageBox.Show(AppointmentInfo.Appointment.ToString("dd/MM/yyy") + "\n" + "Capacity" + AppointmentInfo.Appointment.ToString("dddd") + " :" + n.ToString());
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Reserve Information\n" + ex.Message, "Database connection failure");
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
