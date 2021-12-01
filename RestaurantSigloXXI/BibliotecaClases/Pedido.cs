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
    public class Pedido
    {
        public int id_pedido { get; set; }
        public DateTime fecha_pedido { get; set; }
        public string hora_pedido { get; set; }
        public int propina { get; set; }
        public int descuento { get; set; }
        public int subtotal { get; set; }
        public int total_pedido { get; set; }
        public string estado_solicitud { get; set; }
        public string rut_cliente { get; set; }

        public Pedido()
        {

        }
        OracleConnection conn = null;
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }


        //------------Listar
        public List<ListaPedido> Listar()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista 
                List<ListaPedido> lista = new List<ListaPedido>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_S_PAGO";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("PAGOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaPedido i = new ListaPedido();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.id = int.Parse(dr.GetValue(0).ToString());
                    i.fecha = DateTime.Parse(dr.GetValue(1).ToString());
                    i.hora = dr.GetValue(2).ToString();
                    i.propina = "$ "+dr.GetValue(3).ToString();
                    i.descuento = "$ "+dr.GetValue(4).ToString();
                    i.subtotal = "$ " + dr.GetValue(5).ToString();
                    i.total = "$ " + dr.GetValue(6).ToString();
                    i.mesa = int.Parse(dr.GetValue(7).ToString());
                    i.rut = dr.GetValue(8).ToString();
                    i.cliente = dr.GetValue(9).ToString();
                    i.estado = dr.GetValue(10).ToString();
                   
                    lista.Add(i);
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

        //------Filtrar---------------------
        public List<ListaPedido> Filtrar(int num)
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
                List<ListaPedido> lista = new List<ListaPedido>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRAR_S_PAGO";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_MESA", OracleDbType.Int32)).Value = num;
                CMD.Parameters.Add(new OracleParameter("PAGOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaPedido i = new ListaPedido();

                    //lee cada valor en su posición
                    i.id = int.Parse(reader[0].ToString());
                    i.fecha = DateTime.Parse( reader[1].ToString());
                    i.hora = reader[2].ToString();
                    i.propina = "$ "+reader[3].ToString();
                    i.descuento = "$ " + reader[4].ToString();
                    i.subtotal = "$ " + reader[5].ToString() ;
                    i.total = "$ " + reader[6].ToString();
                    i.mesa = int.Parse(reader[7].ToString());
                    i.rut = reader[8].ToString();
                    i.cliente = reader[9].ToString();
                    i.estado = reader[10].ToString();

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
                conn.Close();
                Logger.Mensaje(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }

        }



        //----------Método Cambiar estado de PEDIDO
        public bool CambiarEstado(int id)
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
                CMD.CommandText = "SP_APROBAR_PAGO";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = id;

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

        public class ListaPedido
        {
            public int id { get; set; }
            public DateTime fecha { get; set; }
            public string hora { get; set; }
            public string estado { get; set; }
            public string propina { get; set; }
            public string descuento { get; set; }

            public string subtotal { get; set; }
            public string total { get; set; }
            public int mesa { get; set; }
            
            public string cliente { get; set; }
            public string rut { get; set; }

            public ListaPedido()
            {

            }
        }
    }
}
