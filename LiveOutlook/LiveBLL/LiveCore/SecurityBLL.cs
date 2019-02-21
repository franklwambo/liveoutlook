using System;
using System.Collections.Generic;
using System.Text;
using LiveOutlook.LiveDAL.LiveCore;
using LiveOutlook.LiveDAL.LiveCore.DsSecurityTableAdapters;
using LiveOutlook.LiveUIL.LiveCore;
using LiveOutlook.LiveUIL;

namespace LiveOutlook.LiveBLL.LiveCore
{
      class RoleBLL
    {
        #region fields
        private tblRoleTableAdapter da = null;
        private DsSecurity.tblRoleDataTable dt = null;
        private DsSecurity.tblRoleRow rw = null;
        private int n = -1;
        #endregion
        #region Methods
        internal int Insert(RoleInfo r)
        {
            try
            {
                da = new tblRoleTableAdapter();
                n = da.Insert(r.RoleID, r.Description);
                LivelogInfo.InsertLog(DateTime.Now, r.RoleID, "Role", UserInfo.LiveUserID, "added new record", UserInfo.SysUserID, UserInfo.Computer);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Insert Record");
            }
            return n;
        }
        internal int Update(RoleInfo r)
        {
            try
            {
                da = new tblRoleTableAdapter();
                n = da.Update(r.NewRoleID, r.Description, r.RoleID);
                LivelogInfo.InsertLog(DateTime.Now, r.RoleID, "Role", UserInfo.LiveUserID, "edited record", UserInfo.SysUserID, UserInfo.Computer);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Insert Record");
            }
            return n;
        }
        internal int Delete(RoleInfo r)
        {
            try
            {
                da = new tblRoleTableAdapter();
                n = da.Delete(r.RoleID);
                LivelogInfo.InsertLog(DateTime.Now, r.RoleID, "Role", UserInfo.LiveUserID, "deleted record", UserInfo.SysUserID, UserInfo.Computer);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Insert Record");
            }
            return n;
        }

