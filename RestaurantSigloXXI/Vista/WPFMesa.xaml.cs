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
   
    public partial class WPFMesa : MetroWindow
    {
        //PatronSingleton--------------------------
        public static WPFMesa _instancia;

        public static WPFMesa ObtenerinstanciaME()
        {
            if (_instancia == null)
            {
                _instancia = new WPFMesa();
            }

            return _instancia;
        }
        //----------------------------------------

        //Hilo para cache
        Thread hilo = null;
        
        //Instanciar BD
        OracleConnection conn = null;
        //Traer clase Mesa
        Mesa mes = new Mesa();
        //Empleado
        Empleado emp = new Empleado();           
           

        public WPFMesa()
        {
            InitializeComponent();
                       
            txtNombre.IsEnabled = false;//No se ve xq se llena del buscar o traspasar
                        
            btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve
            btnGuardar.Visibility = Visibility.Visible;
            //btnEliminar.Visibility = Visibility.Hidden;
            rb_disponible.Focus();//Focus en el radioButton

            CargarGrilla();
            //Cuando se guarda una mesa nueva se refresca la grilla
            NotificationCenter.Subscribe("mesa_guardada", CargarGrilla);
            NotificationCenter.Subscribe("mesa_actualizada", CargarGrilla);
            NotificationCenter.Subscribe("mesa_borrada", CargarGrilla);


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
                Mesa.ListaMesa me = new Mesa.ListaMesa();

                if (txtRut.Text != null)
                {
                    //Guardo el rut 
                    String rut = txtRut.Text;
                    if (rut.Length == 9)//Si el rut tiene solo 9 caracteres se le agrega cero al comienzo para que quede de 10
                    {
                        rut = "0" + txtRut.Text;
                    }
                    me.Rut_Empleado = rut;
                }
                else
                {
                    me.Rut_Empleado = null;
                }

                if (txtNombre.Text != null)
                {
                    me.Empleado = txtNombre.Text;
                }
                if (rb_disponible.IsChecked == true)
                {
                    me.Disponibilidad = "Disponible";
                }
                else
                {
                    me.Disponibilidad = "No Disponible";
                }
                if (rbOnLine.IsChecked == true)
                {
                    me.asignacion = "Online";
                }
                else
                {
                    me.asignacion = "Presencial";
                }

                if (txtCapacidad.Text != null)
                {
                   me.Capacidad = txtCapacidad.Text;
                }
                
                 //Proceso de respaldo
                //Con la ampolleta agregó el using Runtime.Caching
                FileCache filecahe = new FileCache(new ObjectBinder());

                String hora = DateTime.Now.ToString("dd-MM-yy HH:mm:ss");

                filecahe["mesa"] = me;
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
       /* private void dgLista_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if(this.dgLista.Columns != null)
            {
                this.dgLista.Columns[0].Visibility = Visibility.Collapsed;
            }
        }*/

        //---------------Cargar Grilla
        private void CargarGrilla()
        {
            try
            {
                // Dispatcher invoke: Permite ejecutar una acción de forma asincrónica
                //desde un subproceso o desde otra ventana (es un método q llama a una acción)
                //(() => { }); función anónima
                Dispatcher.Invoke(()=> {
                    dgLista.ItemsSource = mes.Listar();
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
            txtNum.Clear();
            
            txtNombre.IsEnabled = false;//No se ve xq se llena del buscar o traspasar
            rb_disponible.IsChecked = true;//Si queda seleccionado
            rb_NoDisponible.IsChecked = false;
            rbOnLine.IsChecked = true;
            rbPresencial.IsChecked = false;

            btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve
            btnGuardar.Visibility = Visibility.Visible;
            //btnEliminar.Visibility = Visibility.Hidden;
            rb_NoDisponible.Focus();//Focus en el radioButton
            txtRut.Clear();
            txtCapacidad.Clear();
            txtNombre.Clear();

            //Limpiar cache
            FileCache filecahe = new FileCache(new ObjectBinder());
            filecahe.Remove("mesa", null);
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
        private void btnPregunta_Click(object sender, RoutedEventArgs e)
        {
            WPFListadoEmpleado emp = new WPFListadoEmpleado(this);
            emp.ShowDialog();
        }

        

        //Buscar a Garzón--------------------------------------------------------
        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Empleado.ListaEmpleadoMesa le = new Empleado.ListaEmpleadoMesa();
                //Rescato el rut para entregarlo x parametro
                String rut = txtRut.Text;
                if (rut.Length == 9)//Si el rut tiene solo 9 caracteres se le agrega cero al comienzo para que quede de 10
                {
                    rut = "0" + txtRut.Text;
                }
                le.BuscarEmpMesa(rut);
                if (le != null)//Si la lista no esta vacía entrego parámetros a los textBox
                {                    
                    txtRut.Text = le.Rut;                    
                    txtNombre.Text = le.Nombre;
                    txtNombre.IsEnabled = false;//No se edita el nombre

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
                     string.Format("Error al Buscar Información! "));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
            }
        }

       
        //--------Modificar -----------------------------------------------
        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                int id = int.Parse(txtNum.Text);
                
                string disponible = null;
                if (rb_disponible.IsChecked == true)
                {
                    disponible = "Disponible";
                }
                if (rb_NoDisponible.IsChecked == true)
                {
                    disponible = "No Disponible";
                }

                string asignada = null;
                if (rbOnLine.IsChecked == true)
                {
                    asignada = "Online";
                }
                if (rbPresencial.IsChecked == true)
                {
                    asignada = "Presencial";
                }

                int capacidad = int.Parse(txtCapacidad.Text);
                string rut = txtRut.Text; 
                if (rut.Length == 9)//Si el rut tiene solo 9 caracteres se le agrega cero al comienzo para que quede de 10
                {
                    rut = "0" + txtRut.Text;
                }

                Mesa m = new Mesa()
                {
                    num_mesa = id,
                    capacidad_persona = capacidad,
                    disponibilidad = disponible,
                    asignacion = asignada,
                    rut_empleado = rut
                };
                bool resp = mes.Actualizar(m);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Actualizado" : "No Actualizado"));
                //Notificación (Actualiza la grilla en tiempo real)
                NotificationCenter.Notify("mesa_actualizada");


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
                string disponible = null;
                if (rb_disponible.IsChecked == true)
                {
                    disponible = "Disponible";
                }
                if (rb_NoDisponible.IsChecked == true)
                {
                    disponible = "No Disponible";
                }
                string asignada = null;
                if (rbOnLine.IsChecked == true)
                {
                    asignada = "Online";
                }
                if (rbPresencial.IsChecked == true)
                {
                    asignada = "Presencial";
                }
                int capacidad = int.Parse(txtCapacidad.Text);
                string rut = txtRut.Text;
                if (rut.Length == 9)//Si el rut tiene solo 9 caracteres se le agrega cero al comienzo para que quede de 10
                {
                    rut = "0" + txtRut.Text;
                }

                Mesa m = new Mesa()
                {
                    capacidad_persona = capacidad,
                    disponibilidad = disponible,
                    asignacion = asignada,
                    rut_empleado = rut
                };

                bool resp = mes.Agregar(m);
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Guardado" : "No Guardado"));
                
                if (resp == true)
                {
                    rb_disponible.Focus();
                   
                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("mesa_guardada");
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
                Mesa.ListaMesa m = (Mesa.ListaMesa)dgLista.SelectedItem;
                int id = m.Número;

                Mesa mesita = new Mesa();
                
                var x = await this.ShowMessageAsync("Eliminar Datos: ",
                         "¿Está Seguro de eliminar la mesa? ",
                        MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                    bool resp = mesita.Eliminar(id);//Entrega id por parametro
                    if (resp == true)//Si el método fue éxitoso muestra el mensaje
                    {
                        await this.ShowMessageAsync("Éxito:",
                          string.Format("Mesa Eliminada"));
                        //Notificación (Actualiza la grilla en tiempo real)
                        NotificationCenter.Notify("mesa_borrada");
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

                if (filecahe["mesa"] != null)
                {
                    Mesa.ListaMesa c = (Mesa.ListaMesa)filecahe["mesa"];
                    //txtRut.Text = c.Rut;

                    txtNombre.Text = c.Empleado;                   
                    txtCapacidad.Text = c.Capacidad;
                    if (c.Disponibilidad == "Disponible")
                    {
                        rb_disponible.IsChecked = true;
                    }
                    if (c.Disponibilidad == "No Disponible")
                    {
                        rb_NoDisponible.IsChecked = true;
                    }


                    if (c.asignacion == "Online")
                    {
                        rbOnLine.IsChecked = true;
                    }
                    if (c.asignacion == "Presencial")
                    {
                        rbPresencial.IsChecked = true;
                    }

                    if (c.Rut_Empleado != null)
                    {
                        txtRut.Text = c.Rut_Empleado;
                                           }
                    else
                    {
                        txtRut.Text = null;
                    }
                  
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
                Mesa.ListaMesa m = (Mesa.ListaMesa)dgLista.SelectedItem;
                txtNum.Text = m.Número.ToString();
                var capLargo = (m.Capacidad.Length - 9);
                txtCapacidad.Text = m.Capacidad.Substring(0,capLargo);
                if (m.Disponibilidad == "Disponible")
                {
                    rb_disponible.IsChecked = true;
                }
                if (m.Disponibilidad == "No Disponible")
                {
                    rb_NoDisponible.IsChecked = true;
                }
                

                if (m.asignacion == "Online")
                {
                    rbOnLine.IsChecked = true;
                }
                if (m.asignacion == "Presencial")
                {
                    rb_NoDisponible.IsChecked = true;
                }
                 

                txtRut.Text = m.Rut_Empleado;
                txtNombre.Text = m.Empleado;

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
