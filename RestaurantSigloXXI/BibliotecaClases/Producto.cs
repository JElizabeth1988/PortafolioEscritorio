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
                if (!value.Equals(""))
                {
                    _nombre = value;
                }
                else
                {
                    //throw new Exception("Error, el Campo Nombre Producto es Obligatorio.");
                    err.AgregarError("Campo Nombre Producto es Obligatorio");
                }

            }
        }

        private int _valor;

        public int valor
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
                    err.AgregarError("Campo Valor Unidad es Obligatorio");
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
                    err.AgregarError("Campo Stock es Obligatorio");
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

                return null;
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
                CMD.Parameters.Add(new OracleParameter("P_NOM_PROD", OracleDbType.Varchar2, 50)).Value = prod.nombre;
                CMD.Parameters.Add(new OracleParameter("P_VALOR_UNIDAD", OracleDbType.Int32)).Value = prod.valor;
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

                Logger.Mensaje(ex.Message);
                return false;
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
                CMD.Parameters.Add(new OracleParameter("P_NOM_PROD", OracleDbType.Varchar2, 50)).Value = prod.nombre;
                CMD.Parameters.Add(new OracleParameter("P_VALOR_UNIDAD", OracleDbType.Int32)).Value = prod.valor;
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
                Logger.Mensaje(ex.Message);
                return false;
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
                    valor = int.Parse(reader[2].ToString());
                    stock = int.Parse(reader[3].ToString());
                    valor_total = int.Parse(reader[5].ToString());
                    id_tipo_producto = int.Parse(reader[5].ToString());

                    list.Add(p);

                }
                //Cerrar conexión
                conn.Close();

            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
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

                return false;
                Logger.Mensaje(ex.Message);
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
                //Lista de clientes
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
                    P.Valor ="$ "+dr.GetValue(2).ToString();
                    P.Stock = dr.GetValue(3).ToString() +" U";
                    P.Total = "$ " + dr.GetValue(4).ToString();
                    P.Categoria = dr.GetValue(5).ToString();
                   
                    lista.Add(P);
                }
                //Cerrar la conexión
                conn.Close();
                return lista;

            }
            catch (Exception ex)
            {
                return null;
                Logger.Mensaje(ex.Message);
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
                    p.Valor = "$ " + reader[2].ToString();
                    p.Stock = reader[3].ToString()+" U";
                    p.Total = "$ " + reader[4].ToString();
                    p.Categoria = reader[5].ToString();                   

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
                return null;
                Logger.Mensaje(ex.Message);                

            }

        }


        //Lista Clientes para mostrar nombres en vez de id (para procedimientos con Joins)
        [Serializable]
        public class ListaProducto
        {
            public int Id { get; set; }
            public String Nombre { get; set; }
            public string Valor { get; set; }
            public string Stock { get; set; }
            public string Total { get; set; }
            public string Categoria { get; set; }


            public ListaProducto()
            {

            }

        }



    }
}