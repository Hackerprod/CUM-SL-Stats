namespace SKYNET.GUI.W_Controls
{
    partial class Subject_Item
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
            this.BT_Edit = new System.Windows.Forms.PictureBox();
            this.BT_Delete = new System.Windows.Forms.PictureBox();
            this.TB_SubnectName = new System.Windows.Forms.TextBox();
            this.BT_Save = new System.Windows.Forms.PictureBox();
            this.LB_SubnectName = new SKYNET.Controls.SKYNET_Label();
            ((System.ComponentModel.ISupportInitialize)(this.BT_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BT_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BT_Save)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_Edit
            // 
            this.BT_Edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Edit.Image = global::SKYNET.Properties.Resources.Edit;
            this.BT_Edit.Location = new System.Drawing.Point(487, 1);
            this.BT_Edit.Name = "BT_Edit";
            this.BT_Edit.Size = new System.Drawing.Size(20, 20);
            this.BT_Edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BT_Edit.TabIndex = 1;
            this.BT_Edit.TabStop = false;
            this.BT_Edit.Click += new System.EventHandler(this.BT_Edit_Click);
            this.BT_Edit.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.BT_Edit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // BT_Delete
            // 
            this.BT_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Delete.Image = global::SKYNET.Properties.Resources.remove_48px;
            this.BT_Delete.Location = new System.Drawing.Point(513, 1);
            this.BT_Delete.Name = "BT_Delete";
            this.BT_Delete.Size = new System.Drawing.Size(20, 20);
            this.BT_Delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BT_Delete.TabIndex = 2;
            this.BT_Delete.TabStop = false;
            this.BT_Delete.Click += new System.EventHandler(this.BT_Delete_Click);
            this.BT_Delete.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.BT_Delete.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // TB_SubnectName
            // 
            this.TB_SubnectName.BackColor = System.Drawing.Color.White;
            this.TB_SubnectName.Font = new System.Drawing.Font("Lucida Fax", 9F);
            this.TB_SubnectName.Location = new System.Drawing.Point(25, 1);
            this.TB_SubnectName.Name = "TB_SubnectName";
            this.TB_SubnectName.Size = new System.Drawing.Size(430, 22);
            this.TB_SubnectName.TabIndex = 3;
            this.TB_SubnectName.Visible = false;
            // 
            // BT_Save
            // 
            this.BT_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Save.Image = global::SKYNET.Properties.Resources.Edit;
            this.BT_Save.Location = new System.Drawing.Point(461, 1);
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Size = new System.Drawing.Size(20, 20);
            this.BT_Save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BT_Save.TabIndex = 4;
            this.BT_Save.TabStop = false;
            this.BT_Save.Visible = false;
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // LB_SubnectName
            // 
            this.LB_SubnectName.AutoSize = true;
            this.LB_SubnectName.ChangeColor = true;
            this.LB_SubnectName.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_SubnectName.GradiantColor = false;
            this.LB_SubnectName.GradiantColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.LB_SubnectName.GradiantColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(135)))));
            this.LB_SubnectName.GradiantMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.LB_SubnectName.Location = new System.Drawing.Point(22, 4);
            this.LB_SubnectName.Name = "LB_SubnectName";
            this.LB_SubnectName.Size = new System.Drawing.Size(119, 15);
            this.LB_SubnectName.TabIndex = 0;
            this.LB_SubnectName.Text = "Español Literatura";
            this.LB_SubnectName.TextColor = System.Drawing.SystemColors.ControlText;
            this.LB_SubnectName.TextColor_MouseHover = System.Drawing.SystemColors.ControlText;
            this.LB_SubnectName.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.LB_SubnectName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // Subject_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BT_Save);
            this.Controls.Add(this.TB_SubnectName);
            this.Controls.Add(this.BT_Delete);
            this.Controls.Add(this.BT_Edit);
            this.Controls.Add(this.LB_SubnectName);
            this.Name = "Subject_Item";
            this.Size = new System.Drawing.Size(546, 22);
            this.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.BT_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BT_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BT_Save)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SKYNET.Controls.SKYNET_Label LB_SubnectName;
        private System.Windows.Forms.PictureBox BT_Edit;
        private System.Windows.Forms.PictureBox BT_Delete;
        private System.Windows.Forms.TextBox TB_SubnectName;
        private System.Windows.Forms.PictureBox BT_Save;
    }
}
