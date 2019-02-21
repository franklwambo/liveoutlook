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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            //LiveOutlook | 
            InitializeComponent();
            this.Text = Application.ProductName + " [v" + Application.ProductVersion + "]  | " + this.Text;
        }

        #region fields
        private static UserInfo myU;
        private static bool EditFlag = false;
        private static bool EditFlagPass = false;
        private static StringBuilder sb;
        private static bool Proceed = true;
        private static string err;
        private static int LiveSection = -1;
        #endregion

        #region methods
        private void LiveLoad()
        {
            LiveClear();
            RoleInfo myRI = new RoleInfo();
            myRI.cmb(cmbRole);
            myRI = null;

            myU = new UserInfo();
            myU.lv(lv);
            myU = null;
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
                #region Combobox
                if (a is ComboBox)
                {
                    ComboBox cntrl = (ComboBox)a;
                    cntrl.Enabled = status;
                }
                #endregion
                #region CheckBox
                if (a is CheckBox)
                {
                    if (lblID.Text.Trim() != "Admin")
                    {
                        CheckBox cntrl = (CheckBox)a;
                        cntrl.Enabled = status;
                    }
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
                #region ComboBox
                if (a is ComboBox)
                {
                    ComboBox cntrl = (ComboBox)a;
                    cntrl.SelectedIndex =-1;
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
            #region pass
            foreach (Control a in gbPass.Controls)
            {
                #region TextBox
                if (a is TextBox)
                {
                    TextBox cntrl = (TextBox)a;
                    cntrl.Clear();
                }
                #endregion
            }
            #endregion

        }

        private void LiveClear()
        {
            EditFlag = false;
            EditFlagPass = false;
            LiveClearControls();
            LiveEnableControls(false);
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnEditPass.Enabled = false;
            ePX.Clear();
            gbPass.Enabled = false;
        }
        private void LiveAdd()
        {
            LiveClearControls();
            LiveEnableControls(true);
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            gbPass.Enabled = true;
            btnEditPass.Enabled = false;
        }
        private void LiveEdit()
        {
            EditFlag = true;
            LiveEnableControls(true);

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            gbPass.Enabled = false;
            btnEditPass.Enabled = false;

        }
        private void LiveEditPass()
        {
            EditFlagPass = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            gbPass.Enabled = true;
            btnEditPass.Enabled = false;
        }

        private void LiveDisplay()
        {
            txtUserID.Text = lblID.Text = lv.SelectedItems[0].Text;
            txtName.Text = lv.SelectedItems[0].SubItems[1].Text;
            cmbRole.SelectedValue= lv.SelectedItems[0].SubItems[2].Text;
            chkIsActive.Checked = Convert.ToBoolean(lv.SelectedItems[0].SubItems[3].Text);
        }
        private void LiveClearDisplay()
        {
            lblID.Text = string.Empty;
            txtUserID.Clear();
            txtName.Clear();
            cmbRole.SelectedIndex = -1;
            chkIsActive.Checked = true;
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
                #region Combobox
                if ((a is ComboBox) && (a.CausesValidation))
                {
                    ComboBox cntrl = (ComboBox)a;
                    if (cntrl.SelectedIndex==-1)
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
            #region pass
            if (gbPass.Enabled)
            {
                foreach (Control a in gbPass.Controls)
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
            }
            #endregion  
            err = sb.ToString();
            return Proceed;
        }
        private void LiveSaveInfo()
        {
            if (LiveFormIsValid())
            {
                myU = new UserInfo();
                myU.UserID =txtUserID.Text.Trim();
                myU.FullName = txtName.Text.Trim();
                myU.RoleID = cmbRole.SelectedValue.ToString().Trim();
                myU.IsActive = chkIsActive.Checked;
                if (EditFlag)
                {
                    myU.UserID = lblID.Text.Trim();
                    myU.NewUserID = txtUserID.Text.Trim();
                    if ((Interactive.LInfoConfirm("Are you sure you want to Edit ?", "") == DialogResult.Yes))
                    {
                        if (myU.Edit())
                        {
                            Interactive.LInfo("Information saved successfully", "");
                            LiveLoad();
                        }
                    }
                }
                else if(EditFlagPass)
                {
                    myU.Password = txtConfirmPass.Text.Trim();
                    if (myU.EditPassword())
                    {
                        Interactive.LInfo("Information saved successfully", "");
                        LiveLoad();
                    }
                }
                else
                {
                    myU.Password = txtConfirmPass.Text.Trim();
                    if (myU.Add())
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
                myU = new UserInfo();
                myU.UserID = lblID.Text.Trim();
                if (myU.Remove())
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
            btnEditPass.Enabled = false;
            LiveClearDisplay();
            if (lv.SelectedIndices.Count > 0)
            {
                LiveDisplay();
                if (lblID.Text.Trim() != "Admin")
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
                btnEditPass.Enabled = true;

            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            LiveAdd();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            LiveEdit();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gbPass.Enabled)
            {
                int cmp = string.Compare(txtPass.Text.Trim(), txtConfirmPass.Text.Trim());
                if (cmp != 0)
                {
                    Interactive.LInfoError("Passwords do not match", "Users");
                    return;
                }
            }
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

        private void btnEditPass_Click(object sender, EventArgs e)
        {
            LiveEditPass();
        }

        private void eventSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string strInv = string.Empty;
            //if (lv.SelectedItems.Count > 0)
            //{
            //    strInv = lv.SelectedItems[0].Text;
            //}

            //if (strInv.Trim().Length == 0)
            //{
            //    Interactive.LInfoWarningOK("Please select use first", "Cannot view log");
            //}
            //else
            //{
            //    FrmAuditReport f = new  FrmAuditReport(strInv.Trim(),9);
            //    f.Show();
            //}
        }
    }
}
