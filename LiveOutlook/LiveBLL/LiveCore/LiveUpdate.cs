using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using LiveOutlook.LiveDAL.LiveCore.DsLiveTableAdapters;
using LiveOutlook.Properties;
using System.Data;
using LiveOutlook.LiveUIL.LiveCore;
using System.Windows.Forms;

namespace LiveOutlook.LiveBLL.LiveCore
{
    class LiveUpdate
    {

#region Declarations

        private static TblLiveTableAdapter daLive;
        private static string strConn = Settings.Default.dbOutlookConnectionString;
        private static string strMasterConn = Settings.Default.dbMasterConnectionString;
        private static SqlConnection Temp;
        private static SqlCommand cmd;
        private static string strVer = string.Empty;
        private static string strSQL = string.Empty;
        private static int n;

#endregion

#region Methods

        public LiveUpdate()
        {
        }
        public LiveUpdate(int n)
        {
            SqlCommand cmd;
            Temp = new SqlConnection(strConn);
            if (Temp.State == ConnectionState.Closed)
            {
                Temp.Open();
            }
            strSQL = "if  not EXISTS " +
            "       (select * from INFORMATION_SCHEMA.tables where table_name = 'TblLive') " +
            "       begin " +
            "           CREATE TABLE [dbo].[TblLive] " +
            "           ( " +
            "               [Product] [nvarchar](100) Primary key, " +
            "               [Version] [nvarchar](50) NULL " +
            "           ); " +
            "           Insert into [dbo].[TblLive] " +
            "           Values('" + Application.ProductName +"','1.0.0.0'); " +
               "       end";
            cmd = new SqlCommand(strSQL, Temp);
            cmd.ExecuteNonQuery();
            if (Temp.State == ConnectionState.Open)
            {
                Temp.Close();
            }
        }
    
