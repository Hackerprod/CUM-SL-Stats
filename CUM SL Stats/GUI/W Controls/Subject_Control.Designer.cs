
namespace SKYNET.Controls
{
    partial class Subject_Control
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
            this.PN_AddCareer = new System.Windows.Forms.Panel();
            this.TB_SubjectName = new SKYNET.Controls.SKYNET_TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BT_Register = new SKYNET_Button();
            this.PN_AddCareer.SuspendLayout();
            this.SuspendLayout();
            // 
            // PN_AddCareer
            // 
            this.PN_AddCareer.BackColor = System.Drawing.Color.White;
            this.PN_AddCareer.Controls.Add(this.TB_SubjectName);
            this.PN_AddCareer.Controls.Add(this.label5);
            this.PN_AddCareer.Controls.Add(this.label4);
            this.PN_AddCareer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN_AddCareer.Location = new System.Drawing.Point(0, 0);
            this.PN_AddCareer.Name = "PN_AddCareer";
            this.PN_AddCareer.Padding = new System.Windows.Forms.Padding(1);
            this.PN_AddCareer.Size = new System.Drawing.Size(376, 420);
            this.PN_AddCareer.TabIndex = 14;
            // 
            // TB_SubjectName
            // 
            this.TB_SubjectName.ActivatedBackColor = System.Drawing.Color.WhiteSmoke;
            this.TB_SubjectName.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.TB_SubjectName.Color = System.Drawing.Color.WhiteSmoke;
            this.TB_SubjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_SubjectName.IsPassword = false;
            this.TB_SubjectName.Location = new System.Drawing.Point(21, 65);
            this.TB_SubjectName.Logo = null;
            this.TB_SubjectName.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_SubjectName.Name = "TB_SubjectName";
            this.TB_SubjectName.ShowLogo = true;
            this.TB_SubjectName.Size = new System.Drawing.Size(332, 35);
            this.TB_SubjectName.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(1, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(374, 32);
            this.label5.TabIndex = 1;
            this.label5.Text = "AÑADIR ASIGNATURA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(18, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nombre de la Asignatura";
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
            // Subject_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BT_Register);
            this.Controls.Add(this.PN_AddCareer);
            this.Name = "Subject_Control";
            this.Size = new System.Drawing.Size(376, 420);
            this.PN_AddCareer.ResumeLayout(false);
            this.PN_AddCareer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private SKYNET_Button BT_Register;
        private System.Windows.Forms.Panel PN_AddCareer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private SKYNET_TextBox TB_SubjectName;
    }
}
