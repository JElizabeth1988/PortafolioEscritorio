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
    
    public partial class LOGIN
    {
        public string USUARIO { get; set; }
        public string CONTRASENIA { get; set; }
        public int ID_TIPO_USER { get; set; }
        public string RUT_CLIENTE { get; set; }
        public string RUT_EMPLEADO { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual EMPLEADO EMPLEADO { get; set; }
        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }
    }
}
