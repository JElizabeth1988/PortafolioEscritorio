//Bibliotecas
using BibliotecaNegocio;
//using System.Data.OracleClient;

//Metro
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Oracle.ManagedDataAccess.Client;
using System;
//FileCache
using System.Runtime.Caching;
using System.Threading; //Hilos
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
                if (int.TryParse(txtIdProd.Text, out Id))
                {
                    pr.id_producto = int.Parse(txtIdProd.Text);
                }

                if (txtNomProd.Text != null)
                {
                    pr.nombre_producto = txtNomProd.Text;
                }
                int ValorUnidad = 0;
                if (int.TryParse(txtValorUnidad.Text, out ValorUnidad))
                {
                    pr.valor_unidad = int.Parse(txtValorUnidad.Text);
                }
                int Stock = 0;
                if (int.TryParse(txtStock.Text, out Stock))
                {
                    pr.stock = int.Parse(txtStock.Text);
                }
                int valorKg = 0;
                if (int.TryParse(txtValorKg.Text, out valorKg))
                {
                    pr.valor_kilo = int.Parse(txtValorKg.Text);
                }
                int valorUnidad = 0;
                if (int.TryParse(txtValorUnidad.Text, out valorUnidad))
                {
                    pr.valor_unidad = int.Parse(txtValorUnidad.Text);
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


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Limpiar()
        {
            txtIdProd.Clear();
            txtNomProd.Clear();
            txtStock.Clear();
            txtValorKg.Clear();
            txtValorTotal.Clear();
            txtValorUnidad.Clear();
            lblCache.Content = null;

            btnModificar.Visibility = Visibility.Hidden;//Botón modificar se esconde
            btnGuardar.Visibility = Visibility.Visible;//botón guardar aparece
            btnEliminar.Visibility = Visibility.Hidden;

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

        ///Boton Guardar

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //int IdProducto = int.Parse(txtIdProd.Text);
                int IdProducto = 0;
                if (int.TryParse(txtIdProd.Text, out IdProducto))
                {

                }
                else
                {
                    return;
                }

                String nombreProducto = txtNomProd.Text;

                //int ValorUnidad = int.Parse(txtValorUnidad.Text);
                int ValorUnidad = 0;
                if (int.TryParse(txtValorUnidad.Text, out ValorUnidad))
                {

                }
                else
                {
                    return;
                }

                //int IdTipo = int.Parse(txtIdTipo.Text);
                int IdTipo = 0;
                if (int.TryParse(txtIdTipo.Text, out IdTipo))
                {

                }
                else
                {
                    return;
                }

                //int Stock = int.Parse(txtStock.Text);
                int Stock = 0;
                if (int.TryParse(txtStock.Text, out Stock))
                {

                }
                else
                {
                    return;
                }

                //int Valorkg = int.Parse(txtValorKg.Text);
                int ValorKg = 0;
                if (int.TryParse(txtValorKg.Text, out ValorKg))
                {

                }
                else
                {
                    return;
                }

                //int Valorkg = int.Parse(txtValorKg.Text);
                int ValorTotal = 0;
                if (int.TryParse(txtValorTotal.Text, out ValorTotal))
                {

                }
                else
                {
                    return;
                }

                //ver porque me esta causando conflictos para guardar, ademas no despliega el listado en el cbo, y falta arreglar la vista, para que el al poner el nombre del tipo producto, se inserte automaticamente el id dle tipo

                int tipo = ((ComboBoxItemTipoProducto)cboTipoProducto.SelectedItem).id_tipo_producto;

                Producto pro = new Producto()
                {
                    id_producto = IdProducto,
                    nombre_producto = nombreProducto,
                    valor_unidad = ValorUnidad,
                    id_tipo_producto = IdTipo,
                    stock = Stock,
                    valor_kilo = ValorKg,
                    valor_total = ValorTotal,
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

        private void txtIdProd_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //----------Botón Actualizar
        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int IdProducto = int.Parse(txtIdProd.Text);
                String nombreProducto = txtNomProd.Text;
                int ValorUnidad = int.Parse(txtValorUnidad.Text);
                int IdTipo = int.Parse(txtIdTipo.Text);
                int Stock = int.Parse(txtStock.Text);
                int ValorKg = int.Parse(txtValorKg.Text);
                int ValorTotal = int.Parse(txtValorTotal.Text);
                int tipo = ((ComboBoxItemTipoProducto)cboTipoProducto.SelectedItem).id_tipo_producto;//Guardar el ID de tipo producto

                Producto pro = new Producto()
                {
                    id_producto = IdProducto,
                    nombre_producto = nombreProducto,
                    valor_unidad = ValorUnidad,
                    id_tipo_producto = IdTipo,
                    stock = Stock,
                    valor_kilo = ValorKg,
                    valor_total = ValorTotal,
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
                int IdProducto = int.Parse(txtIdProd.Text);
                Producto pro1 = new Producto();

                string nombreProducto = txtNomProd.Text;

                var x = await this.ShowMessageAsync("Eliminar Datos: ",
                         "¿Está Seguro de eliminar a " + nombreProducto + "?",
                        MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                    bool resp = prod.Eliminar(IdProducto);//Entrega ID por parametro
                    if (resp == true)//Si el método fue éxitoso muestra el mensaje
                    {
                        await this.ShowMessageAsync("Éxito:",
                          string.Format("Producto Eliminado"));
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

                if (filecahe["producto"] != null)
                {
                    Producto.ListaProducto p = (Producto.ListaProducto)filecahe["producto"];

                    txtIdProd.Text = p.id_producto.ToString();
                    txtNomProd.Text = p.nombre_producto;
                    txtIdTipo.Text = p.id_tipo_producto.ToString();
                    txtValorUnidad.Text = p.valor_unidad.ToString();
                    txtStock.Text = p.stock.ToString();
                    txtValorKg.Text = p.valor_kilo.ToString();
                    txtValorTotal.Text = p.valor_total.ToString();

                    cboTipoProducto.Text = p.nombre_tipo;
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

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int IdProducto = int.Parse(txtIdProd.Text);
                prod.Buscar(IdProducto);
                if (prod != null)//Si la lista no esta vacía entrego parámetros a los textBox
                {
                    txtIdProd.Text = prod.id_producto.ToString();
                    txtNomProd.Text = prod.nombre_producto;
                    txtIdTipo.Text = prod.id_tipo_producto.ToString();
                    txtValorUnidad.Text = prod.valor_unidad.ToString();
                    txtStock.Text = prod.stock.ToString();
                    txtValorKg.Text = prod.valor_kilo.ToString();
                    txtValorTotal.Text = prod.valor_total.ToString();
                    TipoProducto tp = new TipoProducto();
                    tp.id_tipo_producto = prod.id_tipo_producto;
                    tp.Read();
                    cboTipoProducto.Text = tp.nombre_tipo;
                    //--------------------

                    btnModificar.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Hidden;
                    btnEliminar.Visibility = Visibility.Visible;

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                        string.Format("No se encontraron resultados!"));
                }
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Debe ingresar un ID correcto"));
                /*MessageBox.Show("error al Filtrar Información");*/
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

