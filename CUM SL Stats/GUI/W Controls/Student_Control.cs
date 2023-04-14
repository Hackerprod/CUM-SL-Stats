using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Managers;
using SKYNET.Models;

namespace SKYNET.Controls
{
    public partial class Student_Control : UserControl
    {
        private Student _student;

        public async Task SetStudent(Student value) 
        {
            _student = value;
            if (value != null)
            {
                try
                {
                    TB_StudentName.Text = value.Names;
                    TB_CI.Text = value.CI.ToString();
                    TB_CI.Enabled = false;

                    Group currentGroup = await GroupDB.Get(value.GroupID);
                    SchoolCource currentCource = null;
                    Career currentCareer = null;

                    {
                        currentCource = await SchoolCourceDB.Get(currentGroup);
                        CB_SchoolCource.Text = currentCource?.Name;
                        CB_SchoolCource.Tag = currentCource;

                        var SchoolCources = await SchoolCourceDB.Get();

                        for (int i = 0; i < SchoolCources.Count; i++)
                        {
                            var Cource = SchoolCources[i];
                            CB_SchoolCource.Items.Add(Cource.Name);
                            if (currentCource?.ID == Cource.ID)
                            {
                                CB_SchoolCource.SelectedIndex = i;
                            }
                        }
                    }

                    {
                        currentCareer = await CareerDB.Get(currentGroup);
                        CB_Career.Text = currentCareer?.Name;
                        CB_Career.Tag = currentCareer;

                        var Careers = await CareerDB.Get();

                        for (int i = 0; i < Careers.Count; i++)
                        {
                            var career = Careers[i];
                            CB_Career.Items.Add(career.Name);
                            if (currentCareer?.ID == career.ID)
                            {
                                CB_SchoolCource.SelectedIndex = i;
                            }
                        }
                    }

                    {
                        var Groups = await GroupDB.Get(currentCource, currentCareer);

                        for (int i = 0; i < Groups.Count; i++)
                        {
                            var group = Groups[i];
                            CB_Group.Items.Add(group.Name);
                            if (currentGroup?.ID == group.ID)
                            {
                                CB_Group.SelectedIndex = i;
                            }
                        }

                        CB_Group.Text = currentGroup?.Name;
                        CB_Group.Tag = currentGroup;
                    }

                    CB_Status.SelectedIndex = (int)_student.Status;

                    BT_Register.Text = "Actualizar";
                    BT_Register.Location = new Point(138, 370);
                    BT_RegisterOther.Visible = false;

                    SexSelector.Sex = value.Sex;
                    SexSelector.BlockSelector = true;
                }
                catch (Exception ex)
                {
                    Common.Show(ex);
                }
            }
        }

        public Student_Control()
        {
            InitializeComponent();

            Initialize();
        }

        private async void Initialize()
        {
            TB_StudentName.TextChanged += TB_StudentName_TextChanged;

            var SchoolCources = await SchoolCourceDB.Get();

            for (int i = 0; i < SchoolCources.Count; i++)
            {
                var Cource = SchoolCources[i];
                CB_SchoolCource.Items.Add(Cource.Name);
                CB_SchoolCource.SelectedIndex = i;
            }

            CB_Status.SelectedIndex = 1;
        }

        public Student_Control(Student student)
        {
            InitializeComponent();

            TB_StudentName.TextChanged += TB_StudentName_TextChanged;

            SetStudent(student);
        }

        private void TB_StudentName_TextChanged(object sender, EventArgs e)
        {
            if (TB_StudentName.Text.Contains(","))
            {
                try
                {
                    string result = "";
                    var parts = TB_StudentName.Text.Split(',');
                    result = parts[1].Remove(0, 1) + " " + parts[0];
                    TB_StudentName.Text = result;
                }
                catch
                {
                }
            }
        }

        private void BT_Register_Click(object sender, EventArgs e)
        {
            Register(false);
        }

        private void BT_RegisterOther_Click(object sender, EventArgs e)
        {
            Register(true);
        }

        private async void Register(bool other)
        {
            if (string.IsNullOrEmpty(TB_StudentName.Text))
            {
                MessageBox.Show("Debe especificar el nombre del estudiante a registrar");
                return;
            }
            if (string.IsNullOrEmpty(TB_CI.Text))
            {
                MessageBox.Show("Debe especificar el CI del estudiante a registrar");
                return;
            }
            if (string.IsNullOrEmpty(CB_Career.Text))
            {
                MessageBox.Show("Debe especificar el nombre de la carrera para continuar");
                return;
            }
            if (string.IsNullOrEmpty(CB_SchoolCource.Text))
            {
                MessageBox.Show("Debe seleccionar el curso para continuar");
                return;
            }

            var cource = await SchoolCourceDB.Get(CB_SchoolCource.Text);
            if (cource == null)
            {
                MessageBox.Show($"El curso {CB_SchoolCource.Text} no existe.");
                return;
            }

            var career = await CareerDB.Get(CB_Career.Text);
            if (career == null)
            {
                MessageBox.Show($"La carrera {CB_Career.Text} no existe.");
                return;
            }

            if (SexSelector.Sex == Sex.Unknown)
            {
                MessageBox.Show($"Especifique el sexo del estudiante");
                return;
            }

            Group group = await GroupDB.Get(CB_Group.Text);
            if (group == null)
            {
                group = new Group()
                { 
                    CourceID = cource.ID,
                    CareerID = career.ID, 
                    Name = CB_Group.Text
                };
                if (await GroupDB.Register(group) == false)
                {
                    Common.Show($"Error creando el grupo {CB_Group.Text}");
                    return;
                }
            }

            Status status = (Status)CB_Status.SelectedIndex;

            if (_student == null)
            {
                var student = new Student()
                {
                    CI = TB_CI.Text,
                    Names = TB_StudentName.Text,
                    GroupID = group.ID,
                    Sex = SexSelector.Sex, 
                    Status = status
                };
                if (await frmMain.frm.RegisterData(RegisterType.Student, student, other) && other)
                {
                    TB_StudentName.Text = "";
                    TB_CI.Text = "";
                }
            }
            else
            {
                _student.Names = TB_StudentName.Text;
                _student.GroupID = group.ID;
                _student.Status = status;

                StudentDB.Update(_student);
                frmMain.frm.RefreshUpdated(RegisterType.Student, _student);
                frmMain.frm.SelectTab();
            }
        }

        private async void CB_SchoolCource_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_Career.Items.Clear();

            var cource = await SchoolCourceDB.Get(CB_SchoolCource.Text);
            var careers = await CareerDB.Get(cource);

            for (int i = 0; i < careers.Count; i++)
            {
                Career career = careers[i];
                CB_Career.Items.Add(career.Name);
                CB_Career.SelectedIndex = i;
            }
        }

        private async void CB_Career_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_Group.Items.Clear();
            CB_Group.Text = "";

            var cource = await SchoolCourceDB.Get(CB_SchoolCource.Text);
            var career = await CareerDB.Get(CB_Career.Text);

            if (cource == null || career == null)
            {
                return;
            }
            var groups = await GroupDB.Get(cource, career);
            for (int i = 0; i < groups.Count; i++)
            {
                Group group = groups[i];
                CB_Group.Items.Add(group.Name);
                CB_Group.SelectedIndex = i;
            }
        }
    }
}
