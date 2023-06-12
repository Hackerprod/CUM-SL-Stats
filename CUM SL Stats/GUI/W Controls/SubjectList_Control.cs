using System;
using System.Linq;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Models;

namespace SKYNET.GUI.W_Controls
{
    public partial class SubjectList_Control : UserControl
    {
       
        public SubjectList_Control()
        {
            InitializeComponent();

            SubjectDB.OnSubjectRemoved += SubjectDB_OnRemoved;
            SubjectDB.OnSubjectAdded += SubjectDB_OnAdded;
        }

        internal async void LoadData()
        {
            SubjectContainer.Controls.Clear();

            var Subjects = await SubjectDB.Get();
            for (int i = 0; i < Subjects.Count; i++)
            {
                var Subject = Subjects[i];
                var Subject_Item = new Subject_Item(Subject);
                Subject_Item.Dock = DockStyle.Top;
                SubjectContainer.Controls.Add(Subject_Item);
            }
        }

        private void SubjectDB_OnRemoved(object sender, Subject e)
        {
            for (int i = 0; i < SubjectContainer.Controls.Count; i++)
            {
                var control = SubjectContainer.Controls[i];
                if (control is Subject_Item subject)
                {
                    if (subject.Subject.ID == e.ID)
                    {
                        SubjectContainer.Controls.Remove(control);
                    }
                }
            }
        }

        private void SubjectDB_OnAdded(object sender, Subject e)
        {
            var Subject_Item = new Subject_Item(e);
            Subject_Item.Dock = DockStyle.Top;
            SubjectContainer.Controls.Add(Subject_Item);
        }

        private void BT_AddSignature_Click(object sender, EventArgs e)
        {
            frmMain.frm.Register(RegisterType.Subject);
        }
    }
}
