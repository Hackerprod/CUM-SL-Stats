
namespace SKYNET.GUI.Controls
{
    partial class SKYNET_SexSelector
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
            this.PB_Male = new System.Windows.Forms.PictureBox();
            this.PB_Female = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Male)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Female)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Male
            // 
            this.PB_Male.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PB_Male.Image = global::SKYNET.Properties.Resources.user_male;
            this.PB_Male.Location = new System.Drawing.Point(39, 3);
            this.PB_Male.Name = "PB_Male";
            this.PB_Male.Size = new System.Drawing.Size(30, 30);
            this.PB_Male.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Male.TabIndex = 1;
            this.PB_Male.TabStop = false;
            this.PB_Male.Click += new System.EventHandler(this.PB_Male_Click);
            // 
            // PB_Female
            // 
            this.PB_Female.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PB_Female.Image = global::SKYNET.Properties.Resources.female_user;
            this.PB_Female.Location = new System.Drawing.Point(3, 3);
            this.PB_Female.Name = "PB_Female";
            this.PB_Female.Size = new System.Drawing.Size(30, 30);
            this.PB_Female.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Female.TabIndex = 0;
            this.PB_Female.TabStop = false;
            this.PB_Female.Click += new System.EventHandler(this.PB_Female_Click);
            // 
            // SKYNET_SexSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PB_Male);
            this.Controls.Add(this.PB_Female);
            this.Name = "SKYNET_SexSelector";
            this.Size = new System.Drawing.Size(72, 38);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Male)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Female)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Female;
        private System.Windows.Forms.PictureBox PB_Male;
    }
}
