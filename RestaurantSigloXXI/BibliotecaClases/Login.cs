using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Using con DALC
using BibliotecaDALC;
//Using BD
using Oracle.ManagedDataAccess.Client;

namespace BibliotecaNegocio
{
    public class Login
    {
        public string usuario { get; set; }
        /*public string usuario
        {
            get { return _usuario; }
            set
            {
                if (value != string.Empty )
                {
                    _usuario = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Usuario es Obligatorio");
                }

            }
        }*/
        public string contrasenia { get; set; }
        /*public string contrasenia
        {
            get { return _contra; }
            set
            {
                if (value != string.Empty)
                {
                    _contra = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Contraseña es Obligatorio");
                }

            }
        }*/
        public string cliente_activo;
       /* public string cliente_activo
        {
            get { return _activo; }
            set
            {
                if (value != string.Empty)
                {
                    _activo = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Cliente Activo no puede estar Vacío");
                }

            }
        }*/
        public string rut_cliente { get; set; }
        public string rut_empleado { get; set; }

        /*
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }*/

        public Login()
        {
                
        }

    }
}
