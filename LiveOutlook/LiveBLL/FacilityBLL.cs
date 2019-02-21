using System;
using System.Collections.Generic;
using System.Text;
using LiveOutlook.LiveDAL;
using LiveOutlook.LiveDAL.DsLiveOutlookTableAdapters;
using System.Data;
using LiveOutlook.LiveUIL;
using LiveOutlook.LiveUIL.LiveCore;


namespace LiveOutlook.LiveBLL
{
    class FacilityBLL
    {

#region Declarations

        private static TblPublicHolidayTableAdapter daPublic;
        private static TblReserveTableAdapter daReserve;
        private static TblSettingsTableAdapter daSettings;
        private static TblFacilityTableAdapter daFacility;

        private static DsLiveOutlook.TblPublicHolidayDataTable dtPublic;
        private static DsLiveOutlook.TblReserveDataTable dtReserve;
        private static DsLiveOutlook.TblSettingsDataTable dtSettings;
        private static DsLiveOutlook.TblFacilityDataTable dtFacility;
        
        private static DsLiveOutlook.TblPublicHolidayRow drwPublic;
        private static DsLiveOutlook.TblReserveRow drwReserve;
        private static DsLiveOutlook.TblSettingsRow drwSettings;
        private static DsLiveOutlook.TblFacilityRow drwFacility;
        private static int n = 0;
        private static DataTable dt; 

#endregion

#region Methods

        internal static DataTable GetAllFacilitys()
        {
            FacilityInfo.Recs = false;
            try
            {
                dt = new DataTable();
                daFacility = new TblFacilityTableAdapter();
                dtFacility = new DsLiveOutlook.TblFacilityDataTable();
                daFacility.Fill(dtFacility);
                dt = dtFacility;
                if (dt.Rows.Count > 0)
                {
                    FacilityInfo.Recs = true;
                }
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Facility Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllFacilitysByID()
        {
            try
            {
                dt = new DataTable();
                daFacility = new TblFacilityTableAdapter();
                dtFacility = new DsLiveOutlook.TblFacilityDataTable();
                daFacility.FillByID(dtFacility, FacilityInfo.FCode);
                dt = dtFacility;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Facility Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static int DeleteFacility()
        {

            n = 0;
            try
            {
                daFacility = new TblFacilityTableAdapter();
                n = daFacility.Delete1(FacilityInfo.FCode);
                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not Deleted!");
                return n;
            }

        }
        internal static int AddFacility()
        {
            n = 0;
            try
            {
                daFacility = new  TblFacilityTableAdapter();
                dtFacility = new DsLiveOutlook.TblFacilityDataTable();
               
                drwFacility = dtFacility.NewTblFacilityRow();

                drwFacility.Fcode = FacilityInfo.FCode.Trim().ToUpper();
                drwFacility.Facility = FacilityInfo.FName.Trim().ToUpper();

                dtFacility.AddTblFacilityRow(drwFacility);

                n = daFacility.Update(dtFacility);

                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not saved !");
                return n;
            }
        }
        internal static int UpdateFacility()
        {
            n = 0;
            try
            {
                daFacility = new TblFacilityTableAdapter();
                dtFacility = new DsLiveOutlook.TblFacilityDataTable();
                daFacility.FillByID(dtFacility, FacilityInfo.FCode);

                drwFacility = dtFacility[0];

                drwFacility.BeginEdit();


                drwFacility.Fcode = FacilityInfo.NewFCode.Trim().ToUpper();
                drwFacility.Facility = FacilityInfo.FName.Trim().ToUpper();

                drwFacility.EndEdit();

                n = daFacility.Update(dtFacility);

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
