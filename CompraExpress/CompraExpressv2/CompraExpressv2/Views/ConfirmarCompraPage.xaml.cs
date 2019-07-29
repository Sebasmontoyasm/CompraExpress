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
    /**
    * Clase con el modelo y vista de la Confirmacion de la compra para guardar
    * la compra
    * @Autor Sebastian Montoya
    * @Version 3.7
    **/
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmarCompraPage : ContentPage
    {
        public Cliente cliente { get; set; }
        public Empresa empresa { get; set; }
        public Compra compra { get; set; }
        public Producto producto { get; set; }
        public const double IVA = 0.7;

        /**
         * Contructor encargado de recibir la informacion
         * del modelo logico ComprarProducto y añadir 
         * mas funcionalidad.
         **/
        public ConfirmarCompraPage()
        {
            this.cliente = new Cliente(1053854498, "Sebastian Montoya", "Cra 36a #10D-66", "Manizales", "Colombia", "sebasmontoyasm@gmail.com","Softwar3LoMejor");
            this.empresa = new Empresa("1701410810", "Ktronix", "6016 6071 9235 4142");
            this.producto = new Producto("13045876", "Portatil Gamer HP", "Procesador i5 " +
                                                                    "SO: Windows Home " +
                                                                    "Memoria ram: 8GB " +
                                                                    "Disco duro: 1 TB " +
                                                                    "Pantalla 15.6 pulgadas" +
                                                                    "Tarjeta Grafica: NVIDIA ", 224900,1,"pcgamer.png");
            LinkedList<Producto> productos = new LinkedList<Producto>();
            productos.Append(producto);

            int precioTotal = 0;
            foreach (Producto p in productos)
            {
                precioTotal = precioTotal + p.Precio;
            }


            this.compra = new Compra("85698524539", cliente.Documento, empresa.id, productos, precioTotal + precioTotal * IVA, DateTime.Now);

            BindingContext = this;

            InitializeComponent();
        }
    }
}