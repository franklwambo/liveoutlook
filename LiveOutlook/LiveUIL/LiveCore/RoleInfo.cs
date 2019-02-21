using LiveOutlook.LiveBLL.LiveCore;
using LiveOutlook.LiveDAL.LiveCore;
using System.Windows.Forms;

namespace LiveOutlook.LiveUIL.LiveCore
{
    // LiveOutlook.LiveUIL.LiveCore.RoleInfo

    internal class RoleInfo : RoleBLL
    {
        private string _RoleID = string.Empty;

        private string _Description = string.Empty;

        private string _NewRoleID = string.Empty;

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

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        public string NewRoleID
        {
            get
            {
                return _NewRoleID;
            }
            set
            {
                _NewRoleID = value;
            }
        }

        public ListView lv(ListView lv)
        {
            lv.Columns.Clear();
            lv.Items.Clear();
            lv.Columns.Add("RoleID");
            lv.Columns.Add("Description");
            foreach (DsSecurity.tblRoleRow item in ViewAll())
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = item.RoleID;
                listViewItem.SubItems.Add(item.Description);
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
            cmb.DisplayMember = "RoleID";
            cmb.ValueMember = "RoleID";
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

