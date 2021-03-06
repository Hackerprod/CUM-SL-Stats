using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        internal void LoadData()
        {
            for (int i = 0; i < frmMain.Manager.SchoolCources.Count; i++)
            {
                SchoolCource cource = frmMain.Manager.SchoolCources[i];
                CH_SchoolCource.Items.Add(cource.Name);
                CH_SchoolCource.SelectedIndex = i;
            }
            CH_Semester.SelectedIndex = 0;
        }

        private void CB_SchoolCource_SelectedIndexChanged(object sender, EventArgs e)
        {
            CH_Career.Items.Clear();
            CH_Career.Text = "";

            var cource = frmMain.Manager.GetCource(CH_SchoolCource.Text);
            var careers = frmMain.Manager.GetCareers(cource);

            for (int i = 0; i < careers.Count; i++)
            {
                Career career = careers[i];
                CH_Career.Items.Add(career.Name);
            }
        }
        private void BT_Show_Click(object sender, EventArgs e)
        {
            LV_Subjects.Items.Clear();

            if (!frmMain.Manager.GetCource(CH_SchoolCource.Text, out SchoolCource cource))
            {
                modCommon.Show("El Curso seleccionado no es válido");
                return;
            }
            if (!frmMain.Manager.GetCareer(CH_Career.Text, out Career career))
            {
                modCommon.Show("La carrera seleccionada no es válida");
                return;
            }

            Semester semester = (Semester)CH_Semester.SelectedIndex;

             var Subjects = frmMain.Manager.GetSubjects(cource, career, semester);
            Subjects.Sort((s1, s2) => s1.Semester.CompareTo(s2.Semester));

            if (!Subjects.Any())
            {
                modCommon.Show("No existen Asignaturas registradas");
                return;
            }

            LV_Subjects.Items.Clear();

            foreach (var subject in Subjects)
            {
                string semesterString = subject.Semester == Semester.First ? "Primer semestre" : "Segundo semestre";

                var lvItem = new ListViewItem();
                lvItem.SubItems.Add(subject.Name);
                lvItem.SubItems.Add(semesterString);
                LV_Subjects.Items.Add(lvItem);
            }
        }

        private void BT_AddSubject_Click(object sender, EventArgs e)
        {
            if (!frmMain.Manager.GetCource(CH_SchoolCource.Text, out SchoolCource cource))
            {
                modCommon.Show("El Curso seleccionado no es válido");
                return;
            }
            if (!frmMain.Manager.GetCareer(CH_Career.Text, out Career career))
            {
                modCommon.Show("La carrera seleccionada no es válida");
                return;
            }
            Semester semester = (Semester)CH_Semester.SelectedIndex;
            if (semester == Semester.Both)
            {
                modCommon.Show("Debe seleccionar un semestre válido para agregar la asignatura." + Environment.NewLine + "Solo esta permitido agregarla en Primer semestre o Segundo semestre");
                return;
            }
            if (frmMain.Manager.GetSubject(TB_SubjectName.Text, cource.ID, career.ID, semester, out Subject subject))
            {
                modCommon.Show($"La asignatura \"{TB_SubjectName.Text}\" existe en el curso seleccionado");
                return;
            }
            subject = new Subject()
            {
                ID = frmMain.Manager.CreateSubjectId(),
                Name = TB_SubjectName.Text,
                CourceID = cource.ID,
                CareerID = career.ID,
                Semester = semester
            };
            if (!frmMain.Manager.RegisterSubject(subject))
            {
                modCommon.Show($"Error agregando la asignatura \"{TB_SubjectName.Text}\"");
                return;
            }

            modCommon.Show($"La asignatura \"{TB_SubjectName.Text}\" se ha agregado correctamente");
            BT_Show_Click(null, null);
            TB_SubjectName.Text = "";
        }
    }
}
