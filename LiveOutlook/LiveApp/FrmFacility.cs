using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LiveOutlook.LiveUIL;
using LiveOutlook.LiveUIL.LiveCore;
using LiveOutlook.LiveUIL;

namespace LiveOutlook.LiveApp
{
    public partial class FrmFacility : Form
    {
        public FrmFacility()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " [v" + Application.ProductVersion + "]  | " + this.Text;
        }

        private static bool Proceed = false;
        private static bool EditFlag = false;
        private static bool EditFlagP = false;
        private static bool EditFlagR = false;
        private static bool EditFlagW = false;
        private static bool EditFlagRT = false;
        private static bool EditFlagRB = false;
        private static bool EditFlagCL = false;
        private static bool EditFlagCT = false;
        private static StringBuilder sb;
        private static string err = string.Empty;
        private static FacilityInfo myF;
        private static PublicHolidayInfo myP;
        private static SettingsInfo myW;
        private static ReserveInfo myR;
        private static ClassificationInfo myC;
        private static int DaysCount = 0;
        
        private static string OriginalFcode = string.Empty;

        private void LoadFacility()
        {
            LiveClear();
            EditFlag = false;
            OriginalFcode = string.Empty;
            txtCode.Clear();
            txtName.Clear();
            myF = new FacilityInfo();
            if (myF.ShowFacility() > 0)
            {
                btnEdit.Enabled = true;
                OriginalFcode = FacilityInfo.FCode;
                txtCode.Text = FacilityInfo.FCode;
                txtName.Text = FacilityInfo.FName;
                EditFlag = true;
            }
            else
            {
                LiveAdd();
            }

        }
        private void LoadP()
        {
            LiveClearP();
            myP = new PublicHolidayInfo();
            myP.lvPublicHoliday(lvP);
            myP = null;
        }
        private void LoadR()
        {
            LiveClearR();
            myR = new ReserveInfo();
            myR.lvReserve(lvR);
            myR=null;
        }
        private void LoadW()
        {
            //SetCapacity();
            LiveClearW();
            EditFlag = false;
            myW = new SettingsInfo();
            if (myW.ShowSettings() > 0)
            {
                btnEdit.Enabled = true;
                txtMon.Value = SettingsInfo.Mon;
                txtTue.Value = SettingsInfo.Tue;
                txtWed.Value = SettingsInfo.Wed;
                txtThr.Value = SettingsInfo.Thr;
                txtFri.Value = SettingsInfo.Fri;
                txtSat.Value = SettingsInfo.Sat;
                txtSun.Value = SettingsInfo.Sun;
                
                EditFlag = true;
            }
            else
            {
                LiveAdd();
            }

        }
        private void LoadRT()
        {
            LiveClearRT();
            myC = new ClassificationInfo();
            ClassificationInfo.AClass = "ReferredTo";
            myC.lvClassification(lvRT);
            myC = null;
        }
        private void LoadRB()
        {
            LiveClearRB();
            myC = new ClassificationInfo();
            ClassificationInfo.AClass = "ReferredBy";
            myC.lvClassification(lvRB);
            myC = null;
        }
        private void LoadCL()
        {
            LiveClearCL();
            myC = new ClassificationInfo();
            ClassificationInfo.AClass = "Appointments";
            myC.lvClassification(lvCL);
            myC = null;
        }
        private void LoadCT()
        {
            LiveClearCT();
            myC = new ClassificationInfo();
            ClassificationInfo.AClass = "Category";
            myC.lvClassification(lvCT);
            myC = null;
        }
        private void SetCapacity()
        {
            SettingsInfo SetCap = new SettingsInfo ();
            if (SetCap.ShowSettings() > 0)
            {
                txtMon.Maximum = SettingsInfo.Mon;
                txtTue.Maximum = SettingsInfo.Tue;
                txtWed.Maximum = SettingsInfo.Wed;
                txtThr.Maximum = SettingsInfo.Thr;
                txtFri.Maximum = SettingsInfo.Fri;
                txtSat.Maximum = SettingsInfo.Sat;
                txtSun.Maximum = SettingsInfo.Sun;
            }
            else
            {
                txtMon.Maximum = 0;
                txtTue.Maximum = 0;
                txtWed.Maximum = 0;
                txtThr.Maximum = 0;
                txtFri.Maximum = 0;
                txtSat.Maximum = 0;
                txtSun.Maximum = 0;
            }
            SetCap = null;
        }