        internal DsSecurity.tblRoleDataTable ViewAll()
        {
            try
            {
                da = new tblRoleTableAdapter();
                dt = new DsSecurity.tblRoleDataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "View Record");
            }
            return dt;
        }
        #endregion
    }
    class UserBLL
    {
        #region fields
        private tblUserTableAdapter da = null;
        private DsSecurity.tblUserDataTable dt = null;
        private DsSecurity.tblUserRow rw = null;

        //private LiveAccessTableAdapter daLive = null;
        //private DsSecurity.LiveAccessDataTable dtLive = null;

        private int n = -1;
        
        #endregion
        #region Methods
        internal int Insert(UserInfo r)
        {
            try
            {
                da = new tblUserTableAdapter();
                n = da.Insert(r.UserID,r.Password, r.IsActive, r.RoleID,r.FullName);
                LivelogInfo.InsertLog(DateTime.Now, r.UserID, "User", UserInfo.LiveUserID, "added new record", UserInfo.SysUserID, UserInfo.Computer);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Insert Record");
            }
            return n;
        }
        internal int Update(UserInfo r)
        {
            try
            {
                da = new tblUserTableAdapter();
                n = da.UpdateUserInfo(r.NewUserID,r.IsActive, r.RoleID,r.FullName, r.UserID);
                LivelogInfo.InsertLog(DateTime.Now, r.UserID, "User", UserInfo.LiveUserID, "edited new record", UserInfo.SysUserID, UserInfo.Computer);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Insert Record");
            }
            return n;
        }
        internal int UpdatePassword(UserInfo r)
        {
            try
            {
                da = new tblUserTableAdapter();
                n = da.UpdatePassword(r.Password, r.UserID);
                LivelogInfo.InsertLog(DateTime.Now, UserInfo.LiveUserID, "Users", UserInfo.LiveUserID, "changed password", UserInfo.SysUserID, UserInfo.Computer);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Insert Record");
            }
            return n;
        }
        internal int Delete(UserInfo r)
        {
            try
            {
                da = new tblUserTableAdapter();
                n = da.Delete(r.UserID);
                LivelogInfo.InsertLog(DateTime.Now, r.UserID, "User", UserInfo.LiveUserID, "deleted record", UserInfo.SysUserID, UserInfo.Computer);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Insert Record");
            }
            return n;
        }
        internal void UpdateStatus(UserInfo r)
        {
            try
            {
                da = new tblUserTableAdapter();
                da.UpdateOnlineStatus(r.Online, r.UserID);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Update Record");
            }
        }

        internal DsSecurity.tblUserDataTable ViewAll()
        {
            try
            {
                da = new tblUserTableAdapter();
                dt = new DsSecurity.tblUserDataTable();
                da.FillByU(dt);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "View Record");
            }
            return dt;
        }
        internal int Authenticate(UserInfo r)
        {
            n = -1;
            try
            {
                string pass = string.Empty;
                da = new tblUserTableAdapter();
                pass = da.GetPassword(r.UserID).ToString();
                n = string.Compare(r.Password, pass);
            }
            catch (NullReferenceException exI)
            {
                n = -1;
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Check User");
            }
            LivelogInfo.InsertLog(DateTime.Now, "-", "-", UserInfo.LiveUserID, "Authenticating...", UserInfo.SysUserID, UserInfo.Computer);
            return n;
        }
        internal int OnlineUserCount()
        {
            n = 0;
            try
            {
                da = new tblUserTableAdapter();
                n = Convert.ToInt32(da.UsersOnline());
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Check User");
            }
            return n;
        }
        internal DsSecurity.tblUserDataTable ViewAllByID(string uid)
        {
            try
            {
                da = new tblUserTableAdapter();
                dt = new DsSecurity.tblUserDataTable();
                da.FillByUserID(dt, uid);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "View Record");
            }
            return dt;
        }

        //internal DsSecurity.LiveAccessDataTable ViewProfile(string roleid)
        //{
        //    try
        //    {
        //        daLive = new LiveAccessTableAdapter();
        //        dtLive = new DsSecurity.LiveAccessDataTable();
        //        daLive.FillByRoleID(dtLive, roleid);
        //    }
        //    catch (Exception ex)
        //    {
        //        Interactive.LInfoError(ex.Message, "View Record");
        //    }
        //    return dtLive;
        //}

        #endregion
    }
    class LivelogBLL
    {
        #region fields
        private tblLivelogTableAdapter da = null;
        private DsSecurity.tblLivelogDataTable dt = null;
        private DsSecurity.tblLivelogRow rw = null;

        private static tblLivelogTableAdapter dda = null;
        private static DsSecurity.tblLivelogDataTable ddt = null;
        private static DsSecurity.tblLivelogRow rrw = null;
        private int n = -1;
        #endregion
        #region Methods
        internal static void InsertLog(DateTime dt,string rec,string tbl,string usr,string act,string sysuser,string sys)
        {
            try
            {
                 dda = new tblLivelogTableAdapter();
                 dda.Insert(dt, rec, tbl, usr, act,sysuser,sys);
            }
            catch { }
        }
        internal int Insert(LivelogInfo r)
        {
            try
            {
                da = new tblLivelogTableAdapter();
                n = da.Insert(r.LogDate, r.RecordUID, r.TableName, r.UserID, r.Action,r.SystemUser,r.Computer);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Insert Record");
            }
            return n;
        }
        internal int Update(LivelogInfo r)
        {
            try
            {
                da = new tblLivelogTableAdapter();
                n = da.Update(r.LogDate, r.RecordUID, r.TableName, r.UserID, r.Action,r.SystemUser, r.Computer, r.LogID);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Insert Record");
            }
            return n;
        }
        internal int Delete(LivelogInfo r)
        {
            try
            {
                da = new tblLivelogTableAdapter();
                n = da.Delete(r.LogID);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "Insert Record");
            }
            return n;
        }

        internal DsSecurity.tblLivelogDataTable ViewAll()
        {
            try
            {
                da = new tblLivelogTableAdapter();
                dt = new DsSecurity.tblLivelogDataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Interactive.LInfoError(ex.Message, "View Record");
            }
            return dt;
        }
        #endregion
    }
}