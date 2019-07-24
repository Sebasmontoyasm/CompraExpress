using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectCompraExpress
{
    class ConfirmarCompraPage : ContentPage 
    {
        public ConfirmarCompraPage()
        {
            var lbl1 = new Label
            {
                Text = "Escribre tu nombre"

            };

            var txtNombre = new Entry
            {
                Placeholder = "Escribe tu nombre"
            };
            Content = new StackLayout
            {
                Padding = 30,
                Spacing = 10,
                Children = { lbl1, txtNombre }
            };
    }
}
