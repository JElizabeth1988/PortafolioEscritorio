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
   
    public partial class WPFPlato : MetroWindow
    {
        //PatronSingleton--------------------------
        public static WPFPlato _instancia;

        public static WPFPlato ObtenerinstanciaPL()
        {
            if (_instancia == null)
            {
                _instancia = new WPFPlato();
            }

            return _instancia;
        }
        //----------------------------------------

        //Hilo para cache
        Thread hilo = null;

        //Instanciar BD
        OracleConnection conn = null;
        //Traer clase Mesa
        Plato pla = new Plato();
        
        public WPFPlato()
        {
            InitializeComponent();

            //-------Cargar combobox----------------
            foreach (Receta item in new Receta().ReadAll())
            {
                comboBoxItem1 cb = new comboBoxItem1();
                cb.id = item.id_receta;
                cb.nombre = item.nom_receta;
                cboReceta.Items.Add(cb);
            }

            foreach (Categoria item in new Categoria().ReadAll())
            {
                comboBoxItem1 cb = new comboBoxItem1();
                cb.id = item.id_categoria;
                cb.nombre = item.nombre_cat;
                cboCategoria.Items.Add(cb);
            }

            foreach (Producto item in new Producto().ReadAll())
            {
                comboBoxItem1 cb = new comboBoxItem1();
                cb.id = item.id_producto;
                cb.nombre = item.nombre_producto;
                cboProducto.Items.Add(cb);
            }
            //--------------------------------------
            cboReceta.SelectedIndex = 0;
            cboCategoria.SelectedIndex = 0;
            cboProducto.SelectedIndex = 0;
            txtNomb.Focus();

            CargarGrilla();
            //Cuando se guarda una mesa nueva se refresca la grilla
            NotificationCenter.Subscribe("plato_guardado", CargarGrilla);
            NotificationCenter.Subscribe("plato_actualizado", CargarGrilla);
            NotificationCenter.Subscribe("plato_borrado", CargarGrilla);


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
            Dispatcher.Invoke(() => {

                //Llama a la clase cliente donde se gusradarán los datos
                Plato.ListaPlato i = new Plato.ListaPlato();
                int id = 0;
                if (int.TryParse(txtNum.Text, out id))
                {
                   i.Id = int.Parse(txtNum.Text);
                }
                if (txtNomb.Text != null)
                {
                    i.Nombre = txtNomb.Text;
                }
                int precio = 0;
                if (int.TryParse(txtPrecio.Text, out precio))
                {
                    i.Precio = txtPrecio.Text;
                }
                if (txtDescripcion.Text != null)
                {
                    i.Descripcion = txtDescripcion.Text;
                }
                int tiempo = 0;
                if (int.TryParse(txtTiempo.Text, out tiempo))
                {
                    i.Tiempo_Preparación = txtTiempo.Text;
                }
                if (rb_disponible.IsChecked == true)
                {
                    i.Estado = "Disponible";
                }
                if (rb_NoDisponible.IsChecked == true)                
                {
                    i.Estado = "No Disponible";
                }
                if (cboReceta.SelectedValue != null)
                {
                   i.Receta = cboReceta.Text;
                }
                if (cboCategoria.SelectedValue != null)
                {
                    i.Categoria = cboCategoria.Text;
                }
                if (cboProducto.SelectedValue != null)
                {
                    i.Producto = cboProducto.Text;
                }

                //Proceso de respaldo
                //Con la ampolleta agregó el using Runtime.Caching
                FileCache filecahe = new FileCache(new ObjectBinder());

                String hora = DateTime.Now.ToString("dd-MM-yy HH:mm:ss");

                filecahe["plato"] = i;
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
                Dispatcher.Invoke(() => {
                    dgLista.ItemsSource = pla.Listar();
                    dgLista.Items.Refresh();
                });
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message); throw;
            }

        }

        //**********Botones****************************************
        //*********************************************************

        //---------Botón Refrescar
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
        }
        //-------Metodo limpiar-------------------
        public void Limpiar()
        {
            txtNum.Clear();
            txtNomb.Clear();
            txtPrecio.Clear();
            txtDescripcion.Clear();
            txtTiempo.Clear();
            rb_disponible.IsChecked = true;
            rb_NoDisponible.IsChecked = false;
            cboReceta.SelectedIndex = 0;
            cboCategoria.SelectedIndex = 0;
            cboProducto.SelectedIndex = 0;
            txtNomb.Focus();

            btnGuardar.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Hidden;

            //Limpiar cache
            FileCache filecahe = new FileCache(new ObjectBinder());
            filecahe.Remove("plato", null);
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
        //------Botón limpiar
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        //----------Botón Guardar-----------------------------------
        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombre = txtNomb.Text;
                int precio = int.Parse(txtPrecio.Text);
                string desc = txtDescripcion.Text;
                int tiempo = int.Parse(txtTiempo.Text);
                string estado = null;
                if (rb_disponible.IsChecked == true)
                {
                    estado = "Disponible";
                }
                if (rb_NoDisponible.IsChecked == true)
                {
                    estado = "No Disponible";
                }
                int receta = ((comboBoxItem1)cboReceta.SelectedItem).id;//Guardo el id
                int cat = ((comboBoxItem1)cboCategoria.SelectedItem).id;//Guardo el id
                int prod = ((comboBoxItem1)cboProducto.SelectedItem).id;//Guardo el id
                                
                Plato i = new Plato()
                {
                    nom_plato = nombre,
                    precio_plato = precio,
                    descripcion = desc,
                    tiempo_preparacion = tiempo,
                    estado = estado,
                    id_receta = receta,
                    id_categoria = cat,
                    id_producto = prod
                };

                bool resp = pla.Agregar(i);
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Guardado" : "No Guardado"));

                //-----------------------------------------------------------------------------------------------
                //MOSTRAR LISTA DE ERRORES (validación de la clase)
                if (resp == false)//If para que no muestre mensaje en blanco en caso de éxito
                {
                    DaoErrores de = pla.retornar();
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
                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("plato_guardado");
                    txtNomb.Focus();
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
                      string.Format("Error de ingreso de datos"));
                /*MessageBox.Show("Error de ingreso de datos");*/
                Logger.Mensaje(ex.Message);
                DaoErrores de = pla.retornar();
                string li = "";
                foreach (string item in de.ListarErrores())
                {
                    li += item + " \n";
                }
                await this.ShowMessageAsync("Mensaje:",
                    string.Format(li));

            }
        }

        //--------Botón Modificar-------------------------------------
        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtNum.Text);
                string nombre = txtNomb.Text;
                int precio = int.Parse(txtPrecio.Text);
                string desc = txtDescripcion.Text;
                int tiempo = int.Parse(txtTiempo.Text);
                string estado = null;
                if (rb_disponible.IsChecked == true)
                {
                    estado = "Disponible";
                }
                if (rb_NoDisponible.IsChecked == true)
                {
                    estado = "No Disponible";
                }
                int receta = ((comboBoxItem1)cboReceta.SelectedItem).id;//Guardo el id
                int cat = ((comboBoxItem1)cboCategoria.SelectedItem).id;//Guardo el id
                int prod = ((comboBoxItem1)cboProducto.SelectedItem).id;//Guardo el id

                Plato i = new Plato()
                {
                    id_plato = id,
                    nom_plato = nombre,
                    precio_plato = precio,
                    descripcion = desc,
                    tiempo_preparacion = tiempo,
                    estado = estado,
                    id_receta = receta,
                    id_categoria = cat,
                    id_producto = prod
                };
                bool resp = pla.Actualizar(i);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Actualizado" : "No Actualizado"));


                //-----------------------------------------------------------------------------------------------
                if (resp == true)
                {
                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("plato_actualizado");
                    Limpiar();
                    txtNomb.Focus();
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

        //-----Botón Eliminar----------------------------------------
        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar id
               Plato.ListaPlato lp = (Plato.ListaPlato)dgLista.SelectedItem;
                int id = lp.Id;

                Plato platillo = new Plato();

                var x = await this.ShowMessageAsync("Eliminar Datos: ",
                         "¿Está seguro de eliminar el registro? ",
                        MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                    bool resp = platillo.Eliminar(id);//Entrega id por parametro
                    if (resp == true)//Si el método fue éxitoso muestra el mensaje
                    {
                        await this.ShowMessageAsync("Éxito:",
                          string.Format("Resgistro Eliminado"));
                        //Notificación (Actualiza la grilla en tiempo real)
                        NotificationCenter.Notify("agenda_borrada");
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

        //--------Botón Traspasar-----------------------------------
        private void btnPasar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Plato.ListaPlato lp = (Plato.ListaPlato)dgLista.SelectedItem;
                txtNum.Text = lp.Id.ToString();

                txtNomb.Text = lp.Nombre;
                var largoP = (lp.Precio.Length - 2);
                var largoT = (lp.Tiempo_Preparación.Length - 8);
                txtPrecio.Text = lp.Precio.Substring(2, largoP);
                txtDescripcion.Text = lp.Descripcion;
                txtTiempo.Text = lp.Tiempo_Preparación.Substring(0, largoT );
                
                
                if (lp.Estado == "Disponible")
                {
                    rb_disponible.IsChecked = true;
                }
                else
                {
                    rb_disponible.IsChecked = true;
                }
                cboReceta.Text = lp.Receta;
                cboCategoria.Text = lp.Categoria;
                cboProducto.Text = lp.Producto;

                btnGuardar.Visibility = Visibility.Hidden;
                btnModificar.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
            }
        }

        

        //-------Recuperar caché----------------------------------
        private void BtnCache_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileCache filecahe = new FileCache(new ObjectBinder());

                if (filecahe["plato"] != null)
                {
                    Plato.ListaPlato lp = (Plato.ListaPlato)filecahe["plato"];

                    txtNum.Text = lp.Id.ToString();

                    txtNomb.Text = lp.Nombre;
                    var largoP = (lp.Precio.Length - 2);
                    var largoT = (lp.Tiempo_Preparación.Length - 8);
                    txtPrecio.Text = lp.Precio.Substring(2, largoP);
                    txtDescripcion.Text = lp.Descripcion;
                    txtTiempo.Text = lp.Tiempo_Preparación.Substring(0, largoT);

                    if (lp.Estado == "Disponible")
                    {
                        rb_disponible.IsChecked = true;
                    }
                    else
                    {
                        rb_NoDisponible.IsChecked = true;
                    }
                    cboReceta.Text = lp.Receta;
                    cboCategoria.Text = lp.Categoria;
                    cboProducto.Text = lp.Producto;

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

        //----Terminar tareas singleton y caché--------------
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Terminar con la tarea caché al cerrar la ventana
            hilo.Abort();

            //Parar Singleton
            _instancia = null;
        }

                
    }
}
