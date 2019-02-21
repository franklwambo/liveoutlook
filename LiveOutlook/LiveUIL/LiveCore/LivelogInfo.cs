using LiveOutlook.LiveBLL.LiveCore;
using LiveOutlook.LiveDAL.LiveCore;
using System;
using System.Windows.Forms;


namespace LiveOutlook.LiveUIL.LiveCore
{
    // LiveOutlook.LiveUIL.LiveCore.LivelogInfo
    internal class LivelogInfo : LivelogBLL
    {
        private long _LogID = -1L;

        private DateTime _LogDate = Convert.ToDateTime("01/01/1900");

        private string _RecordUID = "-";

        private string _TableName = "-";

        private string _UserID = "-";

        private string _Action = "-";

        private string _SysetmUser = "-";

        private string _Computer = "-";

        public long LogID
        {
            get
            {
                return _LogID;
            }
            set
            {
                _LogID = value;
            }
        }

        public DateTime LogDate
        {
            get
            {
                return _LogDate;
            }
            set
            {
                _LogDate = value;
            }
        }

        public string RecordUID
        {
            get
            {
                return _RecordUID;
            }
            set
            {
                _RecordUID = value;
            }
        }

        public string TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                _TableName = value;
            }
        }

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

        public string Action
        {
            get
            {
                return _Action;
            }
            set
            {
                _Action = value;
            }
        }

        public string SystemUser
        {
            get
            {
                return _SysetmUser;
            }
            set
            {
                _SysetmUser = value;
            }
        }

        public string Computer
        {
            get
            {
                return _Computer;
            }
            set
            {
                _Computer = value;
            }
        }

        public ListView lv(ListView lv)
        {
            lv.Columns.Clear();
            lv.Items.Clear();
            lv.Columns.Add("ID");
            lv.Columns.Add("Date");
            lv.Columns.Add("Record ID");
            lv.Columns.Add("Table");
            lv.Columns.Add("UserID");
            lv.Columns.Add("Action");
            foreach (DsSecurity.tblLivelogRow item in ViewAll())
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = item.LogID.ToString();
                listViewItem.SubItems.Add(item.LogDate.ToString("ddMMMyy Hmmss"));
                listViewItem.SubItems.Add(item.RecordUID);
                listViewItem.SubItems.Add(item.TableName);
                listViewItem.SubItems.Add(item.UserID);
                listViewItem.SubItems.Add(item.Action);
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
            cmb.DataSource = ViewAll();
            cmb.DisplayMember = "LivelogID";
            cmb.ValueMember = "LivelogID";
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

        public bool Remove()
        {
            bool flag = false;
            return (Delete(this) > 0) ? true : false;
        }
    }

}
