using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LiveOutlook.LiveUIL;
using LiveOutlook.LiveUIL.LiveCore;

namespace LiveOutlook.LiveApp
{
    public partial class FrmAppointment : Form
    {
        public FrmAppointment()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " [v" + Application.ProductVersion + "]  | " + this.Text;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
        }

        private static StringBuilder sb;
        private static SettingsInfo WorkingDay;
        private static PublicHolidayInfo PublicHolidayDay;
        private static ReserveInfo ReserveDay;
        private static AppointmentInfo myA;
        private static EnrollmentInfo myE;
        private static ClassificationInfo myC;
        private static string err;
        private static string NULL = string.Empty;
        private static string strFcode = string.Empty;
        private static Bitmap DYes = LiveOutlook.Properties.Resources.ok;
        private static Bitmap DNo = LiveOutlook.Properties.Resources.no;

        private static bool EditFlag = false;
        private static bool CheckTheDate = false;
        private static bool Proceed = true;
        private static bool ProceedWithNoTCA = true;
        private static bool ProceedP = false;
        private static bool ProceedR = false;
        private static bool ProceedW = false;

        private static bool SortAsc = true;
        private static int n;
        private static string strSearch = string.Empty;
        private static string strSearchO = string.Empty;
        private static string strSearchPeriod = string.Empty;
        private static DateTime SearchDate;
        private static string strSearchReg = string.Empty;
        private static string strSearchName = string.Empty;
        private static string strOSearchReg = string.Empty;
        private static string strOSearchName = string.Empty;
        private static DateTime MinAppointmentdate;
        private static DateTime MinVisitDate;
        
