using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {
        public UpdatePage()
        {
            InitializeComponent();
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var empleado = await App.DataBaseSQLite.ObtenerPersona(Convert.ToInt32(txtcodigo.Text));

            if (empleado != null)
            {
                await App.DataBaseSQLite.EliminarPersonas(empleado);
                await DisplayAlert("Eliminado", "Persona Eliminada", "Ok");
                ClearScreen();
            }
        }

    
        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            var empleados = new Models.Empleados
            {
                codigo = Convert.ToInt32(txtcodigo.Text),
                nombre = this.txtnombre1.Text,
                apellido = this.txtapellido1.Text,
                edad = Convert.ToInt32(this.txtedad1.Text),
                direccion = txtdireccion1.Text,
                puesto = txtpuesto1.Text

            };

            if (await App.DataBaseSQLite.GrabarPersonas(empleados) != 0)
                await DisplayAlert("Actualizado", "Dato actualizado", "ok");
            else
                await DisplayAlert("Error", "No se logró actualizar", "ok");
        }

        private void ClearScreen()
        {
            this.txtnombre1.Text = String.Empty;
            this.txtapellido1.Text = String.Empty;
            this.txtedad1.Text = String.Empty;
            this.txtdireccion1.Text = String.Empty;
            this.txtpuesto1.Text = String.Empty;
        }
    }
}