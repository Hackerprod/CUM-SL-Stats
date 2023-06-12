using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYNET.Controls;
using SKYNET.DB;
using SKYNET.Helpers;
using SKYNET.Managers;
using SKYNET.Models;
using SQLite;
using SQLite.Net;
using SQLite.Net.Interop;

namespace SKYNET
{
    public partial class frmMain : Form
    {
        public static frmMain frm;
        public static SettingsManager Settings;

        public RegisterType CurrentRegisterType;
        public TabPage LastTab;

        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            frm = this;
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            SetEnabledControls(false);

            Settings = new SettingsManager();
            Settings.Load();

            TB_Departament.Text = Settings.CurrentDepartament;

            DBManager.Initialize();

            LastTab = tabPage_Home;

            this.EnableBlur();
            BackColor = Color.Azure;
            TransparencyKey = Color.Azure;

            ChartManager.LoadPieChart(pieChart1);

            SetEnabledControls(true);
        }

        private void SetEnabledControls(bool v)
        {
            BN_Start.Enabled = true;
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

        public void SelectTab(TabPage tabPage)
        {
            try
            {
                LastTab = TabControl1.SelectedTab;
                TabControl1.SelectTab(tabPage);
            }
            catch 
            {
            }
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
                case RegisterType.StudyPlan:
                    {
                        PN_RegisterContainer.Controls.Add(new StudyPlan_Control()
                        {
                            Dock = DockStyle.Fill
                        });
                    }
                    break;
            }
            SelectTab(tabPage_Register);
        }

