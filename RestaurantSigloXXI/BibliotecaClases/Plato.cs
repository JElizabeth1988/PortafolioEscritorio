using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Using con DALC
using BibliotecaDALC;
//Using BD
using Oracle.ManagedDataAccess.Client;
using System.Data;

using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

namespace BibliotecaNegocio
{
    //Indicar que la clase es serializable
    [Serializable]
    public class Plato
    {
        public int id_plato { get; set; }

        private string _nombre;
        public string nom_plato
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

        private int _precio;
        public int precio_plato
        {
            get { return _precio; }
            set
            {
                if (value != 0)
                {
                    _precio = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Precio es Obligatorio y Debe Ser Mayor a Cero");
                }
            }
        }

        public string descripcion { get; set; }
        //foto
        public  byte[] foto { get; set; }

        private int _stock;
        public int stock
        {
            get { return _stock; }
            set
            {
                if (value != 0)
                {
                    _stock = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Stock es Obligatorio y Debe Ser Mayor a Cero");
                }
            }
        }
        public int id_receta { get; set; }
        public int id_categoria { get; set; }


        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;
        [NonSerialized]
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        public Plato()
        {

        }
        //************************************************************
        //***** CRUD *************************************************
        //***********************************************************
        //----------------Método agregar----------------------
        public bool Agregar(Plato platito)
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
                CMD.CommandText = "SP_AGREGAR_PLATO";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                //CMD.Parameters.Add(new OracleParameter("P_NUMERO", OracleDbType.Int32)).Value = mes.num_mesa; //seagrega x trigger                              
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 80)).Value = platito.nom_plato;
                CMD.Parameters.Add(new OracleParameter("P_PRECIO", OracleDbType.Int32)).Value = platito.precio_plato;
                CMD.Parameters.Add(new OracleParameter("P_DESCRIPCION", OracleDbType.Varchar2, 200)).Value = platito.descripcion;
                CMD.Parameters.Add(new OracleParameter("P_FOTO", OracleDbType.Blob)).Value = platito.foto;
                CMD.Parameters.Add(new OracleParameter("P_STOCK", OracleDbType.Int32)).Value = platito.stock;
                CMD.Parameters.Add(new OracleParameter("P_RECETA", OracleDbType.Int32)).Value = platito.id_receta;
                CMD.Parameters.Add(new OracleParameter("P_CATEGORIA", OracleDbType.Int32)).Value = platito.id_categoria;
                

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
                //err.AgregarError(ex.Message);
                return false;               

            }
            finally
            {
                conn.Close();
            }
        }

        //------------Método Actualizar------------------------------------------
        public bool Actualizar(Plato platito)
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
                CMD.CommandText = "SP_ACTUALIZAR_PLATO";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = platito.id_plato; //seagrega x trigger                              
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 80)).Value = platito.nom_plato;
                CMD.Parameters.Add(new OracleParameter("P_PRECIO", OracleDbType.Int32)).Value = platito.precio_plato;
                CMD.Parameters.Add(new OracleParameter("P_DESCRIPCION", OracleDbType.Varchar2, 200)).Value = platito.descripcion;
                CMD.Parameters.Add(new OracleParameter("P_FOTO", OracleDbType.Blob)).Value = platito.foto;
                CMD.Parameters.Add(new OracleParameter("P_STOCK", OracleDbType.Int32)).Value = platito.stock;
                CMD.Parameters.Add(new OracleParameter("P_RECETA", OracleDbType.Int32)).Value = platito.id_receta;
                CMD.Parameters.Add(new OracleParameter("P_CATEGORIA", OracleDbType.Int32)).Value = platito.id_categoria;

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
        public bool Eliminar(int num) //Recibe rut pot parametro
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
                CMD.CommandText = "SP_ELIMINAR_PLATO";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = num;

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

        //------------Listar---------------------------------------
        //Llamo a la lista creada más abajo, porque trae nombres en vez de id y porque las variables se ven mejor en la grilla
        public List<ListaPlato> Listar()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista 
                List<ListaPlato> lista = new List<ListaPlato>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_PLATO";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("PLATOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();

                
                //mientras lea
                while (dr.Read())
                {
                    ListaPlato i = new ListaPlato();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.Id = dr.GetInt32(0);
                    i.Nombre = dr.GetValue(1).ToString();
                    i.Precio = "$ "+dr.GetValue(2).ToString();
                    i.Descripcion = dr.GetValue(3).ToString();
                    i.Stock = dr.GetValue(4).ToString() + " U.";
                    i.Receta = dr.GetValue(5).ToString();
                    i.Categoria = dr.GetValue(6).ToString();
                    //i.Imagen = dr.GetByte(7);

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

        //------------Filtrar---------------------------------------
        public List<ListaPlato> Filtrar(String cat)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista 
                List<ListaPlato> lista = new List<ListaPlato>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_FILTRAR_PLATO";
                cmd.Parameters.Add(new OracleParameter("P_CATEGORIA", OracleDbType.Varchar2)).Value = cat;
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("PLATOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                
                //mientras lea
                while (dr.Read())
                {
                    ListaPlato i = new ListaPlato();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.Id = dr.GetInt32(0);
                    i.Nombre = dr.GetValue(1).ToString();
                    i.Precio = "$ "+dr.GetValue(2).ToString();
                    i.Descripcion = dr.GetValue(3).ToString();
                    i.Stock = dr.GetValue(4).ToString() + " U.";
                    i.Receta = dr.GetValue(5).ToString();
                    i.Categoria = dr.GetValue(6).ToString();

                    lista.Add(i);
                    contador = 1;
                }
                //Cerrar la conexión
                conn.Close();
                if (contador ==1)
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

        public byte[] verImagen(int id)
        {
            try
            {
                //int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_FOTO_PLATO";
                cmd.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = id;
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("FOTOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();

                //mientras lea
                while (dr.Read())
                {
                    Plato i = new Plato();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.foto = dr.GetValue(0) as byte[];
                    //contador = 1;                  
                }
                conn.Close();
                /* if (contador==1)
                 {
                     return 1;
                 }
                 else
                 {
                     return 0;
                 }*/
                return foto;  
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

        //------------Método Actualizar Stock ------------------------------------------
        public bool ActualizarStock(int id, int stock)
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
                CMD.CommandText = "SP_STOCK_PLATO";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = id;
                CMD.Parameters.Add(new OracleParameter("P_STOCK", OracleDbType.Int32)).Value = stock;

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

        //---------lista----------------
        [Serializable]
        public class ListaPlato
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Stock { get; set; }
            public string Precio { get; set; }
            public string Descripcion { get; set; }

            public string Receta { get; set; }
            public string Categoria { get; set; }

            //public byte[] Imagen { get; set; }

            public ListaPlato()
            {

            }
        }
    }
}
