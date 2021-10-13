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
    //Indicar que la variable es serializable (para memoria cache)
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

        private string _correo;
        public string correo_emp
        {
            get { return _correo; }
            set
            {
                if (value != string.Empty)
                {
                    _correo = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("Campo correo electrónico no puede estar Vacío");
                }
            }
        }
        //Foranea
        public int id_tipo_user { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }

        //No es serializable
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
                CMD.CommandText = "SP_LOGIN_EMP";
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
                conn.Close();
                return 0;
                
            }
        }

        //----------------Método agregar----------------------
        public bool Agregar(Empleado emplea)
        {
            try
            {
                //Instanciar la conexión
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo de comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_AGREGAR_EMPLEADO";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = emplea.rut_empleado;
                CMD.Parameters.Add(new OracleParameter("P_PRIMER_NOMBRE", OracleDbType.Varchar2, 45)).Value = emplea.primer_nom_emp;
                CMD.Parameters.Add(new OracleParameter("P_SEGUNDO_NOMBRE", OracleDbType.Varchar2, 45)).Value = emplea.segundo_nom_emp;
                CMD.Parameters.Add(new OracleParameter("P_AP_PATERNO", OracleDbType.Varchar2, 45)).Value = emplea.apellido_pat_emp;
                CMD.Parameters.Add(new OracleParameter("P_AP_MATERNO", OracleDbType.Varchar2, 45)).Value = emplea.apellido_mat_emp;
                CMD.Parameters.Add(new OracleParameter("P_CELULAR", OracleDbType.Int32)).Value = emplea.celular_emp;
                CMD.Parameters.Add(new OracleParameter("P_TELEFONO", OracleDbType.Int32)).Value = emplea.telefono_emp;
                CMD.Parameters.Add(new OracleParameter("P_EMAIL", OracleDbType.Varchar2, 80)).Value = emplea.correo_emp;
                CMD.Parameters.Add(new OracleParameter("P_USUARIO", OracleDbType.Varchar2, 20)).Value = emplea.usuario;
                CMD.Parameters.Add(new OracleParameter("P_PASS", OracleDbType.Varchar2, 20)).Value = emplea.contrasenia;
                CMD.Parameters.Add(new OracleParameter("P_TIPO_USER", OracleDbType.Int32)).Value = emplea.id_tipo_user;

                //Se abre la conexión
                conn.Open();
                //se ejecuta la query 
                CMD.ExecuteNonQuery();
                //se cierra la conexioin
                conn.Close();
                //Retorno
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
                conn.Close();             

            }
        }

        //------------Método Actualizar------------------------------------------
        public bool Actualizar(Empleado emp)
        {
            try
            {
                //Instanciar la conexión
                conn = new Conexion().Getcone();

                OracleCommand CMD = new OracleCommand();
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_ACTUALIZAR_EMPLEADO";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = emp.rut_empleado;
                CMD.Parameters.Add(new OracleParameter("P_PRIMER_NOMBRE", OracleDbType.Varchar2, 45)).Value = emp.primer_nom_emp;
                CMD.Parameters.Add(new OracleParameter("P_SEGUNDO_NOMBRE", OracleDbType.Varchar2, 45)).Value = emp.segundo_nom_emp;
                CMD.Parameters.Add(new OracleParameter("P_AP_PATERNO", OracleDbType.Varchar2, 45)).Value = emp.apellido_pat_emp;
                CMD.Parameters.Add(new OracleParameter("P_AP_MATERNO", OracleDbType.Varchar2, 45)).Value = emp.apellido_mat_emp;
                CMD.Parameters.Add(new OracleParameter("P_CELULAR", OracleDbType.Int32)).Value = emp.celular_emp;
                CMD.Parameters.Add(new OracleParameter("P_TELEFONO", OracleDbType.Int32)).Value = emp.telefono_emp;
                CMD.Parameters.Add(new OracleParameter("P_EMAIL", OracleDbType.Varchar2, 80)).Value = emp.correo_emp;
                CMD.Parameters.Add(new OracleParameter("P_USUARIO", OracleDbType.Varchar2, 20)).Value = emp.usuario;
                CMD.Parameters.Add(new OracleParameter("P_PASS", OracleDbType.Varchar2, 20)).Value = emp.contrasenia;
                CMD.Parameters.Add(new OracleParameter("P_TIPO_USER", OracleDbType.Int32)).Value = emp.id_tipo_user;

                //Se abre la conexión
                conn.Open();
                //se ejecuta la query
                CMD.ExecuteNonQuery();
                //se cierra la conexioin
                conn.Close();
                //Retorno
                return true;
            }
            catch (Exception ex)
            {

                return false;
                Logger.Mensaje(ex.Message);
                conn.Close();
            }
        }

        //------------------Método Buscar--------------
        public async void Buscar(String rut)
        {
            try
            {
                //Instanciar la conexión
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                List<Empleado> list = new List<Empleado>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_BUSCAR_EMPLEADO";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = rut;
                CMD.Parameters.Add(new OracleParameter("EMPLEADOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                OracleDataReader reader = CMD.ExecuteReader();
                Empleado e = null;
                while (reader.Read())//Mientras lee
                {
                    e = new Empleado();

                    rut_empleado = reader[0].ToString();
                    primer_nom_emp = reader[1].ToString();
                    segundo_nom_emp = reader[2].ToString();
                    apellido_pat_emp = reader[3].ToString();
                    apellido_mat_emp = reader[4].ToString();
                    correo_emp = reader[5].ToString();
                    celular_emp = int.Parse(reader[6].ToString());
                    telefono_emp = int.Parse(reader[7].ToString());
                    id_tipo_user = int.Parse(reader[8].ToString());
                    usuario = reader[9].ToString();
                    contrasenia = reader[10].ToString();
                    
                    list.Add(e);

                }
                //Cerrar conexión
                conn.Close();

            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                conn.Close();
            }
        }

        

        //---------Método Eliminar-----------------------------------------------
        public bool Eliminar(String rut) //Recibe rut pot parametro
        {
            try
            {
                //Instanciar la conexión
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_ELIMINAR_EMPLEADO";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = rut;

                //se abre la conexion
                conn.Open();
                //se ejecuta la query
                CMD.ExecuteNonQuery();
                //se cierra la conexioin
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {

                return false;
                Logger.Mensaje(ex.Message);
                conn.Close();

            }
        }

        //------------Listar Empleados-------------
        //Llamo a la lista creada más abajo, porque trae nombres en vez de id y porque las variables se ven mejor en la grilla
        public List<ListaEmpleado> Listar()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<ListaEmpleado> lista = new List<ListaEmpleado>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_EMPLEADO";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("EMPLEADOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaEmpleado e = new ListaEmpleado();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    e.Rut = dr.GetValue(0).ToString();
                    e.Nombre = dr.GetValue(1).ToString();
                    e.Segundo_Nombre = dr.GetValue(2).ToString();
                    e.Apellido_Paterno = dr.GetValue(3).ToString();
                    e.Apellido_Materno = dr.GetValue(4).ToString();
                    e.Celular = int.Parse(dr.GetValue(5).ToString());
                    e.Teléfono = int.Parse(dr.GetValue(6).ToString());
                    e.Email = dr.GetValue(7).ToString();
                    e.Usuario = dr.GetValue(8).ToString();
                    e.Contraseña = dr.GetValue(9).ToString();
                    e.Rol = dr.GetValue(10).ToString();

                    lista.Add(e);
                }
                //Cerrar la conexión
                conn.Close();
                return lista;

            }
            catch (Exception ex)
            {
                return null;
                Logger.Mensaje(ex.Message);
                conn.Close();
            }
        }

        //------------Filtrar por Rut--------------------
        public List<ListaEmpleado> Filtrar(String rut)
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista de Clientes
                List<ListaEmpleado> lista = new List<ListaEmpleado>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRAR_RUT_EM";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = rut;
                CMD.Parameters.Add(new OracleParameter("EMPLEADOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaEmpleado e = new ListaEmpleado();

                    //lee cada valor en su posición
                    e.Rut = reader[0].ToString();
                    e.Nombre = reader[1].ToString();
                    e.Segundo_Nombre = reader[2].ToString();
                    e.Apellido_Paterno = reader[3].ToString();
                    e.Apellido_Materno = reader[4].ToString();
                    e.Celular = int.Parse(reader[5].ToString());
                    e.Teléfono = int.Parse(reader[6].ToString());
                    e.Email = reader[7].ToString();
                    e.Usuario = reader[8].ToString();
                    e.Contraseña = reader[9].ToString();
                    e.Rol = reader[10].ToString();

                    //Agrega los valores a la lista, que luego es devuelta por el método
                    lista.Add(e);

                }
                conn.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
                Logger.Mensaje(ex.Message);
                conn.Close();

            }

        }

        //------------Filtrar por Rol--------------------
        public List<ListaEmpleado> FiltrarRol(int tipo)
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista de Clientes
                List<ListaEmpleado> lista = new List<ListaEmpleado>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRAR_ROL_EM";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_ROL", OracleDbType.Int32)).Value = tipo;
                CMD.Parameters.Add(new OracleParameter("EMPLEADOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaEmpleado e = new ListaEmpleado();

                    //lee cada valor en su posición
                    e.Rut = reader[0].ToString();
                    e.Nombre = reader[1].ToString();
                    e.Segundo_Nombre = reader[2].ToString();
                    e.Apellido_Paterno = reader[3].ToString();
                    e.Apellido_Materno = reader[4].ToString();
                    e.Celular = int.Parse(reader[5].ToString());
                    e.Teléfono = int.Parse(reader[6].ToString());
                    e.Email = reader[7].ToString();
                    e.Usuario = reader[8].ToString();
                    e.Contraseña = reader[9].ToString();
                    e.Rol = reader[10].ToString();

                    //Agrega los valores a la lista, que luego es devuelta por el método
                    lista.Add(e);

                }
                conn.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
                Logger.Mensaje(ex.Message);
                conn.Close();

            }

        }
        //--------------------------Para mesa----------------------------
        
        //-----------Listar empleados llamado desde mesa
        public List<ListaEmpleadoMesa2> ListarMesa()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<ListaEmpleadoMesa2> lista = new List<ListaEmpleadoMesa2>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_EMPLEADO_MESA";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("EMPLEADOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaEmpleadoMesa2 e = new ListaEmpleadoMesa2();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    e.Rut = dr.GetValue(0).ToString();
                    e.Nombre = dr.GetValue(1).ToString();
                    e.Segundo_Nombre = dr.GetValue(2).ToString();
                    e.Apellido_Paterno = dr.GetValue(3).ToString();
                    e.Apellido_Materno = dr.GetValue(4).ToString();
                    e.Rol = dr.GetValue(5).ToString();

                    lista.Add(e);
                }
                //Cerrar la conexión
                conn.Close();
                return lista;

            }
            catch (Exception ex)
            {
                return null;
                Logger.Mensaje(ex.Message);
                conn.Close();
            }
        }

        //------------Filtro mesa
        public List<ListaEmpleadoMesa2> FiltrarMesa(string rut)
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista de Clientes
                List<ListaEmpleadoMesa2> lista = new List<ListaEmpleadoMesa2>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRAR_EMPLEADO_MESA";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = rut;
                CMD.Parameters.Add(new OracleParameter("EMPLEADOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaEmpleadoMesa2 e = new ListaEmpleadoMesa2();

                    //lee cada valor en su posición
                    e.Rut = reader[0].ToString();
                    e.Nombre = reader[1].ToString();
                    e.Segundo_Nombre = reader[2].ToString();
                    e.Apellido_Paterno = reader[3].ToString();
                    e.Apellido_Materno = reader[4].ToString();
                    e.Rol = reader[5].ToString();

                    //Agrega los valores a la lista, que luego es devuelta por el método
                    lista.Add(e);

                }
                conn.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
                Logger.Mensaje(ex.Message);
                conn.Close();

            }

        }

        //------------Filtro mesa rol
        public List<ListaEmpleadoMesa2> FiltrarMesaRol(int rol)
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista de Clientes
                List<ListaEmpleadoMesa2> lista = new List<ListaEmpleadoMesa2>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRAR_ROL_MESA";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_ROL", OracleDbType.Int32)).Value = rol;
                CMD.Parameters.Add(new OracleParameter("EMPLEADOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaEmpleadoMesa2 e = new ListaEmpleadoMesa2();

                    //lee cada valor en su posición
                    e.Rut = reader[0].ToString();
                    e.Nombre = reader[1].ToString();
                    e.Segundo_Nombre = reader[2].ToString();
                    e.Apellido_Paterno = reader[3].ToString();
                    e.Apellido_Materno = reader[4].ToString();
                    e.Rol = reader[5].ToString();

                    //Agrega los valores a la lista, que luego es devuelta por el método
                    lista.Add(e);

                }
                conn.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
                Logger.Mensaje(ex.Message);
                conn.Close();

            }

        }
        //---------------------------------------------------------------
        //Buscar empleado para mesa
        public async void BuscarEmpMesa(String rut)
        {

            try
            {
                //Instanciar la conexión
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                List<ListaEmpleadoMesa> list = new List<ListaEmpleadoMesa>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_BUSCAR_EMPLEADO_MESA";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = rut;
                CMD.Parameters.Add(new OracleParameter("EMPLEADOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                OracleDataReader reader = CMD.ExecuteReader();
                ListaEmpleadoMesa e = null;
                while (reader.Read())//Mientras lee
                {
                    e = new ListaEmpleadoMesa();

                    e.Rut = reader[0].ToString();
                    e.Nombre = reader[1].ToString();

                    list.Add(e);

                }
                //Cerrar conexión
                conn.Close();

            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                conn.Close();
            }
        }

        //Lista Clientes para mostrar nombres en vez de id (para procedimientos con Joins)
        [Serializable]
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
            public String Usuario { get; set; }
            public String Contraseña { get; set; }
            public String Rol { get; set; }//Tipo de usuario


            public ListaEmpleado()
            {

            }
        }

        [Serializable]
        public class ListaEmpleadoMesa
        {
            public string Rut { get; set; }
            public string Nombre { get; set; }
            //No es serializable
            [NonSerialized]
            //Crear objeto de la Bdd
            OracleConnection conn = null;

            public ListaEmpleadoMesa()
            {

            }

           
        }

        [Serializable]
        public class ListaEmpleadoMesa2
        {
            public string Rut { get; set; }
            public string Nombre { get; set; }
            public string Segundo_Nombre { get; set; }
            public string Apellido_Paterno { get; set; }
            public string Apellido_Materno { get; set; }
            public String Rol { get; set; }//Tipo de usuario

            public ListaEmpleadoMesa2()
            {

            }
        }

    }

    }