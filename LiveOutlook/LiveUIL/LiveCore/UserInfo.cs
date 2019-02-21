// LiveOutlook.LiveUIL.LiveCore.UserInfo
using LiveOutlook.LiveBLL.LiveCore;
using LiveOutlook.LiveDAL.LiveCore;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Windows.Forms;

namespace LiveOutlook.LiveUIL.LiveCore
{

    internal class UserInfo : UserBLL
    {
        public static string Computer = string.Empty;

        public static string SysUserID = string.Empty;

        public static string LiveUserID = string.Empty;

        public static string LiveFullname = string.Empty;

        public static string LivePassword = string.Empty;

        public static string LiveRoleID = string.Empty;

        public static bool LiveIsActive = false;

        public static int LiveUsers = 0;

        public static List<string> LiveAccessSections;

        private string _UserID = string.Empty;

        private string _FullName = string.Empty;

        private string _Password = string.Empty;

        private bool _IsActive;

        private string _RoleID = string.Empty;

        private bool _Online;

        private string _NewUserID = string.Empty;

        public string UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }

        public string RoleID
        {
            get
            {
                return _RoleID;
            }
            set
            {
                _RoleID = value;
            }
        }

        public string FullName
        {
            get
            {
                return _FullName;
            }
            set
            {
                _FullName = value;
            }
        }

        public bool Online
        {
            get
            {
                return _Online;
            }
            set
            {
                _Online = value;
            }
        }

        public string NewUserID
        {
            get
            {
                return _NewUserID;
            }
            set
            {
                _NewUserID = value;
            }
        }

        public ListView lv(ListView lv)
        {
            lv.Columns.Clear();
            lv.Items.Clear();
            lv.Columns.Add("UserID");
            lv.Columns.Add("Names");
            lv.Columns.Add("RoleID");
            lv.Columns.Add("IsActive");
            foreach (DsSecurity.tblUserRow item in ViewAll())
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = item.UserID;
                listViewItem.SubItems.Add(item.FullName);
                listViewItem.SubItems.Add(item.RoleID);
                listViewItem.SubItems.Add(item.IsActive.ToString());
                lv.Items.Add(listViewItem);
            }
            if (lv.Items.Count > 0)
            {
                for (int i = 0; i < lv.Columns.Count; i++)
                {
                    lv.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
            else
            {
                for (int j = 0; j < lv.Columns.Count; j++)
                {
                    lv.Columns[j].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
            return lv;
        }

        public ComboBox cmb(ComboBox cmb)
        {
            cmb.BeginUpdate();
            cmb.EndUpdate();
            return cmb;
        }

        public ListBox lst(ListBox lst)
        {
            lst.BeginUpdate();
            return lst;
        }

        public TreeView tv(TreeView tv)
        {
            TreeNode treeNode = tv.Nodes.Add("");
            TreeNode treeNode2 = treeNode.Nodes.Add("");
            treeNode2.Nodes.Add("");
            return tv;
        }

        public bool Add()
        {
            bool flag = false;
            return (Insert(this) > 0) ? true : false;
        }

        public bool Edit()
        {
            bool flag = false;
            return (Update(this) > 0) ? true : false;
        }

        public bool EditPassword()
        {
            bool flag = false;
            return (UpdatePassword(this) > 0) ? true : false;
        }

        public bool Remove()
        {
            bool flag = false;
            return (Delete(this) > 0) ? true : false;
        }

        public bool IsLoginUser()
        {
            bool flag = false;
            return (Authenticate(this) == 0) ? true : false;
        }

        public bool IsLoginOk()
        {
            bool flag = false;
            flag = ((Authenticate(this) == 0) ? true : false);
            if (flag)
            {
                Online = true;
                LoadUserProfile();
                if (LiveIsActive)
                {
                    UpdateStatus(this);
                    LoadUserProfile();
                    LivelogBLL.InsertLog(DateTime.Now, "-", "-", LiveUserID, "logged in", SysUserID, Computer);
                }
                else
                {
                    LivelogBLL.InsertLog(DateTime.Now, "-", "-", LiveUserID, "logged in failed", SysUserID, Computer);
                    Interactive.LInfoError("please contact you system admin", "Account has been disabled");
                }
            }
            return flag;
        }

        public void IsLogoutOk()
        {
            UserID = LiveUserID;
            Online = false;
            UpdateStatus(this);
            LivelogBLL.InsertLog(DateTime.Now, "-", "-", LiveUserID, "logged out", SysUserID, Computer);
        }

        public void LoadPCProfile()
        {
            try
            {
                SysUserID = WindowsIdentity.GetCurrent().Name;
            }
            catch
            {
            }
            try
            {
                Computer = Environment.MachineName;
            }
            catch
            {
            }
        }

        private void LoadUserProfile()
        {
            LiveAccessSections = new List<string>();
            foreach (DsSecurity.tblUserRow item in ViewAllByID(UserID))
            {
                LiveUserID = item.UserID;
                LiveFullname = item.FullName;
                LivePassword = item.Password;
                LiveIsActive = item.IsActive;
                LiveRoleID = item.RoleID;
            }
            LiveUsers = OnlineUserCount();
        }
    }

}

