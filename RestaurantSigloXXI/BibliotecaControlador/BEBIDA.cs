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
    
    public partial class BEBIDA
    {
        public BEBIDA()
        {
            this.EXTRA = new HashSet<EXTRA>();
            this.MENU = new HashSet<MENU>();
        }
    
        public int ID_BEBIDA { get; set; }
        public string NOM_BEBIDA { get; set; }
        public int ML_BEBIDA { get; set; }
        public int VALOR_BEBIDA { get; set; }
        public int STOCK { get; set; }
        public int ID_TIPO_PRODUCTO { get; set; }
    
        public virtual TIPO_PRODUCTO TIPO_PRODUCTO { get; set; }
        public virtual ICollection<EXTRA> EXTRA { get; set; }
        public virtual ICollection<MENU> MENU { get; set; }
    }
}
