namespace DVLD_Project.Manage_LDL_Applications {
    partial class frmSceduleTestAppointments {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSceduleTestAppointments));
            this.lblTestTilte = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.dgvTestAppointments = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsAppointmentOptions = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.editAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlLDLApplicationInfo1 = new DVLD_Project.User_Controls.ctrlLDLApplicationInfo();
            this.btnAddNewTest = new Guna.UI2.WinForms.Guna2ImageButton();
            this.pbTestImage = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointments)).BeginInit();
            this.cmsAppointmentOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTestTilte
            // 
            this.lblTestTilte.Font = new System.Drawing.Font("Cascadia Mono", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestTilte.Location = new System.Drawing.Point(12, 174);
            this.lblTestTilte.Name = "lblTestTilte";
            this.lblTestTilte.Size = new System.Drawing.Size(1219, 57);
            this.lblTestTilte.TabIndex = 59;
            this.lblTestTilte.Text = "Vision Test Appointments";
            this.lblTestTilte.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.label2.Location = new System.Drawing.Point(12, 829);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 33);
            this.label2.TabIndex = 62;
            this.label2.Text = "Appointments:";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Cascadia Mono", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(985, 1055);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(31, 35);
            this.lblNumberOfRecords.TabIndex = 64;
            this.lblNumberOfRecords.Tag = "0";
            this.lblNumberOfRecords.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(804, 1054);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 35);
            this.label3.TabIndex = 63;
            this.label3.Text = "# Records:";
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Cascadia Mono", 10.125F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1070, 1031);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(161, 52);
            this.btnClose.TabIndex = 66;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvTestAppointments
            // 
            this.dgvTestAppointments.AllowUserToAddRows = false;
            this.dgvTestAppointments.AllowUserToDeleteRows = false;
            this.dgvTestAppointments.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.dgvTestAppointments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTestAppointments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTestAppointments.ColumnHeadersHeight = 50;
            this.dgvTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTestAppointments.ContextMenuStrip = this.cmsAppointmentOptions;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cascadia Mono", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTestAppointments.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTestAppointments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.dgvTestAppointments.Location = new System.Drawing.Point(-2, 875);
            this.dgvTestAppointments.Name = "dgvTestAppointments";
            this.dgvTestAppointments.ReadOnly = true;
            this.dgvTestAppointments.RowHeadersVisible = false;
            this.dgvTestAppointments.RowHeadersWidth = 82;
            this.dgvTestAppointments.RowTemplate.Height = 33;
            this.dgvTestAppointments.Size = new System.Drawing.Size(800, 219);
            this.dgvTestAppointments.TabIndex = 67;
            this.dgvTestAppointments.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Blue;
            this.dgvTestAppointments.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.dgvTestAppointments.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTestAppointments.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTestAppointments.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTestAppointments.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTestAppointments.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTestAppointments.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.dgvTestAppointments.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(242)))));
            this.dgvTestAppointments.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTestAppointments.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTestAppointments.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTestAppointments.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTestAppointments.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvTestAppointments.ThemeStyle.ReadOnly = true;
            this.dgvTestAppointments.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.dgvTestAppointments.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTestAppointments.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Cascadia Mono", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTestAppointments.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvTestAppointments.ThemeStyle.RowsStyle.Height = 33;
            this.dgvTestAppointments.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            this.dgvTestAppointments.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // cmsAppointmentOptions
            // 
            this.cmsAppointmentOptions.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            this.cmsAppointmentOptions.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsAppointmentOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAppointmentToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsAppointmentOptions.Name = "cmsLDLAppOptions";
            this.cmsAppointmentOptions.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsAppointmentOptions.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsAppointmentOptions.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsAppointmentOptions.RenderStyle.ColorTable = null;
            this.cmsAppointmentOptions.RenderStyle.RoundedEdges = true;
            this.cmsAppointmentOptions.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmsAppointmentOptions.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmsAppointmentOptions.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsAppointmentOptions.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsAppointmentOptions.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmsAppointmentOptions.Size = new System.Drawing.Size(329, 84);
            this.cmsAppointmentOptions.Opening += new System.ComponentModel.CancelEventHandler(this.cmsAppointmentOptions_Opening);
            // 
            // editAppointmentToolStripMenuItem
            // 
            this.editAppointmentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editAppointmentToolStripMenuItem.Image")));
            this.editAppointmentToolStripMenuItem.Name = "editAppointmentToolStripMenuItem";
            this.editAppointmentToolStripMenuItem.Size = new System.Drawing.Size(328, 40);
            this.editAppointmentToolStripMenuItem.Text = "Edit Appointment";
            this.editAppointmentToolStripMenuItem.Click += new System.EventHandler(this.editAppointmentToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("takeTestToolStripMenuItem.Image")));
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(328, 40);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // ctrlLDLApplicationInfo1
            // 
            this.ctrlLDLApplicationInfo1.Location = new System.Drawing.Point(-2, 244);
            this.ctrlLDLApplicationInfo1.Name = "ctrlLDLApplicationInfo1";
            this.ctrlLDLApplicationInfo1.Size = new System.Drawing.Size(1246, 607);
            this.ctrlLDLApplicationInfo1.TabIndex = 60;
            // 
            // btnAddNewTest
            // 
            this.btnAddNewTest.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnAddNewTest.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddNewTest.HoverState.ImageSize = new System.Drawing.Size(80, 80);
            this.btnAddNewTest.Image = global::DVLD_Project.Properties.Resources.add;
            this.btnAddNewTest.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAddNewTest.ImageRotate = 0F;
            this.btnAddNewTest.ImageSize = new System.Drawing.Size(70, 70);
            this.btnAddNewTest.Location = new System.Drawing.Point(1070, 864);
            this.btnAddNewTest.Name = "btnAddNewTest";
            this.btnAddNewTest.PressedState.ImageSize = new System.Drawing.Size(90, 90);
            this.btnAddNewTest.Size = new System.Drawing.Size(174, 131);
            this.btnAddNewTest.TabIndex = 65;
            this.btnAddNewTest.Click += new System.EventHandler(this.btnAddNewTest_Click);
            // 
            // pbTestImage
            // 
            this.pbTestImage.Image = global::DVLD_Project.Properties.Resources.eye_scan;
            this.pbTestImage.ImageRotate = 0F;
            this.pbTestImage.Location = new System.Drawing.Point(519, 12);
            this.pbTestImage.Name = "pbTestImage";
            this.pbTestImage.Size = new System.Drawing.Size(204, 159);
            this.pbTestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestImage.TabIndex = 58;
            this.pbTestImage.TabStop = false;
            // 
            // frmSceduleTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1243, 1098);
            this.Controls.Add(this.dgvTestAppointments);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewTest);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlLDLApplicationInfo1);
            this.Controls.Add(this.lblTestTilte);
            this.Controls.Add(this.pbTestImage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSceduleTestAppointments";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vision Test Appointments";
            this.Load += new System.EventHandler(this.frmSceduleTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointments)).EndInit();
            this.cmsAppointmentOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestTilte;
        private Guna.UI2.WinForms.Guna2PictureBox pbTestImage;
        private User_Controls.ctrlLDLApplicationInfo ctrlLDLApplicationInfo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ImageButton btnAddNewTest;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTestAppointments;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsAppointmentOptions;
        private System.Windows.Forms.ToolStripMenuItem editAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}