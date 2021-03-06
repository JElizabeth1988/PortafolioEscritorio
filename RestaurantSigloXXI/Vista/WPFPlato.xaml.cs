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
//imagen
using Microsoft.Win32;
using System.IO;
using BibliotecaDALC;

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

        private WPFPlato()
        {
            InitializeComponent();
            btnModificar.Visibility = Visibility.Hidden;
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
            //filtro
            foreach (Categoria item in new Categoria().ReadAll())
            {
                comboBoxItem1 cb = new comboBoxItem1();
                cb.id = item.id_categoria;
                cb.nombre = item.nombre_cat;
                cboFiltro.Items.Add(cb);
            }
            //--------------------------------------
            cboReceta.SelectedIndex = 0;
            cboCategoria.SelectedIndex = 0;
            cboFiltro.SelectedIndex = 0;
            txtPrecio.Text = "0";
            txtStock.Text = "0";
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
            Dispatcher.Invoke(() =>
            {

                //Llama a la clase cliente donde se gusradarán los datos
                Plato.ListaPlato i = new Plato.ListaPlato();
                int id = 0;
                if (int.TryParse(lblId.Content.ToString(), out id))
                {
                    i.Id = int.Parse(lblId.Content.ToString());
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

                if (txtStock.Text != null)
                {
                    i.Stock = txtStock.Text;
                }
                if (cboReceta.SelectedValue != null)
                {
                    i.Receta = cboReceta.Text;
                }
                if (cboCategoria.SelectedValue != null)
                {
                    i.Categoria = cboCategoria.Text;
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
            lblId.Content = "";
            txtNomb.Clear();
            txtPrecio.Text = "0";
            txtDescripcion.Clear();

            cboReceta.SelectedIndex = 0;
            cboCategoria.SelectedIndex = 0;
            txtNomb.Focus();

            cboFiltro.SelectedIndex = 0;
            txtStock.Text = "0";

            //limpiar imagen 
            imgPlato.Source = null;
            FileNameLabel.Content = null;

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
                int stock = 0;
                if (txtStock.Text != string.Empty)
                {
                    stock = int.Parse(txtStock.Text);
                }
                
                int receta = ((comboBoxItem1)cboReceta.SelectedItem).id;//Guardo el id
                int cat = ((comboBoxItem1)cboCategoria.SelectedItem).id;//Guardo el id
                byte[] fotin = null;
                if (FileNameLabel.Content != null)
                {
                    //Procedimiento para convertir imagen a byte

                    FileStream stream = new FileStream(FileNameLabel.Content.ToString(), FileMode.Open, FileAccess.Read);
                    //Se inicailiza un flujo de archivo con la imagen seleccionada desde el disco.
                    BinaryReader br = new BinaryReader(stream);
                    FileInfo fi = new FileInfo(FileNameLabel.Content.ToString());
                    //Se inicializa un arreglo de Bytes del tamaño de la imagen
                    byte[] binData = new byte[stream.Length];
                    //Se almacena en el arreglo de bytes la informacion que se obtiene del flujo de archivos(foto)
                    //Lee el bloque de bytes del flujo y escribe los datos en un búfer dado.
                    stream.Read(binData, 0, Convert.ToInt32(stream.Length));

                    fotin = binData;
                }
                else
                {
                    fotin = null;
                }

                Plato i = new Plato()
                {
                    nom_plato = nombre,
                    precio_plato = precio,
                    descripcion = desc,
                    stock = stock,
                    id_receta = receta,
                    id_categoria = cat,
                    foto = fotin
                };

                bool resp = pla.Agregar(i);
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Guardado" : "No Guardado"));

                //-----------------------------------------------------------------------------------------------
                //MOSTRAR LISTA DE ERRORES (validación de la clase)
                if (resp == false)//If para que no muestre mensaje en blanco en caso de éxito
                {

                    DaoErrores de = i.retornar();
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
               

            }
        }

        //--------Botón Modificar-------------------------------------
        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(lblId.Content.ToString());
                string nombre = txtNomb.Text;
                int precio = int.Parse(txtPrecio.Text);
                string desc = txtDescripcion.Text;
                int stock = 0;
                if (txtStock.Text != string.Empty)
                {
                    stock = int.Parse(txtStock.Text);
                }
                int receta = ((comboBoxItem1)cboReceta.SelectedItem).id;//Guardo el id
                int cat = ((comboBoxItem1)cboCategoria.SelectedItem).id;//Guardo el id

                if (FileNameLabel.Content != null)
                {                   

                    byte[] fotin = null;
                    if (FileNameLabel.Content != null)
                    {
                        //Procedimiento para convertir imagen a byte

                        FileStream stream = new FileStream(FileNameLabel.Content.ToString(), FileMode.Open, FileAccess.Read);
                        //Se inicailiza un flujo de archivo con la imagen seleccionada desde el disco.
                        BinaryReader br = new BinaryReader(stream);
                        FileInfo fi = new FileInfo(FileNameLabel.Content.ToString());
                        //Se inicializa un arreglo de Bytes del tamaño de la imagen
                        byte[] binData = new byte[stream.Length];
                        //Se almacena en el arreglo de bytes la informacion que se obtiene del flujo de archivos(foto)
                        //Lee el bloque de bytes del flujo y escribe los datos en un búfer dado.
                        stream.Read(binData, 0, Convert.ToInt32(stream.Length));

                        fotin = binData;
                    }
                    else
                    {
                        fotin = null;
                    }

                    Plato i = new Plato()
                    {
                        id_plato = id,
                        nom_plato = nombre,
                        precio_plato = precio,
                        descripcion = desc,
                        stock = stock,
                        id_receta = receta,
                        id_categoria = cat,
                        foto = fotin
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
                    else
                    {
                        DaoErrores de = i.retornar();
                        string li = "";
                        foreach (string item in de.ListarErrores())
                        {
                            li += item + " \n";
                        }
                        await this.ShowMessageAsync("Mensaje:",
                            string.Format(li));
                    }
                }
                else
                {                   

                    Plato i = new Plato()
                    {
                        id_plato = id,
                        nom_plato = nombre,
                        precio_plato = precio,
                        descripcion = desc,
                        stock = stock,
                        id_receta = receta,
                        id_categoria = cat
                    };
                    bool resp = pla.Actualizar2(i);
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
                    else
                    {
                        DaoErrores de = i.retornar();
                        string li = "";
                        foreach (string item in de.ListarErrores())
                        {
                            li += item + " \n";
                        }
                        await this.ShowMessageAsync("Mensaje:",
                            string.Format(li));
                    }

                }                   


            }
            catch (ArgumentException exa)//mensajes de reglas de negocios
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format((exa.Message)));
                Logger.Mensaje(exa.Message);
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
                        Limpiar();
                        await this.ShowMessageAsync("Éxito:",
                          string.Format("Resgistro Eliminado"));
                        //Notificación (Actualiza la grilla en tiempo real)
                        NotificationCenter.Notify("plato_borrado");
                        
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
                lblId.Content = lp.Id.ToString();

                txtNomb.Text = lp.Nombre;
                var largoP = (lp.Precio.Length - 2);
                txtPrecio.Text = lp.Precio.Substring(2, largoP);
                txtDescripcion.Text = lp.Descripcion;
                var largoSt = (lp.Stock.Length - 3);
                txtStock.Text = lp.Stock.Substring(0, largoSt);


                cboReceta.Text = lp.Receta;
                cboCategoria.Text = lp.Categoria;

                btnGuardar.Visibility = Visibility.Hidden;
                btnModificar.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
            }
        }
        //--Botón filtrar------------------------------------------------
        private async void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cate = cboFiltro.Text;
                if (pla.Filtrar(cate) != null)
                {
                    dgLista.ItemsSource = pla.Filtrar(cate);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("");
                    dt.Columns.Add("Platos:");
                    dt.Rows.Add("", "No existe información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    cboFiltro.SelectedIndex = 0;

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

        //-------Recuperar caché----------------------------------
        private void BtnCache_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileCache filecahe = new FileCache(new ObjectBinder());

                if (filecahe["plato"] != null)
                {
                    Plato.ListaPlato lp = (Plato.ListaPlato)filecahe["plato"];

                    lblId.Content = lp.Id.ToString();

                    txtNomb.Text = lp.Nombre;

                    txtPrecio.Text = lp.Precio;
                    txtDescripcion.Text = lp.Descripcion;
                    txtStock.Text = lp.Stock;

                    cboReceta.Text = lp.Receta;
                    cboCategoria.Text = lp.Categoria;

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

        //-------Botón para cargar imagen
        private void Seleccionar_click(object sender, RoutedEventArgs e)
        {
            //Objeto de open file dialog (se creo un using Microsoft.Win32)
            OpenFileDialog OFD = new OpenFileDialog();
            //filtro de extensión
            OFD.Filter = "image files|*.jpg;*.png;*.gif;*.ico;.*;";
            //Directorio inicial carpeta Mis imágenes 
            OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            //texto
            OFD.Title = "Seleccionar Imagen";

            if (OFD.ShowDialog() == true)
            {
                //Uri fileUri = new Uri(OFD.FileName);
                //cargar imagen en la casilla de imagen
                //imgPlato.Source = new BitmapImage(fileUri);

                //se guarda el nombre y ruta del archivo en variable
                string selectedFileName = OFD.FileName;
                //ruta de la imagen en label
                FileNameLabel.Content = selectedFileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                imgPlato.Source = bitmap;

            }
        }
        /*
        private async void btnVer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                int id;

                if (int.TryParse(lblId.Content.ToString(), out id) == true)
                {
                    return;

                }                
                
                conn.Close();

                if (pla.verImagen(id) != null)

                {
                    Logger.Mensaje(pla.foto.ToString());//para ver que trae
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(pla.foto);

                    ms.Seek(0, System.IO.SeekOrigin.Begin);

                    BitmapImage bi = new BitmapImage();

                    bi.BeginInit();

                    bi.StreamSource = ms;

                    bi.EndInit();

                    // asociar el bitmap a la imagen
                    imgPlato.Source = bi;

                    
                }

                
            }

            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al mostrar foto"));
                Logger.Mensaje(ex.Message);
            }
        }
        */

    }
}
