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
    //Indicar que la clase es serializable
    [Serializable]
    public class Receta
    {
        public int id_receta { get; set; }

        private string _nombre;
        public string nom_receta
        {
            get { return _nombre; }
            set
            {
                if (value != string.Empty)
                {
                    _nombre = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Nombre es Obligatorio");
                }
            }
        }

        private string _instrucciones;
        public string instrucciones
        {
            get { return _instrucciones; }
            set
            {
                if (value != string.Empty)
                {
                    _instrucciones = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Instrucciones es Obligatorio");
                }
            }
        }

        private string _ingredientes;
        public string Ingredientes
        {
            get { return _ingredientes; }
            set
            {
                if (value != string.Empty)
                {
                    _ingredientes = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Ingredientes es Obligatorio");
                }
            }
        }
        public int tiempo_coccion { get; set; }

        private int _tiempo;
        public int tiempo_preparacion
        {
            get { return _tiempo; }
            set
            {
                if (value != 0)
                {
                    _tiempo = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Tiempo de Preparación es Obligatorio y Debe Ser Mayor a Cero");
                }
            }
        }

        private int _total;
        public int tiempo_total
        {
            get { return _total; }
            set
            {
                if (value != 0)
                {
                    _total = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Tiempo Total es Obligatorio y Debe Ser Mayor a Cero");
                }
            }
        }

        private int _porcion;
        public int porcion
        {
            get { return _porcion; }
            set
            {
                if (value != 0)
                {
                    _porcion = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Porción es Obligatorio y Debe Ser Mayor a Cero");
                }
            }
        }

        public Receta()
        {

        }

        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;
        [NonSerialized]
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        //Crear objeto de la Bdd modelo
        [NonSerialized]
        private RSXXI_Entities bdd = new RSXXI_Entities();

        public bool Read()
        {
            try
            {
                RECETA rec =
                    bdd.RECETA.First(tip => tip.ID_RECETA == id_receta);
                nom_receta = rec.NOM_RECETA;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }
        }

        public List<Receta> ReadAll()
        {
            try
            {
                List<Receta> lista = new List<Receta>();
                var lista_receta_bdd = bdd.RECETA.ToList();
                foreach (RECETA item in lista_receta_bdd)
                {
                    Receta tipo = new Receta();
                    tipo.id_receta = item.ID_RECETA;
                    tipo.nom_receta = item.NOM_RECETA;
                    lista.Add(tipo);

                }
                return lista;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }
        }

        //----------------------------------------------
        //----CRUD--------------------------------------
        public bool Agregar(Receta recetita)
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
                CMD.CommandText = "SP_AGREGAR_RECETA";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 45)).Value = recetita.nom_receta;
                CMD.Parameters.Add(new OracleParameter("P_INSTRUCCIONES", OracleDbType.Clob)).Value = recetita.instrucciones;
                CMD.Parameters.Add(new OracleParameter("P_INGREDIENTES", OracleDbType.Clob)).Value = recetita.Ingredientes;
                if (recetita.tiempo_coccion >= 0)
                {
                    CMD.Parameters.Add(new OracleParameter("P_TIEMPO_COC", OracleDbType.Int32)).Value = recetita.tiempo_coccion;
                }
                else
                {
                    err.AgregarError("- Campo Porción es Obligatorio y Debe Ser Mayor a Cero");
                }
                if (recetita.tiempo_preparacion >0)
                {
                    CMD.Parameters.Add(new OracleParameter("P_T_PREPARACION", OracleDbType.Int32)).Value = recetita.tiempo_preparacion;
                }
                else
                {
                    err.AgregarError("- Campo Porción es Obligatorio y Debe Ser Mayor a Cero");
                }
                
                CMD.Parameters.Add(new OracleParameter("P_T_TOTAL", OracleDbType.Int32)).Value = recetita.tiempo_total;
                if (recetita.porcion >0)
                {
                    CMD.Parameters.Add(new OracleParameter("P_PORCION", OracleDbType.Int32)).Value = recetita.porcion;
                }
                else
                {
                    err.AgregarError("- Campo Porción es Obligatorio y Debe Ser Mayor a Cero");
                }
                


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

        //------------Método Actualizar------------------------------------------
        public bool Actualizar(Receta recetita)
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
                CMD.CommandText = "SP_ACTUALIZAR_RECETA";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = recetita.id_receta;
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 45)).Value = recetita.nom_receta;
                CMD.Parameters.Add(new OracleParameter("P_INSTRUCCIONES", OracleDbType.Clob)).Value = recetita.instrucciones;
                CMD.Parameters.Add(new OracleParameter("P_INGREDIENTES", OracleDbType.Clob)).Value = recetita.Ingredientes;
                CMD.Parameters.Add(new OracleParameter("P_TIEMPO_COC", OracleDbType.Int32)).Value = recetita.tiempo_coccion;
                CMD.Parameters.Add(new OracleParameter("P_T_PREPARACION", OracleDbType.Int32)).Value = recetita.tiempo_preparacion;
                CMD.Parameters.Add(new OracleParameter("P_T_TOTAL", OracleDbType.Int32)).Value = recetita.tiempo_total;
                CMD.Parameters.Add(new OracleParameter("P_PORCION", OracleDbType.Int32)).Value = recetita.porcion;

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



        //---------Método Eliminar-----------------------------------------------
        public bool Eliminar(int id) //Recibe id pot parametro
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
                CMD.CommandText = "SP_ELIMINAR_RECETA";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = id;

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

        //------------Listar Clientes-------------
        //Llamo a la lista creada más abajo, porque trae nombres en vez de id y porque las variables se ven mejor en la grilla
        public List<ListaReceta> Listar()
        {
            try
            {

                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista 
                List<ListaReceta> lista = new List<ListaReceta>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_RECETA";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("RECETAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaReceta i = new ListaReceta();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.id = int.Parse(dr.GetValue(0).ToString());
                    i.Nombre = dr.GetValue(1).ToString();
                    i.Instrucciones = dr.GetValue(2).ToString();
                    i.Ingredientes = dr.GetValue(3).ToString();
                    i.Tiempo_coccion = dr.GetValue(4).ToString() + " Minutos";
                    i.tiempo_preparacion = dr.GetValue(5).ToString() + " Minutos";
                    i.tiempo_total = dr.GetValue(6).ToString() + " Minutos";
                    i.porciones = dr.GetValue(7).ToString() + " Prociones";

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

        //----------LISTA RECETA-----------------------------------------
        [Serializable]
        public class ListaReceta
        {
            public int id { get; set; }
            public string Nombre { get; set; }
            public string Instrucciones { get; set; }
            public string Ingredientes { get; set; }
            public string Tiempo_coccion { get; set; }
            public string tiempo_preparacion { get; set; }
            public string tiempo_total { get; set; }
            public string porciones { get; set; }

            public ListaReceta()
            {

            }
        }
    }
}
