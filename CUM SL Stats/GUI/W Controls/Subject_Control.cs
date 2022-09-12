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
    public partial class Subject_Control : UserControl
    {
        public Subject_Control()
        {
            InitializeComponent();
        }

        private void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_SubjectName.Text))
            {
                MessageBox.Show("Debe especificar el nombre de la carrera para continuar");
                return;
            }

            if (SubjectDB.Exists(TB_SubjectName.Text))
            {
                MessageBox.Show($"La asignatura {TB_SubjectName.Text} existe.");
                return;
            }

            Subject subject = new Subject()
            {
                ID = SubjectDB.CreateSubjectId(),
                Name = TB_SubjectName.Text,
            };

            var done = frmMain.frm.RegisterData(RegisterType.Subject, subject);
            if (done)
            {
                TB_SubjectName.Text = "";
            }
        }
    }
}
