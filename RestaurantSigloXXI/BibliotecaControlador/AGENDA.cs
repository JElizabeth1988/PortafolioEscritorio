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
    
    public partial class AGENDA
    {
        public AGENDA()
        {
            this.RESERVA = new HashSet<RESERVA>();
        }
    
        public int ID_AGENDA { get; set; }
        public System.DateTime FECHA { get; set; }
        public string HORA_DESDE { get; set; }
        public string HORA_HASTA { get; set; }
        public string DISPONIBILIDAD { get; set; }
        public int NUM_MESA { get; set; }
    
        public virtual MESA MESA { get; set; }
        public virtual ICollection<RESERVA> RESERVA { get; set; }
    }
}
