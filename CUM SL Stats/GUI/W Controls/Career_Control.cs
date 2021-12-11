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
    public partial class Career_Control : UserControl
    {
        public Career_Control()
        {
            InitializeComponent();
        }

        private void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_Career.Text))
            {
                MessageBox.Show("Debe especificar el nombre de la carrera para continuar");
                return;
            }
            Career Career = frmMain.Manager.GetCareer(TB_Career.Text);

            if (Career != null)
            {
                MessageBox.Show($"La carrera \"{TB_Career.Text}\" ya existe");
                return;
            }

            Career = new Career()
            {
                ID = frmMain.Manager.CreateCareerId(),
                Name = TB_Career.Text,
            };
            frmMain.frm.RegisterData(RegisterType.Career, Career);

        }
    }
}
