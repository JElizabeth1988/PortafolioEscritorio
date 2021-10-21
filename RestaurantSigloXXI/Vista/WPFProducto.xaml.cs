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

using Oracle.ManagedDataAccess.Client;
//using System.Data.OracleClient;

using System.Data;
//Metro
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
//Bibliotecas
using BibliotecaNegocio;


using System.Threading; //Hilos
//FileCache
using System.Runtime.Caching;

namespace Vista
{

    public partial class WPFProducto : MetroWindow
    {
        //PatronSingleton--------------------------
        public static WPFProducto _instancia;
        public static WPFProducto ObtenerinstanciaPROD()
        {
            if (_instancia == null)
            {
                _instancia = new WPFProducto();
            }

            return _instancia;
        }
        //----------------------------------------

        //Hilo para cache
        Thread hilo = null;

        //Instanciar BD
        OracleConnection conn = null;
        //Traer clase producto
        Producto prod = new Producto();

        public WPFProducto()
        {
            InitializeComponent();

            foreach (TipoProducto item in new TipoProducto().ReadAll())
            {
                ComboBoxItemTipoProducto cbtp = new ComboBoxItemTipoProducto();
                cbtp.id_tipo_producto = item.id_tipo_producto;
                cbtp.nombre_tipo = item.nombre_tipo;
                cboTipoProducto.Items.Add(cbtp);
            }

            cboTipoProducto.SelectedIndex = 0;

            foreach (TipoProducto item in new TipoProducto().ReadAll())
            {
                ComboBoxItemTipoProducto cbtp = new ComboBoxItemTipoProducto();
                cbtp.id_tipo_producto = item.id_tipo_producto;
                cbtp.nombre_tipo = item.nombre_tipo;
                cboTipFiltro.Items.Add(cbtp);
            }

            cboTipFiltro.SelectedIndex = 0;

            txtValorUnidad.Text = "0";
            txtValorTotal.Text = "0";
            txtStock.Text = "0";
            lblId.Visibility = Visibility.Hidden;//id no se ve

            btnModificar.Visibility = Visibility.Hidden;
            btnGuardar.Visibility = Visibility.Visible;

            txtNomProd.Focus();

            //---Tarea automática CACHÉ-------
            Task tarea = new Task(() =>
            {
                hilo = Thread.CurrentThread;
                while (true)
                {
                    Thread.Sleep(5000);//cada 5 segundos guarda
                    generaRespaldo();
                }
            });


            tarea.Start();

            FileCache filecache = new FileCache(new ObjectBinder());

            if (filecache["hora"] != null)
            {
                lblCache.Content = filecache["hora"].ToString();
            }

            CargarGrilla();
            //Cuando se guarda una mesa nueva se refresca la grilla
            NotificationCenter.Subscribe("producto_guardado", CargarGrilla);
            NotificationCenter.Subscribe("producto_actualizado", CargarGrilla);
            NotificationCenter.Subscribe("producto_borrado", CargarGrilla);
        }
        //---------------------------------
        //Método generar respaldo------------------

        private void generaRespaldo()
        {
            Dispatcher.Invoke(() =>
            {

                //Llama a la clase producto donde se guaradarán los datos
                Producto.ListaProducto pr = new Producto.ListaProducto();

                int Id = 0;
                if (int.TryParse(lblId.Content.ToString(), out Id))
                {
                    pr.Id = int.Parse(lblId.Content.ToString());
                }

                if (txtNomProd.Text != null)
                {
                    pr.Nombre = txtNomProd.Text;
                }
                int Valor = 0;
                if (int.TryParse(txtValorUnidad.Text, out Valor))
                {
                    pr.Valor = txtValorUnidad.Text;
                }
                int Stock = 0;
                if (int.TryParse(txtStock.Text, out Stock))
                {
                    pr.Stock = txtStock.Text;
                }
                
                int valorTotal = 0;
                if (int.TryParse(txtValorUnidad.Text, out valorTotal))
                {
                    pr.Total = txtValorTotal.Text;
                }
                if (cboTipoProducto.SelectedValue != null)
                {
                    pr.Categoria = cboTipoProducto.Text;
                }

                //Proceso de respaldo
                //Con la ampolleta agregó el using Runtime.Caching
                FileCache filecahe = new FileCache(new ObjectBinder());

                String hora = DateTime.Now.ToString("dd-MM-yy HH:mm:ss");

                filecahe["producto"] = pr;
                filecahe["hora"] = hora;

                lblCache.Content = hora;

            });
        }

        //---------Cargar Grilla----------------------------
        //----------Validación Solo acepta valores numéricos
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

