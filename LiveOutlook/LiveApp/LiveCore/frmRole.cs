using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LiveOutlook.LiveUIL.LiveCore;
using System.Threading;
using LiveOutlook.LiveUIL;

namespace LiveOutlook.LiveAPP.LiveCore
{
    public partial class frmRole : Form
    {
        public frmRole()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " [v" + Application.ProductVersion + "]  | " + this.Text;
        }

        #region fields
        private static RoleInfo myR;
        private static bool EditFlag = false;
        private static StringBuilder sb;
        private static bool Proceed = true;
        private static string err;
        private static int LiveSection = -1;
        #endregion

        #region methods
        private void LiveLoad()
        {
            LiveClear();
            myR = new RoleInfo();
            myR.lv(lv);
            myR = null;
        }
        private void LiveEnableControls(bool status)
        {
            #region pn
            foreach (Control a in pn.Controls)
            {
                #region TextBox
                if (a is TextBox)
                {
                    TextBox cntrl = (TextBox)a;
                    cntrl.Enabled = status;
                }
                #endregion
            }
            #endregion
            #region Groupbox
            foreach (Control b in this.Controls)
            {
                if (b is GroupBox)
                {
                    foreach (Control a in b.Controls)
                    {
                        #region Listview
                        if (a is ListView)
                        {
                            ListView cntrl = (ListView)a;
                            cntrl.Enabled = !status;
                        }
                        #endregion
                    }
                }
            }
            #endregion
        }
        private void LiveClearControls()
        {
            #region pn
            foreach (Control a in pn.Controls)
            {
                #region TextBox
                if (a is TextBox)
                {
                    TextBox cntrl = (TextBox)a;
                    cntrl.Clear();
                }
                #endregion
                #region Listview
                if (a is ListView)
                {
                    ListView cntrl = (ListView)a;
                    cntrl.SelectedItems.Clear();
                }
                #endregion
            }
            #endregion
            #region Groupbox
            foreach (Control b in this.Controls)
            {
                if (b is GroupBox)
                {
                    foreach (Control a in b.Controls)
                    {
                        #region Listview
                        if (a is ListView)
                        {
                            ListView cntrl = (ListView)a;
                            cntrl.SelectedItems.Clear();
                        }
                        #endregion
                    }
                }
            }
            #endregion
        }

        private void LiveClear()
        {
            EditFlag = false;
            LiveClearControls();
            LiveEnableControls(false);
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            ePX.Clear();
        }
        private void LiveAdd()
        {
            LiveClearControls();
            LiveEnableControls(true);
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void LiveEdit()
        {
            EditFlag = true;
            LiveEnableControls(true);

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
        }

        private void LiveDisplay()
        {
            txtRoleID.Text = lblID.Text = lv.SelectedItems[0].Text;
            txtDescription.Text = lv.SelectedItems[0].SubItems[1].Text;
        }
        private void LiveClearDisplay()
        {
            lblID.Text = string.Empty;
            txtRoleID.Clear();
            txtDescription.Clear();
        }

        private bool LiveFormIsValid()
        {
            Proceed = true;
            sb = new StringBuilder("Please resolve the following to proceed\n");
            #region pn
            foreach (Control a in pn.Controls)
            {
                #region TextBox
                if ((a is TextBox) && (a.CausesValidation))
                {
                    TextBox cntrl = (TextBox)a;
                    if (cntrl.Text.Trim().Length.Equals(0))
                    {
                        ePX.SetError(cntrl, cntrl.AccessibleDescription);
                        sb.Append("* " + ePX.GetError(cntrl) + " !\n");
                        Proceed = false;
                    }
                    else
                    {
                        ePX.SetError(cntrl, "");
                    }
                }
                #endregion
            }
            #endregion
            err = sb.ToString();
            return Proceed;
        }
        private void LiveSaveInfo()
        {
            if (LiveFormIsValid())
            {
                myR = new RoleInfo();
                myR.RoleID= txtRoleID.Text.Trim();
                myR.Description=txtDescription.Text.Trim();
                if (EditFlag)
                {
                    myR.RoleID = lblID.Text.Trim();
                    myR.NewRoleID = txtRoleID.Text.Trim();
                    if ((Interactive.LInfoConfirm("Are you sure you want to Edit ?", "") == DialogResult.Yes))
                    {
                        if (myR.Edit())
                        {
                            Interactive.LInfo("Information saved successfully", "");
                            LiveLoad();
                        }
                    }
                }
                else
                {
                    if (myR.Add())
                    {
                        Interactive.LInfo("Information saved successfully", "");
                        LiveLoad();
                    }
                }
            }
            else
            {
                Interactive.LInfoError(err, string.Empty);

            }
        }
        private void LiveDeleteInfo()
        {
            if ((Interactive.LInfoWarning("Are you sure you want to Delete ?", "") == DialogResult.Yes))
            {
                myR = new RoleInfo();
                myR.RoleID = lblID.Text.Trim();
                if (myR.Remove())
                {
                    Interactive.LInfo("Information deleted successfully", "");
                    LiveLoad();
                }
                return;
            }
        }
        #endregion

        #region events
        private void frmConfigProvider_Load(object sender, EventArgs e)
        {
            LiveLoad();
        }
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            LiveClearDisplay();
            if (lv.SelectedIndices.Count > 0)
            {
                LiveDisplay();
                if (lblID.Text != "Administrator")
                {
                    btnEdit.Enabled = true;
                    //btnDelete.Enabled = true;
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            LiveAdd();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            LiveEdit();
            txtRoleID.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            LiveSaveInfo();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            LiveDeleteInfo();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LiveClear();
        }
        private void bgWLive_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (LiveSection)
            {
                case 0:
                    break;
                default:
                    break;
            }
        }
        private void bgWLive_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (LiveSection)
            {
                case 0:
                    lblstatus.Text = "Processing...";
                    pbstatus.MarqueeAnimationSpeed = 100;
                    break;
                default:
                    lblstatus.Text = "Please wait...";
                    pbstatus.MarqueeAnimationSpeed = 100;
                    break;
            }
        }
        private void bgWLive_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblstatus.Text = "Ready";
        }

        #endregion

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
