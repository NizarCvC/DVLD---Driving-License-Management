namespace DVLD_Project.Manage_LDL_Applications {
    partial class frmIssueDLForTheFirstTime {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ctrlLDLApplicationInfo1 = new DVLD_Project.User_Controls.ctrlLDLApplicationInfo();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox9 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancle = new Guna.UI2.WinForms.Guna2Button();
            this.btnIssue = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlLDLApplicationInfo1
            // 
            this.ctrlLDLApplicationInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlLDLApplicationInfo1.Name = "ctrlLDLApplicationInfo1";
            this.ctrlLDLApplicationInfo1.Size = new System.Drawing.Size(1247, 607);
            this.ctrlLDLApplicationInfo1.TabIndex = 0;
            // 
            // txtNotes
            // 
            this.txtNotes.Animated = true;
            this.txtNotes.AutoSize = true;
            this.txtNotes.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "";
            this.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.ForeColor = System.Drawing.Color.Black;
            this.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.Location = new System.Drawing.Point(204, 633);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PlaceholderText = "";
            this.txtNotes.SelectedText = "";
            this.txtNotes.Size = new System.Drawing.Size(1026, 164);
            this.txtNotes.TabIndex = 106;
            // 
            // guna2PictureBox9
            // 
            this.guna2PictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox9.Image = global::DVLD_Project.Properties.Resources.post_it;
            this.guna2PictureBox9.ImageRotate = 0F;
            this.guna2PictureBox9.Location = new System.Drawing.Point(143, 633);
            this.guna2PictureBox9.Name = "guna2PictureBox9";
            this.guna2PictureBox9.Size = new System.Drawing.Size(52, 35);
            this.guna2PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox9.TabIndex = 105;
            this.guna2PictureBox9.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cascadia Mono", 8.875F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(51, 633);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 32);
            this.label5.TabIndex = 104;
            this.label5.Text = "Notes:";
            // 
            // btnCancle
            // 
            this.btnCancle.Animated = true;
            this.btnCancle.AutoRoundedCorners = true;
            this.btnCancle.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancle.FillColor = System.Drawing.Color.White;
            this.btnCancle.Font = new System.Drawing.Font("Cascadia Mono", 10.125F);
            this.btnCancle.ForeColor = System.Drawing.Color.Black;
            this.btnCancle.Location = new System.Drawing.Point(915, 824);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(161, 52);
            this.btnCancle.TabIndex = 108;
            this.btnCancle.Text = "Cancel";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Animated = true;
            this.btnIssue.AutoRoundedCorners = true;
            this.btnIssue.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnIssue.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIssue.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIssue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIssue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIssue.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnIssue.Font = new System.Drawing.Font("Cascadia Mono", 10.125F);
            this.btnIssue.ForeColor = System.Drawing.Color.White;
            this.btnIssue.Location = new System.Drawing.Point(1093, 824);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(140, 52);
            this.btnIssue.TabIndex = 107;
            this.btnIssue.Text = "Issue";
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // frmIssueDLForTheFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1245, 901);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.guna2PictureBox9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ctrlLDLApplicationInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIssueDLForTheFirstTime";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue DL For The First Time";
            this.Load += new System.EventHandler(this.frmIssueDLForTheFirstTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private User_Controls.ctrlLDLApplicationInfo ctrlLDLApplicationInfo1;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox9;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnCancle;
        private Guna.UI2.WinForms.Guna2Button btnIssue;
    }
}