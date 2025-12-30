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

namespace DVLD_Project.Manage_Test_Types_Screens {

    public partial class frmUpdateTestType : Form {

        private clsTestType.enTestType _ID;
        private clsTestType _TestType;

        public frmUpdateTestType(clsTestType.enTestType TestTypeID) {

            InitializeComponent();
            _ID = TestTypeID;
        }

        // Loading and save data
        private void frmUpdateTestType_Load(object sender, EventArgs e) {

            _LoadData();
        }

        private void _LoadData() {

            _TestType = clsTestType.Find(_ID);

            if (_TestType == null) {

                MessageBox.Show($"The operation will be cancled because no test type with ID {(int)_ID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblID.Text = _TestType.ID.ToString();
            txtTitle.Text = _TestType.Title;
            txtDescription.Text = _TestType.Description;
            txtFees.Text = _TestType.Fees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e) {

            if (!this.ValidateChildren()) {

                MessageBox.Show("Invalid information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to save this info?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _TestType.Title = txtTitle.Text;
            _TestType.Description = txtDescription.Text;

            if (!decimal.TryParse(txtFees.Text, out decimal fees)) {

                MessageBox.Show("Please enter a valid number for fees.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _TestType.Fees = fees;

            if (_TestType.Save()) {

                MessageBox.Show("Data Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else {

                MessageBox.Show("Data is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validation for valid data
        private void txtTitle_Validating(object sender, CancelEventArgs e) {

            clsGuna2ControlHelper.ValidateRequiredTextBox(txtTitle, e, errorProvider1, "Title shouldn't be empty!");
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e) {

            clsGuna2ControlHelper.ValidateRequiredTextBox(txtDescription, e, errorProvider1, "Description shouldn't be empty!");
        }

        private void txtFees_Validating(object sender, CancelEventArgs e) {

            clsGuna2ControlHelper.ValidateRequiredTextBox(txtFees, e, errorProvider1, "Fees shouldn't be empty!");
        }

        // Valdation on keyboard
        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if (e.KeyChar == '.' && txtFees.Text.Contains("."))
                e.Handled = true;
        }

        // Close
        private void btnCancel_Click(object sender, EventArgs e) => Close();

    }
}