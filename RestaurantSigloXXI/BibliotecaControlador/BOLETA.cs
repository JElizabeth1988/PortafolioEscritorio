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
    
    public partial class BOLETA
    {
        public decimal ID_BOLETA { get; set; }
        public System.DateTime FECHA_EMISION { get; set; }
        public System.DateTime HORA_EMISION { get; set; }
        public Nullable<decimal> PROPINA { get; set; }
        public decimal IVA { get; set; }
        public decimal TOTAL_BOLETA { get; set; }
        public decimal SUB_TOTAL { get; set; }
        public Nullable<decimal> DESCUENTO { get; set; }
        public decimal PAGO { get; set; }
        public Nullable<decimal> VUELTO { get; set; }
        public Nullable<decimal> N_TRANSACCION { get; set; }
    
        public virtual PAGO PAGO1 { get; set; }
    }
}
