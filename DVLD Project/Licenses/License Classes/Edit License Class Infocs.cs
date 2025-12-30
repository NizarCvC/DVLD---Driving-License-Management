using DVLD_Business_Layer;
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

namespace DVLD_Project.Licenses.License_Classes {

    public partial class frmEditLicenseClassInfo : Form {

        private clsLicenseClass _LicenseClass;

        public frmEditLicenseClassInfo(int LicenseClassID) {

            InitializeComponent();
            _LicenseClass = clsLicenseClass.Find(LicenseClassID);
        }

        private void frmEditLicenseClassInfo_Load(object sender, EventArgs e) {

            if (_LicenseClass == null) {

                MessageBox.Show("There is no license class to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _LoadData();
        }

        private void _LoadData() {

            lblClassID.Text = _LicenseClass.LicenseClassID.ToString();
            lblClassName.Text = _LicenseClass.ClassName;
            txtFees.Text = _LicenseClass.ClassFees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e) {

            if (!this.ValidateChildren()) {

                MessageBox.Show("Invalid information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to save this info?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            decimal feesClass = clsUtil.CheckIfValidDecimal(txtFees.Text);

            if (feesClass == 0) {

                MessageBox.Show("Fees mustn't be zero.\nPlease enter valid fees amount.", "Warnings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _LicenseClass.ClassFees = feesClass;

            if (_LicenseClass.Save()) {

                MessageBox.Show("Data Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else {

                MessageBox.Show("Data is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validate fees to be only numbers
        private void txtFees_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if (e.KeyChar == '.' && txtFees.Text.Contains("."))
                e.Handled = true;
        }

        // Validate fees input
        private void txtFees_Validating(object sender, CancelEventArgs e) {

            clsGuna2ControlHelper.ValidateRequiredTextBox(txtFees, e, errorProvider1, "The fees mustn't be empty");
        }
        
        // Close
        private void btnCancle_Click(object sender, EventArgs e) => Close();

    }
}