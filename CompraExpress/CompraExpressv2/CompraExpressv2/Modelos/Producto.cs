using System;
using System.Collections.Generic;
using System.Text;

namespace CompraExpressv2.Modelos
{
    public class Producto
    {
        public string id { get; set; }
        public string nombre { get;set; }
        public string descripcion { get;set; }
        public int Precio { get; set; }

        public Producto(string newid,string nombre,string newdescripcion,int precio)
        {
            this.id = newid;
            this.nombre = nombre;
            this.descripcion = newdescripcion;
            this.Precio = precio;
        }
    }
}
