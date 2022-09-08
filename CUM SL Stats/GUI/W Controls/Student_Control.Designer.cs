
namespace SKYNET.Controls
{
    partial class Student_Control
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
            this.SexSelector = new SKYNET.GUI.Controls.SKYNET_SexSelector();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CB_Group = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_RegisterOther = new SKYNET_Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.CB_SchoolCource = new System.Windows.Forms.ComboBox();
            this.TB_CI = new SKYNET.Controls.SKYNET_TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CB_Career = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_StudentName = new SKYNET.Controls.SKYNET_TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BT_Register = new SKYNET_Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CB_Status = new System.Windows.Forms.ComboBox();
            this.PN_Student.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PN_Student
            // 
            this.PN_Student.BackColor = System.Drawing.Color.White;
            this.PN_Student.Controls.Add(this.panel2);
            this.PN_Student.Controls.Add(this.label3);
            this.PN_Student.Controls.Add(this.SexSelector);
            this.PN_Student.Controls.Add(this.label2);
            this.PN_Student.Controls.Add(this.panel1);
            this.PN_Student.Controls.Add(this.label1);
            this.PN_Student.Controls.Add(this.BT_RegisterOther);
            this.PN_Student.Controls.Add(this.panel6);
            this.PN_Student.Controls.Add(this.TB_CI);
            this.PN_Student.Controls.Add(this.label13);
            this.PN_Student.Controls.Add(this.panel3);
            this.PN_Student.Controls.Add(this.label12);
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
            // SexSelector
            // 
            this.SexSelector.BackColor = System.Drawing.Color.White;
            this.SexSelector.BlockSelector = false;
            this.SexSelector.Location = new System.Drawing.Point(64, 323);
            this.SexSelector.Name = "SexSelector";
            this.SexSelector.Sex = SKYNET.Models.Sex.Unknown;
            this.SexSelector.Size = new System.Drawing.Size(72, 38);
            this.SexSelector.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(18, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Sexo";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.CB_Group);
            this.panel1.Location = new System.Drawing.Point(21, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 35);
            this.panel1.TabIndex = 16;
            // 
            // CB_Group
            // 
            this.CB_Group.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CB_Group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Group.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CB_Group.FormattingEnabled = true;
            this.CB_Group.Location = new System.Drawing.Point(3, 7);
            this.CB_Group.Name = "CB_Group";
            this.CB_Group.Size = new System.Drawing.Size(326, 25);
            this.CB_Group.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(18, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Seleccione el Grupo o cree uno nuevo";
            // 
            // BT_RegisterOther
            // 
            this.BT_RegisterOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(144)))), ((int)(((byte)(82)))));
            this.BT_RegisterOther.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_RegisterOther.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_RegisterOther.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_RegisterOther.ForeColor = System.Drawing.Color.White;
            this.BT_RegisterOther.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_RegisterOther.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_RegisterOther.ImageIcon = null;
            this.BT_RegisterOther.Location = new System.Drawing.Point(176, 370);
            this.BT_RegisterOther.MenuMode = false;
            this.BT_RegisterOther.Name = "BT_RegisterOther";
            this.BT_RegisterOther.Rounded = false;
            this.BT_RegisterOther.Size = new System.Drawing.Size(143, 32);
            this.BT_RegisterOther.Style = SKYNET_Button._Style.TextOnly;
            this.BT_RegisterOther.TabIndex = 14;
            this.BT_RegisterOther.Text = "Añadir y crear otro";
            this.BT_RegisterOther.Click += new System.EventHandler(this.BT_RegisterOther_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Controls.Add(this.CB_SchoolCource);
            this.panel6.Location = new System.Drawing.Point(21, 166);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(332, 35);
            this.panel6.TabIndex = 12;
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
            // TB_CI
            // 
            this.TB_CI.ActivatedBackColor = System.Drawing.Color.WhiteSmoke;
            this.TB_CI.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.TB_CI.Color = System.Drawing.Color.WhiteSmoke;
            this.TB_CI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_CI.IsPassword = false;
            this.TB_CI.Location = new System.Drawing.Point(21, 108);
            this.TB_CI.Logo = null;
            this.TB_CI.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_CI.Name = "TB_CI";
            this.TB_CI.ShowLogo = true;
            this.TB_CI.Size = new System.Drawing.Size(332, 35);
            this.TB_CI.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(18, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 17);
            this.label13.TabIndex = 10;
            this.label13.Text = "Carné de Identidad";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.CB_Career);
            this.panel3.Location = new System.Drawing.Point(21, 223);
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
            this.CB_Career.SelectedIndexChanged += new System.EventHandler(this.CB_Career_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(18, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(174, 17);
            this.label12.TabIndex = 5;
            this.label12.Text = "Curso en el que se matricula";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(18, 204);
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
            this.TB_StudentName.TextChanged += TB_StudentName_TextChanged;
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
            this.label11.Size = new System.Drawing.Size(125, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Nombre y Apellidos";
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
            this.BT_Register.Location = new System.Drawing.Point(56, 370);
            this.BT_Register.MenuMode = false;
            this.BT_Register.Name = "BT_Register";
            this.BT_Register.Rounded = false;
            this.BT_Register.Size = new System.Drawing.Size(100, 32);
            this.BT_Register.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Register.TabIndex = 13;
            this.BT_Register.Text = "Añadir";
            this.BT_Register.Click += new System.EventHandler(this.BT_Register_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(173, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Estado";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.CB_Status);
            this.panel2.Location = new System.Drawing.Point(232, 327);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(121, 32);
            this.panel2.TabIndex = 20;
            // 
            // CB_Status
            // 
            this.CB_Status.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CB_Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Status.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CB_Status.FormattingEnabled = true;
            this.CB_Status.Items.AddRange(new object[] {
            "Desconocido",
            "Activo",
            "Graduado",
            "Baja"});
            this.CB_Status.Location = new System.Drawing.Point(3, 4);
            this.CB_Status.Name = "CB_Status";
            this.CB_Status.Size = new System.Drawing.Size(115, 25);
            this.CB_Status.TabIndex = 7;
            // 
            // Student_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BT_Register);
            this.Controls.Add(this.PN_Student);
            this.Name = "Student_Control";
            this.Size = new System.Drawing.Size(376, 420);
            this.PN_Student.ResumeLayout(false);
            this.PN_Student.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SKYNET_Button BT_Register;
        private System.Windows.Forms.Panel PN_Student;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox CB_SchoolCource;
        private SKYNET_TextBox TB_CI;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox CB_Career;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private SKYNET_TextBox TB_StudentName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private SKYNET_Button BT_RegisterOther;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CB_Group;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private GUI.Controls.SKYNET_SexSelector SexSelector;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox CB_Status;
        private System.Windows.Forms.Label label3;
    }
}
