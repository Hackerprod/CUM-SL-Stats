using SKYNET.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public partial class frmPopup : Form
    {
        Button OK;
        Button Cancel;

        public frmPopup(PopupType type)
        {
            InitializeComponent();

            OK = new Button()
            {
                DialogResult = DialogResult.OK
            };
            Cancel = new Button()
            {
                DialogResult = DialogResult.Cancel
            };

            switch (type)
            {
                case PopupType.Add_StudyPlan:
                    {
                        var StudyPlan = new StudyPlan_Control() { Dock = DockStyle.Fill };
                        StudyPlan.OnActionResult += OnActionResult;
                        this.Width = StudyPlan.Width + 15;
                        this.Height = StudyPlan.Height + 40;
                        PN_Container.Controls.Add(StudyPlan);
                    }
                    break;
                case PopupType.Add_Career:
                    {
                        var StudyPlan = new Career_Control() { Dock = DockStyle.Fill };
                        StudyPlan.OnActionResult += OnActionResult;
                        this.Width = StudyPlan.Width + 15;
                        this.Height = StudyPlan.Height + 40;
                        PN_Container.Controls.Add(StudyPlan);
                    }
                    break;
                default:
                    break;
            }
        }

        private void OnActionResult(object sender, bool success)
        {
            if (success)
            {
                OK.PerformClick();
            }
            else
            {
                Cancel.PerformClick();
            }
            
            Close();
        }

        private void FrmPopup_Load(object sender, EventArgs e)
        {

        }

        public enum PopupType
        {
            Add_StudyPlan,
            Add_Career,
        }
    }
}
