using DVLD_Business_Layer;
using DVLD_Project.Manage_Licenses_Screens;
using My_Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Manage_Detained_Licenses_Screens {

    public partial class frmDetainLicense : Form {

        private int _LicenseID;
        private clsDetainedLicense _DetainedLicense;

        public frmDetainLicense() => InitializeComponent();

        private void btnDetain_Click(object sender, EventArgs e) {

            if (!this.ValidateChildren()) {

                MessageBox.Show("Invalid information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clsLicense.IsLicenseActive(_LicenseID)) {

                MessageBox.Show("Connot detain this license because it is not active.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsDetainedLicense.IsLicenseDetained(_LicenseID)) {

                MessageBox.Show("Connot detain this license because it is already detained.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _DetainedLicense = clsLicense.FindByLicenseID(_LicenseID)
                .DetainLicense(clsUtil.CheckIfValidDecimal(txtFineFees.Text),
                clsGlobalSettings.CurrentUser.UserID);

            if (_DetainedLicense != null) {

                MessageBox.Show($"License Detained Successfully with ID: {_DetainedLicense.DetainID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtFineFees.Enabled = false;
            btnDetain.Enabled = false;
            ctrlFilterLicense1.FilterEnabled = false;
            lnklblShowDetainedLicInfo.Enabled = true;
            _DisplayDetainedLicenseInfo();
        }

        private void _DisplayDetainedLicenseInfo() {

            lblDetainID.Text = _DetainedLicense.DetainID.ToString();
            lblDetainDate.Text = _DetainedLicense.DetainDate.ToShortDateString();
            lblLicenseID.Text = _DetainedLicense.LicenseID.ToString();
            lblCreatedBy.Text = _DetainedLicense.CreatedByUserInfo.Username;
        }

        private void ctrlFilterLicense1_OnLicenseIDFound(object sender, User_Controls.ctrlFilterLicense.LicenseIDEventArgs e) {

            _LicenseID = e.LicenseID;
        }

        // Validate input of fine fees
        private void txtFineFees_Validating(object sender, CancelEventArgs e) {

            clsGuna2ControlHelper.ValidateRequiredTextBox(txtFineFees, e, errorProvider1, "Fine Fees shouldn't be empty!");
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // Link
        private void lnklblShowDetainedLicInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            frmLicenseDetails frm = new frmLicenseDetails(_DetainedLicense.LicenseID, frmLicenseDetails.enIDType.LicenseID);
            frm.ShowDialog();
        }

        // Close
        private void btnCancle_Click(object sender, EventArgs e) => Close();

    }
}