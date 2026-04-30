using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Manage_People_Screens {

    public partial class frmUserDetails : Form {

        private int? _UserID = null;
        private string _Username = null;

        public frmUserDetails(int UserID) {

            InitializeComponent();
            _UserID = UserID;
            _Username = null;
        }

        public frmUserDetails(string Username) {

            InitializeComponent();
            _Username = Username;
            _UserID = null;
        }

        private void frmUserDetails_Load(object sender, EventArgs e) {

            if (_UserID.HasValue) {

                ctrlUserInfo.LoadUserInfo(_UserID.Value);
            }
            else if (!string.IsNullOrWhiteSpace(_Username)) {

                ctrlUserInfo.LoadUserInfo(_Username);
            }
            else {

                MessageBox.Show("No data for loading", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}