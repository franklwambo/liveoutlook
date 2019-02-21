using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LiveOutlook.LiveUIL.LiveCore;
using LiveOutlook.LiveUIL;

namespace LiveOutlook.LiveAPP.LiveCore
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " [v" + Application.ProductVersion + "]  | " + this.Text;
        }

        #region fields
        private static UserInfo myU;
        private static bool EditFlag = false;
        private static StringBuilder sb;
        private static bool Proceed = true;
        private static string err;
        private static int LiveSection = -1;
        #endregion

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
            ePX.Clear();
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
            #region password

            int n = string.Compare(txtNewPassword.Text.Trim(), txtConfirmPassword.Text.Trim());
            if (n != 0)
            {
                ePX.SetError(txtConfirmPassword,"Passwords do not match");
                sb.Append("* " + ePX.GetError(txtConfirmPassword) + " !\n");
                Proceed = false;
                txtConfirmPassword.SelectAll();
            }
            else
            {
                ePX.SetError(txtConfirmPassword, "");
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
                myU.UserID = UserInfo.LiveUserID;
                myU.Password = txtOldPassword.Text.Trim();

                if (myU.IsLoginUser())
                {
                    myU.Password =txtConfirmPassword.Text.Trim();
                    if (myU.EditPassword())
                    {
                        Interactive.LInfo("Your password has been changed", "Change password");
                        LiveClearControls();
                        this.Close();
                    }
                }
                else
                {
                    Interactive.LInfoError("Old password is wrong","Change password");
                    txtOldPassword.SelectAll();
                }
            }
            else
            {
                Interactive.LInfoError(err, string.Empty);
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            LiveClearControls();
            lbluser.Text = UserInfo.LiveUserID + " [" + UserInfo.LiveFullname + "]";
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            LiveSaveInfo();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LiveClearControls();
        }

      

        
    }
}