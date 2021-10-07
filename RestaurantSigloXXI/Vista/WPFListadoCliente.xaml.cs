using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

using BibliotecaNegocio;


using Oracle.ManagedDataAccess.Client;

using System.Data;

namespace Vista
{
    
    public partial class WPFListadoCliente : MetroWindow
    {
        //This (Origen)
        WPFCliente cli;

        //Clase cliente
        Cliente cl = new Cliente();

        //PatronSingleton--------------------------
        private static WPFListadoCliente _instancia;


        public static WPFListadoCliente ObtenerinstanciaLICLI()
        {
            if (_instancia == null)
            {
                _instancia = new WPFListadoCliente();
            }

            return _instancia;
        }
        //----------------------------------------

        OracleConnection conn = null;

        public WPFListadoCliente()
        {
            InitializeComponent();
            //Se instancia la conexión a la BD
            //conn = new Conexion().Getcone();
            txtFiltroRut.Focus();//Cursor inicia en la casilla de filtro
            btnPasar.Visibility = Visibility.Hidden;//el botón traspasar no se ve
            btnPasarAForm.Visibility = Visibility.Hidden;//no se ve
            btnFiltrarRut.Visibility = Visibility.Visible;//Se ve
            btnFiltrarRutFor.Visibility = Visibility.Hidden;//No se ve
            btnRefrescar2.Visibility = Visibility.Hidden;//No se ve
            CargarGrilla();          
        }

        //-----------------Llamado desde Adm. Clientes---------------------------------
        //-----------------------------------------------------------------------
        public WPFListadoCliente(WPFCliente origen)
        {
            InitializeComponent();
            cli = origen;
            //Mostrar(Visibility) y esconder(Hidden) botones
            btnPasar.Visibility = Visibility.Visible;
            btnPasarAForm.Visibility = Visibility.Hidden;
            btnRefrescar.Visibility = Visibility.Visible;
            btnRefrescar2.Visibility = Visibility.Hidden;
            btnFiltrarRut.Visibility = Visibility.Visible;
            btnFiltrarRutFor.Visibility = Visibility.Hidden;
            CargarGrilla();
        }

