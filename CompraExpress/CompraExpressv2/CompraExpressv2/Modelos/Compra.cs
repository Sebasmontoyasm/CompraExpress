using System;
using System.Collections.Generic;

namespace CompraExpressv2.Modelos
{
    public class Compra
    {
        public string id { get; set; }
        public int idCliente { get; set; }
        public string idEmpresa { get; set; }
        public LinkedList<Producto> Productos { get; set; }
        public double precioCompra { get; set; }
        public DateTime fechaCompra { get; set; }

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
