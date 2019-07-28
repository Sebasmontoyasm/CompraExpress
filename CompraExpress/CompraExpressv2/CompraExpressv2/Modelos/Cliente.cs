using System;
using System.Collections.Generic;
using System.Text;

/**
    Modelo logico de los clientes de la empresa
    @Autor= Sebastian Montoya
    @Version= 2.0
     */

namespace CompraExpressv2.Modelos
{
    public class Cliente
    {
        public int Documento { get; set; }
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Pais { get; set; }

        public string Correo { get; set; }
        public int rol { get; set; }
        public int confirmado { get; set; }


        public Cliente(int documento,string nombre,string direccion,string ciudad,string pais,string correo,int rol,int confirmado)
        {
            this.Documento = documento;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Ciudad = ciudad;
            this.Pais = pais;
            this.Correo = correo;
            this.rol = rol;
            this.confirmado = confirmado;
        }
    }
}
