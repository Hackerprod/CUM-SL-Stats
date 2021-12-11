using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYNET.Managers;
using SKYNET.Models;

namespace SKYNET.Controls
{
    public partial class Subject_Control : UserControl
    {
        public Subject_Control()
        {
            InitializeComponent();

            for (int i = 0; i < frmMain.Manager.SchoolCources.Count; i++)
            {
                SchoolCource cource = frmMain.Manager.SchoolCources[i];
                CH_SchoolCource.Items.Add(cource.Name);
                CH_SchoolCource.SelectedIndex = i;
            }

            CH_Sem.SelectedIndex = 0;
        }

        private void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_SubjectName.Text))
            {
                MessageBox.Show("Debe especificar el nombre de la carrera para continuar");
                return;
            }

            if (!frmMain.Manager.GetCource(CH_SchoolCource.Text, out SchoolCource Cource))
            {
                MessageBox.Show("Debe especificar un curso válido");
                return;
            }

            bool validSemestre = false;
            foreach (var item in CH_Sem.Items)
            {
                if (CH_Sem.SelectedItem == item)
                {
                    validSemestre = true;
                }
            }
            if (!validSemestre)
            {
                MessageBox.Show("El semestre seleccionado no es válido");
                return;
            }
            
            if (frmMain.Manager.GetCareer(CH_Career.Text, out Career career))
            {
                Semester Semester = (Semester)CH_Sem.SelectedIndex + 1;

                if (frmMain.Manager.GetSubject(TB_SubjectName.Text, Cource.ID, career.ID, Semester, out _))
                {
                    MessageBox.Show($"La asignatura {TB_SubjectName.Text} existe.");
                    return;
                }

                Subject subject = new Subject()
                {
                    ID = frmMain.Manager.CreateSubjectId(),
                    Name = TB_SubjectName.Text,
                    CareerID = career.ID,
                    CourceID = Cource.ID,
                    Semester = Semester
                };
                var done = frmMain.frm.RegisterData(RegisterType.Subject, subject);
                if (done)
                {
                    TB_SubjectName.Text = "";
                }
            }
            else
            {
                MessageBox.Show($"La carrera {CH_Career.Text} no existe.");
                return;
            }
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
                CH_Career.SelectedIndex = 0;
            }
        }

        private void CH_Career_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_Year.Items.Clear();
            CB_Year.Text = "";

            var cource = frmMain.Manager.GetCource(CH_SchoolCource.Text); 
            var career = frmMain.Manager.GetCareer(CH_Career.Text);
            var Years  = frmMain.Manager.GetYears(cource, career); 

            foreach (var year in Years)
            {
                CB_Year.Items.Add(year);
            }

        }
    }
}
