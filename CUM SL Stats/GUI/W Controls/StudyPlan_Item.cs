using System;
using System.Drawing;
using System.Windows.Forms;
using SKYNET.Models;
using SKYNET.DB;

namespace SKYNET.GUI.W_Controls
{
    public partial class StudyPlan_Item : UserControl
    {
        private bool Selected;

        public StudyPlan StudyPlan;
        public event EventHandler<StudyPlan_Item> OnItemClicked;

        public StudyPlan_Item(StudyPlan item)
        {
            InitializeComponent();

            StudyPlan = item;

            LB_StudyPlanName.Text = StudyPlan.Name;
            TB_StudyPlanName.Text = StudyPlan.Name;

            BT_Save.Location = BT_Edit.Location;
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Selected)
            {
                BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            if (!Selected)
            {
                BackColor = Color.White;
            }
        }

        private void BT_Edit_Click(object sender, EventArgs e)
        {
            LB_StudyPlanName.Visible = false;
            TB_StudyPlanName.Visible = true;
            BT_Save.Visible = true;
            BT_Edit.Visible = false;
            TB_StudyPlanName.Focus();
        }

        private void BT_Delete_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Esta seguro que desea eliminar la asignatura?", "", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                StudyPlanDB.Remove(StudyPlan);
            }
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            UpdateStudyPlan(true);
        }

        private void TB_StudyPlan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                UpdateStudyPlan(true);
            }
            if (e.KeyData == Keys.Escape)
            {
                UpdateStudyPlan(false);
            }
        }

        private async void UpdateStudyPlan(bool Update)
        {
            LB_StudyPlanName.Visible = true;
            TB_StudyPlanName.Visible = false;
            BT_Save.Visible = false;
            BT_Edit.Visible = true;

            if (Update && LB_StudyPlanName.Text != TB_StudyPlanName.Text)
            {
                LB_StudyPlanName.Text = TB_StudyPlanName.Text;
                StudyPlan.Name = TB_StudyPlanName.Text;
                await StudyPlanDB.Update(StudyPlan);
            }
        }

        private void StudyPlan_Item_Click(object sender, EventArgs e)
        {
            OnItemClicked?.Invoke(this, this);
        }

        internal void SetSelected(bool Select)
        {
            Selected = Select;

            if (Select)
            {
                BackColor = Color.FromArgb(220, 220, 220);
            }
            else
            {
                BackColor = Color.White;
            }
        }
    }
}