        private void LiveAdd()
        {
            ClearControls();
            EnableControls(true);
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
        }
        private void LiveAddP()
        {
            ClearControlsP();
            EnableControlsP(true);
            btnPNew.Enabled = false;
            btnPSave.Enabled = true;
            btnPEdit.Enabled = false;
            btnPDelete.Enabled = false;
        }
        private void LiveAddR()
        {
            ClearControlsR();
            EnableControlsR(true);
            btnRNew.Enabled = false;
            btnRSave.Enabled = true;
            btnREdit.Enabled = false;
            btnRDelete.Enabled = false;
        }
        private void LiveAddRB()
        {
            ClearControlsRB();
            EnableControlsRB(true);
            btnRBNew.Enabled = false;
            btnRBSave.Enabled = true;
            btnRBEdit.Enabled = false;
            btnRBDelete.Enabled = false;
        }
        private void LiveAddRT()
        {
            ClearControlsRT();
            EnableControlsRT(true);
            btnRTNew.Enabled = false;
            btnRTSave.Enabled = true;
            btnRTEdit.Enabled = false;
            btnRTDelete.Enabled = false;
        }
        private void LiveAddCL()
        {
            ClearControlsCL();
            EnableControlsCL(true);
            btnCLNew.Enabled = false;
            btnCLSave.Enabled = true;
            btnCLEdit.Enabled = false;
            btnCLDelete.Enabled = false;
        }
        private void LiveAddCT()
        {
            ClearControlsCT();
            EnableControlsCT(true);
            btnCTNew.Enabled = false;
            btnCTSave.Enabled = true;
            btnCTEdit.Enabled = false;
            btnCTDelete.Enabled = false;
        }

        private void LiveEdit()
        {
            EditFlag = true;
            EnableControls(true);
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }
        private void LiveEditP()
        {
            EditFlagP = true;
            EnableControlsP(true);
            btnPEdit.Enabled = false;
            btnPDelete.Enabled = false;
            btnPNew.Enabled = false;
            btnPSave.Enabled = true;
        }
        private void LiveEditR()
        {
            EditFlagR = true;
            EnableControlsR(true);
            btnREdit.Enabled = false;
            btnRDelete.Enabled = false;
            btnRNew.Enabled = false;
            btnRSave.Enabled = true;
        }
        private void LiveEditW()
        {
            EditFlagW = true;
            EnableControlsW(true);
            btnWEdit.Enabled = false;
            btnWSave.Enabled = true;
        }
        private void LiveEditRT()
        {
            EditFlagRT = true;
            EnableControlsRT(true);
            btnRTEdit.Enabled = false;
            btnRTDelete.Enabled = false;
            btnRTNew.Enabled = false;
            btnRTSave.Enabled = true;
        }
        private void LiveEditRB()
        {
            EditFlagRB = true;
            EnableControlsRB(true);
            btnRBEdit.Enabled = false;
            btnRBDelete.Enabled = false;
            btnRBNew.Enabled = false;
            btnRBSave.Enabled = true;
        }
        private void LiveEditCL()
        {
            EditFlagCL = true;
            EnableControlsCL(true);
            btnCLEdit.Enabled = false;
            btnCLDelete.Enabled = false;
            btnCLNew.Enabled = false;
            btnCLSave.Enabled = true;
        }
        private void LiveEditCT()
        {
            EditFlagCT = true;
            EnableControlsCT(true);
            btnCTEdit.Enabled = false;
            btnCTDelete.Enabled = false;
            btnCTNew.Enabled = false;
            btnCTSave.Enabled = true;
        }

        private void LiveClear()
        {
            EditFlag = false;
            EnableControls(false);
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            
        }
        private void LiveClearP()
        {
            EditFlag = false;
            ClearControlsP();
            EnableControlsP(false);
            btnPNew.Enabled = true;
            btnPDelete.Enabled = false;
            btnPEdit.Enabled = false;
            btnPSave.Enabled = false;
        }
        private void LiveClearR()
        {
            EditFlag = false;
            ClearControlsR();
            EnableControlsR(false);
            btnRNew.Enabled = true;
            btnRDelete.Enabled = false;
            btnREdit.Enabled = false;
            btnRSave.Enabled = false;
        }
        private void LiveClearW()
        {
            EditFlag = false;
            //ClearControls();
            EnableControlsW(false);
            btnWSave.Enabled = false;
            btnWEdit.Enabled = true;
        }
        private void LiveClearRB()
        {
            EditFlagRB = false;
            ClearControlsRB();
            EnableControlsRB(false);
            btnRBNew.Enabled = true;
            btnRBDelete.Enabled = false;
            btnRBEdit.Enabled = false;
            btnRBSave.Enabled = false;
        }
        private void LiveClearRT()
        {
            EditFlagRT = false;
            ClearControlsRT();
            EnableControlsRT(false);
            btnRTNew.Enabled = true;
            btnRTDelete.Enabled = false;
            btnRTEdit.Enabled = false;
            btnRTSave.Enabled = false;
        }
        private void LiveClearCL()
        {
            EditFlagCL = false;
            ClearControlsCL();
            EnableControlsCL(false);
            btnCLNew.Enabled = true;
            btnCLDelete.Enabled = false;
            btnCLEdit.Enabled = false;
            btnCLSave.Enabled = false;
        }
        private void LiveClearCT()
        {
            EditFlagCT = false;
            ClearControlsCT();
            EnableControlsCT(false);
            btnCTNew.Enabled = true;
            btnCTDelete.Enabled = false;
            btnCTEdit.Enabled = false;
            btnCTSave.Enabled = false;
        }

