using DVLD_Business_Layer;
using DVLD_Project.Manage_International_Licenses_Screens;
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

namespace DVLD_Project.Manage_Licenses_Screens {

    public partial class frmLicenseHistory : Form {

        public enum enIDType { LDLApplicationID = 1, DriverID = 2 }
        private enIDType _IDType;
        private clsDriver Driver;

        public frmLicenseHistory(int ID, enIDType IDType) {

            InitializeComponent();
            _IDType = IDType;

            if (_IDType == enIDType.LDLApplicationID)
                Driver = clsDriver.FindByPersonID(clsLocalDrivingLicenseApplication.FindByLDLAppID(ID).Application.ApplicantPersonID);
            else
                Driver = clsDriver.FindByDriverID(ID);
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e) {

            if (Driver == null) {

                MessageBox.Show("This person is not a driver in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlPersonInfo1.LoadPersonInfo(Driver.PersonID);
            dgvAllDriverLocalLicenses.DataSource = clsLicense.GetAllLocalLicensesForDriver(Driver.DriverID);
            dgvAllInternationalLicenses.DataSource = clsInternationalLicense.GetAllInternationalLicensesForDriver(Driver.DriverID);
        }

        private void showLocalLicenseToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllDriverLocalLicenses))
                return;

            frmLicenseDetails frm = new frmLicenseDetails((int)dgvAllDriverLocalLicenses.CurrentRow.Cells[0].Value, frmLicenseDetails.enIDType.LicenseID);
            frm.ShowDialog();
        }

        private void showInternationalLicense_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllInternationalLicenses))
                return;

            frmInternationalLicenseDetails frm = new frmInternationalLicenseDetails((int)dgvAllInternationalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

    }
}