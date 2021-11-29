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
        public string empleado { get; set; }
        public string Fecha { get; set; }
        public string hora { get; set; }
        public string pedido { get; set; }   
        public string Subtotal { get; set; }
        public string iva { get; set; }
        public string propina { get; set; }
        public string dcto { get; set; }

        public string Total { get; set; }

        public string efectivo { get; set; }
        public string vuelto { get; set; }
        public int mesa { get; set; }

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
                //Lista de clientes
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
                    Fecha = dr.GetValue(1).ToString();
                    hora = dr.GetValue(2).ToString();
                    propina = "$ " + dr.GetValue(3).ToString();
                    iva = "$ " + dr.GetValue(4).ToString();
                    Total = "$ " + dr.GetValue(5).ToString();
                    Subtotal = "$ " + dr.GetValue(6).ToString();
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
        }
    }
}
