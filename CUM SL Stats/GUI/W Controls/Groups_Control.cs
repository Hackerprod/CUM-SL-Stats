using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYNET.DB;
using SKYNET.Models;

namespace SKYNET.Controls
{
    public partial class Groups_Control : UserControl
    {
        private Group Group;

        public Groups_Control()
        {
            InitializeComponent();


        }

        public void LoadData()
        {
            Task.Run(delegate 
            {
                foreach (var group in GroupDB.Groups)
                {
                    try
                    {
                        var Cource = SchoolCourceDB.GetCource(group.CourceID);
                        var Career = CareerDB.GetCareer(group.CareerID);

                        var lvItem = new ListViewItem();
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());

                        lvItem.SubItems[0].Tag = group;
                        lvItem.SubItems[1].Text = Cource == null ? "Invalid" : Cource.Name;
                        lvItem.SubItems[2].Text = Career == null ? "Invalid" : Career.Name;
                        lvItem.SubItems[3].Text = group.Name;
                        lvItem.SubItems[4].Text = StudentDB.GetCourceYear(Cource, frmMain.Settings.CurrentCource); 
                        LV_Groups.Items.Add(lvItem);
                    }
                    catch
                    {
                    }
                }
            });
        }
    }
}
