using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using LiveOutlook.LiveBLL;
using LiveOutlook.LiveUIL.LiveCore;

namespace LiveOutlook.LiveUIL
{
    class EnrollmentInfo : EnrollmentBLL
    {

        #region Declarations

        private static string _RegNo = string.Empty;
        private static string _Names = string.Empty;
        private static int _Age;
        private static string _AgeUnit = string.Empty;
        private static string _Sex = string.Empty;
        private static DateTime _RegDate;
        private static string _Residence = string.Empty;
        private static string _ReferredBy = string.Empty;
        private static string _ReferredTo = string.Empty;
        private static string _FCode = string.Empty;
        private static string _Category = string.Empty;
        private static string _ContactInfo = string.Empty;
        private static string _Outcome = string.Empty;
        private static string _NewRegNo = string.Empty;
        private static DataRow[] myr;
        private static int n = 0;
        private static bool _Recs = false;

        #endregion

        #region Properties

        public static string RegNo
        {
            get { return _RegNo; }
            set { _RegNo = value; }
        }
        public static string Names
        {
            get { return _Names; }
            set { _Names = value; }
        }
        public static int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        public static string AgeUnit
        {
            get { return _AgeUnit; }
            set { _AgeUnit = value; }
        }
        public static string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        public static DateTime RegDate
        {
            get { return _RegDate; }
            set { _RegDate = value; }
        }
        public static string Residence
        {
            get { return _Residence; }
            set { _Residence = value; }
        }
        public static string ReferredBy
        {
            get { return _ReferredBy; }
            set { _ReferredBy = value; }
        }
        public static string ReferredTo
        {
            get { return _ReferredTo; }
            set { _ReferredTo = value; }
        }
        public static string Fcode
        {
            get { return _FCode; }
            set { _FCode = value; }
        }
        public static string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        public static string ContactInfo
        {
            get
            {
                return _ContactInfo;
            }
            set { _ContactInfo = value; }
        }
        public static string Outcome
        {
            get { return _Outcome; }
            set { _Outcome = value; }
        }
        public static string NewRegNo
        {
            get { return _NewRegNo; }
            set { _NewRegNo = value; }
        }
        public static bool Recs
        {
            get { return _Recs; }
            set { _Recs = value; }
        }

        #endregion

        #region Methods

