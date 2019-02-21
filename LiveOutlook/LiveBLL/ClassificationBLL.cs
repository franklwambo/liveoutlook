using System;
using System.Collections.Generic;
using System.Text;
using LiveOutlook.LiveDAL.DsLiveOutlookTableAdapters;
using LiveOutlook.LiveDAL;
using System.Data;
using LiveOutlook.LiveUIL.LiveCore;
using LiveOutlook.LiveUIL;

namespace LiveOutlook.LiveBLL
{
    class ClassificationBLL
    {
#region Declarations

        private static TblClassificationTableAdapter daClassification;
        private static DsLiveOutlook.TblClassificationDataTable dtClassification;
        private static DsLiveOutlook.TblClassificationRow drwClassification;
        private static int n = 0;
        private static DataTable dt;

#endregion

#region Methods

        internal static DataTable GetAllClassifications()
        {
            ClassificationInfo.Recs = false;
            try
            {
                dt = new DataTable();
                daClassification = new TblClassificationTableAdapter();
                dtClassification = new DsLiveOutlook.TblClassificationDataTable();
                daClassification.Fill(dtClassification);
                dt = dtClassification;
                if (dt.Rows.Count > 0)
                {
                    ClassificationInfo.Recs = true;
                }
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Classification Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllClassificationsByID()
        {
            try
            {
                dt = new DataTable();
                daClassification = new TblClassificationTableAdapter();
                dtClassification = new DsLiveOutlook.TblClassificationDataTable();
                daClassification.FillByID(dtClassification,ClassificationInfo.ID, ClassificationInfo.AClass);
                dt = dtClassification;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Classification Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllClassificationsByClass()
        {
            try
            {
                dt = new DataTable();
                daClassification = new TblClassificationTableAdapter();
                dtClassification = new DsLiveOutlook.TblClassificationDataTable();
                daClassification.FillByClass(dtClassification, ClassificationInfo.AClass);
                dt = dtClassification;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Classification Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllClassificationsByClass(string strclass)
        {
            try
            {
                dt = new DataTable();
                daClassification = new TblClassificationTableAdapter();
                dtClassification = new DsLiveOutlook.TblClassificationDataTable();
                daClassification.FillByClass(dtClassification, strclass);
                dt = dtClassification;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Classification Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static int DeleteClassification()
        {

            n = 0;
            try
            {
                daClassification = new TblClassificationTableAdapter();
                n = daClassification.Delete1(ClassificationInfo.ID,ClassificationInfo.AClass);
                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not Deleted!");
                return n;
            }

        }
        internal static int AddClassification()
        {
            n = 0;
            try
            {
                daClassification = new TblClassificationTableAdapter();
                dtClassification = new DsLiveOutlook.TblClassificationDataTable();

                drwClassification = dtClassification.NewTblClassificationRow();

                drwClassification.ID = ClassificationInfo.ID.Trim();
                drwClassification.Class = ClassificationInfo.AClass.Trim();
                drwClassification.Display = ClassificationInfo.Display.Trim();
                drwClassification.Value = ClassificationInfo.Value;
                
                dtClassification.AddTblClassificationRow(drwClassification);

                n = daClassification.Update(dtClassification);

                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not saved !");
                return n;
            }
        }
        internal static int UpdateClassification()
        {
            n = 0;
            try
            {
                daClassification = new TblClassificationTableAdapter();
                dtClassification = new DsLiveOutlook.TblClassificationDataTable();
                daClassification.FillByID(dtClassification, ClassificationInfo.ID,ClassificationInfo.AClass);

                drwClassification = dtClassification[0];

                drwClassification.BeginEdit();

                drwClassification.ID = ClassificationInfo.NewID.Trim();
                drwClassification.Display = ClassificationInfo.Display.Trim();
                drwClassification.Value = ClassificationInfo.Value;
      
                drwClassification.EndEdit();
                n = daClassification.Update(dtClassification);
                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not saved !");
                return n;
            }

        }

#endregion
    }
}
