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
    
    public partial class CLIENTE
    {
        public CLIENTE()
        {
            this.LOGIN = new HashSet<LOGIN>();
            this.ORDEN = new HashSet<ORDEN>();
            this.PAGO = new HashSet<PAGO>();
            this.PEDIDO = new HashSet<PEDIDO>();
            this.RESERVA = new HashSet<RESERVA>();
        }
    
        public string RUT_CLIENTE { get; set; }
        public string PRIMER_NOM_CLI { get; set; }
        public string SEGUNDO_NOM_CLI { get; set; }
        public string AP_PATERNO_CLI { get; set; }
        public string AP_MATERNO_CLI { get; set; }
        public int CELULAR_CLI { get; set; }
        public Nullable<int> TELEFONO_CLI { get; set; }
        public string CORREO_CLI { get; set; }
    
        public virtual ICollection<LOGIN> LOGIN { get; set; }
        public virtual ICollection<ORDEN> ORDEN { get; set; }
        public virtual ICollection<PAGO> PAGO { get; set; }
        public virtual ICollection<PEDIDO> PEDIDO { get; set; }
        public virtual ICollection<RESERVA> RESERVA { get; set; }
    }
}
