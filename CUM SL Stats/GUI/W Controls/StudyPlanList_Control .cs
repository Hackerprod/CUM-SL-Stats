using System;
using System.Linq;
using System.Windows.Forms;
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
            CH_Career.Items.Clear();

            foreach (var career in CareerDB.Careers)
            {
                CH_Career.Items.Add(career.Name);
            }
        }

        private void BT_LoadPlans_Click(object sender, EventArgs e)
        {
            var career = CareerDB.GetCareer(CH_Career.Text);
            if (career == null)
            {
                Common.Show($"La carrera {CH_Career.Text} no existe.");
                return;
            }

            LV_Plans.Items.Clear();

            var Plans = StudyPlansDB.Get(career);
            foreach (var plan in Plans)
            {
                var lvItem = new ListViewItem();
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());

                lvItem.SubItems[1].Text = plan.Name;
                lvItem.Tag = plan;

                LV_Plans.Items.Add(lvItem);
            }
        }

        private void BT_AddPlan_Click(object sender, EventArgs e)
        {
            frmMain.frm.Register(RegisterType.StudyPlan);
        }

        private void BT_EditPlan_Click(object sender, EventArgs e)
        {

        }

        private void BT_RemovePlan_Click(object sender, EventArgs e)
        {

        }

        private void LV_Plans_DoubleClick(object sender, EventArgs e)
        {
            StudyPlan studyPlan = (StudyPlan)LV_Plans.SelectedItems[0].SubItems[0].Tag;
            if (studyPlan != null)
            {
                LV_StudyPlans.Tag = studyPlan;

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
            var lvItem = new ListViewItem();
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());

            var Subject = SubjectDB.Get(plan.SubjectID);

            lvItem.SubItems[0].Text = ((int)plan.Year).ToString();
            lvItem.SubItems[1].Text = Subject == null ? "Desconocida" : Subject.Name;
            lvItem.SubItems[2].Tag = plan.Semester == Semester.First ? "Primero" : "Segundo";
            lvItem.SubItems[0].Tag = Subject;

            LV_StudyPlans.Items.Add(lvItem);
        }
    }
}