        public string GetVersion()
        {
            try
            {
                daLive = new TblLiveTableAdapter();
                strVer = daLive.GetVersion(LiveStart.LiveProduct).ToString();
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not Get version\n" + ex.Message, "Application Failure");
            }
            return strVer;
        }
        public bool UpdateVersion()
        {
            try
            {
                    daLive = new TblLiveTableAdapter();
                    

                    n = daLive.UpdateVersion(LiveStart.LiveDbVersion, LiveStart.LiveProduct);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not update database\n" + ex.Message, "Application Failure");
            }
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DatabaseUpdate()
        {
            int n = 0;
            if (Temp.State == ConnectionState.Closed)
            {
                Temp.Open();
            }
            switch (GetVersion())
            {
                #region 0
                case "1.0.0.0":
                    try
                    {
                        strSQL = @"  DELETE FROM TblClassification
                                    WHERE (Class = 'Appointments');";
                        cmd = new SqlCommand(strSQL, Temp);
                        cmd.ExecuteNonQuery();
                        n += 1;
                    }
                    catch { }

                    try
                    {
                        strSQL = @" INSERT INTO TblClassification(ID, Class, Display, Value)
                                    VALUES ('DID NOT ATTEND', 'Appointments', 'IsNull({VisitSchedule.Days Missed})', -1);
                                    INSERT INTO TblClassification(ID, Class, Display, Value)
                                    VALUES ('ATTENDED','Appointments','{VisitSchedule.Days Missed}<=0 OR {VisitSchedule.Days Missed}>=0',-1);
                                    INSERT INTO TblClassification(ID, Class, Display, Value)
                                    VALUES ('UNSCHEDULED','Appointments','{VisitSchedule.Days Missed}<0',-1);
                                    INSERT INTO TblClassification(ID, Class, Display, Value)
                                    VALUES ('LATE','Appointments','{VisitSchedule.Days Missed}>0',-1);
                                    INSERT INTO TblClassification(ID, Class, Display, Value)
                                    VALUES ('SCHEDULED','Appointments','{VisitSchedule.Days Missed}=0',-1);";
                        cmd = new SqlCommand(strSQL, Temp);
                        cmd.ExecuteNonQuery();
                        n += 1;
                    }
                    catch { }
                    if (n == 2)
                    {
                        strSQL = " UPDATE TblLive SET Version=N'" + LiveStart.LiveDbVersion + "' WHERE (Product = N'" + LiveStart.LiveProduct + "');";
                        cmd = new SqlCommand(strSQL, Temp);
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                case "1.0.0.1":
                    List<String> sqlStatements = new List<string>();
                    sqlStatements.Clear();
                    sqlStatements.Add(@"ALTER TABLE TblEnrollment ADD [CurrentStatus] NVARCHAR (50);");
                    sqlStatements.Add(@"ALTER TABLE TblClassification ALTER COLUMN [Display] VARCHAR (150);");
                    sqlStatements.Add(@"update TblEnrollment set [CurrentStatus]=N'Other'");
                    sqlStatements.Add(@"Update TblClassification SET Display=N'{VisitSchedule.Days Missed}<=0 OR {VisitSchedule.Days Missed}>=0'where Class=N'Appointments' AND ID=N'ATTENDED';");
                    sqlStatements.Add(@"Update TblClassification SET Display=N'IsNull({VisitSchedule.Appointment})'where Class=N'Appointments' AND ID=N'DID NOT ATTEND' ;");
                    sqlStatements.Add(@"Update TblClassification SET Display=N'{VisitSchedule.Days Missed}>0'where Class=N'Appointments' AND ID=N'LATE' ;");
                    sqlStatements.Add(@"Update TblClassification SET Display=N'{VisitSchedule.Days Missed}=0'where Class=N'Appointments' AND ID=N'SCHEDULED' ;");
                    sqlStatements.Add(@"Update TblClassification SET Display=N'{VisitSchedule.Days Missed}<0'where Class=N'Appointments' AND ID=N'UNSCHEDULED' ;");
                    sqlStatements.Add(@"INSERT INTO TblClassification(ID, Class, Display, Value) VALUES ('DEFAULTER','Appointments','Datediff(''d'',{VisitSchedule.Appointment},Cdate({@PeriodEnding}))>2 AND IsNull({VisitSchedule.ReturnDate})',-1);");
                    
                    sqlStatements.Add(@"INSERT INTO TblClassification(ID, Class, Display, Value) VALUES ('D','Outcome','Dead',-1);");
                    sqlStatements.Add(@"INSERT INTO TblClassification(ID, Class, Display, Value) VALUES ('LTFU','Outcome','Lost to followup',-1);");
                    sqlStatements.Add(@"INSERT INTO TblClassification(ID, Class, Display, Value) VALUES ('OOC','Outcome','Out of control',-1);");
                    sqlStatements.Add(@"INSERT INTO TblClassification(ID, Class, Display, Value) VALUES ('Other','Outcome','Other',-1);");
                    sqlStatements.Add(@"INSERT INTO TblClassification(ID, Class, Display, Value) VALUES ('T','Outcome','Transfered',-1);");
                    sqlStatements.Add(@"
                            create view vCurrentAge as
                            SELECT   RegNo,
                            case 
	                            when ageunit =N'Y' then  Age + DATEDIFF(year, RegDate, GETDATE()) 
	                            else cast (((Age + DATEDIFF(month, RegDate, GETDATE()))) as decimal(10,1))/12 end as Age
                            FROM     TblEnrollment");

                    try
                    {
                        foreach (String sqlStatement in sqlStatements)
                        {
                            cmd = new SqlCommand(sqlStatement, Temp);
                            cmd.ExecuteNonQuery();
                            n += 1;
                        }
                    }
                    catch(Exception ex) {
                        MessageBox.Show(ex.Message);

                    }


                    if (n == sqlStatements.Count)
                    {
                        strSQL = " UPDATE TblLive SET Version=N'" + LiveStart.LiveDbVersion + "' WHERE (Product = N'" + LiveStart.LiveProduct + "');";
                        cmd = new SqlCommand(strSQL, Temp);
                        cmd.ExecuteNonQuery();
                    }
                    break;
            }

        }
        public void DatabaseUpdate(string strver)
        {
            int n = 0;
            switch (strver)
            {
                case "1.0.0.0":
                    try
                    {
                        strSQL = @"  DELETE FROM TblClassification
                                    WHERE (Class = 'Appointments');";
                        cmd = new SqlCommand(strSQL, Temp);
                        cmd.ExecuteNonQuery();
                        n += 1;
                    }
                    catch { }

                    try
                    {
                        strSQL = @" INSERT INTO TblClassification(ID, Class, Display, Value)
                                    VALUES ('DID NOT ATTEND', 'Appointments', 'IsNull({VisitSchedule.Days Missed})', -1);
                                    INSERT INTO TblClassification(ID, Class, Display, Value)
                                    VALUES ('ATTENDED','Appointments','{VisitSchedule.Days Missed}<=0 OR {VisitSchedule.Days Missed}>=0',-1);
                                    INSERT INTO TblClassification(ID, Class, Display, Value)
                                    VALUES ('UNSCHEDULED','Appointments','{VisitSchedule.Days Missed}<0',-1);
                                    INSERT INTO TblClassification(ID, Class, Display, Value)
                                    VALUES ('LATE','Appointments','{VisitSchedule.Days Missed}>0',-1);
                                    INSERT INTO TblClassification(ID, Class, Display, Value)
                                    VALUES ('SCHEDULED','Appointments','{VisitSchedule.Days Missed}=0',-1);";
                        cmd = new SqlCommand(strSQL, Temp);
                        cmd.ExecuteNonQuery();
                        n += 1;
                    }
                    catch { }
                    if (n == 2)
                    {
                        UpdateVersion();
                    }
                    break;
            }
        }

#endregion

    }
}
