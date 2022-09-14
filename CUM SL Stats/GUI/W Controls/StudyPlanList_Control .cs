using System;
using System.Linq;
using System.Windows.Forms;
using SKYNET.Controls;
using SKYNET.DB;
using SKYNET.Models;

namespace SKYNET.GUI.W_Controls
{
    public partial class StudyPlanList_Control : UserControl
    {
        ColumnHeader columnName;
        public StudyPlanList_Control()
        {
            InitializeComponent();

            this.columnName = new ColumnHeader();
            this.columnName.Text = "Nombre";
            this.columnName.Width = 255;
        }

        public void LoadData()
        {
            LV_Plans.Items.Clear();

            var Plans = StudyPlansDB.StudyPlans;
            foreach (var plan in Plans)
            {
                var lvItem = new ListViewItem();
                lvItem.SubItems.Add(plan.Name);
                lvItem.Tag = plan;
                LV_Plans.Items.Add(lvItem);
            }
        }

        private void BT_AddStudyPlan_Click(object sender, EventArgs e)
        {
            frmMain.frm.Register(RegisterType.StudyPlan);
        }

        private void BT_EditPlan_Click(object sender, EventArgs e)
        {
            try
            {
                StudyPlan Plan = (StudyPlan)LV_Plans.SelectedItems[0].Tag;
                if (Plan == null)
                {
                    Common.Show("Por favor seleccione un plan.");
                    return;
                }
                else
                {
                    frmMain.frm.PN_RegisterContainer.Controls.Clear();
                    frmMain.frm.PN_RegisterContainer.Controls.Add(new Plan_Control(Plan)
                    {
                        Dock = DockStyle.Fill
                    });
                    frmMain.frm.SelectTab(frmMain.frm.tabPage_Register);
                }

            }
            catch (Exception)
            {
            }

        }

        private void BT_RemovePlan_Click(object sender, EventArgs e)
        {

        }

        private void LV_Plans_DoubleClick(object sender, EventArgs e)
        {
            PN_PlansContainer.Controls.Clear();

            StudyPlan studyPlan = (StudyPlan)LV_Plans.SelectedItems[0].Tag;
            if (studyPlan != null)
            {
                var Plans = StudyPlansDB.GetPlans(studyPlan);
                Plans.Sort((s1, s2) => s2.Year.CompareTo(s1.Year));

                foreach (var plan in Plans)
                {
                    AddStudyPlan(plan);
                }
            }
        }

        private void AddStudyPlan(Plan plan)
        {
            var PlanControl = new Control_Plan()
            {
                Plan = plan,
                Dock = DockStyle.Top
            };

            PlanControl.OnEditPlan += PlanControl_OnEditPlan;
            PlanControl.OnDeletePlan += PlanControl_OnDeletePlan;

            PN_PlansContainer.Controls.Add(PlanControl);

        }

        private void PlanControl_OnEditPlan(object sender, Plan e)
        {

        }

        private void PlanControl_OnDeletePlan(object sender, Plan e)
        {

        }

        private void BT_AddPlan_Click(object sender, EventArgs e)
        {

        }
    }
}
