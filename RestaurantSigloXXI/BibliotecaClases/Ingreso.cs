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
    public class Ingreso
    {
        public int id_ingreso { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string monto { get; set; }

        public Ingreso()
        {
                
        }

        [NonSerialized]
        OracleConnection conn = null;
        //Capturar Errores
        [NonSerialized]
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        //------------Listar egresos
        public List<Ingreso> Listar(DateTime desde, DateTime hasta)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista 
                List<Ingreso> lista = new List<Ingreso>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_INGRESO";
                cmd.Parameters.Add(new OracleParameter("P_FECHA_DESDE", OracleDbType.Date)).Value = desde;
                cmd.Parameters.Add(new OracleParameter("P_FECHA_HASTA", OracleDbType.Date)).Value = hasta;
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("INGRESOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader reader = cmd.ExecuteReader();
                //mientras lea

                while (reader.Read())
                {
                    Ingreso i = new Ingreso();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.id_ingreso = int.Parse(reader[0].ToString());
                    i.fecha = reader[1].ToString();
                    i.hora = reader[2].ToString();
                    i.monto = "$ " + reader[3].ToString();

                    lista.Add(i);
                    contador = 1;
                }
                //Cerrar la conexión
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

        public int Total(DateTime desde, DateTime hasta)
        {
            try
            {
                int total = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();                
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_INGRESO_TOTAL";
                cmd.Parameters.Add(new OracleParameter("P_FECHA_DESDE", OracleDbType.Date)).Value = desde;
                cmd.Parameters.Add(new OracleParameter("P_FECHA_HASTA", OracleDbType.Date)).Value = hasta;
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("P_TOTAL", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se ejecuta la query
                cmd.ExecuteNonQuery();
                //tipo_user = Convert.ToInt32(CMD.Parameters["P_TIPO"].Value); --->Dio error
                //Se le entrega el resultado a la variable que es el resultado del procedure parseado
                total = int.Parse(cmd.Parameters["P_TOTAL"].Value.ToString());

                //Cerrar conexión
                conn.Close();
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

    }
}
