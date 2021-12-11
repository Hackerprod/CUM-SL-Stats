using System;
using System.Drawing;
using System.Windows.Forms;
using SKYNET.Managers;
using SKYNET.Models;

namespace SKYNET.Controls
{
    public partial class Student_Control : UserControl
    {
        public Student Student 
        {
            get => _student;
            set
            {
                _student = value;
                if (value != null)
                {
                    try
                    {
                        TB_StudentName.Text = value.Names;
                        TB_CI.Text = value.CI;
                        TB_CI.Enabled = false;

                        SchoolCource cource = frmMain.Manager.GetCource(value.CourceID);
                        CB_SchoolCource.Text = cource?.Name;
                        CB_SchoolCource.Tag = cource;

                        Career career = frmMain.Manager.GetCareer(value.CareerID);
                        CB_Career.Text = career?.Name;
                        CB_Career.Tag = career;

                        Group group = frmMain.Manager.GetGroup(value.GroupID);
                        CB_Group.Text = group?.Name;
                        CB_Group.Tag = group;

                        CB_Status.SelectedIndex = (int)_student.Status;

                        BT_Register.Text = "Actualizar";
                        BT_Register.Location = new Point(138, 370);
                        BT_RegisterOther.Visible = false;

                        SexSelector.Sex = value.Sex;
                        SexSelector.BlockSelector = true;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
        private Student _student;

        public Student_Control()
        {
            InitializeComponent();

            TB_StudentName.TextChanged += TB_StudentName_TextChanged;

            for (int i = 0; i < frmMain.Manager.SchoolCources.Count; i++)
            {
                SchoolCource Cource = frmMain.Manager.SchoolCources[i];
                CB_SchoolCource.Items.Add(Cource.Name);
                CB_SchoolCource.SelectedIndex = i;
            }

            CB_Status.SelectedIndex = 1;
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

        private void Register(bool other)
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
            if (!frmMain.Manager.GetCource(CB_SchoolCource.Text, out SchoolCource cource))
            {
                MessageBox.Show($"El curso {CB_SchoolCource.Text} no existe.");
                return;
            }

            if (!frmMain.Manager.GetCareer(CB_Career.Text, out Career career))
            {
                MessageBox.Show($"La carrera {CB_Career.Text} no existe.");
                return;
            }

            if (SexSelector.Sex == Sex.Unknown)
            {
                MessageBox.Show($"Especifique el sexo del estudiante");
                return;
            }

            Group group = frmMain.Manager.GetGroup(CB_Group.Text);
            if (group == null)
            {
                group = new Group()
                { 
                    ID = frmMain.Manager.CreateGroupId(),
                    CourceID = cource.ID,
                    CareerID = career.ID, 
                    Name = CB_Group.Text
                };
                if (!frmMain.Manager.RegisterGroup(group))
                {
                    modCommon.Show($"Error creando el grupo {CB_Group.Text}");
                    return;
                }
            }

            Status status = (Status)CB_Status.SelectedIndex;

            if (_student == null)
            {
                _student = new Student()
                {
                    CI = TB_CI.Text,
                    Names = TB_StudentName.Text,
                    CareerID = career.ID,
                    CourceID = cource.ID,
                    GroupID = group.ID,
                    Sex = SexSelector.Sex,
                    Status = status
                };
                if (frmMain.frm.RegisterData(RegisterType.Student, _student, other) && other)
                {
                    TB_StudentName.Text = "";
                    TB_CI.Text = "";
                }
            }
            else
            {
                _student.Names = TB_StudentName.Text;
                _student.CareerID = career.ID;
                _student.CourceID = cource.ID;
                _student.GroupID = group.ID;
                _student.Status = status;

                frmMain.Manager.UpdateStudent(_student);
                frmMain.frm.RefreshUpdated(RegisterType.Student, _student);
                frmMain.frm.SelectTab();
            }
        }

        private void CB_SchoolCource_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_Career.Items.Clear();

            var cource = frmMain.Manager.GetCource(CB_SchoolCource.Text);
            var careers = frmMain.Manager.GetCareers(cource);

            for (int i = 0; i < careers.Count; i++)
            {
                Career career = careers[i];
                CB_Career.Items.Add(career.Name);
                CB_Career.SelectedIndex = i;
            }
        }

        private void CB_Career_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB_Group.Items.Clear();
            if (!frmMain.Manager.GetCource(CB_SchoolCource.Text, out SchoolCource cource) || !frmMain.Manager.GetCareer(CB_Career.Text, out Career career))
            {
                return;
            }
            var groups = frmMain.Manager.GetGroups(cource, career);
            for (int i = 0; i < groups.Count; i++)
            {
                Group group = groups[i];
                CB_Group.Items.Add(group.Name);
                CB_Group.SelectedIndex = i;
            }
        }


    }
}
