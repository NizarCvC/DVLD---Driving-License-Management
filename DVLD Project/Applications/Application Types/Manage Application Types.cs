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

    public partial class frmManageApplicationTypes : Form {

        public frmManageApplicationTypes() {

            InitializeComponent();
            _RefreshAll();
        }

        // Refreshing data
        private void _RefreshApplicationTypeList() {

            dgvApplicationType.DataSource = clsApplicationType.GetAllApplicationTypes();
        }

        private void _RefreshNumberOfRecords() {

            lblNumberOfRecords.Text = clsGuna2ControlHelper.NumberOfRecords(dgvApplicationType).ToString();
        }

        private void _RefreshAll() {

            _RefreshApplicationTypeList();
            _RefreshNumberOfRecords();
        }

        // Update data
        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvApplicationType))
                return;

            frmUpdateApplicationType frm = new frmUpdateApplicationType((int)dgvApplicationType.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshAll();
        }

        // Close
        private void btnClose_Click(object sender, EventArgs e) => this.Close();

    }
}