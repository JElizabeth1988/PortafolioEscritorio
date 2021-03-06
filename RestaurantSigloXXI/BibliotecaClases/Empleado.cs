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
                    err.AgregarError("- Campo Rut no puede estar Vacío");
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
                    err.AgregarError("- Campo Nombre es Obligatorio");
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
                    err.AgregarError("- Campo Apellido Paterno es Obligatorio");
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
                    err.AgregarError("- Campo Apellido Materno es Obligatorio");
                }
            }
        }

        //public int celular_emp { get; set; }
        private int _celular;

        public int celular_emp
        {
            get { return _celular; }
            set
            {
                if (value > 900000000 && value < 1000000000)
                {
                    _celular = value;
                }
                else
                {
                    err.AgregarError("- Campo Celular es Obligatorio y debe tener un largo de 9 dígitos");
                    
                }
            }
        }

        public int telefono_emp { get; set; }
       

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
                    err.AgregarError("- Campo Correo Electrónico es Obligatorio");
                }
            }
        }
        //Foranea
        //public int id_tipo_user { get; set; }
        private int _id_tipo_user;
        public int id_tipo_user
        {
            get { return _id_tipo_user; }
            set
            {
                if (value != 0)
                {
                    _id_tipo_user = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Tipo de Usuario es Obligatorio");
                }
            }
        }

        //------------------------------
        //Variables para vista
        //public string usuario { get; set; }
        private string _usuario;
        public string usuario
        {
            get { return _usuario; }
            set
            {
                if (value != string.Empty)
                {
                    _usuario = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Usuario es Obligatorio");
                }
            }
        }

        //public string contrasenia { get; set; }
        private string _contrasenia;
        public string contrasenia
        {
            get { return _contrasenia; }
            set
            {
                if (value != string.Empty)
                {
                    _contrasenia = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Contraseña es Obligatorio");
                }
            }
        }
        //-----------------------------

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
         //---------------------------------------------------      
        //-----------CRUD-------------------------------------
        //----------------------------------------------------
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
                
                if (emplea.celular_emp != 0 && emplea.celular_emp > 900000000 && emplea.celular_emp < 1000000000)
                {
                    CMD.Parameters.Add(new OracleParameter("P_CELULAR", OracleDbType.Int32)).Value = emplea.celular_emp;
                }
                else
                {
                    //err.AgregarError("- Campo Celular es Obligatorio y debe tener un largo de 9 dígitos");
                }
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
                conn.Close();
                Logger.Mensaje(ex.Message);
                return false;                            

            }
            finally
            {
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
                if (emp.celular_emp != 0 && emp.celular_emp > 900000000 && emp.celular_emp < 1000000000)
                {
                    CMD.Parameters.Add(new OracleParameter("P_CELULAR", OracleDbType.Int32)).Value = emp.celular_emp;
                }
                else
                {
                    err.AgregarError("- Campo Celular es Obligatorio y debe tener un largo de 9 dígitos");
                }
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
                conn.Close();
                Logger.Mensaje(ex.Message);
                return false;                              
            }
            finally
            {
                conn.Close();
            }
        }

        //------------------Método Buscar--------------
        public async void Buscar(string rut)
        {
            try
            {
                //Instanciar la conexión
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //lista
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
                //se crea un lector
                OracleDataReader reader = CMD.ExecuteReader();
                Empleado e = null;
                //mientras lee
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
                    //se agregan los datos a la clase empleado
                    list.Add(e);
                }
                //Cerrar conexión
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Mensaje(ex.Message);
                
            }
            finally
            {
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
                conn.Close();
                Logger.Mensaje(ex.Message);
                return false;
            }
            finally
            {
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
                //Lista
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
                conn.Close();
                Logger.Mensaje(ex.Message);
                return null; 
            }
            finally
            {
                conn.Close();
            }
        }

        //------------Filtrar por Rut--------------------
        public List<ListaEmpleado> Filtrar(String rut)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista 
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
                    contador = 1;

                }
                conn.Close();
                if (contador ==1)
                {
                    return lista;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Mensaje(ex.Message);
                return null;
           }
            finally
            {
                conn.Close();
            }

        }

        //------------Filtrar por Rol--------------------
        public List<ListaEmpleado> FiltrarRol(int tipo)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista 
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
                    contador = 1;
                }
                conn.Close();
                if (contador ==1)
                {
                    return lista;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Mensaje(ex.Message);
                return null;
            }
            finally
            {
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
                //Lista
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
                conn.Close();
                Logger.Mensaje(ex.Message);
                return null;               
            }
            finally
            {
                conn.Close();
            }
        }

        //------------Filtro mesa
        public List<ListaEmpleadoMesa2> FiltrarMesa(string rut)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista
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
                    contador = 1;
                }
                conn.Close();
                if (contador ==1)
                {
                    return lista;
                }
                else
                {
                    return null;
                }
               
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Mensaje(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }

        }
                
        //---------------------------------------------------------------
        

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
            //Buscar empleado para mesa
            public void BuscarEmpMesa(String rut)
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

                        Rut = reader[0].ToString();
                        Nombre = reader[1].ToString();
                        list.Add(e);

                    }
                    //Cerrar conexión
                    conn.Close();

                }
                catch (Exception ex)
                {
                    conn.Close();
                    Logger.Mensaje(ex.Message);
                    
                }
                finally
                {
                    conn.Close();
                }
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
            public string Rol { get; set; }//Tipo de usuario

            public ListaEmpleadoMesa2()
            {

            }
        }

    }

    }