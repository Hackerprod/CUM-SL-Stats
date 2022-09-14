
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
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.PN_PlansContainer = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.skyneT_Button1 = new SKYNET_Button();
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
            this.BT_AddStudyPlan = new SKYNET_Button();
            this.BT_EditPlan = new SKYNET_Button();
            this.BT_RemovePlan = new SKYNET_Button();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.panel17);
            this.panel13.Location = new System.Drawing.Point(328, 16);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(2);
            this.panel13.Size = new System.Drawing.Size(613, 528);
            this.panel13.TabIndex = 42;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.White;
            this.panel14.Controls.Add(this.PN_PlansContainer);
            this.panel14.Controls.Add(this.panel16);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(2, 44);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(3);
            this.panel14.Size = new System.Drawing.Size(609, 482);
            this.panel14.TabIndex = 2;
            // 
            // PN_PlansContainer
            // 
            this.PN_PlansContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PN_PlansContainer.Location = new System.Drawing.Point(3, 28);
            this.PN_PlansContainer.Name = "PN_PlansContainer";
            this.PN_PlansContainer.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.PN_PlansContainer.Size = new System.Drawing.Size(603, 451);
            this.PN_PlansContainer.TabIndex = 3;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel16.Controls.Add(this.label5);
            this.panel16.Controls.Add(this.label4);
            this.panel16.Controls.Add(this.label1);
            this.panel16.Controls.Add(this.label10);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(3, 3);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(603, 25);
            this.panel16.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(511, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Acciones";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(171, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Asignatura";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Semestre";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(28, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Año";
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel17.Controls.Add(this.skyneT_Button1);
            this.panel17.Controls.Add(this.label12);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(2, 2);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(609, 42);
            this.panel17.TabIndex = 1;
            // 
            // skyneT_Button1
            // 
            this.skyneT_Button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.skyneT_Button1.BackColorMouseOver = System.Drawing.Color.Empty;
            this.skyneT_Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skyneT_Button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skyneT_Button1.ForeColor = System.Drawing.Color.White;
            this.skyneT_Button1.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.skyneT_Button1.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.skyneT_Button1.ImageIcon = null;
            this.skyneT_Button1.Location = new System.Drawing.Point(561, 4);
            this.skyneT_Button1.MenuMode = false;
            this.skyneT_Button1.Name = "skyneT_Button1";
            this.skyneT_Button1.Rounded = false;
            this.skyneT_Button1.Size = new System.Drawing.Size(40, 28);
            this.skyneT_Button1.Style = SKYNET_Button._Style.TextOnly;
            this.skyneT_Button1.TabIndex = 46;
            this.skyneT_Button1.Text = "+";
            this.skyneT_Button1.Click += new System.EventHandler(this.BT_AddPlan_Click);
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(609, 39);
            this.label12.TabIndex = 1;
            this.label12.Text = "ASIGNATURAS";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(25, 16);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(284, 492);
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
            this.panel2.Size = new System.Drawing.Size(280, 446);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LV_Plans);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 28);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panel3.Size = new System.Drawing.Size(274, 415);
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
            this.LV_Plans.Size = new System.Drawing.Size(254, 405);
            this.LV_Plans.TabIndex = 2;
            this.LV_Plans.UseCompatibleStateImageBehavior = false;
            this.LV_Plans.View = System.Windows.Forms.View.Details;
            this.LV_Plans.DoubleClick += new System.EventHandler(this.LV_Plans_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "--";
            this.columnHeader2.Width = 25;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nombre";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 220;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(274, 25);
            this.panel4.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre del Plan de estudio";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(280, 42);
            this.panel5.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = "PLANES";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BT_AddStudyPlan
            // 
            this.BT_AddStudyPlan.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BT_AddStudyPlan.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_AddStudyPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_AddStudyPlan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_AddStudyPlan.ForeColor = System.Drawing.Color.White;
            this.BT_AddStudyPlan.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_AddStudyPlan.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_AddStudyPlan.ImageIcon = null;
            this.BT_AddStudyPlan.Location = new System.Drawing.Point(27, 512);
            this.BT_AddStudyPlan.MenuMode = false;
            this.BT_AddStudyPlan.Name = "BT_AddStudyPlan";
            this.BT_AddStudyPlan.Rounded = false;
            this.BT_AddStudyPlan.Size = new System.Drawing.Size(90, 32);
            this.BT_AddStudyPlan.Style = SKYNET_Button._Style.TextOnly;
            this.BT_AddStudyPlan.TabIndex = 45;
            this.BT_AddStudyPlan.Text = "Agregar";
            this.BT_AddStudyPlan.Click += new System.EventHandler(this.BT_AddStudyPlan_Click);
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
            this.BT_EditPlan.Location = new System.Drawing.Point(123, 512);
            this.BT_EditPlan.MenuMode = false;
            this.BT_EditPlan.Name = "BT_EditPlan";
            this.BT_EditPlan.Rounded = false;
            this.BT_EditPlan.Size = new System.Drawing.Size(90, 32);
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
            this.BT_RemovePlan.Location = new System.Drawing.Point(219, 512);
            this.BT_RemovePlan.MenuMode = false;
            this.BT_RemovePlan.Name = "BT_RemovePlan";
            this.BT_RemovePlan.Rounded = false;
            this.BT_RemovePlan.Size = new System.Drawing.Size(90, 32);
            this.BT_RemovePlan.Style = SKYNET_Button._Style.TextOnly;
            this.BT_RemovePlan.TabIndex = 43;
            this.BT_RemovePlan.Text = "Eliminar";
            this.BT_RemovePlan.Click += new System.EventHandler(this.BT_RemovePlan_Click);
            // 
            // StudyPlanList_Control
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BT_AddStudyPlan);
            this.Controls.Add(this.BT_EditPlan);
            this.Controls.Add(this.BT_RemovePlan);
            this.Controls.Add(this.panel13);
            this.Name = "StudyPlanList_Control";
            this.Size = new System.Drawing.Size(968, 556);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
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

        }

        #endregion
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel PN_PlansContainer;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label12;
        private SKYNET_Button BT_RemovePlan;
        private SKYNET_Button BT_EditPlan;
        private SKYNET_Button BT_AddStudyPlan;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private SKYNET_Button skyneT_Button1;
    }
}
