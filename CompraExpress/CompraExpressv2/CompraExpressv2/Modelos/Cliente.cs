using System;
using System.Collections.Generic;
using System.Text;

namespace CompraExpressv2.Modelos
{
    public class Usuario
    {
        public int Documento { get; set; }
        public string Tarjeta { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Password { get; set; }

        public int Rol { get; set; }
        
        public int confirmado { get; set; }
        
        public Usuario(int Documento,string Tarjeta,string Nombre,string Apellido,string Correo,string Password,int Rol,int confirmado)
        {
            this.Documento = Documento;
            this.Tarjeta = Tarjeta;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Correo = Correo;
            this.Password = Password;
            this.Rol = Rol;
            this.confirmado = confirmado;
        }
    }
}
