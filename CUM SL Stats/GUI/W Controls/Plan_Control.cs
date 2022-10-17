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
        private StudyPlan Plan;
        public Plan_Control()
        {
            InitializeComponent();
        }

        public Plan_Control(StudyPlan plan)
        {
            InitializeComponent();

            Plan = plan;
            TB_PlanName.Text = Plan.Name;
            BT_Register.Text = "Actualizar";
        }


        private void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_PlanName.Text))
            {
                Common.Show($"Debe especificar un nombre válido");
                return;
            }

            if (Plan == null)
            {
                Plan = new StudyPlan()
                {
                    Name = TB_PlanName.Text,
                    Plans = new List<Plan>()
                };
                StudyPlansDB.Register(Plan);
                Common.Show($"El plan {TB_PlanName.Text} se registró correctamente");
            }
            else
            {
                Plan.Name = TB_PlanName.Text;
                StudyPlansDB.Update(Plan);
                Common.Show($"El plan {TB_PlanName.Text} se actualizó correctamente");
                frmMain.frm.StudyPlanList.LoadData();
                frmMain.frm.SelectTab();
            }

            TB_PlanName.Clear();

        }
    }
}
