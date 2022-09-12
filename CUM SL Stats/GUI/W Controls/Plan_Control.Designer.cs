
namespace SKYNET.Controls
{
    partial class Plan_Control
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
            this.PN_Student = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CB_Career = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_StudentName = new SKYNET.Controls.SKYNET_TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BT_Register = new SKYNET_Button();
            this.PN_Student.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PN_Student
            // 
            this.PN_Student.BackColor = System.Drawing.Color.White;
            this.PN_Student.Controls.Add(this.panel3);
            this.PN_Student.Controls.Add(this.label7);
            this.PN_Student.Controls.Add(this.TB_StudentName);
            this.PN_Student.Controls.Add(this.label10);
            this.PN_Student.Controls.Add(this.label11);
            this.PN_Student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN_Student.Location = new System.Drawing.Point(0, 0);
            this.PN_Student.Name = "PN_Student";
            this.PN_Student.Padding = new System.Windows.Forms.Padding(1);
            this.PN_Student.Size = new System.Drawing.Size(376, 420);
            this.PN_Student.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.CB_Career);
            this.panel3.Location = new System.Drawing.Point(21, 111);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 35);
            this.panel3.TabIndex = 9;
            // 
            // CB_Career
            // 
            this.CB_Career.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CB_Career.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Career.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CB_Career.FormattingEnabled = true;
            this.CB_Career.Location = new System.Drawing.Point(3, 7);
            this.CB_Career.Name = "CB_Career";
            this.CB_Career.Size = new System.Drawing.Size(326, 25);
            this.CB_Career.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(18, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Carrera";
            // 
            // TB_StudentName
            // 
            this.TB_StudentName.ActivatedBackColor = System.Drawing.Color.WhiteSmoke;
            this.TB_StudentName.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.TB_StudentName.Color = System.Drawing.Color.WhiteSmoke;
            this.TB_StudentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_StudentName.IsPassword = false;
            this.TB_StudentName.Location = new System.Drawing.Point(21, 52);
            this.TB_StudentName.Logo = null;
            this.TB_StudentName.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_StudentName.Name = "TB_StudentName";
            this.TB_StudentName.ShowLogo = true;
            this.TB_StudentName.Size = new System.Drawing.Size(332, 35);
            this.TB_StudentName.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(1, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(374, 32);
            this.label10.TabIndex = 1;
            this.label10.Text = "AÑADIR ESTUDIANTE";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(18, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Nombre";
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
            this.BT_Register.Location = new System.Drawing.Point(131, 370);
            this.BT_Register.MenuMode = false;
            this.BT_Register.Name = "BT_Register";
            this.BT_Register.Rounded = false;
            this.BT_Register.Size = new System.Drawing.Size(100, 32);
            this.BT_Register.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Register.TabIndex = 13;
            this.BT_Register.Text = "Añadir";
            this.BT_Register.Click += new System.EventHandler(this.BT_Register_Click);
            // 
            // Plan_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BT_Register);
            this.Controls.Add(this.PN_Student);
            this.Name = "Plan_Control";
            this.Size = new System.Drawing.Size(376, 420);
            this.PN_Student.ResumeLayout(false);
            this.PN_Student.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SKYNET_Button BT_Register;
        private System.Windows.Forms.Panel PN_Student;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox CB_Career;
        private System.Windows.Forms.Label label7;
        private SKYNET_TextBox TB_StudentName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}
