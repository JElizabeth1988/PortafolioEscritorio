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
    public class Plato
    {
        public int id_plato { get; set; }
        public string nom_plato { get; set; }
        public int precio_plato { get; set; }
        public string descripcion { get; set; }
        //public  byte foto { get; set; }
        public int  stock { get; set; }
        public int id_receta { get; set; }
        public int id_categoria { get; set; }


        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;
        [NonSerialized]
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        public Plato()
        {

        }
        //************************************************************
        //***** CRUD *************************************************
        //***********************************************************
        //----------------Método agregar----------------------
        public bool Agregar(Plato platito)
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
                CMD.CommandText = "SP_AGREGAR_PLATO";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                //CMD.Parameters.Add(new OracleParameter("P_NUMERO", OracleDbType.Int32)).Value = mes.num_mesa; //seagrega x trigger                              
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 80)).Value = platito.nom_plato;
                CMD.Parameters.Add(new OracleParameter("P_PRECIO", OracleDbType.Int32)).Value = platito.precio_plato;
                CMD.Parameters.Add(new OracleParameter("P_DESCRIPCION", OracleDbType.Varchar2, 200)).Value = platito.descripcion;
                CMD.Parameters.Add(new OracleParameter("P_STOCK", OracleDbType.Int32)).Value = platito.stock;
                CMD.Parameters.Add(new OracleParameter("P_RECETA", OracleDbType.Int32)).Value = platito.id_receta;
                CMD.Parameters.Add(new OracleParameter("P_CATEGORIA", OracleDbType.Int32)).Value = platito.id_categoria;

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
        public bool Actualizar(Plato platito)
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
                CMD.CommandText = "SP_ACTUALIZAR_PLATO";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = platito.id_plato; //seagrega x trigger                              
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 80)).Value = platito.nom_plato;
                CMD.Parameters.Add(new OracleParameter("P_PRECIO", OracleDbType.Int32)).Value = platito.precio_plato;
                CMD.Parameters.Add(new OracleParameter("P_DESCRIPCION", OracleDbType.Varchar2, 200)).Value = platito.descripcion;
                CMD.Parameters.Add(new OracleParameter("P_STOCK", OracleDbType.Int32)).Value = platito.stock;
                CMD.Parameters.Add(new OracleParameter("P_RECETA", OracleDbType.Int32)).Value = platito.id_receta;
                CMD.Parameters.Add(new OracleParameter("P_CATEGORIA", OracleDbType.Int32)).Value = platito.id_categoria;

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
          }*/

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
                CMD.CommandText = "SP_ELIMINAR_PLATO";
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
        public List<ListaPlato> Listar()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<ListaPlato> lista = new List<ListaPlato>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_PLATO";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("PLATOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaPlato i = new ListaPlato();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.Id = int.Parse(dr.GetValue(0).ToString());
                    i.Nombre = dr.GetValue(1).ToString();
                    i.Precio = "$ "+dr.GetValue(2).ToString();
                    i.Descripcion = dr.GetValue(3).ToString();
                    i.Stock = dr.GetValue(4).ToString() + "U.";
                    i.Receta = dr.GetValue(5).ToString();
                    i.Categoria = dr.GetValue(6).ToString();

                    lista.Add(i);
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

        //------------Listar---------------------------------------
        public List<ListaPlato> Filtrar(String cat)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<ListaPlato> lista = new List<ListaPlato>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_FILTRAR_PLATO";
                cmd.Parameters.Add(new OracleParameter("P_CATEGORIA", OracleDbType.Varchar2)).Value = cat;
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("PLATOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaPlato i = new ListaPlato();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.Id = int.Parse(dr.GetValue(0).ToString());
                    i.Nombre = dr.GetValue(1).ToString();
                    i.Precio = "$ "+dr.GetValue(2).ToString();
                    i.Descripcion = dr.GetValue(3).ToString();
                    i.Stock = dr.GetValue(4).ToString() + "U.";
                    i.Receta = dr.GetValue(5).ToString();
                    i.Categoria = dr.GetValue(6).ToString();

                    lista.Add(i);
                    contador = 1;
                }
                //Cerrar la conexión
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
            public string Precio { get; set; }
            public string Descripcion { get; set; }
            public string Stock { get; set; }
            public string Receta { get; set; }
            public string Categoria { get; set; }

            public ListaPlato()
            {

            }
        }
    }
}
