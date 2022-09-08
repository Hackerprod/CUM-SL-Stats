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
                    CH_SchoolCource.Items.Add(cource.Name);
                }

                foreach (var career in CareerDB.Careers)
                {
                    CH_Career.Items.Add(career.Name);
                }

                Loaded = true;
            }
            catch
            {
                Loaded = false;
            }
        }

        public void LoadData()
        {
            LV_Groups.Items.Clear();

            Task.Run(delegate 
            {
                foreach (var group in GroupDB.Groups)
                {
                    try
                    {
                        var Cource = SchoolCourceDB.GetCource(group.CourceID);
                        var Career = CareerDB.GetCareer(group.CareerID);

                        var lvItem = new ListViewItem();
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());

                        lvItem.SubItems[0].Tag = group;
                        lvItem.SubItems[1].Text = Cource == null ? "Invalid" : Cource.Name;
                        lvItem.SubItems[2].Text = Career == null ? "Invalid" : Career.Name;
                        lvItem.SubItems[3].Text = group.Name;
                        lvItem.SubItems[4].Text = StudentDB.GetCourceYear(Cource, frmMain.Settings.CurrentCource);
                        lvItem.SubItems[5].Text = StudentDB.GetStudents(group).Count.ToString();
                        LV_Groups.Items.Add(lvItem);
                    }
                    catch
                    {
                    }
                }
            });
        }

        private void LV_Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Loaded)
            {
                LoadCourceAndCareer();
            }

            try
            {
                GroupSelected = (Group)LV_Groups.SelectedItems[0].SubItems[0].Tag;
                TB_Name.Text = GroupSelected.Name;

                SchoolCourceSelected = SchoolCourceDB.GetCource(GroupSelected.CourceID);
                for (int i = 0; i < CH_SchoolCource.Items.Count; i++)
                {
                    if (CH_SchoolCource.Items[i].ToString() == SchoolCourceSelected.Name)
                    {
                        CH_SchoolCource.SelectedIndex = i;
                    }
                }

                CareerSelected = CareerDB.GetCareer(GroupSelected.CareerID);
                for (int i = 0; i < CH_Career.Items.Count; i++)
                {
                    if (CH_Career.Items[i].ToString() == CareerSelected.Name)
                    {
                        CH_Career.SelectedIndex = i;
                    }
                }
            }
            catch 
            {
            }
        }

        private void CH_SchoolCource_SelectedIndexChanged(object sender, EventArgs e)
        {
            SchoolCourceSelected = SchoolCourceDB.GetCourceByName(CH_SchoolCource.Text);
        }

        private void CH_Career_SelectedIndexChanged(object sender, EventArgs e)
        {
            CareerSelected = CareerDB.GetCareer(CH_Career.Text);
        }

        private void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_Name.Text))
            {
                MessageBox.Show($"El Nombre especificado no es válido");
                return;
            }
            if (string.IsNullOrEmpty(CH_SchoolCource.Text))
            {
                MessageBox.Show($"El Curso especificado no es válido");
                return;
            }
            if (string.IsNullOrEmpty(CH_Career.Text))
            {
                MessageBox.Show($"La Carrera especificada no es válida");
                return;
            }

            if (SchoolCourceSelected == null)
            {
                var Dialog = MessageBox.Show($"El Curso {CH_SchoolCource.Text} no existe" + Environment.NewLine + "Desea agregarlo?", "", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    SchoolCourceSelected = new SchoolCource()
                    {
                        ID = SchoolCourceDB.CreateCourceId(),
                        Name = CH_SchoolCource.Text
                    };
                    SchoolCourceDB.RegisterSchoolCource(SchoolCourceSelected);
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (SchoolCourceSelected.Name != CH_SchoolCource.Text)
                {
                    var Dialog = MessageBox.Show($"El Curso {CH_SchoolCource.Text} no existe" + Environment.NewLine + "Desea agregarlo?", "", MessageBoxButtons.YesNo);
                    if (Dialog == DialogResult.Yes)
                    {
                        SchoolCourceSelected = new SchoolCource()
                        {
                            ID = SchoolCourceDB.CreateCourceId(),
                            Name = CH_SchoolCource.Text
                        };
                        SchoolCourceDB.RegisterSchoolCource(SchoolCourceSelected);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (CareerSelected == null)
            {
                var Dialog = MessageBox.Show($"La carrera {CH_Career.Text} no existe" + Environment.NewLine + "Desea agregarlo?", "", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    CareerSelected = new Career()
                    {
                        ID = CareerDB.CreateCareerId(),
                        Name = CH_Career.Text,
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
                if (SchoolCourceSelected.Name != CH_SchoolCource.Text)
                {
                    var Dialog = MessageBox.Show($"La carrera {CH_Career.Text} no existe" + Environment.NewLine + "Desea agregarlo?", "", MessageBoxButtons.YesNo);
                    if (Dialog == DialogResult.Yes)
                    {
                        CareerSelected = new Career()
                        {
                            ID = CareerDB.CreateCareerId(),
                            Name = CH_Career.Text,
                        };
                        frmMain.frm.RegisterData(RegisterType.Career, CareerSelected);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            GroupSelected.CareerID = CareerSelected.ID;
            GroupSelected.CourceID = SchoolCourceSelected.ID;
            GroupSelected.Name = TB_Name.Text;
            GroupDB.UpdateGroup(GroupSelected);

            LV_Groups.Items.Clear();
            CH_SchoolCource.Items.Clear();
            CH_Career.Items.Clear();

            LoadData();
            LoadCourceAndCareer();
        }

        private void BT_RemoveGroup_Click(object sender, EventArgs e)
        {
            if (GroupSelected != null)
            {
                var Dialog = MessageBox.Show($"Esta a punto de eliminar el grupo {GroupSelected.Name}, junto con el grupo se eliminarán los estudiantes asociados a ese grupo." + Environment.NewLine + "Desea continuar?", "", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    StudentDB.RemoveStudents(GroupSelected);
                    GroupDB.Remove(GroupSelected);
                    LoadData();
                    LoadCourceAndCareer();

                    TB_Name.Clear();
                    CH_SchoolCource.Items.Clear();
                    CH_Career.Items.Clear();
                }
            }
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          