        //------------Evento que oculta la primera columna (id) para que no sea modificada
        private void dgLista_LoadingRow(object sender, DataGridRowEventArgs e)
         {
             if(this.dgLista.Columns != null)
             {
                 this.dgLista.Columns[0].Visibility = Visibility.Collapsed;
             }
         }

        //---------------Cargar Grilla
        private void CargarGrilla()
        {
            try
            {
                // Dispatcher invoke: Permite ejecutar una acción de forma asincrónica
                //desde un subproceso o desde otra ventana (es un método q llama a una acción)
                //(() => { }); función anónima
                Dispatcher.Invoke(() => {
                    dgLista.ItemsSource = prod.Listar();
                    dgLista.Items.Refresh();
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
            CargarGrilla();
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
            lblId.Content = "";
            lblId.Visibility = Visibility.Hidden;
            txtNomProd.Clear();
            txtStock.Clear();
            txtValorTotal.Clear();
            txtValorUnidad.Clear();
            lblCache.Content = null;
            cboTipoProducto.SelectedIndex = 0;

            btnModificar.Visibility = Visibility.Hidden;//Botón modificar se esconde
            btnGuardar.Visibility = Visibility.Visible;//botón guardar aparece
           
            //Limpiar cache
            FileCache filecahe = new FileCache(new ObjectBinder());
            filecahe.Remove("Producto", null);

            try
            {

                lblCache.Content = "Se limpió caché";

            }
            catch (Exception ex)
            {
                lblCache.Content = "Error al limpiar";
                Logger.Mensaje(ex.Message);
            }


        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        //////CRUD Producto

        //-------Boton Guardar

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {              
              
                String nombreProducto = txtNomProd.Text;
                int Valor = int.Parse(txtValorUnidad.Text);               
                
                int Stock = int.Parse(txtStock.Text);
                /*int Stock = 0;
                if (int.TryParse(txtStock.Text, out Stock))
                {

                }
                else
                {
                    return;
                }*/
                
                int valorTotal = int.Parse(txtValorTotal.Text);
                /*int ValorTotal = 0;
                if (int.TryParse(txtValorTotal.Text, out ValorTotal))
                {

                }
                else
                {
                    return;
                }*/

                int tipo = ((ComboBoxItemTipoProducto)cboTipoProducto.SelectedItem).id_tipo_producto;

                Producto pro = new Producto()
                {                   
                    nombre = nombreProducto,
                    valor = Valor,                   
                    stock = Stock,
                    valor_total = valorTotal,
                    id_tipo_producto = tipo
                };

                bool resp = prod.AgregarProducto(pro);
                await this.ShowMessageAsync("Mensaje:",
                                            string.Format(resp ? "Guardado" : "No Guardado"));

                //MOSTRAR LISTA DE ERRORES (validación de la clase)
                if (resp == false)//If para que no muestre mensaje en blanco en caso de éxito
                {
                    DaoErrores de = prod.retornar();
                    string li = "";
                    foreach (string item in de.ListarErrores())
                    {
                        li += item + " \n";
                    }
                    await this.ShowMessageAsync("Mensaje:",
                        string.Format(li));
                }
                else
                {
                    Limpiar();
                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("producto_guardado");
                    txtNomProd.Focus();
                }
            }
            catch (ArgumentException ex)//mensajes de reglas de negocios
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format((ex.Message)));
                DaoErrores de = prod.retornar();
                string li = "";
                foreach (string item in de.ListarErrores())
                {
                    li += item + " \n";
                }
                await this.ShowMessageAsync("Mensaje:",
                    string.Format(li));
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                /*MessageBox.Show("Error de ingreso de datos");*/
                Logger.Mensaje(ex.Message);
                DaoErrores de = prod.retornar();
                string li = "";
                foreach (string item in de.ListarErrores())
                {
                    li += item + " \n";
                }
                await this.ShowMessageAsync("Mensaje:",
                    string.Format(li));
            }
        }      

        //----------Botón Actualizar
        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int IdProducto = int.Parse(lblId.Content.ToString());
                String nombreProducto = txtNomProd.Text;
                int Valor = int.Parse(txtValorUnidad.Text);
                int Stock = int.Parse(txtStock.Text);
                int ValorTotal = int.Parse(txtValorTotal.Text);
                int tipo = ((ComboBoxItemTipoProducto)cboTipoProducto.SelectedItem).id_tipo_producto;//Guardar el ID de tipo producto

                Producto pro = new Producto()
                {
                    id_producto = IdProducto,
                    nombre = nombreProducto,
                    valor = Valor,                   
                    stock = Stock,
                    valor_total = ValorTotal,
                    id_tipo_producto = tipo,
                };
                bool resp = prod.Actualizar(pro);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Actualizado" : "No Actualizado"));

                //-----------------------------------------------------------------------------------------------
                //MOSTRAR LISTA DE ERRORES
                if (resp == false)//If para que no muestre mensaje en blanco en caso de éxito
                {

                    DaoErrores de = prod.retornar();
                    string li = "";
                    foreach (string item in de.ListarErrores())
                    {
                        li += item + " \n";
                    }
                    await this.ShowMessageAsync("Mensaje:",
                        string.Format(li));
                }
                else
                {
                    Limpiar();
                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("producto_actualizado");
                    txtNomProd.Focus();
                }

            }
            catch (ArgumentException exa)//mensajes de reglas de negocios
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format((exa.Message)));
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al Actualizar Datos"));
                /*MessageBox.Show("Error al Actualizar");*/
                Logger.Mensaje(ex.Message);

            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar id
                Producto.ListaProducto m = (Producto.ListaProducto)dgLista.SelectedItem;
                int id = m.Id;

