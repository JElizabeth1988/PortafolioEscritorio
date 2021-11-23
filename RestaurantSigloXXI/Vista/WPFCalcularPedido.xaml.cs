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
        public static WPFCalcularPedido ObtenerinstanciaCP()
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
        Articulo te = new Articulo();
        PedidoProveedor ped = new PedidoProveedor();


        public WPFCalcularPedido()
        {
            InitializeComponent();

            txtCantidad.Text = "0";

            btnPasar.Visibility = Visibility.Hidden;

            lblNumero.Content = DateTime.Now.ToString("yyyyMMddHHmmss");

            //-------Cargar combobox----------------
            foreach (Proveedor item in new Proveedor().ReadAll())
            {
                comboBoxItem1 cb = new comboBoxItem1();
                cb.id = item.id_proveedor;
                cb.nombre = item.nombre;
                cbProveedor.Items.Add(cb);
            }
            cbProveedor.SelectedIndex = 0;
            cbProveedor.Focus();

            CargarGrillaProd();
            CargarGrillaBeb();
           // Total();
            // CargarGrilla();
            //Cuando se guarda una mesa nueva se refresca la grilla
            NotificationCenter.Subscribe("producto_guardado", CargarGrillaProd);
            NotificationCenter.Subscribe("bebida_guardado", CargarGrillaBeb);
            NotificationCenter.Subscribe("pedido_guardado", CargarGrilla);
            NotificationCenter.Subscribe("registro_borrado", CargarGrilla);
            NotificationCenter.Subscribe("pedido_total", Total);
                                              

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
                Dispatcher.Invoke(() =>
                {
                    string id = lblNumero.Content.ToString();
                    dgListaPedido.ItemsSource = te.Listar(id);
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
             CargarGrilla();
        }


        private async void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar id
                string id = lblNumero.Content.ToString();
               
                var x = await this.ShowMessageAsync("Cancelar Operación: ",
                         "¿Está Seguro de Cancelar la Operación? ",
                        MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                    bool resp = ped.Eliminar(id);//Entrega id por parametro
                    if (resp == true)//Si el método fue éxitoso muestra el mensaje
                    {
                        Close();
                    }
                   /* else
                    {
                        await this.ShowMessageAsync("Error:",
                          string.Format("No Cancelado"));
                    }*/
                }
                
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:",
                       string.Format("No es posible cancelar la operación"));
                Logger.Mensaje(ex.Message);
            }
        }

        

        private void btnSelccionarProd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Producto.ListaProductoPedido i = (Producto.ListaProductoPedido)dgListaProducto.SelectedItem;

                txtNomProd.Text = i.Nombre;

                //---Medir el largo para quitar signos $ y U
                var lUnidad = (i.Valor.Length - 2);

                txtValorUnidad.Text = i.Valor.Substring(2, lUnidad);

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
                txtValorUnidad.Text = i.Valor.Substring(2, lUnidad);

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
                string v_nombre = txtNomProd.Text;
                int v_valor = int.Parse(txtValorUnidad.Text);
                int v_cantidad = int.Parse(txtCantidad.Text);
                int v_total = (int.Parse(txtValorUnidad.Text) * int.Parse(txtCantidad.Text));
                string pedido = lblNumero.Content.ToString();

                Articulo t = new Articulo()
                {
                    nombre = v_nombre,
                    valor = v_valor,
                    cantidad = v_cantidad,
                    total = v_total,
                    id_pedido = pedido
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
                    NotificationCenter.Notify("pedido_total");

                }

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                Logger.Mensaje(ex.Message);
            }
        }

        private async void btnAgregar2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pedido = lblNumero.Content.ToString();
                DateTime fecha = DateTime.Now;
                int proveedor = ((comboBoxItem1)cbProveedor.SelectedItem).id;

                string v_nombre = txtNomProd.Text;
                int v_valor = int.Parse(txtValorUnidad.Text);
                int v_cantidad = int.Parse(txtCantidad.Text);
                int v_total = (int.Parse(txtValorUnidad.Text) * int.Parse(txtCantidad.Text));

                PedidoProveedor pp = new PedidoProveedor()
                {
                    id_pedido = pedido,
                    fecha_pedido = fecha,
                    id_proveedor = proveedor
                };                

                Articulo ar = new Articulo()
                {
                    nombre = v_nombre,
                    valor = v_valor,
                    cantidad = v_cantidad,
                    total = v_total
                };

                bool resp = ped.Agregar(pp,ar);
                /*await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Guardado" : "No Guardado"));*/

                if (resp == true)
                {

                    txtNomProd.Clear();
                    txtCantidad.Text = "0";
                    txtValorUnidad.Clear();
                    NotificationCenter.Notify("pedido_guardado");
                    NotificationCenter.Notify("pedido_total");

                    btnAgregar.Visibility = Visibility.Hidden;
                    btnPasar.Visibility = Visibility.Visible;

                }
                
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                Logger.Mensaje(ex.Message);
            }
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pedido = lblNumero.Content.ToString();
                int totalsin = int.Parse(lblTotal.Content.ToString());
                int proveedor = ((comboBoxItem1)cbProveedor.SelectedItem).id;

                PedidoProveedor pp = new PedidoProveedor()
                {
                    id_pedido = pedido,
                    total = totalsin,
                    id_proveedor = proveedor
                };

               
                bool resp = ped.GuardarOperacion(pp);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Guardado" : "No Guardado"));

                if (resp == true)
                {

                    txtNomProd.Clear();
                    txtCantidad.Text = "0";
                    txtValorUnidad.Clear();
                    cbProveedor.SelectedIndex = 0;
                    lblNumero.Content = DateTime.Now.ToString("yyyyMMddHHmmss");
                    CargarGrillaBeb();
                    CargarGrillaProd();
                    CargarGrilla();
                    lblTotal.Content = "";

                }

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                Logger.Mensaje(ex.Message);
            }
        }

        //--------calcular el total
        public void Total()
        {
            try
            {
                // Dispatcher invoke: Permite ejecutar una acción de forma asincrónica
                //desde un subproceso o desde otra ventana (es un método q llama a una acción)
                //(() => { }); función anónima
                Dispatcher.Invoke(() =>
                {
                    string id = lblNumero.Content.ToString();
                    
                    lblTotal.Content = te.Total(id);

                    
                });
            }
            catch (Exception ex)
            {

                Logger.Mensaje(ex.Message);
            }
        }

        private async void btnQuitar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar id
                Articulo.ListaArticulos tp = (Articulo.ListaArticulos)dgListaPedido.SelectedItem;
                int id = tp.id;


                /* var x = await this.ShowMessageAsync("Eliminar Datos: ",
                          "¿Está seguro de eliminar el registro? ",
                         MessageDialogStyle.AffirmativeAndNegative);*/
                /*if (x == MessageDialogResult.Affirmative)
                {*/
                bool resp = te.Quitar(id);//Entrega id por parametro
                if (resp == true)//Si el método fue éxitoso muestra el mensaje
                {
                    /* await this.ShowMessageAsync("Éxito:",
                       string.Format("Resgistro Eliminado"));
                     //Notificación (Actualiza la grilla en tiempo real)*/
                    NotificationCenter.Notify("registro_borrado");
                    NotificationCenter.Subscribe("pedido_total", Total);
                }
                else
                {
                    await this.ShowMessageAsync("Error:",
                      string.Format("No Eliminado"));
                }
                /* }
                 else
                 {
                     await this.ShowMessageAsync("Mensaje:",
                           string.Format("Operación Cancelada"));
                 }*/
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Seleccione un registro"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
            }
        }
        //------------Evento que oculta la primera columna (id) para que no sea modificada
        private void dgListaPedido_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (this.dgListaPedido.Columns != null)
            {
                this.dgListaPedido.Columns[0].Visibility = Visibility.Collapsed;
            }

        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Parar Singleton
            _instancia = null;
        }
    }
}
