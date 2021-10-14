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
            btnPasarAForm.Visibility = Visibility.Hidden;
            btnPasarAMesa.Visibility = Visibility.Hidden;

            //----Botones Resfrescar
            btnRefrescar.Visibility = Visibility.Visible;
            btnRefrescar2.Visibility = Visibility.Hidden;
            btnRefrescarmesa.Visibility = Visibility.Hidden;

            //---Botones filtrar rut
            btnFiltrarRut.Visibility = Visibility.Visible;
            btnFiltrarRutFor.Visibility = Visibility.Hidden;
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
            btnPasarAForm.Visibility = Visibility.Hidden;
            btnPasarAMesa.Visibility = Visibility.Hidden;

            //----Botones Resfrescar
            btnRefrescar.Visibility = Visibility.Visible;
            btnRefrescar2.Visibility = Visibility.Hidden;
            btnRefrescarmesa.Visibility = Visibility.Hidden;

            //---Botones filtrar rut
            btnFiltrarRut.Visibility = Visibility.Visible;
            btnFiltrarRutFor.Visibility = Visibility.Hidden;
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
            btnPasarAForm.Visibility = Visibility.Hidden;
            btnPasarAMesa.Visibility = Visibility.Visible;

            //---Botones refrescar
            btnRefrescar.Visibility = Visibility.Hidden;
            btnRefrescar2.Visibility = Visibility.Hidden;
            btnRefrescarmesa.Visibility = Visibility.Visible;

            //----Botones filtro rut
            btnFiltrarRut.Visibility = Visibility.Hidden;
            btnFiltrarRutFor.Visibility = Visibility.Hidden;
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

                throw;
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

                throw;
            }

        }

        //-----------Botón Refrescar listado empleado -------------------------------
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            //----Botones traspasar
            //btnPasar.Visibility = Visibility.Hidden;
            btnPasarAForm.Visibility = Visibility.Hidden;
            btnPasarAMesa.Visibility = Visibility.Hidden;

            //---Botones refrescar
           // btnRefrescar.Visibility = Visibility.Hidden;
            btnRefrescar2.Visibility = Visibility.Hidden;
            btnRefrescarmesa.Visibility = Visibility.Visible;

            //----Botones filtro rut
            btnFiltrarRut.Visibility = Visibility.Visible;
            btnFiltrarRutFor.Visibility = Visibility.Hidden;
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
            btnPasarAForm.Visibility = Visibility.Hidden;
            btnPasarAMesa.Visibility = Visibility.Visible;

            //---Botones refrescar
            btnRefrescar.Visibility = Visibility.Hidden;
            btnRefrescar2.Visibility = Visibility.Hidden;
            btnRefrescarmesa.Visibility = Visibility.Visible;

            //----Botones filtro rut
            btnFiltrarRut.Visibility = Visibility.Hidden;
            btnFiltrarRutFor.Visibility = Visibility.Hidden;
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

        //-----------Refrescar 2 (informe)---------------------------------------------------------
        private void btnRefrescar2_Click(object sender, RoutedEventArgs e)
        {
           /* btnFiltrarRut.Visibility = Visibility.Visible;
            btnFiltrarRutFor.Visibility = Visibility.Hidden;
            CargarGrilla();
            txtFiltroRut.Clear();
            cboRol.SelectedIndex = 0;*/
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
        //---------------Filtro para Empleados-----------
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

        //Filtro por cargo
        private async void Rol_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarRut.Visibility = Visibility.Visible;
            btnFiltrarRutFor.Visibility = Visibility.Hidden;

            try
            {
                int tipo = ((comboBoxItemTipoUser)cboRol.SelectedItem).id_tipo_user;//Guardo el id
                dgLista.ItemsSource = em.FiltrarRol(tipo);
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
            btnFiltrarRutFor.Visibility = Visibility.Hidden;

            try
            {
                String rut = txtFiltroRut.Text;
                dgLista.ItemsSource = em.FiltrarMesa(rut);
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
