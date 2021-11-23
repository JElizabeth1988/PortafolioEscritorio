using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaNegocio
{
    public class Egreso
    {
        public int id_egreso { get; set; }
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public string estado { get; set; }
        public int monto { get; set; }
        public string id_pedido { get; set; }

        public Egreso()
        {

        }
    }
}
