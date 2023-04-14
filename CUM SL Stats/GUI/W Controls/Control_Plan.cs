using SKYNET.DB;
using SKYNET.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SKYNET.Controls
{
    public partial class Control_Plan : UserControl
    {
        private Plan _StudyPlan;

        public event EventHandler<Plan> OnEditPlan;
        public event EventHandler<Plan> OnDeletePlan;

        public Control_Plan()
        {
            InitializeComponent();
        }

        public Plan Plan
        {
            get
            {
                return _StudyPlan;
            }
            set
            {
                _StudyPlan = value;

                LB_Year.Text = ((int)value.Year).ToString();
                LB_Semester.Text = ((int)value.Semester).ToString();
                //if (SubjectDB.Get(value.SubjectID, out var Subject))
                //{
                //    LB_Signature.Text = Subject.Name;
                //}
            }
        }

        private void PB_EditPlan_Click(object sender, EventArgs e)
        {
            OnEditPlan?.Invoke(null, Plan);
        }

        private void PB_RemovePlan_Click(object sender, EventArgs e)
        {
            OnDeletePlan?.Invoke(null, Plan);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
        }
    }
}
