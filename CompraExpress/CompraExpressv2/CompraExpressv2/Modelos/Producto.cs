using System;
using System.Collections.Generic;
using System.Text;

namespace CompraExpressv2.Modelos
{
    /**
     * Clase encargada del modelo logico de los Productos
     * que se van a ofertar y comprar por parte del cliente
     * para su correcto funcionamiento
     * @Autor Sebastian Montoya
     * @Version 1.2
     **/
    public class Producto
    {
        public string Idp { get; set; }
        public string Nombre { get;set; }
        public string Descripcion { get;set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public string Figura { get; set; }
        /**
         * Constructor con los parametros necesarios para crear un nuevo producto
         * @param newid @type string id del producto 
         * @param nombre @type string nombre nombre del producto  
         * @param newdescripcion @type string descripcion del producto
         * @param precio @type int precio del producto
         * @param cantidad @type int cantidad del producto en la informacion
         * @param figura @type string ruta con la imagen del producto
         **/
        public Producto(string newid,string nombre,string newdescripcion,int precio,int cantidad,string figura)
        {
            this.Idp = newid;
            this.Nombre = nombre;
            this.Descripcion = newdescripcion;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.Figura = figura;
        }
        /** 
          * Constructor especifico para confirmarCompra y mandar a la base de datos.
          * @param newid @type string id del producto 
         *  @param nombre @type string nombre nombre del producto  
         *  @param newdescripcion @type string descripcion del producto
         *  @param precio @type int precio del producto
          **/
        public Producto(string newid, string nombre, string newdescripcion, int precio)
        {
            this.Idp = newid;
            this.Nombre = nombre;
            this.Descripcion = newdescripcion;
            this.Precio = precio;
        }
    }
}
