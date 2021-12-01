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
    public class Boleta
    {
        public string numero { get; set; }
        private string _empleado { get; set; }
        public string empleado
        {
            get { return _empleado; }
            set
            {
                if (value != null)
                {
                    _empleado = value;
                }
                else
                {
                    err.AgregarError("- Campo Empleado es Obligatorio");
                }
            }
        }
        private string _fecha { get; set; }
        public string fecha
        {
            get { return _fecha; }
            set
            {
                if (value != null)
                {
                    _fecha = value;
                }
                else
                {
                    err.AgregarError("- Campo Fecha es Obligatorio");
                }
            }
        }
        private string _hora { get; set; }
        public string hora
        {
            get { return _hora; }
            set
            {
                if (value != null)
                {
                    _hora = value;
                }
                else
                {
                    err.AgregarError("- Campo Hora es Obligatorio");
                }
            }
        }
        private string _pedido { get; set; }
        public string pedido
        {
            get { return _pedido; }
            set
            {
                if (value != null)
                {
                    _pedido = value;
                }
                else
                {
                    err.AgregarError("- Campo Pedido es Obligatorio");
                }
            }
        }
        private string _subtotal { get; set; }
        public string subtotal
        {
            get { return _subtotal; }
            set
            {
                if (value != null)
                {
                    _subtotal = value;
                }
                else
                {
                    err.AgregarError("- Campo Sub-total es Obligatorio");
                }
            }
        }
        private string _iva { get; set; }
        public string iva
        {
            get { return _iva; }
            set
            {
                if (value != null)
                {
                    _iva = value;
                }
                else
                {
                    err.AgregarError("- Campo IVA es Obligatorio");
                }
            }
        }
        public string propina { get; set; }
       
        public string dcto { get; set; }
        
        private string _total { get; set; }
        public string total
        {
            get { return _total; }
            set
            {
                if (value != null)
                {
                    _total = value;
                }
                else
                {
                    err.AgregarError("- Campo Total es Obligatorio");
                }
            }
        }

        private string _efectivo { get; set; }
        public string efectivo
        {
            get { return _efectivo; }
            set
            {
                if (value != null)
                {
                    _efectivo = value;
                }
                else
                {
                    err.AgregarError("- Campo Efectivo es Obligatorio");
                }
            }
        }
        public string vuelto { get; set; }
        
        private int _mesa { get; set; }
        public int mesa
        {
            get { return _mesa; }
            set
            {
                if (value >0)
                {
                    _mesa = value;
                }
                else
                {
                    err.AgregarError("- Campo Mesa es Obligatorio");
                }
            }
        }

        public Boleta()
        {

        }
        [NonSerialized]
        OracleConnection conn = null;
        //Capturar Errores
        [NonSerialized]
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        //------------Listar pedido
        public List<Boleta> ListarBoleta()
        {
            try
            {
                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista
                List<Boleta> lista = new List<Boleta>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_VER_BOLETA";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("BOLETAS", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                Boleta i = null;
                while (dr.Read())
                {
                    i = new Boleta();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    numero = dr.GetValue(0).ToString();
                    fecha = dr.GetValue(1).ToString();
                    hora = dr.GetValue(2).ToString();
                    propina = "$ " + dr.GetValue(3).ToString();
                    iva = "$ " + dr.GetValue(4).ToString();
                    total = "$ " + dr.GetValue(5).ToString();
                    subtotal = "$ " + dr.GetValue(6).ToString();
                    dcto = "$ " + dr.GetValue(7).ToString();
                    efectivo = "$ " + dr.GetValue(8).ToString();
                    vuelto = "$ " + dr.GetValue(9).ToString();
                    mesa = int.Parse(dr.GetValue(10).ToString());
                    empleado = dr.GetValue(11).ToString();
                    pedido = dr.GetValue(12).ToString();
                  
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
    }
}
