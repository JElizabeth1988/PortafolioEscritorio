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
    public class PedidoProveedor
    {
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
        private DateTime _fecha_pedido { get; set; }
        public DateTime fecha_pedido
        {
            get { return _fecha_pedido; }
            set
            {
                if (value != null)
                {
                    _fecha_pedido = value;
                }
                else
                {
                    err.AgregarError("- Campo Fecha es Obligatorio");
                }
            }
        }
        public string estado { get; set; }
        public int total { get; set; }
        public int id_proveedor { get; set; }

        public PedidoProveedor()
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

        public bool Agregar(PedidoProveedor ped, Articulo art)
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
                CMD.CommandText = "SP_AGREGAR_PED";
                //Se crea un nuevo tipo de parametro, nombre parametro, el tipo, el largo, y el valor es igual al de la clase.
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Varchar2, 30)).Value = ped.id_pedido;
                CMD.Parameters.Add(new OracleParameter("P_FECHA", OracleDbType.Date)).Value = ped.fecha_pedido;
                CMD.Parameters.Add(new OracleParameter("P_PROVEEDOR", OracleDbType.Int32)).Value = ped.id_proveedor;

                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 30)).Value = art.nombre;
                CMD.Parameters.Add(new OracleParameter("P_VALOR", OracleDbType.Int32)).Value = art.valor;
                CMD.Parameters.Add(new OracleParameter("P_CANTIDAD", OracleDbType.Int32)).Value = art.cantidad;
                CMD.Parameters.Add(new OracleParameter("P_TOTAL", OracleDbType.Int32)).Value = art.total;

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

        //---------------ELIMINAR---------------
        public bool Eliminar(string id) //Recibe id por parametro
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
                CMD.CommandText = "SP_CANCELAR_OP";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Varchar2, 30)).Value = id;

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
        //-------Guardar todo el pedido
        public bool GuardarOperacion(PedidoProveedor ped)
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
                CMD.CommandText = "SP_PEDIDO_PROV";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Varchar2,30)).Value = ped.id_pedido;
                CMD.Parameters.Add(new OracleParameter("P_TOTAL", OracleDbType.Int32)).Value = ped.total;
                CMD.Parameters.Add(new OracleParameter("P_PROVEEDOR", OracleDbType.Int32)).Value = ped.id_proveedor;

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
    }
}
