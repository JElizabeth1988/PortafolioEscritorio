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
        WPFCliente2 cli2;
        WPFAsignarMesa asi;

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

        
        public WPFListadoCliente()
        {
            InitializeComponent();
            //Se instancia la conexión a la BD
            //conn = new Conexion().Getcone();
            txtFiltroRut.Focus();//Cursor inicia en la casilla de filtro
            btnPasar.Visibility = Visibility.Hidden;//el botón traspasar no se ve
            btnPasar2.Visibility = Visibility.Hidden;
            btnPasar3.Visibility = Visibility.Hidden;

            btnFiltrarRut.Visibility = Visibility.Visible;//Se ve
            btnFiltrarRut2.Visibility = Visibility.Hidden;//No Se ve
            btnRefrescar2.Visibility = Visibility.Hidden;//Se ve

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
            btnPasar2.Visibility = Visibility.Hidden;
            btnPasar3.Visibility = Visibility.Hidden;
            btnRefrescar.Visibility = Visibility.Visible;
            btnRefrescar2.Visibility = Visibility.Hidden;
            btnFiltrarRut.Visibility = Visibility.Visible;
            btnFiltrarRut2.Visibility = Visibility.Hidden;

            CargarGrilla();
        }

        //-----------------Llamado desde Adm. Clientes2---------------------------------
        //-----------------------------------------------------------------------
        public WPFListadoCliente(WPFCliente2 origen)
        {
            InitializeComponent();
            cli2 = origen;
            //Mostrar(Visibility) y esconder(Hidden) botones
            btnPasar2.Visibility = Visibility.Visible;
            btnPasar.Visibility = Visibility.Hidden;
            btnPasar3.Visibility = Visibility.Hidden;

            btnRefrescar.Visibility = Visibility.Hidden;
            btnRefrescar2.Visibility = Visibility.Visible;
            btnFiltrarRut.Visibility = Visibility.Hidden;
            btnFiltrarRut2.Visibility = Visibility.Visible;

            CargarGrilla2();
        }

        //-----------------Llamado desde Asignar mesa---------------------------------
        //-----------------------------------------------------------------------
        public WPFListadoCliente(WPFAsignarMesa origen)
        {
            InitializeComponent();
            asi = origen;
            //Mostrar(Visibility) y esconder(Hidden) botones
            btnPasar3.Visibility = Visibility.Visible;
            
            btnPasar2.Visibility = Visibility.Hidden;
            btnPasar.Visibility = Visibility.Hidden;
            btnRefrescar.Visibility = Visibility.Visible;
            btnRefrescar2.Visibility = Visibility.Hidden;
            btnFiltrarRut.Visibility = Visibility.Visible;
            btnFiltrarRut2.Visibility = Visibility.Hidden;

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
                Logger.Mensaje(ex.Message);
                
            }

        }

        //------------Cargar Grilla para clientes de mesas (presenciales)---------------------
        private void CargarGrilla2()
        {
            try
            {
                //Trae la lista del método Listar
                dgLista.ItemsSource = cl.ListarCli();
                dgLista.Items.Refresh();
                               

            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
            }

        }

        //-----------Botón Refrescar -------------------------------
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarRut.Visibility = Visibility.Visible;
            
            CargarGrilla();
        }
        //---Refrescar 2
        private void btnRefrescar2_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarRut.Visibility = Visibility.Visible;

            CargarGrilla2();
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
                Cliente.ListaClientes c = (Cliente.ListaClientes)dgLista.SelectedItem;
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

        //-----------------Botón pasar a Cliente mesa---------------------
        private async void btnPasar2_Click(object sender, RoutedEventArgs e)
        {
            btnPasar2.Visibility = Visibility.Visible;
            try
            {
                Cliente.ListaClientes2 c = (Cliente.ListaClientes2)dgLista.SelectedItem;
                //Traspasar los datos del dataGrid a la ventana cliente
                cli2.txtRut.Text = c.Rut.Substring(0, 8);
                cli2.txtDV.Text = c.Rut.Substring(9, 1);
                cli2.txtRut.IsEnabled = false;//Rut no se modifica
                cli2.txtDV.IsEnabled = false;//DV tampoco
                cli2.txtNombre.Text = c.Nombre;
                cli2.txtSegNombre.Text = c.Segundo_Nombre;
                cli2.txtApPaterno.Text = c.Apellido_Paterno;
                cli2.txtApeMaterno.Text = c.Apellido_Materno;
                cli2.txtEmail.Text = c.Email;
                cli2.txtCelular.Text = c.Celular.ToString();
                cli2.txtTelefono.Text = c.Teléfono.ToString();
                cli2.txtUser.Text = c.usuario;
                cli2.txtPass.Text = c.contraseña;

                if (c.activo == "Si")
                {
                    cli2.rbSi.IsChecked = true;
                }
                if (c.activo == "No")
                {
                    cli2.rbNo.IsChecked = true;
                }

                //Esconder y mostrar botones
                cli2.btnModificar.Visibility = Visibility.Visible;
                cli2.btnGuardar.Visibility = Visibility.Hidden;
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
        //Botón pasar de asignar mesa
        private async void btnPasar3_Click(object sender, RoutedEventArgs e)
        {

            btnPasar3.Visibility = Visibility.Visible;
            try
            {
                Cliente.ListaClientes c = (Cliente.ListaClientes)dgLista.SelectedItem;
                //Traspasar los datos del dataGrid a la ventana cliente
                asi.txtRut.Text = c.Rut;                
                asi.txtRut.IsEnabled = false;//Rut no se modifica                
                asi.txtNombre.Text = c.Nombre+" "+c.Apellido_Paterno;                
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


        //---------------Filtro para Cliente-----------
        private async void btnFiltrarRut_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarRut.Visibility = Visibility.Visible;
            
            try
            {
                String rut = txtFiltroRut.Text;
                if (cl.Filtrar(rut) != null)
                {
                    dgLista.ItemsSource = cl.Filtrar(rut);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Clientes:");
                    dt.Rows.Add("No Existe información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    txtFiltroRut.Clear();
                    
                }
                
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al filtrar la Información"));
                Logger.Mensaje(ex.Message);
                CargarGrilla();
            }
        }

        //---------------Filtro para Cliente mesa-----------
        private async void btnFiltrarRut2_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarRut2.Visibility = Visibility.Visible;

            try
            {
                String rut = txtFiltroRut.Text;
                if (cl.FiltrarCli(rut) != null)
                {
                    dgLista.ItemsSource = cl.FiltrarCli(rut);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Clientes:");
                    dt.Rows.Add("No Existe información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    txtFiltroRut.Clear();

                }

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al filtrar la Información"));
                Logger.Mensaje(ex.Message);
                CargarGrilla();
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Parar Singleton
            _instancia = null;
        }

        private void dgLista_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                if (this.dgLista.Columns.Count > 8)
                {
                    this.dgLista.Columns[9].Visibility = Visibility.Hidden;
                    this.dgLista.Columns[8].Visibility = Visibility.Hidden;

                }
            }
            catch (Exception ex)
            {

                Logger.Mensaje(ex.Message);
            }
            
        }
    }
}
