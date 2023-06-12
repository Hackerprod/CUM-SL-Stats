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
        private Career selectedCareer;

        public StudyPlanList_Control()
        {
            InitializeComponent();

            StudyPlanDB.OnStudyPlanAdded += StudyPlanDB_OnStudyPlanAdded;
            StudyPlanDB.OnStudyPlanRemoved += StudyPlanDB_OnStudyPlanRemoved;

        }

        internal async void LoadData()
        {
            PN_StudyPlanContainer.Controls.Clear();
            CH_Career.Items.Clear();

            foreach (var career in await CareerDB.Get())
            {
                CH_Career.Items.Add(career.Name);
            }
        }

        private void BT_AddSignature_Click(object sender, EventArgs e)
        {
            
        }

        private void BT_AddStudyPlan_Click(object sender, EventArgs e)
        {
            //frmMain.frm.Register(RegisterType.StudyPlan);
            var result = new frmPopup(frmPopup.PopupType.Add_StudyPlan).ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadData();
            }
        }

        private async void Subject_Item_OnItemClicked(object sender, StudyPlan_Item e)
        {
            ModifyItemsColor(e);

            PN_PlansContainer.Controls.Clear();
            var Plans = await StudyPlanDB.GetPlans(e.StudyPlan);
            foreach (var Plan in Plans)
            {
                //Common.Show(Plan.SubjectID);
            }
        }

        private void ModifyItemsColor(StudyPlan_Item e)
        {
            for (int i = 0; i < PN_StudyPlanContainer.Controls.Count; i++)
            {
                var control = PN_StudyPlanContainer.Controls[i];
                if (control is StudyPlan_Item subject)
                {
                    //Common.Show($"Control: {subject.StudyPlan.Name} || Selected: {e.StudyPlan.Name}");
                    if (subject.StudyPlan.ID == e.StudyPlan.ID)
                    {
                        subject.SetSelected(true);
                    }
                    else
                    {
                        subject.SetSelected(false);
                    }
                }
            }
        }

        private void StudyPlanDB_OnStudyPlanRemoved(object sender, StudyPlan e)
        {
            Common.Notify($"El plan de estudio {e.Name} se ha eliminado correctamente");

            for (int i = 0; i < PN_StudyPlanContainer.Controls.Count; i++)
            {
                var control = PN_StudyPlanContainer.Controls[i];
                if (control is StudyPlan_Item subject)
                {
                    if (subject.StudyPlan.ID == e.ID)
                    {
                        PN_StudyPlanContainer.Controls.Remove(control);
                    }
                }
            }
        }

        private void StudyPlanDB_OnStudyPlanAdded(object sender, StudyPlan e)
        {
            Common.Notify($"El plan de estudio {e.Name} se ha agregado correctamente");

            if (selectedCareer == null || e.CareerID != selectedCareer.ID)
                return;

            var Subject_Item = new StudyPlan_Item(e);
            Subject_Item.Dock = DockStyle.Top;
            Subject_Item.OnItemClicked += Subject_Item_OnItemClicked;
            Subject_Item.Name = e.ID.ToString();
            PN_StudyPlanContainer.Controls.Add(Subject_Item);
        }

        private async void CH_Career_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCareer = await CareerDB.Get(CH_Career.Text);
            if (selectedCareer == null) return;

            PN_StudyPlanContainer.Controls.Clear();

            var Subjects = await StudyPlanDB.Get(selectedCareer);

            for (int i = 0; i < Subjects.Count; i++)
            {
                var Subject = Subjects[i];
                var Subject_Item = new StudyPlan_Item(Subject);
                Subject_Item.Dock = DockStyle.Top;
                Subject_Item.OnItemClicked += Subject_Item_OnItemClicked;
                Subject_Item.Name = Subject.ID.ToString();
                PN_StudyPlanContainer.Controls.Add(Subject_Item);
            }
        }
    }
}
