using DVLD_Business_Layer;
using DVLD_Project;
using DVLD_Project.Manage_Application_Types_Screens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DVLD_Presentation_Layer {

    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLoginScreen frmLoginScreen = new frmLoginScreen();

            if (frmLoginScreen.ShowDialog() == DialogResult.OK) {

                Application.Run(new frmMainScreen());
            }

        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
