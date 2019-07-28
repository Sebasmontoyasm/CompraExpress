using System;
using System.Collections.Generic;
using System.Text;

namespace CompraExpressv2.Modelos
{
    /**
    * Clase con la informacion de la Empresa 
    * para realizar el pago
    * @Autor Sebastian Montoya
    * @Version 1.2
    **/
    public class Empresa
    {
        public string id { get; set; }
        public string Nombre { get; set; }

        public string nCuenta { get; set; }
        /**
         * Constructor de la empresa con los 
         * parametros necesarios
         * @param newid @type string Identificador unico de la empresa.
         * @param nombre @type string Nombre de la empresa
         * @param ncuenta @type string Numero de la tarjeta de credito
         * para consiginar las ventas.
         **/
        public Empresa(string newid,string nombre,string ncuenta)
        {
            this.id = newid;
            this.Nombre = nombre;
            this.nCuenta = ncuenta;
        }
    }
}
