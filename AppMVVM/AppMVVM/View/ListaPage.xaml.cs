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
    public partial class ListaPage : ContentPage
    {
        public ListaPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var listaempleados = await App.DataBaseSQLite.ObtenerListaPersonas();
            lstEmpleados.ItemsSource = listaempleados;
        }


        private async void lstEmpleados_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Empleados item = (Models.Empleados)e.Item;


            var page = new View.UpdatePage();
            page.BindingContext = item;
            await Navigation.PushAsync(page);
        }
    }
}