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

using Oracle.ManagedDataAccess.Client;
//using System.Data.OracleClient;

using System.Data;
//Metro
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
//Bibliotecas
using BibliotecaNegocio;


namespace Vista
{
    /// <summary>
    /// Lógica de interacción para WPFCalcularPedido.xaml
    /// </summary>
    public partial class WPFCalcularPedido : MetroWindow
    {
        //PatronSingleton--------------------------
        public static WPFCalcularPedido _instancia;
        public static WPFCalcularPedido ObtenerinstanciaPED()
        {
            if (_instancia == null)
            {
                _instancia = new WPFCalcularPedido();
            }

            return _instancia;
        }
        //----------------------------------------

        //Instanciar BD
        OracleConnection conn = null;
        //Traer clase producto
        Producto prod = new Producto();
        Bebida Beb = new Bebida();
        Temporal te = new Temporal();

        public WPFCalcularPedido()
        {
            InitializeComponent();

            txtCantidad.Text = "0";

            btnPasar.Visibility = Visibility.Hidden;

            CargarGrillaProd();
            CargarGrillaBeb();
            // CargarGrilla();
            //Cuando se guarda una mesa nueva se refresca la grilla
            NotificationCenter.Subscribe("producto_guardado", CargarGrillaProd);
            NotificationCenter.Subscribe("bebida_guardado", CargarGrillaBeb);
            NotificationCenter.Subscribe("pedido_guardado", CargarGrilla);


        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            //Parar Singleton
            _instancia = null;
        }
        //----solo números
        private void txtNumeros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }


        //---------------Cargar Grilla de Pedido
        private void CargarGrilla()
         {
             try
             {
                 // Dispatcher invoke: Permite ejecutar una acción de forma asincrónica
                 //desde un subproceso o desde otra ventana (es un método q llama a una acción)
                 //(() => { }); función anónima
                 Dispatcher.Invoke(() => {
                     dgListaPedido.ItemsSource = te.Listar();
                     dgListaPedido.Items.Refresh();
                 });
             }
             catch (Exception ex)
             {
                 Logger.Mensaje(ex.Message); throw;
             }

         }

        //---------------Cargar Grilla de Producto
        private void CargarGrillaProd()
        {
            try
            {
                // Dispatcher invoke: Permite ejecutar una acción de forma asincrónica
                //desde un subproceso o desde otra ventana (es un método q llama a una acción)
                //(() => { }); función anónima
                Dispatcher.Invoke(() =>
                {
                    dgListaProducto.ItemsSource = prod.ListarPedido();
                    dgListaProducto.Items.Refresh();
                });
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message); throw;
            }

        }


        //---------------Cargar Grilla de Bebida
        private void CargarGrillaBeb()
        {
            try
            {
                // Dispatcher invoke: Permite ejecutar una acción de forma asincrónica
                //desde un subproceso o desde otra ventana (es un método q llama a una acción)
                //(() => { }); función anónima
                Dispatcher.Invoke(() =>
                {
                    dgListaBebida.ItemsSource = Beb.ListarPedido();
                    dgListaBebida.Items.Refresh();
                });
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message); throw;
            }

        }

        //---------Botón Refrescar
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            CargarGrillaProd();
        }

        private void btnRefrescar1_Click(object sender, RoutedEventArgs e)
        {
            CargarGrillaBeb();
        }

        private void btnRefrescar2_Click(object sender, RoutedEventArgs e)
        {
            // CargarGrilla();
        }


        private async void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = await this.ShowMessageAsync("Mensaje de Confirmación: ",
                              "¿Está seguro que desea cancelar la operación? ",
                             MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
            }
        }

        private void Limpiar()
        {

            txtNomProd.Clear();
            //txtStock.Text = "0";
            txtValorUnidad.Text = "0";
            txtCantidad.Text = "0";

            btnPasar.Visibility = Visibility.Hidden;


        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void btnSelccionarProd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Producto.ListaProductoPedido i = (Producto.ListaProductoPedido)dgListaProducto.SelectedItem;

                txtNomProd.Text = i.Nombre;

                //---Medir el largo para quitar signos $ y U
                var lUnidad = (i.Valor.Length - 2);

                txtValorUnidad.Text = i.Valor.Substring(0, lUnidad);


                btnPasar.Visibility = Visibility.Visible;

            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
            }
        }

        private void btnBebida_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bebida.ListaBebidaPedido i = (Bebida.ListaBebidaPedido)dgListaBebida.SelectedItem;

                txtNomProd.Text = i.Nombre;

                //---Medir el largo para quitar signos $ y U
                var lUnidad = (i.Valor.Length - 2);
                txtValorUnidad.Text = i.Valor.Substring(0, lUnidad);



                btnPasar.Visibility = Visibility.Visible;

            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
            }
        }

        
        //----------Agregar items a la lista de pedido donde se visualizarán para posteriormente realizar el pedido
        private async void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*
                dgListaPedido.ItemsSource = null;
                DataTable dt = new DataTable();
                DataRow Renglon;
                dt.Columns.Add(new DataColumn ("NOMBRE"));
                dt.Columns.Add(new DataColumn("VALOR"));
                dt.Columns.Add(new DataColumn("CANTIDAD"));
                dt.Columns.Add(new DataColumn("TOTAL"));

                Renglon = dt.NewRow();

                int total = (int.Parse(txtValorUnidad.Text) * int.Parse(txtCantidad.Text));

                Renglon[0] = txtNomProd.Text;
                Renglon[1] = txtValorUnidad.Text;
                Renglon[2] = txtCantidad.Text;
                Renglon[3] = total;
                //Aqui simplemente le agregamos el renglon nuevo a la tabla
                dt.Rows.Add(Renglon);

                //Aqui le decimos al dataGridView que tome la tabla y la muestre              
                dgListaPedido.ItemsSource = dt.DefaultView;
                */

                string v_nombre = txtNomProd.Text;
                int v_valor = int.Parse(txtValorUnidad.Text);
                int v_cantidad = int.Parse(txtCantidad.Text);
                int v_total = (int.Parse(txtValorUnidad.Text) * int.Parse(txtCantidad.Text));

                Temporal t = new Temporal()
                {
                    nombre = v_nombre,
                    valor = v_valor,
                    cantidad = v_cantidad,
                    total = v_total
                };
                bool resp = te.Agregar(t);
                /*await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Guardado" : "No Guardado"));*/

                if (resp == true)
                {
                    txtNomProd.Clear();
                    txtCantidad.Text = "0";
                    txtValorUnidad.Clear();
                    NotificationCenter.Notify("pedido_guardado");

                }

                /*DataGridRow file = new DataGridRow();
                //dgListaPedido.ItemsSource = null;
                DataTable dt = new DataTable();

                DataRow fila = dt.NewRow();
                fila[0] = txtNomProd.Text;
                fila[1] = txtValorUnidad.Text;
                fila[2] = txtCantidad.Text;
                fila[3] = total;

                dt.Rows.Add(fila);
                dt.AcceptChanges();
               
                dgListaPedido.ItemsSource = dt.DefaultView;*/
                                
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                Logger.Mensaje(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        //--------calcular el total
        public void Calcular()
        {
            /*  int total = 0;
              int contador = 0;

              contador = dgListaPedido.Items.Count;

              for (int i = 0; i < contador; i++)
              {
                  total += int.Parse(dgListaPedido.);
              }
              */
        }


    }
}
