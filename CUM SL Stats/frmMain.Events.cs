using SKYNET.DB;
using SKYNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmMain 
    {
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showSubjectsMenuItem_Click(object sender, EventArgs e)
        {
            subjectList_Control1.LoadData();
            SelectTab(tabPage_Subjects);
        }

        private async void addStudentMenuItem_Click(object sender, EventArgs e)
        {
            string Header = "Para registrar un estudiante necesitas haber registrado un Curso escolar y una carrera." + Environment.NewLine;

            var Careers = await CareerDB.Get();
            var SchoolCources = await SchoolCourceDB.Get();
            if (SchoolCources.Count == 0)
            {
                var dialog = MessageBox.Show(Header + "No contamos con ningun Curso, desea registrarlo ahora?", "", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Register(RegisterType.SchoolCource);
                }
                return;
            }
            else if (Careers.Count == 0)
            {
                var dialog = MessageBox.Show(Header + "No contamos con ninguna Carrera, desea registrarla ahora?", "", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Register(RegisterType.Career);
                }
                return;
            }
            else
            {
                Register(RegisterType.Student);
            }
        }

        private void addCourceMenuItem_Click(object sender, EventArgs e)
        {
            Register(RegisterType.SchoolCource);
        }

        private void addCareerMenuItem_Click(object sender, EventArgs e)
        {
            Register(RegisterType.Career);
        }

        private void addSubjectMenuItem_Click(object sender, EventArgs e)
        {
            Register(RegisterType.Subject);
        }

        private void homeMenuItem_Click(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void showCourcesMenuItem_Click(object sender, EventArgs e)
        {
            LoadStats();
        }

        private async void importMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Title = "Seleccione un reporte exportado de SIGENU",
                Filter = "Archivo PDF | *.pdf",
                Multiselect = false,
            };
            var fileOK = openDialog.ShowDialog();

            if (fileOK == DialogResult.OK)
            {
                string pdfFile = openDialog.FileName;
                await import_Control1.ProcessPdfFile(pdfFile);
                SelectTab(tabPage_Import);
            }
        }

        private void addGroupMenuItem_Click(object sender, EventArgs e)
        {
            Register(RegisterType.Group);
        }

        private void showEvaluationMenuItem_Click(object sender, EventArgs e)
        {
            CTR_EvaluationList.LoadData();
            SelectTab(tabPage_Evaluations);
        }

        private void SubjectStatsMenuItem_Click(object sender, EventArgs e)
        {
            statsSelector.Select(RegisterType.Subject);
            SelectTab(tabPage_Stats);
        }

        private void groupStatsMenuItem_Click(object sender, EventArgs e)
        {
            statsSelector.Select(RegisterType.Group);
            SelectTab(tabPage_Stats);
        }

        private void CareerStatsMenuItem_Click(object sender, EventArgs e)
        {
            statsSelector.Select(RegisterType.Career);
            SelectTab(tabPage_Stats);
        }

        private void CourceStatsMenuItem1_Click(object sender, EventArgs e)
        {
            statsSelector.Select(RegisterType.SchoolCource);
            SelectTab(tabPage_Stats);
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            new frmSettings().ShowDialog();
        }

        private void aboutUsMenuItem_Click(object sender, EventArgs e)
        {
            new frmAbout().ShowDialog();
        }

        private void MostrarGruposMenuItem_Click(object sender, EventArgs e)
        {
            groups_Control1.LoadData();
            SelectTab(tabPage_Groups);
        }

        private void MostrarPlanesMenuItem_Click(object sender, EventArgs e)
        {
            StudyPlanList.LoadData();
            SelectTab(tabPage_StudyPlan);
        }

        private async void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SchoolCourceDB.Register(new SchoolCource()
            {
                Name = "2020-2021"
            });

            var plan = new Plan()
            {
                ID = 0,
                Semester = Semester.First,
                SubjectID = 10,
                Year = SchoolYear.First
            };

            var splan = new StudyPlan()
            {
                ID = 0,
                CourceID = 0,
                Name = "Aprobado",
                Plans = new List<uint>() { 0, 8 }
            };

            await PlanDB.Register(plan);
            await StudyPlanDB.Register(splan);
        }

        private void AñadirPlanMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
