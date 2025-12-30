using DVLD_Business_Layer;
using DVLD_Project.Manage_Licenses_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.User_Controls {

    public partial class ctrlLDLApplicationInfo : UserControl {

        private clsLocalDrivingLicenseApplication _LDLApplication;

        public ctrlLDLApplicationInfo() => InitializeComponent();

        // Loading info
        public void LoadLDLApplicationInfo(int LDLApplicationID) {

            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLAppID(LDLApplicationID);

            if (_LDLApplication == null) {

                _ResetToDefault();
                MessageBox.Show($"No Application with ApplicationID: {LDLApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DisplayLDLApplicationInfo();
        }

        // Print info in the form
        private void _DisplayLDLApplicationInfo() {

            lnklblShowLicenseInfo.Enabled = _LDLApplication.Application.ApplicationStatusTemp == 2;

            lblLDLAppID.Text = _LDLApplication.LDLApplicationID.ToString();
            lblAppliedLicense.Text = _LDLApplication.LicenseClass.ClassName;
            lblPassedTests.Text = clsTest.NumberOfPassedTests(_LDLApplication.LDLApplicationID).ToString() + "/3";
            lblAppID.Text = _LDLApplication.ApplicationID.ToString();
            lblStatus.Text = _HandleApplicationStatus(_LDLApplication.Application.ApplicationStatusTemp);
            lblFees.Text = _LDLApplication.Application.PaidFees.ToString();
            lblType.Text = _LDLApplication.Application.ApplicationTypeInfo.Title;
            lblApplicantName.Text = _LDLApplication.Application.PersonInfo.FullName;
            lblDate.Text = _LDLApplication.Application.ApplicationDate.ToShortDateString();
            lblLastStatusDate.Text = _LDLApplication.Application.LastStatusDate.ToShortDateString();
            lblCreatedByUser.Text = _LDLApplication.Application.CreatedByUserInfo.Username;
        }

        // Handle the status of application
        private string _HandleApplicationStatus(byte StatusNumber) {

            switch (StatusNumber) {

                case 0:
                return "Cancelled";
                case 1:
                return "New";
                case 2:
                return "Completed";
                default:
                return "No info";
            }
        }

        // Reset form
        private void _ResetToDefault() {

            lblLDLAppID.Text = "N/A";
            lblAppliedLicense.Text = "N/A";
            lblPassedTests.Text = "N/A";
            lblAppID.Text = "N/A";
            lblStatus.Text = "N/A";
            lblFees.Text = "N/A";
            lblType.Text = "N/A";
            lblApplicantName.Text = "N/A";
            lblDate.Text = "N/A";
            lblLastStatusDate.Text = "N/A";
            lblCreatedByUser.Text = "N/A";
        }

        // Links to open another forms
        private void lnklblShowApplicantInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            frmPersonDetails frm = new frmPersonDetails(_LDLApplication.Application.ApplicantPersonID);
            frm.ShowDialog();

            LoadLDLApplicationInfo(_LDLApplication.LDLApplicationID);
        }

        private void lnklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            frmLicenseDetails frm = new frmLicenseDetails(_LDLApplication.ApplicationID, frmLicenseDetails.enIDType.ApplicationID);
            frm.ShowDialog();
        }

    }
}