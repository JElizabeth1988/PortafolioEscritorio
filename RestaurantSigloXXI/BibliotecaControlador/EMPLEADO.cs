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
    
    public partial class EMPLEADO
    {
        public EMPLEADO()
        {
            this.LOGIN = new HashSet<LOGIN>();
            this.MESA = new HashSet<MESA>();
            this.ORDEN = new HashSet<ORDEN>();
            this.PEDIDO_PROVEEDOR = new HashSet<PEDIDO_PROVEEDOR>();
            this.RECETA = new HashSet<RECETA>();
        }
    
        public string RUT_EMPLEADO { get; set; }
        public string PRIMER_NOM_EMP { get; set; }
        public string SEGUNDO_NOM_EMP { get; set; }
        public string APELLIDO_PAT_EMP { get; set; }
        public string APELLIDO_MAT_EMP { get; set; }
        public string CORREO_EMP { get; set; }
        public int CELULAR_EMP { get; set; }
        public Nullable<int> TELEFONO_EMP { get; set; }
        public int ID_TIPO_USER { get; set; }
        public string USUARIO { get; set; }
        public string CONTRASENIA { get; set; }
    
        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }
        public virtual ICollection<LOGIN> LOGIN { get; set; }
        public virtual ICollection<MESA> MESA { get; set; }
        public virtual ICollection<ORDEN> ORDEN { get; set; }
        public virtual ICollection<PEDIDO_PROVEEDOR> PEDIDO_PROVEEDOR { get; set; }
        public virtual ICollection<RECETA> RECETA { get; set; }
    }
}
