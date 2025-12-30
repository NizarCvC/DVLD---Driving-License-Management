using DVLD_Business_Layer;
using My_Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project {

    public partial class frmNewLDLApplication : Form {

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private int _PersonID, _LDLApplicationID;
        private clsLocalDrivingLicenseApplication _LDLApplication;

        public frmNewLDLApplication() {

            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmNewLDLApplication(int LDLApplicationID) {

            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
            _Mode = enMode.Update;
        }

        private void frmNewLDLApplication_Load(object sender, EventArgs e) {

            _FillLicenseClassesInComboBox();

            if (_Mode == enMode.AddNew) {

                tcLDLApplication.SelectedIndex = 0;
                this.Text = "New Local Driving License Application";
            }
            else {

                this.Text = "Update Local Driving License Application";
                tcLDLApplication.SelectedIndex = 1;
                ctrlPersonalInfo.Enabled = false;
                btnContinue.Enabled = false;
                _LoadData();
                _PersonID = _LDLApplication.Application.ApplicantPersonID;
            }
        }

        private void _FillLicenseClassesInComboBox() {

            DataTable dt = clsLicenseClass.GetAllLicenseClassNames();

            foreach (DataRow row in dt.Rows) {

                cbLicenseClasses.Items.Add(row["ClassName"]);
            }

            cbLicenseClasses.StartIndex = 2;
        }

        private void _LoadData() {

            if (_Mode == enMode.AddNew) {

                _LDLApplication = new clsLocalDrivingLicenseApplication();
                lblApplicationDate.Text = _LDLApplication.Application.ApplicationDate.ToShortDateString();
                lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
                lblApplicationFee.Text = _LDLApplication.Application.PaidFees.ToString();
                return;
            }

            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLAppID(_LDLApplicationID);

            if (_LDLApplication == null) {

                MessageBox.Show($"The operation will be cancled because no application with ID {_LDLApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblLDLAppID.Text = _LDLApplication.LDLApplicationID.ToString();
            lblApplicationDate.Text = _LDLApplication.Application.ApplicationDate.ToShortDateString();
            lblApplicationFee.Text = _LDLApplication.Application.PaidFees.ToString();
            lblCreatedBy.Text = _LDLApplication.Application.CreatedByUserInfo.Username;
            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(_LDLApplication.LicenseClass.ClassName);
        }

        private bool CheckIsValidAgeForLicenseClass(int PersonID, int LicenseClassID) {

            clsPerson Person = clsPerson.Find(PersonID);
            clsLicenseClass LicenseClass = clsLicenseClass.Find(LicenseClassID);
            int Age = DateTime.Now.Year - Person.DateOfBirth.Year;

            if (DateTime.Now < Person.DateOfBirth.AddYears(Age))
                Age--;

            return Age >= LicenseClass.MinimumAllowedAge;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            
            if (MessageBox.Show("Are you sure you want to save this application?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int ChosenLicenseClassID = clsLicenseClass.Find(cbLicenseClasses.Text).LicenseClassID;

            if (clsLocalDrivingLicenseApplication.PersonHasNewLDLApplicationInLicenseClass(_PersonID, ChosenLicenseClassID)) {

                MessageBox.Show("The applicant has already an active application in the same license class.\nPlease choose another class.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsLocalDrivingLicenseApplication.IsPersonHasAnActiveLicenseInClass(_PersonID, ChosenLicenseClassID)) {

                MessageBox.Show("This applicant has already an active license on this class.\nplease choose another class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CheckIsValidAgeForLicenseClass(_PersonID, ChosenLicenseClassID)) {

                MessageBox.Show("The person cannot applay for this license.\nBecause of the minimum allowed age.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _LDLApplication.Application.ApplicantPersonID = _PersonID;
            _LDLApplication.Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _LDLApplication.LicenseClassID = ChosenLicenseClassID;

            if (_LDLApplication.Save()) {

                MessageBox.Show("Data Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                MessageBox.Show("Data is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Mode = enMode.Update;
            _LDLApplicationID = _LDLApplication.LDLApplicationID;
            this.Text = "Update Local Driving License Application";
            lblLDLAppID.Text = _LDLApplication.LDLApplicationID.ToString();
            ctrlPersonalInfo.Enabled = false;
            btnContinue.Enabled = false;
        }

        private void ctrlPersonalInfo_OnPersonIDFound(object sender, ctrlFilterPersonInfo.PersonIDEventArgs e) {

            _PersonID = e.PersonID;
        }

        // Transactions
        private void _TryGoToApplicationInfo() {

            if (_Mode == enMode.AddNew && _PersonID == 0) {

                MessageBox.Show("Please select a person first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tcLDLApplication.SelectedIndex = 0;
            }
            else {

                _LoadData();
                tcLDLApplication.SelectedIndex = 1;
            }
        }

        private void btnContinue_Click(object sender, EventArgs e) {

            _TryGoToApplicationInfo();
        }

        private void tcLDLApplication_SelectedIndexChanged(object sender, EventArgs e) {

            if (tcLDLApplication.SelectedIndex == 1)
                _TryGoToApplicationInfo();
        }

        // Close
        private void btnCancle_Click(object sender, EventArgs e) => Close();

    }
}