using System;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Models;

namespace SKYNET.Controls
{
    public partial class SchoolCource_Control : UserControl
    {
        public SchoolCource_Control()
        {
            InitializeComponent();
        }

        private void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_CourseName.Text))
            {
                MessageBox.Show("Debe especificar el nombre del Curso a registrar");
                return;
            }

            if (!SchoolCourceDB.IsValidCourceName(TB_CourseName.Text, out string CourceName))
            {
                MessageBox.Show("El nombre del curso no tiene un formato correcto");
                return;
            }
            SchoolCource schoolCource = new SchoolCource()
            {
                ID = SchoolCourceDB.CreateCourceId(),
                Name = CourceName
            };

            frmMain.frm.RegisterData(RegisterType.SchoolCource, schoolCource);
        }
    }
}
