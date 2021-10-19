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
    //Indicar que la clase es serializable
    [Serializable]
    public class Menu
    {/*
        public int id_plato { get; set; }
        public string nom_plato { get; set; }
        public int precio_plato { get; set; }
        public string descripcion { get; set; }
        public int tiempo_preparacion { get; set; }
        public string estado { get; set; }
        public int id_receta { get; set; }
        public int id_categoria { get; set; }
        public int id_producto { get; set; }


        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;
        [NonSerialized]
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        public Menu()
        {

        }
        //************************************************************
        //***** CRUD *************************************************
        //***********************************************************
        //----------------Método agregar----------------------
        public bool Agregar(Menu menusin)
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
                CMD.CommandText = "SP_AGREGAR_";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                //CMD.Parameters.Add(new OracleParameter("P_NUMERO", OracleDbType.Int32)).Value = mes.num_mesa; //seagrega x trigger                              
                CMD.Parameters.Add(new OracleParameter("P_CAPACIDAD", OracleDbType.Int32)).Value = mes.capacidad_persona;
                CMD.Parameters.Add(new OracleParameter("P_HORA", OracleDbType.Varchar2, 15)).Value = mes.disponibilidad;
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
                CMD.Parameters.Add(new OracleParameter("P_HORA", OracleDbType.Varchar2, 15)).Value = mes.disponibilidad;
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
                    C.Capacidad = int.Parse(dr.GetValue(1).ToString());
                    C.Disponibilidad = dr.GetValue(2).ToString();
                    C.Rut_Empleado = dr.GetValue(3).ToString();
                    C.Nombre_Empleado = dr.GetValue(4).ToString();

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

        //---------lista----------------
        [Serializable]
        public class ListaPlato
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public int Precio { get; set; }
            public string Descripcion { get; set; }
            public int Tiempo_Preparación { get; set; }
            public string Estado { get; set; }
            public string Receta { get; set; }
            public string Categoria { get; set; }
            public string Producto { get; set; }

            public ListaPlato()
            {

            }
        }*/
    }
}
