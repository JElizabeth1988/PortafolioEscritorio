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
    //Indicar que la variable es serializable
    [Serializable]
    public class Empleado
    {

        private string _rut_empleado;

        public string rut_empleado
        {
            get { return _rut_empleado; }
            set
            {
                if (value != string.Empty && value.Length >= 9 && value.Length <= 12)
                {
                    _rut_empleado = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("Campo Rut  no puede estar Vacío");
                }

            }
        }
        private string _primer_nombre;

        public string primer_nom_emp
        {
            get { return _primer_nombre; }
            set
            {
                if (value != string.Empty)
                {
                    _primer_nombre = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("Campo Nombre no puede estar Vacío");
                }
            }
        }

        public string segundo_nom_emp { get; set; }

        private string _ap_paterno;

        public string apellido_pat_emp
        {
            get { return _ap_paterno; }
            set
            {
                if (value != string.Empty)
                {
                    _ap_paterno = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("Campo Apellido Paterno no puede estar Vacío");
                }
            }
        }

        private string _ap_materno;

        public string apellido_mat_emp
        {
            get { return _ap_materno; }
            set
            {
                if (value != string.Empty)
                {
                    _ap_materno = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("Campo Apellido Materno no puede estar Vacío");
                }
            }
        }

        public int celular_emp { get; set; }
        /*private int _celular;

        public int celular_cli
        {
            get { return _celular; }
            set
            {
                if (value != 0 )
                {
                    _celular = value;
                }
                else
                {
                    err.AgregarError("Campo Celular no puede estar Vacío");
                    //throw new ArgumentException("- Campo Teléfono no puede estar Vacío y debe tener un largo de 9 dígitos");
                }
            }
        }*/

        public int telefono_emp { get; set; }
        /*private int _telefono;

        public int telefono_cli
         {
             get { return _telefono; }
             set {
                     if (value != 0 )
                     {
                         _telefono = value;
                     }
                     else
                     {
                         err.AgregarError("Campo Teléfono no puede estar Vacío");
                         //throw new ArgumentException("- Campo Teléfono no puede estar Vacío y debe tener un largo de 9 dígitos");
                     }
             }
         }*/

        private string _correo_cli;
        public string correo_emp
        {
            get { return _correo_cli; }
            set
            {
                if (value != string.Empty)
                {
                    _correo_cli = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("Campo correo electrónico no puede estar Vacío");
                }
            }
        }

        public int id_tipo_user { get; set; }
        public String usuario { get; set; }
        public String contrasenia { get; set; }


        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;
        [NonSerialized]
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        public Empleado()
        {

        }

        //CRUD
        //----------------Método Login de Empleado
        public int Metodologin(string user, string pass)
        {
            try
            {
                //Variable donde guardaré el resultado
                int tipo_user = 0;
                //Instanciar la conexión
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo de comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_LOGIN_EMP2";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_USER", OracleDbType.Varchar2, 20)).Value = user;
                CMD.Parameters.Add(new OracleParameter("P_PASS", OracleDbType.Varchar2, 20)).Value = pass;
                //Parámetro de Salida de tipo int (id_tipo_user)
                CMD.Parameters.Add(new OracleParameter("P_TIPO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //se ejecuta la query
                CMD.ExecuteNonQuery();

                //tipo_user = Convert.ToInt32(CMD.Parameters["P_TIPO"].Value); --->Dio error
                //Se le entrega el resultado a la variable que es el resultado del procedure parseado
                tipo_user = int.Parse(CMD.Parameters["P_TIPO"].Value.ToString());

                //Cerrar conexión
                conn.Close();
                return tipo_user;

            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return 0;
                
            }
        }

        //----------------Método agregar----------------------


        public class ListaEmpleado
        {
            public string Rut { get; set; }
            public string Nombre { get; set; }
            public string Segundo_Nombre { get; set; }
            public string Apellido_Paterno { get; set; }
            public string Apellido_Materno { get; set; }
            public int Celular { get; set; }
            public int Teléfono { get; set; }
            public string Email { get; set; }
            public String Rol { get; set; }


            public ListaEmpleado()
            {

            }
        }

    }

    }