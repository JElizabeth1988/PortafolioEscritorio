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

//Metro
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

//Biblioteca de clases
using BibliotecaNegocio;
//Using para conexión
using Oracle.ManagedDataAccess.Client;

using System.Data;

namespace Vista
{
    public partial class WPFListadoEmpleado : MetroWindow
    {
        //This (Origen)
        WPFEmpleado emp;
        //This (Origen)
        WPFMesa mes;

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
            
            txtFiltroRut.Focus();//Cursor inicia en la casilla de filtro
                       
            //Mostrar(Visibility) y esconder(Hidden) botones
            //---Botones traspasar
            btnPasar.Visibility = Visibility.Hidden;            
            btnPasarAMesa.Visibility = Visibility.Hidden;

            //----Botones Resfrescar
            btnRefrescar.Visibility = Visibility.Visible;           
            btnRefrescarmesa.Visibility = Visibility.Hidden;

            //---Botones filtrar rut
            btnFiltrarRut.Visibility = Visibility.Visible;           
            btnFiltrarRutMesa.Visibility = Visibility.Hidden;

            //----Botones filtrar rol
            btnFiltrarRol.Visibility = Visibility.Visible;

            CargarGrilla();

            //Llenar el combobox
            foreach (TipoUsuario item in new TipoUsuario().ReadAll())
            {
                comboBoxItemTipoUser cb = new comboBoxItemTipoUser();
                cb.id_tipo_user = item.id_tipo_user;
                cb.descripcion_user = item.descripcion_user;
                cboRol.Items.Add(cb);
            }

            cboRol.SelectedIndex = 0;

        }
        //-----------------Llamado desde Adm. Empleados---------------------------------
        //-----------------------------------------------------------------------
        public WPFListadoEmpleado(WPFEmpleado origen)
        {
            InitializeComponent();
            emp = origen;
            //Mostrar(Visibility) y esconder(Hidden) botones
            //---Botones traspasar
            btnPasar.Visibility = Visibility.Visible;            
            btnPasarAMesa.Visibility = Visibility.Hidden;

            //----Botones Resfrescar
            btnRefrescar.Visibility = Visibility.Visible;           
            btnRefrescarmesa.Visibility = Visibility.Hidden;

            //---Botones filtrar rut
            btnFiltrarRut.Visibility = Visibility.Visible;           
            btnFiltrarRutMesa.Visibility = Visibility.Hidden;

            //----Botones filtrar rol
            btnFiltrarRol.Visibility = Visibility.Visible;

            CargarGrilla();

            //Llenar el combobox
            foreach (TipoUsuario item in new TipoUsuario().ReadAll())
            {
                comboBoxItemTipoUser cb = new comboBoxItemTipoUser();
                cb.id_tipo_user = item.id_tipo_user;
                cb.descripcion_user = item.descripcion_user;
                cboRol.Items.Add(cb);
            }

            cboRol.SelectedIndex = 0;
        }

