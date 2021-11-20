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
        public string id_pedido { get; set; }
        public DateTime fecha_pedido { get; set; }
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
                CMD.CommandText = "SP_AGREGAR_PED_PROV";
                //Se crea un nuevo tipo de parametro, nombre parametro, el tipo, el largo, y el valor es igual al de la clase.
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Varchar2, 30)).Value = ped.id_pedido;
                CMD.Parameters.Add(new OracleParameter("P_FECHA", OracleDbType.Date)).Value = ped.fecha_pedido;
                CMD.Parameters.Add(new OracleParameter("P_PROVEEDOR", OracleDbType.Varchar2, 50)).Value = ped.id_proveedor;

                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 50)).Value = art.nombre;
                CMD.Parameters.Add(new OracleParameter("P_VALOR", OracleDbType.Varchar2, 50)).Value = art.valor;
                CMD.Parameters.Add(new OracleParameter("P_CANTIDAD", OracleDbType.Varchar2, 50)).Value = art.cantidad;
                CMD.Parameters.Add(new OracleParameter("P_TOTAL", OracleDbType.Varchar2, 50)).Value = art.total;


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
    }
}
