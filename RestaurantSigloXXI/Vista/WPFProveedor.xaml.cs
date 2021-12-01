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

    public partial class WPFProveedor : MetroWindow
    {
        //PatronSingleton--------------------------
        public static WPFProveedor _instancia;

        public static WPFProveedor ObtenerinstanciaPRO()
        {
            if (_instancia == null)
            {
                _instancia = new WPFProveedor();
            }

            return _instancia;
        }
        //----------------------------------------

        //Hilo para cache
        Thread hilo = null;
        //Traer clase
        Proveedor pro = new Proveedor();

        public WPFProveedor()
        {
            InitializeComponent();
            txtTelefono.Text = "0";

            btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve
            btnGuardar.Visibility = Visibility.Visible;
            //btnEliminar.Visibility = Visibility.Hidden;
            txtNombre.Focus();//Focus en el nombre

            CargarGrilla();
            //Cuando se guarda una mesa nueva se refresca la grilla
            NotificationCenter.Subscribe("proveedor_guardado", CargarGrilla);
            NotificationCenter.Subscribe("proveedor_actualizado", CargarGrilla);
            NotificationCenter.Subscribe("proveedor_borrado", CargarGrilla);


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
                Proveedor.ListaProveedor i = new Proveedor.ListaProveedor();

                if (txtNombre.Text != null)
                {
                    i.Nombre = txtNombre.Text;
                }
                if (txtCorreo.Text != null)
                {
                    i.Email = txtCorreo.Text;
                }
                int telefono = 0;
                if (int.TryParse(txtTelefono.Text, out telefono))
                {
                    i.Teléfono = int.Parse(txtTelefono.Text);
                }                

                if (txtDireccion.Text != null)
                {
                    i.Dirección = txtDireccion.Text;
                }

                if (txtWeb.Text != null)
                {
                    i.WebSite = txtWeb.Text;
                }

                //Proceso de respaldo
                //Con la ampolleta agregó el using Runtime.Caching
                FileCache filecahe = new FileCache(new ObjectBinder());

                String hora = DateTime.Now.ToString("dd-MM-yy HH:mm:ss");

                filecahe["proveedor"] = pro;
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
                    dgLista.ItemsSource = pro.Listar();
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
            LblId.Content = "";
            txtNombre.Clear();
            txtTelefono.Text = "0";
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtWeb.Clear();

            btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve
            btnGuardar.Visibility = Visibility.Visible;
           //btnEliminar.Visibility = Visibility.Hidden;
            txtNombre.Focus();//Focus en el radioButton
            
            //Limpiar cache
            FileCache filecahe = new FileCache(new ObjectBinder());
            filecahe.Remove("proveedor", null);
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


        //---Guardar------------------------------------------------------
        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //int Id = int.Parse(LblId.Content.ToString());
                string Nombre = txtNombre.Text;
                string Correo = txtCorreo.Text;
                string Direccion = txtDireccion.Text;
                int Telefono = int.Parse(txtTelefono.Text);
                string web = txtWeb.Text;
                
                Proveedor i = new Proveedor()
                {
                    nombre = Nombre,
                    correo = Correo,
                    telefono = Telefono,
                    direccion = Direccion,
                    sitio_web = web
                    
                };

                bool resp = pro.Agregar(i);
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Guardado" : "No Guardado"));

                //-----------------------------------------------------------------------------------------------
                //MOSTRAR LISTA DE ERRORES (validación de la clase)
                if (resp == false)//If para que no muestre mensaje en blanco en caso de éxito
                {
                    DaoErrores de = pro.retornar();
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
                    txtNombre.Focus();

                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("proveedor_guardado");
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

        //--------Modificar -----------------------------------------------
        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = int.Parse(LblId.Content.ToString());
                string Nombre = txtNombre.Text;
                string Correo = txtCorreo.Text;
                string Direccion = txtDireccion.Text;
                int Telefono = int.Parse(txtTelefono.Text);
                string web = txtWeb.Text;

                Proveedor i = new Proveedor()
                {
                    id_proveedor = Id,
                    nombre = Nombre,
                    correo = Correo,
                    telefono = Telefono,
                    direccion = Direccion,
                    sitio_web = web

                };
                
                bool resp = pro.Actualizar(i);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Actualizado" : "No Actualizado"));
               
                //-----------------------------------------------------------------------------------------------
                //MOSTRAR LISTA DE ERRORES (validación de la clase)
                if (resp == false)//If para que no muestre mensaje en blanco en caso de éxito
                {
                    DaoErrores de = pro.retornar();
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
                    txtNombre.Focus();
                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("proveedor_actualizado");
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

        
        //---------Eliminar---------------------------------------------
        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar id
                Proveedor.ListaProveedor i = (Proveedor.ListaProveedor)dgLista.SelectedItem;
                int id = i.Id;

               Proveedor proveer = new Proveedor();

                var x = await this.ShowMessageAsync("Eliminar Datos: ",
                         "¿Está Seguro de eliminar el Registro? ",
                        MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                    bool resp = proveer.Eliminar(id);//Entrega id por parametro
                    if (resp == true)//Si el método fue éxitoso muestra el mensaje
                    {
                        await this.ShowMessageAsync("Éxito:",
                          string.Format("Registro Eliminado"));
                        //Notificación (Actualiza la grilla en tiempo real)
                        NotificationCenter.Notify("proveedor_borrado");
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



        //------Recuperar caché---------------------------------------
        private void BtnCache_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileCache filecahe = new FileCache(new ObjectBinder());

                if (filecahe["proveedor"] != null)
                {
                    Proveedor.ListaProveedor c = (Proveedor.ListaProveedor)filecahe["proveedor"];

                    LblId.Content = c.Id.ToString();
                    txtNombre.Text = c.Nombre;
                    txtCorreo.Text = c.Email;
                    txtTelefono.Text = c.Teléfono.ToString();
                    txtDireccion.Text = c.Dirección;
                    txtWeb.Text = c.WebSite;                   

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
               Proveedor.ListaProveedor i = (Proveedor.ListaProveedor)dgLista.SelectedItem;
                LblId.Content = i.Id.ToString();
                txtNombre.Text = i.Nombre;
                txtCorreo.Text = i.Email;
                txtTelefono.Text = i.Teléfono.ToString();
                txtDireccion.Text = i.Dirección;
                txtWeb.Text = i.WebSite;

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
