using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.ComponentModel;
using LiveOutlook.Properties;
using System.Windows.Forms;
using System.Threading;
using LiveOutlook.LiveUIL.LiveCore;
using System.IO;
using System.Data;

namespace LiveOutlook.LiveBLL.LiveCore
{
    class LiveStart
    {

#region Declarations

        private static string _strConn = Settings.Default.dbOutlookConnectionString;
        private static SqlConnection _Conn;
        private static SqlConnection Temp;
        private static BackgroundWorker bw;
        private static string _DbName = "dbOutlook";
        private static string _Dir = "C:\\LiveOutlook\\Data\\";
        private static string _DirBak = "C:\\LiveOutlook\\Data\\Backup\\";
        private static string _Sql = "dbOutlook.bak";
        private static string _DirName = "C:\\LiveOutlook\\Data";
        private static string _LiveProduct = Application.ProductName;
        private static string _LiveDbVersion = string.Empty;
        private static LiveUpdate L;
        private static string strSQL = string.Empty;

#endregion

#region Properties

        public static string Dir
        {
            get { return _Dir; }
        }
        public static string DirBak
        {
            get { return _DirBak; }
        }
        public static string DbName
        {
            get { return _DbName; }
        }
        public static string Sql
        {
            get { return _Dir + _Sql; }
        }
        public static string DirName
        {
            get { return _DirName; }
        }
        public static string LiveProduct
        {
            get { return _LiveProduct; }
            //set { _LiveProduct = value; } 
        }
        public static string LiveDbVersion
        {
            get { return _LiveDbVersion; }
            set { _LiveDbVersion = value; }
        }
        public static SqlConnection Conn
        {
            get
            {
                _Conn = new SqlConnection();
                _Conn.ConnectionString = _strConn;
                return _Conn;
            }
        }

#endregion

#region Methods

        public LiveStart()
        {
        }
        public LiveStart(BackgroundWorker b)
        {
            bw = b;
        }
        public void LoadISInteractive()
        {
            CreateLiveDirectories(true);
            Thread.Sleep(500);
            Interactive.STATUS = "Locating System Files...";
            CreateLiveFiles(true);
            Thread.Sleep(500);
            Interactive.STATUS = "Checking Database...";
            CreateLiveDatabase(true);
            Interactive.STATUS = "Checking server...";
            TestConnection(true);
            Interactive.STATUS = "Initializing...";
            BackupData();
            LiveSystemUpdate();
            Interactive.STATUS = "Loading GUI... Please wait";
            Thread.Sleep(3000);
        }
        public void CreateLiveDirectories(bool interactive)
        {
            try
            {
                bw.ReportProgress(1);
                if (!Directory.Exists(Dir))
                {
                    Directory.CreateDirectory(Dir);
                }
                if (!Directory.Exists(DirBak))
                {
                    Directory.CreateDirectory(DirBak);
                }
                bw.ReportProgress(2);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not create directory !\n" + ex.Message, "Application Failure");
                Application.Exit();
            }
        }
        public void CreateLiveFiles(bool interactive)
        {
            try
            {
                if (!File.Exists(Sql))
                {
                    File.WriteAllBytes(Sql, Resources.dbOutlook);
                }
                bw.ReportProgress(3);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not create system file !\n" + ex.Message, "Application Failure");
                Application.Exit();
            }
        }
        public void CreateLiveDatabase(bool interactive)
        {
            try
            {
                SqlCommand cmd;
                Temp = new SqlConnection();
                Temp.ConnectionString = Settings.Default.dbMasterConnectionString;
                if (Temp.State == ConnectionState.Closed)
                {
                    Temp.Open();
                }
                bw.ReportProgress(4);

                cmd = new SqlCommand("SELECT Count(*) from sys.databases where name = '"+ DbName+"'", Temp);
                if (cmd.ExecuteScalar().Equals(0))
                {
                    cmd = new SqlCommand("Create DATABASE " + DbName + "", Temp);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("RESTORE DATABASE " + DbName + " FROM DISK='" + Sql + "' WITH REPLACE;", Temp);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("sp_configure 'Show Advanced options',1;RECONFIGURE;", Temp);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("sp_configure 'Ad Hoc Distributed Queries',1;RECONFIGURE;", Temp);
                    cmd.ExecuteNonQuery();
                    //cmd = new SqlCommand("sp_configure 'user instances enabled',1;RECONFIGURE;", Temp);
                    //cmd.ExecuteNonQuery();
                }
                bw.ReportProgress(9);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not Create Database\nPlease ensure that SQL Server 2005 or greater has been installed\n" + ex, "Application Fail");
                Application.Exit();
            }
            finally
            {
                if (Temp.State == ConnectionState.Open)
                {
                    Temp.Close();
                }
            }
        }
        public void TestConnection(bool interactive)
        {
            try
            {
                
                Temp = new SqlConnection();
                Temp.ConnectionString = Settings.Default.dbOutlookConnectionString;

               
                if (Temp.State == ConnectionState.Closed)
                {
                    Temp.Open();
                }
               
                if (Temp.State == ConnectionState.Open)
                {
                    Temp.Close();
                }
                bw.ReportProgress(9);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Database connection failed\n" + ex, "Application Fail");
                Application.Exit();
            }
            finally
            {
                Temp.Dispose();
            }
        }
        public void LiveSystemUpdate()
        {
            bw.ReportProgress(13);
            L = new LiveUpdate(1);
            LiveDbVersion = "1.0.0.3";
            if (LiveDbVersion != L.GetVersion())
            {
                Interactive.STATUS = "Updating System... Please wait";
                L.DatabaseUpdate();
                bw.ReportProgress(14);
            }
            bw.ReportProgress(15);
        }
        public static void BackupData()
        {
            Interactive.STATUS = "Backing up Data... ";
            bw.ReportProgress(9);
            try
            {
                string x = DateTime.Now.ToString("ddMMMyyy-HHmmss").ToUpper();
                string bak = DirBak + x;
                SqlCommand cmd;
                string strBAK = "BACKUP DATABASE " + DbName + " TO Disk='" + bak +  DbName+".bak'";
                Temp = new SqlConnection();
                Temp.ConnectionString = Settings.Default.dbMasterConnectionString;
                if (Temp.State == ConnectionState.Closed)
                {
                    Temp.Open();
                }
                cmd = new SqlCommand(strBAK, Temp);
                cmd.ExecuteNonQuery();
                bw.ReportProgress(11);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError("Could not Back up data\n" + ex.Message, "Application Failure");
                //Application.Exit();
            }
            finally
            {
                Temp.Dispose();
            }
            bw.ReportProgress(12);
        }

#endregion

    }
}
