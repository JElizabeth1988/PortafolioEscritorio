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
    
    public partial class MESA
    {
        public MESA()
        {
            this.AGENDA = new HashSet<AGENDA>();
        }
    
        public int NUM_MESA { get; set; }
        public int CAPACIDAD_PERSONA { get; set; }
        public string DISPONIBILIDAD { get; set; }
        public string ASIGNACION { get; set; }
        public string RUT_EMPLEADO { get; set; }
    
        public virtual ICollection<AGENDA> AGENDA { get; set; }
        public virtual EMPLEADO EMPLEADO { get; set; }
    }
}
