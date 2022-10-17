﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Managers;
using SKYNET.Models;

using static SKYNET.frmMain;

namespace SKYNET
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            this.EnableBlur();
            BackColor = Color.Azure;
            TransparencyKey = Color.Azure;
        }

        private void Path_MouseClick(object sender, MouseEventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Title = "Seleccione la base de datos",
                Filter = "Database File | *.DB",
                Multiselect = false,
            };
            var fileOK = openDialog.ShowDialog();

            //if (fileOK == DialogResult.OK)
            //{
            //    Settings.DBPath = openDialog.FileName;
            //    //Settings.Save();
            //    var DB = new SQLiteDatabase(openDialog.FileName);
            //    DBManager.Initialize();
            //    frm.LoadStats();
            //}
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            TB_Departament.Text = Settings.CurrentDepartament;
            LB_Path.Text = Settings.DBPath.Replace(@"\", "/");

            for (int i = 0; i < SchoolCourceDB.SchoolCources.Count; i++)
            {
                SchoolCource Cources = SchoolCourceDB.SchoolCources[i];
                CH_SchoolCource.Items.Add(Cources.Name);
                if (Cources.ID == Settings.CurrentCource)
                {
                    CH_SchoolCource.SelectedIndex = i;
                }
            }

            SetFocus();
        }

        private void SetFocus()
        {
            textBox1.Text = "sd";
            textBox1.Focus();
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LB_Path.Text) || !File.Exists(LB_Path.Text))
            {
                MessageBox.Show("Error guardando la ruta de la base de datos");
                return;
            }
            if (CH_SchoolCource.Items.Count > 0 && CH_SchoolCource.Text == "")
            {
                MessageBox.Show("Debes seleccionar el curso actual");
                return;
            }
            SchoolCource cource = SchoolCourceDB.Get(CH_SchoolCource.Text);

            if (cource == null)
            {
                MessageBox.Show("Error guardando el curso actual");
                return;
            }

            Settings.CurrentDepartament = TB_Departament.Text;
            Settings.DBPath = LB_Path.Text;
            Settings.CurrentCource = cource.ID;
            Settings.Save();

            frm.TB_Departament.Text = TB_Departament.Text;

            Close();
        }
    }
}
