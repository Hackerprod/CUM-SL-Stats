using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Models;

namespace SKYNET.Controls
{
    public partial class Groups_Control : UserControl
    {
        private Group GroupSelected;
        private SchoolCource SchoolCourceSelected;
        private Career CareerSelected;
        private StudyPlan StudyPlanSelected;
        private bool Loaded;

        public Groups_Control()
        {
            InitializeComponent();

            LoadCourceAndCareer();
        }

        private void LoadCourceAndCareer()
        {
            try
            {
                foreach (var cource in SchoolCourceDB.SchoolCources)
                {
                    CB_SchoolCource.Items.Add(cource.Name);
                }

                foreach (var career in CareerDB.Careers)
                {
                    CB_Career.Items.Add(career.Name);
                }

                foreach (var plan in StudyPlansDB.StudyPlans)
                {
                    CB_StudyPlan.Items.Add(plan.Name);
                }

                Loaded = true;
            }
            catch
            {
                Loaded = false;
            }
        }

        public async Task LoadData()
        {
            LV_Groups.Items.Clear();

            LoadCourceAndCareer();

            await Task.Delay(250);

            var Groups = GroupDB.Groups;
            Groups.Sort((s1, s2) => s2.Name.CompareTo(s1.Name));
            Groups.Reverse();
            foreach (var group in Groups)
            {
                try
                {
                    //Common.Show(group == null);
                    var Cource = SchoolCourceDB.Get(group.CourceID);
                    var Career = CareerDB.Get(group.CareerID);

                    var lvItem = new ListViewItem();
                    lvItem.SubItems.Add(Cource == null ? "Invalid" : Cource.Name);
                    lvItem.SubItems.Add(Career == null ? "Invalid" : Career.Name);
                    lvItem.SubItems.Add(group.Name);
                    lvItem.SubItems.Add(StudentDB.GetCourceYear(Cource, frmMain.Settings.CurrentCource));
                    lvItem.SubItems.Add(StudentDB.GetStudents(group).Count.ToString());
                    lvItem.Tag = group;

                    LV_Groups.Items.Add(lvItem);
                }
                catch
                {
                }
            }
        }

        private void LV_Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Loaded)
            {
                LoadCourceAndCareer();
            }

