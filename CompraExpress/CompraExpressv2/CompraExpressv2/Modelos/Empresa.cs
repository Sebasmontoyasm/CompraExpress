using System;
using System.Collections.Generic;
using System.Text;

namespace CompraExpressv2.Modelos
{
    public class Empresa
    {
        public string id { get; set; }
        public string Nombre { get; set; }

        public string nCuenta { get; set; }

        public Empresa(string newid,string nombre,string ncuenta)
        {
            this.id = newid;
            this.Nombre = nombre;
            this.nCuenta = ncuenta;
        }
    }
}
