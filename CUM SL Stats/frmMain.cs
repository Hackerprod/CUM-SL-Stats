using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SKYNET.Controls;
using SKYNET.DB;
using SKYNET.Helpers;
using SKYNET.Managers;
using SKYNET.Models;
using SQLite;
using static SKYNET.BlurExtentions;
using static SKYNET.ChartManager;

namespace SKYNET
{
    public partial class frmMain : Form
    {
        public static frmMain frm;
        public static SettingsManager Settings;
        public static SQLiteDatabase DB;

        public RegisterType CurrentRegisterType;
        public TabPage LastTab;

        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            frm = this;

            Settings = new SettingsManager();
            Settings.Load();

            TB_Departament.Text = Settings.CurrentDepartament;

            if (!string.IsNullOrEmpty(Settings.DBPath))
            {
                DB = new SQLiteDatabase(Settings.DBPath);
            }
            else
            {
                DB = new SQLiteDatabase(System.IO.Path.Combine("Data", "DB.db"));
            }

            DBManager.Initialize(DB);
            LastTab = tabPage_Home;

            this.EnableBlur();
            BackColor = Color.Azure;
            TransparencyKey = Color.Azure;


        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ChartManager.LoadPieChart(pieChart1);
        }



        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Save();
            Process.GetCurrentProcess().Kill();
        }

        private void BN_Start_Click(object sender, EventArgs e)
        {
            LoadStats();
        }

        public void SelectTab()
        {
            TabControl1.SelectTab(LastTab);
        }
        private void SelectTab(TabPage tabPage)
        {
            LastTab = TabControl1.SelectedTab;
            TabControl1.SelectTab(tabPage);
        }

        public void Register(RegisterType type)
        {
            CurrentRegisterType = type;
            PN_RegisterContainer.Controls.Clear();
            switch (type)
            {
                case RegisterType.SchoolCource:
                    {
                        PN_RegisterContainer.Controls.Add(new SchoolCource_Control()
                        {
                            Dock = DockStyle.Fill
                        });
                    }
                    break;
                case RegisterType.Career:
                    {
                        PN_RegisterContainer.Controls.Add(new Career_Control()
                        {
                            Dock = DockStyle.Fill
                        });
                    }
                    break;
                case RegisterType.Student:
                    {
                        PN_RegisterContainer.Controls.Add(new Student_Control()
                        {
                            Dock = DockStyle.Fill
                        });
                    }
                    break;
                case RegisterType.Subject:
                    {
                        PN_RegisterContainer.Controls.Add(new Subject_Control()
                        {
                            Dock = DockStyle.Fill
                        });
                    }
                    break;
                case RegisterType.Group:
                    {
                        PN_RegisterContainer.Controls.Add(new Group_Control()
                        {
                            Dock = DockStyle.Fill
                        });
                    }
                    break;
            }
            SelectTab(tabPage_Register);
        }

        public bool RegisterData(RegisterType type, object Data, bool other = false, bool notify = true)
        {
            switch (type)
            {
                case RegisterType.SchoolCource:
                    {
                        SchoolCource schoolCource = (SchoolCource)Data;
                        if (SchoolCourceDB.RegisterSchoolCource(schoolCource))
                        {
                            if (notify)
                            {
                                modCommon.Show($"El Curso {schoolCource.Name} se ha registrado correctamente");
                            }
                            SelectTab(LastTab);
                            LoadStats();
                            return true;
                        }
                        return false;
                    }
                case RegisterType.Career:
                    {
                        Career Career = (Career)Data;
                        if (CareerDB.RegisterCareer(Career))
                        {
                            if (notify)
                            {
                                modCommon.Show($"La Carrera {Career.Name} se ha registrado correctamente");
                            }
                            SelectTab(LastTab);
                            return true;
                        }
                        return false;
                    }
                case RegisterType.Student:
                    {
                        Student student = (Student)Data;
                        bool registered = StudentDB.RegisterStudent(student);
                        if (registered && !other)
                        {
                            if (notify)
                            {
                                modCommon.Show($"El estudiante {student.Names} se ha registrado correctamente");
                            }
                            SelectTab(LastTab);
                            return true;
                        }
                        if (registered)
                        {
                            return true;
                        }
                        return false;
                    }
                case RegisterType.Subject:
                    {
                        Subject subject = (Subject)Data;
                        if (SubjectDB.RegisterSubject(subject))
                        {
                            if (notify)
                            {
                                modCommon.Show($"La asignatura {subject.Name} se ha guardado correctamente");
                            }
                            SelectTab(LastTab);
                            return true;
                        }
                        return false;
                    }
                case RegisterType.Group:
                    {
                        Group group = (Group)Data;

                        bool registered = GroupDB.RegisterGroup(group);
                        if (registered)
                        {
                            if (notify)
                            {
                                modCommon.Show($"El Grupo {group.Name} se ha guardado correctamente");
                            }
                            SelectTab(LastTab);
                            return true;
                        }
                        return false;
                    }
            }
            return false;
        }

        internal void RefreshUpdated(RegisterType type, object data, bool removed = false)
        {
            switch (type)
            {
                case RegisterType.SchoolCource:
                    break;
                case RegisterType.Career:
                    break;
                case RegisterType.Student:
                    {
                        Student student = (Student)data;
                        var Items = LV_Students.Items;
                        for (int i = 0; i < Items.Count; i++)
                        {
                            ListViewItem item = (ListViewItem)Items[i];
                            if (item.SubItems[0].Tag is Student)
                            {
                                Student target = (Student)item.SubItems[0].Tag;
                                if (target.CI == student.CI || target.Names == student.Names)
                                {
                                    if (removed)
                                    {
                                        LV_Students.Items.Remove(item);
                                    }
                                    else
                                    {
                                        item.SubItems[0].Tag = student;
                                        item.SubItems[1].Text = student.CI;
                                        item.SubItems[2].Text = student.Names;

                                        string status = "";
                                        switch (student.Status)
                                        {
                                            case Status.Unknown: status = "Desconocido"; break;
                                            case Status.Active: status = "Activo"; break;
                                            case Status.Graduated: status = "Graduado"; break;
                                            case Status.Down: status = "Baja"; break;
                                        }

                                        item.SubItems[5].Text = status;
                                    }
                                }
                            }
                        } 
                    }
                    break;
                case RegisterType.Subject:
                    break;
                case RegisterType.Group:
                    break;
                default:
                    break;
            }
        }

        public void LoadStats()
        {
            LV_Cources.Items.Clear();
            List<CourceStats> stats = new List<CourceStats>();
            foreach (var Cource in SchoolCourceDB.SchoolCources)
            {
                StudentDB.GetEnrolledAndGraduates(Cource, out int Enrolleds, out int Graduates);
                StudentDB.GetActiveStudents(Cource, out int students);
                StudentDB.GetCourceEvaluations(Cource, out uint _5Points, out uint _4Points, out uint _3Points);
                stats.Add(new CourceStats()
                {
                    Cource = Cource,
                    Enrolled = Enrolleds,
                    Graduates = Graduates,
                    Active = students,
                });

                int Groups = 0;
                foreach (var career in CareerDB.GetCareers(Cource))
                {
                    Groups += GroupDB.GetGroups(Cource, career).Count;
                }

                var lvItem = new ListViewItem();
                lvItem.SubItems.Add(Cource.Name);
                lvItem.SubItems.Add(CareerDB.GetCareers(Cource).Count.ToString());
                lvItem.SubItems.Add(Groups.ToString());
                lvItem.SubItems.Add(Enrolleds.ToString());
                lvItem.SubItems.Add(students.ToString());
                lvItem.SubItems[0].Tag = Cource;

                LV_Cources.Items.Add(lvItem);
            }
            LoadCartesianChart(cartesianChart1, stats);
            SelectTab(tabPage_MainStats);
            LV_Students.Items.Clear();
        }



        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SchoolCource Cource = (SchoolCource)LV_Cources.SelectedItems[0].SubItems[0].Tag;
            if (Cource != null)
            {
                var Careers = CareerDB.GetCareers(Cource);
                if (Careers.Any())
                {
                    LoadCourceStats(Cource);
                }
                else
                {
                    MessageBox.Show("El curso seleccionado no contiene carreras");
                }
            }
        }

        private void LoadCourceStats(SchoolCource Cource)
        {
            LV_Careers.Items.Clear();
            var Cources = SchoolCourceDB.GetActiveCources(Cource.ID);

            foreach (var cource in Cources)
            {
                var Careers = CareerDB.GetCareers(cource);
                foreach (var career in Careers)
                {
                    var lvItem = new ListViewItem();
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());

                    lvItem.SubItems[0].Text = career.Name;
                    lvItem.SubItems[1].Text = StudentDB.GetCourceYear(cource, Settings.CurrentCource); 
                    lvItem.SubItems[0].Tag = career;
                    lvItem.SubItems[1].Tag = cource;

                    LV_Careers.Items.Add(lvItem);
                }
            }

            SelectTab(tabPage_CourceStats);
        }
        private void LV_Groups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LV_Students.Items.Clear();
            Group group = (Group)LV_Groups.SelectedItems[0].SubItems[0].Tag;

            if (group != null)
            {
                SchoolCource Cource = SchoolCourceDB.GetCource(group.CourceID);
                var Students = StudentDB.GetStudents(group);
                foreach (var item in Students)
                {
                    var lvItem = new ListViewItem();
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());

                    string status = "";
                    switch (item.Status)
                    {
                        case Status.Unknown:    status = "Desconocido"; break;
                        case Status.Active:     status = "Activo"; break;
                        case Status.Graduated:  status = "Graduado"; break;
                        case Status.Down:       status = "Baja"; break;
                    }

                    lvItem.SubItems[0].Tag = item;
                    lvItem.SubItems[1].Text = item.CI;
                    lvItem.SubItems[2].Text = item.Names;
                    lvItem.SubItems[3].Text = Cource.Name;
                    lvItem.SubItems[4].Text = item.Sex.ToString();
                    lvItem.SubItems[5].Text = status;

                    LV_Students.Items.Add(lvItem);
                }
                CustomizeItem(LV_Groups, LV_Groups.SelectedItems[0].Text, 0, Color.FromArgb(0, 120, 215), Color.White);
            }
        }

        private void LV_Careers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Groups.Items.Clear();
                Career Career = (Career)LV_Careers.SelectedItems[0].SubItems[0].Tag;
                SchoolCource Cource = (SchoolCource)LV_Careers.SelectedItems[0].SubItems[1].Tag;

                if (Cource != null && Career != null)
                {
                    var Groups = GroupDB.GetGroups(Cource, Career);
                    foreach (var group in Groups)
                    {
                        var lvItem = new ListViewItem();
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems[0].Tag = group;
                        lvItem.SubItems[0].Text = group.Name;

                        LV_Groups.Items.Add(lvItem);
                    }
                    CustomizeItem(LV_Careers, LV_Careers.SelectedItems[0], Color.FromArgb(0, 120, 215), Color.White);
                }
            }
            catch
            {
            }
        }
        private void CustomizeItem(ListView LV, ListViewItem item, Color BackColor, Color ForeColor)
        {
            foreach (ListViewItem Item in LV.Items)
            {
                if (Item == item)
                {
                    Item.SubItems[0].BackColor = BackColor;
                    Item.SubItems[0].ForeColor = ForeColor;
                }
                else
                {
                    Item.SubItems[0].BackColor = Color.White;
                    Item.SubItems[0].ForeColor = SystemColors.WindowFrame;
                }
            }
        }
        private void CustomizeItem(ListView LV, string comparer, int subitem, Color BackColor, Color ForeColor)
        {
            foreach (ListViewItem item in LV.Items)
            {
                if (item.SubItems[subitem].Text == comparer)
                {
                    item.SubItems[0].BackColor = BackColor;
                    item.SubItems[0].ForeColor = ForeColor;
                }
                else
                {
                    item.SubItems[0].BackColor = Color.White;
                    item.SubItems[0].ForeColor = SystemColors.WindowFrame;
                }
            }
        }

        private void BT_Print_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += Document_PrintPage;
            //PrintPageEventArgs
            PrintDialog printDialog = new PrintDialog()
            {
                Document = document
            };
            printDialog.ShowDialog();
        }


        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            LV_Students.PrintData(e.MarginBounds.Location, e.Graphics, Brushes.Blue, Brushes.Black, Pens.Blue);
        }

        private void CB_SelectStudents_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in LV_Students.Items)
            {
                item.Checked = CB_SelectStudents.Checked;
                item.Selected = CB_SelectStudents.Checked;
            }
        }



        private void BN_Evaluate_Click(object sender, EventArgs e)
        {
            try
            {
                LV_Evaluate.Items.Clear();
                Career Career = (Career)LV_Careers.SelectedItems[0].SubItems[0].Tag;
                SchoolCource Cource = (SchoolCource)LV_Careers.SelectedItems[0].SubItems[1].Tag;
                Group Group = (Group)LV_Groups.SelectedItems[0].SubItems[0].Tag;
                if (Career != null)
                {
                    var Students = StudentDB.GetStudents(Cource, Career, Group);
                    foreach (var student in Students)
                    {
                        var lvItem = new ListViewItem();
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());

                        lvItem.SubItems[0].Tag = student;
                        lvItem.SubItems[1].Tag = Cource;
                        lvItem.SubItems[2].Tag = Career;
                        lvItem.SubItems[3].Tag = Group;

                        lvItem.SubItems[1].Text = student.CI;
                        lvItem.SubItems[2].Text = student.Names;
                        lvItem.SubItems[3].Text = Cource.Name;

                        string status = "";
                        switch (student.Status)
                        {
                            case Status.Unknown: status = "Desconocido"; break;
                            case Status.Active: status = "Activo"; break;
                            case Status.Graduated: status = "Graduado"; break;
                            case Status.Down: status = "Baja"; break;
                        }

                        lvItem.SubItems[4].Text = status;

                        LV_Evaluate.Items.Add(lvItem);

                        //LB_CourceEvaluate.Text = Cource.Name;
                    }
                    SelectTab(tabPage_Evaluation);
                }
            }
            catch (Exception)
            {

            }

        }

        private void LV_Evaluate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Student student = (Student)LV_Evaluate.SelectedItems[0].SubItems[0].Tag;
            SchoolCource Cource = (SchoolCource)LV_Evaluate.SelectedItems[0].SubItems[1].Tag;
            Career Career = (Career)LV_Evaluate.SelectedItems[0].SubItems[2].Tag;
            Group Group = (Group)LV_Evaluate.SelectedItems[0].SubItems[3].Tag;

            evaluation_Control.LoadData(student, Cource, Career, Group);

            CustomizeItem(LV_Evaluate, student.CI, 1, Color.FromArgb(0, 120, 215), Color.White);
        }

        private void BT_StudentGraphics_Click(object sender, EventArgs e)
        {
            Student student = null;
            var List = LV_Students.Items;
            for (int i = 0; i < List.Count; i++)
            {
                ListViewItem item = (ListViewItem)List[i];
                if (item.Checked)
                {
                    student = (Student)item.SubItems[0].Tag;
                }
            }
            if (student == null)
            {
                modCommon.Show("Por favor, Marque el estudiante al que desea mostrar sus estadísticas");
            }
            else
            {
                modCommon.Show("Implementar estadística para " + student.Names);
            }
        }

        #region Menu Items events

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showSubjectsMenuItem_Click(object sender, EventArgs e)
        {
            subjectList_Control1.LoadData();
            SelectTab(tabPage_Subjects);
        }

        private void localizarDBMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Title = "Seleccione la base de datos",
                Filter = "Database File | *.DB",
                Multiselect = false,
            };
            var fileOK = openDialog.ShowDialog();

            if (fileOK == DialogResult.OK)
            {
                Settings.DBPath = openDialog.FileName;
                //Settings.Save();
                DB = new SQLiteDatabase(openDialog.FileName);
                DBManager.Initialize(DB);
                LoadStats();
            }
        }

        private void addStudentMenuItem_Click(object sender, EventArgs e)
        {
            string Header = "Para registrar un estudiante necesitas haber registrado un Curso escolar y una carrera." + Environment.NewLine;
            if (SchoolCourceDB.SchoolCources.Count == 0)
            {
                var dialog = MessageBox.Show(Header + "No contamos con ningun Curso, desea registrarlo ahora?", "", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Register(RegisterType.SchoolCource);
                }
                return;
            }
            else if (CareerDB.Careers.Count == 0)
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

        private void importMenuItem_Click(object sender, EventArgs e)
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
                import_Control1.ProcessPdfFile(pdfFile);
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

        #endregion

        private void BT_EditStudent_Click(object sender, EventArgs e)
        {
            try
            {
                Student Student = (Student)LV_Students.SelectedItems[0].SubItems[0].Tag;
                Student_Control student = new Student_Control()
                {
                    Student = Student,
                    Dock = DockStyle.Fill
                };
                PN_RegisterContainer.Controls.Clear();
                PN_RegisterContainer.Controls.Add(student);
                SelectTab(tabPage_Register);
            }
            catch 
            {
                modCommon.Show("Seleccione el estudiante que desea editar");
            }
        }

        private void BT_AddCource_Click(object sender, EventArgs e)
        {
            Register(RegisterType.SchoolCource);
        }

        private void BT_RemoveCource_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in LV_Cources.Items)
            {
                if (item.Selected)
                {
                    SchoolCource Cource = (SchoolCource)item.SubItems[0].Tag;
                    if (SchoolCourceDB.RemoveCource(Cource))
                    {
                        modCommon.Show($"El Curso {Cource.Name} se ha eliminado correctamente");
                    }
                    else
                    {
                        modCommon.Show($"Error eliminando el Curso {Cource.Name}");
                    }
                }
            }
            LoadStats();
        }

        private void BT_DeleteStudent_Click(object sender, EventArgs e)
        {
            var List = LV_Students.Items;
            var toRemove = new Dictionary<Student, ListViewItem>();
            for (int i = 0; i < List.Count; i++)
            {
                ListViewItem item = (ListViewItem)List[i];
                if (item.Checked)
                {
                    Student student = (Student)item.SubItems[0].Tag;
                    if (student != null)
                    {
                        toRemove.Add(student, item);
                    }
                }
            }
            if (toRemove.Any())
            {
                string students = toRemove.Count == 1 ? $"al estudiante {toRemove.FirstOrDefault().Key.Names}" : "a los estudiantes seleccionados";
                var dialog = MessageBox.Show($"Esta seguro que desea eliminar {students}?", "", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    foreach (var KV in toRemove)
                    {
                        if (StudentDB.RemoveStudent(KV.Key))
                        {
                            LV_Students.Items.Remove(KV.Value);
                        }
                        else
                        {
                            modCommon.Show($"Error eliminando el estudiante {KV.Key.Names}");
                        }
                    }
                }
            }
        }

        private void BT_UpdateCources_Click(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void BT_CourceBack_Click(object sender, EventArgs e)
        {
            SelectTab(tabPage_CourceStats);
        }
    }
}


