using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYNET.Models;
using SKYNET.DB;

namespace SKYNET.GUI.W_Controls
{
    public partial class Subject_Item : UserControl
    {
        Subject Subject;

        public Subject_Item(Subject subject)
        {
            InitializeComponent();

            Subject = subject;

            LB_SubnectName.Text = Subject.Name;
            TB_SubnectName.Text = Subject.Name;
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            BackColor = Color.FromArgb(240, 240, 240);
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White; ;
        }

        private void BT_Edit_Click(object sender, EventArgs e)
        {
            LB_SubnectName.Visible = false;
            TB_SubnectName.Visible = true;
            BT_Save.Visible = true;
            TB_SubnectName.Focus();
        }

        private void BT_Delete_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Esta seguro que desea eliminar la asignatura?", "", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                SubjectDB.Remove(Subject);
            }
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            LB_SubnectName.Visible = true;
            TB_SubnectName.Visible = false;
            BT_Save.Visible = false;

            if (LB_SubnectName.Text != TB_SubnectName.Text)
            {
                LB_SubnectName.Text = TB_SubnectName.Text;
                Subject.Name = TB_SubnectName.Text;
                SubjectDB.Update(Subject);
                sd
            }
        }
    }
}
