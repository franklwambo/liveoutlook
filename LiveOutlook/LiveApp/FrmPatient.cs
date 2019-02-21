using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LiveOutlook.LiveUIL.LiveCore;
using LiveOutlook.LiveUIL;


namespace LiveOutlook.LiveApp
{
    public partial class FrmPatient : Form
    {
        private static string PatientID = string.Empty;
        private static bool PatientOutcome = false;

        public FrmPatient()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " [v" + Application.ProductVersion + "]  | " + this.Text;
        }
        public FrmPatient(string pid)
        {
            PatientID = pid;
            InitializeComponent();
        }
        public FrmPatient(string pid,bool outcome)
        {
            PatientOutcome = outcome;
            PatientID = pid;
            InitializeComponent();

        }
        private static StringBuilder sb;
        private static EnrollmentInfo myE;
        private static ClassificationInfo myC;
        private static FacilityInfo myF;
        private static string err;
        private static string NULL = string.Empty;
        private static string strFcode = string.Empty;

        private static bool EditFlag = false;
        private static bool Proceed = true;

        private static bool SortAsc = true;
        private static int n;
        private static string strSearch = string.Empty;
        private static string strSearchReg = string.Empty;
        private static string strSearchName = string.Empty;

        private void Load500Enrollments()
        {
            LiveClear();
            myE = new EnrollmentInfo();
            myE.lvEnrollmentTop500(lvEnrollment);
            myE = null;

        }
        private void LoadAllEnrollments()
        {
            LiveClear();
            myE = new EnrollmentInfo();
            myE.lvEnrollment(lvEnrollment);
            myE = null;

        }

