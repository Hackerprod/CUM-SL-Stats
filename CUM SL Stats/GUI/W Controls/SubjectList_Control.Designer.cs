
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
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.SubjectContainer = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.BT_AddSignature = new SKYNET_Button();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.panel17);
            this.panel13.Location = new System.Drawing.Point(213, 32);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(2);
            this.panel13.Size = new System.Drawing.Size(565, 495);
            this.panel13.TabIndex = 42;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.White;
            this.panel14.Controls.Add(this.SubjectContainer);
            this.panel14.Controls.Add(this.panel16);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(2, 44);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(3);
            this.panel14.Size = new System.Drawing.Size(561, 449);
            this.panel14.TabIndex = 2;
            // 
            // SubjectContainer
            // 
            this.SubjectContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubjectContainer.Location = new System.Drawing.Point(3, 28);
            this.SubjectContainer.Name = "SubjectContainer";
            this.SubjectContainer.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.SubjectContainer.Size = new System.Drawing.Size(555, 418);
            this.SubjectContainer.TabIndex = 3;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.label10);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(3, 3);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(555, 25);
            this.panel16.TabIndex = 1;
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
            this.panel17.Controls.Add(this.BT_AddSignature);
            this.panel17.Controls.Add(this.label12);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(2, 2);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(561, 42);
            this.panel17.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(561, 39);
            this.label12.TabIndex = 1;
            this.label12.Text = "ASIGNATURAS";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BT_AddSignature
            // 
            this.BT_AddSignature.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BT_AddSignature.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_AddSignature.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_AddSignature.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_AddSignature.ForeColor = System.Drawing.Color.White;
            this.BT_AddSignature.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_AddSignature.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_AddSignature.ImageIcon = null;
            this.BT_AddSignature.Location = new System.Drawing.Point(516, 5);
            this.BT_AddSignature.MenuMode = false;
            this.BT_AddSignature.Name = "BT_AddSignature";
            this.BT_AddSignature.Rounded = false;
            this.BT_AddSignature.Size = new System.Drawing.Size(40, 28);
            this.BT_AddSignature.Style = SKYNET_Button._Style.TextOnly;
            this.BT_AddSignature.TabIndex = 47;
            this.BT_AddSignature.Text = "+";
            this.BT_AddSignature.Click += new System.EventHandler(this.BT_AddSignature_Click);
            // 
            // SubjectList_Control
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel13);
            this.Name = "SubjectList_Control";
            this.Size = new System.Drawing.Size(968, 556);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel SubjectContainer;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label12;
        private SKYNET_Button BT_AddSignature;
    }
}
