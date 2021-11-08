using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Using con DALC
using BibliotecaDALC;
//Using BD
using Oracle.ManagedDataAccess.Client;

namespace BibliotecaNegocio
{
    public class DetallePedido
    {
        public int id_producto { get; set; }
        public int id_pedido { get; set; }
        public int cantidad { get; set; }

        public DetallePedido()
        {

        }
    }
}
