
namespace SKYNET.Controls
{
    partial class SchoolCource_Control
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PN_ScoolYear = new System.Windows.Forms.Panel();
            this.TB_CourseName = new SKYNET.Controls.SKYNET_TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BT_Register = new SKYNET_Button();
            this.PN_ScoolYear.SuspendLayout();
            this.SuspendLayout();
            // 
            // PN_ScoolYear
            // 
            this.PN_ScoolYear.BackColor = System.Drawing.Color.White;
            this.PN_ScoolYear.Controls.Add(this.TB_CourseName);
            this.PN_ScoolYear.Controls.Add(this.label8);
            this.PN_ScoolYear.Controls.Add(this.label9);
            this.PN_ScoolYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN_ScoolYear.Location = new System.Drawing.Point(0, 0);
            this.PN_ScoolYear.Name = "PN_ScoolYear";
            this.PN_ScoolYear.Padding = new System.Windows.Forms.Padding(1);
            this.PN_ScoolYear.Size = new System.Drawing.Size(376, 420);
            this.PN_ScoolYear.TabIndex = 12;
            // 
            // TB_CourseName
            // 
            this.TB_CourseName.ActivatedBackColor = System.Drawing.Color.WhiteSmoke;
            this.TB_CourseName.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.TB_CourseName.Color = System.Drawing.Color.WhiteSmoke;
            this.TB_CourseName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_CourseName.IsPassword = false;
            this.TB_CourseName.Location = new System.Drawing.Point(21, 71);
            this.TB_CourseName.Logo = null;
            this.TB_CourseName.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_CourseName.Name = "TB_CourseName";
            this.TB_CourseName.ShowLogo = true;
            this.TB_CourseName.Size = new System.Drawing.Size(332, 35);
            this.TB_CourseName.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(1, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(374, 32);
            this.label8.TabIndex = 1;
            this.label8.Text = "AÑADIR CURSO";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(18, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Curso escolar (Ejemplo 2021-2022)";
            // 
            // BT_Register
            // 
            this.BT_Register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(144)))), ((int)(((byte)(82)))));
            this.BT_Register.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Register.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_Register.ForeColor = System.Drawing.Color.White;
            this.BT_Register.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Register.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_Register.ImageIcon = null;
            this.BT_Register.Location = new System.Drawing.Point(138, 370);
            this.BT_Register.MenuMode = false;
            this.BT_Register.Name = "BT_Register";
            this.BT_Register.Rounded = false;
            this.BT_Register.Size = new System.Drawing.Size(100, 32);
            this.BT_Register.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Register.TabIndex = 13;
            this.BT_Register.Text = "Añadir";
            this.BT_Register.Click += new System.EventHandler(this.BT_Register_Click);
            // 
            // SchoolCource_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BT_Register);
            this.Controls.Add(this.PN_ScoolYear);
            this.Name = "SchoolCource_Control";
            this.Size = new System.Drawing.Size(376, 420);
            this.PN_ScoolYear.ResumeLayout(false);
            this.PN_ScoolYear.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PN_ScoolYear;
        private SKYNET.Controls.SKYNET_TextBox TB_CourseName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private SKYNET_Button BT_Register;
    }
}
