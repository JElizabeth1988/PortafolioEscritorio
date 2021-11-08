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
    /// <summary>
    /// Lógica de interacción para WPFListadoProducto.xaml
    /// </summary>
    public partial class WPFListadoProducto : MetroWindow
    {

        //This Origen
        WPFProducto prod;

        //Clase Producto
        Producto pr = new Producto();

        //PatronSingleton--------------------------
        private static WPFListadoProducto _instancia;

        public static WPFListadoProducto ObtnerInstanciaLIPRO()
        {
            if (_instancia == null)
            {
                _instancia = new WPFListadoProducto();
            }

            return _instancia;
        }

        //---------------------------------------

        OracleConnection conn = null;
        public WPFListadoProducto()
        {
            InitializeComponent();
            //Se instancia la conexión a la BD
            //conn = new Conexion().Getcone();

            txtFiltroID.Focus();
            btnPasar.Visibility = Visibility.Hidden;
            btnPasarAForm.Visibility = Visibility.Hidden;
            //btnFiltrarID.Visibility = Visibility.Hidden;
            btnFiltrarIDFor.Visibility = Visibility.Hidden;
            btnRefrescar2.Visibility = Visibility.Hidden;
            CargarGrilla();
        }

        //-----------------Llamado desde Adm. Productos---------------------------------
        //-----------------------------------------------------------------------
        public WPFListadoProducto(WPFProducto origen)
        {
            InitializeComponent();
            prod = origen;
            //Mostrar(Visibility) y esconder(Hidden) botones
            btnPasar.Visibility = Visibility.Visible;
            btnPasarAForm.Visibility = Visibility.Hidden;
            btnRefrescar.Visibility = Visibility.Visible;
            btnRefrescar2.Visibility = Visibility.Hidden;
            btnFiltrarID.Visibility = Visibility.Visible;
            btnFiltrarIDFor.Visibility = Visibility.Hidden;
            CargarGrilla();
        }

        //------------Cargar Grilla---------------------
        private void CargarGrilla()
        {
            try
            {
                //Trae la lista del método Listar
                dgLista.ItemsSource = pr.Listar();
                dgLista.Items.Refresh();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void btnFiltrarIDFor_Click(object sender, RoutedEventArgs e) //Revisar
        {

        }

        private async void btnFiltrarID_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarID.Visibility = Visibility.Visible;
            btnFiltrarIDFor.Visibility = Visibility.Hidden;

            try
            {
                int ID = int.Parse(txtFiltroID.Text);
                dgLista.ItemsSource = pr.Filtrar(ID);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al filtrar la Información"));
                Logger.Mensaje(ex.Message);
                CargarGrilla();
            }
        }

        private void btnPasarAForm_Click(object sender, RoutedEventArgs e) //REVISAR
        {

        }

        private async void btnPasar_Click(object sender, RoutedEventArgs e)
        {
            btnPasar.Visibility = Visibility.Visible;
            try
            {
                Producto.ListaProducto p = (Producto.ListaProducto)dgLista.SelectedItem;
                prod.txtIdProd.Text = p.id_producto.ToString();
                prod.txtNomProd.Text = p.nombre_tipo;
                prod.txtValorUnidad.Text = p.valor_unidad.ToString();
                prod.txtIdTipo.Text = p.id_tipo_producto.ToString();
                prod.txtStock.Text = p.stock.ToString();
                prod.txtValorKg.Text = p.valor_kilo.ToString();
                prod.txtValorTotal.Text = p.valor_total.ToString();
                prod.cboTipoProducto.Text = p.nombre_tipo;

                //Esconder y mostrar botones
                prod.btnModificar.Visibility = Visibility.Visible;
                prod.btnGuardar.Visibility = Visibility.Hidden;
                prod.btnEliminar.Visibility = Visibility.Visible;
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

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //-----------Botón Refrescar -------------------------------
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            btnFiltrarID.Visibility = Visibility.Visible;
            btnFiltrarIDFor.Visibility = Visibility.Hidden;
            CargarGrilla();
        }

        private void btnRefrescar3_Click(object sender, RoutedEventArgs e)
        {
            /*

            btnRefrescar.Visibility = Visibility.Hidden;
            btnPasar.Visibility = Visibility.Hidden;
            btnPasarAForm.Visibility = Visibility.Visible;
            btnFiltrarID.Visibility = Visibility.Hidden;
            btnFiltrarIDFor.Visibility = Visibility.Visible;

            CargarInforme();*/
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Parar Singleton
            _instancia = null;
        }

    }
}
