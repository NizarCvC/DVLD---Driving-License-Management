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

    public partial class frmLDLApplicationDetails : Form {

        private int _LDLApplicationID;

        public frmLDLApplicationDetails(int LDLApplicationID) {

            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
        }

        private void frmLDLApplicationDetails_Load(object sender, EventArgs e) {

            if (_LDLApplicationID > 0) {

                ctrlLDLApplicationInfo1.LoadLDLApplicationInfo(_LDLApplicationID);
            }
            else {

                MessageBox.Show("No data for loading", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}