            try
            {
                GroupSelected = (Group)LV_Groups.SelectedItems[0].Tag;
                TB_Name.Text = GroupSelected.Name;
                CB_StudyPlan.Text = "";

                SchoolCourceSelected = SchoolCourceDB.Get(GroupSelected.CourceID);
                if (SchoolCourceSelected != null)
                {
                    for (int i = 0; i < CB_SchoolCource.Items.Count; i++)
                    {
                        if (CB_SchoolCource.Items[i].ToString() == SchoolCourceSelected?.Name)
                        {
                            CB_SchoolCource.SelectedIndex = i;
                        }
                    }
                }

                CareerSelected = CareerDB.Get(GroupSelected.CareerID);
                if (CareerSelected != null)
                {
                    for (int i = 0; i < CB_Career.Items.Count; i++)
                    {
                        if (CB_Career.Items[i].ToString() == CareerSelected?.Name)
                        {
                            CB_Career.SelectedIndex = i;
                        }
                    }
                }

                StudyPlanSelected = StudyPlansDB.Get(GroupSelected.StudyPlanID);
                if (StudyPlanSelected != null)
                {
                    for (int i = 0; i < CB_StudyPlan.Items.Count; i++)
                    {
                        if (CB_StudyPlan.Items[i].ToString() == StudyPlanSelected?.Name)
                        {
                            CB_StudyPlan.SelectedIndex = i;
                        }
                    }
                }
            }
            catch 
            {
            }
        }

        private void CH_SchoolCource_SelectedIndexChanged(object sender, EventArgs e)
        {
            SchoolCourceSelected = SchoolCourceDB.Get(CB_SchoolCource.Text);
        }

        private void CH_Career_SelectedIndexChanged(object sender, EventArgs e)
        {
            CareerSelected = CareerDB.Get(CB_Career.Text);
        }

        private void CB_StudyPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudyPlanSelected = StudyPlansDB.Get(CB_StudyPlan.Text);
        }

        private void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_Name.Text))
            {
                MessageBox.Show($"El Nombre especificado no es válido");
                return;
            }

            if (string.IsNullOrEmpty(CB_SchoolCource.Text))
            {
                MessageBox.Show($"El Curso especificado no es válido");
                return;
            }

            if (string.IsNullOrEmpty(CB_Career.Text))
            {
                MessageBox.Show($"La Carrera especificada no es válida");
                return;
            }

            if (string.IsNullOrEmpty(CB_StudyPlan.Text))
            {
                MessageBox.Show($"El Plan de estudio especificado no es válido");
                return;
            }

            if (StudyPlanSelected == null)
            {
                var Dialog = MessageBox.Show($"El Plan de estudio {CB_StudyPlan.Text} no existe" + Environment.NewLine + "Desea agregarlo?", "", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    StudyPlanSelected = new StudyPlan()
                    {
                        ID = StudyPlansDB.CreateID(),
                        Name = CB_StudyPlan.Text
                    };
                    StudyPlansDB.Register(StudyPlanSelected);
                }
                else
                {
                    return;
                }
            }

            if (SchoolCourceSelected == null)
            {
                var Dialog = MessageBox.Show($"El Curso {CB_SchoolCource.Text} no existe" + Environment.NewLine + "Desea agregarlo?", "", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    SchoolCourceSelected = new SchoolCource()
                    {
                        ID = SchoolCourceDB.CreateID(),
                        Name = CB_SchoolCource.Text
                    };
                    SchoolCourceDB.Register(SchoolCourceSelected);
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (SchoolCourceSelected.Name != CB_SchoolCource.Text)
                {
                    var Dialog = MessageBox.Show($"El Curso {CB_SchoolCource.Text} no existe" + Environment.NewLine + "Desea agregarlo?", "", MessageBoxButtons.YesNo);
                    if (Dialog == DialogResult.Yes)
                    {
                        SchoolCourceSelected = new SchoolCource()
                        {
                            ID = SchoolCourceDB.CreateID(),
                            Name = CB_SchoolCource.Text
                        };
                        SchoolCourceDB.Register(SchoolCourceSelected);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (CareerSelected == null)
            {
                var Dialog = MessageBox.Show($"La carrera {CB_Career.Text} no existe" + Environment.NewLine + "Desea agregarlo?", "", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    CareerSelected = new Career()
                    {
                        ID = CareerDB.CreateID(),
                        Name = CB_Career.Text,
                    };
                    frmMain.frm.RegisterData(RegisterType.Career, CareerSelected);
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (SchoolCourceSelected.Name != CB_SchoolCource.Text)
                {
                    var Dialog = MessageBox.Show($"La carrera {CB_Career.Text} no existe" + Environment.NewLine + "Desea agregarlo?", "", MessageBoxButtons.YesNo);
                    if (Dialog == DialogResult.Yes)
                    {
                        CareerSelected = new Career()
                        {
                            ID = CareerDB.CreateID(),
                            Name = CB_Career.Text,
                        };
                        frmMain.frm.RegisterData(RegisterType.Career, CareerSelected);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            GroupSelected.StudyPlanID = StudyPlanSelected.ID;
            GroupSelected.CareerID = CareerSelected.ID;
            GroupSelected.CourceID = SchoolCourceSelected.ID;
            GroupSelected.Name = TB_Name.Text;
            GroupDB.Update(GroupSelected);

            LV_Groups.Items.Clear();
            CB_SchoolCource.Items.Clear();
            CB_Career.Items.Clear();

            LoadData();
            LoadCourceAndCareer();
        }

        private async void BT_RemoveGroup_Click(object sender, EventArgs e)
        {
            if (GroupSelected != null)
            {
                var Dialog = MessageBox.Show($"Esta a punto de eliminar el grupo {GroupSelected.Name}, junto con el grupo se eliminarán los estudiantes asociados a ese grupo." + Environment.NewLine + "Desea continuar?", "", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    StudentDB.Remove(GroupSelected);
                    GroupDB.Remove(GroupSelected);
                    await LoadData();
                    LoadCourceAndCareer();

                    TB_Name.Clear();
                    CB_SchoolCource.Items.Clear();
                    CB_Career.Items.Clear();
                }
            }
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          