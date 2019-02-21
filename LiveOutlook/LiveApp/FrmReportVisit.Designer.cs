namespace LiveOutlook.LiveApp
{
    partial class FrmReportVisit
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "M",
            "Male"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "F",
            "Female"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "9",
            "Missing"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportVisit));
            this.statusStripLive = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.spltLiveReport = new System.Windows.Forms.SplitContainer();
            this.LiveReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lvAppointment = new System.Windows.Forms.ListView();
            this.columnHeaderAppointment = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderCriteria = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.nudStartAge = new System.Windows.Forms.NumericUpDown();
            this.lvSex = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.nudEndAge = new System.Windows.Forms.NumericUpDown();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkAge = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lvART = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.lvRefTo = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lvRefBy = new System.Windows.Forms.ListView();
            this.columnHeaderRefBy = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.bgWLive = new System.ComponentModel.BackgroundWorker();
            this.lvState = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.statusStripLive.SuspendLayout();
            this.spltLiveReport.Panel1.SuspendLayout();
            this.spltLiveReport.Panel2.SuspendLayout();
            this.spltLiveReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndAge)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStripLive
            // 
            this.statusStripLive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.pbStatus});
            this.statusStripLive.Location = new System.Drawing.Point(0, 692);
            this.statusStripLive.Name = "statusStripLive";
            this.statusStripLive.Size = new System.Drawing.Size(992, 22);
            this.statusStripLive.TabIndex = 0;
            this.statusStripLive.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(775, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbStatus
            // 
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(200, 16);
            // 
            // spltLiveReport
            // 
            this.spltLiveReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltLiveReport.Location = new System.Drawing.Point(0, 0);
            this.spltLiveReport.Name = "spltLiveReport";
            this.spltLiveReport.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltLiveReport.Panel1
            // 
            this.spltLiveReport.Panel1.Controls.Add(this.LiveReportViewer);
            // 
            // spltLiveReport.Panel2
            // 
            this.spltLiveReport.Panel2.BackColor = System.Drawing.Color.LightYellow;
            this.spltLiveReport.Panel2.Controls.Add(this.lvState);
            this.spltLiveReport.Panel2.Controls.Add(this.lvAppointment);
            this.spltLiveReport.Panel2.Controls.Add(this.label3);
            this.spltLiveReport.Panel2.Controls.Add(this.nudStartAge);
            this.spltLiveReport.Panel2.Controls.Add(this.lvSex);
            this.spltLiveReport.Panel2.Controls.Add(this.nudEndAge);
            this.spltLiveReport.Panel2.Controls.Add(this.btnRefresh);
            this.spltLiveReport.Panel2.Controls.Add(this.chkAge);
            this.spltLiveReport.Panel2.Controls.Add(this.btnGenerate);
            this.spltLiveReport.Panel2.Controls.Add(this.lvART);
            this.spltLiveReport.Panel2.Controls.Add(this.lvRefTo);
            this.spltLiveReport.Panel2.Controls.Add(this.lvRefBy);
            this.spltLiveReport.Panel2.Controls.Add(this.label2);
            this.spltLiveReport.Panel2.Controls.Add(this.label1);
            this.spltLiveReport.Panel2.Controls.Add(this.dtpEnd);
            this.spltLiveReport.Panel2.Controls.Add(this.dtpStart);
            this.spltLiveReport.Panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spltLiveReport.Size = new System.Drawing.Size(992, 692);
            this.spltLiveReport.SplitterDistance = 567;
            this.spltLiveReport.TabIndex = 1;
            // 
            // LiveReportViewer
            // 
            this.LiveReportViewer.ActiveViewIndex = -1;
            this.LiveReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LiveReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LiveReportViewer.Location = new System.Drawing.Point(0, 0);
            this.LiveReportViewer.Name = "LiveReportViewer";
            this.LiveReportViewer.SelectionFormula = "";
            this.LiveReportViewer.Size = new System.Drawing.Size(992, 567);
            this.LiveReportViewer.TabIndex = 0;
            this.LiveReportViewer.ViewTimeSelectionFormula = "";
            // 
            // lvAppointment
            // 
            this.lvAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvAppointment.CheckBoxes = true;
            this.lvAppointment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAppointment,
            this.columnHeaderCriteria});
            this.lvAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAppointment.Location = new System.Drawing.Point(775, 6);
            this.lvAppointment.Name = "lvAppointment";
            this.lvAppointment.Size = new System.Drawing.Size(166, 109);
            this.lvAppointment.TabIndex = 18;
            this.lvAppointment.UseCompatibleStateImageBehavior = false;
            this.lvAppointment.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderAppointment
            // 
            this.columnHeaderAppointment.Text = "Appointmnent";
            this.columnHeaderAppointment.Width = 197;
            // 
            // columnHeaderCriteria
            // 
            this.columnHeaderCriteria.Text = "Criteria";
            this.columnHeaderCriteria.Width = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "_";
            // 
            // nudStartAge
            // 
            this.nudStartAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudStartAge.Location = new System.Drawing.Point(209, 95);
            this.nudStartAge.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudStartAge.Name = "nudStartAge";
            this.nudStartAge.Size = new System.Drawing.Size(45, 18);
            this.nudStartAge.TabIndex = 14;
            // 
            // lvSex
            // 
            this.lvSex.CheckBoxes = true;
            this.lvSex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lvSex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            this.lvSex.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.lvSex.Location = new System.Drawing.Point(141, 6);
            this.lvSex.Name = "lvSex";
            this.lvSex.Size = new System.Drawing.Size(87, 78);
            this.lvSex.TabIndex = 9;
            this.lvSex.UseCompatibleStateImageBehavior = false;
            this.lvSex.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 34;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Sex";
            this.columnHeader6.Width = 49;
            // 
            // nudEndAge
            // 
            this.nudEndAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudEndAge.Location = new System.Drawing.Point(271, 95);
            this.nudEndAge.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudEndAge.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEndAge.Name = "nudEndAge";
            this.nudEndAge.Size = new System.Drawing.Size(45, 18);
            this.nudEndAge.TabIndex = 15;
            this.nudEndAge.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(71, 91);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(61, 24);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // chkAge
            // 
            this.chkAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAge.AutoSize = true;
            this.chkAge.Location = new System.Drawing.Point(139, 96);
            this.chkAge.Name = "chkAge";
            this.chkAge.Size = new System.Drawing.Size(62, 16);
            this.chkAge.TabIndex = 16;
            this.chkAge.Text = "Age (yrs)";
            this.chkAge.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(4, 91);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(63, 24);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lvART
            // 
            this.lvART.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvART.CheckBoxes = true;
            this.lvART.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.lvART.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvART.Location = new System.Drawing.Point(234, 6);
            this.lvART.Name = "lvART";
            this.lvART.Size = new System.Drawing.Size(85, 78);
            this.lvART.TabIndex = 6;
            this.lvART.UseCompatibleStateImageBehavior = false;
            this.lvART.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ART";
            this.columnHeader4.Width = 105;
            // 
            // lvRefTo
            // 
            this.lvRefTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvRefTo.CheckBoxes = true;
            this.lvRefTo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvRefTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvRefTo.Location = new System.Drawing.Point(618, 6);
            this.lvRefTo.Name = "lvRefTo";
            this.lvRefTo.Size = new System.Drawing.Size(152, 110);
            this.lvRefTo.TabIndex = 5;
            this.lvRefTo.UseCompatibleStateImageBehavior = false;
            this.lvRefTo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Referred To";
            this.columnHeader2.Width = 210;
            // 
            // lvRefBy
            // 
            this.lvRefBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvRefBy.CheckBoxes = true;
            this.lvRefBy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRefBy});
            this.lvRefBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvRefBy.Location = new System.Drawing.Point(475, 6);
            this.lvRefBy.Name = "lvRefBy";
            this.lvRefBy.Size = new System.Drawing.Size(137, 110);
            this.lvRefBy.TabIndex = 4;
            this.lvRefBy.UseCompatibleStateImageBehavior = false;
            this.lvRefBy.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderRefBy
            // 
            this.columnHeaderRefBy.Text = "Referred By";
            this.columnHeaderRefBy.Width = 169;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ending";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Starting";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Checked = false;
            this.dtpEnd.CustomFormat = "dd MMM yyyy";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(42, 29);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowCheckBox = true;
            this.dtpEnd.Size = new System.Drawing.Size(90, 18);
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.Checked = false;
            this.dtpStart.CustomFormat = "dd MMM yyyy";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(42, 7);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowCheckBox = true;
            this.dtpStart.Size = new System.Drawing.Size(90, 18);
            this.dtpStart.TabIndex = 0;
            // 
            // bgWLive
            // 
            this.bgWLive.WorkerReportsProgress = true;
            this.bgWLive.WorkerSupportsCancellation = true;
            this.bgWLive.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWLive_DoWork);
            this.bgWLive.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWLive_RunWorkerCompleted);
            this.bgWLive.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWLive_ProgressChanged);
            // 
            // lvState
            // 
            this.lvState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvState.CheckBoxes = true;
            this.lvState.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvState.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvState.Location = new System.Drawing.Point(329, 5);
            this.lvState.Name = "lvState";
            this.lvState.Size = new System.Drawing.Size(137, 110);
            this.lvState.TabIndex = 19;
            this.lvState.UseCompatibleStateImageBehavior = false;
            this.lvState.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Current State";
            this.columnHeader1.Width = 169;
            // 
            // FrmReportVisit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 714);
            this.Controls.Add(this.spltLiveReport);
            this.Controls.Add(this.statusStripLive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportVisit";
            this.Text = ":. Reports";
            this.Load += new System.EventHandler(this.FrmReportVisit_Load);
            this.statusStripLive.ResumeLayout(false);
            this.statusStripLive.PerformLayout();
            this.spltLiveReport.Panel1.ResumeLayout(false);
            this.spltLiveReport.Panel2.ResumeLayout(false);
            this.spltLiveReport.Panel2.PerformLayout();
            this.spltLiveReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudStartAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripLive;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar pbStatus;
        private System.Windows.Forms.SplitContainer spltLiveReport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer LiveReportViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.ListView lvRefBy;
        private System.Windows.Forms.ColumnHeader columnHeaderRefBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvRefTo;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvART;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ListView lvSex;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.NumericUpDown nudEndAge;
        private System.Windows.Forms.NumericUpDown nudStartAge;
        public System.ComponentModel.BackgroundWorker bgWLive;
        private System.Windows.Forms.CheckBox chkAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvAppointment;
        private System.Windows.Forms.ColumnHeader columnHeaderAppointment;
        private System.Windows.Forms.ColumnHeader columnHeaderCriteria;
        private System.Windows.Forms.ListView lvState;
        private System.Windows.Forms.ColumnHeader columnHeader1;


    }
}