namespace SKYNET.Controls
{
    partial class Control_Plan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.PB_RemovePlan = new System.Windows.Forms.PictureBox();
            this.PB_EditPlan = new System.Windows.Forms.PictureBox();
            this.LB_Signature = new System.Windows.Forms.Label();
            this.LB_Semester = new System.Windows.Forms.Label();
            this.LB_Year = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_RemovePlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_EditPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.PB_RemovePlan);
            this.panel1.Controls.Add(this.PB_EditPlan);
            this.panel1.Controls.Add(this.LB_Signature);
            this.panel1.Controls.Add(this.LB_Semester);
            this.panel1.Controls.Add(this.LB_Year);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 24);
            this.panel1.TabIndex = 0;
            this.panel1.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // PB_RemovePlan
            // 
            this.PB_RemovePlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PB_RemovePlan.Image = global::SKYNET.Properties.Resources.remove_48px;
            this.PB_RemovePlan.Location = new System.Drawing.Point(529, 3);
            this.PB_RemovePlan.Name = "PB_RemovePlan";
            this.PB_RemovePlan.Size = new System.Drawing.Size(19, 19);
            this.PB_RemovePlan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_RemovePlan.TabIndex = 4;
            this.PB_RemovePlan.TabStop = false;
            this.PB_RemovePlan.Click += new System.EventHandler(this.PB_RemovePlan_Click);
            this.PB_RemovePlan.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.PB_RemovePlan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // PB_EditPlan
            // 
            this.PB_EditPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PB_EditPlan.Image = global::SKYNET.Properties.Resources.Edit;
            this.PB_EditPlan.Location = new System.Drawing.Point(507, 3);
            this.PB_EditPlan.Name = "PB_EditPlan";
            this.PB_EditPlan.Size = new System.Drawing.Size(19, 19);
            this.PB_EditPlan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_EditPlan.TabIndex = 3;
            this.PB_EditPlan.TabStop = false;
            this.PB_EditPlan.Click += new System.EventHandler(this.PB_EditPlan_Click);
            this.PB_EditPlan.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.PB_EditPlan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // LB_Signature
            // 
            this.LB_Signature.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Signature.Location = new System.Drawing.Point(163, 3);
            this.LB_Signature.Name = "LB_Signature";
            this.LB_Signature.Size = new System.Drawing.Size(340, 18);
            this.LB_Signature.TabIndex = 2;
            this.LB_Signature.Text = "label2";
            this.LB_Signature.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.LB_Signature.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // LB_Semester
            // 
            this.LB_Semester.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Semester.Location = new System.Drawing.Point(82, 3);
            this.LB_Semester.Name = "LB_Semester";
            this.LB_Semester.Size = new System.Drawing.Size(58, 18);
            this.LB_Semester.TabIndex = 1;
            this.LB_Semester.Text = "label2";
            this.LB_Semester.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_Semester.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.LB_Semester.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // LB_Year
            // 
            this.LB_Year.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Year.Location = new System.Drawing.Point(7, 3);
            this.LB_Year.Name = "LB_Year";
            this.LB_Year.Size = new System.Drawing.Size(51, 18);
            this.LB_Year.TabIndex = 0;
            this.LB_Year.Text = "label1";
            this.LB_Year.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_Year.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.LB_Year.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // Control_Plan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.panel1);
            this.Name = "Control_Plan";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(555, 26);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_RemovePlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_EditPlan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LB_Year;
        private System.Windows.Forms.Label LB_Semester;
        private System.Windows.Forms.Label LB_Signature;
        private System.Windows.Forms.PictureBox PB_RemovePlan;
        private System.Windows.Forms.PictureBox PB_EditPlan;
    }
}
