using System;
using System.Collections.Generic;
using System.Text;
using LiveOutlook.LiveBLL;
using System.Data;
using System.Windows.Forms;
using LiveOutlook.LiveUIL.LiveCore;

namespace LiveOutlook.LiveUIL
{
    class ReserveInfo:ReserveBLL
    {

#region Declarations

        private static int _Day;
        private static int _Month;
        private static int _Year;
        private static int _MaxAppointments;
        private static int _NewDay;
        private static int _NewMonth;
        private static int _NewYear;
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
            set { _Day = value; }
        }
        public static int Month
        {
            get
            {
                return _Month;
            }
            set { _Month = value; }
        }
        public static int Year
        {
            get
            {
                return _Year;
            }
            set { _Year= value; }
        }
        public static int MaxAppointments
        {
            get
            {
                return _MaxAppointments;
            }
            set { _MaxAppointments = value; }
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
        public static int NewYear
        {
            get
            {
                return _NewYear;
            }
            set { _NewYear = value; }
        }
        public static bool Recs
        {
            get { return _Recs; }
            set { _Recs = value; }
        }
        

#endregion

#region Methods

        public int ShowReserve()
        {
            n = 0;
            myr = GetAllReservesByID().Select();
            if (Recs)
            {
                n = 1;
                foreach (DataRow r in myr)
                {
                    Day = Convert.ToInt32(r["Day"].ToString());
                    Month = Convert.ToInt32(r["Month"].ToString());
                    Year = Convert.ToInt32(r["Year"].ToString());
                    MaxAppointments = Convert.ToInt32(r["MaxAppointments"].ToString());
                }
            }
            return n;
        }
        public ListView lvReserve(ListView lv)
        {
            myr = GetAllReserves().Select();
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                string dt = r["Day"].ToString() + "/" + r["Month"].ToString() + "/" + r["Year"].ToString();
                l = new ListViewItem();
                l.Text = Convert.ToDateTime(dt).ToLongDateString();
                l.SubItems.Add(r["MaxAppointments"].ToString());
                lv.Items.Add(l);
            }
            return lv;
        }

        public bool NewReserve()
        {
            bool ok = false;
            if (AddReserve() > 0)
            {
                ok = true;
                Interactive.LInfo("Reserve added successfully", "New Reserve");
            }
            return ok;

        }
        public bool EditReserve()
        {
            bool ok = false;
            if (UpdateReserve() > 0)
            {
                ok = true;
                Interactive.LInfo("Reserve Updated successfully", "Edit Reserve");
            }
            return ok;
        }
        public bool RemoveReserve()
        {

            bool ok = false;
            if (DeleteReserve() > 0)
            {
                ok = true;
                Interactive.LInfo("Reserve Deleted successfully", "Delete Reserve");
            }
            return ok;
        }
        public bool DateIsReserve()
        {
            return IsReserve();
        }
        public bool DateIsReserved()
        {
            return IsReservedDay();
        }

#endregion
    }
}
