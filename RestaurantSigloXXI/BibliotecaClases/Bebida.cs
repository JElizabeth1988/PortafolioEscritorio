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
{ //Indicar que la variable es serializable
    [Serializable]
    public class Bebida
    {
        public int id_bebida { get; set; }
        public string nom_bebida { get; set; }
        public int ml_bebida { get; set; }
        public int valor_bebida { get; set; }
        public int stock { get; set; }
        public int id_tipo_producto { get; set; }

        //No es serializable
        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;
        [NonSerialized]
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        public Bebida()
        {

        }
        
        //**********************************************************
        //----------------CRUD--------------------------------------
        //***********************************************************
        //----------------Método agregar----------------------
        public bool Agregar(Bebida fantita)
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
                CMD.CommandText = "SP_AGREGAR_BEBIDA";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                //CMD.Parameters.Add(new OracleParameter("P_NUMERO", OracleDbType.Int32)).Value = mes.num_mesa; //seagrega x trigger                              
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 80)).Value = fantita.nom_bebida;
                CMD.Parameters.Add(new OracleParameter("P_ML", OracleDbType.Int32)).Value = fantita.ml_bebida;
                CMD.Parameters.Add(new OracleParameter("P_VALOR", OracleDbType.Int32)).Value = fantita.valor_bebida;
                CMD.Parameters.Add(new OracleParameter("P_STOCK", OracleDbType.Int32)).Value = fantita.stock;
                CMD.Parameters.Add(new OracleParameter("P_ID_TIPO", OracleDbType.Int32)).Value = fantita.id_tipo_producto;

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

        //------------Método Actualizar------------------------------------------
        public bool Actualizar(Bebida fantita)
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
                CMD.CommandText = "SP_ACTUALIZAR_BEBIDA";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_NUMERO", OracleDbType.Int32)).Value = fantita.id_bebida;                              
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 80)).Value = fantita.nom_bebida;
                CMD.Parameters.Add(new OracleParameter("P_ML", OracleDbType.Int32)).Value = fantita.ml_bebida;
                CMD.Parameters.Add(new OracleParameter("P_VALOR", OracleDbType.Int32)).Value = fantita.valor_bebida;
                CMD.Parameters.Add(new OracleParameter("P_STOCK", OracleDbType.Int32)).Value = fantita.stock;
                CMD.Parameters.Add(new OracleParameter("P_ID_TIPO", OracleDbType.Int32)).Value = fantita.id_tipo_producto;

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
                CMD.CommandText = "SP_ELIMINAR_BEBIDA";
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

                return false;
                Logger.Mensaje(ex.Message);
                conn.Close();

            }
        }

        //------------Listar---------------------------------------
        //Llamo a la lista creada más abajo, porque trae nombres en vez de id y porque las variables se ven mejor en la grilla
        public List<ListaBebida> Listar()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<ListaBebida> lista = new List<ListaBebida>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_BEBIDA";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("BEBIDAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaBebida C = new ListaBebida();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    C.Id = int.Parse(dr.GetValue(0).ToString());
                    C.Nombre = dr.GetValue(1).ToString();
                    C.Ml = dr.GetValue(2).ToString()+ " Ml";
                    C.Valor = "$ "+dr.GetValue(3).ToString();
                    C.Stock = dr.GetValue(4).ToString()+ " Unidades";
                    C.Tipo = dr.GetValue(5).ToString();

                    lista.Add(C);
                }
                //Cerrar la conexión
                conn.Close();
                return lista;

            }
            catch (Exception ex)
            {
                return null;
                Logger.Mensaje(ex.Message);
            }
        }

        //------------Filtrar por tipo--------------------
        public List<ListaBebida> Filtrar(string tipo)
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
                List<ListaBebida> lista = new List<ListaBebida>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRAR_BEBIDA";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_TIPO", OracleDbType.Varchar2)).Value = tipo;
                CMD.Parameters.Add(new OracleParameter("BEBIDAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaBebida c = new ListaBebida();

                    //lee cada valor en su posición
                    c.Id = int.Parse(reader[0].ToString());
                    c.Nombre = reader[1].ToString();
                    c.Ml = reader[2].ToString() + " Ml";
                    c.Valor = "$ "+reader[3].ToString();
                    c.Stock = reader[4].ToString() + " Unidades";
                    c.Tipo = reader[5].ToString();
                    

                    //Agrega los valores a la lista, que luego es devuelta por el método
                    lista.Add(c);
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

            }

        }

        //------------Método Actualizar Stock------------------------------------------
        public bool ActualizarStock(int id, int stock)
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
                CMD.CommandText = "SP_STOCK_BEBIDA";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = id;
                CMD.Parameters.Add(new OracleParameter("P_STOCK", OracleDbType.Int32)).Value = stock;                

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
        //---------------------------------------------------------
        //----------Lista-----------------------------------------
        [Serializable]
        public class ListaBebida
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Ml { get; set; }
            public string Valor { get; set; }
            public string Stock { get; set; }
            public string Tipo { get; set; }

            public ListaBebida()
            {

            }
        }
    }
}
