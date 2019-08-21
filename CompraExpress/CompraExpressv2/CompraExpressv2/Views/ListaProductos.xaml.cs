using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CompraExpressv2.Modelos;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompraExpressv2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaProductos : ContentPage
	{
        private ObservableCollection<Producto> _post;
        private HttpClient _Client;
        private const string  url = "http://192.168.0.115:63751/api/ProductosAPI";
        public ListaProductos()
        {
             _Client = new HttpClient();
            InitializeComponent();
            btnBuscar.Clicked += buscarProductos;
            
        }
        protected override async void OnAppearing()
        {
            ListProducts.Children.Clear();
            var content = await _Client.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Producto>>(content);
            _post = new ObservableCollection<Producto>(post);

            
            
            foreach (Producto p in _post) {
                StackLayout newStack=new StackLayout();
                Label l = new Label();
                l.Text = p.Nombre;
                l.FontSize = 16;
                l.FontAttributes = FontAttributes.Bold;
                Button b = new Button();
                b.ImageSource = p.Figura;
                b.ClassId = p.Id;

                
                b.Clicked +=  button_click;
                
                newStack.Children.Add(l);
                newStack.Children.Add(b);
                ListProducts.Children.Add(newStack);

                
            }
            base.OnAppearing();

           
        }
        
        
            
    
        
        private async void button_click(object sender, EventArgs e)
        {

            Button button = sender as Button;
            if (button != null)
            {
                await Navigation.PushAsync(new ComprarProducto(button.ClassId));

            }
            
            
        }
        /**Metodo para listar productos desde la busqueda
         * @param= caracterer subcadena del nombre deun producto
         * return=Si parametro es "" la pantalla mostrara que debe ingresar caracter, si es diferente de ""
         * mostrara los productos que en su nombre contengan ese caracter
         * 
         * **/
        public async void buscarProductos(object sender, EventArgs e)
        {
            ListProducts.Children.Clear();
            
            var content = await _Client.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Producto>>(content);
            _post = new ObservableCollection<Producto>(post);
            foreach (Producto p in _post)
            { Boolean contiene = p.Nombre.Contains(entryBuscar.Text);
                if (entryBuscar.Text != "")
                {
                    if (contiene)
                    {
                        StackLayout newStack = new StackLayout();
                        Label l = new Label();
                        l.Text = p.Nombre;
                        l.FontSize = 16;
                        l.FontAttributes = FontAttributes.Bold;
                        Button b = new Button();
                        b.ImageSource = p.Figura;
                        b.ClassId = p.Id;


                        b.Clicked += button_click;

                        newStack.Children.Add(l);
                        newStack.Children.Add(b);
                        ListProducts.Children.Add(newStack);
                    }
                }
                else { await DisplayAlert("Alerta","Debe ingresar algun caracter","ok"); }
            }
        }
    }
}