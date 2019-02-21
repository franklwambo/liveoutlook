using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LiveOutlook.LiveUIL.LiveCore;
using LiveOutlook.LiveAPP.LiveCore;

namespace LiveOutlook.LiveApp
{
    public partial class FrmMain : Form
    {
        private int childFormNumber = 0;

        public FrmMain()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " [v" + Application.ProductVersion + "]  | " + this.Text;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            Form childForm = new Form();
            // Make it a child of this MDI form before showing it.
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                // TODO: Add code here to open the file.
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                // TODO: Add code here to save the current contents of the form to a file.
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard.GetText() or System.Windows.Forms.GetData to retrieve information from the clipboard.
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void helpMenu_Click(object sender, EventArgs e)
        {

        }

     

        private void visitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportVisit f = new FrmReportVisit();
            f.Show();
        }

        private void facilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFacility f = new FrmFacility();
            f.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiveAPP.LiveCore.frmUsers f = new LiveOutlook.LiveAPP.LiveCore.frmUsers();
            f.Show();
        }

        private void enroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPatient f = new FrmPatient();
            f.Show();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            UserInfo u = new UserInfo();
            u.IsLogoutOk();
            Application.Exit();

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (Interactive.LInfoConfirm("Are you sure you want to Exit ?", "Exit") == DialogResult.Yes)
            {
                e.Cancel = false;
            }

        }
        private void LoadSecurity()
        {
            switch (UserInfo.LiveRoleID)
            {
                case "Administrator":
                    settingsToolStripMenuItem.Visible = true;
                    break;
                case "User":
                    settingsToolStripMenuItem.Visible = false;
                    break;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
            userToolStripMenuItem.Text = UserInfo.LiveUserID;
            lblPCUserLive.Text = UserInfo.SysUserID + " [" + UserInfo.Computer + "]";
            lblLoggedInLive.Text = "logged in as " + UserInfo.LiveFullname + " [" + UserInfo.LiveUserID + "]";
            lblUsersOnlineLive.Text = "  " + UserInfo.LiveUsers.ToString() + " users online";

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword f = new frmChangePassword();
            f.Show();
        }

        private void appointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAppointment f = new FrmAppointment();
            f.Show();
        }

        private void tsbtnAppointments_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Loading... please wait";
            pblive.Style = ProgressBarStyle.Marquee;
            pblive.MarqueeAnimationSpeed = 100;
            this.Cursor = Cursors.AppStarting;
            FrmAppointment f = new FrmAppointment();
            f.Show();
            lblStatus.Text = "Ready";
            pblive.Style = ProgressBarStyle.Blocks;
            pblive.Value = 0;
            this.Cursor = Cursors.Default;
        }

        private void tsbtnEnrollement_Click(object sender, EventArgs e)
        {
            FrmPatient f = new FrmPatient();
            f.Show();

        }

        private void tsbtnVisit_Click(object sender, EventArgs e)
        {
            FrmReportVisit f = new FrmReportVisit();
            f.Show();
        }

        private void activePatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportVisit f = new FrmReportVisit(true);
            f.Show();
        }

        private void defaultersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmReportVisit f = new FrmReportVisit(3);
            f.Show();
        }
    }
}