using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//DALC
using BibliotecaDALC;
//BD
using Oracle.ManagedDataAccess.Client;

namespace BibliotecaNegocio
{
    public class Atencion
    {
        public int id { get; set; }
        public string rut_cliente { get; set; }

        public int mesa { get; set; }
        public string estado { get; set; }
        public string fecha { get; set; }
        public string hora_entrada { get; set; }
        public string hora_salida { get; set; }


        public Atencion()
        {

        }
        //Objeto de la DB
        OracleConnection conn = null;

        //----------Método Notificar Entrada
        public bool Entrada(Atencion ate, Reserva res)
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
                CMD.CommandText = "SP_NOTIFICAR_LLEGADA";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = ate.rut_cliente;
                CMD.Parameters.Add(new OracleParameter("P_MESA", OracleDbType.Int32)).Value =ate.mesa;
                CMD.Parameters.Add(new OracleParameter("P_RESERVA", OracleDbType.Int32)).Value = res.id_reserva;

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

        //----------Método Notificar Salida
        public bool Salida(Atencion ate)
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
                CMD.CommandText = "SP_NOTIFICAR_SALIDA";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = ate.rut_cliente;
                CMD.Parameters.Add(new OracleParameter("P_MESA", OracleDbType.Int32)).Value = ate.mesa;

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
        //--Buscar x mesa
        public List<Atencion> Buscar(int mesa)
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
                List<Atencion> lista = new List<Atencion>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_BUSCAR_MESA_SALIDA";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_MESA", OracleDbType.Int32)).Value = mesa;
                CMD.Parameters.Add(new OracleParameter("MESAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    Atencion i = new Atencion();

                    //lee cada valor en su posición
                    i.id = int.Parse(reader[0].ToString());
                    i.rut_cliente = reader[1].ToString();
                    i.mesa = int.Parse(reader[2].ToString());
                    i.estado = reader[3].ToString();
                    i.fecha = reader[4].ToString();
                    i.hora_entrada = reader[5].ToString();
                    i.hora_salida = reader[6].ToString();

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
        //Asignar mesa
        public bool asignarMesa(Atencion ate)
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
                CMD.CommandText = "SP_ASIGNAR_MESA";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = ate.rut_cliente;
                CMD.Parameters.Add(new OracleParameter("P_MESA", OracleDbType.Int32)).Value = ate.mesa;

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

        //---------Listar mesa salida
        //--Buscar x mesa
        public List<Atencion> ListarMesa()
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
                List<Atencion> lista = new List<Atencion>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_LISTAR_MESA_SALIDA";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("MESAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    Atencion i = new Atencion();

                    //lee cada valor en su posición
                    i.id = int.Parse(reader[0].ToString());
                    i.rut_cliente = reader[1].ToString();
                    i.mesa = int.Parse(reader[2].ToString());
                    i.estado = reader[3].ToString();
                    i.fecha = reader[4].ToString();
                    i.hora_entrada = reader[5].ToString();
                    i.hora_salida = reader[6].ToString();

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

    }
}