        //------------Cargar Grilla---------------------
        private void CargarGrilla()
        {
            try
            {
                //Trae la lista del método Listar
                dgLista.ItemsSource = cl.Listar();
                dgLista.Items.Refresh();
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        //-----------------Llamado desde Informe---------------------------------
        //-----------------------------------------------------------------------
        //Llama solo los parámetros que necesito para el informe
        /*public ListadoCliente(FormularioInspeccion origen)
        {
            InitializeComponent();
            //Instanciar la conexión a la BD
            conn = new Conexion().Getcone();
            form = origen;
            //Ocultar (Hidden) y mostrar (Visible) botones
            btnPasarAForm.Visibility = Visibility.Visible;
            btnPasar.Visibility = Visibility.Hidden;
            btnRefrescar.Visibility = Visibility.Hidden;
            btnRefrescar2.Visibility = Visibility.Visible;
            btnFiltrarRut.Visibility = Visibility.Hidden;
            btnFiltrarRutFor.Visibility = Visibility.Visible;
            CargarInforme();            

        }

        //----------Cargar Grilla para el informe(Sólo clientes con solicitudes confirmadas y sin revisión)-----------
        private void CargarInforme()
        {
            try
            {
                int contador = 0; //Contador para que presente o no información en la grilla
                List<BibliotecaNegocio.Solicitud.ListaSolicitud> lista = new List<BibliotecaNegocio.Solicitud.ListaSolicitud>();
                //se crea un comando de oracle
                OracleCommand cmd = new OracleCommand();
                //se ejecutan los comandos de procedimientos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //conexion
                cmd.Connection = conn;
                //procedimiento
                cmd.CommandText = "SP_LISTAR_CLIENTE_INF";
                //Se agrega el parametro de salida
                cmd.Parameters.Add(new OracleParameter("CLIENTES", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                //se abre la conexion
                conn.Open();
                //se crea un reader
                OracleDataReader dr = cmd.ExecuteReader();
                //mientras lea
                while (dr.Read())
                {
                    BibliotecaNegocio.Solicitud.ListaSolicitud C = new BibliotecaNegocio.Solicitud.ListaSolicitud();

                    //se obtiene el valor con getvalue es lo mismo pero con get
                    C.Rut = dr.GetValue(0).ToString();
                    C.Nombre = dr.GetValue(1).ToString();
                    C.Direccion = dr.GetValue(2).ToString();
                    C.Constructora = dr.GetValue(3).ToString();
                    C.Fecha = DateTime.Parse(dr.GetValue(4).ToString());
                    C.id_solicitud = int.Parse(dr.GetValue(5).ToString());
                    C.Comuna = dr.GetValue(6).ToString();

                    lista.Add(C);
                    contador = 1;//Contador aumenta 1 si encontró resultados
                }
                conn.Close();
                if (contador > 0)//En caso de que el cursor traíga datos
                {
                    dgLista.ItemsSource = lista;
                    dgLista.Items.Refresh();
                    btnPasarAForm.Visibility = Visibility.Visible;
                    txtFiltroRut.IsEnabled = true;
                    btnFiltrarRutFor.Visibility = Visibility.Visible;
                }
                else
                {
                    //Mostrar texto en la Grilla
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Listado:");
                    dt.Rows.Add("No existen clientes con solicitudes confirmadas");
                    dgLista.ItemsSource = dt.DefaultView;
                    //Esconder botones que no son necesarios en caso de que no exista información
                    btnPasarAForm.Visibility = Visibility.Hidden;
                    txtFiltroRut.IsEnabled = false;
                    btnFiltrarRut.Visibility = Visibility.Hidden;
                    btnFiltrarRutFor.Visibility = Visibility.Hidden;
                }
                btnRefrescar.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

                Logger.Mensaje(ex.Message);
            }
        }*/
        

        //-----------Botón Refrescar -------------------------------
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarRut.Visibility = Visibility.Visible;
            btnFiltrarRutFor.Visibility = Visibility.Hidden;
            CargarGrilla();
        }

        //-----------Refrescar 2 (informe)---------------------------------------------------------
        private void btnRefrescar2_Click(object sender, RoutedEventArgs e)
        { /*

            btnRefrescar.Visibility = Visibility.Hidden;
            btnPasar.Visibility = Visibility.Hidden;
            btnPasarAForm.Visibility = Visibility.Visible;
            btnFiltrarRut.Visibility = Visibility.Hidden;
            btnFiltrarRutFor.Visibility = Visibility.Visible;

            CargarInforme();*/
        }
        //--------------Salir---------------------------------------
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //-----------------Botón pasar a Cliente---------------------
        private async void btnPasar_Click(object sender, RoutedEventArgs e)
        {
            btnPasar.Visibility = Visibility.Visible;
            try
            {
                BibliotecaNegocio.Cliente.ListaClientes c = (BibliotecaNegocio.Cliente.ListaClientes)dgLista.SelectedItem;
                //Traspasar los datos del dataGrid a la ventana cliente
                cli.txtRut.Text = c.Rut.Substring(0, 8);
                cli.txtDV.Text = c.Rut.Substring(9, 1);
                cli.txtRut.IsEnabled = false;//Rut no se modifica
                cli.txtDV.IsEnabled = false;//DV tampoco
                cli.txtNombre.Text = c.Nombre;
                cli.txtSegNombre.Text = c.Segundo_Nombre;
                cli.txtApPaterno.Text = c.Apellido_Paterno;
                cli.txtApeMaterno.Text = c.Apellido_Materno;
                cli.txtEmail.Text = c.Email;
                cli.txtCelular.Text = c.Celular.ToString();
                cli.txtTelefono.Text = c.Teléfono.ToString();
                //Esconder y mostrar botones
                cli.btnModificar.Visibility = Visibility.Visible;
                cli.btnGuardar.Visibility = Visibility.Hidden;
                cli.btnEliminar.Visibility = Visibility.Visible;
                //Cerrar listado
                Close();
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al traspasar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
            }
        }
       
        //---------------Botón Pasar a Formulario (Traspasa la info del cliente y solicitud al formulario)
        private async void btnPasarAForm_Click(object sender, RoutedEventArgs e)
        { /* 
            btnPasar.Visibility = Visibility.Hidden;
            btnPasarAForm.Visibility = Visibility.Visible;
            try
            {
                BibliotecaNegocio.Solicitud.ListaSolicitud cl = (BibliotecaNegocio.Solicitud.ListaSolicitud)dgLista.SelectedItem;
                string rutbuscar = form.txtRutCliente.Text;
                form.txtRutCliente.Text = cl.Rut;
                form.Buscar();
                Close();
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al traspasar la Información"));
                Logger.Mensaje(ex.Message);
            }*/
        }
        //---------------Filtro para Cliente-----------
       private async void btnFiltrarRut_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarRut.Visibility = Visibility.Visible;
            btnFiltrarRutFor.Visibility = Visibility.Hidden;
            
            try
            {
                String rut = txtFiltroRut.Text;
                dgLista.ItemsSource = cl.Filtrar(rut);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al filtrar la Información"));
                Logger.Mensaje(ex.Message);
                CargarGrilla();
            }
        }
        //Filtro Rut que sirve para informe (Clientes con solicitudes)
        private async void btnFiltrarRutFor_Click(object sender, RoutedEventArgs e)
        {
            /*btnFiltrarRut.Visibility = Visibility.Hidden;
            btnFiltrarRutFor.Visibility = Visibility.Visible;
            try
            {
                string rut = txtFiltroRut.Text;
                OracleCommand CMD = new OracleCommand();
                //que tipo de comando voy a ejecutar
                CMD.CommandType = System.Data.CommandType.StoredProcedure;

                List<BibliotecaNegocio.Solicitud.ListaSolicitud> clie = new List<BibliotecaNegocio.Solicitud.ListaSolicitud>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_BUSCAR_CLI";
                //////////se crea un nuevo de tipo parametro//P_Nombre//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 20)).Value = rut;
                CMD.Parameters.Add(new OracleParameter("INFORMES", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                OracleDataReader reader = CMD.ExecuteReader();
                BibliotecaNegocio.Solicitud.ListaSolicitud c = null;
                while (reader.Read())
                {
                    c = new BibliotecaNegocio.Solicitud.ListaSolicitud();

                    c.Rut = reader[0].ToString();
                    c.Nombre = reader[1].ToString();
                    c.Fecha = DateTime.Parse(reader[2].ToString());
                    c.id_solicitud = int.Parse(reader[3].ToString());
                    c.Direccion = reader[4].ToString();
                    c.Constructora = reader[5].ToString();
                    c.Comuna= reader[6].ToString();

                    clie.Add(c);

                }
                conn.Close();
                dgLista.ItemsSource = clie;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al filtrar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                /*Logger.Mensaje(ex.Message);

                CargarInforme();
            }*/
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Parar Singleton
            _instancia = null;
        }
    }
}