        private void LoadEnrollment()
        {
            LiveClear();
            myE = new EnrollmentInfo();
            myE.lvEnrollmentMin(lvEnrollment);
            myE = null;
        }
        private void LoadAppointments()
        {
            myA = new AppointmentInfo();
            myA.lvAppointmentAll(lvOApp);
            myA = null;
        }
        private void LoadHistory()
        {
            if (lvEnrollment.SelectedItems.Count > 0)
            {
                AppointmentInfo.RegNo = lblReg.Text = lvEnrollment.SelectedItems[0].Text;
                myA = new AppointmentInfo();
                myA.lvAppointmentByReg(lvAppointments);
                myA = null;
            }
        }
        private void LoadSeenBy()
        {
            //myA = new  AppointmentInfo();
            //myA.cmbSeenBy(cmbSeenby);
            //myA = null;
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
                            if (cntrl.Text.Trim().Length== 0)
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
                                #region Dates
                                if (a.Name == dtpAvialDate.Name)
                                {
                                    DateTimePicker cntrl = (DateTimePicker)a;
                                    if (!cntrl.Checked)
                                    {
                                        ProceedWithNoTCA = true;
                                    }
                                    else
                                    {
                                        ProceedWithNoTCA = false;
                                    }
                                }
                                else
                                {
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
                                }
                                #endregion
                                //#region Numericupdown
                                //if ((a is NumericUpDown) && (a.CausesValidation))
                                //{
                                //    NumericUpDown cntrl = (NumericUpDown)a;
                                //    if (cntrl.Value.Equals(0))
                                //    {
                                //        ePX.SetError(cntrl, cntrl.AccessibleDescription);
                                //        sb.Append("* " + ePX.GetError(cntrl) + " !\n");
                                //        Proceed = false;
                                //    }
                                //    else
                                //    {
                                //        ePX.SetError(cntrl, "");
                                //    }
                                //}
                                //#endregion
                                //#region Radiobuttons
                                //if ((a is RadioButton) && (a.CausesValidation))
                                //{
                                //    rbExists = true;
                                //    RadioButton cntrl = (RadioButton)a;
                                //    if (cntrl.Checked)
                                //    {
                                //        radioOK = true;
                                //    }
                                //}
                                //#endregion
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
            if (lblReg.Text.Trim().Length ==0)
            {
                ePX.SetError(lblReg, lblReg.AccessibleDescription);
                sb.Append("* " + ePX.GetError(lblReg) + " !\n");
                Proceed = false;

            }
            else
            {
                ePX.SetError(lblReg, "");
            }
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
            if (lblReg.Text.Trim().Length == 0)
            {
                Interactive.LInfo("Select Patient from list first", "No Patient Selected");
                return;
            }
            ClearControls();
            EnableControls(true);
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            if (lvAppointments.Items.Count > 0)
            {
               //dtpAvialDate.MinDate = MinAppointmentdate = Convert.ToDateTime(lvAppointments.Items[0].Text);
               //dtpVisitDate.MinDate = MinVisitDate = Convert.ToDateTime(lvAppointments.Items[0].SubItems[1].Text);
            }
            dtpVisitDate.Checked = true;
        }
        private void LiveEdit()
        {
            EditFlag = true;
            EnableControls(true);

            btnEdit.Enabled = false;

            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            /*
            dtpAvialDate.MinDate = MinAppointmentdate = Convert.ToDateTime("1/1/1900");
            dtpVisitDate.MinDate = MinVisitDate = Convert.ToDateTime("1/1/1900");
             */
            dtpVisitDate.Checked = true;
        }
        private void ClearControls()
        {
            
            #region Groupbox
            foreach (Control b in this.Controls)
            {
                if (b is GroupBox )
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
                        #region Dates
                        if ((a is DateTimePicker) && (a.CausesValidation))
                        {
                            DateTimePicker cntrl = (DateTimePicker)a;
                            cntrl.Checked = false;
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
                                #region RadioButtons
                                if ((a is RadioButton) && (a.CausesValidation))
                                {
                                    RadioButton cntrl = (RadioButton)a;
                                    cntrl.Checked = false;
                                }
                                 #endregion
                                #region Dates
                                if ((a is DateTimePicker) && (a.CausesValidation))
                                {
                                    DateTimePicker cntrl = (DateTimePicker)a;
                                    cntrl.Checked = false;
                                    try { cntrl.Value = DateTime.Now; }
                                    catch { }
                                }
                                #endregion
                                #region Label
                                if ((a is Label) && (!a.CausesValidation))
                                {
                                    Label cntrl = (Label)a;
                                    cntrl.Text = string.Empty;
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
                        if (a is ComboBox && a.CausesValidation)
                        {
                            ComboBox cntrl = (ComboBox)a;
                            cntrl.Enabled = status;
                        }
                        #endregion
                        #region TextBox
                        if (a is TextBox && a.CausesValidation)
                        {
                            TextBox cntrl = (TextBox)a;
                            cntrl.Enabled = status;
                        }
                        #endregion
                        #region Dates
                        if (a is DateTimePicker && a.CausesValidation)
                        {
                            DateTimePicker cntrl = (DateTimePicker)a;
                            cntrl.Enabled = status;
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
                                #region Dates
                                if (a is DateTimePicker && a.CausesValidation)
                                {
                                    DateTimePicker cntrl = (DateTimePicker)a;
                                    cntrl.Enabled = status;
                                }
                                #endregion
                                #region Listview
                                if (a is ListView && a.CausesValidation)
                                {
                                    ListView cntrl = (ListView)a;
                                    cntrl.Enabled = !status;
                                }
                                #endregion
                            }
                        }
                    }
                }
            }
            #endregion
            txtSearchReg.Enabled= !status;
            txtSearchName.Enabled = !status;
        }
        private void SaveInfo()
        {
            if (FormIsValid())
            {
                myA = new AppointmentInfo();
                AppointmentInfo.AppointmentID = Convert.ToInt64(lblAppointmentID.Text.Trim());
                AppointmentInfo.RegNo = lblReg.Text;
                AppointmentInfo.Period = Convert.ToInt32(txtPeriod.Value);
                AppointmentInfo.PeriodName = GetPeriodName();
                //AppointmentInfo.SeenBy = cmbSeenby.Text;
                AppointmentInfo.VisitDate = dtpVisitDate.Value;
                AppointmentInfo.Appointment = ProceedWithNoTCA == true ? Convert.ToDateTime("01JAN1900") : dtpAvialDate.Value;
                if (EditFlag)
                {
                    /*
                    if (lvAppointments.Items.Count > 0)
                    {
                        AppointmentInfo.Appointment = Convert.ToDateTime(lvAppointments.SelectedItems[0].Text);
                        AppointmentInfo.ReturnDate = AppointmentInfo.VisitDate;
                        myA.UpdateReturnVisit();
                    }

                    AppointmentInfo.RegNo = AppointmentInfo.NewRegNo = lblReg.Text;
                    AppointmentInfo.Appointment = Convert.ToDateTime(lblAppointment.Text);
                    AppointmentInfo.NewAppointmentT = dtpAvialDate.Value;
                    */
                    if ((Interactive.LInfoConfirm("Are you sure you want to Edit ?", "Appointment") == DialogResult.Yes))
                    {
                        if (myA.EditAppointment())
                        {
                            //LoadAppointments();
                            LoadHistory();
                            LiveClear();
                        }
                    }
                }
                    
                else
                {

                    if (myA.NewAppointment())
                    {
                        if (lvAppointments.Items.Count > 0)
                        {
                            AppointmentInfo.AppointmentID = Convert.ToInt64(lvAppointments.Items[0].SubItems[7].Text);
                            AppointmentInfo.ReturnDate = AppointmentInfo.VisitDate;
                            myA.UpdateReturnVisit();
                        }
                        
                 
                        //LoadAppointments();
                        LoadHistory();
                        LiveClear();
                    }
                }
            }
            else
            {
                Interactive.LInfoError(err, "Appointment");
            }
        }
        private void DeleteInfo()
        {
            if ((Interactive.LInfoWarning("Are you sure you want to Delete ?", "Appointment") == DialogResult.Yes))
            {
                myA = new AppointmentInfo();
                AppointmentInfo.AppointmentID = Convert.ToInt64(lblAppointmentID.Text);
                if (myA.RemoveAppointment())
                {
                    LoadHistory();
                    LiveClear();
                    
                }
                return;
            }
        }
        private string GetPeriodName()
        {
            string str = String.Empty;

            foreach (Control a in pnApp.Controls)
            {
                if ((a is RadioButton) && (a.CausesValidation))
                {
                    RadioButton cntrl = (RadioButton)a;
                    if (cntrl.Checked)
                    {
                        str = cntrl.AccessibleDescription.Trim();
                    }
                }
            }
            return str;
        }
        private void Display()
        {
            AppointmentInfo.RegNo =lblReg.Text=lvEnrollment.SelectedItems[0].Text;
            lblname.Text = lvEnrollment.SelectedItems[0].SubItems[1].Text;
            lblAge.Text = lvEnrollment.SelectedItems[0].SubItems[2].Text;
            lblAgeunit.Text = lvEnrollment.SelectedItems[0].SubItems[3].Text;
            lblSex.Text =lvEnrollment.SelectedItems[0].SubItems[4].Text;
            myA = new AppointmentInfo();
            myA.lvAppointmentByReg(lvAppointments);
            //myA = null;
            lblHistory.Text = "{"+lblReg.Text +"} "+ lblname.Text;
            if (lvAppointments.Items.Count > 0)
            {
                btnPrintHistory.Enabled = true;
            }
            else
            {
                btnPrintHistory.Enabled = false;
            }
        }
        private void DontDisplay()
        {
            lblReg.Text = string.Empty;
            lblSex.Text= lblAge.Text = lblAgeunit.Text = lblname.Text = string.Empty;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnPrintHistory.Enabled = false;
        }
        private void DisplayHistory()
        {
            lblAppointmentID.Text = lvAppointments.SelectedItems[0].SubItems[7].Text;
            lblA.Text= lblAppointment.Text = lvAppointments.SelectedItems[0].Text;
            dtpVisitDate.Value = Convert.ToDateTime(lvAppointments.SelectedItems[0].SubItems[1].Text);
           // cmbSeenby.Text =lvAppointments.SelectedItems[0].SubItems[1].Text;
            ShowPeriod(lvAppointments.SelectedItems[0].SubItems[4].Text);
            dtpAvialDate.Value = Convert.ToDateTime(lvAppointments.SelectedItems[0].Text);
            dtpAvialDate.Checked = dtpAvialDate.Value < Convert.ToDateTime("01 JAN 1902") ? false : true;

            //MessageBox.Show(lvAppointments.SelectedItems[0].SubItems[3].Text + " -" + lvAppointments.SelectedItems[0].SubItems[4].Text);
            txtPeriod.Value = Convert.ToDecimal(lvAppointments.SelectedItems[0].SubItems[3].Text);
           
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }
        private void DontDisplayHistory()
        {
            lblAppointment.Text = string.Empty;
            //dtpVisitDate.Value = DateTime.Now;
           // cmbSeenby.Text = string.Empty;
            //txtPeriod.ResetText();
            //ClearPeriod();
            //dtpAvialDate.Value = DateTime.Now;
            lblAppointmentID.Text = "-1";
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            
        }
        private void ClearPeriod()
        {
            foreach (Control a in pnApp.Controls)
            {
                #region RadioButtons
                if ((a is RadioButton) && (a.CausesValidation))
                {
                    RadioButton cntrl = (RadioButton)a;
                    cntrl.Checked = false;
                }
                #endregion
            }
        }
        private void ShowPeriod(string str)
        {
            foreach (Control a in pnApp.Controls)
            {
                if ((a is RadioButton) && (a.CausesValidation))
                {
                    RadioButton cntrl = (RadioButton)a;
                    if (cntrl.AccessibleDescription.Equals(str))
                    {
                        cntrl.Checked = true;
                    }
                }
            }
        }
        private void SearchEnrollment()
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

            myE = new  EnrollmentInfo();
            try
            {
                strSearch += strSearchReg + strSearchName;
                myE.lvEnrollmentMinSearch(lvEnrollment, strSearch);
            }
            catch
            { }
            myE = null;
            this.Cursor = Cursors.Default;
        }
        private void SearchAppointments()
        {
            this.Cursor = Cursors.WaitCursor;
            strSearchO = " (RegNo <> '') "; 
            strSearchPeriod = string.Empty;
            strOSearchReg = string.Empty;
            strOSearchName = string.Empty;

            if (txtOSearchReg.Text.Length > 0)
            {
                strOSearchReg = " AND (RegNo Like '%" + txtOSearchReg.Text.Trim() + "%')";
            }
            if (txtOSearchName.Text.Length > 0)
            {
                strOSearchName = " AND (Names Like '%" + txtOSearchName.Text.Trim() + "%') ";
            }
            if (dtpStartDate.Checked && dtpEndDate.Checked)
            {
                strSearchPeriod = " AND (Appointment >='" + dtpStartDate.Value.ToString("dd/MM/yyyy") + "' AND Appointment <='" + dtpEndDate.Value.ToString("dd/MM/yyyy") + "') ";
            }
            if (dtpStartDate.Checked && !dtpEndDate.Checked)
            {
                strSearchPeriod = " AND (Appointment ='" + dtpStartDate.Value.Date + "') ";
            }
            if (!dtpStartDate.Checked && dtpEndDate.Checked)
            {
                strSearchPeriod = " AND (Appointment ='" + dtpEndDate.Value.Date + "') ";
            }
            myA = new AppointmentInfo();
            try
            {
                strSearchO += strOSearchReg + strOSearchName + strSearchPeriod;
                myA.lvAppointmentAllSearch(lvOApp, strSearchO);
            }
            catch
            { }
            myA = null;
            lblCount.Text = lvOApp.Items.Count.ToString();
            this.Cursor = Cursors.Default;
        }
        private void ShowOutlook()
        {
            this.Cursor = Cursors.WaitCursor;
            strSearchPeriod = string.Empty;
            strSearchO = " (Appointment ='" + SearchDate.Date.ToString("ddMMMyyyy") + "')";
            myA = new AppointmentInfo();
            try
            {
                myA.lvAppointmentAllSearch(lvOApp, strSearchO);
            }
            catch
            { }
            myA = null;
            lblCount.Text = lvOApp.Items.Count.ToString();
            this.Cursor = Cursors.Default;
        }
        private void ShowOutlookToday()
        {
            this.Cursor = Cursors.WaitCursor;
            strSearchPeriod = string.Empty;
            strSearchO = " (Appointment ='" + DateTime.Today.Date + "')";
            myA = new AppointmentInfo();
            try
            {
                myA.lvAppointmentAllSearch(lvAppointments, strSearchO);
            }
            catch
            { }
            myA = null;
            lblCount.Text = lvOApp.Items.Count.ToString();
            this.Cursor = Cursors.Default;
        }
        private void VerifyDate()
        {
            if (txtPeriod.Value > 0)
            {
                //MessageBox.Show(GetPeriodName());
                switch (GetPeriodName())
                {

                    case "D":
                        dtpAvialDate.Value = dtpVisitDate.Value.AddDays(Convert.ToDouble(txtPeriod.Value));
                        break;
                    case "W":
                        dtpAvialDate.Value = dtpVisitDate.Value.AddDays(Convert.ToDouble(txtPeriod.Value * 7));
                        break;
                    case "M":
                        dtpAvialDate.Value = dtpVisitDate.Value.AddMonths(Convert.ToInt32(txtPeriod.Value));
                        break;
                    case "Y":
                        dtpAvialDate.Value = dtpVisitDate.Value.AddYears(Convert.ToInt32(txtPeriod.Value));
                        break;
                }
                ConfirmDate(dtpAvialDate);
            }



        }
        private void ConfirmDate(DateTimePicker dtp)
        {
            ReserveDay = new ReserveInfo();
            WorkingDay = new SettingsInfo();
            PublicHolidayDay = new PublicHolidayInfo();
            AppointmentInfo.Appointment = dtp.Value.Date;
            Proceed = false;
            n = 0;
            while (!Proceed)
            {
                AppointmentOK(false);
                Proceed = true;
                AppointmentInfo.Appointment = AppointmentInfo.Appointment.AddDays(n);
                if (ReserveDay.DateIsReserved())
                {
                    if (ProceedR = ReserveDay.DateIsReserve())
                    {
                        Proceed = false;
                        n = 1;
                    }
                    else
                    {
                        return;
                    }
                }
                if ((AppointmentInfo.Appointment.DayOfWeek == DayOfWeek.Thursday) && (lblAgeunit.Text == "Y") && (Convert.ToInt32(lblAge.Text) > 20))
                {
                    Proceed = false;
                    n = 1;
                }
                if (ProceedW = !WorkingDay.DateIsOK())
                {
                    Proceed = false;
                    n = 1;
                }
                if (ProceedP= PublicHolidayDay.DateIsHoliday())
                {
                    Proceed = false;
                    n = 1;
                }
            }
            AppointmentOK(true);
           
           
        }
        private void CheckDate(DateTimePicker dtp)
        {
            ReserveDay = new ReserveInfo();
            WorkingDay = new SettingsInfo();
            PublicHolidayDay = new PublicHolidayInfo();
            AppointmentInfo.Appointment = dtp.Value.Date;
            AppointmentOK(false);
            Proceed = true;
            if (ReserveDay.DateIsReserved())
            {
                if (ProceedR = ReserveDay.DateIsReserve())
                {
                    Proceed = false;
                }
                else
                {
                    return;
                }
            }
            if ((AppointmentInfo.Appointment.DayOfWeek == DayOfWeek.Thursday) && (lblAgeunit.Text == "Y") && (Convert.ToInt32(lblAge.Text) > 20))
            {
                Proceed = false;
            }
            if (ProceedW = !WorkingDay.DateIsOK())
            {
                Proceed = false;
            }
            if (ProceedP = PublicHolidayDay.DateIsHoliday())
            {
                Proceed = false;
            }
            if (Proceed)
            {
                AppointmentOK(true);
            }
            CheckTheDate= Proceed;
        }
        private void AppointmentOK(bool status)
        {
            pS.Image = DNo;
            lblStatus.Text = "NOT AVAILABLE !";
            lblStatus.ForeColor = Color.Red;
            if (status)
            {
                pS.Image = DYes;
                lblStatus.Text = "AVAILABLE ";
                lblStatus.ForeColor = Color.Green;
                dtpAvialDate.Value = AppointmentInfo.Appointment;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            LiveEdit();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteInfo();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            LiveAdd();
       }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (dtpAvialDate.Checked)
            {

                TimeSpan tscheck = dtpAvialDate.Value.Date - dtpVisitDate.Value.Date;
                TimeSpan tscheck2 = DateTime.Today - dtpVisitDate.Value.Date;
                if ((tscheck.Days < 0) || (tscheck2.Days<0))
                {
                    Interactive.LInfoError("Visit date is cannot be greater than Appointment date or todays date","");
                    {
                        return;
                    }
                }
            
                CheckDate(dtpAvialDate);
                if (!CheckTheDate)
                {
                    if ((Interactive.LInfoWarning("Would you like to check for next available date ?", "Appointment date is not avilable") == DialogResult.Yes))
                    {
                        ConfirmDate(dtpAvialDate);
                    }
                }
                TimeSpan ts = dtpAvialDate.Value.Date - DateTime.Today;
                if (ts.Days > 90)
                {
                    if ((Interactive.LInfoWarning("Would you like to change ?", "Appointment date is more than 3 months") == DialogResult.Yes))
                    {
                        return;
                    }
                }
            
            }
            
            
            this.Cursor = Cursors.WaitCursor;
            SaveInfo();
            this.Cursor = Cursors.Default;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            lvAppointments.SelectedItems.Clear();
            LiveClear();
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            SearchAppointments();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpStartDate.Checked = false;
            dtpEndDate.Checked = false;
            txtOSearchName.Clear();
            txtOSearchReg.Clear();
            LoadAppointments();
        }
        private void FrmAppointment_Load(object sender, EventArgs e)
        {
            SearchDate = DateTime.Today;
            LoadEnrollment();
            //LoadAppointments();
            ShowOutlook();
            LoadSeenBy();
        }
        private void lvAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            DontDisplayHistory();
            if (lvAppointments.SelectedItems.Count > 0)
            {
                DisplayHistory();
            }
        }
        private void txtSearchReg_TextChanged(object sender, EventArgs e)
        {
            //SearchEnrollment();
        }
        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
           //SearchEnrollment();
        }
        private void mcAppointment_DateSelected(object sender, DateRangeEventArgs e)
        {
            SearchDate = e.Start;
            ShowOutlook();
        }
        private void btnClearA_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtSearchReg.Clear();
            txtSearchName.Clear();
            LoadEnrollment();
            this.Cursor = Cursors.Default;
        }
        private void lvEnrollment_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkDemographics.Enabled = false;
            DontDisplay();
            
            if (lvEnrollment.SelectedItems.Count == 1)
            {
                linkDemographics.Enabled = true;
                //dtpAvialDate.MinDate = MinAppointmentdate = Convert.ToDateTime("1/1/1900");
                //dtpVisitDate.MinDate = MinVisitDate = Convert.ToDateTime("1/1/1900");
                //try
                //{
                //    dtpAvialDate.MinDate = MinAppointmentdate = Convert.ToDateTime(lvEnrollment.SelectedItems[0].SubItems[2].Text);
                //    dtpVisitDate.MinDate = MinVisitDate = Convert.ToDateTime(lvEnrollment.SelectedItems[0].SubItems[2].Text);
                //}
                //catch { };
                Display();
            }
        }
        private void rbDays_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDays.Checked)
            {
                VerifyDate();
            }
        }
        private void rbWeeks_CheckedChanged(object sender, EventArgs e)
        {

            VerifyDate();
        }
        private void rbMonths_CheckedChanged(object sender, EventArgs e)
        {
            VerifyDate();
        }
        private void rbYears_CheckedChanged(object sender, EventArgs e)
        {
            VerifyDate();
        }
        private void txtPeriod_ValueChanged(object sender, EventArgs e)
        {
            VerifyDate();
        }
        private void dtpAvialDate_ValueChanged(object sender, EventArgs e)
        {
          
        }
        private void pnApp_Paint(object sender, PaintEventArgs e)
        {

        }
        private void dtpVisitDate_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private void enroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void facilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }
        private void dtpAvialDate_Leave(object sender, EventArgs e)
        {
            if (dtpAvialDate.Checked)
            {
                CheckDate(dtpAvialDate);
                if (!CheckTheDate)
                {
                    if ((Interactive.LInfoWarning("Would you like to check for next available date ?", "Appointment date is not avilable") == DialogResult.Yes))
                    {
                        ConfirmDate(dtpAvialDate);
                    }
                }
            }
        }
        private void lvOApp_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }
        private void dtpReturn_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        private void gBAppointment_Enter(object sender, EventArgs e)
        {

        }
        private void mcAppointment_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
        private void FrmAppointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //if (Interactive.LInfoConfirm("Are you sure want to exit ?", "Exit") == DialogResult.Yes)
            //{
            //    e.Cancel = false;
            //}
        }
        private void FrmAppointment_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void lblReg_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblA_TextChanged(object sender, EventArgs e)
        {
            if (lblA.Text.Trim().Length > 0)
            {
                lblAview.Text = Convert.ToDateTime(lblA.Text).ToString("dd MMM yyyy").ToUpper();
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtOSearchReg_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchEnrollment();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintHistory_Click(object sender, EventArgs e)
        {
            FrmReportVisit f = new FrmReportVisit(AppointmentInfo.RegNo);
            f.Show();

        }

        private void visitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void linkDemographics_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPatient f = new FrmPatient(lblReg.Text);
            f.Show();
        }

       
    }
}