        public async Task<bool> RegisterData(RegisterType type, object Data, bool other = false, bool notify = true)
        {
            switch (type)
            {
                case RegisterType.SchoolCource:
                    {
                        SchoolCource schoolCource = (SchoolCource)Data;
                        if (await SchoolCourceDB.Register(schoolCource))
                        {
                            if (notify)
                            {
                                Common.Show($"El Curso {schoolCource.Name} se ha registrado correctamente");
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
                        if (await CareerDB.Register(Career))
                        {
                            if (notify)
                            {
                                Common.Show($"La Carrera {Career.Name} se ha registrado correctamente");
                            }
                            SelectTab(LastTab);
                            return true;
                        }
                        return false;
                    }
                case RegisterType.Student:
                    {
                        Student student = (Student)Data;
                        bool registered = await StudentDB.Register(student);
                        if (registered && !other)
                        {
                            if (notify)
                            {
                                Common.Show($"El estudiante {student.Names} se ha registrado correctamente");
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
                        if (await SubjectDB.Register(subject))
                        {
                            if (notify)
                            {
                                Common.Show($"La asignatura {subject.Name} se ha guardado correctamente");
                            }
                            SelectTab(LastTab);
                            return true;
                        }
                        return false;
                    }
                case RegisterType.Group:
                    {
                        Group group = (Group)Data;

                        bool registered = await GroupDB.Register(group);
                        if (registered)
                        {
                            if (notify)
                            {
                                Common.Show($"El Grupo {group.Name} se ha guardado correctamente");
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
                                        item.SubItems[1].Text = student.CI.ToString();
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

        public async void LoadStats()
        {
            LV_Cources.Items.Clear();

            var stats = new List<ChartManager.CourceStats>();
            var SchoolCources = await SchoolCourceDB.Get();
            SchoolCources.Sort((x, y) => x.Name.CompareTo(y.Name));
            foreach (var Cource in SchoolCources)
            {
                var Actives = await StudentDB.GetActiveStudents(Cource);
                var EnrolledAndGraduates = await StudentDB.GetEnrolledAndGraduates(Cource);
                var Evaluations = await StudentDB.GetCourceEvaluations(Cource);

                stats.Add(new ChartManager.CourceStats()
                {
                    Cource = Cource,
                    Enrolled = EnrolledAndGraduates.Item1,
                    Graduates = EnrolledAndGraduates.Item2,
                    Active = Actives,
                });

                int Groups = 0;
                foreach (var career in await CareerDB.Get(Cource))
                {
                    Groups += (await GroupDB.Get(Cource, career)).Count;
                }

                var lvItem = new ListViewItem();
                lvItem.SubItems.Add(Cource.Name);
                lvItem.SubItems.Add((await CareerDB.Get(Cource)).Count.ToString());
                lvItem.SubItems.Add(Groups.ToString());
                lvItem.SubItems.Add(EnrolledAndGraduates.Item1.ToString());
                lvItem.SubItems.Add(Actives.ToString());
                lvItem.SubItems[0].Tag = Cource;

                LV_Cources.Items.Add(lvItem);
            }

            ChartManager.LoadCartesianChart(cartesianChart1, stats);
            SelectTab(tabPage_MainStats);
            LV_Students.Items.Clear();
        }

        private async void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SchoolCource Cource = (SchoolCource)LV_Cources.SelectedItems[0].SubItems[0].Tag;
            if (Cource != null)
            {
                var Careers = await CareerDB.Get(Cource);
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

        private async void LoadCourceStats(SchoolCource Cource)
        {
            LV_Careers.Items.Clear();
            var Cources = await SchoolCourceDB.GetActiveCources(Cource.ID);

            foreach (var cource in Cources)
            {
                var Careers = await CareerDB.Get(cource);
                foreach (var career in Careers)
                {
                    var lvItem = new ListViewItem();
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());

                    lvItem.SubItems[0].Text = career.Name;
                    lvItem.SubItems[1].Text = await StudentDB.GetCourceYear(cource, Settings.CurrentCource); 
                    lvItem.SubItems[0].Tag  = career;
                    lvItem.SubItems[1].Tag  = cource;

                    LV_Careers.Items.Add(lvItem);
                }
            }

            SelectTab(tabPage_CourceStats);
        }

        private async void LV_Groups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LV_Students.Items.Clear();
            Group group = (Group)LV_Groups.SelectedItems[0].SubItems[0].Tag;

            if (group != null)
            {
                var Cource = await SchoolCourceDB.Get(group.CourceID);
                var Students = await StudentDB.Get(group);
                foreach (var student in Students)
                {
                    var lvItem = new ListViewItem();
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());

                    string status = "";
                    switch (student.Status)
                    {
                        case Status.Unknown:    status = "Desconocido"; break;
                        case Status.Active:     status = "Activo"; break;
                        case Status.Graduated:  status = "Graduado"; break;
                        case Status.Down:       status = "Baja"; break;
                    }

                    lvItem.SubItems[0].Tag = student;
                    lvItem.SubItems[1].Text = student.CI.ToString();
                    lvItem.SubItems[2].Text = student.Names;
                    lvItem.SubItems[3].Text = Cource.Name;
                    lvItem.SubItems[4].Text = student.Sex.ToString();
                    lvItem.SubItems[5].Text = status;

                    LV_Students.Items.Add(lvItem);
                }
                CustomizeItem(LV_Groups, LV_Groups.SelectedItems[0].Text, 0, Color.FromArgb(0, 120, 215), Color.White);
            }
        }

        private async void LV_Careers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Groups.Items.Clear();
                var Career = (Career)LV_Careers.SelectedItems[0].SubItems[0].Tag;
                var Cource = (SchoolCource)LV_Careers.SelectedItems[0].SubItems[1].Tag;

                if (Cource != null && Career != null)
                {
                    var Groups = await GroupDB.Get(Cource, Career);
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
            var printDialog = new PrintDialog()
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

        private async void BN_Evaluate_Click(object sender, EventArgs e)
        {
            try
            {
                LV_Evaluate.Items.Clear();
                Career Career = (Career)LV_Careers.SelectedItems[0].SubItems[0].Tag;
                SchoolCource Cource = (SchoolCource)LV_Careers.SelectedItems[0].SubItems[1].Tag;
                Group Group = (Group)LV_Groups.SelectedItems[0].SubItems[0].Tag;
                if (Career != null)
                {
                    var Students = await StudentDB.Get(Group);
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

                        lvItem.SubItems[1].Text = student.CI.ToString();
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

            CustomizeItem(LV_Evaluate, student.CI.ToString(), 1, Color.FromArgb(0, 120, 215), Color.White);
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
                Common.Show("Por favor, Marque el estudiante al que desea mostrar sus estadísticas");
            }
            else
            {
                Common.Show("Implementar estadística para " + student.Names);
            }
        }

        private void BT_EditStudent_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < LV_Students.Items.Count; i++)
                {
                    ListViewItem item = LV_Students.Items[i];
                    if (item.Checked)
                    {
                        Student Student = (Student)item.SubItems[0].Tag;
                        Student_Control student = new Student_Control(Student)
                        {
                            Dock = DockStyle.Fill,
                        };
                        PN_RegisterContainer.Controls.Clear();
                        PN_RegisterContainer.Controls.Add(student);
                        SelectTab(tabPage_Register);
                        return;
                    }
                }
                Common.Show("Seleccione el estudiante que desea editar");
            }
            catch 
            {
                //Common.Show("Seleccione el estudiante que desea editar");
            }
        }

        private void BT_AddCource_Click(object sender, EventArgs e)
        {
            Register(RegisterType.SchoolCource);
        }

        private async void BT_RemoveCource_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in LV_Cources.Items)
            {
                if (item.Selected)
                {
                    var Cource = (SchoolCource)item.SubItems[0].Tag;
                    if (await SchoolCourceDB.Remove(Cource))
                    {
                        Common.Show($"El Curso {Cource.Name} se ha eliminado correctamente");
                    }
                    else
                    {
                        Common.Show($"Error eliminando el Curso {Cource.Name}");
                    }
                }
            }
            LoadStats();
        }

        private async void BT_DeleteStudent_Click(object sender, EventArgs e)
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
                        if (await StudentDB.Remove(KV.Key))
                        {
                            LV_Students.Items.Remove(KV.Value);
                        }
                        else
                        {
                            Common.Show($"Error eliminando el estudiante {KV.Key.Names}");
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

        public void Notify(string msg, SKYNET_AlertBox.NotificationType flag = SKYNET_AlertBox.NotificationType.Success)
        {
            AlertBox.ShowControl(flag, msg, 3500);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}


