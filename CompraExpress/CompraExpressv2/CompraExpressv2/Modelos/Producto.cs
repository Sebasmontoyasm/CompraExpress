using System;
using System.Collections.Generic;
using System.Text;

namespace CompraExpressv2.Modelos
{
    public class Producto
    {
        public string Idp { get; set; }
        public string Nombre { get;set; }
        public string Descripcion { get;set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public string Figura { get; set; }

        public Producto(string newid,string nombre,string newdescripcion,int precio,int cantidad,string figura)
        {
            this.Idp = newid;
            this.Nombre = nombre;
            this.Descripcion = newdescripcion;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.Figura = figura;
        }
    }
}
