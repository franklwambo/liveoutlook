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
    class EnrollmentBLL
    {

#region Declarations

        private static TblEnrollmentTableAdapter daEnrollment;
        private static DsLiveOutlook.TblEnrollmentDataTable dtEnrollment;
        private static DsLiveOutlook.TblEnrollmentRow drwEnrollment;
        private static int n = 0;
        private static DataTable dt;

#endregion

#region Methods

        internal static DataTable GetAllEnrollments()
        {
            try
            {
                dt = new DataTable();
                daEnrollment = new TblEnrollmentTableAdapter();
                dtEnrollment = new DsLiveOutlook.TblEnrollmentDataTable();
                daEnrollment.Fill(dtEnrollment);
                dt = dtEnrollment;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Enrollment Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllEnrollmentsTop100()
        {
            try
            {
                dt = new DataTable();
                daEnrollment = new TblEnrollmentTableAdapter();
                dtEnrollment = new DsLiveOutlook.TblEnrollmentDataTable();
                daEnrollment.FillByTop100(dtEnrollment);
                dt = dtEnrollment;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Enrollment Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        internal static DataTable GetAllEnrollmentsByID()
        {
            try
            {
                EnrollmentInfo.Recs = false;
                dt = new DataTable();
                daEnrollment = new TblEnrollmentTableAdapter();
                dtEnrollment = new DsLiveOutlook.TblEnrollmentDataTable();
                daEnrollment.FillByID(dtEnrollment,EnrollmentInfo.RegNo);
                dt = dtEnrollment;
                if (dt.Rows.Count > 0)
                {
                    EnrollmentInfo.Recs = true;
                }
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not load Enrollment Information\n" + ex.Message, "Database connection failure");
            }
            return dt;
        }
        public DataTable GetTop5ooEnrollments()
        {
            DataTable dt = new DataTable();
            daEnrollment = new TblEnrollmentTableAdapter();
            dtEnrollment = new DsLiveOutlook.TblEnrollmentDataTable();
            daEnrollment.SelectTop500(dtEnrollment);
            dt = dtEnrollment; ;
            return dt;

        }
        internal static int DeleteEnrollment()
        {

            n = 0;
            try
            {
                daEnrollment = new TblEnrollmentTableAdapter();
                n = daEnrollment.Delete1(EnrollmentInfo.RegNo);
                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not Deleted!");
                return n;
            }

        }
        internal static int AddEnrollment()
        {
            n = 0;
            try
            {
                daEnrollment = new TblEnrollmentTableAdapter();
                dtEnrollment = new DsLiveOutlook.TblEnrollmentDataTable();

                drwEnrollment = dtEnrollment.NewTblEnrollmentRow();

                drwEnrollment.RegNo = EnrollmentInfo.RegNo.Trim().ToUpper();
                drwEnrollment.Names = EnrollmentInfo.Names.Trim().ToUpper();
                drwEnrollment.Age = EnrollmentInfo.Age;
                drwEnrollment.AgeUnit = EnrollmentInfo.AgeUnit;
                drwEnrollment.Sex = EnrollmentInfo.Sex.Trim().ToUpper();
                drwEnrollment.RegDate = EnrollmentInfo.RegDate;
                drwEnrollment.Residence = EnrollmentInfo.Residence.Trim().ToUpper();
                drwEnrollment.ReferredBy = EnrollmentInfo.ReferredBy.Trim().ToUpper();
                drwEnrollment.ReferredTo = EnrollmentInfo.ReferredTo.Trim().ToUpper();
                drwEnrollment.Fcode = EnrollmentInfo.Fcode.Trim().ToUpper();
                drwEnrollment.Category = EnrollmentInfo.Category.Trim();
                drwEnrollment.ContactInfo = EnrollmentInfo.ContactInfo.Trim();
                drwEnrollment.CurrentStatus = EnrollmentInfo.Outcome;
               
                dtEnrollment.AddTblEnrollmentRow(drwEnrollment);

                n = daEnrollment.Update(dtEnrollment);

                return n;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Record was not saved !");
                return n;
            }
        }
        internal static int UpdateEnrollment()
        {
            n = 0;
            try
            {
                daEnrollment = new TblEnrollmentTableAdapter();
                dtEnrollment = new DsLiveOutlook.TblEnrollmentDataTable();
                daEnrollment.FillByID(dtEnrollment, EnrollmentInfo.RegNo);

                drwEnrollment = dtEnrollment[0];

                drwEnrollment.BeginEdit();


                drwEnrollment.RegNo = EnrollmentInfo.NewRegNo.Trim().ToUpper();
                drwEnrollment.Names = EnrollmentInfo.Names.Trim().ToUpper();
                drwEnrollment.Age = EnrollmentInfo.Age;
                drwEnrollment.AgeUnit = EnrollmentInfo.AgeUnit;
                drwEnrollment.Sex = EnrollmentInfo.Sex.Trim().ToUpper();
                drwEnrollment.RegDate = EnrollmentInfo.RegDate;
                drwEnrollment.Residence = EnrollmentInfo.Residence.Trim().ToUpper();
                drwEnrollment.ReferredBy = EnrollmentInfo.ReferredBy.Trim().ToUpper();
                drwEnrollment.ReferredTo = EnrollmentInfo.ReferredTo.Trim().ToUpper();
                drwEnrollment.Fcode = EnrollmentInfo.Fcode.Trim().ToUpper();
                drwEnrollment.Category = EnrollmentInfo.Category.Trim();
                drwEnrollment.ContactInfo = EnrollmentInfo.ContactInfo.Trim();

                drwEnrollment.CurrentStatus = EnrollmentInfo.Outcome;

                drwEnrollment.EndEdit();

                n = daEnrollment.Update(dtEnrollment);

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
