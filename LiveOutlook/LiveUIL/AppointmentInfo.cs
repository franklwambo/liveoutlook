using System;
using System.Collections.Generic;
using System.Text;
using LiveOutlook.LiveBLL;
using System.Windows.Forms;
using LiveOutlook.LiveUIL.LiveCore;
using System.Data;
using System.Drawing;

namespace LiveOutlook.LiveUIL
{
    class AppointmentInfo : AppointmentBLL
    {
#region Declarations

        private static long _AppointmentID = -1;
        private static string _RegNo = string.Empty;
        private static DateTime _Appointment;
        private static string _SeenBy= string.Empty;
        private static DateTime _VisitDate;
        private static int _Period;
        private static string _PeriodName= string.Empty;
        private static bool _VisitStatus = false;
        private static string _AStatus = string.Empty;
        private static DateTime _ReturnDate;
        private static string _NewRegNo = string.Empty;
        private static DateTime _NewAppointment;
        
        private static DataRow[] myr;
        private static int n = 0;
        private static bool _Recs = false;

#endregion

#region Properties

        public static long AppointmentID
        {
            get { return _AppointmentID; }
            set { _AppointmentID = value; }
        }
        public static string RegNo
        {
            get
            {
                return _RegNo;
            }
            set { _RegNo = value; }
        }
        public static DateTime Appointment
        {
            get { return _Appointment; }
            set { _Appointment = value; }
        }
        public static int Period
        {
            get { return _Period; }
            set { _Period = value; }
        }
        public static string PeriodName
        {
            get { return _PeriodName; }
            set { _PeriodName = value; }
        }
        public static string SeenBy
        {
            get
            {
                return _SeenBy;
            }
            set
            {
                _SeenBy = value;
            }
        }
        public static DateTime VisitDate
        {
            get
            {
                return _VisitDate;
            }
            set { _VisitDate = value; }
        }
        public static bool VisitStatus
        {
            get { return _VisitStatus; }
            set { _VisitStatus = value; }
        }
        public static string AStatus
        {
            get { return _AStatus; }
            set { _AStatus = value; }
        }
        public static DateTime ReturnDate
        {
            get { return _ReturnDate; }
            set { _ReturnDate = value; }
        }
        public static string NewRegNo
        {
            get
            {
                return _NewRegNo;
            }
            set { _NewRegNo = value; }
        }
        public static DateTime NewAppointmentT
        {
            get { return _NewAppointment; }
            set { _NewAppointment = value; }
        }
        public static bool Recs
        {
            get { return _Recs; }
            set { _Recs = value; }
        }

#endregion

#region Methods

