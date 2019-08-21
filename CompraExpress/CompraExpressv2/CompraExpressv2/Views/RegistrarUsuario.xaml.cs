using CompraExpressv2.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/**
 Clase que hace las validaciones de datos de entrada para poder registrar un cliente
    @Autor= Cristian David Beltran
    @Version= 3.0
 */

namespace CompraExpressv2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarUsuario : ContentPage
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
            CrearUsuario.Clicked += OnButtonClicked;
         }


        /**
         * Metodo que tiene la funcion de Registrar usuario en la base de datos habiendo validado
         * que los campos esten diligenciados correctamente y y el correo del usuario no existe 
         * en la base de datos
         * @param: eventos del click
         * return= Usuario registrado en la base de datos
         * **/
        public async void OnButtonClicked(object sender, EventArgs e)
        {
            
            if (await validarFormulario() && !await buscarCliente())
            {
                Usuario cliente = new Usuario( int.Parse(entryDocumento.Text),entryTarjeta.Text, entryNombre.Text,entryApellido.Text, entryCorreo.Text, entryContrasena.Text,2,2);
                 //llama al metodo POSTREQUESt para insertar el usuario en la base dedatos
                InsertarUsuario(cliente);
                await DisplayAlert("Alerta","El usuario ha sido registrado satisfactoriamente","ok");
             }
        }


        /**
         Metodo para validar los datos de entrada, que no esten vacios, con formatos incorrectos, con longitud de caracteres 
            correcta
            return=boolean True si los campos estan correctos si es False los datos no estan correctos
         * */
      private async Task<bool> validarFormulario()
        {
            //validar que todos los campos no esten vacios
            object[] campos = { entryNombre.Text, entryDocumento.Text, entryApellido.Text, entryCorreo.Text, entryContrasena.Text,entryTarjeta.Text };
            foreach (String valor in campos)
            {
                if (String.IsNullOrWhiteSpace(valor))
                {
                    await this.DisplayAlert("Advertencia", "Todos los campos son obligatorios", "ok");
                    return false;
                }
            }
            if (entryDocumento.Text.Length > 10) {
                await this.DisplayAlert("Advertencia", "El documento debe ser menor a 11 caracteres", "ok");
                return false; }
                //validar el formato del correo
                bool isEmail = Regex.IsMatch(entryCorreo.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    if (String.IsNullOrWhiteSpace(entryCorreo.Text))
                    {
                        await this.DisplayAlert("Advertencia", "Todos los campos son obligatorios", "ok");
                        return false;
                    }
                    await this.DisplayAlert("Advertencia", "Formato invalido de correo electronico", "OK");
                    return false;
                }
                //validar tamano de la contrasena
                if (entryContrasena.Text.Length < 6)
                {
                    await this.DisplayAlert("Advertencia", "Contrasena debe ser mayor a 6 caracteres", "ok");
                    return false;
                }

                //valida que documento sea numero
                if (!entryDocumento.Text.ToCharArray().All(Char.IsDigit))
                {
                    await this.DisplayAlert("Advertencia", "Formato de documento incorrecto", "OK");
                    return false;
                }

            /**
            statusInternet.Text = CrossConnectivity.Current.IsConnected ? "Connected" : "Disconnected";
            if ("Disconnected".Equals(CrossConnectivity.Current.IsConnected ? "Connected" : "Disconnected"))
            {
              await this.DisplayAlert("Advertencia", "Sin conexion a internet", "OK");
            return false;
            }**/
            if (entryTarjeta.Text.Length < 16 || entryTarjeta.Text.Length > 16) {
                await this.DisplayAlert("Advertencia", "El numero de la Tarjeta debe ser de 16 caracteres", "ok");
                return false;
            }
            return true;
        }



        /**
         Metodo para  insertar un cliente a la base de datos mediante POSTrequest
            @param=cliente de tipo Cliente
         * **/
        protected  async void InsertarUsuario(Usuario cliente)
        {
            HttpClient clienteHttp = new HttpClient();
            var urlServicio = new Uri("http://192.168.0.115:63751/api/UsuariosAPI");
            string json = JsonConvert.SerializeObject(cliente);
            try
            {
                var contenido = new StringContent(json, Encoding.UTF8, "application/json");
                 HttpResponseMessage response = clienteHttp.PostAsync(urlServicio, contenido).Result;
            }
            catch (HttpRequestException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
           
        }

        /**verificar que el usuario no este registrado antes de registrarse mediante Get del servicio Web
         *return= True si encuentra un usuario en la base de datos con el mismo correo electronico, 
          False si no lo encuentra. 
         **/
        private async Task<bool> buscarCliente()
        {
            ObservableCollection<Usuario> _post;
            HttpClient _Client=new HttpClient();
             string url = "http://192.168.0.115:63751/api/UsuariosAPI";
            var contenido = await _Client.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Usuario>>(contenido);
            _post = new ObservableCollection<Usuario>(post);
            foreach (Usuario c in _post) {
                if (c.Correo.Equals(entryCorreo.Text)||c.Documento.Equals(entryDocumento.Text))
                {
                    await DisplayAlert("Alerta","El usuario ya se encuentra registrado","ok");
                    return true;
                }
            }

            return false;

            
        }
    }
}