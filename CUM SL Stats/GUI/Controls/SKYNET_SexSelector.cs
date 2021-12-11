using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYNET.Models;
using SKYNET.Properties;

namespace SKYNET.GUI.Controls
{
    public partial class SKYNET_SexSelector : UserControl
    {
        [Category("SKYNET")]
        public event EventHandler<Sex> SexChanged;

        [Category("SKYNET")]
        public Sex Sex 
        { 
            get 
            { 
                return _sex; 
            } 
            set 
            {
                if (BlockSelector) return;

                if (_sex != value)
                {
                    _sex = value;

                    switch (value)
                    {
                        case Sex.F:
                            PB_Female.Image = Resources.female_user_Sekected;
                            PB_Male.Image = Resources.user_male;
                            break;
                        case Sex.M:
                            PB_Female.Image = Resources.female_user;
                            PB_Male.Image = Resources.user_male_Selected;
                            break;
                    }

                    SexChanged?.Invoke(this, value);
                }
            }
        }
        private Sex _sex;

        [Category("SKYNET")]
        public bool BlockSelector { get; set; }


        public SKYNET_SexSelector()
        {
            InitializeComponent();
        }

        private void PB_Female_Click(object sender, EventArgs e)
        {
            Sex = Sex.F;
        }

        private void PB_Male_Click(object sender, EventArgs e)
        {
            Sex = Sex.M;
        }
    }
}
