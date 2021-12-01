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
    //Indicar que la variable es serializable
    [Serializable]
    public class Producto
    {
        public int id_producto { get; set; }

        private string _nombre;

        public string nombre
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
                    //throw new Exception("Error, el Campo Nombre Producto es Obligatorio.");
                    err.AgregarError("- Campo Nombre Producto es Obligatorio");
                }

            }
        }


        public int cantidad_embase { get; set; }

        private string _unidad;
        public string u_medida
        {
            get { return _unidad; }
            set
            {
                if (value != string.Empty)
                {
                    _unidad = value;
                }
                else
                {
                    //throw new Exception("Error, el Campo Unidad de medida es Obligatorio.");
                    err.AgregarError("- Campo Unidad de Medida es Obligatorio");
                }
            }
        }

        private int _valor;

        public int valor_unitario
        {
            get { return _valor; }
            set
            {
                if (value != 0)
                {
                    _valor = value;
                }
                else
                {
                    //throw new Exception("Error, el Campo Valor Unidad es Obligatorio.");
                    err.AgregarError("- Campo Valor Unitario es Obligatorio");
                }
            }
        }

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
                    //throw new Exception("Error, el Campo Stock es Obligatorio.");
                    err.AgregarError("- Campo Stock es Obligatorio");
                }
            }
        }


        public int valor_total { get; set; }

        //Foranea
        public int id_tipo_producto { get; set; }

        //No es serializable
        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;
        [NonSerialized]
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        public Producto()
        {

        }

        //Crear objeto de la Bdd modelo
        [NonSerialized]
        private RSXXI_Entities bdd = new RSXXI_Entities();

        public bool Read()
        {
            try
            {
                PRODUCTO prod =
                    bdd.PRODUCTO.First(tip => tip.ID_PRODUCTO == id_producto);
                nombre = prod.NOMBRE;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }
        }

        public List<Producto> ReadAll()
        {
            try
            {
                List<Producto> lista = new List<Producto>();
                var lista_prod_bdd = bdd.PRODUCTO.ToList();
                foreach (PRODUCTO item in lista_prod_bdd)
                {
                    Producto tipo = new Producto();
                    tipo.id_producto = item.ID_PRODUCTO;
                    tipo.nombre = item.NOMBRE;
                    lista.Add(tipo);

                }
                return lista;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        //CRUD
        //------------Método Agregar-----------

        public bool AgregarProducto(Producto prod)
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
                CMD.CommandText = "SP_AGREGAR_PRODUCTO";
                //Se crea un nuevo tipo de parametro, nombre parametro, el tipo, el largo, y el valor es igual al de la clase.
                //CMD.Parameters.Add(new OracleParameter("P_ID_PROD", OracleDbType.Int32)).Value = prod.id_producto; -->Se agrega x Trigger con secuencia
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 50)).Value = prod.nombre;
                CMD.Parameters.Add(new OracleParameter("P_CANTIDAD", OracleDbType.Int32)).Value = prod.cantidad_embase;
                CMD.Parameters.Add(new OracleParameter("P_UNIDAD", OracleDbType.Varchar2, 10)).Value = prod.u_medida;
                CMD.Parameters.Add(new OracleParameter("P_VALOR", OracleDbType.Int32)).Value = prod.valor_unitario;
                CMD.Parameters.Add(new OracleParameter("P_ID_TIPO_PROD", OracleDbType.Int32)).Value = prod.id_tipo_producto;
                CMD.Parameters.Add(new OracleParameter("P_STOCK", OracleDbType.Int32)).Value = prod.stock;
                CMD.Parameters.Add(new OracleParameter("P_VALOR_TOTAL", OracleDbType.Int32)).Value = prod.valor_total;

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
            finally
            {
                conn.Close();
            }
        }

        //------------Método Actualizar------------------------------------------
        public bool Actualizar(Producto prod)
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
                CMD.CommandText = "SP_ACTUALIZAR_PRODUCTO";
                CMD.Parameters.Add(new OracleParameter("P_ID_PROD", OracleDbType.Int32)).Value = prod.id_producto;
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 50)).Value = prod.nombre;
                CMD.Parameters.Add(new OracleParameter("P_CANTIDAD", OracleDbType.Int32)).Value = prod.cantidad_embase;
                CMD.Parameters.Add(new OracleParameter("P_UNIDAD", OracleDbType.Varchar2, 10)).Value = prod.u_medida;
                CMD.Parameters.Add(new OracleParameter("P_VALOR", OracleDbType.Int32)).Value = prod.valor_unitario;
                CMD.Parameters.Add(new OracleParameter("P_ID_TIPO_PROD", OracleDbType.Int32)).Value = prod.id_tipo_producto;
                CMD.Parameters.Add(new OracleParameter("P_STOCK", OracleDbType.Int32)).Value = prod.stock;
                CMD.Parameters.Add(new OracleParameter("P_VALOR_TOTAL", OracleDbType.Int32)).Value = prod.valor_total;

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

        //------------------Método Buscar--------------
        public async void Buscar(int IdProd)
        {
            try
            {
                //Instanciar la conexión
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                List<Producto> list = new List<Producto>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_BUSCAR_PRODUCTO";
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = IdProd;
                CMD.Parameters.Add(new OracleParameter("PRODUCTOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                OracleDataReader reader = CMD.ExecuteReader();
                Producto p = null;
                while (reader.Read())//Mientras lee
                {
                    p = new Producto();

                    id_producto = int.Parse(reader[0].ToString());
                    nombre = reader[1].ToString();
                    cantidad_embase = int.Parse(reader[2].ToString());
                    u_medida = reader[3].ToString();
                    valor_unitario = int.Parse(reader[4].ToString());
                    stock = int.Parse(reader[5].ToString());
                    valor_total = int.Parse(reader[6].ToString());
                    id_tipo_producto = int.Parse(reader[7].ToString());

                    list.Add(p);

                }
                //Cerrar conexión
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                Logger.Mensaje(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }

        //---------Método Eliminar-----------------------------------------------
        public bool Eliminar(int IdProd) //Recibe ID por parametro
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
                CMD.CommandText = "SP_ELIMINAR_PRODUCTO";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = IdProd;

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

        //------------Listar Productos-------------
        //Llamo a la lista creada más abajo, porque trae nombres en vez de id y porque las variables se ven mejor en la grilla
        public List<ListaProducto> Listar()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista
                List<ListaProducto> lista = new List<ListaProducto>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_PRODUCTO";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("PRODUCTOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListaProducto P = new ListaProducto();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    P.Id = int.Parse(dr.GetValue(0).ToString());
                    P.Nombre = dr.GetValue(1).ToString();
                    P.Contenido = int.Parse(dr.GetValue(2).ToString());
                    P.Medición = dr.GetValue(3).ToString();
                    P.Valor = "$ " + dr.GetValue(4).ToString();
                    P.Stock = dr.GetValue(5).ToString() + " U";
                    P.Total = "$ " + dr.GetValue(6).ToString();
                    P.Categoria = dr.GetValue(7).ToString();

                    lista.Add(P);
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

        //------------Filtrar por ID--------------------
        public List<ListaProducto> Filtrar(string tipo)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista de Productos
                List<ListaProducto> lista = new List<ListaProducto>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRAR_TIPO_P";
                CMD.Parameters.Add(new OracleParameter("P_TIPO", OracleDbType.Varchar2)).Value = tipo;
                CMD.Parameters.Add(new OracleParameter("PRODUCTOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();

                while (reader.Read())
                {
                    ListaProducto p = new ListaProducto();

                    p.Id = int.Parse(reader[0].ToString());
                    p.Nombre = reader[1].ToString();
                    p.Contenido = int.Parse(reader[2].ToString());
                    p.Medición = reader[3].ToString();
                    p.Valor = "$ " + reader[4].ToString();
                    p.Stock = reader[5].ToString() + " U";
                    p.Total = "$ " + reader[6].ToString();
                    p.Categoria = reader[7].ToString();

                    //Agrega los valores a la lista, que luego es devuelta por el método
                    lista.Add(p);
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
        //------------Método Actualizar Stock------------------------------------------
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
                CMD.CommandText = "SP_STOCK_PRODUCTO";
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

        //Lista para mostrar nombres en vez de id (para procedimientos con Joins)
        [Serializable]
        public class ListaProducto
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public int Contenido { get; set; }
            public string Medición { get; set; }
            public string Valor { get; set; }
            public string Stock { get; set; }
            public string Total { get; set; }
            public string Categoria { get; set; }


            public ListaProducto()
            {

            }

        }

        [Serializable]
        public class ListaProducto2
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Contenido { get; set; }
            public string Valor { get; set; }
            public string Stock { get; set; }
            public string Total { get; set; }
            public string Categoria { get; set; }


            public ListaProducto2()
            {

            }

        }
        public List<ListaProducto2> Listar2()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista 
                List<ListaProducto2> lista = new List<ListaProducto2>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_PRODUCTO2";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("PRODUCTOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListaProducto2 P = new ListaProducto2();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    P.Id = int.Parse(dr.GetValue(0).ToString());
                    P.Nombre = dr.GetValue(1).ToString();
                    P.Contenido = dr.GetValue(2).ToString();
                    P.Valor = "$ " + dr.GetValue(3).ToString();
                    P.Stock = dr.GetValue(4).ToString() + " U";
                    P.Total = "$ " + dr.GetValue(5).ToString();
                    P.Categoria = dr.GetValue(6).ToString();

                    lista.Add(P);
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

        //------------Filtrar por ID--------------------
        public List<ListaProducto2> Filtrar2(string tipo)
        {
            try
            {
                int contador = 0;
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                //Lista de Productos
                List<ListaProducto2> lista = new List<ListaProducto2>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRAR_TIPO_P2";
                CMD.Parameters.Add(new OracleParameter("P_TIPO", OracleDbType.Varchar2)).Value = tipo;
                CMD.Parameters.Add(new OracleParameter("PRODUCTOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();

                while (reader.Read())
                {
                    ListaProducto2 p = new ListaProducto2();

                    p.Id = int.Parse(reader[0].ToString());
                    p.Nombre = reader[1].ToString();
                    p.Contenido = reader[2].ToString();
                    p.Valor = "$ " + reader[3].ToString();
                    p.Stock = reader[4].ToString() + " U";
                    p.Total = "$ " + reader[5].ToString();
                    p.Categoria = reader[6].ToString();

                    //Agrega los valores a la lista, que luego es devuelta por el método
                    lista.Add(p);
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

        //Lista  para mostrar nombres en vez de id (para procedimientos con Joins)
        [Serializable]
        public class ListaProductoPedido
        {            
            public string Nombre { get; set; }
            public string Valor { get; set; }
            public string Cantidad { get; set; }
            public string Stock { get; set; }

            public ListaProductoPedido()
            {

            }

        }
        //------------Listar Productos para pedidos-------------
        public List<ListaProductoPedido> ListarPedido()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista 
                List<ListaProductoPedido> lista = new List<ListaProductoPedido>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_STOCK_BAJO_PROD";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("BAJITOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListaProductoPedido P = new ListaProductoPedido();

                    //se obtiene el valor con getvalue es lo mismo pero con get                    
                    P.Nombre = dr.GetValue(0).ToString();
                    P.Stock = dr.GetValue(1).ToString() + " U";
                    P.Cantidad = dr.GetValue(2).ToString();
                    P.Valor = "$ " + dr.GetValue(3).ToString();

                    lista.Add(P);
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


    }
}