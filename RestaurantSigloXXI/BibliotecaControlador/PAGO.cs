//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BibliotecaDALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAGO
    {
        public PAGO()
        {
            this.BOLETA = new HashSet<BOLETA>();
        }
    
        public int N_TRANSACCION { get; set; }
        public int VALOR_PAGO { get; set; }
        public string ESTADO_PAGO { get; set; }
        public Nullable<int> DESCUENTO { get; set; }
        public int ID_METODO_PAGO { get; set; }
        public string RUT_CLIENTE { get; set; }
        public int ID_ORDEN { get; set; }
    
        public virtual ICollection<BOLETA> BOLETA { get; set; }
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual METODO_PAGO METODO_PAGO { get; set; }
        public virtual ORDEN ORDEN { get; set; }
    }
}
