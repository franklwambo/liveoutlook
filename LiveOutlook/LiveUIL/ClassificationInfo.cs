using System;
using System.Collections.Generic;
using System.Text;
using LiveOutlook.LiveBLL;
using System.Data;
using System.Windows.Forms;
using LiveOutlook.LiveUIL.LiveCore;

namespace LiveOutlook.LiveUIL
{
    class ClassificationInfo:ClassificationBLL
    {
#region Declarations

        private static string _ID;
        private static string _Class = string.Empty;
        private static string _Display = string.Empty;
        private static long _Value; 
        private static string _NewID;
        private static string _NewClass = string.Empty;
        private static bool _Recs = false;
        private static DataRow[] myr;
        private static int n = 0;

#endregion

#region Properties

        public static string ID
        {
            get
            {
                return _ID;
            }
            set { _ID = value; }
        }
        public static string AClass
        {
            get
            {
                return _Class;
            }
            set
            {
                _Class = value;
            }
        }
        public static string Display
        {
            get
            {
                return _Display;
            }
            set { _Display = value; }
        }
        public static long Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        public static string NewID
        {
            get
            {
                return _NewID;
            }
            set { _NewID = value; }
        }
        public static string NewClass
        {
            get
            {
                return _NewClass;
            }
            set
            {
                _NewClass = value;
            }
        }
        public static bool Recs
        {
            get { return _Recs; }
            set { _Recs = value; }
        } 

#endregion

#region Methods

        public int ShowClassification()
        {
            n = 0;
            myr = GetAllClassificationsByID().Select();
            if (ClassificationInfo.Recs)
            {
                n = 1;
                foreach (DataRow r in myr)
                {
                    ClassificationInfo.ID = r["ID"].ToString();
                    ClassificationInfo.AClass = r["Class"].ToString();
                    ClassificationInfo.Display = r["Dispaly"].ToString();
                    ClassificationInfo.Value = Convert.ToInt64(r["Value"].ToString());
                }
            }
            return n;
        }
        public ComboBox cmbClassification(ComboBox cmb)
        {
            //  cmb.Items.Clear();
            cmb.BeginUpdate();
            cmb.DataSource = GetAllClassificationsByClass();
            cmb.DisplayMember = "Display";
            cmb.ValueMember = "ID";
            cmb.EndUpdate();
            return cmb;
        }
        public ListView lvClassification(ListView lv)
        {
            myr =GetAllClassificationsByClass().Select("","Display ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {
                l = new ListViewItem();
                l.Text = r["ID"].ToString();
                l.SubItems.Add(r["Display"].ToString());
//                l.SubItems.Add(r["Class"].ToString());
                l.SubItems.Add(r["Value"].ToString());
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvClassification(ListView lv,string strClass,bool All)
        {
            myr = GetAllClassificationsByClass(strClass).Select("", "Display ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {

                l = new ListViewItem();
                if (All)
                {
                    l.Text = r["ID"].ToString();
                    l.SubItems.Add(r["Display"].ToString());
                }
                else
                {
                    l.Text = r["Display"].ToString();
                }
                lv.Items.Add(l);
            }
            return lv;
        }
        public ListView lvClassification(ListView lv, string strClass,string strItem, bool All)
        {
            myr = GetAllClassificationsByClass(strClass).Select(strItem, "Display ASC");
            lv.Items.Clear();
            ListViewItem l;
            foreach (DataRow r in myr)
            {

                l = new ListViewItem();
                if (All)
                {
                    l.Text = r["ID"].ToString();
                    l.SubItems.Add(r["Display"].ToString());
                }
                else
                {
                    l.Text = r["Display"].ToString();
                }
                lv.Items.Add(l);
            }
            return lv;
        }
        //public ListView lvClassificationSearch(ListView lv,string strSc)
        //{
        //    myr = GetAllClassifications().Select(strSc, "Zone ASC");
        //    lv.Items.Clear();
        //    ListViewItem l;
        //    foreach (DataRow r in myr)
        //    {
        //        l = new ListViewItem();
        //        l.Text = r["Fcode"].ToString();
        //        l.SubItems.Add(r["Classification"].ToString());
        //        l.SubItems.Add(r["Zone"].ToString());
        //        l.SubItems.Add(r["ZoneID"].ToString());
        //        l.SubItems.Add(r["Sector"].ToString());
        //        l.SubItems.Add(r["District"].ToString());
        //        l.SubItems.Add(r["Province"].ToString());
        //        lv.Items.Add(l);
        //    }
        //    return lv;
        //}
        public bool NewClassification()
        {
            bool ok = false;
            if (AddClassification() > 0)
            {
                ok = true;
                Interactive.LInfo("Classification added successfully", "New Classification");
            }
            return ok;

        }
        public bool EditClassification()
        {
            bool ok = false;
            if (UpdateClassification() > 0)
            {
                ok = true;
                Interactive.LInfo("Classification Updated successfully", "Edit Classification");
            }
            return ok;
        }
        public bool RemoveClassification()
        {

            bool ok = false;
            if (DeleteClassification() > 0)
            {
                ok = true;
                Interactive.LInfo("Classification Deleted successfully", "Delete Classification");
            }
            return ok;
        }

#endregion

    }
}
