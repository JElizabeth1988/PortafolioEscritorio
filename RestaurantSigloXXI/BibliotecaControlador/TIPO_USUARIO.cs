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
    
    public partial class TIPO_USUARIO
    {
        public TIPO_USUARIO()
        {
            this.EMPLEADO = new HashSet<EMPLEADO>();
            this.LOGIN = new HashSet<LOGIN>();
        }
    
        public int ID_TIPO_USER { get; set; }
        public string DESCRIPCION_USER { get; set; }
    
        public virtual ICollection<EMPLEADO> EMPLEADO { get; set; }
        public virtual ICollection<LOGIN> LOGIN { get; set; }
    }
}