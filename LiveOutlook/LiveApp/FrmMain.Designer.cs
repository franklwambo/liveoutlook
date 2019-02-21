namespace LiveOutlook.LiveApp
{
    // LiveOutlook.LiveApp.FrmMain
    using LiveOutlook.LiveApp;
    using LiveOutlook.LiveAPP.LiveCore;
    using LiveOutlook.LiveUIL.LiveCore;
    using LiveOutlook.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;

    public partial class FrmMain
    {

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(LiveOutlook.LiveApp.FrmMain));
            ToolTip = new System.Windows.Forms.ToolTip(components);
            lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip = new System.Windows.Forms.StatusStrip();
            lblLoggedInLive = new System.Windows.Forms.ToolStripStatusLabel();
            lblPCUserLive = new System.Windows.Forms.ToolStripStatusLabel();
            lblUsersOnlineLive = new System.Windows.Forms.ToolStripStatusLabel();
            pblive = new System.Windows.Forms.ToolStripProgressBar();
            toolStrip = new System.Windows.Forms.ToolStrip();
            tsbtnAppointments = new System.Windows.Forms.ToolStripButton();
            tsbtnEnrollement = new System.Windows.Forms.ToolStripButton();
            tsbtnVisit = new System.Windows.Forms.ToolStripButton();
            fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip = new System.Windows.Forms.MenuStrip();
            patientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            facilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            visitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            activePatientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            defaultersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(161, 17);
            lblStatus.Spring = true;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[5]
            {
            lblStatus,
            lblLoggedInLive,
            lblPCUserLive,
            lblUsersOnlineLive,
            pblive
            });
            statusStrip.Location = new System.Drawing.Point(0, 431);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(764, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            lblLoggedInLive.Name = "lblLoggedInLive";
            lblLoggedInLive.Size = new System.Drawing.Size(161, 17);
            lblLoggedInLive.Spring = true;
            lblLoggedInLive.Text = "logged in as Amme";
            lblPCUserLive.Name = "lblPCUserLive";
            lblPCUserLive.Size = new System.Drawing.Size(161, 17);
            lblPCUserLive.Spring = true;
            lblPCUserLive.Text = "Ke\\dkoske";
            lblUsersOnlineLive.Name = "lblUsersOnlineLive";
            lblUsersOnlineLive.Size = new System.Drawing.Size(161, 17);
            lblUsersOnlineLive.Spring = true;
            lblUsersOnlineLive.Text = "5 users online";
            pblive.Name = "pblive";
            pblive.Size = new System.Drawing.Size(100, 16);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[3]
            {
            tsbtnAppointments,
            tsbtnEnrollement,
            tsbtnVisit
            });
            toolStrip.Location = new System.Drawing.Point(0, 24);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new System.Drawing.Size(764, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "ToolStrip";
            tsbtnAppointments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbtnAppointments.Image = LiveOutlook.Properties.Resources.cale;
            tsbtnAppointments.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbtnAppointments.Name = "tsbtnAppointments";
            tsbtnAppointments.Size = new System.Drawing.Size(23, 22);
            tsbtnAppointments.Text = "toolStripButton1";
            tsbtnAppointments.ToolTipText = "Manage Appointments";
            tsbtnAppointments.Click += new System.EventHandler(tsbtnAppointments_Click);
            tsbtnEnrollement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbtnEnrollement.Image = LiveOutlook.Properties.Resources.Accept;
            tsbtnEnrollement.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbtnEnrollement.Name = "tsbtnEnrollement";
            tsbtnEnrollement.Size = new System.Drawing.Size(23, 22);
            tsbtnEnrollement.Text = "toolStripButton2";
            tsbtnEnrollement.ToolTipText = "Manage Patients";
            tsbtnEnrollement.Click += new System.EventHandler(tsbtnEnrollement_Click);
            tsbtnVisit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbtnVisit.Image = LiveOutlook.Properties.Resources.ReportGraph;
            tsbtnVisit.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbtnVisit.Name = "tsbtnVisit";
            tsbtnVisit.Size = new System.Drawing.Size(23, 22);
            tsbtnVisit.Text = "toolStripButton3";
            tsbtnVisit.ToolTipText = "Reporting";
            tsbtnVisit.Click += new System.EventHandler(tsbtnVisit_Click);
            fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1]
            {
            exitToolStripMenuItem
            });
            fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new System.Drawing.Size(37, 20);
            fileMenu.Text = "&File";
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += new System.EventHandler(ExitToolsStripMenuItem_Click);
            viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2]
            {
            toolBarToolStripMenuItem,
            statusBarToolStripMenuItem
            });
            viewMenu.Name = "viewMenu";
            viewMenu.Size = new System.Drawing.Size(44, 20);
            viewMenu.Text = "&View";
            toolBarToolStripMenuItem.Checked = true;
            toolBarToolStripMenuItem.CheckOnClick = true;
            toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            toolBarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            toolBarToolStripMenuItem.Text = "&Toolbar";
            toolBarToolStripMenuItem.Click += new System.EventHandler(ToolBarToolStripMenuItem_Click);
            statusBarToolStripMenuItem.Checked = true;
            statusBarToolStripMenuItem.CheckOnClick = true;
            statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            statusBarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            statusBarToolStripMenuItem.Text = "&Status Bar";
            statusBarToolStripMenuItem.Click += new System.EventHandler(StatusBarToolStripMenuItem_Click);
            windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5]
            {
            cascadeToolStripMenuItem,
            tileVerticalToolStripMenuItem,
            tileHorizontalToolStripMenuItem,
            closeAllToolStripMenuItem,
            arrangeIconsToolStripMenuItem
            });
            windowsMenu.Name = "windowsMenu";
            windowsMenu.Size = new System.Drawing.Size(68, 20);
            windowsMenu.Text = "&Windows";
            cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            cascadeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            cascadeToolStripMenuItem.Text = "&Cascade";
            cascadeToolStripMenuItem.Click += new System.EventHandler(CascadeToolStripMenuItem_Click);
            tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            tileVerticalToolStripMenuItem.Click += new System.EventHandler(TileVerticalToolStripMenuItem_Click);
            tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            tileHorizontalToolStripMenuItem.Click += new System.EventHandler(TileHorizontalToolStripMenuItem_Click);
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            closeAllToolStripMenuItem.Text = "C&lose All";
            closeAllToolStripMenuItem.Click += new System.EventHandler(CloseAllToolStripMenuItem_Click);
            arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            arrangeIconsToolStripMenuItem.Click += new System.EventHandler(ArrangeIconsToolStripMenuItem_Click);
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[7]
            {
            fileMenu,
            viewMenu,
            patientsToolStripMenuItem,
            settingsToolStripMenuItem,
            reportsToolStripMenuItem,
            windowsMenu,
            userToolStripMenuItem
            });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.MdiWindowListItem = windowsMenu;
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(764, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            patientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2]
            {
            appointmentsToolStripMenuItem,
            enroToolStripMenuItem
            });
            patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            patientsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            patientsToolStripMenuItem.Text = "Patients";
            appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            appointmentsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            appointmentsToolStripMenuItem.Text = "Appointments";
            appointmentsToolStripMenuItem.Click += new System.EventHandler(appointmentsToolStripMenuItem_Click);
            enroToolStripMenuItem.Name = "enroToolStripMenuItem";
            enroToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            enroToolStripMenuItem.Text = "Enrollment";
            enroToolStripMenuItem.Click += new System.EventHandler(enroToolStripMenuItem_Click);
            settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2]
            {
            facilityToolStripMenuItem,
            usersToolStripMenuItem
            });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            facilityToolStripMenuItem.Name = "facilityToolStripMenuItem";
            facilityToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            facilityToolStripMenuItem.Text = "Facility";
            facilityToolStripMenuItem.Click += new System.EventHandler(facilityToolStripMenuItem_Click);
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            usersToolStripMenuItem.Text = "Users";
            usersToolStripMenuItem.Click += new System.EventHandler(usersToolStripMenuItem_Click);
            reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3]
            {
            visitsToolStripMenuItem,
            activePatientsToolStripMenuItem,
            defaultersToolStripMenuItem
            });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            reportsToolStripMenuItem.Text = "Reports";
            visitsToolStripMenuItem.Image = LiveOutlook.Properties.Resources.ReportGraph;
            visitsToolStripMenuItem.Name = "visitsToolStripMenuItem";
            visitsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            visitsToolStripMenuItem.Text = "Visits";
            visitsToolStripMenuItem.Click += new System.EventHandler(visitsToolStripMenuItem_Click);
            activePatientsToolStripMenuItem.Name = "activePatientsToolStripMenuItem";
            activePatientsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            activePatientsToolStripMenuItem.Text = "Active patients";
            activePatientsToolStripMenuItem.Click += new System.EventHandler(activePatientsToolStripMenuItem_Click);
            defaultersToolStripMenuItem.Name = "defaultersToolStripMenuItem";
            defaultersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            defaultersToolStripMenuItem.Text = "Defaulters";
            defaultersToolStripMenuItem.Click += new System.EventHandler(defaultersToolStripMenuItem_Click);
            userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1]
            {
            changePasswordToolStripMenuItem
            });
            userToolStripMenuItem.Name = "userToolStripMenuItem";
            userToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            userToolStripMenuItem.Text = "user";
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            changePasswordToolStripMenuItem.Text = "Change Password";
            changePasswordToolStripMenuItem.Click += new System.EventHandler(changePasswordToolStripMenuItem_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(764, 453);
            base.Controls.Add(statusStrip);
            base.Controls.Add(toolStrip);
            base.Controls.Add(menuStrip);
            base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.IsMdiContainer = true;
            base.MainMenuStrip = menuStrip;
            base.Name = "FrmMain";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Hospital Reception System - PSC";
            base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            base.Load += new System.EventHandler(FrmMain_Load);
            base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FrmMain_FormClosed);
            base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmMain_FormClosing);
            statusStrip.ResumeLayout(performLayout: false);
            statusStrip.PerformLayout();
            toolStrip.ResumeLayout(performLayout: false);
            toolStrip.PerformLayout();
            menuStrip.ResumeLayout(performLayout: false);
            menuStrip.PerformLayout();
            ResumeLayout(performLayout: false);
            PerformLayout();
        }
        private IContainer components;

        private ToolTip ToolTip;

        private ToolStripStatusLabel lblStatus;

        private StatusStrip statusStrip;

        private ToolStrip toolStrip;

        private ToolStripMenuItem fileMenu;

        private ToolStripMenuItem exitToolStripMenuItem;

        private ToolStripMenuItem viewMenu;

        private ToolStripMenuItem toolBarToolStripMenuItem;

        private ToolStripMenuItem statusBarToolStripMenuItem;

        private ToolStripMenuItem windowsMenu;

        private ToolStripMenuItem cascadeToolStripMenuItem;

        private ToolStripMenuItem tileVerticalToolStripMenuItem;

        private ToolStripMenuItem tileHorizontalToolStripMenuItem;

        private ToolStripMenuItem closeAllToolStripMenuItem;

        private ToolStripMenuItem arrangeIconsToolStripMenuItem;

        private MenuStrip menuStrip;

        private ToolStripMenuItem patientsToolStripMenuItem;

        private ToolStripMenuItem enroToolStripMenuItem;

        private ToolStripMenuItem settingsToolStripMenuItem;

        private ToolStripMenuItem facilityToolStripMenuItem;

        private ToolStripMenuItem reportsToolStripMenuItem;

        private ToolStripMenuItem visitsToolStripMenuItem;

        private ToolStripMenuItem appointmentsToolStripMenuItem;

        private ToolStripMenuItem usersToolStripMenuItem;

        private ToolStripMenuItem userToolStripMenuItem;

        private ToolStripStatusLabel lblLoggedInLive;

        private ToolStripStatusLabel lblPCUserLive;

        private ToolStripMenuItem changePasswordToolStripMenuItem;

        private ToolStripProgressBar pblive;

        private ToolStripStatusLabel lblUsersOnlineLive;

        private ToolStripButton tsbtnAppointments;

        private ToolStripButton tsbtnEnrollement;

        private ToolStripButton tsbtnVisit;

        private ToolStripMenuItem activePatientsToolStripMenuItem;

        private ToolStripMenuItem defaultersToolStripMenuItem;



    }
}