﻿using System;
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
    public class Proveedor
    {
        public int id_proveedor { get; set; }

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
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Nombre es Obligatorio");
                }
            }
        }

        private string _correo;
        public string correo
        {
            get { return _correo; }
            set
            {
                if (value != string.Empty)
                {
                    _correo = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Correo Electrónico es Obligatorio");
                }
            }
        }

        private int _telefono;
        public int telefono
        {
            get { return _telefono; }
            set
            {
                if (value != 0)
                {
                    _telefono = value;
                }
                else
                {
                    //throw new ArgumentException("Campo Rut no puede estar Vacío");
                    err.AgregarError("- Campo Teléfono es Obligatorio");
                }
            }
        }

        public string direccion { get; set; }
        public string sitio_web { get; set; }

        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;
        [NonSerialized]
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        
        public Proveedor()
        {

        }

        //CRUD
        //----------------Método agregar----------------------
        public bool Agregar(Proveedor proveer)
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
                CMD.CommandText = "SP_AGREGAR_PROVEEDOR";
                //////////se crea un nuevo de tipo parametro//nombre parámetro//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 45)).Value = proveer.nombre;
                CMD.Parameters.Add(new OracleParameter("P_CORREO", OracleDbType.Varchar2, 100)).Value = proveer.correo;
                CMD.Parameters.Add(new OracleParameter("P_TELEFONO", OracleDbType.Int32)).Value = proveer.telefono;
                CMD.Parameters.Add(new OracleParameter("P_DIRECCION", OracleDbType.Varchar2, 100)).Value = proveer.direccion;
                CMD.Parameters.Add(new OracleParameter("P_SITIO_WEB", OracleDbType.Varchar2, 100)).Value = proveer.sitio_web;

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

        //------------Método Actualizar------------------------------------------
        public bool Actualizar(Proveedor proveer)
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
                CMD.CommandText = "SP_ACTUALIZAR_PROVEEDOR";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// y el valor es igual al de la clase
                CMD.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32)).Value = proveer.id_proveedor;
                CMD.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2, 45)).Value = proveer.nombre;
                CMD.Parameters.Add(new OracleParameter("P_CORREO", OracleDbType.Varchar2, 100)).Value = proveer.correo;
                CMD.Parameters.Add(new OracleParameter("P_TELEFONO", OracleDbType.Int32)).Value = proveer.telefono;
                CMD.Parameters.Add(new OracleParameter("P_DIRECCION", OracleDbType.Varchar2, 100)).Value = proveer.direccion;
                CMD.Parameters.Add(new OracleParameter("P_SITIO_WEB", OracleDbType.Varchar2, 100)).Value = proveer.sitio_web;

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
            }
        }

       

        //---------Método Eliminar-----------------------------------------------
        public bool Eliminar(int id) //Recibe rut pot parametro
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
                CMD.CommandText = "SP_ELIMINAR_PROVEEDOR";
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
                return false;
                Logger.Mensaje(ex.Message);

            }
        }

        //------------Listar Clientes-------------
        //Llamo a la lista creada más abajo, porque trae nombres en vez de id y porque las variables se ven mejor en la grilla
        public List<Proveedor> Listar()
        {
            try
            {

                //Se instancia la conexión a la BD
                conn = new Conexion().Getcone();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //Lista de clientes
                List<Proveedor> lista = new List<Proveedor>();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_PROVEEDOR";
                //Se agrega el parámetro de salida
                cmd.Parameters.Add(new OracleParameter("PROVEEDORES", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    Proveedor C = new Proveedor();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    C.id_proveedor = int.Parse(dr.GetValue(0).ToString());
                    C.nombre = dr.GetValue(1).ToString();
                    C.correo = dr.GetValue(2).ToString();
                    C.telefono = int.Parse(dr.GetValue(3).ToString());
                    C.direccion = dr.GetValue(4).ToString();
                    C.sitio_web = dr.GetValue(5).ToString();


                    lista.Add(C);
                }
                //Cerrar la conexión
                conn.Close();
                return lista;

            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
                Logger.Mensaje(ex.Message);
            }
        }

        

    }
}