        private bool FormIsValid()
        {
            Proceed = true;
            sb = new StringBuilder("Please resolve the following to proceed\n");
            #region Form
            foreach (Control a in this.Controls)
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
            err = sb.ToString();
            return Proceed;
        }
        private bool FormIsValidP()
        {
            Proceed = true;
            sb = new StringBuilder("Please resolve the following to proceed\n");
            #region Form
            foreach (Control a in this.Controls)
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
            err = sb.ToString();
            return Proceed;
        }
        private bool FormIsValidR()
        {
            Proceed = true;
            sb = new StringBuilder("Please resolve the following to proceed\n");
            #region Form
            foreach (Control a in tPgR.Controls)
            {
                #region NumericUpdown
                if ((a is NumericUpDown) && (a.CausesValidation))
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
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
            err = sb.ToString();
            return Proceed;
        }
        private bool FormIsValidW()
        {
            Proceed = true;
            sb = new StringBuilder("Please resolve the following to proceed\n");
            #region Form
            foreach (Control a in tPgW.Controls)
            {
                #region NumericUpdown
                if ((a is NumericUpDown) && (a.CausesValidation))
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
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
            err = sb.ToString();
            return Proceed;
        }
        private bool FormIsValidRB()
        {
            Proceed = true;
            sb = new StringBuilder("Please resolve the following to proceed\n");
            #region Form
            foreach (Control a in tPgRB.Controls)
            {
                #region Text
                if (a is TextBox && a.CausesValidation)
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
                #region NumericUpdown
                if ((a is NumericUpDown) && (a.CausesValidation))
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
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
            err = sb.ToString();
            return Proceed;
        }
        private bool FormIsValidRT()
        {
            Proceed = true;
            sb = new StringBuilder("Please resolve the following to proceed\n");
            #region Form
            foreach (Control a in tPgRT.Controls)
            {
                #region Text
                if (a is TextBox && a.CausesValidation)
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
                #region NumericUpdown
                if ((a is NumericUpDown) && (a.CausesValidation))
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
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
            err = sb.ToString();
            return Proceed;
        }
        private bool FormIsValidCL()
        {
            Proceed = true;
            sb = new StringBuilder("Please resolve the following to proceed\n");
            #region Form
            foreach (Control a in tPgCL.Controls)
            {
                #region Text
                if (a is TextBox && a.CausesValidation)
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
                #region NumericUpdown
                if ((a is NumericUpDown) && (a.CausesValidation))
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
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
            err = sb.ToString();
            return Proceed;
        }
        private bool FormIsValidCT()
        {
            Proceed = true;
            sb = new StringBuilder("Please resolve the following to proceed\n");
            #region Form
            foreach (Control a in tPgCT.Controls)
            {
                #region Text
                if (a is TextBox && a.CausesValidation)
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
                #region NumericUpdown
                if ((a is NumericUpDown) && (a.CausesValidation))
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
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
            err = sb.ToString();
            return Proceed;
        }

        private void SaveInfo()
        {
           
            if (FormIsValid())
            {
                myF = new FacilityInfo();
                FacilityInfo.FCode = txtCode.Text;
                FacilityInfo.FName = txtName.Text;

                if (EditFlag)
                {
                    FacilityInfo.FCode = OriginalFcode;
                    FacilityInfo.NewFCode = txtCode.Text;
                    if ((Interactive.LInfoConfirm("Are you sure you want to Edit ?", "Facility") == DialogResult.Yes))
                    {

                        if (myF.EditFacility())
                        {
                            LoadFacility();
                        }
                    }
                }
                else
                {
                    if (myF.NewFacility())
                    {
                        LoadFacility();
                    }
                }
            }
            else
            {
                Interactive.LInfoError(err, "Update Facility");
            }
        }
        private void SaveInfoP()
        {

            if (FormIsValidP())
            {
                myP = new PublicHolidayInfo();
                PublicHolidayInfo.Day = dtpP.Value.Day;
                PublicHolidayInfo.Month = dtpP.Value.Month;

                if (EditFlagP)
                {
                    PublicHolidayInfo.Day = Convert.ToInt32(lblPD.Text);
                    PublicHolidayInfo.Month = Convert.ToInt32(lblPM.Text);
                    PublicHolidayInfo.NewDay = dtpP.Value.Day;
                    PublicHolidayInfo.NewMonth = dtpP.Value.Month;
                    
                    
                    if ((Interactive.LInfoConfirm("Are you sure you want to Edit ?", "PublicHoliday") == DialogResult.Yes))
                    {

                        if (myP.EditPublicHoliday())
                        {
                            LoadP();
                            lvP.SelectedItems.Clear();
                        }
                    }
                }
                else
                {
                    if (myP.NewPublicHoliday())
                    {
                        LoadP();
                        lvP.SelectedItems.Clear();
                    }
                }
            }
            else
            {
                Interactive.LInfoError(err, "Update PublicHoliday");
            }
        }
        private void SaveInfoR()
        {

            if (FormIsValidR())
            {
                myR = new ReserveInfo();
                ReserveInfo.Day = dtpR.Value.Day;
                ReserveInfo.Month = dtpR.Value.Month;
                ReserveInfo.Year = dtpR.Value.Year;
                ReserveInfo.MaxAppointments =Convert.ToInt32(txtCapcity.Value);
                if (EditFlagR)
                {

                    ReserveInfo.Day = Convert.ToDateTime(lblRDate.Text).Day;
                    ReserveInfo.Month = Convert.ToDateTime(lblRDate.Text).Month;
                    ReserveInfo.Year = Convert.ToDateTime(lblRDate.Text).Year;
                 
                    ReserveInfo.NewDay = dtpR.Value.Day;
                    ReserveInfo.NewMonth = dtpR.Value.Month;
                    ReserveInfo.NewYear = dtpR.Value.Year;
                    if ((Interactive.LInfoConfirm("Are you sure you want to Edit ?", "Reserve") == DialogResult.Yes))
                    {

                        if (myR.EditReserve())
                        {
                            LoadR();
                            lvR.SelectedItems.Clear();
                        }
                    }
                }
                else
                {
                    if (myR.NewReserve())
                    {
                        LoadR();
                        lvR.SelectedItems.Clear();
                    }
                }
            }
            else
            {
                Interactive.LInfoError(err, "Update Reserve");
            }
        }
        private void SaveInfoW()
        {

            if (FormIsValidW())
            {
                myW = new SettingsInfo();
                if (EditFlagW)
                {
                    DaysCount = 0;
                    
                    foreach (Control a in tPgW.Controls)
                    {
                        #region NumericupDown
                        if (a is NumericUpDown)
                        {
                            NumericUpDown cntrl = (NumericUpDown)a;
                            SettingsInfo.ADay = cntrl.AccessibleName;
                            SettingsInfo.MaxAppointments = Convert.ToInt32(cntrl.Value);
                            if (myW.EditSettings())
                            {
                                DaysCount += 1;
                            }
                        }
                        #endregion
                    }
                    if (DaysCount.Equals(7))
                    {
                        Interactive.LInfo("Settings Updated successfully", "Edit Settings");
                        LoadW();
                    }
                }
            }
            else
            {
                Interactive.LInfoError(err, "Update Settings");
            }
        }
        private void SaveInfoRB()
        {
            if (FormIsValidRB())
            {
                myC = new ClassificationInfo();
                ClassificationInfo.ID = txtRBID.Text;
                ClassificationInfo.Display = txtRB.Text;
                ClassificationInfo.AClass = "ReferredBy";
                ClassificationInfo.Value = -1;
                if (EditFlagRB)
                {
                    ClassificationInfo.ID = lblRB.Text;
                    ClassificationInfo.NewID = txtRBID.Text;
                    if ((Interactive.LInfoConfirm("Are you sure you want to Edit ?", "Classification") == DialogResult.Yes))
                    {
                        if (myC.EditClassification())
                        {
                            LoadRB();
                        }
                    }
                }
                else
                {
                    if (myC.NewClassification())
                    {
                        LoadRB();
                    }
                }
            }
            else
            {
                Interactive.LInfoError(err, "Update Classification");
            }
        }
        private void SaveInfoRT()
        {
            if (FormIsValidRT())
            {
                myC = new ClassificationInfo();
                ClassificationInfo.ID = txtRTID.Text;
                ClassificationInfo.Display = txtRT.Text;
                ClassificationInfo.AClass = "ReferredTo";
                ClassificationInfo.Value = -1;
                if (EditFlagRT)
                {
                    ClassificationInfo.ID = lblRT.Text;
                    ClassificationInfo.NewID = txtRTID.Text;
                    if ((Interactive.LInfoConfirm("Are you sure you want to Edit ?", "Classification") == DialogResult.Yes))
                    {
                        if (myC.EditClassification())
                        {
                            LoadRT();
                        }
                    }
                }
                else
                {
                    if (myC.NewClassification())
                    {
                        LoadRT();
                    }
                }
            }
            else
            {
                Interactive.LInfoError(err, "Update Classification");
            }
        }
        private void SaveInfoCL()
        {
            if (FormIsValidCL())
            {
                myC = new ClassificationInfo();
                ClassificationInfo.ID = txtCLID.Text;
                ClassificationInfo.Display = txtCL.Text;
                ClassificationInfo.AClass = "Appointments";
                //ClassificationInfo.Value = Convert.ToInt64(txtCLdays.Value);
                if (EditFlagCL)
                {
                    ClassificationInfo.ID = lblCL.Text;
                    ClassificationInfo.NewID = txtCLID.Text;
                    if ((Interactive.LInfoConfirm("Are you sure you want to Edit ?", "Classification") == DialogResult.Yes))
                    {
                        if (myC.EditClassification())
                        {
                            LoadCL();
                        }
                    }
                }
                else
                {
                    if (myC.NewClassification())
                    {
                        LoadCL();
                    }
                }
            }
            else
            {
                Interactive.LInfoError(err, "Update Classification");
            }
        }
        private void SaveInfoCT()
        {
            if (FormIsValidCT())
            {
                myC = new ClassificationInfo();
                ClassificationInfo.ID = txtCTID.Text;
                ClassificationInfo.Display = txtCT.Text;
                ClassificationInfo.AClass = "Category";
                ClassificationInfo.Value = -1;
                if (EditFlagCT)
                {
                    ClassificationInfo.ID = lblCT.Text;
                    ClassificationInfo.NewID = txtCTID.Text;
                    if ((Interactive.LInfoConfirm("Are you sure you want to Edit ?", "Classification") == DialogResult.Yes))
                    {
                        if (myC.EditClassification())
                        {
                            LoadCT();
                        }
                    }
                }
                else
                {
                    if (myC.NewClassification())
                    {
                        LoadCT();
                    }
                }
            }
            else
            {
                Interactive.LInfoError(err, "Update Classification");
            }
        }

        private void DeleteInfoP()
        {
            if ((Interactive.LInfoWarning("Are you sure you want to Delete ?", "PublicHoliday") == DialogResult.Yes))
            {
                myP = new PublicHolidayInfo();
                PublicHolidayInfo.Day = Convert.ToInt32(lblPD.Text);
                PublicHolidayInfo.Month = Convert.ToInt32(lblPM.Text);
                if (myP.RemovePublicHoliday())
                {
                    LoadP();
                }
                return;
            }
        }
        private void DeleteInfoR()
        {
            if ((Interactive.LInfoWarning("Are you sure you want to Delete ?", "Reserve") == DialogResult.Yes))
            {
                myR = new ReserveInfo();
                ReserveInfo.Day = Convert.ToDateTime(lblRDate.Text).Day;
                ReserveInfo.Month = Convert.ToDateTime(lblRDate.Text).Month;
                ReserveInfo.Year = Convert.ToDateTime(lblRDate.Text).Year;
                if (myR.RemoveReserve())
                {
                    LoadR();
                }
                return;
            }
        }
        private void DeleteInfoRB()
        {
            if ((Interactive.LInfoWarning("Are you sure you want to Delete ?", "Classification") == DialogResult.Yes))
            {
                myC = new ClassificationInfo();
                ClassificationInfo.ID = lblRB.Text;
                ClassificationInfo.AClass = "ReferredBy";
                if (myC.RemoveClassification())
                {
                    LoadRB();
                }
                return;
            }
        }
        private void DeleteInfoRT()
        {
            if ((Interactive.LInfoWarning("Are you sure you want to Delete ?", "Classification") == DialogResult.Yes))
            {
                myC = new ClassificationInfo();
                ClassificationInfo.ID = lblRT.Text;
                ClassificationInfo.AClass = "ReferredTo";
                if (myC.RemoveClassification())
                {
                    LoadRT();
                }
                return;
            }
        }
        private void DeleteInfoCL()
        {
            if ((Interactive.LInfoWarning("Are you sure you want to Delete ?", "Classification") == DialogResult.Yes))
            {
                myC = new ClassificationInfo();
                ClassificationInfo.ID = lblCL.Text;
                ClassificationInfo.AClass = "Appointments";
                if (myC.RemoveClassification())
                {
                    LoadCL();
                }
                return;
            }
        }
        private void DeleteInfoCT()
        {
            if ((Interactive.LInfoWarning("Are you sure you want to Delete ?", "Classification") == DialogResult.Yes))
            {
                myC = new ClassificationInfo();
                ClassificationInfo.ID = lblCT.Text;
                ClassificationInfo.AClass = "Category";
                if (myC.RemoveClassification())
                {
                    LoadCT();
                }
                return;
            }
        }

        private void ClearControls()
        {
            TextBox txt;
            OriginalFcode = string.Empty;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    txt = (TextBox)c;
                    txt.Clear();
                }
            }
        }
        private void ClearControlsP()
        {
            dtpP.Value = DateTime.Now;
            lblPD.Text = string.Empty;
            lblPM.Text = string.Empty;
            lblPMM.Text = string.Empty;
           
        }
        private void ClearControlsR()
        {
            lblRDate.Text = string.Empty;
            txtCapcity.ResetText();
        }
        private void ClearControlsW()
        {
          
        }
        private void ClearControlsRT()
        {
            
            foreach (Control a in tPgRT.Controls)
            {
                #region Label
                if (a is Label && !a.CausesValidation)
                {
                    Label cntrl = (Label)a;
                    cntrl.Text = string.Empty;
                }
                #endregion
                #region Text
                if (a is TextBox && a.CausesValidation)
                {
                    TextBox cntrl = (TextBox)a;
                    cntrl.Clear();
                }
                #endregion
                #region NumericupDown
                if (a is NumericUpDown && a.CausesValidation)
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
                    cntrl.ResetText();
                }
                #endregion
            }
            
        }
        private void ClearControlsRB()
        {
            foreach (Control a in tPgRB.Controls)
            {
                #region Label
                if (a is Label && !a.CausesValidation)
                {
                    Label cntrl = (Label)a;
                    cntrl.Text = string.Empty;
                }
                #endregion
                #region Text
                if (a is TextBox && a.CausesValidation)
                {
                    TextBox cntrl = (TextBox)a;
                    cntrl.Clear();
                }
                #endregion
                #region NumericupDown
                if (a is NumericUpDown && a.CausesValidation)
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
                    cntrl.ResetText();
                }
                #endregion
            }

        }
        private void ClearControlsCL()
        {
            foreach (Control a in tPgCL.Controls)
            {
                #region Label
                if (a is Label && !a.CausesValidation)
                {
                    Label cntrl = (Label)a;
                    cntrl.Text = string.Empty;
                }
                #endregion
                #region Text
                if (a is TextBox && a.CausesValidation)
                {
                    TextBox cntrl = (TextBox)a;
                    cntrl.Clear();
                }
                #endregion
                #region NumericupDown
                if (a is NumericUpDown && a.CausesValidation)
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
                    cntrl.ResetText();
                }
                #endregion
            }

        }
        private void ClearControlsCT()
        {
            foreach (Control a in tPgCT.Controls)
            {
                #region Label
                if (a is Label && !a.CausesValidation)
                {
                    Label cntrl = (Label)a;
                    cntrl.Text = string.Empty;
                }
                #endregion
                #region Text
                if (a is TextBox && a.CausesValidation)
                {
                    TextBox cntrl = (TextBox)a;
                    cntrl.Clear();
                }
                #endregion
                #region NumericupDown
                if (a is NumericUpDown && a.CausesValidation)
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
                    cntrl.ResetText();
                }
                #endregion
            }

        }

