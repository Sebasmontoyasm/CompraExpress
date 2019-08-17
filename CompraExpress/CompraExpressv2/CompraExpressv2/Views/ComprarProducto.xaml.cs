using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CompraExpressv2.Modelos;

namespace CompraExpressv2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComprarProducto : ContentPage
    {
        public Empresa empresa { get; set; }
        public Compra compra { get; set; }
        public Producto producto { get; set; }


        public ComprarProducto( String IdproductoDetalle)
        {
            this.producto = new Producto("13045876", "Portatil Gamer HP", "Procesador i5 " +
                                                                    "SO: Windows Home " +
                                                                    "Memoria ram: 8GB " +
                                                                    "Disco duro: 1 TB " +
                                                                    "Pantalla 15.6 pulgadas" +
                                                                    "Tarjeta Grafica: NVIDIA ", 224900, 3, "pcgamer.png","1234");

            LinkedList<Producto> productos = new LinkedList<Producto>();
            productos.Append(producto);

            int precioTotal = 0;
            foreach (Producto p in productos)
            {
                precioTotal = precioTotal + p.Precio;
            }

            this.producto = new Producto(producto.Id,producto.Nombre, producto.Descripcion, producto.Precio ,producto.Cantidad,producto.Figura,producto.IdProvedor);

            BindingContext = this;

            InitializeComponent();
            
        }

        private async void button_click(object sender, EventArgs e)
        {
            //await App.Current.MainPage.DisplayAlert("Cantidad", "La Cantidad a comprar es: "+stepper.Value.ToString(), "Aceptar", "Cancelar");
            await Navigation.PushAsync(new ConfirmarCompraPage());
        }

    }
}


