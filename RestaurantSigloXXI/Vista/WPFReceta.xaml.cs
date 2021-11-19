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

    public partial class WPFReceta : MetroWindow
    {
        //PatronSingleton--------------------------
        public static WPFReceta _instancia;

        public static WPFReceta ObtenerinstanciaREC()
        {
            if (_instancia == null)
            {
                _instancia = new WPFReceta();
            }

            return _instancia;
        }
        //----------------------------------------

        //Hilo para cache
        Thread hilo = null;

        //Instanciar BD
        OracleConnection conn = null;
        //Traer clase Mesa
        Receta rec = new Receta();
        //Empleado
        Empleado emp = new Empleado();

        public WPFReceta()
        {
            InitializeComponent();
            txtTi_Coc.Text = "0";
            txtTPrep.Text = "0";
            //txtTotal.Text = "0";
            txtPorcion.Text = "0";
            CargarGrilla();
            btnModificar.Visibility = Visibility.Hidden;
            //Cuando se guarda una mesa nueva se refresca la grilla
            NotificationCenter.Subscribe("receta_guardada", CargarGrilla);
            NotificationCenter.Subscribe("receta_actualizada", CargarGrilla);
            NotificationCenter.Subscribe("receta_borrada", CargarGrilla);

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
                Receta.ListaReceta re = new Receta.ListaReceta();

                int id = 0;
                if (int.TryParse(lblId.Content.ToString(), out id))
                {
                    re.id = int.Parse(lblId.Content.ToString());
                }
                if (txtNom_receta.Text != null)
                {
                    re.Nombre = txtNom_receta.Text;
                }

                int coccion = 0;
                if (int.TryParse(txtTi_Coc.Text, out coccion))
                {
                    re.Tiempo_coccion = txtTi_Coc.Text;
                }
                int prepa = 0;
                if (int.TryParse(txtTPrep.Text, out prepa))
                {
                    re.tiempo_preparacion = txtTPrep.Text;
                }
                
                int porc = 0;
                if (int.TryParse(txtPorcion.Text, out porc))
                {
                    re.porciones = txtPorcion.Text;
                }
                if (txtIngrediente.Text != null)
                {
                    re.Ingredientes = txtIngrediente.Text;
                }
                if (txtInstrucciones.Text != null)
                {
                    re.Instrucciones = txtInstrucciones.Text;
                }

                //Proceso de respaldo
                //Con la ampolleta agregó el using Runtime.Caching
                FileCache filecahe = new FileCache(new ObjectBinder());

                String hora = DateTime.Now.ToString("dd-MM-yy HH:mm:ss");

                filecahe["receta"] = re;
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
                    dgLista.ItemsSource = rec.Listar();
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
            txtNom_receta.Clear();
            txtTi_Coc.Text = "0";
            txtTPrep.Text = "0";
            //txtTotal.Text = "0";
            txtPorcion.Text = "0";
            txtInstrucciones.Clear();
            txtIngrediente.Clear();
            txtNom_receta.Focus();

            btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve
            btnGuardar.Visibility = Visibility.Visible;
            //btnEliminar.Visibility = Visibility.Hidden;

            //Limpiar cache
            FileCache filecahe = new FileCache(new ObjectBinder());
            filecahe.Remove("receta", null);
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
                string nombre = txtNom_receta.Text;
                int coccion = int.Parse(txtTi_Coc.Text);
                int prepa = int.Parse(txtTPrep.Text);
                int total = (int.Parse(txtTi_Coc.Text) + int.Parse(txtTPrep.Text));
                int porcion = int.Parse(txtPorcion.Text);
                string ingredientes = txtIngrediente.Text;
                string instruccion = txtInstrucciones.Text;

                Receta r = new Receta()
                {
                    nom_receta = nombre,
                    tiempo_coccion = coccion,
                    tiempo_preparacion = prepa,
                    tiempo_total = total,
                    porcion = porcion,
                    Ingredientes = ingredientes,
                    instrucciones = instruccion
                };

                bool resp = rec.Agregar(r);
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Guardado" : "No Guardado"));

                if (resp == true)
                {
                    txtNom_receta.Focus();

                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("receta_guardada");
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
                int id = int.Parse(lblId.Content.ToString());
                string nombre = txtNom_receta.Text;
                int coccion = int.Parse(txtTi_Coc.Text);
                int prepa = int.Parse(txtTPrep.Text);
                int total = (int.Parse(txtTi_Coc.Text) + int.Parse(txtTPrep.Text));
                int porcion = int.Parse(txtPorcion.Text);
                string ingredientes = txtIngrediente.Text;
                string instruccion = txtInstrucciones.Text;

                Receta r = new Receta()
                {
                    id_receta = id,
                    nom_receta = nombre,
                    tiempo_coccion = coccion,
                    tiempo_preparacion = prepa,
                    tiempo_total = total,
                    porcion = porcion,
                    Ingredientes = ingredientes,
                    instrucciones = instruccion
                };
                bool resp = rec.Actualizar(r);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Actualizado" : "No Actualizado"));
                //Notificación (Actualiza la grilla en tiempo real)
                NotificationCenter.Notify("receta_actualizada");


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


        //---------Eliminar---------------------------------------------
        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar id
                Receta.ListaReceta r = (Receta.ListaReceta)dgLista.SelectedItem;
                int id = r.id;

                var x = await this.ShowMessageAsync("Eliminar Datos: ",
                         "¿Está Seguro de eliminar la Receta? ",
                        MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                    bool resp = rec.Eliminar(id);//Entrega id por parametro
                    if (resp == true)//Si el método fue éxitoso muestra el mensaje
                    {
                        await this.ShowMessageAsync("Éxito:",
                          string.Format("Receta Eliminada"));
                        //Notificación (Actualiza la grilla en tiempo real)
                        NotificationCenter.Notify("receta_borrada");
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

                if (filecahe["receta"] != null)
                {
                    Receta.ListaReceta c = (Receta.ListaReceta)filecahe["receta"];

                    txtNom_receta.Text = c.Nombre;
                    txtTi_Coc.Text = c.Tiempo_coccion;
                    txtTPrep.Text = c.tiempo_preparacion;
                    //txtTotal.Text = c.tiempo_total;
                    txtPorcion.Text = c.porciones;
                    txtIngrediente.Text = c.Instrucciones;
                    txtIngrediente.Text = c.Ingredientes;
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
                Receta.ListaReceta r = (Receta.ListaReceta)dgLista.SelectedItem;
                lblId.Content = r.id;
                txtNom_receta.Text = r.Nombre;

                var LargoCoc = (r.Tiempo_coccion.Length - 8);
                txtTi_Coc.Text = r.Tiempo_coccion.Substring(0, LargoCoc);

                var LargoPrep = (r.tiempo_preparacion.Length - 8);
                txtTPrep.Text = r.tiempo_preparacion.Substring(0, LargoPrep);
                /*var LargoTot = (r.tiempo_total.Length - 8);
                txtTotal.Text = r.tiempo_total.Substring(0, LargoTot);*/
                var LargoPorc = (r.porciones.Length - 10);
                txtPorcion.Text = r.porciones.Substring(0, LargoPorc);

                txtInstrucciones.Text = r.Instrucciones;
                txtIngrediente.Text = r.Ingredientes;


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
        //---Total
      /*  public string TiempoTotal()
        {
            try
            {
                int coccion = 0;
                if (txtTi_Coc.Text != null)
                {
                    coccion = int.Parse(txtTi_Coc.Text);
                }
                int preparacion = 0;
                if (txtTPrep.Text != null)
                {
                    preparacion = int.Parse(txtTPrep.Text);
                }

                string total = (coccion + preparacion).ToString();

                return total;

            }
            catch (Exception ex)
            {
                return null;
                Logger.Mensaje(ex.Message);
            }
        }
        private async void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TiempoTotal() != null && TiempoTotal() != "0")
                {
                    txtTotal.Text = TiempoTotal().ToString();
                }                
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                     string.Format("Es obligatorio Ingresar Valores"));
                    //MessageBox.Show("Es obligatorio Ingresar Valores");
                }
                

            }
            catch (Exception ex)
            {

                Logger.Mensaje(ex.Message);
            }
        }*/
    }
}
