using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using SKYNET.DB;
using SKYNET.Models;
using static SKYNET.frmMain;

namespace SKYNET.GUI.W_Controls
{
    public partial class StatsSelector_Control : UserControl
    {
        private SchoolCource Cource;
        private Career Career;
        private Group Group;
        private Semester Semester;
        private Subject Subject;

        public StatsSelector_Control()
        {
            InitializeComponent();
        }

        public void Select(RegisterType type)
        {
            ClearData();

            foreach (var item in SchoolCourceDB.SchoolCources)
            {
                CH_SchoolCource.Items.Add(item.Name);
            }

            switch (type)
            {
                case RegisterType.SchoolCource:
                    break;
                case RegisterType.Career:
                    break;
                case RegisterType.Student:
                    break;
                case RegisterType.Subject:
                    break;
                case RegisterType.Group:
                    break;
                default:
                    break;
            }
        }

        private void ClearData(bool shoolCource = true)
        {
            if (shoolCource)
            {
                CH_SchoolCource.Items.Clear();
                CH_SchoolCource.Items.Add("Todos");
                CH_SchoolCource.SelectedIndex = 0;
            }           

            CH_Career.Items.Clear();
            CH_Career.Items.Add("Todas");
            CH_Career.SelectedIndex = 0;

            CH_Group.Items.Clear();
            CH_Group.Items.Add("Todos");
            CH_Group.SelectedIndex = 0;

            CH_Semester.Items.Clear();
            CH_Semester.Items.Add("Todos");
            CH_Semester.Items.Add("Primero");
            CH_Semester.Items.Add("Segundo");
            CH_Semester.SelectedIndex = 0;

            CH_Subject.Items.Clear();
            CH_Subject.Items.Add("Todas");
            CH_Subject.SelectedIndex = 0;
        }

        private void CH_SchoolCource_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Careers
            ClearData(false);

            var cource = SchoolCourceDB.Get(CH_SchoolCource.Text);
            var careers = CareerDB.GetCareers(cource);

            foreach (Career career in careers)
            {
                CH_Career.Items.Add(career.Name);
            }

            // Subjects
            CH_Subject.Items.Clear();
            CH_Subject.Items.Add("Todas");
            CH_Subject.SelectedIndex = 0;

            var subjects = SubjectDB.Subjects;
            foreach (Subject subject in subjects)
            {
                CH_Subject.Items.Add(subject.Name);
            }

            Career = null;
            Group = null;
        }

        private void CH_Career_SelectedIndexChanged(object sender, EventArgs e)
        {
            CH_Group.Items.Clear();
            CH_Group.Items.Add("Todos");
            CH_Group.SelectedIndex = 0;

            if (!SchoolCourceDB.Get(CH_SchoolCource.Text, out Cource) || !CareerDB.Get(CH_Career.Text, out Career))
            {
                return;
            }
            var groups = GroupDB.GetGroups(Cource, Career);
            foreach (Group group in groups)
            {
                CH_Group.Items.Add(group.Name);
            }

            GetSubjects();
        }

        private void CH_Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubjects();
        }

        private void GetSubjects()
        {
            CH_Subject.Items.Clear();
            CH_Subject.Items.Add("Todas");
            CH_Subject.SelectedIndex = 0;

            var subjects = new List<Subject>();

            if (Cource != null && Career == null)
            {
                switch (CH_Semester.SelectedIndex)
                {
                    case 0:     // All Subjects
//                        subjects = SubjectDB.GetSubjects(Cource);
                        break;
                    case 1:     // First Semester Subjects
//                        subjects = SubjectDB.GetSubjects(Cource, Semester.First);
                        break;
                    case 2:     // 2do Semester Subjects
//                        subjects = SubjectDB.GetSubjects(Cource, Semester.Second);
                        break;
                }
            }
            else if (Cource != null && Career != null)
            {
                switch (CH_Semester.SelectedIndex)
                {
                    case 0:     // All Subjects
//                        subjects = SubjectDB.GetSubjects(Cource, Career);
                        break;
                    case 1:     // First Semester Subjects
//                        subjects = SubjectDB.GetSubjects(Cource, Career, Semester.First);
                        break;
                    case 2:     // 2do Semester Subjects
//                        subjects = SubjectDB.GetSubjects(Cource, Career, Semester.Second);
                        break;
                }
            }

            foreach (var subject in subjects)
            {
                CH_Subject.Items.Add(subject.Name);
            }
        }
        private void CH_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Career != null)
            {
                Group = GroupDB.GetGroup(CH_Group.Text, Cource, Career);
            }
        }
        private void BT_Show_Click(object sender, EventArgs e)
        {
            RegisterType type = RegisterType.SchoolCource;

            // Subject Stats ////////////////////////////////////////////////////////////////////
            if (Subject != null)
            {
                List<Evaluation> evaluations = new List<Evaluation>();

                if (Cource == null && Career == null && Group == null)
                {
                    evaluations = EvaluationDB.GetEvaluations(Subject, Semester);
                }
                else if (Cource == null && Career == null && Group != null)
                {
                    evaluations = EvaluationDB.GetEvaluations(Group, Subject, Semester);
                }
                else if (Cource == null && Career != null && Group != null)
                {
                    evaluations = EvaluationDB.GetEvaluations(Career, Group, Subject, Semester);
                }
                else if (Cource != null && Career != null && Group == null)
                {
                    evaluations = EvaluationDB.GetEvaluations(Cource, Career, Group, Subject, Semester);
                }

            }
            /////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
