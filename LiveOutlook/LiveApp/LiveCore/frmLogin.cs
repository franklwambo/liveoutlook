using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LiveOutlook.LiveUIL.LiveCore;
using LiveOutlook.LiveUIL;
using LiveOutlook.LiveApp.LiveCore;

namespace LiveOutlook.LiveApp.LiveCore
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " [v" + Application.ProductVersion + "]  | " + this.Text;
        }
        #region fields
        private static UserInfo myU;
        private static StringBuilder sb;
        private static bool Proceed = true;
        private static string err;
        #endregion
        #region Methods
        private bool LiveFormIsValid()
        {
            Proceed = true;
            sb = new StringBuilder("Could not login\n");
            #region pn
            foreach (Control a in pn.Controls)
            {
                #region TextBox
                if ((a is TextBox) && (a.CausesValidation))
                {
                    TextBox cntrl = (TextBox)a;
                    if (cntrl.Text.Trim().Length.Equals(0))
                    {
                        ePX.SetError(cntrl, cntrl.AccessibleDescription + " is required");
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
            btnOK.Enabled = status;
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
            }
            #endregion
        }
        private void LiveClear()
        {
            LiveClearControls();
            LiveEnableControls(true);
            ePX.Clear();
        }
        private void LiveLogin()
        {
            if (LiveFormIsValid())
            {
                LiveEnableControls(false);

                myU = new UserInfo();
                myU.UserID = txtUserID.Text.Trim();
                myU.Password = txtPassword.Text.Trim();
                myU.LoadPCProfile();
                if (myU.IsLoginOk())
                {
                    if (UserInfo.LiveIsActive)
                    {
                        this.Hide();
                        Splash f = new Splash();
                        f.Show();
                    }
                    else
                    {
                        LiveEnableControls(true);
                    }
                }
                else 
                {
                    LivelogInfo.InsertLog(DateTime.Now, "-", "-", UserInfo.LiveUserID, "logged in failed", UserInfo.SysUserID, UserInfo.Computer);
                    Interactive.LInfoError("User ID or Password is incorrect,\nPassword should be in the correct case", "Login failed");
                    LiveEnableControls(true);
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                Interactive.LInfoError(err, string.Empty);
            }
            this.Cursor = Cursors.Default;
        } 
        #endregion
        #region Events
        private void frmLogin_Load(object sender, EventArgs e)
        {
            //this.Enabled = false;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LiveLogin();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LiveClear();
        } 
        #endregion
    }
}