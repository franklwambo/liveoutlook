using System;
using System.Collections.Generic;
using System.Text;
using LiveOutlook.LiveBLL;
using System.Data;

namespace LiveOutlook.LiveUIL
{
    class SettingsInfo:SettingsBLL
    {
#region Declarations

        private static string _ADay = string.Empty;
        private static int _MaxAppointments;
        private static bool _Recs = false;
        public static int Mon = 0;
        public static int Tue = 0;
        public static int Wed = 0;
        public static int Thr = 0;
        public static int Fri = 0;
        public static int Sat = 0;
        public static int Sun = 0;
        private static int n = 0;
        DataRow[] myr;
        
#endregion

#region Properties

        public static string ADay
        {
            get
            {
                return _ADay;
            }
            set { _ADay = value; }
        }
        public static int MaxAppointments
        {
            get
            {
                return _MaxAppointments;
            }
            set { _MaxAppointments = value; }
        }
        public static bool Recs
        {
            get { return _Recs; }
            set { _Recs = value; }
        }

#endregion

#region Methods

        public int ShowSettings()
        {
            n = 0;
            myr = GetAllSettingss().Select();
            if (Recs)
            {
                n = 1;
                foreach (DataRow r in myr)
                {
                    switch (r["ADay"].ToString())
                    {
                        case "Monday":
                            Mon = Convert.ToInt32(r["MaxAppointments"].ToString());
                            break;
                        case "Tuesday":
                            Tue= Convert.ToInt32(r["MaxAppointments"].ToString());
                            break;
                        case "Wednesday":
                            Wed = Convert.ToInt32(r["MaxAppointments"].ToString());
                            break;
                        case "Thursday":
                            Thr = Convert.ToInt32(r["MaxAppointments"].ToString());
                            break;
                        case "Friday":
                            Fri = Convert.ToInt32(r["MaxAppointments"].ToString());
                            break;
                        case "Saturday":
                            Sat = Convert.ToInt32(r["MaxAppointments"].ToString());
                            break;
                        case "Sunday":
                            Sun = Convert.ToInt32(r["MaxAppointments"].ToString());
                            break;
                    }

                }
            }
            return n;
        }
        public bool EditSettings()
        {
            bool ok = false;
            if (UpdateSettings() > 0)
            {
                ok = true;
  
            }
            return ok;
        }
        public bool DateIsOK()
        {
            return WorkingDayOK();
        }
        public bool DateIsOK(string ageunit, int age)
        {
            return WorkingDayOK(ageunit,age);
        }
#endregion
    }
}
