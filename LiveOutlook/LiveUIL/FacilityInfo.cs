using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using LiveOutlook.LiveBLL;
using LiveOutlook.LiveUIL.LiveCore;


namespace LiveOutlook.LiveUIL
{
    class FacilityInfo:FacilityBLL
    {

#region Declarations

        private static string _FCode;
        private static string _FName = string.Empty;
        private static string _NewFCode = string.Empty;
        private static bool _Recs = false;
        private static DataRow[] myr;
        private static int n = 0; 

#endregion

#region Properties

        public static string FCode
        {
            get
            {
                return _FCode;
            }
            set { _FCode = value; }
        }
        public static string FName
        {
            get
            {
                return _FName;
            }
            set
            {
                _FName = value;
            }
        }
        public static string NewFCode
        {
            get
            {
                return _NewFCode;
            }
            set { _NewFCode = value; }
        }
        public static bool Recs
        {
            get { return _Recs; }
            set { _Recs = value; }
        } 

#endregion

#region Methods

        public int ShowFacility()
        {
            n = 0;
            myr = GetAllFacilitys().Select();
            if (FacilityInfo.Recs)
            {
                n = 1;
                foreach (DataRow r in myr)
                {
                    FacilityInfo.FCode = r["Fcode"].ToString();
                    FacilityInfo.FName = r["Facility"].ToString();
                }
            }
            return n;
        }
        //public ListView lvFacility(ListView lv, string strFind)
        //{

        //    myr = GetAllFacilitys().Select("Facility LIKE '" + strFind.Trim() + "%'", "Facility ASC");

        //    lv.Items.Clear();
        //    ListViewItem l;
        //    foreach (DataRow r in myr)
        //    {
        //        l = new ListViewItem();
        //        l.Text = r["Facility"].ToString();
        //        l.SubItems.Add(r["Description"].ToString());
        //        lv.Items.Add(l);
        //    }
        //    return lv;
        //}
        //public ListView lvFacility(ListView lv, string strColumn, string SortOrder)
        //{

        //    myr = GetAllFacilitys().Select("", strColumn + " " + SortOrder);

        //    lv.Items.Clear();
        //    ListViewItem l;
        //    foreach (DataRow r in myr)
        //    {
        //        l = new ListViewItem();
        //        l.Text = r["Fcode"].ToString();
        //        l.SubItems.Add(r["Facility"].ToString());
        //        l.SubItems.Add(r["Zone"].ToString());
        //        l.SubItems.Add(r["ZoneID"].ToString());
        //        l.SubItems.Add(r["Sector"].ToString());
        //        l.SubItems.Add(r["District"].ToString());
        //        l.SubItems.Add(r["Province"].ToString());

        //        lv.Items.Add(l);
        //    }
        //    return lv;
        //}
        //public ComboBox cmbFacility(ComboBox cmb)
        //{
        //  //  cmb.Items.Clear();
        //    cmb.BeginUpdate();
        //    cmb.DataSource = GetAllFacilitys();
        //    cmb.DisplayMember = "Facility";
        //    cmb.ValueMember = "Fcode";
        //    cmb.EndUpdate();
        //    return cmb;
        //}
        //public ComboBox cmbFullFacility(ComboBox cmb)
        //{
        //    //  cmb.Items.Clear();
        //    cmb.BeginUpdate();
        //    cmb.DataSource = GetAllFacilitys();
        //    cmb.DisplayMember = "FullFacility";
        //    cmb.ValueMember = "Fcode";
        //    cmb.EndUpdate();
        //    return cmb;
        //}

