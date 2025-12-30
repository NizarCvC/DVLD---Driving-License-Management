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

namespace DVLD_Project.Manage_Test_Types_Screens {

    public partial class frmManageTestTypes : Form {

        public frmManageTestTypes() {

            InitializeComponent();
            _RefreshAll();
        }

        // Refreshing data
        private void _RefreshTestTypeList() {

            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();
        }

        private void _RefreshNumberOfRecords() {

            lblNumberOfRecords.Text = clsTestType.NumberOfTestTypes().ToString();
        }

        private void _RefreshAll() {

            _RefreshTestTypeList();
            _RefreshNumberOfRecords();
        }

        // Update data
        private void updateTestTypeToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvTestTypes))
                return;

            frmUpdateTestType frm = new frmUpdateTestType((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshTestTypeList();
        }

        // Close
        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}