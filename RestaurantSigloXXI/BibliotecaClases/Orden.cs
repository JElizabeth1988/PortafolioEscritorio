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
        public string cliente_activo { get; set; }
        public int id_menu { get; set; }
        public string rut_empleado { get; set; }
        public int id_plato { get; set; }
        public int id_bebida { get; set; }

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
                    i.Cantidad = int.Parse(dr.GetValue(4).ToString());
                    i.Rut_Cliente = dr.GetValue(5).ToString();
                    i.Cliente = dr.GetValue(6).ToString();
                    i.Estado = dr.GetValue(7).ToString();
                    i.Menú = dr.GetValue(8).ToString();
                    i.Plato = dr.GetValue(9).ToString();
                    i.Bebida = dr.GetValue(10).ToString();
                    i.Garzón = dr.GetValue(11).ToString();
                    i.Valor = int.Parse(dr.GetValue(12).ToString());
                    i.cliente_activo = dr.GetValue(13).ToString();

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
                    i.Cantidad = int.Parse(reader[4].ToString());
                    i.Rut_Cliente = reader[5].ToString();
                    i.Cliente = reader[6].ToString();
                    i.Estado = reader[7].ToString();
                    i.Menú = reader[8].ToString();
                    i.Plato = reader[9].ToString();
                    i.Bebida = reader[10].ToString();
                    i.Garzón = reader[11].ToString();
                    i.Valor = int.Parse(reader[12].ToString());
                    i.cliente_activo = reader[13].ToString();
                    

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
        //-----------Filtro fecha----------------
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
                    i.Cantidad = int.Parse(reader[4].ToString());
                    i.Rut_Cliente = reader[5].ToString();
                    i.Cliente = reader[6].ToString();
                    i.Estado = reader[7].ToString();
                    i.Menú = reader[8].ToString();
                    i.Plato = reader[9].ToString();
                    i.Bebida = reader[10].ToString();
                    i.Garzón = reader[11].ToString();
                    i.Valor = int.Parse(reader[12].ToString());
                    i.cliente_activo = reader[13].ToString();


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

        //*********Lista**************
        public class ListaOrden
        {
            public int Id { get; set; }            
            public string Fecha { get; set; }
            public string Hora { get; set; }            
            public string Rut_Cliente { get; set; }
            public string Cliente { get; set; }
            public string cliente_activo { get; set; }
            public string Garzón { get; set; }
            public string Estado { get; set; }                   
            public string Menú { get; set; }            
            public string Plato { get; set; }
            public string Bebida { get; set; }
            public int Cantidad { get; set; }
            public int Valor { get; set; }
            public string Detalle { get; set; }

            public ListaOrden()
            {

            }                    

        }
    }
}
