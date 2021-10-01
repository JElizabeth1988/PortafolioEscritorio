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
    public class Cliente
    {
        //Crear objeto de la Bdd
        OracleConnection conn = null;


        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        private string _rut_cliente;

        public string rut_cliente
        {
            get { return _rut_cliente; }
            set
            {
                if (value != string.Empty && value.Length >= 9 && value.Length <= 12)
                {
                    _rut_cliente = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("Campo Rut  no puede estar Vacío");
                }

            }
        }
        private string _primer_nombre;

        public string primer_nom_cli
        {
            get { return _primer_nombre; }
            set
            {
                if (value != string.Empty)
                {
                    _primer_nombre = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("Campo Nombre no puede estar Vacío");
                }
            }
        }

        public string segundo_nom_cli { get; set; }

        private string _ap_paterno;

        public string ap_paterno_cli
        {
            get { return _ap_paterno; }
            set
            {
                if (value != string.Empty)
                {
                    _ap_paterno = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("Campo Apellido Paterno no puede estar Vacío");
                }
            }
        }

        private string _ap_materno;

        public string ap_materno_cli
        {
            get { return _ap_materno; }
            set
            {
                if (value != string.Empty)
                {
                    _ap_materno = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("Campo Apellido Materno no puede estar Vacío");
                }
            }
        }

        public int celular_cli { get; set; }

        public int telefono_cli { get; set; }
        //private int _telefono;

        /* public int telefono
         {
             get { return _telefono; }
             set {
                     if (value != 0 && value >90000000 && value <10000000)
                     {
                         _telefono = value;
                     }
                     else
                     {
                         err.AgregarError("Campo Teléfono no puede estar Vacío y debe tener un largo de 9 dígitos");
                         //throw new ArgumentException("- Campo Teléfono no puede estar Vacío y debe tener un largo de 9 dígitos");
                     }
             }
         }*/

        private string _correo_cli;
        public string correo_cli
        {
            get { return _correo_cli; }
            set
            {
                if (value != string.Empty)
                {
                    _correo_cli = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("Campo correo electrónico no puede estar Vacío");
                }
            }
        }


        public Cliente()
        {

        }

        //CRUD
        //----------------Método agregar----------------------
        public bool Agregar(Cliente client)
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
                CMD.CommandText = "SP_AGREGAR_CLIENTE";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_RUT_CLIENTE", OracleDbType.Varchar2, 12)).Value = client.rut_cliente;
                CMD.Parameters.Add(new OracleParameter("P_PRIMER_NOMBRE", OracleDbType.Varchar2, 45)).Value = client.primer_nom_cli;
                CMD.Parameters.Add(new OracleParameter("P_SEGUNDO_NOMBRE", OracleDbType.Varchar2, 45)).Value = client.segundo_nom_cli;
                CMD.Parameters.Add(new OracleParameter("P_AP_PATERNO", OracleDbType.Varchar2, 45)).Value = client.ap_paterno_cli;
                CMD.Parameters.Add(new OracleParameter("P_AP_MATERNO", OracleDbType.Varchar2, 45)).Value = client.ap_materno_cli;
                CMD.Parameters.Add(new OracleParameter("P_CELULAR", OracleDbType.Int32)).Value = client.celular_cli;
                CMD.Parameters.Add(new OracleParameter("P_TELEFONO", OracleDbType.Int32)).Value = client.telefono_cli;
                CMD.Parameters.Add(new OracleParameter("P_EMAIL", OracleDbType.Varchar2, 100)).Value = client.correo_cli;

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

                return false;
                Logger.Mensaje(ex.Message);

            }
        }

        //------------Método Actualizar------------------------------------------
        public bool Actualizar(Cliente client)
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
                CMD.CommandText = "SP_ACTUALIZAR_CLIENTE";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_RUT_CLIENTE", OracleDbType.Varchar2, 12)).Value = client.rut_cliente;
                CMD.Parameters.Add(new OracleParameter("P_PRIMER_NOMBRE", OracleDbType.Varchar2, 45)).Value = client.primer_nom_cli;
                CMD.Parameters.Add(new OracleParameter("P_SEGUNDO_NOMBRE", OracleDbType.Varchar2, 45)).Value = client.segundo_nom_cli;
                CMD.Parameters.Add(new OracleParameter("P_AP_PATERNO", OracleDbType.Varchar2, 45)).Value = client.ap_paterno_cli;
                CMD.Parameters.Add(new OracleParameter("P_AP_MATERNO", OracleDbType.Varchar2, 45)).Value = client.ap_materno_cli;
                CMD.Parameters.Add(new OracleParameter("P_CELULAR", OracleDbType.Int32)).Value = client.celular_cli;
                CMD.Parameters.Add(new OracleParameter("P_TELEFONO", OracleDbType.Int32)).Value = client.telefono_cli;
                CMD.Parameters.Add(new OracleParameter("P_EMAIL", OracleDbType.Varchar2, 100)).Value = client.correo_cli;

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

                return false;
            }
        }

        //------------------Método Buscar--------------
        public async void Buscar(String rut)
        {
            try
            {
                //Instanciar la conexión
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                List<Cliente> clie = new List<Cliente>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_BUSCAR_CLIENTE";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = rut;
                CMD.Parameters.Add(new OracleParameter("CLIENTES", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                OracleDataReader reader = CMD.ExecuteReader();
                Cliente c = null;
                while (reader.Read())//Mientras lee
                {
                    c = new BibliotecaNegocio.Cliente();

                    rut_cliente = reader[0].ToString();
                    primer_nom_cli = reader[1].ToString();
                    segundo_nom_cli = reader[2].ToString();
                    ap_paterno_cli = reader[3].ToString();
                    ap_materno_cli = reader[4].ToString();
                    celular_cli = int.Parse(reader[5].ToString());
                    telefono_cli = int.Parse(reader[6].ToString());
                    correo_cli = reader[7].ToString();


                    clie.Add(c);

                }
                //Cerrar conexión
                conn.Close();

            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
            }
        }

        //---------Método Eliminar-----------------------------------------------
        public bool Eliminar(String rut) //Recibe rut pot parametro
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
                CMD.CommandText = "SP_ELIMINAR_CLIENTE";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_RUT_CLIENTE", OracleDbType.Varchar2, 12)).Value = rut;

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

            }
        }

        //------------Listar Clientes-------------
        public List<Cliente> Listar()
        {
            try
            {
                
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<Cliente> lista = new List<Cliente>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_CLIENTE";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("CLIENTES", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    Cliente C = new Cliente();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    C.rut_cliente = dr.GetValue(0).ToString();
                    C.primer_nom_cli = dr.GetValue(1).ToString();
                    C.segundo_nom_cli = dr.GetValue(2).ToString();
                    C.ap_paterno_cli = dr.GetValue(3).ToString();
                    C._ap_materno = dr.GetValue(4).ToString();
                    C.celular_cli = int.Parse(dr.GetValue(5).ToString());
                    C.telefono_cli = int.Parse(dr.GetValue(6).ToString());
                    C.correo_cli = dr.GetValue(7).ToString();
                    
                    lista.Add(C);
                }
                //Cerrar la conexión
                conn.Close();
                return lista;

                            }
            catch (Exception ex)
            {
                return null;
                Logger.Mensaje(ex.Message);
            }
        }

        //------------Filtrar por Rut--------------------
        public List<Cliente> Filtrar(String rut)
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                OracleCommand CMD = new OracleCommand();
                //que tipo comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                List<Cliente> lista = new List<Cliente>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_FILTRAR_RUT";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = rut;
                CMD.Parameters.Add(new OracleParameter("CLIENTES", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                //Reader
                OracleDataReader reader = CMD.ExecuteReader();
                //Mientras lee
                while (reader.Read())
                {
                    Cliente c = new Cliente();

                    c.rut_cliente = reader[0].ToString();
                    c._primer_nombre = reader[1].ToString();
                    c.segundo_nom_cli = reader[2].ToString();
                    c.ap_paterno_cli = reader[3].ToString();
                    c._ap_materno = reader[4].ToString();
                    c.celular_cli = int.Parse(reader[5].ToString());
                    c.telefono_cli = int.Parse(reader[6].ToString());
                    c.correo_cli = reader[7].ToString();
                    
                    lista.Add(c);

                }
                conn.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
                Logger.Mensaje(ex.Message);
                
            }
            
        }


        //Lista Clientes
        public class ListaClientes
        {
            public string Rut { get; set; }
            public string Nombre { get; set; }
            public string Segundo_Nombre { get; set; }
            public string Apellido_paterno { get; set; }
            public string Apellido_Materno { get; set; }
            public int celular { get; set; }
            public int Teléfono { get; set; }
            public string Email { get; set; }
            

            public ListaClientes()
            {

            }
        }

    }
}
