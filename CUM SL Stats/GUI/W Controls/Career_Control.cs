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

        public event EventHandler<bool> OnActionResult;

        private async void BT_Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TB_Career.Text))
            {
                MessageBox.Show("Debe especificar el nombre de la carrera para continuar");
                return;
            }

            var Career = await CareerDB.Get(TB_Career.Text);
            if (Career != null)
            {
                MessageBox.Show($"La carrera \"{TB_Career.Text}\" ya existe");
                return;
            }

            Career = new Career()
            {
                Name = TB_Career.Text,
            };

            var result = await CareerDB.Register(Career);

            Common.Notify(result ? $"La Carrera {Career.Name} se ha registrado correctamente" : $"Error agregando la asignatura {Career.Name}");
            OnActionResult?.Invoke(this, result);
        }
    }
}
