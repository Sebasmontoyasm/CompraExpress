using System;
using System.Collections.Generic;
using System.Linq;
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
        public async void OnButtonClicked(object sender, EventArgs e)
        {

            if (await validarFormulario())
            {
                // Cliente usuario = new Cliente()
                //{
                //   Documento = int.Parse(entryDocumento.Text),
                //   Nombre = entryNombre.Text,
                //   Apellido = entryApellido.Text,
                //  Correo = entryCorreo.Text,
                // contrasena = entryContrasena.Text,
                /// confirmado = 2
                //};
                //db.insert(usuario)   inserta en la base de datos
                await DisplayAlert("alerta", entryNombre.Text + "  registrado!", "ok");
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
            object[] campos = { entryNombre.Text, entryDocumento.Text, entryApellido.Text, entryCorreo.Text, entryContrasena.Text };
            foreach (String valor in campos)
            {
                if (String.IsNullOrWhiteSpace(valor))
                {
                    await this.DisplayAlert("Advertencia", "Todos los campos son obligatorios", "ok");
                    return false;
                }
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

                //validar Conexion a internet
                //statusInternet.Text = CrossConnectivity.Current.IsConnected ? "Connected" : "Disconnected";
                //if ("Disconnected".Equals(CrossConnectivity.Current.IsConnected ? "Connected" : "Disconnected"))
                //{
                //  await this.DisplayAlert("Advertencia", "Sin conexion a internet", "OK");
                return false;
                //}
            }
            return true;
        }
    }
}