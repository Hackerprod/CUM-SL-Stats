using System;
using System.Linq;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Models;

namespace SKYNET.GUI.W_Controls
{
    public partial class SubjectList_Control : UserControl
    {
        ColumnHeader columnName;
        public SubjectList_Control()
        {
            InitializeComponent();

            this.columnName = new ColumnHeader();
            this.columnName.Text = "Nombre";
            this.columnName.Width = 255;
        }

        internal async void LoadData()
        {
            var SchoolCources = await SchoolCourceDB.Get();
            for (int i = 0; i < SchoolCources.Count; i++)
            {
                var cource = SchoolCources[i];
                CH_SchoolCource.Items.Add(cource.Name);
                CH_SchoolCource.SelectedIndex = i;
            }
            CH_Semester.SelectedIndex = 0;
        }

        private async void CB_SchoolCource_SelectedIndexChanged(object sender, EventArgs e)
        {
            CH_Career.Items.Clear();
            CH_Career.Text = "";

            var cource = await SchoolCourceDB.Get(CH_SchoolCource.Text);
            var careers = await CareerDB.Get(cource);

            for (int i = 0; i < careers.Count; i++)
            {
                var career = careers[i];
                CH_Career.Items.Add(career.Name);
            }
        }

        private async void BT_Show_Click(object sender, EventArgs e)
        {
            LV_Subjects.Items.Clear();

            var cource = await SchoolCourceDB.Get(CH_SchoolCource.Text);
            if (cource == null)
            {
                Common.Show("El Curso seleccionado no es válido");
                return;
            }

            var career = await CareerDB.Get(CH_Career.Text);
            if (career == null)
            {
                Common.Show("La carrera seleccionada no es válida");
                return;
            }

            Semester semester = (Semester)CH_Semester.SelectedIndex;

            // var Subjects = SubjectDB.GetSubjects(cource, career, semester);
            //Subjects.Sort((s1, s2) => s1.Semester.CompareTo(s2.Semester));

            //if (!Subjects.Any())
            //{
            //    Common.Show("No existen Asignaturas registradas");
            //    return;
            //}

            //LV_Subjects.Items.Clear();

            //foreach (var subject in Subjects)
            //{
            //    string semesterString = subject.Semester == Semester.First ? "Primer semestre" : "Segundo semestre";

            //    var lvItem = new ListViewItem();
            //    lvItem.SubItems.Add(subject.Name);
            //    lvItem.SubItems.Add(semesterString);
            //    LV_Subjects.Items.Add(lvItem);
            //}
        }

        private async void BT_AddSubject_Click(object sender, EventArgs e)
        {
            var cource = await SchoolCourceDB.Get(CH_SchoolCource.Text);
            if (cource == null)
            {
                Common.Show("El Curso seleccionado no es válido");
                return;
            }

            var career = await CareerDB.Get(CH_Career.Text);
            if (career == null)
            {
                Common.Show("La carrera seleccionada no es válida");
                return;
            }

            Semester semester = (Semester)CH_Semester.SelectedIndex;


            //if (SubjectDB.GetSubject(TB_SubjectName.Text, cource.ID, career.ID, semester, out Subject subject))
            //{
            //    Common.Show($"La asignatura \"{TB_SubjectName.Text}\" existe en el curso seleccionado");
            //    return;
            //}
            //subject = new Subject()
            //{
            //    ID = SubjectDB.CreateSubjectId(),
            //    Name = TB_SubjectName.Text
            //};
            //if (!SubjectDB.RegisterSubject(subject))
            //{
            //    Common.Show($"Error agregando la asignatura \"{TB_SubjectName.Text}\"");
            //    return;
            //}

            Common.Show($"La asignatura \"{TB_SubjectName.Text}\" se ha agregado correctamente");
            BT_Show_Click(null, null);
            TB_SubjectName.Text = "";
        }
    }
}
