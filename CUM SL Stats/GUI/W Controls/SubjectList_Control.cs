using System;
using System.Linq;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Models;

namespace SKYNET.GUI.W_Controls
{
    public partial class SubjectList_Control : UserControl
    {
        ColumnHeader columnName;
        public SubjectList_Control()
        {
            InitializeComponent();

            this.columnName = new ColumnHeader();
            this.columnName.Text = "Nombre";
            this.columnName.Width = 255;
        }

        internal async void LoadData()
        {
            SubjectContainer.Controls.Clear();

            var Subjects = await SubjectDB.Get();
            for (int i = 0; i < Subjects.Count; i++)
            {
                var Subject = Subjects[i];
                var lvItem = new ListViewItem();
                lvItem.SubItems.Add(Subject.Name);
                lvItem.Tag = Subject;
                var Subject_Item = new Subject_Item(Subject);
                Subject_Item.Dock = DockStyle.Top;
                SubjectContainer.Controls.Add(Subject_Item);
            }
        }
    }
}
