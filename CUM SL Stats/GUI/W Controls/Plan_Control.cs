using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Managers;
using SKYNET.Models;

namespace SKYNET.Controls
{
    public partial class Plan_Control : UserControl
    {
        public Plan_Control()
        {
            InitializeComponent();

            TB_StudentName.TextChanged += TB_StudentName_TextChanged;

            foreach (var item in CareerDB.Careers)
            {
                CB_Career.Items.Add(item.Name);
            }
        }

        private void TB_StudentName_TextChanged(object sender, EventArgs e)
        {
            if (TB_StudentName.Text.Contains(","))
            {
                try
                {
                    string result = "";
                    var parts = TB_StudentName.Text.Split(',');
                    result = parts[1].Remove(0, 1) + " " + parts[0];
                    TB_StudentName.Text = result;
                }
                catch
                {
                }
            }
        }

        private void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_StudentName.Text))
            {
                Common.Show($"Debe especificar un nombre válido");
                return;
            }

            var Career = CareerDB.GetCareer(CB_Career.Text);
            if (Career == null)
            {
                Common.Show($"La carrera {CB_Career.Text} no existe.");
                return;
            }

            var Plan = new StudyPlan()
            {
                CareerID = Career.ID,
                Name = TB_StudentName.Text,
                Plans = new List<uint>()
            };

            StudyPlansDB.Register(Plan);

            Common.Show($"El plan {TB_StudentName.Text} se registró correctamente");
            TB_StudentName.Clear();
        }

        private void Register()
        {

        }
    }
}
