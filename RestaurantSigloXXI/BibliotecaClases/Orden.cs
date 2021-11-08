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
{ //Indicar que la variable es serializable
    [Serializable]
    public class Orden
    {
        public int id_orden { get; set; }
        public string detalle_orden { get; set; }
        public DateTime fecha_orden { get; set; }
        public string hora_orden { get; set; }
        public int cantidad_producto { get; set; }
        public string rut_cliente { get; set; }
        public string estado_orden { get; set; }
        public int valor_orden { get; set; }
        public string rut_empleado { get; set; }
        public int id_bebida { get; set; }
        public int id_plato { get; set; }
        public int id_pedido { get; set; }


        public Orden()
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

        //------------CRUD--------------------
        //**************************************
        //------------Listar---------------------------------------
        //Llamo a la lista creada más abajo, porque trae nombres en vez de id y porque las variables se ven mejor en la grilla
        public List<ListaOrden> Listar()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<ListaOrden> lista = new List<ListaOrden>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_PEDIDOS_LISTOS";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("PEDIDOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaOrden i = new ListaOrden();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.Id = int.Parse(dr.GetValue(0).ToString());
                    i.Detalle = dr.GetValue(1).ToString();
                    i.Fecha = dr.GetValue(2).ToString();
                    i.Hora = dr.GetValue(3).ToString();
                    i.Cantidad = dr.GetValue(4).ToString()+ " U.";
                    i.Rut_Cliente = dr.GetValue(5).ToString();
                    i.Cliente = dr.GetValue(6).ToString();
                    i.Estado = dr.GetValue(7).ToString();
                    i.Plato = dr.GetValue(8).ToString();
                    i.Bebida = dr.GetValue(9).ToString();
                    i.Garzón = dr.GetValue(10).ToString();
                    i.Valor = "$ "+dr.GetValue(11).ToString();

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
        }
        //-----------Filtro fecha----------------
        public List<ListaOrden> FiltrarFecha(string fecha)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista de Clientes
                List<ListaOrden> lista = new List<ListaOrden>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRO_FECHA";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_FECHA", OracleDbType.Varchar2)).Value = fecha;
                CMD.Parameters.Add(new OracleParameter("PEDIDOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaOrden i = new ListaOrden();

                    //lee cada valor en su posición
                    i.Id = int.Parse(reader[0].ToString());
                    i.Detalle = reader[1].ToString();
                    i.Fecha = reader[2].ToString();
                    i.Hora = reader[3].ToString();
                    i.Cantidad = reader[4].ToString()+" U.";
                    i.Rut_Cliente = reader[5].ToString();
                    i.Cliente = reader[6].ToString();
                    i.Estado = reader[7].ToString();
                    i.Plato = reader[8].ToString();
                    i.Bebida = reader[9].ToString();
                    i.Garzón = reader[10].ToString();
                    i.Valor = "$ "+reader[11].ToString();
                    

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

        }
        //-----------Filtro rut----------------
        public List<ListaOrden> FiltrarRut(string rut)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista de Clientes
                List<ListaOrden> lista = new List<ListaOrden>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRO_PEDIDO_RUT";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2)).Value = rut;
                CMD.Parameters.Add(new OracleParameter("PEDIDOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaOrden i = new ListaOrden();

                    //lee cada valor en su posición
                    i.Id = int.Parse(reader[0].ToString());
                    i.Detalle = reader[1].ToString();
                    i.Fecha = reader[2].ToString();
                    i.Hora = reader[3].ToString();
                    i.Cantidad = reader[4].ToString() + " U.";
                    i.Rut_Cliente = reader[5].ToString();
                    i.Cliente = reader[6].ToString();
                    i.Estado = reader[7].ToString();
                    i.Plato = reader[8].ToString();
                    i.Bebida = reader[9].ToString();
                    i.Garzón = reader[10].ToString();
                    i.Valor = "$ " + reader[11].ToString();


                    //Agrega los valores a la lista, que luego es devuelta por el método
                    lista.Add(i);
                    contador = 1;

                }
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

        }

        public List<ListaOrden> Listar2()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<ListaOrden> lista = new List<ListaOrden>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_ORDENES";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("ORDENES", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaOrden i = new ListaOrden();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.Id = int.Parse(dr.GetValue(0).ToString());
                    i.Detalle = dr.GetValue(1).ToString();
                    i.Fecha = dr.GetValue(2).ToString();
                    i.Hora = dr.GetValue(3).ToString();
                    i.Cantidad = dr.GetValue(4).ToString() + " U.";
                    i.Rut_Cliente = dr.GetValue(5).ToString();
                    i.Cliente = dr.GetValue(6).ToString();
                    i.Estado = dr.GetValue(7).ToString();
                    i.Plato = dr.GetValue(8).ToString();
                    i.Bebida = dr.GetValue(9).ToString();
                    i.Garzón = dr.GetValue(10).ToString();
                    i.Valor = "$ " + dr.GetValue(11).ToString();

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
        }

        //-----------Filtro fecha----------------
        public List<ListaOrden> FiltrarFecha2(string fecha)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista de Clientes
                List<ListaOrden> lista = new List<ListaOrden>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRO_FECHA2";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_FECHA", OracleDbType.Varchar2)).Value = fecha;
                CMD.Parameters.Add(new OracleParameter("PEDIDOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaOrden i = new ListaOrden();

                    //lee cada valor en su posición
                    i.Id = int.Parse(reader[0].ToString());
                    i.Detalle = reader[1].ToString();
                    i.Fecha = reader[2].ToString();
                    i.Hora = reader[3].ToString();
                    i.Cantidad = reader[4].ToString() + " U.";
                    i.Rut_Cliente = reader[5].ToString();
                    i.Cliente = reader[6].ToString();
                    i.Estado = reader[7].ToString();
                    i.Plato = reader[8].ToString();
                    i.Bebida = reader[9].ToString();
                    i.Garzón = reader[10].ToString();
                    i.Valor = "$ " + reader[11].ToString();


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

        }
        //-----------Filtro rut----------------
        public List<ListaOrden> FiltrarRut2(string rut)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista de Clientes
                List<ListaOrden> lista = new List<ListaOrden>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRO_PEDIDO_RUT2";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2)).Value = rut;
                CMD.Parameters.Add(new OracleParameter("PEDIDOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaOrden i = new ListaOrden();

                    //lee cada valor en su posición
                    i.Id = int.Parse(reader[0].ToString());
                    i.Detalle = reader[1].ToString();
                    i.Fecha = reader[2].ToString();
                    i.Hora = reader[3].ToString();
                    i.Cantidad = reader[4].ToString() + " U.";
                    i.Rut_Cliente = reader[5].ToString();
                    i.Cliente = reader[6].ToString();
                    i.Estado = reader[7].ToString();
                    i.Plato = reader[8].ToString();
                    i.Bebida = reader[9].ToString();
                    i.Garzón = reader[10].ToString();
                    i.Valor = "$ " + reader[11].ToString();


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

        }

        //----------Método Cambiar estado de orden
        public bool CambiarEstado(int id, string estado)
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
                CMD.CommandText = "SP_ESTADO_PEDIDO";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = id;
                CMD.Parameters.Add(new OracleParameter("P_ESTADO", OracleDbType.Varchar2, 50)).Value = estado;

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

        public List<ListaOrden2> ListarTablero()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<ListaOrden2> lista = new List<ListaOrden2>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_TABLERO_EJECUCION";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("ORDENES", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaOrden2 i = new ListaOrden2();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.Id = int.Parse(dr.GetValue(0).ToString());
                    i.Detalle = dr.GetValue(1).ToString();
                    i.Fecha = dr.GetValue(2).ToString();
                    i.Hora = dr.GetValue(3).ToString();
                    i.Cantidad = dr.GetValue(4).ToString() + " U.";
                    i.Rut_Cliente = dr.GetValue(5).ToString();
                    i.Cliente = dr.GetValue(6).ToString();
                    i.Estado = dr.GetValue(7).ToString();
                    i.Plato = dr.GetValue(8).ToString();
                    i.Receta = dr.GetValue(9).ToString();
                    i.tiempo_cocción = dr.GetValue(10).ToString() + " Minutos";
                    i.Bebida = dr.GetValue(11).ToString();
                    i.Garzón = dr.GetValue(12).ToString();

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
        }

        //-----------Filtro fecha----------------
        public List<ListaOrden2> FiltrarFechaTablero(string fecha)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista de Clientes
                List<ListaOrden2> lista = new List<ListaOrden2>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_TABLERO_FILTRO_FECHA";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_FECHA", OracleDbType.Varchar2)).Value = fecha;
                CMD.Parameters.Add(new OracleParameter("ORDENES", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaOrden2 i = new ListaOrden2();

                    //lee cada valor en su posición
                    i.Id = int.Parse(reader[0].ToString());
                    i.Detalle = reader[1].ToString();
                    i.Fecha = reader[2].ToString();
                    i.Hora = reader[3].ToString();
                    i.Cantidad = reader[4].ToString() + " U.";
                    i.Rut_Cliente = reader[5].ToString();
                    i.Cliente = reader[6].ToString();
                    i.Estado = reader[7].ToString();
                    i.Plato = reader[8].ToString();
                    i.Receta = reader[9].ToString();
                    i.tiempo_cocción = reader[10].ToString() + " Minutos";
                    i.Bebida = reader[11].ToString();
                    i.Garzón = reader[12].ToString();
                                        
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

        }
        //-----------Filtro rut----------------
        public List<ListaOrden2> FiltrarRutTablero(string rut)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista de Clientes
                List<ListaOrden2> lista = new List<ListaOrden2>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_TABLERO_FILTRO_RUT";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2)).Value = rut;
                CMD.Parameters.Add(new OracleParameter("ORDENES", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    ListaOrden2 i = new ListaOrden2();

                    //lee cada valor en su posición
                    i.Id = int.Parse(reader[0].ToString());
                    i.Detalle = reader[1].ToString();
                    i.Fecha = reader[2].ToString();
                    i.Hora = reader[3].ToString();
                    i.Cantidad = reader[4].ToString() + " U.";
                    i.Rut_Cliente = reader[5].ToString();
                    i.Cliente = reader[6].ToString();
                    i.Estado = reader[7].ToString();
                    i.Plato = reader[8].ToString();
                    i.Receta = reader[9].ToString();
                    i.tiempo_cocción = reader[10].ToString() + " Minutos";
                    i.Bebida = reader[11].ToString();
                    i.Garzón = reader[12].ToString();

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

        }

        //*********Lista**************
        public class ListaOrden
        {
            public int Id { get; set; }            
            public string Fecha { get; set; }
            public string Hora { get; set; }
            public string Estado { get; set; }
            public string Rut_Cliente { get; set; }
            public string Cliente { get; set; }
            public string Garzón { get; set; }
            public string Plato { get; set; }
            public string Bebida { get; set; }
            public string Cantidad { get; set; }
            public string Valor { get; set; }
            public string Detalle { get; set; }

            public ListaOrden()
            {

            }                    

        }

        //*********Lista 2 para tablero de ejecución**************
        public class ListaOrden2
        {
            public int Id { get; set; }
            public string Fecha { get; set; }
            public string Hora { get; set; }
            public string Estado { get; set; }
            public string Detalle { get; set; }
            
            public string Plato { get; set; }
            public string Receta { get; set; }
            public string tiempo_cocción { get; set; }
            public string Bebida { get; set; }
            public string Cantidad { get; set; }

            public string Garzón { get; set; }
            public string Rut_Cliente { get; set; }
            public string Cliente { get; set; }

            public ListaOrden2()
            {

            }

        }
    }
}
