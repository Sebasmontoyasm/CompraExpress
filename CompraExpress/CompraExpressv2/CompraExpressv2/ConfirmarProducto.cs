using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CompraExpressv2
{
    class ConfirmarProducto : ContentPage
    {
        public ConfirmarProducto()
        {
            var lbl1 = new Label
            {
                Text = "Nombre: "
            };

            var txtNombre = new Entry
            {
                Placeholder = "Ingrese nombre"
            };

            Content = new StackLayout
            {
                Padding = 30,
                Spacing = 10,
                Children = { lbl1, txtNombre }
            };
        }
    }
}
