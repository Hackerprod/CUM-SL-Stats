
namespace SKYNET.Controls
{
    partial class Evaluation_Control
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CH_Semester = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.LB_StudentEvaluate = new System.Windows.Forms.Label();
            this.TB_Evaluation = new SKYNET.Controls.SKYNET_TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.CH_Subjects = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.BT_Register = new SKYNET_Button();
            this.PN_AddCareer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel22.SuspendLayout();
            this.SuspendLayout();
            // 
            // PN_AddCareer
            // 
            this.PN_AddCareer.BackColor = System.Drawing.Color.White;
            this.PN_AddCareer.Controls.Add(this.panel1);
            this.PN_AddCareer.Controls.Add(this.label1);
            this.PN_AddCareer.Controls.Add(this.panel25);
            this.PN_AddCareer.Controls.Add(this.TB_Evaluation);
            this.PN_AddCareer.Controls.Add(this.label22);
            this.PN_AddCareer.Controls.Add(this.panel22);
            this.PN_AddCareer.Controls.Add(this.label21);
            this.PN_AddCareer.Controls.Add(this.label19);
            this.PN_AddCareer.Controls.Add(this.label20);
            this.PN_AddCareer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN_AddCareer.Location = new System.Drawing.Point(0, 0);
            this.PN_AddCareer.Name = "PN_AddCareer";
            this.PN_AddCareer.Padding = new System.Windows.Forms.Padding(1);
            this.PN_AddCareer.Size = new System.Drawing.Size(376, 420);
            this.PN_AddCareer.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.CH_Semester);
            this.panel1.Location = new System.Drawing.Point(21, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 35);
            this.panel1.TabIndex = 20;
            // 
            // CH_Semester
            // 
            this.CH_Semester.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CH_Semester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CH_Semester.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CH_Semester.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CH_Semester.FormattingEnabled = true;
            this.CH_Semester.Items.AddRange(new object[] {
            "Seleccione el semestre a evaluar",
            "Primer semestre",
            "Segundo semestre"});
            this.CH_Semester.Location = new System.Drawing.Point(9, 7);
            this.CH_Semester.Name = "CH_Semester";
            this.CH_Semester.Size = new System.Drawing.Size(317, 25);
            this.CH_Semester.TabIndex = 4;
            this.CH_Semester.SelectedIndexChanged += new System.EventHandler(this.CH_Semester_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(18, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Semestre";
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel25.Controls.Add(this.LB_StudentEvaluate);
            this.panel25.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.panel25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel25.Location = new System.Drawing.Point(21, 66);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(332, 35);
            this.panel25.TabIndex = 16;
            // 
            // LB_StudentEvaluate
            // 
            this.LB_StudentEvaluate.AutoSize = true;
            this.LB_StudentEvaluate.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.LB_StudentEvaluate.Location = new System.Drawing.Point(9, 9);
            this.LB_StudentEvaluate.Name = "LB_StudentEvaluate";
            this.LB_StudentEvaluate.Size = new System.Drawing.Size(0, 17);
            this.LB_StudentEvaluate.TabIndex = 0;
            // 
            // TB_Evaluation
            // 
            this.TB_Evaluation.ActivatedBackColor = System.Drawing.Color.WhiteSmoke;
            this.TB_Evaluation.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.TB_Evaluation.Color = System.Drawing.Color.WhiteSmoke;
            this.TB_Evaluation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_Evaluation.IsPassword = false;
            this.TB_Evaluation.Location = new System.Drawing.Point(21, 259);
            this.TB_Evaluation.Logo = null;
            this.TB_Evaluation.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_Evaluation.Name = "TB_Evaluation";
            this.TB_Evaluation.ShowLogo = true;
            this.TB_Evaluation.Size = new System.Drawing.Size(332, 35);
            this.TB_Evaluation.TabIndex = 15;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label22.Location = new System.Drawing.Point(18, 239);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 17);
            this.label22.TabIndex = 14;
            this.label22.Text = "Evaluation";
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel22.Controls.Add(this.CH_Subjects);
            this.panel22.Location = new System.Drawing.Point(21, 194);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(332, 35);
            this.panel22.TabIndex = 13;
            // 
            // CH_Subjects
            // 
            this.CH_Subjects.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CH_Subjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CH_Subjects.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CH_Subjects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CH_Subjects.FormattingEnabled = true;
            this.CH_Subjects.Location = new System.Drawing.Point(9, 7);
            this.CH_Subjects.Name = "CH_Subjects";
            this.CH_Subjects.Size = new System.Drawing.Size(317, 25);
            this.CH_Subjects.TabIndex = 4;
            this.CH_Subjects.SelectedIndexChanged += new System.EventHandler(this.CH_Subjects_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label21.Location = new System.Drawing.Point(18, 174);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 17);
            this.label21.TabIndex = 12;
            this.label21.Text = "Asignatura";
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label19.Location = new System.Drawing.Point(1, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(374, 32);
            this.label19.TabIndex = 1;
            this.label19.Text = "EVALUAR ESTUDIANTE";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label20.Location = new System.Drawing.Point(18, 46);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 17);
            this.label20.TabIndex = 0;
            this.label20.Text = "Estudiante";
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
            this.BT_Register.Location = new System.Drawing.Point(138, 375);
            this.BT_Register.MenuMode = false;
            this.BT_Register.Name = "BT_Register";
            this.BT_Register.Rounded = false;
            this.BT_Register.Size = new System.Drawing.Size(100, 32);
            this.BT_Register.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Register.TabIndex = 13;
            this.BT_Register.Text = "Evaluar";
            this.BT_Register.Click += new System.EventHandler(this.BT_Register_Click);
            // 
            // Evaluation_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BT_Register);
            this.Controls.Add(this.PN_AddCareer);
            this.Name = "Evaluation_Control";
            this.Size = new System.Drawing.Size(376, 420);
            this.PN_AddCareer.ResumeLayout(false);
            this.PN_AddCareer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SKYNET_Button BT_Register;
        private System.Windows.Forms.Panel PN_AddCareer;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Label LB_StudentEvaluate;
        private SKYNET_TextBox TB_Evaluation;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.ComboBox CH_Subjects;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CH_Semester;
        private System.Windows.Forms.Label label1;
    }
}