        public int ShowEnrollment()
        {
            n = 0;
            myr = GetAllEnrollmentsByID().Select();
            if (Recs)
            {
                n = 1;
                foreach (DataRow r in myr)
                {
                    RegNo = r["RegNo"].ToString();
                    Names = r["Names"].ToString();
                    Age = Convert.ToInt32(r["Age"].ToString());
                    Sex = r["Sex"].ToString();
                    RegDate = Convert.ToDateTime(r["RegDate"].ToString());
                    Residence = r["Residence"].ToString();
                    ReferredBy = r["ReferredBy"].ToString();
                    ReferredTo = r["ReferredTo"].ToString();
                    Fcode = r["Fcode"].ToString();
                    ContactInfo = r["ContactInfo"].ToString();
                    Outcome = r["CurrentStatus"].ToString();
                }
            }
            return n;
        }
        public ListView lvEnrollmentTop500(ListView lv)
        {
            myr = GetTop5ooEnrollments().Select("", "RegNo ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Names"].ToString());
                l.SubItems.Add(r["Age"].ToString());
                l.SubItems.Add(r["AgeUnit"].ToString());
                l.SubItems.Add(r["Sex"].ToString());
                l.SubItems.Add(r["RegDate"].ToString());
                //l.SubItems.Add(r["Residence"].ToString());
                //l.SubItems.Add(r["ReferredBy"].ToString());
                //l.SubItems.Add(r["ReferredTo"].ToString());
                l.SubItems.Add(r["CurrentStatus"].ToString());
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvEnrollment(ListView lv)
        {
            myr = GetAllEnrollments().Select("", "RegNo ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Names"].ToString());
                l.SubItems.Add(r["Age"].ToString());
                l.SubItems.Add(r["AgeUnit"].ToString());
                l.SubItems.Add(r["Sex"].ToString());
                l.SubItems.Add(r["RegDate"].ToString());
                //l.SubItems.Add(r["Residence"].ToString());
                //l.SubItems.Add(r["ReferredBy"].ToString());
                //l.SubItems.Add(r["ReferredTo"].ToString());
                //l.SubItems.Add(r["Fcode"].ToString());
                l.SubItems.Add(r["CurrentStatus"].ToString());
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvEnrollmentSearchSort(ListView lv, string strSc, string strColumn, string SortOrder)
        {
            myr = GetAllEnrollments().Select(strSc, strColumn + " " + SortOrder);
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Names"].ToString());
                l.SubItems.Add(r["Age"].ToString());
                l.SubItems.Add(r["AgeUnit"].ToString());
                l.SubItems.Add(r["Sex"].ToString());
                l.SubItems.Add(r["RegDate"].ToString());
                //l.SubItems.Add(r["Residence"].ToString());
                //l.SubItems.Add(r["ReferredBy"].ToString());
                //l.SubItems.Add(r["ReferredTo"].ToString());
                //l.SubItems.Add(r["Fcode"].ToString());
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvEnrollmentSearch(ListView lv, string strSc)
        {
            myr = GetAllEnrollments().Select(strSc, "Names ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Names"].ToString());
                l.SubItems.Add(r["Age"].ToString());
                l.SubItems.Add(r["AgeUnit"].ToString());
                l.SubItems.Add(r["Sex"].ToString());
                l.SubItems.Add(r["RegDate"].ToString());
                //l.SubItems.Add(r["Residence"].ToString());
                //l.SubItems.Add(r["ReferredBy"].ToString());
                //l.SubItems.Add(r["ReferredTo"].ToString());
                //l.SubItems.Add(r["Fcode"].ToString());
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvEnrollmentMin(ListView lv)
        {
            myr = GetAllEnrollmentsTop100().Select("", "RegNo ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Names"].ToString());
                l.SubItems.Add(r["Age"].ToString());
                l.SubItems.Add(r["AgeUnit"].ToString());
                l.SubItems.Add(r["Sex"].ToString());
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvEnrollmentMinSearchSort(ListView lv, string strSc, string strColumn, string SortOrder)
        {
            myr = GetAllEnrollments().Select(strSc, strColumn + " " + SortOrder);
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Names"].ToString());
                l.SubItems.Add(r["Age"].ToString());
                l.SubItems.Add(r["AgeUnit"].ToString());
                l.SubItems.Add(r["Sex"].ToString());

                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvEnrollmentMinSearch(ListView lv, string strSc)
        {
            myr = GetAllEnrollments().Select(strSc, "RegNo ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["RegNo"].ToString();
                l.SubItems.Add(r["Names"].ToString());
                l.SubItems.Add(r["Age"].ToString());
                l.SubItems.Add(r["AgeUnit"].ToString());
                l.SubItems.Add(r["Sex"].ToString());
                lv.Items.Add(l);
            }
            return lv;
        }
        public int GetTop500()
        {
            myr = GetTop5ooEnrollments().Select();
            int count = myr.Length;
            return count;
        }
        public int GetAll()
        {
            myr = GetAllEnrollments().Select();
            int count = myr.Length;
            return count;
        }

        public bool NewEnrollment()
        {
            bool ok = false;
            if (AddEnrollment() > 0)
            {
                ok = true;
                Interactive.LInfo("Enrollment added successfully", "New Enrollment");
            }
            return ok;

        }
        public bool EditEnrollment()
        {
            bool ok = false;
            if (UpdateEnrollment() > 0)
            {
                ok = true;
                Interactive.LInfo("Enrollment Updated successfully", "Edit Enrollment");
            }
            return ok;
        }
        public bool RemoveEnrollment()
        {

            bool ok = false;
            if (DeleteEnrollment() > 0)
            {
                ok = true;
                Interactive.LInfo("Enrollment Deleted successfully", "Delete Enrollment");
            }
            return ok;
        }

        #endregion
    }
}
