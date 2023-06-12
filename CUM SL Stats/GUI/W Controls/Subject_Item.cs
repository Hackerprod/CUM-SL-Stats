using System;
using System.Drawing;
using System.Windows.Forms;
using SKYNET.Models;
using SKYNET.DB;

namespace SKYNET.GUI.W_Controls
{
    public partial class Subject_Item : UserControl
    {
        public Subject Subject;

        public Subject_Item(Subject subject)
        {
            InitializeComponent();

            Subject = subject;

            LB_SubjectName.Text = Subject.Name;
            TB_SubjectName.Text = Subject.Name;

            BT_Save.Location = BT_Edit.Location;
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            BackColor = Color.FromArgb(240, 240, 240);
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White; 
        }

        private void BT_Edit_Click(object sender, EventArgs e)
        {
            LB_SubjectName.Visible = false;
            TB_SubjectName.Visible = true;
            BT_Save.Visible = true;
            BT_Edit.Visible = false;
            TB_SubjectName.Focus();
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
            UpdateSubject(true);
        }

        private void UpdateSubject(bool Update)
        {
            LB_SubjectName.Visible = true;
            TB_SubjectName.Visible = false;
            BT_Save.Visible = false;
            BT_Edit.Visible = true;

            if (Update && LB_SubjectName.Text != TB_SubjectName.Text)
            {
                LB_SubjectName.Text = TB_SubjectName.Text;
                Subject.Name = TB_SubjectName.Text;
                SubjectDB.Update(Subject);
            }
        }

        private void TB_SubjectName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                UpdateSubject(true);
            }
            if (e.KeyData == Keys.Escape)
            {
                UpdateSubject(false);
            }
        }
    }
}
