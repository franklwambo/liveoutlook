namespace LiveOutlook.LiveAPP.LiveCore
{
    partial class frmUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.statusStripLive = new System.Windows.Forms.StatusStrip();
            this.lblstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbstatus = new System.Windows.Forms.ToolStripProgressBar();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ePX = new System.Windows.Forms.ErrorProvider(this.components);
            this.bgWLive = new System.ComponentModel.BackgroundWorker();
            this.imageListLiveSmall = new System.Windows.Forms.ImageList(this.components);
            this.imageListLiveLarge = new System.Windows.Forms.ImageList(this.components);
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.pn = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbPass = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eventSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gb = new System.Windows.Forms.GroupBox();
            this.btnEditPass = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lv = new System.Windows.Forms.ListView();
            this.statusStripLive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ePX)).BeginInit();
            this.pn.SuspendLayout();
            this.gbPass.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Role";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "UserID";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(59, 5);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(165, 20);
            this.txtUserID.TabIndex = 6;
            // 
            // statusStripLive
            // 
            this.statusStripLive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblstatus,
            this.pbstatus});
            this.statusStripLive.Location = new System.Drawing.Point(0, 496);
            this.statusStripLive.Name = "statusStripLive";
            this.statusStripLive.Size = new System.Drawing.Size(541, 22);
            this.statusStripLive.TabIndex = 7;
            this.statusStripLive.Text = "statusStrip1";
            // 
            // lblstatus
            // 
            this.lblstatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(424, 17);
            this.lblstatus.Spring = true;
            this.lblstatus.Text = "Ready";
            this.lblstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbstatus
            // 
            this.pbstatus.Name = "pbstatus";
            this.pbstatus.Size = new System.Drawing.Size(100, 16);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(122, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 24);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(59, 165);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(57, 24);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(185, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 24);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ePX
            // 
            this.ePX.ContainerControl = this;
            // 
            // bgWLive
            // 
            this.bgWLive.WorkerReportsProgress = true;
            this.bgWLive.WorkerSupportsCancellation = true;
            this.bgWLive.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWLive_DoWork);
            this.bgWLive.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWLive_RunWorkerCompleted);
            this.bgWLive.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWLive_ProgressChanged);
            // 
            // imageListLiveSmall
            // 
            this.imageListLiveSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListLiveSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListLiveSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListLiveLarge
            // 
            this.imageListLiveLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListLiveLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.imageListLiveLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(59, 78);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(56, 17);
            this.chkIsActive.TabIndex = 11;
            this.chkIsActive.Text = "Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(59, 53);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(191, 21);
            this.cmbRole.TabIndex = 12;
            // 
            // pn
            // 
            this.pn.Controls.Add(this.txtName);
            this.pn.Controls.Add(this.label5);
            this.pn.Controls.Add(this.gbPass);
            this.pn.Controls.Add(this.label3);
            this.pn.Controls.Add(this.cmbRole);
            this.pn.Controls.Add(this.label1);
            this.pn.Controls.Add(this.chkIsActive);
            this.pn.Controls.Add(this.txtUserID);
            this.pn.Controls.Add(this.btnCancel);
            this.pn.Controls.Add(this.btnNew);
            this.pn.Controls.Add(this.btnSave);
            this.pn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn.Location = new System.Drawing.Point(0, 300);
            this.pn.Name = "pn";
            this.pn.Size = new System.Drawing.Size(541, 196);
            this.pn.TabIndex = 13;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(59, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(322, 20);
            this.txtName.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Names";
            // 
            // gbPass
            // 
            this.gbPass.Controls.Add(this.label4);
            this.gbPass.Controls.Add(this.label2);
            this.gbPass.Controls.Add(this.txtConfirmPass);
            this.gbPass.Controls.Add(this.txtPass);
            this.gbPass.Enabled = false;
            this.gbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPass.Location = new System.Drawing.Point(9, 99);
            this.gbPass.Name = "gbPass";
            this.gbPass.Size = new System.Drawing.Size(313, 62);
            this.gbPass.TabIndex = 13;
            this.gbPass.TabStop = false;
            this.gbPass.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Confirm password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.AccessibleDescription = "Confirm password";
            this.txtConfirmPass.Location = new System.Drawing.Point(92, 37);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(169, 18);
            this.txtConfirmPass.TabIndex = 8;
            // 
            // txtPass
            // 
            this.txtPass.AccessibleDescription = "Password";
            this.txtPass.Location = new System.Drawing.Point(92, 15);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(169, 18);
            this.txtPass.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventSummaryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 26);
            // 
            // eventSummaryToolStripMenuItem
            // 
            this.eventSummaryToolStripMenuItem.Name = "eventSummaryToolStripMenuItem";
            this.eventSummaryToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.eventSummaryToolStripMenuItem.Text = "Event summary";
            this.eventSummaryToolStripMenuItem.Click += new System.EventHandler(this.eventSummaryToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 49);
            this.panel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::LiveOutlook.Properties.Resources.LiveLogo;
            this.pictureBox1.Location = new System.Drawing.Point(484, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 49);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(58, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Add,Edit and delete user information";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Manage system access";
            // 
            // gb
            // 
            this.gb.Controls.Add(this.btnEditPass);
            this.gb.Controls.Add(this.lblID);
            this.gb.Controls.Add(this.btnDelete);
            this.gb.Controls.Add(this.btnEdit);
            this.gb.Controls.Add(this.lv);
            this.gb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb.Location = new System.Drawing.Point(0, 49);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(541, 251);
            this.gb.TabIndex = 15;
            this.gb.TabStop = false;
            this.gb.Text = "User Information";
            // 
            // btnEditPass
            // 
            this.btnEditPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPass.Location = new System.Drawing.Point(428, 221);
            this.btnEditPass.Name = "btnEditPass";
            this.btnEditPass.Size = new System.Drawing.Size(103, 26);
            this.btnEditPass.TabIndex = 4;
            this.btnEditPass.Text = "Reset password";
            this.btnEditPass.UseVisualStyleBackColor = true;
            this.btnEditPass.Click += new System.EventHandler(this.btnEditPass_Click);
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(14, 227);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(10, 13);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "-";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(366, 221);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(57, 24);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(302, 221);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(57, 24);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lv
            // 
            this.lv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv.CheckBoxes = true;
            this.lv.FullRowSelect = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(9, 19);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(523, 196);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 518);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pn);
            this.Controls.Add(this.statusStripLive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.frmConfigProvider_Load);
            this.statusStripLive.ResumeLayout(false);
            this.statusStripLive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ePX)).EndInit();
            this.pn.ResumeLayout(false);
            this.pn.PerformLayout();
            this.gbPass.ResumeLayout(false);
            this.gbPass.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.StatusStrip statusStripLive;
        private System.Windows.Forms.ToolStripStatusLabel lblstatus;
        private System.Windows.Forms.ToolStripProgressBar pbstatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider ePX;
        private System.ComponentModel.BackgroundWorker bgWLive;
        private System.Windows.Forms.ImageList imageListLiveSmall;
        private System.Windows.Forms.ImageList imageListLiveLarge;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Panel pn;
        private System.Windows.Forms.GroupBox gbPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eventSummaryToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Button btnEditPass;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListView lv;
    }
}