        public int ShowAppointment()
        {
            n = 0;
            myr = GetAllAppointmentsByID().Select();
            if (Recs)
            {
                n = 1;
                foreach (DataRow r in myr)
                {
                    RegNo = r["RegNo"].ToString();
                    Appointment = Convert.ToDateTime(r["Appointment"].ToString());
                    SeenBy =r["SeenBy"].ToString();
                    VisitDate =  Convert.ToDateTime(r["VisitDate"].ToString());
                    VisitStatus =Convert.ToBoolean(r["VisitStatus"].ToString());
                    AStatus = r["AStatus"].ToString();
                }
            }
            return n;
        }
        public ListView lvAppointment(ListView lv)
        {
            myr = GetAllAppointments().Select("", "Names ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Appointment"].ToString());
                l.SubItems.Add( r["SeenBy"].ToString());
                l.SubItems.Add(r["VisitDate"].ToString());
                l.SubItems.Add(r["VisitStatus"].ToString());
                l.SubItems.Add(r["ReturnDate"].ToString());
                l.SubItems.Add(r["AStatus"].ToString());
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvAppointmentSearchSort(ListView lv, string strSc, string strColumn, string SortOrder)
        {
            myr = GetAllAppointments().Select(strSc, strColumn + " " + SortOrder);
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Appointment"].ToString());
                l.SubItems.Add(r["SeenBy"].ToString());
                l.SubItems.Add(r["VisitDate"].ToString());
                l.SubItems.Add(r["VisitStatus"].ToString());
                l.SubItems.Add(r["ReturnDate"].ToString());
                l.SubItems.Add(r["AStatus"].ToString());
                
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvAppointmentSearch(ListView lv, string strSc)
        {
            myr = GetAllAppointments().Select(strSc, "Names ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Appointment"].ToString());
                l.SubItems.Add(r["SeenBy"].ToString());
                l.SubItems.Add(r["VisitDate"].ToString());
                l.SubItems.Add(r["VisitStatus"].ToString());
                l.SubItems.Add(r["ReturnDate"].ToString());
                l.SubItems.Add(r["AStatus"].ToString());
                
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvAppointmentByReg(ListView lv)
        {
            myr = GetAllAppointmentsByRegNo().Select("", "AppointmentID DESC");
            lv.Items.Clear();
            ListViewItem l;
            string strStatus = string.Empty;
            foreach (DataRow r in myr)
            {
                strStatus = r["Appointment"].ToString();
                l = new ListViewItem();
                if (strStatus.Contains("1900"))
                {
                    l.ForeColor = Color.Red;
                }
                

                l.Text = r["Appointment"].ToString();
                //l.SubItems.Add(r["SeenBy"].ToString());
                l.SubItems.Add(r["VisitDate"].ToString());
                l.SubItems.Add(r["SeenBy"].ToString());
                l.SubItems.Add(r["Period"].ToString());
                l.SubItems.Add(r["PeriodName"].ToString());
                l.SubItems.Add(r["ReturnDate"].ToString());
                l.SubItems.Add(r["AStatus"].ToString());
                l.SubItems.Add(r["AppointmentID"].ToString());
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvAppointmentAll(ListView lv)
        {
            myr = GetAllAppointmentsAll().Select("", "Names ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Names"].ToString());
                l.SubItems.Add(r["Appointment"].ToString());
                //l.SubItems.Add(r["SeenBy"].ToString());
                //l.SubItems.Add(r["VisitDate"].ToString());
                //l.SubItems.Add(r["VisitStatus"].ToString());
                l.SubItems.Add(r["AStatus"].ToString());
                l.SubItems.Add(r["ReturnDate"].ToString());
                l.SubItems.Add(r["AStatus"].ToString());
                
                //l.SubItems.Add(r["Names"].ToString());
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvAppointmentAllSearchSort(ListView lv, string strSc, string strColumn, string SortOrder)
        {
            myr = GetAllAppointmentsAll().Select(strSc, strColumn + " " + SortOrder);
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Names"].ToString());
                l.SubItems.Add(r["Appointment"].ToString());
                //l.SubItems.Add(r["SeenBy"].ToString());
                //l.SubItems.Add(r["VisitDate"].ToString());
                //l.SubItems.Add(r["VisitStatus"].ToString());
                l.SubItems.Add(r["AStatus"].ToString());
                l.SubItems.Add(r["ReturnDate"].ToString());
                l.SubItems.Add(r["AStatus"].ToString()); 
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvAppointmentAllSearch(ListView lv, string strSc)
        {
            myr = GetAllAppointmentsAll().Select(strSc, "Names ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Names"].ToString());
                l.SubItems.Add(r["Appointment"].ToString());
                //l.SubItems.Add(r["SeenBy"].ToString());
                //l.SubItems.Add(r["VisitDate"].ToString());
                //l.SubItems.Add(r["VisitStatus"].ToString());
                l.SubItems.Add(r["AStatus"].ToString());
                l.SubItems.Add(r["ReturnDate"].ToString());
                l.SubItems.Add(r["AStatus"].ToString());  
                lv.Items.Add(l);
            }
            return lv;
        }
        public ComboBox cmbSeenBy(ComboBox cmb)
        {
            cmb.BeginUpdate();
            cmb.DataSource = GetAllSeenBy();
            cmb.DisplayMember = "SeenBy";
            //cmb.ValueMember = "Value";
            cmb.EndUpdate();
            return cmb;
        }

        public bool UpdateReturnVisit()
        {
            bool ok = false;
            if (UpdateAppointmentReturn() > 0)
            {
                ok = true;
                //.UpdateAppointmentReturInteractive.LInfo("Appointment added successfully", "New Appointment");
            }
            return ok;

        }
        public bool NewAppointment()
        {
            bool ok = false;
            if (AddAppointment() > 0)
            {
                ok = true;
                Interactive.LInfo("Appointment added successfully", "New Appointment");
            }
            return ok;

        }
        public bool EditAppointment()
        {
            bool ok = false;
            if (UpdateAppointment() > 0)
            {
                ok = true;
                Interactive.LInfo("Appointment Updated successfully", "Edit Appointment");
            }
            return ok;
        }
        public bool RemoveAppointment()
        {

            bool ok = false;
            if (DeleteAppointment() > 0)
            {
                ok = true;
                Interactive.LInfo("Appointment Deleted successfully", "Delete Appointment");
            }
            return ok;
        }

#endregion
    }
}
