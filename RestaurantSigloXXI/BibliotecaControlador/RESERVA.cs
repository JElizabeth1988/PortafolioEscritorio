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
    
    public partial class RESERVA
    {
        public decimal ID_RESERVA { get; set; }
        public System.DateTime FECHA_RESERVA { get; set; }
        public System.DateTime HORA_RESERVA { get; set; }
        public decimal CANTIDAD_PERSONAS { get; set; }
        public string OBSERVACIONES { get; set; }
        public string ESTADO_RESERVA { get; set; }
        public string RUT_CLIENTE { get; set; }
        public decimal NUM_MESA { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual MESA MESA { get; set; }
    }
}
