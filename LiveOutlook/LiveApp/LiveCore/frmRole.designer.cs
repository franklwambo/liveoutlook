namespace LiveOutlook.LiveAPP.LiveCore
{
    partial class frmRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRole));
            this.label3 = new System.Windows.Forms.Label();
            this.txtRoleID = new System.Windows.Forms.TextBox();
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
            this.pn = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gb = new System.Windows.Forms.GroupBox();
            this.lblID = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lv = new System.Windows.Forms.ListView();
            this.statusStripLive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ePX)).BeginInit();
            this.pn.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "RoleID";
            // 
            // txtRoleID
            // 
            this.txtRoleID.AccessibleDescription = "Role";
            this.txtRoleID.Location = new System.Drawing.Point(80, 7);
            this.txtRoleID.Name = "txtRoleID";
            this.txtRoleID.Size = new System.Drawing.Size(282, 20);
            this.txtRoleID.TabIndex = 6;
            // 
            // statusStripLive
            // 
            this.statusStripLive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblstatus,
            this.pbstatus});
            this.statusStripLive.Location = new System.Drawing.Point(0, 369);
            this.statusStripLive.Name = "statusStripLive";
            this.statusStripLive.Size = new System.Drawing.Size(544, 22);
            this.statusStripLive.TabIndex = 7;
            this.statusStripLive.Text = "statusStrip1";
            // 
            // lblstatus
            // 
            this.lblstatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(427, 17);
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
            this.btnSave.Location = new System.Drawing.Point(142, 103);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 24);
            this.btnSave.TabIndex = 9;
            this.btnSave.Tag = "S";
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(80, 103);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(57, 24);
            this.btnNew.TabIndex = 8;
            this.btnNew.Tag = "N";
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(205, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 24);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Tag = "C";
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
            // pn
            // 
            this.pn.Controls.Add(this.txtDescription);
            this.pn.Controls.Add(this.label1);
            this.pn.Controls.Add(this.txtRoleID);
            this.pn.Controls.Add(this.btnCancel);
            this.pn.Controls.Add(this.label3);
            this.pn.Controls.Add(this.btnSave);
            this.pn.Controls.Add(this.btnNew);
            this.pn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn.Location = new System.Drawing.Point(0, 236);
            this.pn.Name = "pn";
            this.pn.Size = new System.Drawing.Size(544, 133);
            this.pn.TabIndex = 11;
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleDescription = "Description";
            this.txtDescription.Location = new System.Drawing.Point(80, 32);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(282, 65);
            this.txtDescription.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Description";
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
            this.panel1.Size = new System.Drawing.Size(544, 49);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::LiveOutlook.Properties.Resources.LiveLogo;
            this.pictureBox1.Location = new System.Drawing.Point(487, 0);
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
            this.label7.Size = new System.Drawing.Size(253, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Add,edit accounts and reset user password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Manage system users";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lblID);
            this.gb.Controls.Add(this.btnDelete);
            this.gb.Controls.Add(this.btnEdit);
            this.gb.Controls.Add(this.lv);
            this.gb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb.Location = new System.Drawing.Point(0, 49);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(544, 187);
            this.gb.TabIndex = 16;
            this.gb.TabStop = false;
            this.gb.Text = "Role Information";
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(18, 155);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(10, 13);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "-";
            this.lblID.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(474, 154);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(57, 24);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "D";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(412, 154);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(57, 24);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "E";
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
            this.lv.Size = new System.Drawing.Size(523, 129);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            // 
            // frmRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 391);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pn);
            this.Controls.Add(this.statusStripLive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Role";
            this.Load += new System.EventHandler(this.frmConfigProvider_Load);
            this.statusStripLive.ResumeLayout(false);
            this.statusStripLive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ePX)).EndInit();
            this.pn.ResumeLayout(false);
            this.pn.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRoleID;
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
        private System.Windows.Forms.Panel pn;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListView lv;
    }
}