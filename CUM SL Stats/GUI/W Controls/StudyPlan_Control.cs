using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Managers;
using SKYNET.Models;

namespace SKYNET.Controls
{
    public partial class StudyPlan_Control : UserControl
    {
        private StudyPlan Plan;
        public event EventHandler<bool> OnActionResult;

        public StudyPlan_Control()
        {
            InitializeComponent();

            LoadData();
        }

        private async void LoadData()
        {
            foreach (var cource in await SchoolCourceDB.Get())
            {
                CH_SchoolCource.Items.Add(cource.Name);
            }

            foreach (var career in await CareerDB.Get())
            {
                CH_Career.Items.Add(career.Name);
            }
        }

        public StudyPlan_Control(StudyPlan plan)
        {
            InitializeComponent();
            LoadData();

            Plan = plan;
            TB_StudyPlanName.Text = Plan.Name;
            BT_Register.Text = "Actualizar";
            CH_SchoolCource.Enabled = false;
            CH_Career.Enabled = false;
        }


        private async void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_StudyPlanName.Text))
            {
                Common.Show($"Debe especificar un nombre válido");
                return;
            }

            if (CH_SchoolCource.Items.Count == 0)
            {
                Common.Show($"Debe añadir un nuevo curso para poder agregar el plan de estudio");
                return;
            }

            if (string.IsNullOrEmpty(CH_SchoolCource.Text))
            {
                Common.Show($"Debe especificar un curso válido");
                return;
            }

            if (CH_Career.Items.Count == 0)
            {
                Common.Show($"Debe añadir una nueva carrera para poder agregar el plan de estudio");
                return;
            }

            if (string.IsNullOrEmpty(CH_Career.Text))
            {
                Common.Show($"Debe especificar una carrera válida");
                return;
            }

            if (Plan == null)
            {
                var cource = await SchoolCourceDB.Get(CH_SchoolCource.Text);
                if (cource == null)
                {
                    Common.Show($"Error al obtener el curso {CH_SchoolCource.Text}");
                    return;
                }
                var career = await CareerDB.Get(CH_Career.Text);
                if (career == null)
                {
                    Common.Show($"Error al obtener la carrera {CH_Career.Text}");
                    return;
                }
                var courceID = cource.ID;
                var careerID = career.ID;

                Plan = new StudyPlan()
                {
                    Name = TB_StudyPlanName.Text,
                    Plans = new List<uint>(),
                    CareerID = careerID,
                    CourceID = courceID
                };
                if (await StudyPlanDB.Register(Plan))
                {
                    Common.Notify($"El plan {TB_StudyPlanName.Text} se registró correctamente");
                    OnActionResult?.Invoke(this, true);
                }
            }
            else
            {
                Plan.Name = TB_StudyPlanName.Text;
                await StudyPlanDB.Update(Plan);
                Common.Notify($"El plan {TB_StudyPlanName.Text} se actualizó correctamente");
                frmMain.frm.StudyPlanList.LoadData();
                frmMain.frm.SelectTab();
            }

            TB_StudyPlanName.Clear();

        }
    }
}