                Producto p = new Producto();

                var x = await this.ShowMessageAsync("Eliminar Datos: ",
                         "¿Está Seguro de eliminar el registro? ",
                        MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                    bool resp = prod.Eliminar(id);//Entrega id por parametro
                    if (resp == true)//Si el método fue éxitoso muestra el mensaje
                    {
                        await this.ShowMessageAsync("Éxito:",
                          string.Format("Registro Eliminado"));
                        //Notificación (Actualiza la grilla en tiempo real)
                        NotificationCenter.Notify("producto_borrado");
                        Limpiar();
                        txtNomProd.Focus();
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error:",
                          string.Format("No Eliminado"));
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                          string.Format("Operación Cancelada"));
                }
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al Eliminar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
            }
        }

        private void BtnCache_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileCache filecahe = new FileCache(new ObjectBinder());

                if (filecahe["producto"] != null)
                {
                    Producto.ListaProducto p = (Producto.ListaProducto)filecahe["producto"];

                    lblId.Content = p.Id.ToString();
                    txtNomProd.Text = p.Nombre;
                    
                    txtValorUnidad.Text = p.Valor;
                    txtValorTotal.Text = p.Total;
                    txtStock.Text = p.Stock;

                    cboTipoProducto.Text = p.Categoria;
                }
                else
                {
                    lblCache.Content = "Error al recuperar";
                    //MessageBox.Show("Error al recuperar");
                }
            }
            catch (Exception ex)
            {

                Logger.Mensaje(ex.Message);
            }
        }

        

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Terminar con la tarea caché al cerrar la ventana
            hilo.Abort();

            //Parar Singleton
            _instancia = null;
        }
        //--------Botón filtrar----------------------------------------
        private async void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tipo = cboTipFiltro.Text;
                if (prod.Filtrar(tipo) != null)
                {
                    dgLista.ItemsSource = prod.Filtrar(tipo);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("");
                    dt.Columns.Add("Productos:");
                    dt.Rows.Add("", "No existe información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    cboTipFiltro.SelectedIndex = 0;

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

        private void btnPasar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Producto.ListaProducto m = (Producto.ListaProducto)dgLista.SelectedItem;
                lblId.Content = m.Id.ToString();
                txtNomProd.Text = m.Nombre;

                //---Medir el largo para quitar signos $ y U
                var lUnidad = (m.Valor.Length - 2);
                var lTotal = (m.Total.Length - 2);
                var lStock = (m.Stock.Length - 2);

                
                txtValorUnidad.Text = m.Valor.Substring(2, lUnidad);
                txtValorTotal.Text = m.Total.Substring(2, lTotal);
                txtStock.Text = m.Stock.Substring(0, lStock);

                cboTipoProducto.Text = m.Categoria;
                               

                btnGuardar.Visibility = Visibility.Hidden;
                btnModificar.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
            }
        }

        //------Método calcular total
        public int calcular()
        {
            try
            {
                int precio = 0;
                if (txtValorUnidad.Text != null)
                {
                    precio = int.Parse(txtValorUnidad.Text);
                }
                int stock = 0;
                if (txtValorUnidad.Text != null)
                {
                    stock = int.Parse(txtStock.Text);
                }
                int total = precio * stock;
                

                return total;
                
            }
            catch (Exception ex)
            {
                return 0;
                Logger.Mensaje(ex.Message);
            }
        }
        //------Calculo del total
        private async void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtValorTotal.Text =  calcular().ToString();
                
            }
            catch (Exception ex)
            {

                Logger.Mensaje(ex.Message);
            }
        }

        
    }
}

