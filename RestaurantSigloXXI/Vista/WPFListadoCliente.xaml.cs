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
            
            btnFiltrarRut.Visibility = Visibility.Visible;//Se ve
            
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
            
            btnRefrescar.Visibility = Visibility.Visible;
            
            btnFiltrarRut.Visibility = Visibility.Visible;
           
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



        //-----------Botón Refrescar -------------------------------
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarRut.Visibility = Visibility.Visible;
            
            CargarGrilla();
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
        

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Parar Singleton
            _instancia = null;
        }
    }
}
