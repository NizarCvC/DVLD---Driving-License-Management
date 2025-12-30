using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace My_Libraries {

    public static class clsGuna2ControlHelper {

        public static void ValidateRequiredTextBox(Guna2TextBox textBox, CancelEventArgs e, ErrorProvider errorProvider, string errorMessage) {

            if (string.IsNullOrWhiteSpace(textBox.Text)) {

                e.Cancel = true;
                textBox.Focus();
                errorProvider.SetError(textBox, errorMessage);
            }
            else {

                e.Cancel = false;
                errorProvider.SetError(textBox, null);
            }
        }

        public static bool IsDataGridViewRowSelected(Guna2DataGridView dataGridView, string Message = "Please choose a row.", string Title = "Error", MessageBoxIcon messageBoxIcon = MessageBoxIcon.Error) {

            if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.Index < 0) {

                MessageBox.Show(Message, Title, MessageBoxButtons.OK, messageBoxIcon);
                return false;
            }

            return true;
        }

        public static void TogglePasswordVisibility(Guna2TextBox sender, ref bool PasswordVisible, Image Show, Image Hide) {

            PasswordVisible = !PasswordVisible;
            sender.IconRight = PasswordVisible ? Show : Hide;
            sender.UseSystemPasswordChar = !PasswordVisible;
        }

        public static int NumberOfRecords(Guna2DataGridView dataGridView) {

            return dataGridView.AllowUserToAddRows ? dataGridView.Rows.Count - 1 : dataGridView.Rows.Count;
        }

    }
}