        private void EnableControls(bool status)
        {
            txtCode.Enabled=status;
            txtName.Enabled=status;
        }
        private void EnableControlsP(bool status)
        {
            dtpP.Enabled = status;
            lvP.Enabled = !status;
        }
        private void EnableControlsR(bool status)
        {
            dtpR.Enabled = status;
            txtCapcity.Enabled = status;
            lvR.Enabled = !status;
        }
        private void EnableControlsW(bool status)
        {
            foreach (Control a in tPgW.Controls)
            {
                #region NumericupDown
                if (a is NumericUpDown)
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
                    cntrl.Enabled = status;
                }
                #endregion
            }
        }
        private void EnableControlsRT(bool status)
        {
            foreach (Control a in tPgRT.Controls)
            {
                #region Text
                if (a is TextBox && a.CausesValidation)
                {
                    TextBox cntrl = (TextBox)a;
                    cntrl.Enabled = status;
                }
                #endregion
                #region NumericupDown
                if (a is NumericUpDown && a.CausesValidation)
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
                    cntrl.Enabled = status;
                }
                #endregion
            }
        }
        private void EnableControlsRB(bool status)
        {
            foreach (Control a in tPgRB.Controls)
            {
                #region Text
                if (a is TextBox && a.CausesValidation)
                {
                    TextBox cntrl = (TextBox)a;
                    cntrl.Enabled = status;
                }
                #endregion
                #region NumericupDown
                if (a is NumericUpDown && a.CausesValidation)
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
                    cntrl.Enabled = status;
                }
                #endregion
     
            }
        }
        private void EnableControlsCL(bool status)
        {
            foreach (Control a in tPgCL.Controls)
            {
                #region Text
                if (a is TextBox && a.CausesValidation)
                {
                    TextBox cntrl = (TextBox)a;
                    cntrl.Enabled = status;
                }
                #endregion
                #region NumericupDown
                if (a is NumericUpDown && a.CausesValidation)
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
                    cntrl.Enabled = status;
                }
                #endregion
            }
        }
        private void EnableControlsCT(bool status)
        {
            foreach (Control a in tPgCT.Controls)
            {
                #region Text
                if (a is TextBox && a.CausesValidation)
                {
                    TextBox cntrl = (TextBox)a;
                    cntrl.Enabled = status;
                }
                #endregion
                #region NumericupDown
                if (a is NumericUpDown && a.CausesValidation)
                {
                    NumericUpDown cntrl = (NumericUpDown)a;
                    cntrl.Enabled = status;
                }
                #endregion

            }
        }

        private void DisplayP()
        {
            
            lblPD.Text = lvP.SelectedItems[0].Text;
            lblPM.Text = lvP.SelectedItems[0].SubItems[2].Text;
            lblPMM.Text = lvP.SelectedItems[0].SubItems[1].Text;
            try
            {
                dtpP.Value = Convert.ToDateTime(lblPD.Text + "/" + lblPM.Text + "/" + "1999");
            }
            catch { }
            btnPEdit.Enabled = true;
            btnPDelete.Enabled = true;
        }
        private void DontDisplayP()
        {
            LiveClearR();
            btnPEdit.Enabled = false;
            btnPDelete.Enabled = false;
        }

        private void DisplayR()
        {
            lblRDate.Text = lvR.SelectedItems[0].Text;
            dtpR.Value=Convert.ToDateTime(lvR.SelectedItems[0].Text);
            txtCapcity.Value =Convert.ToDecimal(lvR.SelectedItems[0].SubItems[1].Text);
            btnREdit.Enabled = true;
            btnRDelete.Enabled = true;
        }
        private void DontDisplayR()
        {
            LiveClearR();
            btnREdit.Enabled = false;
            btnRDelete.Enabled = false;
        }

        private void DisplayRT()
        {
            lblRT.Text = lvRT.SelectedItems[0].Text;
            txtRTID.Text = lvRT.SelectedItems[0].Text;
            txtRT.Text = lvRT.SelectedItems[0].SubItems[1].Text;
            btnRTEdit.Enabled = true;
            btnRTDelete.Enabled = true;
        }
        private void DontDisplayRT()
        {
            LiveClearRT();
            btnRTEdit.Enabled = false;
            btnRTDelete.Enabled = false;
        }

        private void DisplayRB()
        {
            lblRB.Text = lvRB.SelectedItems[0].Text;
            txtRBID.Text = lvRB.SelectedItems[0].Text;
            txtRB.Text = lvRB.SelectedItems[0].SubItems[1].Text;
            btnRBEdit.Enabled = true;
            btnRBDelete.Enabled = true;
        }
        private void DontDisplayRB()
        {
            LiveClearRB();
            btnRBEdit.Enabled = false;
            btnRBDelete.Enabled = false;
        }

        private void DisplayCL()
        {
            lblCL.Text = lvCL.SelectedItems[0].Text;
            txtCLID.Text = lvCL.SelectedItems[0].Text;
            txtCL.Text = lvCL.SelectedItems[0].SubItems[1].Text;
            //txtCLdays.Value = Convert.ToDecimal(lvCL.SelectedItems[0].SubItems[2].Text);
            btnCLEdit.Enabled = true;
            btnCLDelete.Enabled = true;
        }
        private void DontDisplayCL()
        {
            LiveClearCL();
            btnCLEdit.Enabled = false;
            btnCLDelete.Enabled = false;
        }

        private void DisplayCT()
        {
            lblCT.Text = lvCT.SelectedItems[0].Text;
            txtCTID.Text = lvCT.SelectedItems[0].Text;
            txtCT.Text = lvCT.SelectedItems[0].SubItems[1].Text;
            btnCTEdit.Enabled = true;
            btnCTDelete.Enabled = true;
        }
        private void DontDisplayCT()
        {
            LiveClearCT();
            btnCTEdit.Enabled = false;
            btnCTDelete.Enabled = false;
        }

        private void FrmFacility_Load(object sender, EventArgs e)
        {
            LoadFacility();
            LoadP();
            LoadW();
            LoadR();
            LoadCL();
            LoadRB();
            LoadRT();
            LoadCT();
            Interactive.LInfoWarningOK("Please contact you Administrator before\nchanging these setting", "Warning : Important Notice !");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            LiveEdit();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LiveClear();
        }

        private void lvP_SelectedIndexChanged(object sender, EventArgs e)
        {
            DontDisplayP();
            if (lvP.SelectedItems.Count > 0)
            {
                DisplayP();
            }
        }
        private void btnPNew_Click(object sender, EventArgs e)
        {
            LiveAddP();
        }
        private void btnPSave_Click(object sender, EventArgs e)
        {
            SaveInfoP();
        }
        private void btnPEdit_Click(object sender, EventArgs e)
        {
            LiveEditP();
        }
        private void btnPDelete_Click(object sender, EventArgs e)
        {
            DeleteInfoP();
        }
        private void btnPCancel_Click(object sender, EventArgs e)
        {
            LiveClearP();
        }

        private void lvR_SelectedIndexChanged(object sender, EventArgs e)
        {
            DontDisplayR();
            if (lvR.SelectedItems.Count > 0)
            {
                DisplayR();
            }
        }
        private void btnRNew_Click(object sender, EventArgs e)
        {
            LiveAddR();
        }
        private void btnRSave_Click(object sender, EventArgs e)
        {
            SaveInfoR();
        }
        private void btnREdit_Click(object sender, EventArgs e)
        {
            LiveEditR();
        }
        private void btnRDelete_Click(object sender, EventArgs e)
        {
            DeleteInfoR();
        }
        private void btnRCancel_Click(object sender, EventArgs e)
        {
            LiveClearR();
        }

        private void btnWEdit_Click(object sender, EventArgs e)
        {
            LiveEditW();
        }
        private void btnWSave_Click(object sender, EventArgs e)
        {
            SaveInfoW();
        }
        private void btnWCancel_Click(object sender, EventArgs e)
        {
            LiveClearW();
        }

        private void lvCL_SelectedIndexChanged(object sender, EventArgs e)
        {
            DontDisplayCL();
            if (lvCL.SelectedItems.Count > 0)
            {
                DisplayCL();
            }
        }
        private void btnCLNew_Click(object sender, EventArgs e)
        {
            LiveAddCL();
        }
        private void btnCLSave_Click(object sender, EventArgs e)
        {
            SaveInfoCL();
        }
        private void btnCLEdit_Click(object sender, EventArgs e)
        {
            LiveEditCL();
        }
        private void btnCLDelete_Click(object sender, EventArgs e)
        {
            DeleteInfoCL();
        }
        private void btnCLCancel_Click(object sender, EventArgs e)
        {
            LiveClearCL();
        }
   
        private void lvRB_SelectedIndexChanged(object sender, EventArgs e)
        {
            DontDisplayRB();
            if (lvRB.SelectedItems.Count > 0)
            {
                DisplayRB();
            }
        }
        private void btnRBNew_Click(object sender, EventArgs e)
        {
            LiveAddRB();
        }
        private void btnRBSave_Click(object sender, EventArgs e)
        {
            SaveInfoRB();
        }
        private void btnRBEdit_Click(object sender, EventArgs e)
        {
            LiveEditRB();
        }
        private void btnRBDelete_Click(object sender, EventArgs e)
        {
            DeleteInfoRB();
        }
        private void btnRBCancel_Click(object sender, EventArgs e)
        {
            LiveClearRB();
        }

        private void lvRT_SelectedIndexChanged(object sender, EventArgs e)
        {
            DontDisplayRT();
            if (lvRT.SelectedItems.Count > 0)
            {
                DisplayRT();
            }
        }
        private void btnRTNew_Click(object sender, EventArgs e)
        {
            LiveAddRT();
        }
        private void btnRTSave_Click(object sender, EventArgs e)
        {
            SaveInfoRT();
        }
        private void btnRTEdit_Click(object sender, EventArgs e)
        {
            LiveEditRT();
        }
        private void btnRTDelete_Click(object sender, EventArgs e)
        {
            DeleteInfoRT();
        }
        private void btnRTCancel_Click(object sender, EventArgs e)
        {
            LiveClearRT();
        }

        private void lvCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            DontDisplayCT();
            if (lvCT.SelectedItems.Count > 0)
            {
                DisplayCT();
            }
        }
        private void btnCTNew_Click(object sender, EventArgs e)
        {
            LiveAddCT();
        }
        private void btnCTSave_Click(object sender, EventArgs e)
        {
            SaveInfoCT();
        }
        private void btnCTEdit_Click(object sender, EventArgs e)
        {
            LiveEditCT();
        }
        private void btnCTDelete_Click(object sender, EventArgs e)
        {
            DeleteInfoCT();
        }
        private void btnCTCancel_Click(object sender, EventArgs e)
        {
            LiveClearCT();
        }

    

    
    }
}
