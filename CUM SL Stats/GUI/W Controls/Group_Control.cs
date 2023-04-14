using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Managers;
using SKYNET.Models;

namespace SKYNET.Controls
{
    public partial class Group_Control : UserControl
    {
        public Group_Control()
        {
            InitializeComponent();
            Initialize();
        }

        private async void Initialize()
        {
            var SchoolCources = await SchoolCourceDB.Get();
            for (int i = 0; i < SchoolCources.Count; i++)
            {
                var cource = SchoolCources[i];
                CB_SchoolCource.Items.Add(cource.Name);
                CB_SchoolCource.SelectedIndex = i;
            }
        }

        private async void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_GroupName.Text))
            {
                MessageBox.Show("Debe especificar el nombre del Curso para continuar");
                return;
            }

            var Cource = await SchoolCourceDB.Get(CB_SchoolCource.Text);
            if (Cource == null)
            {
                MessageBox.Show("Debe especificar un curso válido");
                return;
            }

            var Career = await CareerDB.Get(CB_Career.Text);
            if (Career == null)
            {
                MessageBox.Show($"La carrera {CB_Career.Text} no existe.");
                return;
            }

            var target = await GroupDB.Get(TB_GroupName.Text);
            if (target != null)
            {
                MessageBox.Show($"El grupo {TB_GroupName.Text} ya existe.");
                return;
            }

            Group group = new Group()
            {
                Name = TB_GroupName.Text,
                CareerID = Career.ID,
                CourceID = Cource.ID
            };
            frmMain.frm.RegisterData(RegisterType.Group, group);
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
    }
}
