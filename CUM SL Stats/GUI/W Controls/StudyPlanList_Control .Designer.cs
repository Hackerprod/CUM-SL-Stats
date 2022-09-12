
namespace SKYNET.GUI.W_Controls
{
    partial class StudyPlanList_Control
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
            this.panel29 = new System.Windows.Forms.Panel();
            this.CH_Career = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.LV_StudyPlans = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel16 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LV_Plans = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.BT_AddPlan = new SKYNET_Button();
            this.BT_EditPlan = new SKYNET_Button();
            this.BT_RemovePlan = new SKYNET_Button();
            this.BT_LoadPlans = new SKYNET_Button();
            this.panel29.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel29.Controls.Add(this.CH_Career);
            this.panel29.Location = new System.Drawing.Point(36, 29);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(253, 35);
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
            this.CH_Career.Size = new System.Drawing.Size(244, 25);
            this.CH_Career.TabIndex = 7;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label21.Location = new System.Drawing.Point(33, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 17);
            this.label21.TabIndex = 26;
            this.label21.Text = "Carrera";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.panel17);
            this.panel13.Location = new System.Drawing.Point(295, 78);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(2);
            this.panel13.Size = new System.Drawing.Size(633, 461);
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
            this.panel14.Size = new System.Drawing.Size(629, 415);
            this.panel14.TabIndex = 2;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.LV_StudyPlans);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(3, 28);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panel15.Size = new System.Drawing.Size(623, 384);
            this.panel15.TabIndex = 3;
            // 
            // LV_StudyPlans
            // 
            this.LV_StudyPlans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LV_StudyPlans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader1});
            this.LV_StudyPlans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_StudyPlans.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.LV_StudyPlans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LV_StudyPlans.FullRowSelect = true;
            this.LV_StudyPlans.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_StudyPlans.HideSelection = false;
            this.LV_StudyPlans.Location = new System.Drawing.Point(10, 0);
            this.LV_StudyPlans.Name = "LV_StudyPlans";
            this.LV_StudyPlans.Size = new System.Drawing.Size(603, 374);
            this.LV_StudyPlans.TabIndex = 2;
            this.LV_StudyPlans.UseCompatibleStateImageBehavior = false;
            this.LV_StudyPlans.View = System.Windows.Forms.View.Details;
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
            // columnHeader1
            // 
            this.columnHeader1.Text = "Semester";
            this.columnHeader1.Width = 154;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.label7);
            this.panel16.Controls.Add(this.label10);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(3, 3);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(623, 25);
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
            this.panel17.Size = new System.Drawing.Size(629, 42);
            this.panel17.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(629, 39);
            this.label12.TabIndex = 1;
            this.label12.Text = "ASIGNATURAS";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(36, 78);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(250, 461);
            this.panel1.TabIndex = 46;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 44);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(246, 415);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LV_Plans);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 28);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panel3.Size = new System.Drawing.Size(240, 384);
            this.panel3.TabIndex = 3;
            // 
            // LV_Plans
            // 
            this.LV_Plans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LV_Plans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.LV_Plans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_Plans.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.LV_Plans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LV_Plans.FullRowSelect = true;
            this.LV_Plans.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Plans.HideSelection = false;
            this.LV_Plans.Location = new System.Drawing.Point(10, 0);
            this.LV_Plans.Name = "LV_Plans";
            this.LV_Plans.Size = new System.Drawing.Size(220, 374);
            this.LV_Plans.TabIndex = 2;
            this.LV_Plans.UseCompatibleStateImageBehavior = false;
            this.LV_Plans.View = System.Windows.Forms.View.Details;
            this.LV_Plans.DoubleClick += new System.EventHandler(this.LV_Plans_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "--";
            this.columnHeader2.Width = 22;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nombre";
            this.columnHeader3.Width = 180;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 25);
            this.panel4.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(246, 42);
            this.panel5.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = "PLANES";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BT_AddPlan
            // 
            this.BT_AddPlan.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BT_AddPlan.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_AddPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_AddPlan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_AddPlan.ForeColor = System.Drawing.Color.White;
            this.BT_AddPlan.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_AddPlan.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_AddPlan.ImageIcon = null;
            this.BT_AddPlan.Location = new System.Drawing.Point(616, 32);
            this.BT_AddPlan.MenuMode = false;
            this.BT_AddPlan.Name = "BT_AddPlan";
            this.BT_AddPlan.Rounded = false;
            this.BT_AddPlan.Size = new System.Drawing.Size(100, 32);
            this.BT_AddPlan.Style = SKYNET_Button._Style.TextOnly;
            this.BT_AddPlan.TabIndex = 45;
            this.BT_AddPlan.Text = "Agregar";
            this.BT_AddPlan.Click += new System.EventHandler(this.BT_AddPlan_Click);
            // 
            // BT_EditPlan
            // 
            this.BT_EditPlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(144)))), ((int)(((byte)(82)))));
            this.BT_EditPlan.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_EditPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_EditPlan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_EditPlan.ForeColor = System.Drawing.Color.White;
            this.BT_EditPlan.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_EditPlan.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_EditPlan.ImageIcon = null;
            this.BT_EditPlan.Location = new System.Drawing.Point(722, 32);
            this.BT_EditPlan.MenuMode = false;
            this.BT_EditPlan.Name = "BT_EditPlan";
            this.BT_EditPlan.Rounded = false;
            this.BT_EditPlan.Size = new System.Drawing.Size(100, 32);
            this.BT_EditPlan.Style = SKYNET_Button._Style.TextOnly;
            this.BT_EditPlan.TabIndex = 44;
            this.BT_EditPlan.Text = "Editar";
            this.BT_EditPlan.Click += new System.EventHandler(this.BT_EditPlan_Click);
            // 
            // BT_RemovePlan
            // 
            this.BT_RemovePlan.BackColor = System.Drawing.Color.Red;
            this.BT_RemovePlan.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_RemovePlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_RemovePlan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_RemovePlan.ForeColor = System.Drawing.Color.White;
            this.BT_RemovePlan.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_RemovePlan.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_RemovePlan.ImageIcon = null;
            this.BT_RemovePlan.Location = new System.Drawing.Point(828, 32);
            this.BT_RemovePlan.MenuMode = false;
            this.BT_RemovePlan.Name = "BT_RemovePlan";
            this.BT_RemovePlan.Rounded = false;
            this.BT_RemovePlan.Size = new System.Drawing.Size(100, 32);
            this.BT_RemovePlan.Style = SKYNET_Button._Style.TextOnly;
            this.BT_RemovePlan.TabIndex = 43;
            this.BT_RemovePlan.Text = "Eliminar";
            this.BT_RemovePlan.Click += new System.EventHandler(this.BT_RemovePlan_Click);
            // 
            // BT_LoadPlans
            // 
            this.BT_LoadPlans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(144)))), ((int)(((byte)(82)))));
            this.BT_LoadPlans.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_LoadPlans.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_LoadPlans.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_LoadPlans.ForeColor = System.Drawing.Color.White;
            this.BT_LoadPlans.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_LoadPlans.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_LoadPlans.ImageIcon = null;
            this.BT_LoadPlans.Location = new System.Drawing.Point(295, 32);
            this.BT_LoadPlans.MenuMode = false;
            this.BT_LoadPlans.Name = "BT_LoadPlans";
            this.BT_LoadPlans.Rounded = false;
            this.BT_LoadPlans.Size = new System.Drawing.Size(100, 32);
            this.BT_LoadPlans.Style = SKYNET_Button._Style.TextOnly;
            this.BT_LoadPlans.TabIndex = 41;
            this.BT_LoadPlans.Text = "Cargar Planes";
            this.BT_LoadPlans.Click += new System.EventHandler(this.BT_LoadPlans_Click);
            // 
            // StudyPlanList_Control
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BT_AddPlan);
            this.Controls.Add(this.BT_EditPlan);
            this.Controls.Add(this.BT_RemovePlan);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.BT_LoadPlans);
            this.Controls.Add(this.panel29);
            this.Controls.Add(this.label21);
            this.Name = "StudyPlanList_Control";
            this.Size = new System.Drawing.Size(968, 556);
            this.panel29.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.ComboBox CH_Career;
        private System.Windows.Forms.Label label21;
        private SKYNET_Button BT_LoadPlans;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.ListView LV_StudyPlans;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private SKYNET_Button BT_RemovePlan;
        private SKYNET_Button BT_EditPlan;
        private SKYNET_Button BT_AddPlan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView LV_Plans;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
    }
}
