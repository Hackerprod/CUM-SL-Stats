using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Models;

namespace SKYNET.Controls
{
    public partial class Evaluation_Control : UserControl
    {
        private Student _student;
        private SchoolCource _cource;
        private Career _career;
        private Dictionary<string, Subject> Subjects;
        private Semester Semester;
        private Subject Subject;

        public Student Student 
        {
            get => _student;
            set
            {
                _student = value;
                if (value != null)
                {
                    LB_StudentEvaluate.Text = _student.Names;
                }
            } 
        }
        public SchoolCource Cource
        {
            get => _cource;
            set
            {
                _cource = value;
            }
        }

        public Career Career 
        {
            get => _career;
            set
            {
                _career = value;
            }
        }

        public Group Group
        {
            get => _group;
            set
            {
                _group = value;
            }
        }
        private Group _group;

        public Evaluation_Control()
        {
            InitializeComponent();
            Subjects = new Dictionary<string, Subject>();
            CH_Semester.SelectedIndex = 0;
        }

        private async void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CH_Subjects.Text))
            {
                MessageBox.Show("Debe especificar una Asignatura para continuar");
                return;
            }
            if (string.IsNullOrEmpty(TB_Evaluation.Text))
            {
                MessageBox.Show("Debe añadir la evaluación para continuar");
                return;
            }
            if (string.IsNullOrEmpty(CH_Subjects.Text))
            {
                MessageBox.Show("Debe especificar una Asignatura para continuar");
                return;
            }

            if (Subject != null || Subjects.TryGetValue(CH_Subjects.Text, out Subject))
            {
                Evaluation evaluation = new Evaluation()
                {
                    CourceID = Cource.ID,
                    CareerID = Career.ID,
                    StudentID = this.Student.CI,
                    SubjectID = Subject.ID,
                    GroupID = Group.ID, 
                    Semester = (Semester)CH_Semester.SelectedIndex,
                    Points = TB_Evaluation.Text.Replace(",", ".")
                };
                if (await EvaluationDB.RegisterOrUpdate(evaluation))
                {
                    MessageBox.Show($"Estudiante evaluado correctamente");
                    LB_StudentEvaluate.Text = "";
                    TB_Evaluation.Text = "";
                }
            }
            else
            {
                MessageBox.Show($"La asignatura especificada {CH_Subjects.Text} no existe.");
            }
        }

        public async void LoadData(Student student, SchoolCource cource, Career career, Group group)
        {
            this.Student = student;
            this.Cource  = cource;
            this.Career  = career;
            this.Group   = group;

            TB_Evaluation.Text = "";

            if (!Subjects.ContainsKey(CH_Subjects.Text))
            {
                CH_Subjects.Text = "";
            }

            if (Student != null && Cource != null && Career != null && Group != null && Subject != null)
            {
                var evaluation = await EvaluationDB.Get(student, cource, career, group, Semester, Subject);
                if (evaluation != null)
                {
                    TB_Evaluation.Text = evaluation.Points;
                }
            }
        }

        private void CH_Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            CH_Subjects.Items.Clear();
            Subjects.Clear();

            if (CH_Semester.SelectedIndex == 1)
            {
                Semester = Semester.First;
            }
            else if (CH_Semester.SelectedIndex == 2)
            {
                Semester = Semester.Second;
            }

            if (Cource != null && Career != null)
            {
                //var subjects = SubjectDB.GetSubjects(Cource, Career, Semester);
                //foreach (var subject in subjects)
                //{
                //    if (!Subjects.ContainsKey(subject.Name))
                //    {
                //        Subjects.Add(subject.Name, subject);
                //        CH_Subjects.Items.Add(subject.Name);
                //    }
                //}
            }
        }

        private void CH_Subjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Subjects.TryGetValue(CH_Subjects.Text, out Subject subject))
            {
                Subject = subject;
            }   
        }
    }
}
