using System;
using System.Collections.Generic;
using System.Text;
using LiveOutlook.LiveBLL;
using System.Data;
using System.Windows.Forms;
using LiveOutlook.LiveUIL.LiveCore;

namespace LiveOutlook.LiveUIL
{
    class PublicHolidayInfo:PublicHolidayBLL
    {

#region Declarations

        private static int _Day;
        private static int _Month;
        private static int _NewDay;
        private static int _NewMonth;
        private static DataRow[] myr;
        private static int n = 0;
        private static bool _Recs = false;

#endregion

#region Properties

        public static int Day
        {
            get
            {
                return _Day;
            }
            set {_Day = value; }
        }
        public static int Month
        {
            get
            {
                return _Month;
            }
            set { _Month = value; }
        }
        public static int NewDay
        {
            get
            {
                return _NewDay;
            }
            set { _NewDay = value; }
        }
        public static int NewMonth
        {
            get
            {
                return _NewMonth;
            }
            set { _NewMonth = value; }
        }
        public static bool Recs
        {
            get { return _Recs; }
            set { _Recs = value; }
        }

#endregion

#region Methods

        public int ShowPublicHoliday()
        {
            n = 0;
            myr = GetAllPublicHolidaysByID().Select();
            if (Recs)
            {
                n = 1;
                foreach (DataRow r in myr)
                {
                    Day = Convert.ToInt32(r["Day"].ToString());
                    Month = Convert.ToInt32(r["Month"].ToString());
                }
            }
            return n;
        }
        public ListView lvPublicHoliday(ListView lv)
        {
            myr = GetAllPublicHolidays().Select("", "Month ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["Day"].ToString();
                l.SubItems.Add(Convert.ToDateTime("1/" + r["Month"].ToString() + "/" + "1999").ToString("MMMM"));
                l.SubItems.Add( r["Month"].ToString());
                lv.Items.Add(l);
            }
            return lv;
        }
    
        public bool NewPublicHoliday()
        {
            bool ok = false;
            if (AddPublicHoliday() > 0)
            {
                ok = true;
                Interactive.LInfo("PublicHoliday added successfully", "New PublicHoliday");
            }
            return ok;

        }
        public bool EditPublicHoliday()
        {
            bool ok = false;
            if (UpdatePublicHoliday() > 0)
            {
                ok = true;
                Interactive.LInfo("PublicHoliday Updated successfully", "Edit PublicHoliday");
            }
            return ok;
        }
        public bool RemovePublicHoliday()
        {

            bool ok = false;
            if (DeletePublicHoliday() > 0)
            {
                ok = true;
                Interactive.LInfo("PublicHoliday Deleted successfully", "Delete PublicHoliday");
            }
            return ok;
        }

        public bool DateIsHoliday()
        {
            return IsHoliday();
        }


#endregion
    }
}
