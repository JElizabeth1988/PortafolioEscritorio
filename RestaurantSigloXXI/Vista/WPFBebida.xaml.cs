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
    public partial class WPFBebida : MetroWindow
    {
        //PatronSingleton--------------------------
        public static WPFBebida _instancia;

        public static WPFBebida ObtenerinstanciaBE()
        {
            if (_instancia == null)
            {
                _instancia = new WPFBebida();
            }

            return _instancia;
        }
        //----------------------------------------

        //Hilo para cache
        Thread hilo = null;

        //Instanciar BD
        OracleConnection conn = null;
        //Traer clase Bebida
        Bebida bebi = new Bebida();

        public WPFBebida()
        {
            InitializeComponent();
            
            txtMl.Text = "0";
            txtStock.Text = "0";
            txtValor.Text = "0";

            btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve
            btnGuardar.Visibility = Visibility.Visible;

            txtNombre.Focus();//Focus en el nombre

            //Llenar el combobox
            foreach (TipoProducto item in new TipoProducto().ReadAll())
            {
                ComboBoxItemTipoProducto cb = new ComboBoxItemTipoProducto();
                cb.id_tipo_producto = item.id_tipo_producto;
                cb.nombre_tipo = item.nombre_tipo;
                cboTipo.Items.Add(cb);
            }

            cboTipo.SelectedIndex = 0;

            CargarGrilla();
            //Cuando se guarda una bebida nueva se refresca la grilla
            NotificationCenter.Subscribe("bebida_guardada", CargarGrilla);
            NotificationCenter.Subscribe("bebida_actualizada", CargarGrilla);
            NotificationCenter.Subscribe("bebida_borrada", CargarGrilla);


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
                Bebida.ListaBebida be = new Bebida.ListaBebida();

                int id = 0;
                if (int.TryParse(lblId.Content.ToString(), out id))
                {
                    be.Id = int.Parse(lblId.Content.ToString());
                }
                if (txtNombre.Text != null)
                {
                    be.Nombre = txtNombre.Text;
                }
                int ml = 0;
                if (int.TryParse(txtMl.Text, out ml))
                {
                    be.Ml = int.Parse(txtMl.Text);
                }
                int valor = 0;
                if (int.TryParse(txtValor.Text, out valor))
                {
                    be.Valor = int.Parse(txtValor.Text);
                }
                int stock = 0;
                if (int.TryParse(txtStock.Text, out stock))
                {
                    be.Stock = int.Parse(txtStock.Text);
                }
                if (cboTipo.SelectedValue != null)
                {
                    be.Tipo = cboTipo.Text;
                }


                //Proceso de respaldo
                //Con la ampolleta agregó el using Runtime.Caching
                FileCache filecahe = new FileCache(new ObjectBinder());

                String hora = DateTime.Now.ToString("dd-MM-yy HH:mm:ss");

                filecahe["bebida"] = be;
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
                Dispatcher.Invoke(() =>
                {
                    dgLista.ItemsSource = bebi.Listar();
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
            txtMl.Clear();
            txtValor.Clear();
            txtStock.Clear();
            cboTipo.SelectedIndex = 0;
            txtMl.Text = "0";
            txtValor.Text = "0";
            txtStock.Text = "0";

            btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve
            btnGuardar.Visibility = Visibility.Visible;
            txtNombre.Focus();

            //Limpiar cache
            FileCache filecahe = new FileCache(new ObjectBinder());
            filecahe.Remove("bebida", null);
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
                int id = int.Parse(lblId.Content.ToString());
                string nombre = txtNombre.Text;
                int ml = int.Parse(txtMl.Text);
                int valor = int.Parse(txtValor.Text);
                int stock = int.Parse(txtStock.Text);
                int tipo = ((ComboBoxItemTipoProducto)cboTipo.SelectedItem).id_tipo_producto;//Guardo el id

                Bebida b = new Bebida()
                {
                    id_bebida = id,
                    nom_bebida = nombre,
                    ml_bebida = ml,
                    valor_bebida = valor,
                    stock = stock,
                    id_tipo_producto = tipo
                };
                bool resp = bebi.Actualizar(b);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Actualizado" : "No Actualizado"));
                //Notificación (Actualiza la grilla en tiempo real)
                NotificationCenter.Notify("bebida_actualizada");
                txtNombre.Focus();

                //-----------------------------------------------------------------------------------------------
                if (resp == true)
                {
                    Limpiar();
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

        //---Guardar------------------------------------------------------
        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //int id = int.Parse(txtNum.Text);
                string nombre = txtNombre.Text;
                int ml = int.Parse(txtMl.Text);
                int valor = int.Parse(txtValor.Text);
                int stock = int.Parse(txtStock.Text);
                int tipo = ((ComboBoxItemTipoProducto)cboTipo.SelectedItem).id_tipo_producto;//Guardo el id


                Bebida b = new Bebida()
                {
                    //id_bebida = id,
                    nom_bebida = nombre,
                    ml_bebida = ml,
                    valor_bebida = valor,
                    stock = stock,
                    id_tipo_producto = tipo
                };

                bool resp = bebi.Agregar(b);
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Guardado" : "No Guardado"));

                if (resp == true)
                {
                    txtNombre.Focus();

                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("bebida_guardada");
                    Limpiar();

                }

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                Logger.Mensaje(ex.Message);
            }
        }
        //---------Eliminar---------------------------------------------
        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar id
                Bebida.ListaBebida b = (Bebida.ListaBebida)dgLista.SelectedItem;
                int id = b.Id;

                var x = await this.ShowMessageAsync("Eliminar Datos: ",
                         "¿Está Seguro de eliminar? ",
                        MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                    bool resp = bebi.Eliminar(id);//Entrega id por parametro
                    if (resp == true)//Si el método fue éxitoso muestra el mensaje
                    {
                        await this.ShowMessageAsync("Éxito:",
                          string.Format("Registro Eliminado"));
                        //Notificación (Actualiza la grilla en tiempo real)
                        NotificationCenter.Notify("bebida_borrada");
                        Limpiar();
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

                if (filecahe["bebida"] != null)
                {
                    Bebida.ListaBebida b = (Bebida.ListaBebida)filecahe["bebida"];

                    lblId.Content = b.Id.ToString();
                    txtNombre.Text = b.Nombre;
                    txtMl.Text = b.Ml.ToString();
                    txtValor.Text = b.Valor.ToString();
                    txtStock.Text = b.Stock.ToString();
                    cboTipo.Text = b.Tipo;

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
                Bebida.ListaBebida b = (Bebida.ListaBebida)dgLista.SelectedItem;
                lblId.Content = b.Id.ToString();
                txtNombre.Text = b.Nombre;
                txtMl.Text = b.Ml.ToString();
                txtValor.Text = b.Valor.ToString();
                txtStock.Text = b.Stock.ToString();
                cboTipo.Text = b.Tipo;

                btnGuardar.Visibility = Visibility.Hidden;
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
