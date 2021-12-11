
namespace SKYNET.GUI.W_Controls
{
    partial class StatsSelector_Control
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.CH_Semester = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel30 = new System.Windows.Forms.Panel();
            this.CH_Subject = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.CH_Group = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel28 = new System.Windows.Forms.Panel();
            this.CH_SchoolCource = new System.Windows.Forms.ComboBox();
            this.panel29 = new System.Windows.Forms.Panel();
            this.CH_Career = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.PN_StatsContainer = new System.Windows.Forms.Panel();
            this.BT_Show = new SKYNET_Button();
            this.panel2.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel29.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.CH_Semester);
            this.panel2.Location = new System.Drawing.Point(499, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 35);
            this.panel2.TabIndex = 64;
            // 
            // CH_Semester
            // 
            this.CH_Semester.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CH_Semester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CH_Semester.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CH_Semester.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CH_Semester.FormattingEnabled = true;
            this.CH_Semester.Items.AddRange(new object[] {
            "Primer semestre",
            "Segundo semestre"});
            this.CH_Semester.Location = new System.Drawing.Point(5, 5);
            this.CH_Semester.Name = "CH_Semester";
            this.CH_Semester.Size = new System.Drawing.Size(114, 25);
            this.CH_Semester.TabIndex = 7;
            this.CH_Semester.SelectedIndexChanged += new System.EventHandler(this.CH_Semester_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(496, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "Semestre";
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel30.Controls.Add(this.CH_Subject);
            this.panel30.Location = new System.Drawing.Point(628, 39);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(228, 35);
            this.panel30.TabIndex = 62;
            // 
            // CH_Subject
            // 
            this.CH_Subject.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CH_Subject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CH_Subject.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CH_Subject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CH_Subject.FormattingEnabled = true;
            this.CH_Subject.Location = new System.Drawing.Point(5, 5);
            this.CH_Subject.Name = "CH_Subject";
            this.CH_Subject.Size = new System.Drawing.Size(221, 25);
            this.CH_Subject.TabIndex = 7;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label22.Location = new System.Drawing.Point(625, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 17);
            this.label22.TabIndex = 61;
            this.label22.Text = "Asignatura";
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel27.Controls.Add(this.CH_Group);
            this.panel27.Location = new System.Drawing.Point(393, 39);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(100, 35);
            this.panel27.TabIndex = 60;
            // 
            // CH_Group
            // 
            this.CH_Group.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CH_Group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CH_Group.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CH_Group.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CH_Group.FormattingEnabled = true;
            this.CH_Group.Location = new System.Drawing.Point(5, 5);
            this.CH_Group.Name = "CH_Group";
            this.CH_Group.Size = new System.Drawing.Size(93, 25);
            this.CH_Group.TabIndex = 7;
            this.CH_Group.SelectedIndexChanged += new System.EventHandler(this.CH_Group_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label19.Location = new System.Drawing.Point(390, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 17);
            this.label19.TabIndex = 59;
            this.label19.Text = "Grupo";
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel28.Controls.Add(this.CH_SchoolCource);
            this.panel28.Location = new System.Drawing.Point(17, 39);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(105, 35);
            this.panel28.TabIndex = 58;
            // 
            // CH_SchoolCource
            // 
            this.CH_SchoolCource.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CH_SchoolCource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CH_SchoolCource.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CH_SchoolCource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CH_SchoolCource.FormattingEnabled = true;
            this.CH_SchoolCource.Location = new System.Drawing.Point(5, 5);
            this.CH_SchoolCource.Name = "CH_SchoolCource";
            this.CH_SchoolCource.Size = new System.Drawing.Size(96, 25);
            this.CH_SchoolCource.TabIndex = 7;
            this.CH_SchoolCource.SelectedIndexChanged += new System.EventHandler(this.CH_SchoolCource_SelectedIndexChanged);
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel29.Controls.Add(this.CH_Career);
            this.panel29.Location = new System.Drawing.Point(128, 39);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(259, 35);
            this.panel29.TabIndex = 57;
            // 
            // CH_Career
            // 
            this.CH_Career.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CH_Career.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CH_Career.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.CH_Career.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CH_Career.FormattingEnabled = true;
            this.CH_Career.Location = new System.Drawing.Point(5, 5);
            this.CH_Career.Name = "CH_Career";
            this.CH_Career.Size = new System.Drawing.Size(250, 25);
            this.CH_Career.TabIndex = 7;
            this.CH_Career.SelectedIndexChanged += new System.EventHandler(this.CH_Career_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label20.Location = new System.Drawing.Point(14, 19);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 17);
            this.label20.TabIndex = 56;
            this.label20.Text = "Curso";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label21.Location = new System.Drawing.Point(125, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 17);
            this.label21.TabIndex = 55;
            this.label21.Text = "Carrera";
            // 
            // PN_StatsContainer
            // 
            this.PN_StatsContainer.Location = new System.Drawing.Point(17, 87);
            this.PN_StatsContainer.Name = "PN_StatsContainer";
            this.PN_StatsContainer.Size = new System.Drawing.Size(933, 452);
            this.PN_StatsContainer.TabIndex = 66;
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
            this.BT_Show.Location = new System.Drawing.Point(860, 39);
            this.BT_Show.MenuMode = false;
            this.BT_Show.Name = "BT_Show";
            this.BT_Show.Rounded = false;
            this.BT_Show.Size = new System.Drawing.Size(90, 35);
            this.BT_Show.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Show.TabIndex = 65;
            this.BT_Show.Text = "Mostrar";
            this.BT_Show.Click += new System.EventHandler(this.BT_Show_Click);
            // 
            // StatsSelector_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PN_StatsContainer);
            this.Controls.Add(this.BT_Show);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel30);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.panel27);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.panel28);
            this.Controls.Add(this.panel29);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Name = "StatsSelector_Control";
            this.Size = new System.Drawing.Size(968, 556);
            this.panel2.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SKYNET_Button BT_Show;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox CH_Semester;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.ComboBox CH_Subject;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.ComboBox CH_Group;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.ComboBox CH_SchoolCource;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.ComboBox CH_Career;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel PN_StatsContainer;
    }
}
