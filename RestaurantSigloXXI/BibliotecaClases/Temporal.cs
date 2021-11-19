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
    public class Temporal
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int valor { get; set; }
        public int cantidad { get; set; }
        public int total { get; set; }

        public Temporal()
        {

        }

        //No es serializable
        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;

        public bool Agregar(Temporal temp)
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
                CMD.CommandText = "SP_TEMPORAL";
                //Se crea un nuevo tipo de parametro, nombre parametro, el tipo, el largo, y el valor es igual al de la clase.
                //CMD.Parameters.Add(new OracleParameter("P_ID_PROD", OracleDbType.Int32)).Value = prod.id_producto; -->Se agrega x Trigger con secuencia
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 50)).Value = temp.nombre;
                CMD.Parameters.Add(new OracleParameter("P_VALOR", OracleDbType.Int32)).Value = temp.valor;
                CMD.Parameters.Add(new OracleParameter("P_CANTIDAD", OracleDbType.Int32, 10)).Value = temp.cantidad;
                CMD.Parameters.Add(new OracleParameter("P_TOTAL", OracleDbType.Int32)).Value = temp.total;

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

        }

        //------------Listar Productos para pedidos-------------
        public List<Temporal> Listar()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<Temporal> lista = new List<Temporal>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_CARGAR_TEMP";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("PEDIDOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Temporal t = new Temporal();

                    //se obtiene el valor con getvalue es lo mismo pero con get                    
                    t.nombre = dr.GetValue(0).ToString();
                    t.valor = int.Parse(dr.GetValue(1).ToString());
                    t.cantidad = int.Parse(dr.GetValue(2).ToString());
                    t.total = int.Parse(dr.GetValue(3).ToString());

                    lista.Add(t);
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

        }
    }
}
