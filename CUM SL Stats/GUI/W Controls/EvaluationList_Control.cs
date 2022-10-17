using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Models;

namespace SKYNET.GUI.W_Controls
{
    public partial class EvaluationList_Control : UserControl
    {
        ColumnHeader columnName;
        public EvaluationList_Control()
        {
            InitializeComponent();

            this.columnName = new ColumnHeader();
            this.columnName.Text = "Nombre";
            this.columnName.Width = 255;
        }

        internal void LoadData()
        {
            for (int i = 0; i < SchoolCourceDB.SchoolCources.Count; i++)
            {
                SchoolCource cource = SchoolCourceDB.SchoolCources[i];
                CH_SchoolCource.Items.Add(cource.Name);
                CH_SchoolCource.SelectedIndex = i;
            }

        }

        private void CB_SchoolCource_SelectedIndexChanged(object sender, EventArgs e)
        {
            CH_Career.Items.Clear();
            CH_Career.Text = "";

            var cource = SchoolCourceDB.Get(CH_SchoolCource.Text);
            var careers = CareerDB.GetCareers(cource);

            for (int i = 0; i < careers.Count; i++)
            {
                Career career = careers[i];
                CH_Career.Items.Add(career.Name);
                CH_Career.SelectedIndex = i;
            }
        }

        private void CB_Career_SelectedIndexChanged(object sender, EventArgs e)
        {
            CH_Group.Items.Clear();
            CH_Group.Text = "";
            if (!SchoolCourceDB.Get(CH_SchoolCource.Text, out SchoolCource cource) || !CareerDB.Get(CH_Career.Text, out Career career))
            {
                return;
            }
            var groups = GroupDB.GetGroups(cource, career);
            for (int i = 0; i < groups.Count; i++)
            {
                Group group = groups[i];
                CH_Group.Items.Add(group.Name);
                CH_Group.SelectedIndex = i;
            }
        }

        private void CB_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO
        }


        private void CH_Subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO
        }

        private void BT_Show_Click(object sender, EventArgs e)
        {
            LV_Students.Items.Clear();

            if (!SchoolCourceDB.Get(CH_SchoolCource.Text, out SchoolCource cource))
            {
                Common.Show("El Curso seleccionado no es válido");
                return;
            }
            if (!CareerDB.Get(CH_Career.Text, out Career career))
            {
                Common.Show("La carrera seleccionada no es válida");
                return;
            }
            if (!GroupDB.GetGroup(cource, career, CH_Group.Text, out Group group))
            {
                Common.Show("El Grupo seleccionado no es válido");
                return;
            }

            Semester semester = (Semester)CH_Semester.SelectedIndex + 1;

            var Evaluations = EvaluationDB.GetEvaluations(cource, career, group, semester);

            // Separate Evaluations by Students 
            var studentsEvaluation = new Dictionary<ulong, object>();
            foreach (var ev in Evaluations)
            {
                if (!studentsEvaluation.ContainsKey(ev.StudentID))
                {
                    List<Evaluation> evs = new List<Evaluation>();
                    evs.Add(ev);
                    studentsEvaluation.Add(ev.StudentID, evs);
                }
                else
                {
                    List<Evaluation> evs = (List<Evaluation>)studentsEvaluation[ev.StudentID];
                    evs.Add(ev);
                    studentsEvaluation[ev.StudentID] = evs;
                }
            }

            //*******************************************************************\\

            // Create Subjects Columns
            //List<Subject> subjects = new List<Subject>();
            //foreach (var item in studentsEvaluation)
            //{
            //    List<Evaluation> evs = (List<Evaluation>)item.Value;
            //    foreach (var i in evs)
            //    {
            //        var exist = subjects.Find(s => s.ID == i.SubjectID);
            //        if (exist == null)
            //        {
            //            var subject = SubjectDB.Subjects;
            //            if (subject != null)
            //            {
            //                subjects.Add(subject);
            //            }
            //        }
            //    }
            //}

            LV_Students.Clear();
            LV_Students.Columns.Add(columnName);

            //foreach (var subject in subjects)
            //{
            //    var column = new ColumnHeader()
            //    {
            //        Text = subject.Name,
            //        TextAlign = HorizontalAlignment.Center
            //    };
            //    column.Width = Common.GetTextSize(LV_Students, subject.Name) + 10;
            //    column.Tag = subject;
            //    LV_Students.Columns.Add(column);
            //}

            //*******************************************************************\\

            string semesterString = semester == Semester.First ? "primer semestre" : "segundo semestre";

            if (Evaluations.Count == 0)
            {
                Common.Show($"No se han encontrado evaluaciones en el {semesterString}");
                return;
            }

            LB_Info.Text = $"EVALUACIONES {semesterString.ToUpper()}";

            foreach (var item in studentsEvaluation)
            {
                List<Evaluation> evs = (List<Evaluation>)item.Value;
                Student student = StudentDB.Get(item.Key);

                var lvItem = CreateListViewItem(evs.Count + 1); 
                lvItem.SubItems[0].Text = (student.Names);

                for (int E = 0; E < evs.Count; E++)
                {
                    Evaluation i = evs[E];
                    lvItem.SubItems[E + 1].Text = i.Points;
                }
                LV_Students.Items.Add(lvItem);
            }
        }

        private ListViewItem CreateListViewItem(int Count)
        {
            var lvItem = new ListViewItem();
            for (int i = 0; i < Count; i++)
            {
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
            }
            return lvItem;
        }
    }
}
