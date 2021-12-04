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


using System.Threading; //Hilos
//FileCache
using System.Runtime.Caching;

namespace Vista
{

    public partial class WPFStockPlato : MetroWindow
    {
        //PatronSingleton--------------------------
        public static WPFStockPlato _instancia;

        public static WPFStockPlato ObtenerinstanciaSPL()
        {
            if (_instancia == null)
            {
                _instancia = new WPFStockPlato();
            }

            return _instancia;
        }
        //----------------------------------------

        //Hilo para cache
        Thread hilo = null;

        //Traer clase Bebida
        Plato pla = new Plato();

        public WPFStockPlato()
        {
            InitializeComponent();
            txtStock.Text = "0";

            btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve

            txtNombre.Focus();//Focus en el nombre

            //filtro
            foreach (Categoria item in new Categoria().ReadAll())
            {
                comboBoxItem1 cb = new comboBoxItem1();
                cb.id = item.id_categoria;
                cb.nombre = item.nombre_cat;
                cbofiltro.Items.Add(cb);
            }

            cbofiltro.SelectedIndex = 0;

            CargarGrilla();
            //Cuando se guarda una bebida nueva se refresca la grilla

            NotificationCenter.Subscribe("plato_actualizado", CargarGrilla);


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
            //---------------------------------
        }
        //Método generar respaldo------------------
        private void generaRespaldo()
        {
            Dispatcher.Invoke(() =>
            {

                //Llama a la clase cliente donde se gusradarán los datos
                Plato.ListaPlato i = new Plato.ListaPlato();
                int id = 0;
                if (int.TryParse(lblId.Content.ToString(), out id))
                {
                    i.Id = int.Parse(lblId.Content.ToString());
                }
                if (txtNombre.Text != null)
                {
                    i.Nombre = txtNombre.Text;
                }
                
                if (txtStock.Text != null)
                {
                    i.Stock = txtStock.Text;
                }
                
                //Proceso de respaldo
                //Con la ampolleta agregó el using Runtime.Caching
                FileCache filecahe = new FileCache(new ObjectBinder());

                String hora = DateTime.Now.ToString("dd-MM-yy HH:mm:ss");


                filecahe["platoStock"] = i;
                filecahe["hora"] = hora;

                lblCache.Content = hora;

            });
        }

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
            if (this.dgLista.Columns != null)
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
                Dispatcher.Invoke(() =>
                {
                    dgLista.ItemsSource = pla.Listar();
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

        //-----------Botón Cancelar-------------------
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

        //------------Limpiar-------------------------------------------
        //----Método limpiar
        private void Limpiar()
        {
            lblId.Content = "";
            txtNombre.Clear();

            txtStock.Text = "0";

            btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve

            txtNombre.Focus();

            //Limpiar cache
            FileCache filecahe = new FileCache(new ObjectBinder());
            filecahe.Remove("platoStock", null);
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

        //----Botón limpiar
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();

        }
        //---------------------------------------------------------
        //----------CRUD-------------------------------------------
        //---------------------------------------------------------

        //--------Modificar -----------------------------------------------
        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtStock.Text != string.Empty)
                {
                    int id = int.Parse(lblId.Content.ToString());
                    int stock = 0;
                    if (txtStock.Text != string.Empty)
                    {
                        stock = int.Parse(txtStock.Text);
                    }


                    bool resp = pla.ActualizarStock(id, stock);
                    await this.ShowMessageAsync("Mensaje:",
                         string.Format(resp ? "Stock Actualizado" : "No Actualizado"));
                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("plato_actualizado");
                    txtNombre.Focus();

                    //-----------------------------------------------------------------------------------------------
                    if (resp == true)
                    {
                        Limpiar();
                    }

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                     string.Format("Campo Stock No Debe Estar Vacío"));
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


        //------Botón Filtrar x tipo
        private async void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tipo = cbofiltro.Text;
                if (pla.Filtrar(tipo) != null)
                {
                    dgLista.ItemsSource = pla.Filtrar(tipo);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("");
                    dt.Columns.Add("Platos:");
                    dt.Rows.Add("", "No existe información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    cbofiltro.SelectedIndex = 0;

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

        //--------Botón cache--------------------------
        private void BtnCache_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileCache filecahe = new FileCache(new ObjectBinder());

                if (filecahe["platoStock"] != null)
                {
                    Bebida.ListaBebida b = (Bebida.ListaBebida)filecahe["platoStock"];

                    lblId.Content = b.Id.ToString();
                    txtNombre.Text = b.Nombre;

                    txtStock.Text = b.Stock.ToString();

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

        private void btnPasar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Plato.ListaPlato b = (Plato.ListaPlato)dgLista.SelectedItem;
                lblId.Content = b.Id.ToString();
                txtNombre.Text = b.Nombre;

                var stoLargo = (b.Stock.Length - 3);
                txtStock.Text = b.Stock.Substring(0, stoLargo);

                btnModificar.Visibility = Visibility.Visible;
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
    }
}
