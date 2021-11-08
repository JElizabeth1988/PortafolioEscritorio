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
    public class Mesa
    {
        public int num_mesa { get; set; }
        public int capacidad_persona { get; set; }
        public string disponibilidad { get; set; }
        public string asignacion { get; set; }
        public string rut_empleado { get; set; }

        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;
        [NonSerialized]
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        public Mesa()
        {

        }
                
        //**********************************************************
        //----------------CRUD--------------------------------------
        //***********************************************************
        //----------------Método agregar----------------------
        public bool Agregar(Mesa mes)
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
                CMD.CommandText = "SP_AGREGAR_MESAS";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                //CMD.Parameters.Add(new OracleParameter("P_NUMERO", OracleDbType.Int32)).Value = mes.num_mesa; //seagrega x trigger                              
                CMD.Parameters.Add(new OracleParameter("P_CAPACIDAD", OracleDbType.Int32)).Value = mes.capacidad_persona;
                CMD.Parameters.Add(new OracleParameter("P_DISPONIBILIDAD", OracleDbType.Varchar2, 15)).Value = mes.disponibilidad;
                CMD.Parameters.Add(new OracleParameter("P_ASIGNACION", OracleDbType.Varchar2, 10)).Value = mes.asignacion;
                CMD.Parameters.Add(new OracleParameter("P_RUT_EMPLEADO", OracleDbType.Varchar2, 12)).Value = mes.rut_empleado;

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
                return false;
                Logger.Mensaje(ex.Message);               

            }
        }

        //------------Método Actualizar------------------------------------------
        public bool Actualizar(Mesa mes)
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
                CMD.CommandText = "SP_ACTUALIZAR_MESA";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = mes.num_mesa;
                CMD.Parameters.Add(new OracleParameter("P_CAPACIDAD", OracleDbType.Int32)).Value = mes.capacidad_persona;
                CMD.Parameters.Add(new OracleParameter("P_DISPONIBILIDAD", OracleDbType.Varchar2, 15)).Value = mes.disponibilidad;
                CMD.Parameters.Add(new OracleParameter("P_ASIGNACION", OracleDbType.Varchar2, 10)).Value = mes.asignacion;
                CMD.Parameters.Add(new OracleParameter("P_RUT_EMPLEADO", OracleDbType.Varchar2, 12)).Value = mes.rut_empleado;

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
                return false;
                Logger.Mensaje(ex.Message);                
            }
        }       

        //---------Método Eliminar-----------------------------------------------
        public bool Eliminar(int num) //Recibe rut pot parametro
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
                CMD.CommandText = "SP_ELIMINAR_MESA";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = num;

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
                return false;
                Logger.Mensaje(ex.Message);               

            }
        }

        //------------Listar---------------------------------------
        //Llamo a la lista creada más abajo, porque trae nombres en vez de id y porque las variables se ven mejor en la grilla
        public List<ListaMesa> Listar()
        {
            try
            {

                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<ListaMesa> lista = new List<ListaMesa>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_MESA";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("MESAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaMesa C = new ListaMesa();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    C.Número = int.Parse(dr.GetValue(0).ToString());
                    C.Capacidad = dr.GetValue(1).ToString() + " Personas";
                    C.Disponibilidad = dr.GetValue(2).ToString();
                    C.asignacion = dr.GetValue(3).ToString();
                    C.Rut_Empleado = dr.GetValue(4).ToString();                    
                    C.Empleado = dr.GetValue(5).ToString();
                    
                    lista.Add(C);
                }
                //Cerrar la conexión
                conn.Close();
                return lista;

            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
                Logger.Mensaje(ex.Message);
            }
        }
        //---Para asignación de mesa para que se vea el orden de la signacion presencial primero
        public List<ListaMesa> Listar2()
        {
            try
            {

                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<ListaMesa> lista = new List<ListaMesa>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_MESA2";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("MESAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaMesa C = new ListaMesa();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    C.Número = int.Parse(dr.GetValue(0).ToString());
                    C.Capacidad = dr.GetValue(1).ToString() + " Personas";
                    C.Disponibilidad = dr.GetValue(2).ToString();
                    C.asignacion = dr.GetValue(3).ToString();
                    C.Rut_Empleado = dr.GetValue(4).ToString();
                    C.Empleado = dr.GetValue(5).ToString();

                    lista.Add(C);
                }
                //Cerrar la conexión
                conn.Close();
                return lista;

            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
                Logger.Mensaje(ex.Message);
            }
        }
        //-----------------------------------------------------------------
        //----Filtrar por asignación
        public List<ListaMesa> FiltrarAsign(string asig)
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
                List<ListaMesa> lista = new List<ListaMesa>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRAR_MESA_ASIG";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_ASIG", OracleDbType.Varchar2, 10)).Value = asig;
                CMD.Parameters.Add(new OracleParameter("MESAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaMesa i = new ListaMesa();

                    //lee cada valor en su posición
                    i.Número = int.Parse(reader[0].ToString());
                    i.Capacidad = reader[1].ToString();
                    i.Disponibilidad = reader[2].ToString();
                    i.asignacion = reader[3].ToString();
                    i.Rut_Empleado = reader[4].ToString();
                    i.Empleado = reader[5].ToString();
                   
                    //Agrega los valores a la lista, que luego es devuelta por el método
                    lista.Add(i);
                    contador = 1;

                }
                conn.Close();
                if (contador == 1)
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
                return null;
                Logger.Mensaje(ex.Message);
                conn.Close();

            }

        }
        //----Filtrar por Disponibilidad
        public List<ListaMesa> FiltrarDisp(string disp)
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
                List<ListaMesa> lista = new List<ListaMesa>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRAR_MESA_DISP";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_DISP", OracleDbType.Varchar2, 10)).Value = disp;
                CMD.Parameters.Add(new OracleParameter("MESAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaMesa i = new ListaMesa();

                    //lee cada valor en su posición
                    i.Número = int.Parse(reader[0].ToString());
                    i.Capacidad = reader[1].ToString();
                    i.Disponibilidad = reader[2].ToString();
                    i.asignacion = reader[3].ToString();
                    i.Rut_Empleado = reader[4].ToString();
                    i.Empleado = reader[5].ToString();

                    //Agrega los valores a la lista, que luego es devuelta por el método
                    lista.Add(i);
                    contador = 1;

                }
                conn.Close();
                if (contador == 1)
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
                return null;
                Logger.Mensaje(ex.Message);
                conn.Close();

            }

        }

        //Lista Mesas para mostrar nombres en vez de id (para procedimientos con Joins)
        [Serializable]
        public class ListaMesa
        {
            public int Número { get; set; }
            public string Capacidad { get; set; }
            public string Disponibilidad { get; set; }
            public string asignacion { get; set; }
            public string Rut_Empleado { get; set; }
            public string Empleado { get; set; }
        
            public ListaMesa()
            {

            }
        }

        //Lista Mesas para cbo
        [Serializable]
        public class ListaMesaCBO
        {
            public int Número { get; set; }
            [NonSerialized]
            //Crear objeto de la Bdd
            OracleConnection conn = null;

            public ListaMesaCBO()
            {

            }

            public List<ListaMesaCBO> ListarCbo()
            {
                try
                {
                    //Se instancia la conexión a la BD
                    conn = new Conexion().Getcone();
                    //se crea un comando de oracle
                    OracleCommand cmd = new OracleCommand();
                    //Lista de clientes
                    List<ListaMesaCBO> lista = new List<ListaMesaCBO>();
                    //se ejecutan los comandos de procedimientos
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //conexion
                    cmd.Connection = conn;
                    //procedimiento
                    cmd.CommandText = "SP_LISTAR_MESA_CB";
                    //Se agrega el parámetro de salida
                    cmd.Parameters.Add(new OracleParameter("MESAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                    //se abre la conexion
                    conn.Open();
                    //se crea un reader
                    OracleDataReader dr = cmd.ExecuteReader();
                    //mientras lea
                    while (dr.Read())
                    {
                        ListaMesaCBO C = new ListaMesaCBO();

                        //se obtiene el valor con getvalue es lo mismo pero con get
                        C.Número = int.Parse(dr.GetValue(0).ToString());
                        
                        lista.Add(C);
                    }
                    //Cerrar la conexión
                    conn.Close();
                    return lista;

                }
                catch (Exception ex)
                {
                    conn.Close();
                    return null;
                    Logger.Mensaje(ex.Message);
                }
            }
        }

        
        //------------------Método Buscar--------------
        /*  public async void Buscar(int num)
          {
              try
              {
                  //Instanciar la conexión
                  conn = new Conexion().Getcone();
                  OracleCommand CMD = new OracleCommand();
                  CMD.CommandType = System.Data.CommandType.StoredProcedure;
                  List<Mesa> mes = new List<Mesa>();
                  //nombre de la conexion
                  CMD.Connection = conn;
                  //nombre del procedimeinto almacenado
                  CMD.CommandText = "SP_BUSCAR_MESA";
                  //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// 
                  CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = num;
                  CMD.Parameters.Add(new OracleParameter("MESAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                  //se abre la conexion
                  conn.Open();
                  OracleDataReader reader = CMD.ExecuteReader();
                  Mesa c = null;
                  while (reader.Read())//Mientras lee
                  {
                      c = new Mesa();

                      num = int.Parse(reader[0].ToString());                    
                      capacidad_persona = int.Parse(reader[1].ToString());
                      disponibilidad = reader[2].ToString();
                      rut_empleado = reader[3].ToString();

                      mes.Add(c);

                  }
                  //Cerrar conexión
                  conn.Close();

              }
              catch (Exception ex)
              {
                  Logger.Mensaje(ex.Message);
                  conn.Close();
              }
          }*/
    }
}
