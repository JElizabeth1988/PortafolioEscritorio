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
    
    public partial class TIPO_BEBIDA
    {
        public TIPO_BEBIDA()
        {
            this.BEBIDA = new HashSet<BEBIDA>();
        }
    
        public int ID_TIPO { get; set; }
        public string NOMBRE { get; set; }
    
        public virtual ICollection<BEBIDA> BEBIDA { get; set; }
    }
}
