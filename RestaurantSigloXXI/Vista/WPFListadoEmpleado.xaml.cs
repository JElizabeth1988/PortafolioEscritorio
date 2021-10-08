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
using System.Windows.Navigation;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

using BibliotecaNegocio;


using Oracle.ManagedDataAccess.Client;

using System.Data;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para ListadoEmpleado.xaml
    /// </summary>
    public partial class WPFListadoEmpleado : MetroWindow
    {
        //This (Origen)
        WPFEmpleado emp;

        //Clase cliente
        Empleado em = new Empleado();

        //PatronSingleton--------------------------
        private static WPFListadoEmpleado _instancia;


        public static WPFListadoEmpleado ObtenerinstanciaLILIE()
        {
            if (_instancia == null)
            {
                _instancia = new WPFListadoEmpleado();
            }

            return _instancia;
        }
        //----------------------------------------

        OracleConnection conn = null;
        public WPFListadoEmpleado()
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
        //-----------------Llamado desde Adm. Empleados---------------------------------
        //-----------------------------------------------------------------------
        public WPFListadoEmpleado(WPFEmpleado origen)
        {
            InitializeComponent();
            emp = origen;
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
                dgLista.ItemsSource = em.Listar();
                dgLista.Items.Refresh();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

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

        //-----------------Botón pasar a Empleado---------------------
        private async void btnPasar_Click(object sender, RoutedEventArgs e)
        {
            btnPasar.Visibility = Visibility.Visible;
            try
            {
                emp.h2.Abort();
                emp.txtUser.IsEnabled = false;
                emp.txtPass.IsEnabled = true;
                Empleado.ListaEmpleado c = (Empleado.ListaEmpleado)dgLista.SelectedItem;
                //Traspasar los datos del dataGrid a la ventana cliente
                emp.txtRut.Text = c.Rut.Substring(0, 8);
                emp.txtDV.Text = c.Rut.Substring(9, 1);
                emp.txtRut.IsEnabled = false;//Rut no se modifica
                emp.txtDV.IsEnabled = false;//DV tampoco
                emp.txtNombre.Text = c.Nombre;
                emp.txtSegNombre.Text = c.Segundo_Nombre;
                emp.txtApPaterno.Text = c.Apellido_Paterno;
                emp.txtApeMaterno.Text = c.Apellido_Materno;
                emp.txtEmail.Text = c.Email;
                emp.txtCelular.Text = c.Celular.ToString();
                emp.txtTelefono.Text = c.Teléfono.ToString();
                emp.txtUser.Text = c.Usuario;
                emp.txtPass.Text = c.Contraseña;
                emp.cboTipoUser.Text = c.Rol;
                
                //Esconder y mostrar botones
                emp.btnModificar.Visibility = Visibility.Visible;
                emp.btnGuardar.Visibility = Visibility.Hidden;
                emp.btnEliminar.Visibility = Visibility.Visible;
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
                dgLista.ItemsSource = em.Filtrar(rut);
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
