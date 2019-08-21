using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CompraExpressv2.Modelos;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
/**
* Clase encargada de hacer las validaciones 
* para que el usuario pueda iniciar sesion en el sistema
* Autor Lina Marcela Arias 
* @Version 4.1 
**/

namespace CompraExpressv2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        
        

        public Login()
        {
            
            
            InitializeComponent();
        }

        /**El método  que valida que los campos no estén vacíos  y que cumplan con el formato definido 
        *el correo que contenga xxx@xx.xxx
        *la clave con valores mayores a 6
        *return =boolean retorna un valor booleando si es true los campos están correctos, si es false los datos no están correctos
        **/

        private async Task<bool> validarFormulario()
        {
            //Valida que el formato del correo sea valido
            bool isEmail = Regex.IsMatch(correoF.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                await this.DisplayAlert("Advertencia", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");
                return false;
            }
            if (String.IsNullOrWhiteSpace(claveF.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo de contraseña es obligatorio.", "OK");
                return false;
            }

            //validar tamano de la contrasena
            if (claveF.Text.Length < 6)
            {
                await this.DisplayAlert("Advertencia", "Contrasena debe ser mayor a 6 caracteres", "ok");
                return false;
            }

            return true;
        }

        //valida que el correo y la clave existan y estén almacenados 
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (await validarFormulario() && await buscarCliente())
            {
                //await DisplayAlert("Exito", "Puede iniciar", "OK");

            }
            else {
                await DisplayAlert("Exito", "Debe registrarse primero", "OK");
            }
        }

        /**verificar que el usuario no este registrado antes de registrarse mediante Get del servicio Web
         *return= True si encuentra un usuario en la base de datos con el mismo correo electronico, 
          False si no lo encuentra.
         * **/
        private async Task<bool> buscarCliente()
        {
            ObservableCollection<Usuario> _post;
            HttpClient _Client = new HttpClient();
            string url = "http://192.168.0.115:63751/api/UsuariosAPI";
            var contenido = await _Client.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Usuario>>(contenido);
            _post = new ObservableCollection<Usuario>(post);
            foreach (Usuario c in _post)
            {
                if (c.Correo.Equals(correoF.Text) )
                {
                    if (c.Password.Equals(claveF.Text))
                    {

                        return true;
                    }
                    else {
                        await DisplayAlert("Alerta","Clave incorrecta","ok");
                        return false;
                    }
                }
            }

            return false;


        }
    }
}