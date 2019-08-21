using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CompraExpressv2.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CompraExpressv2
{
    public partial class App : Application
    {   
        public static bool IsLoggedIn { get; set; }

        public App()
        {   //IsloggedIn variable de tipo boolean que controla que se haya inciado sesion para poder listar productos
            IsLoggedIn = false;
            if (IsLoggedIn) {
                MainPage = new NavigationPage(new ListaProductos());
            } else {
                MainPage = new NavigationPage(new Login());
            }
            InitializeComponent();

            //MainPage = new NavigationPage(new ConfirmarCompraPage());
            //MainPage = new NavegationPage(new ComprarProducto());
            //MainPage = new NavigationPage(new ListaProductos());
           // MainPage = new NavigationPage(new ComprarProducto());
            //MainPage = new NavigationPage(new Login());
            MainPage = new NavigationPage (new ListaProductos());
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
