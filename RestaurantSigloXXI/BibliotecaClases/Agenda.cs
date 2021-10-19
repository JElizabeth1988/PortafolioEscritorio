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
    //Indicar que la variable es serializable (para memoria cache)
    [Serializable]
    public class Agenda
    {
        public int id_agenda { get; set; }
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public string disponibilidad { get; set; }
        public int num_mesa { get; set; }
                
        public Agenda()
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

        //*******************************************
        //*******CRUD********************************
        //----------------Método agregar----------------------
        public bool Agregar(Agenda agendita)
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
                CMD.CommandText = "SP_AGREGAR_AGENDA";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                //CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = agendita.id_agenda;
                CMD.Parameters.Add(new OracleParameter("P_FECHA", OracleDbType.Date)).Value = agendita.fecha;
                CMD.Parameters.Add(new OracleParameter("P_HORA", OracleDbType.Varchar2, 5)).Value = agendita.hora;
                CMD.Parameters.Add(new OracleParameter("P_DISPONIBILIDAD", OracleDbType.Varchar2, 15)).Value = agendita.disponibilidad;
                CMD.Parameters.Add(new OracleParameter("P_MESA", OracleDbType.Int32)).Value = agendita.num_mesa;

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
        }

        //------------Método Actualizar------------------------------------------
        public bool Actualizar(Agenda agendita)
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
                CMD.CommandText = "SP_ACTUALIZAR_AGENDA";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = agendita.id_agenda;
                CMD.Parameters.Add(new OracleParameter("P_FECHA", OracleDbType.Date)).Value = agendita.fecha;
                CMD.Parameters.Add(new OracleParameter("P_HORA", OracleDbType.Varchar2, 5)).Value = agendita.hora;
                CMD.Parameters.Add(new OracleParameter("P_DISPONIBILIDAD", OracleDbType.Varchar2, 15)).Value = agendita.disponibilidad;
                CMD.Parameters.Add(new OracleParameter("P_MESA", OracleDbType.Int32)).Value = agendita.num_mesa;

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
        public void Buscar(int id)
        {
            try
            {
                //Instanciar la conexión
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                List<Agenda> list = new List<Agenda>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_BUSCAR_AGENDA";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Varchar2, 12)).Value = id;
                CMD.Parameters.Add(new OracleParameter("AGENDAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                OracleDataReader reader = CMD.ExecuteReader();
                Agenda i = null;
                while (reader.Read())//Mientras lee
                {
                    i = new Agenda();

                    id_agenda = int.Parse(reader[0].ToString());
                    fecha = DateTime.Parse(reader[1].ToString());
                    hora = reader[2].ToString();
                    disponibilidad = reader[3].ToString();
                    num_mesa = int.Parse(reader[4].ToString());
                    
                    list.Add(i);

                }
                //Cerrar conexión
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Mensaje(ex.Message);                
            }
        }



        //---------Método Eliminar-----------------------------------------------
        public bool Eliminar(int id) //Recibe rut pot parametro
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
                CMD.CommandText = "SP_ELIMINAR_AGENDA";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Varchar2, 12)).Value = id;

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

        //------------Listar Empleados-------------
        //Llamo a la lista creada más abajo, porque trae nombres en vez de id y porque las variables se ven mejor en la grilla
        public List<ListaAgenda> Listar()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<ListaAgenda> lista = new List<ListaAgenda>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_AGENDA";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("AGENDAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaAgenda i = new ListaAgenda();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.Id = int.Parse(dr.GetValue(0).ToString());
                    i.fecha = dr.GetValue(1).ToString();
                    i.hora = dr.GetValue(2).ToString();
                    i.disponibilidad = dr.GetValue(3).ToString();
                    i.Mesa = int.Parse(dr.GetValue(4).ToString());
                    
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

        //-------Lista Agenda
        [Serializable]
        public class ListaAgenda
        {
            public int Id { get; set; }
            public string fecha { get; set; }
            public string hora { get; set; }
            public string disponibilidad { get; set; }
            public int Mesa { get; set; }

            public ListaAgenda()
            {

            }
        }
    }
}