        //-----------------Llamado desde Adm. Mesas---------------------------------
        //-----------------------------------------------------------------------
        public WPFListadoEmpleado(WPFMesa origen)
        {
            InitializeComponent();
            mes = origen;
            //Mostrar(Visibility) y esconder(Hidden) botones
            //----Botones traspasar
            btnPasar.Visibility = Visibility.Hidden;            
            btnPasarAMesa.Visibility = Visibility.Visible;

            //---Botones refrescar
            btnRefrescar.Visibility = Visibility.Hidden;            
            btnRefrescarmesa.Visibility = Visibility.Visible;

            //----Botones filtro rut
            btnFiltrarRut.Visibility = Visibility.Hidden;            
            btnFiltrarRutMesa.Visibility = Visibility.Visible;

            //----Botones filtro Rol
            btnFiltrarRol.Visibility = Visibility.Hidden;

            //Filtro no se ve
            lblRol.Visibility = Visibility.Hidden;
            cboRol.Visibility = Visibility.Hidden;

            CargarGrillaMesa();

            //Llenar el combobox
            foreach (TipoUsuario item in new TipoUsuario().ReadAll())
            {
                comboBoxItemTipoUser cb = new comboBoxItemTipoUser();
                cb.id_tipo_user = item.id_tipo_user;
                cb.descripcion_user = item.descripcion_user;
                cboRol.Items.Add(cb);
            }

            cboRol.SelectedIndex = 0;
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

                Logger.Mensaje(ex.Message);
            }

        }
        //------------Cargar Grillamesa---------------------
        private void CargarGrillaMesa()
        {
            try
            {
                //Trae la lista del método Listar mesa
                dgLista.ItemsSource = em.ListarMesa();
                dgLista.Items.Refresh();
            }
            catch (Exception ex)
            {

                Logger.Mensaje(ex.Message);
            }

        }

        //-----------Botón Refrescar listado empleado -------------------------------
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            //----Botones traspasar
            //btnPasar.Visibility = Visibility.Hidden;
            
            btnPasarAMesa.Visibility = Visibility.Hidden;

            //---Botones refrescar
            btnRefrescar.Visibility = Visibility.Visible;            
            btnRefrescarmesa.Visibility = Visibility.Hidden;

            //----Botones filtro rut
            btnFiltrarRut.Visibility = Visibility.Visible;           
            btnFiltrarRutMesa.Visibility = Visibility.Hidden;

            //----Botones filtro Rol
            btnFiltrarRol.Visibility = Visibility.Visible;
          

            CargarGrilla();
            txtFiltroRut.Clear();
            cboRol.SelectedIndex = 0;
        }

        //-----------Botón Refrescar mesa
        private void btnRefrescarMesa_Click(object sender, RoutedEventArgs e)
        {
            //----Botones traspasar
            btnPasar.Visibility = Visibility.Hidden;            
            btnPasarAMesa.Visibility = Visibility.Visible;

            //---Botones refrescar
            btnRefrescar.Visibility = Visibility.Hidden;            
            btnRefrescarmesa.Visibility = Visibility.Visible;

            //----Botones filtro rut
            btnFiltrarRut.Visibility = Visibility.Hidden;            
            btnFiltrarRutMesa.Visibility = Visibility.Visible;

            //----Botones filtro Rol
            btnFiltrarRol.Visibility = Visibility.Hidden;

            //Filtro no se ve
            lblRol.Visibility = Visibility.Hidden;
            cboRol.Visibility = Visibility.Hidden;

            CargarGrillaMesa();
            txtFiltroRut.Clear();
            cboRol.SelectedIndex = 0;
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

        //---------------Botón pasar a mesa
        private async void btnPasarAMesa_Click(object sender, RoutedEventArgs e)
        {
            btnPasarAMesa.Visibility = Visibility.Visible;
            try
            {
                Empleado.ListaEmpleadoMesa2 c = (Empleado.ListaEmpleadoMesa2)dgLista.SelectedItem;
                //Traspasar los datos del dataGrid a la ventana cliente
                mes.txtRut.Text = c.Rut;
                              
                mes.txtNombre.Text = c.Nombre+' '+c.Apellido_Paterno;
                mes.txtNombre.IsEnabled = false;
                
                //Esconder y mostrar botones
                //mes.btnModificar.Visibility = Visibility.Hidden;
                //mes.btnGuardar.Visibility = Visibility.Visible;
                //mes.btnEliminar.Visibility = Visibility.Visible;
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

       
        //---------------Filtro para Empleados-----------
        private async void btnFiltrarRut_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarRut.Visibility = Visibility.Visible;
            try
            {
                String rut = txtFiltroRut.Text;
                if (em.Filtrar(rut) !=null)
                {
                    dgLista.ItemsSource = em.Filtrar(rut);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Empleados:");
                    dt.Rows.Add("No existe información relacionada a su búsqueda");
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

        //Filtro por cargo
        private async void Rol_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarRut.Visibility = Visibility.Visible;
            
            try
            {
                int tipo = ((comboBoxItemTipoUser)cboRol.SelectedItem).id_tipo_user;//Guardo el id
                if (em.FiltrarRol(tipo) !=null)
                {
                    dgLista.ItemsSource = em.FiltrarRol(tipo);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Empleados:");
                    dt.Rows.Add("No existe información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    cboRol.SelectedIndex = 0;
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
        //---------------Filtro para mesa (Garzones)-----------
        private async void btnFiltrarRutmesa_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarRut.Visibility = Visibility.Visible;
            
            try
            {
                String rut = txtFiltroRut.Text;
                if (em.FiltrarMesa(rut) != null)
                {
                    dgLista.ItemsSource = em.FiltrarMesa(rut);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Empleados:");
                    dt.Rows.Add("No existe información relacionada a su búsqueda");
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