        private void LoadReferredTo()
        {
            myC = new ClassificationInfo();
            ClassificationInfo.AClass = "ReferredTo";
            myC.cmbClassification(cmbReferredTo);
            myC = null;
            
        }
        private void LoadReferredBy()
        {
            myC = new ClassificationInfo();
            ClassificationInfo.AClass = "ReferredBy";
            myC.cmbClassification(cmbReferredBy);
            myC = null;
        }
        private void LoadCategory()
        {
            myC = new ClassificationInfo();
            ClassificationInfo.AClass = "Category";
            myC.cmbClassification(cmbCategory);
            myC = null;
        }
        private void LoadOutcome()
        {
            myC = new ClassificationInfo();
            ClassificationInfo.AClass = "Outcome";
            myC.cmbClassification(cmbOutcome);
            myC = null;
        }
        private bool FormIsValid()
        {
            Proceed = true;
            sb = new StringBuilder("Please resolve the following to proceed\n");
            #region Groupbox
            foreach (Control b in this.Controls)
            {
                if (b is GroupBox)
                {
                    foreach (Control a in b.Controls)
                    {
                        #region Combobox
                        if ((a is ComboBox) && (a.CausesValidation))
                        {
                            ComboBox cntrl = (ComboBox)a;
                            if (cntrl.SelectedIndex == -1)
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
                        #region Dates
                        if ((a is DateTimePicker) && (a.CausesValidation))
                        {
                            DateTimePicker cntrl = (DateTimePicker)a;
                            if (!cntrl.Checked)
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
                        #region Numericupdown
                        if ((a is NumericUpDown) && (a.CausesValidation))
                        {
                            NumericUpDown cntrl = (NumericUpDown)a;
                            if (cntrl.Value.Equals(0))
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
            }
            #endregion
            #region Groupbox.Panel
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox && c.CausesValidation)
                {
                    foreach (Control b in c.Controls)
                    {
                        if ((b is Panel) && (b.CausesValidation))
                        {
                            bool radioOK = false;
                            bool rbExists = false;
                            foreach (Control a in b.Controls)
                            {
                                #region Numericupdown
                                if ((a is NumericUpDown) && (a.CausesValidation))
                                {
                                    NumericUpDown cntrl = (NumericUpDown)a;
                                    if (cntrl.Value.Equals(0))
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
                                #region Radiobuttons
                                if ((a is RadioButton) && (a.CausesValidation))
                                {
                                    rbExists = true;
                                    RadioButton cntrl = (RadioButton)a;
                                    if (cntrl.Checked)
                                    {
                                        radioOK = true;
                                    }
                                }
                                #endregion
                            }
                            #region Checkradiobuttons
                            if ((!radioOK) && (rbExists))
                            {
                                ePX.SetError(b, b.AccessibleDescription);
                                sb.Append("* " + ePX.GetError(b) + " !\n");
                                Proceed = false;
                            }
                            else
                            {
                                ePX.SetError(b, "");
                            }
                            #endregion
                        }
                    }
                }
            }
            #endregion
            err = sb.ToString();
            return Proceed;
        }
        private void Clean()
        {
            #region Groupbox
            foreach (Control b in this.Controls)
            {
                if (b is GroupBox)
                {
                    foreach (Control a in b.Controls)
                    {
                        ePX.SetError(a, "");
                    }
                }
            }
            #endregion
            #region Groupbox.Panel
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control b in c.Controls)
                    {
                        if ((b is Panel) && (b.CausesValidation))
                        {
                            foreach (Control a in b.Controls)
                            {
                                ePX.SetError(a, "");
                            }
                        }
                    }
                }
            }
            #endregion
        }
        private void LiveClear()
        {
            EditFlag = false;
            ClearControls();
            EnableControls(false);
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
        }
        private void LiveAdd()
        {
            ClearControls();
            EnableControls(true);
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            LoadDefaults();
        }
        private void LoadDefaults()
        {
            myF=new FacilityInfo();
            if (myF.ShowFacility() > 0)
            {
                strFcode = FacilityInfo.FCode;
                txtFacility.Text = FacilityInfo.FName;
            }
            else
            {
                LiveClear();
                Interactive.LInfoWarningOK("Facility informantion is required", "Facility Settings");
                FrmFacility f = new FrmFacility();
                f.ShowDialog();
            }
            
        }
        private void LiveEdit()
        {
            EditFlag = true;
            EnableControls(true);

            btnEdit.Enabled = false;

            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
        }
        private void LiveEdit(bool outcome)
        {
            EditFlag = true;
            EnableControls(true);

            btnEdit.Enabled = false;

            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
        }
        private void ClearControls()
        {
            #region Groupbox
            foreach (Control b in this.Controls)
            {
                if (b is GroupBox)
                {
                    foreach (Control a in b.Controls)
                    {
                        #region Combobox
                        if ((a is ComboBox) && (a.CausesValidation))
                        {
                            ComboBox cntrl = (ComboBox)a;
                            cntrl.SelectedIndex = -1;
                        }
                        #endregion
                        #region TextBox
                        if ((a is TextBox) && (a.CausesValidation))
                        {
                            TextBox cntrl = (TextBox)a;
                            cntrl.Clear();
                        }
                        #endregion
                        #region Dates
                        if ((a is DateTimePicker) && (a.CausesValidation))
                        {
                            DateTimePicker cntrl = (DateTimePicker)a;
                            cntrl.Checked=false;
                        }
                        #endregion
                        #region Numericupdown
                        if ((a is NumericUpDown) && (a.CausesValidation))
                        {
                            NumericUpDown cntrl = (NumericUpDown)a;
                            cntrl.ResetText();
                        }
                        #endregion
                    }
                }
            }
            #endregion
            #region Groupbox.Panel
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox && c.CausesValidation)
                {
                    foreach (Control b in c.Controls)
                    {
                        if ((b is Panel) && (b.CausesValidation))
                        {
                            foreach (Control a in b.Controls)
                            {
                                 #region Numericupdown
                        if ((a is NumericUpDown) && (a.CausesValidation))
                        {
                            NumericUpDown cntrl = (NumericUpDown)a;
                            cntrl.ResetText();
                        }
                        #endregion
                            }
                        }
                    }
                }
            }
            #endregion
        }
        private void EnableControls(bool status)
        {
            #region Groupbox
            foreach (Control b in this.Controls)
            {
                if (b is GroupBox)
                {
                    foreach (Control a in b.Controls)
                    {
                        #region Combobox
                        if (a is ComboBox)
                        {
                            ComboBox cntrl = (ComboBox)a;
                            cntrl.Enabled = status;
                        }
                        #endregion
                        #region TextBox
                        if (a is TextBox)
                        {
                            TextBox cntrl = (TextBox)a;
                            cntrl.Enabled = status;
                        }
                        #endregion
                        #region Dates
                        if (a is DateTimePicker)
                        {
                            DateTimePicker cntrl = (DateTimePicker)a;
                            cntrl.Enabled = status;
                        }
                        #endregion
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
            #region Groupbox.Panel
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control b in c.Controls)
                    {
                        if ((b is Panel) && (b.CausesValidation))
                        {
                            foreach (Control a in b.Controls)
                            {
                                #region Numericupdown
                                if (a is NumericUpDown && a.CausesValidation)
                                {
                                    NumericUpDown cntrl = (NumericUpDown)a;
                                    cntrl.Enabled = status;
                                }
                                #endregion
                            }
                        }
                    }
                }
            }
            #endregion
            txtSearchReg.Enabled = !status;
            txtSearchName.Enabled = !status;
        }
        private void SaveInfo()
        {

            if (FormIsValid())
            {
                myE = new EnrollmentInfo();
                EnrollmentInfo.RegNo = txtRegNo.Text;
                EnrollmentInfo.Names = txtName.Text;
                EnrollmentInfo.Age = Convert.ToInt32(txtAge.Value);
                EnrollmentInfo.AgeUnit = rbYr.Checked ? "Y" : "m";
                EnrollmentInfo.Sex = rbM.Checked ? "M" : "F";
                EnrollmentInfo.RegDate = dtpRegDate.Value;
                EnrollmentInfo.Residence = txtResidence.Text;
                
                try { EnrollmentInfo.ReferredBy = cmbReferredBy.SelectedValue.ToString(); }
                catch { };
                try { EnrollmentInfo.ReferredTo = cmbReferredTo.SelectedValue.ToString(); }
                catch { };

                EnrollmentInfo.Fcode = strFcode;
                
                try { EnrollmentInfo.Category = cmbCategory.SelectedValue.ToString(); }
                catch { };
                EnrollmentInfo.ContactInfo = txtContact.Text;
                try { EnrollmentInfo.Outcome = cmbOutcome.SelectedValue.ToString(); }
                catch { };
                if (EditFlag)
                {
                    EnrollmentInfo.RegNo = lblRegNo.Text;
                    EnrollmentInfo.NewRegNo = txtRegNo.Text;
                    if ((Interactive.LInfoConfirm("Are you sure you want to Edit ?", "Enrollment") == DialogResult.Yes))
                    {
                        if (myE.EditEnrollment())
                        {
                            Load500Enrollments();
                        }
                    }
                }
                else
                {
                    if (myE.NewEnrollment())
                    {
                        Load500Enrollments();
                    }
                }
            }
            else
            {
                Interactive.LInfoError(err, "Enrollment");
            }
        }
        private void DeleteInfo()
        {
            if ((Interactive.LInfoWarning("Are you sure you want to Delete ?", "Enrollment") == DialogResult.Yes))
            {
                myE = new EnrollmentInfo();
                EnrollmentInfo.RegNo = lblRegNo.Text.Trim();
                if (myE.RemoveEnrollment())
                {
                    Load500Enrollments();
                }
                return;
            }
        }
        private void Display()
        {
            LoadDefaults();
            EnrollmentInfo.RegNo= txtRegNo.Text= lblRegNo.Text = lvEnrollment.SelectedItems[0].Text;
            txtName.Text = lvEnrollment.SelectedItems[0].SubItems[1].Text;
            DisplayAgeUnit(lvEnrollment.SelectedItems[0].SubItems[3].Text);
            txtAge.Value = Convert.ToDecimal(lvEnrollment.SelectedItems[0].SubItems[2].Text);
            DisplaySex(lvEnrollment.SelectedItems[0].SubItems[4].Text);
            dtpRegDate.Value = Convert.ToDateTime(lvEnrollment.SelectedItems[0].SubItems[5].Text);
            dtpRegDate.Checked = true;
            EnrollmentInfo En = new EnrollmentInfo();
            En.ShowEnrollment();
            cmbReferredBy.SelectedValue = EnrollmentInfo.ReferredBy;
            cmbReferredTo.SelectedValue = EnrollmentInfo.ReferredTo;
            cmbOutcome.SelectedValue = EnrollmentInfo.Outcome;
            txtResidence.Text = EnrollmentInfo.Residence;
            txtContact.Text = EnrollmentInfo.ContactInfo;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true ;
        }
        private void DontDisplay()
        {
            ClearControls();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            lblRegNo.Text= string.Empty;
        }
        private void DisplaySex(string p)
        {
            switch (p)
            {
                case "M":
                    rbM.Checked = true;
                    break;
                case "F":
                    rbF.Checked = true;
                    break;
            }
        }
        private void DisplayAgeUnit(string p)
        {
            switch (p)
            {
                case "Y":
                    rbYr.Checked = true;
                    break;
                case "m":
                    rbMn.Checked = true;
                    break;
            }
        }
        private void Search()
        {
            this.Cursor = Cursors.WaitCursor;
            strSearch = " (RegNo <> '') ";
            strSearchReg = string.Empty;
            strSearchName = string.Empty;
            if (txtSearchReg.Text.Length > 0)
            {
                strSearchReg = "AND (RegNo Like '%" + txtSearchReg.Text.Trim() + "%')";
            
            }
            else
            {
                strSearchReg = string.Empty;
            }
            if (txtSearchName.Text.Length > 0)
            {
                strSearchName = "AND (Names Like '%" + txtSearchName.Text.Trim() + "%') ";
            }
            else
            {
                strSearchName = string.Empty;
            }

            myE = new EnrollmentInfo(); 
            
            try
            {
                strSearch += strSearchReg + strSearchName;
                myE.lvEnrollmentSearch(lvEnrollment, strSearch);
            }
            catch
            { }
            myE = null;
            this.Cursor = Cursors.Default;
        }

        private void FrmPatient_Load(object sender, EventArgs e)
        {
            LoadReferredBy();
            LoadReferredTo();
            LoadCategory();
            LoadOutcome();
            if (PatientID.Trim().Length > 0)
            {
                txtSearchReg.Text = PatientID;
                Search();
                try
                {
                    lvEnrollment.Items[0].Selected = true;
                    LiveEdit();

                }
                catch { }
            }
            else
            {
                Load500Enrollments();
            }
          
            SetLabels();
       }
        private void SetLabels()
        {
            myE=new EnrollmentInfo();
            lblNumerator.Text = lvEnrollment.Items.Count.ToString();
            lblDenominator.Text = myE.GetAll().ToString();
        }
        private void FrmPatient_FormClosing(object sender, FormClosingEventArgs e)
        {
        
        }
        private void FrmPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void lvEnrollment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (lvEnrollment.SelectedItems.Count > 0)
            {
                Display();
            }
            else
            {
                DontDisplay();
            }
            this.Cursor = Cursors.Default;

        }

        private void lvEnrollment_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Search();
            myE = new EnrollmentInfo();
            switch (e.Column)
            {
                case 0:
                    if (SortAsc)
                    {
                        myE.lvEnrollmentSearchSort(lvEnrollment, strSearch, "RegNo", "ASC");
                        SortAsc = false;
                    }
                    else
                    {
                        myE.lvEnrollmentSearchSort(lvEnrollment, strSearch, "RegNo", "DESC");
                        SortAsc = true;
                    }
                    break;
                case 1:
                    if (SortAsc)
                    {
                        myE.lvEnrollmentSearchSort(lvEnrollment, strSearch, "Names", "ASC");
                        SortAsc = false;
                    }
                    else
                    {
                        myE.lvEnrollmentSearchSort(lvEnrollment, strSearch, "Names", "DESC");
                        SortAsc = true;
                    }
                    break;
                case 2:
                    if (SortAsc)
                    {
                        myE.lvEnrollmentSearchSort(lvEnrollment, strSearch, "Age", "ASC");
                        SortAsc = false;
                    }
                    else
                    {
                        myE.lvEnrollmentSearchSort(lvEnrollment, strSearch, "Age", "DESC");
                        SortAsc = true;
                    }
                    break;
                case 3:
                    if (SortAsc)
                    {
                        myE.lvEnrollmentSearchSort(lvEnrollment, strSearch, "AgeUnit", "ASC");
                        SortAsc = false;
                    }
                    else
                    {
                        myE.lvEnrollmentSearchSort(lvEnrollment, strSearch, "AgeUnit", "DESC");
                        SortAsc = true;
                    }
                    break;
                case 4:
                    if (SortAsc)
                    {
                        myE.lvEnrollmentSearchSort(lvEnrollment, strSearch, "Sex", "ASC");
                        SortAsc = false;
                    }
                    else
                    {
                        myE.lvEnrollmentSearchSort(lvEnrollment, strSearch, "Sex", "DESC");
                        SortAsc = true;
                    }
                    break;
                case 5:
                    if (SortAsc)
                    {
                        myE.lvEnrollmentSearchSort(lvEnrollment, strSearch, "RegDate", "ASC");
                        SortAsc = false;
                    }
                    else
                    {
                        myE.lvEnrollmentSearchSort(lvEnrollment, strSearch, "RegDate", "DESC");
                        SortAsc = true;
                    }
                    break;
            }
            myE = null;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            LoadDefaults();
            LiveAdd();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            LiveEdit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteInfo();
            SetLabels();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveInfo();
            SetLabels();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LiveClear();
        }

        private void rbMn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMn.Checked)
            {
                txtAge.Maximum = 12;
            }
            else
            {
                txtAge.Maximum = 150;
            }


        }

        private void txtSearchReg_TextChanged(object sender, EventArgs e)
        {
            //Search();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            //Search();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtSearchName.Clear();
            txtSearchReg.Clear();
            Load500Enrollments();
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void lnkViewAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadAllEnrollments();
            SetLabels();
        }

        private void lnkTop500_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Load500Enrollments();
            SetLabels();
        }

        private void gbPatient_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
        
    }
}