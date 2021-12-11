
namespace SKYNET.GUI.W_Controls
{
    partial class SubjectList_Control
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel28 = new System.Windows.Forms.Panel();
            this.CH_SchoolCource = new System.Windows.Forms.ComboBox();
            this.panel29 = new System.Windows.Forms.Panel();
            this.CH_Career = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CH_Semester = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_Show = new SKYNET_Button();
            this.TB_SubjectName = new SKYNET.Controls.SKYNET_TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BT_AddSubject = new SKYNET_Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.LV_Subjects = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel16 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel28.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel28.Controls.Add(this.CH_SchoolCource);
            this.panel28.Location = new System.Drawing.Point(36, 50);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(332, 35);
            this.panel28.TabIndex = 29;
            // 
            // CH_SchoolCource
            // 
            this.CH_SchoolCource.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CH_SchoolCource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CH_SchoolCource.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CH_SchoolCource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CH_SchoolCource.FormattingEnabled = true;
            this.CH_SchoolCource.Location = new System.Drawing.Point(6, 5);
            this.CH_SchoolCource.Name = "CH_SchoolCource";
            this.CH_SchoolCource.Size = new System.Drawing.Size(323, 25);
            this.CH_SchoolCource.TabIndex = 7;
            this.CH_SchoolCource.SelectedIndexChanged += new System.EventHandler(this.CB_SchoolCource_SelectedIndexChanged);
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel29.Controls.Add(this.CH_Career);
            this.panel29.Location = new System.Drawing.Point(36, 108);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(332, 35);
            this.panel29.TabIndex = 28;
            // 
            // CH_Career
            // 
            this.CH_Career.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CH_Career.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CH_Career.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CH_Career.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CH_Career.FormattingEnabled = true;
            this.CH_Career.Location = new System.Drawing.Point(6, 5);
            this.CH_Career.Name = "CH_Career";
            this.CH_Career.Size = new System.Drawing.Size(323, 25);
            this.CH_Career.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label20.Location = new System.Drawing.Point(33, 29);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 17);
            this.label20.TabIndex = 27;
            this.label20.Text = "Curso";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label21.Location = new System.Drawing.Point(33, 88);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 17);
            this.label21.TabIndex = 26;
            this.label21.Text = "Carrera";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.CH_Semester);
            this.panel1.Location = new System.Drawing.Point(36, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 35);
            this.panel1.TabIndex = 36;
            // 
            // CH_Semester
            // 
            this.CH_Semester.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CH_Semester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CH_Semester.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CH_Semester.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CH_Semester.FormattingEnabled = true;
            this.CH_Semester.Items.AddRange(new object[] {
            "Ambos semestres",
            "Primer semestre",
            "Segundo semestre"});
            this.CH_Semester.Location = new System.Drawing.Point(6, 5);
            this.CH_Semester.Name = "CH_Semester";
            this.CH_Semester.Size = new System.Drawing.Size(323, 25);
            this.CH_Semester.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(33, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "Semestre";
            // 
            // BT_Show
            // 
            this.BT_Show.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(144)))), ((int)(((byte)(82)))));
            this.BT_Show.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Show.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_Show.ForeColor = System.Drawing.Color.White;
            this.BT_Show.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Show.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_Show.ImageIcon = null;
            this.BT_Show.Location = new System.Drawing.Point(268, 220);
            this.BT_Show.MenuMode = false;
            this.BT_Show.Name = "BT_Show";
            this.BT_Show.Rounded = false;
            this.BT_Show.Size = new System.Drawing.Size(100, 32);
            this.BT_Show.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Show.TabIndex = 37;
            this.BT_Show.Text = "Mostrar";
            this.BT_Show.Click += new System.EventHandler(this.BT_Show_Click);
            // 
            // TB_SubjectName
            // 
            this.TB_SubjectName.ActivatedBackColor = System.Drawing.Color.WhiteSmoke;
            this.TB_SubjectName.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.TB_SubjectName.Color = System.Drawing.Color.WhiteSmoke;
            this.TB_SubjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_SubjectName.IsPassword = false;
            this.TB_SubjectName.Location = new System.Drawing.Point(36, 352);
            this.TB_SubjectName.Logo = null;
            this.TB_SubjectName.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_SubjectName.Name = "TB_SubjectName";
            this.TB_SubjectName.ShowLogo = true;
            this.TB_SubjectName.Size = new System.Drawing.Size(332, 35);
            this.TB_SubjectName.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(32, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(336, 32);
            this.label5.TabIndex = 39;
            this.label5.Text = "AÑADIR ASIGNATURA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(33, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "Nombre de la Asignatura";
            // 
            // BT_AddSubject
            // 
            this.BT_AddSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(144)))), ((int)(((byte)(82)))));
            this.BT_AddSubject.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_AddSubject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_AddSubject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_AddSubject.ForeColor = System.Drawing.Color.White;
            this.BT_AddSubject.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_AddSubject.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_AddSubject.ImageIcon = null;
            this.BT_AddSubject.Location = new System.Drawing.Point(268, 396);
            this.BT_AddSubject.MenuMode = false;
            this.BT_AddSubject.Name = "BT_AddSubject";
            this.BT_AddSubject.Rounded = false;
            this.BT_AddSubject.Size = new System.Drawing.Size(100, 32);
            this.BT_AddSubject.Style = SKYNET_Button._Style.TextOnly;
            this.BT_AddSubject.TabIndex = 41;
            this.BT_AddSubject.Text = "Agregar";
            this.BT_AddSubject.Click += new System.EventHandler(this.BT_AddSubject_Click);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.panel17);
            this.panel13.Location = new System.Drawing.Point(411, 50);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(2);
            this.panel13.Size = new System.Drawing.Size(513, 480);
            this.panel13.TabIndex = 42;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.White;
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Controls.Add(this.panel16);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(2, 44);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(3);
            this.panel14.Size = new System.Drawing.Size(509, 434);
            this.panel14.TabIndex = 2;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.LV_Subjects);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(3, 28);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panel15.Size = new System.Drawing.Size(503, 403);
            this.panel15.TabIndex = 3;
            // 
            // LV_Subjects
            // 
            this.LV_Subjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LV_Subjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader1});
            this.LV_Subjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_Subjects.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.LV_Subjects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LV_Subjects.FullRowSelect = true;
            this.LV_Subjects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Subjects.Location = new System.Drawing.Point(10, 0);
            this.LV_Subjects.Name = "LV_Subjects";
            this.LV_Subjects.Size = new System.Drawing.Size(483, 393);
            this.LV_Subjects.TabIndex = 2;
            this.LV_Subjects.UseCompatibleStateImageBehavior = false;
            this.LV_Subjects.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "--";
            this.columnHeader5.Width = 22;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Nombre";
            this.columnHeader6.Width = 298;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.label7);
            this.panel16.Controls.Add(this.label10);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(3, 3);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(503, 25);
            this.panel16.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(333, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Semestre";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(36, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Nombre";
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel17.Controls.Add(this.label12);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(2, 2);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(509, 42);
            this.panel17.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(509, 39);
            this.label12.TabIndex = 1;
            this.label12.Text = "ASIGNATURAS";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Semester";
            this.columnHeader1.Width = 154;
            // 
            // SubjectList_Control
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.BT_AddSubject);
            this.Controls.Add(this.TB_SubjectName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BT_Show);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel28);
            this.Controls.Add(this.panel29);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Name = "SubjectList_Control";
            this.Size = new System.Drawing.Size(968, 556);
            this.panel28.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.ComboBox CH_SchoolCource;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.ComboBox CH_Career;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CH_Semester;
        private System.Windows.Forms.Label label1;
        private SKYNET_Button BT_Show;
        private SKYNET.Controls.SKYNET_TextBox TB_SubjectName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private SKYNET_Button BT_AddSubject;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.ListView LV_Subjects;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
