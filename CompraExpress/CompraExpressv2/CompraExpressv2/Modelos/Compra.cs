using System;
using System.Collections.Generic;

namespace CompraExpressv2.Modelos
{
    /**
    * Modelo de la compra logico con toda
    * la informacion necesaria para efectuar
    * la compra
    * @Autor Sebastian Montoya
    * @Version 1.2
    **/
    public class Compra
    {
        public string id { get; set; }
        public int idCliente { get; set; }
        public string idEmpresa { get; set; }
        public LinkedList<Producto> Productos { get; set; }
        public double precioCompra { get; set; }
        public DateTime fechaCompra { get; set; }

        /**
         * Constructor de crear un objeto
         * para realizar la compra del producto.
         * @newid type  string identificador unico de la compra realizada
         * @param idcliente @type int Documento unico del cliente que lo carateriza
         * @param idempresa @type string Identificador del provedor del producto que
         * usa nuestro sistema
         * @param productos @type LinkedList<Producto> Lista de los productos comprados por el Usuario final
         * @param preciocompra @type double Precio del total de todos los productos comprados.
         * @param fechaCompra @type DateTime hora y fecha en la que se realizo la compra.
        **/
        public Compra(string newid, int idcliente,string idempresa,LinkedList<Producto> productos, double preciocompra,DateTime fechacompra)
        {
            this.id = newid;
            this.idCliente = idcliente;
            this.idEmpresa = idempresa;
            this.Productos = productos;
            this.precioCompra = preciocompra;
            this.fechaCompra = fechacompra;
        }
    }
}
