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
    [Serializable]
    public class Pago
    {
        private int _n_transaccion { get; set; }
        public int n_transaccion
        {
            get { return _n_transaccion; }
            set
            {
                if (value >0)
                {
                    _n_transaccion = value;
                }
                else
                {
                    err.AgregarError("- Campo N° de Transacción es Obligatorio");
                }
            }
        }
        private int _valor_pago { get; set; }
        public int valor_pago
        {
            get { return _valor_pago; }
            set
            {
                if (value >0)
                {
                    _valor_pago = value;
                }
                else
                {
                    err.AgregarError("- Campo Valor de Pago es Obligatorio");
                }
            }
        }
        public int monto_pagado { get; set; }
        public int vuelto { get; set; }
        private string _estado_pago { get; set; }
        public string estado_pago
        {
            get { return _estado_pago; }
            set
            {
                if (value != null)
                {
                    _estado_pago = value;
                }
                else
                {
                    err.AgregarError("- Campo Estado es Obligatorio");
                }
            }
        }
        public int descuento { get; set; }
        private int _id_metodo_pago { get; set; }
        public int id_metodo_pago
        {
            get { return _id_metodo_pago; }
            set
            {
                if (value >0)
                {
                    _id_metodo_pago = value;
                }
                else
                {
                    err.AgregarError("- Campo Id Método de Pago es Obligatorio");
                }
            }
        }
        private string _rut_cliente { get; set; }
        public string rut_cliente
        {
            get { return _rut_cliente; }
            set
            {
                if (value != null)
                {
                    _rut_cliente = value;
                }
                else
                {
                    err.AgregarError("- Campo Rut de Cliente es Obligatorio");
                }
            }
        }
        private int _id_pedido { get; set; }
        public int id_pedido
        {
            get { return _id_pedido; }
            set
            {
                if (value >0)
                {
                    _id_pedido = value;
                }
                else
                {
                    err.AgregarError("- Campo Id Pedido es Obligatorio");
                }
            }
        }

        public Pago()
        {

        }

        [NonSerialized]
        OracleConnection conn = null;
        //Capturar Errores
        [NonSerialized]
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        //----------------Método agregar----------------------
        public bool Agregar(Pago paguin)
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
                CMD.CommandText = "SP_FINANZA_PAGO";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_VALOR", OracleDbType.Int32)).Value = paguin.valor_pago;
                CMD.Parameters.Add(new OracleParameter("P_MONTO", OracleDbType.Int32)).Value = paguin.monto_pagado;
                CMD.Parameters.Add(new OracleParameter("P_DESCUENTO", OracleDbType.Int32)).Value = paguin.descuento;
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 12)).Value = paguin.rut_cliente;
                CMD.Parameters.Add(new OracleParameter("P_PEDIDO", OracleDbType.Int32)).Value = paguin.id_pedido;

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

        //------------Listar pedido
        public List<ListaPedido> Listar()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista 
                List<ListaPedido> lista = new List<ListaPedido>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_PEDIDO_PAGAR";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("PEDIDOS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    ListaPedido i = new ListaPedido();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    i.id = int.Parse(dr.GetValue(0).ToString());
                    i.Fecha = dr.GetValue(1).ToString();
                    i.propina = "$ " + dr.GetValue(2).ToString();
                    i.descuento = "$ " + dr.GetValue(3).ToString();
                    i.Subtotal = "$ " + dr.GetValue(4).ToString();
                    i.Total = "$ " + dr.GetValue(5).ToString();
                    i.rut_cliente = dr.GetValue(6).ToString();
                    i.mesa = int.Parse(dr.GetValue(7).ToString());
                    i.cliente = dr.GetValue(8).ToString();
                    i.empleado = dr.GetValue(9).ToString();

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

        public class ListaPedido
        {
            public int id { get; set; }
            public int mesa { get; set; }
            public string Fecha { get; set; }
            public string propina { get; set; }
            public string descuento { get; set; }
            public string Subtotal { get; set; }
            public string Total { get; set; }
            public string rut_cliente { get; set; }
            public string cliente { get; set; }
            public string empleado { get; set; }

            public ListaPedido()
            {

            }
        }

        

    }
}