        //public ListBox lstFacility(ListBox lst)
        //{
        //    lst.BeginUpdate();
        //    lst.DataSource = GetAllFacilitys();
        //    lst.DisplayMember = "Facility";
        //    lst.ValueMember = "Facility";
        //    lst.EndUpdate();
        //    return lst;
        //}
        //public ListView lvFacilitySearchSort(ListView lv, string strSc, string strColumn, string SortOrder)
        //{
        //    myr = GetAllFacilitys().Select(strSc, strColumn+" "+SortOrder);
        //    lv.Items.Clear();
        //    ListViewItem l;
        //    foreach (DataRow r in myr)
        //    {
        //        l = new ListViewItem();
        //        l.Text = r["Fcode"].ToString();
        //        l.SubItems.Add(r["Facility"].ToString());
        //        l.SubItems.Add(r["Zone"].ToString());
        //        l.SubItems.Add(r["ZoneID"].ToString());
        //        l.SubItems.Add(r["Sector"].ToString());
        //        l.SubItems.Add(r["District"].ToString());
        //        l.SubItems.Add(r["Province"].ToString());
        //        lv.Items.Add(l);
        //    }
        //    return lv;
        //}
        //public ListView lvFacilitySearch(ListView lv,string strSc)
        //{
        //    myr = GetAllFacilitys().Select(strSc, "Zone ASC");
        //    lv.Items.Clear();
        //    ListViewItem l;
        //    foreach (DataRow r in myr)
        //    {
        //        l = new ListViewItem();
        //        l.Text = r["Fcode"].ToString();
        //        l.SubItems.Add(r["Facility"].ToString());
        //        l.SubItems.Add(r["Zone"].ToString());
        //        l.SubItems.Add(r["ZoneID"].ToString());
        //        l.SubItems.Add(r["Sector"].ToString());
        //        l.SubItems.Add(r["District"].ToString());
        //        l.SubItems.Add(r["Province"].ToString());
        //        lv.Items.Add(l);
        //    }
        //    return lv;
        //}
        //public TreeView tvProvinceDistrictZone(TreeView tv,string x)
        //{
        //    DataRow[] Prw;
        //    DataRow[] Drw;
        //    DataRow[] Zrw;
        //    Prw = ProvinceBLL.GetAllProvinces().Select("", "Province ASC");
        //    TreeNode t;
        //    TreeNode t1;
        //    TreeNode t2;
        //    foreach (DataRow r in Prw)
        //    {

        //        t = tv.Nodes.Add(r["Province"].ToString());
        //        Drw = DistrictBLL.GetAllDistrictsByPcode(Convert.ToInt32(r["Pcode"].ToString())).Select("", "District ASC"); ;
        //        foreach (DataRow r2 in Drw)
        //        {
        //            t.Nodes.Add(r2["District"].ToString() + " [" + r2["Dcode"].ToString() + "]");
        //            Zrw = ZoneBLL.GetAllZonesByDcode(Convert.ToInt32(r2["Dcode"].ToString())).Select("", "Zone ASC"); ;
        //            foreach (DataRow r3 in Zrw)
        //            {
        //                t = t.Nodes.Add(r3["Zone"].ToString() + " [" + r3["ZoneID"].ToString() + "]");
        //            }
        //        }
        //    }
        //    return tv;
        //}
        //public TreeView tvProvinceDistrictZone(TreeView tv)
        //{
        //    DataRow[] Prw;
        //    DataRow[] Drw;
        //    DataRow[] Zrw;
        //    TreeNode t1;
        //    TreeNode t2;
        //    TreeNode t3;
        //    Prw = ProvinceBLL.GetAllProvinces().Select("", "Province ASC");
        //    foreach (DataRow r in Prw)
        //    {
        //        t1=tv.Nodes.Add(r["Province"].ToString());
        //        Drw = DistrictBLL.GetAllDistrictsByPcode(Convert.ToInt32(r["Pcode"].ToString())).Select("", "District ASC"); ;
        //        foreach (DataRow r2 in Drw)
        //        {
        //            t2=t1.Nodes.Add(r2["District"].ToString() + " [" + r2["Dcode"].ToString() + "]");
        //            Zrw = ZoneBLL.GetAllZonesByDcode(Convert.ToInt32(r2["Dcode"].ToString())).Select("", "Zone ASC"); ;
        //            foreach (DataRow r3 in Zrw)
        //            {
        //                 t3=t2.Nodes.Add(r3["Zone"].ToString() + " [" + r3["ZoneID"].ToString() + "]");
        //            }
        //        }
        //    }

        //    return tv;
        //}
        public bool NewFacility()
        {
            bool ok = false;
            if (AddFacility() > 0)
            {
                ok = true;
                Interactive.LInfo("Facility added successfully", "New Facility");
            }
            return ok;

        }
        public bool EditFacility()
        {
            bool ok = false;
            if (UpdateFacility() > 0)
            {
                ok = true;
                Interactive.LInfo("Facility Updated successfully", "Edit Facility");
            }
            return ok;
        }
        public bool RemoveFacility()
        {

            bool ok = false;
            if (DeleteFacility() > 0)
            {
                ok = true;
                Interactive.LInfo("Facility Deleted successfully", "Delete Facility");
            }
            return ok;
        } 

#endregion

    }
}
