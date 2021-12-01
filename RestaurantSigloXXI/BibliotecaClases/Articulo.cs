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
    public class Articulo
    {
        public int id { get; set; }
        private string _nombre { get; set; }
        public string nombre
        {
            get { return _nombre; }
            set
            {
                if (value != null)
                {
                    _nombre = value;
                }
                else
                {
                    err.AgregarError("- Campo Nombre es Obligatorio");
                }

            }
        }
        private int _valor { get; set; }
        public int valor
        {
            get { return _valor; }
            set
            {
                if (value > 0)
                {
                    _valor = value;
                }
                else
                {
                    err.AgregarError("- Campo Valor es Obligatorio");
                }

            }
        }

        private int _cantidad { get; set; }
        public int cantidad
        {
            get { return _cantidad; }
            set
            {
                if (value > 0)
                {
                    _cantidad = value;
                }
                else
                {
                    err.AgregarError("- Campo Cantidad es Obligatorio");
                }

            }
        }
        private int _total { get; set; }
        public int total
        {
            get { return _total; }
            set
            {
                if (value > 0)
                {
                    _total = value;
                }
                else
                {
                    err.AgregarError("- Campo Total es Obligatorio");
                }

            }
        }
        private string _id_pedido { get; set; }
        public string id_pedido
        {
            get { return _id_pedido; }
            set
            {
                if (value != null)
                {
                    _id_pedido = value;
                }
                else
                {
                    err.AgregarError("- Campo Id Pedido es Obligatorio");
                }
            }
        }

        public Articulo()
        {

        }

        //No es serializable
        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;
        [NonSerialized]
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        public bool Agregar(Articulo temp)
        {
            try
            {
                //instanciar la Conexión
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo de comando se va ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //nombre de la ejecución
                CMD.Connection = conn;
                //nombre del Procedimiento Almacenado
                CMD.CommandText = "SP_AGREGAR_ARTICULO";
                //Se crea un nuevo tipo de parametro, nombre parametro, el tipo, el largo, y el valor es igual al de la clase.
                //CMD.Parameters.Add(new OracleParameter("P_ID_PROD", OracleDbType.Int32)).Value = prod.id_producto; -->Se agrega x Trigger con secuencia
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 50)).Value = temp.nombre;
                CMD.Parameters.Add(new OracleParameter("P_VALOR", OracleDbType.Int32)).Value = temp.valor;
                CMD.Parameters.Add(new OracleParameter("P_CANTIDAD", OracleDbType.Int32)).Value = temp.cantidad;
                CMD.Parameters.Add(new OracleParameter("P_TOTAL", OracleDbType.Int32)).Value = temp.total;
                CMD.Parameters.Add(new OracleParameter("P_ID_PEDIDO", OracleDbType.Varchar2, 30)).Value = temp.id_pedido;

                // Se abre la conexión
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

        //------------Listar Productos para pedidos-------------
        public List<ListaArticulos> Listar(string id)
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista
                List<ListaArticulos> lista = new List<ListaArticulos>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_CARGAR_TEMP";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Varchar2,30)).Value = id;
                cmd.Parameters.Add(new OracleParameter("PEDIDOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListaArticulos t = new ListaArticulos();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    t.id = int.Parse(dr.GetValue(0).ToString());
                    t.nombre = dr.GetValue(1).ToString();
                    t.valor = "$ "+ dr.GetValue(2).ToString();
                    t.cantidad = dr.GetValue(3).ToString();
                    t.total = "$ " + dr.GetValue(4).ToString();

                    lista.Add(t);
                }
                //Cerrar la conexión
                conn.Close();
                //Retorno
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

        //---------Método Eliminar-----------------------------------------------
        public bool Quitar(int id) //Recibe id por parametro
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
                CMD.CommandText = "SP_QUITAR";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = id;

                //se abre la conexion
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

        //----------------Método Login de Empleado
        public int Total(string id)
        {
            try
            {
                //Variable donde guardaré el resultado
                int total = 0;
                //Instanciar la conexión
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo de comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_TOTAL";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Varchar2, 30)).Value = id;
                CMD.Parameters.Add(new OracleParameter("TOTALES", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //se ejecuta la query
                CMD.ExecuteNonQuery();


                //tipo_user = Convert.ToInt32(CMD.Parameters["P_TIPO"].Value); --->Dio error
                //Se le entrega el resultado a la variable que es el resultado del procedure parseado
                total = int.Parse(CMD.Parameters["TOTALES"].Value.ToString());

                //Cerrar conexión
                conn.Close();
                //Retorno
                return total;
            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Mensaje(ex.Message);                
                return 0;                
            }
            finally
            {
                conn.Close();
            }
        }

        public class ListaArticulos
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public string valor { get; set; }
            public string cantidad { get; set; }
            public string total { get; set; }

            public ListaArticulos()
            {

            }
        }


    }
}
