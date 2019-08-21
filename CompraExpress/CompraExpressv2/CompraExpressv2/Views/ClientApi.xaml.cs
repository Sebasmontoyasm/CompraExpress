using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CompraExpressv2.Modelos;

namespace CompraExpressv2.Views
{
    

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientApi : ContentPage
    {
        private const string url = "http://192.168.1.22:63751/api/UsuariosAPI";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Usuario> _post;
        public ClientApi()
        {
            InitializeComponent();
        }





        //get de usuarios
        
        protected override async void OnAppearing()
        {   
            var content = await _Client.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Usuario>>(content);
            _post = new ObservableCollection<Usuario>(post);
            Post_List.ItemsSource = _post;
            
            base.OnAppearing();
        }
    }
}