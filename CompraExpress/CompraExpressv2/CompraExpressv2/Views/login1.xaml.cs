using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CompraExpressv2.Modelos;
/**autor: Lina 
 * V.4.1
clase encargada de hacer las validaciones para que el usuario pueda iniciar sesion en el sistema 
**/

namespace CompraExpressv2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login1 : ContentPage
    {
        public Cliente cliente { get; set; }
        public LinkedList<Cliente> clientesL = new LinkedList<Cliente>();

        public login1()
        {
            this.cliente = new Cliente(10, "Oscar", "Cervantes ", "Manizales", "Colombia", "compraexpress@gmail.com", "caballo");
            this.cliente = new Cliente(11, "Oscar1", "Cervantes ", "Manizales", "Colombia", "c@gmail.com", "1234567");
            clientesL.Append(cliente);
            InitializeComponent();
        }
        /**El método  que valida que los campos no estén vacíos  y que cumplan con el formato definido 
        *el correo que contenga xxx@xx.xxx
        *la clave con valores mayores a 6
        *return =boolean retorna un valor booleando si es true los campos están correctos, si es false los datos no están correctos
        **/
 
        private async Task<bool> validarFormulario()       {


            //Valida que el formato del correo sea valido
            bool isEmail = Regex.IsMatch(correoF.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                await this.DisplayAlert("Advertencia", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");
                return false;
            }
            if (String.IsNullOrWhiteSpace(claveF.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del nombre es obligatorio.", "OK");
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
            if (await validarFormulario())
            {
                await DisplayAlert("Exito", "Todos tus campos cumplieron las validaciones.", "OK");



                if (this.cliente.Correo.Equals(correoF.Text))
                {
                    if (this.cliente.Clave.Equals(claveF.Text))
                    {
                        await DisplayAlert("Exito", "Clave correcta ", "OK");
                        await DisplayAlert("Exito", "Aqui poner el pasar a la siguiente pagina con un navigationPague, contraseña y email correocto", "OK");
                    }
                    else { 
                    await DisplayAlert("Exito", "Clave Incorrecta ", "OK");
                    }
                }
                else { 
                await DisplayAlert("Exito", "Correo Incorrecto o inexistente ", "OK");
                }

            }
        }



    }
}