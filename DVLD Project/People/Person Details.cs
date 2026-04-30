using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project {

    public partial class frmPersonDetails : Form {

        public frmPersonDetails(int PersonID) {

            InitializeComponent();
            ctrlPersonCard.LoadPersonInfo(PersonID);
        }

        public frmPersonDetails(string NationalNo) {

            InitializeComponent();
            ctrlPersonCard.LoadPersonInfo(NationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}