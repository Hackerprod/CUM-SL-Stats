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
    public partial class Group_Control : UserControl
    {
        public Group_Control()
        {
            InitializeComponent();

            for (int i = 0; i < frmMain.Manager.SchoolCources.Count; i++)
            {
                SchoolCource cource = frmMain.Manager.SchoolCources[i];
                CB_SchoolCource.Items.Add(cource.Name);
                CB_SchoolCource.SelectedIndex = i;
            }
        }

        private void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_GroupName.Text))
            {
                MessageBox.Show("Debe especificar el nombre del Curso para continuar");
                return;
            }

            if (!frmMain.Manager.GetCource(CB_SchoolCource.Text, out SchoolCource Cource))
            {
                MessageBox.Show("Debe especificar un curso válido");
                return;
            }
            
            if (!frmMain.Manager.GetCareer(CB_Career.Text, out Career career))
            {
                MessageBox.Show($"La carrera {CB_Career.Text} no existe.");
                return;
            }

            Group target = frmMain.Manager.GetGroup(TB_GroupName.Text);
            if (target != null)
            {
                MessageBox.Show($"El grupo {TB_GroupName.Text} ya existe.");
                return;
            }

            Group group = new Group()
            {
                Name = TB_GroupName.Text,
                ID = frmMain.Manager.CreateGroupId(),
                CareerID = career.ID,
                CourceID = Cource.ID
            };
            frmMain.frm.RegisterData(RegisterType.Group, group);
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
    }
}
