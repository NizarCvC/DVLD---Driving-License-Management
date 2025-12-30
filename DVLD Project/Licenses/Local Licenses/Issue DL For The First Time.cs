using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Manage_LDL_Applications {

    public partial class frmIssueDLForTheFirstTime : Form {

        private int _LDLApplicationID;
        private clsLocalDrivingLicenseApplication _LDLApplication;

        public frmIssueDLForTheFirstTime(int LDLApplicationID) {

            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
        }

        private void frmIssueDLForTheFirstTime_Load(object sender, EventArgs e) {

            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLAppID(_LDLApplicationID);

            if (_LDLApplication == null || _LDLApplication.Application == null) {

                MessageBox.Show("Application not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            if (!_LDLApplication.IsPassedAllTests()) {

                MessageBox.Show("Cannot issue driving license for this applicant.\nBecause hasn't complete all tests", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (clsLocalDrivingLicenseApplication.IsPersonHasAnActiveLicenseInClass(
                _LDLApplication.Application.ApplicantPersonID, _LDLApplication.LicenseClassID)) {

                MessageBox.Show("This applicant has already an active license on this class.\nplease choose another class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ctrlLDLApplicationInfo1.LoadLDLApplicationInfo(_LDLApplication.LDLApplicationID);
        }

        private void btnIssue_Click(object sender, EventArgs e) {

            if (MessageBox.Show("Are you sure you want to issue this license?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int NewLicenseID = _LDLApplication.IssueLicenseForTheFirstTime(txtNotes.Text, clsGlobalSettings.CurrentUser.UserID);

            if (NewLicenseID != -1) {

                MessageBox.Show($"License Issued Successfully with License ID: {NewLicenseID}",
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                MessageBox.Show("License Was not Issued!", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        // Close
        private void btnCancle_Click(object sender, EventArgs e) => Close();

    }
}