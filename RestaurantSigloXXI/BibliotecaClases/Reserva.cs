using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BibliotecaDALC;
using Oracle.ManagedDataAccess.Client;

namespace BibliotecaNegocio
{
    public class Reserva
    {
        public int id_reserva { get; set; }
        public DateTime fecha_reserva { get; set; }
        public string hora_reserva { get; set; }
        public int cantidad_personas { get; set; }
        public string observaciones { get; set; }
        public string estado_reserva { get; set; }
        public string rut_cliente { get; set; }
        public int id_agenda { get; set; }

        public Reserva()
        {

        }
        
        //Conexión BD
        OracleConnection conn = null;

        //*********************************************************
        //----Listar reserva x codigo
        //Llamo a la lista creada más abajo, porque trae nombres en vez de id y porque las variables se ven mejor en la grilla       

        public List<ListaReserva> BuscarCodigo(int cod)
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
                List<ListaReserva> lista = new List<ListaReserva>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_VER_RESERVA_COD";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_CODE", OracleDbType.Int32)).Value = cod;
                CMD.Parameters.Add(new OracleParameter("RESERVAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaReserva c = new ListaReserva();

                    //lee cada valor en su posición
                    c.Id = int.Parse(reader[0].ToString());
                    c.rut_cliente = reader[1].ToString();
                    c.Cliente = reader[2].ToString();
                    c.Mesa = int.Parse(reader[3].ToString());
                    c.Fecha = reader[4].ToString();
                    c.Desde = reader[5].ToString();
                    c.Hasta = reader[6].ToString();
                    c.cantidad_personas = int.Parse(reader[7].ToString());
                    c.Estado = reader[8].ToString();
                    c.Observaciones = reader[9].ToString();


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
                conn.Close();
                Logger.Mensaje(ex.Message);
                return null;
                

            }
        }
        //------Listar x rut
        public List<ListaReserva> BuscarRut(string rut)
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
                List<ListaReserva> lista = new List<ListaReserva>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_VER_RESERVA_RUT";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = rut;
                CMD.Parameters.Add(new OracleParameter("RESERVAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaReserva c = new ListaReserva();

                    //lee cada valor en su posición
                    c.Id = int.Parse(reader[0].ToString());
                    c.rut_cliente = reader[1].ToString();
                    c.Cliente = reader[2].ToString();
                    c.Mesa = int.Parse(reader[3].ToString());
                    c.Fecha = reader[4].ToString();
                    c.Desde = reader[5].ToString();
                    c.Hasta = reader[6].ToString();
                    c.cantidad_personas = int.Parse(reader[7].ToString());
                    c.Estado = reader[8].ToString();
                    c.Observaciones = reader[9].ToString();


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
                conn.Close();
                Logger.Mensaje(ex.Message);
                return null;
                

            }
        }

        //------Listar
        public List<ListaReserva> Listar()
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
                List<ListaReserva> lista = new List<ListaReserva>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_VER_RESERVA";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("RESERVAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaReserva c = new ListaReserva();

                    //lee cada valor en su posición
                    c.Id = int.Parse(reader[0].ToString());
                    c.rut_cliente = reader[1].ToString();
                    c.Cliente = reader[2].ToString();
                    c.Mesa = int.Parse(reader[3].ToString());
                    c.Fecha = reader[4].ToString();
                    c.Desde = reader[5].ToString();
                    c.Hasta = reader[6].ToString();
                    c.cantidad_personas = int.Parse(reader[7].ToString());
                    c.Estado = reader[8].ToString();
                    c.Observaciones = reader[9].ToString();


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
                conn.Close();
                Logger.Mensaje(ex.Message);
                return null;
                

            }
        }
        //--Lista-------------------------
        public class ListaReserva
        {
            public int Id { get; set; }
            public string rut_cliente { get; set; }
            public string Cliente { get; set; }
            public int Mesa { get; set; }
            public string Fecha { get; set; }
            public string Desde { get; set; }
            public string Hasta { get; set; }
            public int cantidad_personas { get; set; }
            public string Estado { get; set; }
            public string Observaciones { get; set; }

            public ListaReserva()
            {

            }
        }
    }
}
