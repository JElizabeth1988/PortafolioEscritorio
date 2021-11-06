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

using System.Globalization;

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

    public partial class WPFAgenda : MetroWindow
    {
        //PatronSingleton--------------------------
        public static WPFAgenda _instancia;

        public static WPFAgenda ObtenerinstanciaAGE()
        {
            if (_instancia == null)
            {
                _instancia = new WPFAgenda();
            }

            return _instancia;
        }
        //----------------------------------------

        //Hilo para cache
        Thread hilo = null;

        //Instanciar BD
        OracleConnection conn = null;

        //Traer clase Agenda
        Agenda horario = new Agenda();

        //Inicializar txthora y minuto
        int horita = int.Parse(DateTime.Now.Hour.ToString()),
           minutin = 00;
        

        public WPFAgenda()
        {
            InitializeComponent();
            string hori = DateTime.Now.Hour.ToString();
            if (hori.Length < 2)
            {
                txtHora.Text = "0" + hori;
            }
            else
            {
                txtHora.Text = hori;
            }
            txtMinuto.Text = "00";
            /*string minu = DateTime.Now.Minute.ToString();//Minuto
            if (minu.Length < 2)
            {
                txtMinuto.Text = "0" + minu;
            }
            else
            {
                txtMinuto.Text = minu;
            }*/
            
            dpFiltro.SelectedDate = DateTime.Today;

            dpFecha.DisplayDate = DateTime.Now;
            dpFecha.SelectedDate = DateTime.Now;//Día actual

            btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve
            btnGuardar.Visibility = Visibility.Visible;

            //---Llenar ComboBox            
            foreach (Mesa.ListaMesaCBO item in new Mesa.ListaMesaCBO().ListarCbo())
            {
                cboMesa.Items.Add(item.Número.ToString());
            }
            //Inicializar comboBox
            cboMesa.SelectedIndex = 0;
            dpFecha.Focus();

            CargarGrilla();
            //Cuando se guarda una bebida nueva se refresca la grilla
            NotificationCenter.Subscribe("agenda_guardada", CargarGrilla);
            NotificationCenter.Subscribe("agenda_actualizada", CargarGrilla);
            NotificationCenter.Subscribe("agenda_borrada", CargarGrilla);

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

        //---Método generar respaldo------------------
        private void generaRespaldo()
        {
            Dispatcher.Invoke(() =>
            {

                //Llama a la clase cliente donde se gusradarán los datos
                Agenda.ListaAgenda ag = new Agenda.ListaAgenda();

                int id = 0;
                if (int.TryParse(lblId.Content.ToString(), out id))
                {
                    ag.Id = int.Parse(lblId.Content.ToString());
                }
                if (dpFecha.SelectedDate != null)
                {
                    ag.fecha = dpFecha.DisplayDate.ToString();
                }
                

                if (rbSi.IsChecked == true)
                {
                    ag.disponibilidad = "Disponible";
                }
                if (RbNo.IsChecked == true)
                {
                    ag.disponibilidad = "No Disponible";
                }

                if (cboMesa.SelectedValue != null)
                {
                    ag.Mesa = int.Parse(cboMesa.Text);
                }
                string ho = null;
                if (txtHora.Text.Length > 2)
                {
                    ho = "0" + txtHora.Text;
                }
                else
                {
                    ho = txtHora.Text;
                }
                string mi = null;
                if (txtMinuto.Text.Length > 2)
                {
                    mi = "0" + txtMinuto.Text;
                }
                else
                {
                    mi = txtMinuto.Text;
                }
                if (txtHora.Text != null)
                {
                    ag.Desde = ho + ":" + mi;
                }

                //Proceso de respaldo
                //Con la ampolleta agregó el using Runtime.Caching
                FileCache filecahe = new FileCache(new ObjectBinder());

                String hora = DateTime.Now.ToString("dd-MM-yy HH:mm:ss");

                filecahe["agenda"] = ag;
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

        //---------------Cargar Grilla--------------------
        private void CargarGrilla()
        {
            try
            {
                // Dispatcher invoke: Permite ejecutar una acción de forma asincrónica
                //desde un subproceso o desde otra ventana (es un método q llama a una acción)
                //(() => { }); función anónima
                Dispatcher.Invoke(() =>
                {
                    dgLista.ItemsSource = horario.Listar();
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

        //--------------------------------------------------------------------
        //---------------Botones hora y minuto--------------------------------
        //--------------------------------------------------------------------
        private void btnMasHora_Click(object sender, RoutedEventArgs e)
        {
            horita++;
            if (horita == 24)
            {
                horita = 0;
            }
            if (horita.ToString().Length < 2)
            {
                txtHora.Text = "0"+horita.ToString();
            }
            else
            {
                txtHora.Text = horita.ToString();
            }
            
        }

        private void btnMenosHora_Click(object sender, RoutedEventArgs e)
        {
            horita--;
            if (horita < 0)
            {
                horita = 23;
            }
            if (horita.ToString().Length < 2)
            {
                txtHora.Text = "0" + horita.ToString();
            }
            else
            {
                txtHora.Text = horita.ToString();
            }
        }

        private void btnMasMin_Click(object sender, RoutedEventArgs e)
        {
            minutin++;
            if (minutin == 60)
            {
                minutin = 0;
            }
            if (minutin.ToString().Length < 2)
            {
                txtMinuto.Text = "0" + minutin.ToString();
            }
            else
            {
                txtMinuto.Text = minutin.ToString();
            }
           
        }

        private void btnMenosMin_Click(object sender, RoutedEventArgs e)
        {
            minutin--;
            if (minutin < 0)
            {
                minutin = 59;
            }
            if (minutin.ToString().Length < 2)
            {
                txtMinuto.Text = "0" + minutin.ToString();
            }
            else
            {
                txtMinuto.Text = minutin.ToString();
            }

        }
        //----------------------------------------------------
        //-------Metodo limpiar-------------------
        public void Limpiar()
        {
            lblId.Content = "";
            dpFecha.DisplayDate = DateTime.Now;
            dpFecha.SelectedDate = DateTime.Now;
            dpFiltro.SelectedDate = DateTime.Today;
            string hori = DateTime.Now.Hour.ToString();
            if (hori.Length < 2)
            {
                txtHora.Text = "0" + hori;
            }
            else
            {
                txtHora.Text = hori;
            }
            txtMinuto.Text = "00";
           /* string minu = DateTime.Now.Minute.ToString();//Minuto
            if (minu.Length < 2)
            {
                txtMinuto.Text = "0" + minu;
            }
            else
            {
                txtMinuto.Text = minu;
            }*/
            rbSi.IsChecked = true;
            RbNo.IsChecked = false;
            cboMesa.SelectedIndex = 0;
            dpFecha.Focus();

            btnGuardar.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Hidden;

            //Limpiar cache
            FileCache filecahe = new FileCache(new ObjectBinder());
            filecahe.Remove("agenda", null);
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
        //-------Botón Refrescar------------------------------------
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
            dpFiltro.SelectedDate = DateTime.Today;
        }

        //----------Botón Guardar-----------------------------------
        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dpFecha.SelectedDate.Value.Date >= DateTime.Today )
                {
                    DateTime Fecha = dpFecha.SelectedDate.Value.Date;
                    //------------------------------------
                    string hour = txtHora.Text;
                    if (hour.Length < 2)
                    {
                        hour = "0" + txtHora.Text;//agrego un cero antes si es de 1 dígito
                    }
                    string minuto = txtMinuto.Text;
                    if (minuto.Length < 2)
                    {
                        minuto = "0" + txtMinuto.Text;
                    }
                    string HoraDesde = hour + ":" + minuto;
                    //--------------------------
                    int suma = (int.Parse(txtHora.Text) + 1);
                    string horaSumada = suma.ToString();
                    if (horaSumada == "24")
                    {
                        horaSumada = "00"; if (horaSumada == "24")
                        {
                            horaSumada = "00";
                        }
                    }
                    if (horaSumada.Length < 2)
                    {
                        horaSumada = "0" + horaSumada;//agrego un cero antes si es de 1 dígito
                    }

                    string HoraHasta = horaSumada + ":" + minuto;

                    string disponible = null;
                    if (rbSi.IsChecked == true)
                    {
                        disponible = "Disponible";
                    }
                    if (RbNo.IsChecked == true)
                    {
                        disponible = "No Disponible";
                    }

                    int mesa = int.Parse(cboMesa.SelectedItem.ToString());

                    Agenda agi = new Agenda()
                    {
                        fecha = Fecha,
                        hora_desde = HoraDesde,
                        hora_hasta = HoraHasta,
                        disponibilidad = disponible,
                        num_mesa = mesa

                    };

                    bool resp = horario.Agregar(agi);
                    await this.ShowMessageAsync("Mensaje:",
                          string.Format(resp ? "Guardado" : "No Guardado"));

                    //-----------------------------------------------------------------------------------------------
                    //MOSTRAR LISTA DE ERRORES (validación de la clase)
                    if (resp == false)//If para que no muestre mensaje en blanco en caso de éxito
                    {
                        DaoErrores de = agi.retornar();
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
                        NotificationCenter.Notify("agenda_guardada");
                        dpFecha.Focus();
                        Limpiar();
                    }
                   
                }
                else
                {
                    await this.ShowMessageAsync("Error:",
                     string.Format("La fecha no debe ser anterior a la fecha actual"));
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
                DaoErrores de = horario.retornar();
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
                int id = int.Parse(lblId.Content.ToString());
                DateTime Fecha = dpFecha.SelectedDate.Value.Date;
                //------------------------------------
                string hour = txtHora.Text;
                if (hour.Length < 2)
                {
                    hour = "0" + txtHora.Text;//agrego un cero antes si es de 1 dígito
                }
                string minuto = txtMinuto.Text;
                if (minuto.Length < 2)
                {
                    minuto = "0" + txtMinuto.Text;
                }
                string HoraDesde = hour + ":" + minuto;
                //--------------------------
                int suma = (int.Parse(txtHora.Text) + 1);
                string horaSumada = suma.ToString();
                if (horaSumada == "24")
                {
                    horaSumada = "00";
                }
                if (horaSumada.Length < 2)
                {
                    horaSumada = "0" + horaSumada;//agrego un cero antes si es de 1 dígito
                }

                string HoraHasta = horaSumada + ":" + minuto;
                string disponible = null;
                if (rbSi.IsChecked == true)
                {
                    disponible = "Disponible";
                }
                if (RbNo.IsChecked == true)
                {
                    disponible = "No Disponible";
                }

                int mesa = int.Parse(cboMesa.SelectedItem.ToString());

                Agenda agi = new Agenda()
                {
                    id_agenda = id,
                    fecha = Fecha,
                    hora_desde = HoraDesde,
                    hora_hasta = HoraHasta,
                    disponibilidad = disponible,
                    num_mesa = mesa

                };
                bool resp = horario.Actualizar(agi);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Actualizado" : "No Actualizado"));


                //-----------------------------------------------------------------------------------------------
                if (resp == true)
                {
                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("agenda_actualizada");
                    Limpiar();
                    dpFecha.Focus();
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
                Agenda.ListaAgenda la = (Agenda.ListaAgenda)dgLista.SelectedItem;
                int id = la.Id;

                Agenda agendin = new Agenda();

                var x = await this.ShowMessageAsync("Eliminar Datos: ",
                         "¿Está seguro de eliminar el registro? ",
                        MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                    bool resp = agendin.Eliminar(id);//Entrega id por parametro
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
                Agenda.ListaAgenda la = (Agenda.ListaAgenda)dgLista.SelectedItem;
                lblId.Content = la.Id.ToString();
                var cultureInfo = new CultureInfo("es-ES");
                DateTime fechita = DateTime.Parse(la.fecha, cultureInfo);

                dpFecha.SelectedDate = fechita;
                dpFecha.DisplayDate = fechita;

                if (la.disponibilidad == "Disponible")
                {
                    rbSi.IsChecked = true;
                }
                else
                {
                    RbNo.IsChecked = true;
                }
                txtHora.Text = la.Desde.Substring(0, 2);
                txtMinuto.Text = la.Desde.Substring(3, 2);
                cboMesa.Text = la.Mesa.ToString();

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

                if (filecahe["agenda"] != null)
                {
                    Agenda.ListaAgenda i = (Agenda.ListaAgenda)filecahe["agenda"];

                    lblId.Content = i.Id.ToString();
                    var cultureInfo = new CultureInfo("es-ES");
                    DateTime fechita = DateTime.Parse(i.fecha, cultureInfo);

                    dpFecha.SelectedDate = fechita;
                    dpFecha.DisplayDate = fechita;
                    if (i.disponibilidad == "Disponible")
                    {
                        rbSi.IsChecked = true;
                    }
                    else
                    {
                        RbNo.IsChecked = true;
                    }
                    if (i.Desde != null)
                    {
                        txtHora.Text = i.Desde.Substring(0, 2);
                        txtMinuto.Text = i.Desde.Substring(3, 2);
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

        //---Filtro por fecha--------------------------
        private async void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime fech = dpFiltro.SelectedDate.Value;
                if (horario.Filtrar(fech) != null)
                {
                    dgLista.ItemsSource = horario.Filtrar(fech);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("");
                    dt.Columns.Add("Agenda:");
                    dt.Rows.Add(" ","No existe información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    dpFiltro.SelectedDate = DateTime.Today;

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

        //------------Evento que oculta la primera columna (id) para que no sea modificada
        private void dgLista_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (this.dgLista.Columns != null)
            {
                this.dgLista.Columns[0].Visibility = Visibility.Collapsed;
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
