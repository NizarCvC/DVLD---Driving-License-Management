using DVLD_Business_Layer;
using DVLD_Project.Licenses.License_Classes;
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

namespace DVLD_Project.Manage_License_Classes_Screens {

    public partial class frmManageLicenseClasses : Form {

        public frmManageLicenseClasses() {

            InitializeComponent();
            _RefreshAll();
        }

        // Refreshing data
        private void _RefreshLicenseClassesList() {

            dgvLicenseClasses.DataSource = clsLicenseClass.GetAllLicenseClasses();
        }

        private void _RefreshNumberOfRecords() {

            lblNumberOfRecords.Text = clsGuna2ControlHelper.NumberOfRecords(dgvLicenseClasses).ToString();
        }

        private void _RefreshAll() {

            _RefreshLicenseClassesList();
            _RefreshNumberOfRecords();
        }

        // Edit Info
        private void editLicenseClassToolStripMenuItem_Click(object sender, EventArgs e) {

            frmEditLicenseClassInfo frm = new frmEditLicenseClassInfo((int)dgvLicenseClasses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        // Close
        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}