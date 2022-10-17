using System;
using System.Windows.Forms;
using SKYNET.DB;
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
            Career Career = CareerDB.Get(TB_Career.Text);

            if (Career != null)
            {
                MessageBox.Show($"La carrera \"{TB_Career.Text}\" ya existe");
                return;
            }

            Career = new Career()
            {
                ID = CareerDB.CreateID(),
                Name = TB_Career.Text,
            };
            frmMain.frm.RegisterData(RegisterType.Career, Career);

        }
    }
}
