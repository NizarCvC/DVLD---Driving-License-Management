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

namespace DVLD_Project.Manage_Application_Types_Screens {

    public partial class frmUpdateApplicationType : Form {

        private int _TypeID;
        private clsApplicationType _ApplicationType;

        public frmUpdateApplicationType(int TypeID) {

            InitializeComponent();
            _TypeID = TypeID;
        }

        // Loading and save data
        private void frmUpdateApplicationType_Load(object sender, EventArgs e) => _LoadData();

        private void _LoadData() {

            _ApplicationType = clsApplicationType.Find(_TypeID);

            if (_ApplicationType == null) {

                MessageBox.Show($"The operation will be cancled because no application type with ID {_TypeID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblTypeID.Text = _ApplicationType.TypeID.ToString();
            txtTitle.Text = _ApplicationType.Title;
            txtFees.Text = _ApplicationType.Fees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e) {

            if (!this.ValidateChildren()) {

                MessageBox.Show("Invalid information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to save this info?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _ApplicationType.Title = txtTitle.Text;

            if (!decimal.TryParse(txtFees.Text, out decimal fees)) {

                MessageBox.Show("Please enter a valid number for fees.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _ApplicationType.Fees = fees;

            if (_ApplicationType.Save()) {

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
        private void btnCancle_Click(object sender, EventArgs e) => this.Close();
    
    }
}