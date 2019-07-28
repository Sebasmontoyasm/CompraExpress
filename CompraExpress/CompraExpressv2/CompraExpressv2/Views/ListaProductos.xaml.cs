using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompraExpressv2.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompraExpressv2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaProductos : ContentPage
	{
		public ListaProductos ()
		{
			InitializeComponent ();
		}

        private async void button_click(object sender, EventArgs e)
        {
            //await App.Current.MainPage.DisplayAlert("Cantidad", "La Cantidad a comprar es: "+stepper.Value.ToString(), "Aceptar", "Cancelar");
            await Navigation.PushAsync(new ComprarProducto());
        }

    }
}