
namespace SKYNET.Controls
{
    partial class Group_Control
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
            this.BT_Register = new SKYNET_Button();
            this.PN_AddCareer = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.CB_SchoolCource = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TB_GroupName = new SKYNET.Controls.SKYNET_TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CB_Career = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PN_AddCareer.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            // PN_AddCareer
            // 
            this.PN_AddCareer.BackColor = System.Drawing.Color.White;
            this.PN_AddCareer.Controls.Add(this.panel6);
            this.PN_AddCareer.Controls.Add(this.label12);
            this.PN_AddCareer.Controls.Add(this.TB_GroupName);
            this.PN_AddCareer.Controls.Add(this.panel3);
            this.PN_AddCareer.Controls.Add(this.label7);
            this.PN_AddCareer.Controls.Add(this.label5);
            this.PN_AddCareer.Controls.Add(this.label4);
            this.PN_AddCareer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN_AddCareer.Location = new System.Drawing.Point(0, 0);
            this.PN_AddCareer.Name = "PN_AddCareer";
            this.PN_AddCareer.Padding = new System.Windows.Forms.Padding(1);
            this.PN_AddCareer.Size = new System.Drawing.Size(376, 420);
            this.PN_AddCareer.TabIndex = 14;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Controls.Add(this.CB_SchoolCource);
            this.panel6.Location = new System.Drawing.Point(21, 133);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(332, 35);
            this.panel6.TabIndex = 14;
            // 
            // CB_SchoolCource
            // 
            this.CB_SchoolCource.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CB_SchoolCource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_SchoolCource.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CB_SchoolCource.FormattingEnabled = true;
            this.CB_SchoolCource.Location = new System.Drawing.Point(3, 7);
            this.CB_SchoolCource.Name = "CB_SchoolCource";
            this.CB_SchoolCource.Size = new System.Drawing.Size(326, 25);
            this.CB_SchoolCource.TabIndex = 7;
            this.CB_SchoolCource.SelectedIndexChanged += new System.EventHandler(this.CB_SchoolCource_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(15, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "Curso";
            // 
            // TB_GroupName
            // 
            this.TB_GroupName.ActivatedBackColor = System.Drawing.Color.WhiteSmoke;
            this.TB_GroupName.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.TB_GroupName.Color = System.Drawing.Color.WhiteSmoke;
            this.TB_GroupName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_GroupName.IsPassword = false;
            this.TB_GroupName.Location = new System.Drawing.Point(21, 71);
            this.TB_GroupName.Logo = null;
            this.TB_GroupName.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_GroupName.Name = "TB_GroupName";
            this.TB_GroupName.ShowLogo = true;
            this.TB_GroupName.Size = new System.Drawing.Size(332, 35);
            this.TB_GroupName.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.CB_Career);
            this.panel3.Location = new System.Drawing.Point(21, 195);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 35);
            this.panel3.TabIndex = 11;
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
            this.label7.Location = new System.Drawing.Point(15, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Carrera";
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
            this.label5.Text = "AÑADIR GRUPO";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(18, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nombre del Grupo";
            // 
            // Group_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BT_Register);
            this.Controls.Add(this.PN_AddCareer);
            this.Name = "Group_Control";
            this.Size = new System.Drawing.Size(376, 420);
            this.PN_AddCareer.ResumeLayout(false);
            this.PN_AddCareer.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SKYNET_Button BT_Register;
        private System.Windows.Forms.Panel PN_AddCareer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox CB_Career;
        private System.Windows.Forms.Label label7;
        private SKYNET_TextBox TB_GroupName;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox CB_SchoolCource;
        private System.Windows.Forms.Label label12;
    }
}
