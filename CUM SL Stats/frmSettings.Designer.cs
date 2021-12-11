
namespace SKYNET
{
    partial class frmSettings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Departament = new SKYNET.Controls.SKYNET_TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.BT_Save = new SKYNET_Button();
            this.panel29 = new System.Windows.Forms.Panel();
            this.CH_SchoolCource = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LB_Path = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel29.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.TB_Departament);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.BT_Save);
            this.panel1.Controls.Add(this.panel29);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.LB_Path);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 450);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(0, 25);
            this.textBox1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 15);
            this.label1.TabIndex = 145;
            this.label1.Text = "Ruta de la Base de datos";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(344, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(22, 31);
            this.panel2.TabIndex = 144;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 146;
            this.label2.Text = "...";
            this.label2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Path_MouseClick);
            // 
            // TB_Departament
            // 
            this.TB_Departament.ActivatedBackColor = System.Drawing.Color.WhiteSmoke;
            this.TB_Departament.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.TB_Departament.Color = System.Drawing.Color.WhiteSmoke;
            this.TB_Departament.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_Departament.IsPassword = false;
            this.TB_Departament.Location = new System.Drawing.Point(15, 159);
            this.TB_Departament.Logo = null;
            this.TB_Departament.LogoCursor = System.Windows.Forms.Cursors.Default;
            this.TB_Departament.Name = "TB_Departament";
            this.TB_Departament.ShowLogo = false;
            this.TB_Departament.Size = new System.Drawing.Size(332, 35);
            this.TB_Departament.TabIndex = 143;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label28.Location = new System.Drawing.Point(12, 139);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(147, 17);
            this.label28.TabIndex = 142;
            this.label28.Text = "Centro o Departamento";
            // 
            // BT_Save
            // 
            this.BT_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(144)))), ((int)(((byte)(82)))));
            this.BT_Save.BackColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Save.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_Save.ForeColor = System.Drawing.Color.White;
            this.BT_Save.ForeColorMouseOver = System.Drawing.Color.Empty;
            this.BT_Save.ImageAlignment = SKYNET_Button.ImgAlign.Left;
            this.BT_Save.ImageIcon = null;
            this.BT_Save.Location = new System.Drawing.Point(254, 406);
            this.BT_Save.MenuMode = false;
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Rounded = false;
            this.BT_Save.Size = new System.Drawing.Size(100, 32);
            this.BT_Save.Style = SKYNET_Button._Style.TextOnly;
            this.BT_Save.TabIndex = 141;
            this.BT_Save.Text = "Guardar";
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel29.Controls.Add(this.CH_SchoolCource);
            this.panel29.Location = new System.Drawing.Point(15, 90);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(332, 35);
            this.panel29.TabIndex = 140;
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
            this.CH_SchoolCource.TabIndex = 22;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label23.Location = new System.Drawing.Point(12, 69);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 17);
            this.label23.TabIndex = 139;
            this.label23.Text = "Curso actual";
            // 
            // label4
            // 
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.label4.Location = new System.Drawing.Point(12, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 19);
            this.label4.TabIndex = 138;
            this.label4.Text = "Click para seleccionar la ruta de la base de datos";
            this.label4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Path_MouseClick);
            // 
            // LB_Path
            // 
            this.LB_Path.AutoSize = true;
            this.LB_Path.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LB_Path.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.LB_Path.ForeColor = System.Drawing.Color.Gray;
            this.LB_Path.Location = new System.Drawing.Point(12, 24);
            this.LB_Path.Name = "LB_Path";
            this.LB_Path.Size = new System.Drawing.Size(92, 17);
            this.LB_Path.TabIndex = 137;
            this.LB_Path.Text = "Database Path";
            this.LB_Path.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Path_MouseClick);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(366, 450);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel29.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LB_Path;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.ComboBox CH_SchoolCource;
        private System.Windows.Forms.Label label23;
        private SKYNET_Button BT_Save;
        private Controls.SKYNET_TextBox TB_Departament;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}