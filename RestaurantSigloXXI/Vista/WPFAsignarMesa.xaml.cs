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

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

using BibliotecaNegocio;


using Oracle.ManagedDataAccess.Client;

using System.Data;

namespace Vista
{    
    public partial class WPFAsignarMesa : MetroWindow
    {
        //PatronSingleton--------------------------
        private static WPFAsignarMesa _instancia;

        public static WPFAsignarMesa ObtenerinstanciaAM()
        {
            if (_instancia == null)
            {
                _instancia = new WPFAsignarMesa();
            }

            return _instancia;
        }
        //----------------------------------------


        Mesa mes = new Mesa();
        Cliente cli = new Cliente();
        Atencion ate = new Atencion();

        private WPFAsignarMesa()
        {
            InitializeComponent();
            CargarGrilla();
            //Cuando se guarda una mesa nueva se refresca la grilla
            NotificationCenter.Subscribe("mesa_asignada", CargarGrilla);            

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
                    dgLista.ItemsSource = mes.Listar2();
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

        private async void btnRut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rut = txtRut.Text;
                if (cli.BuscarCL(rut) != null)
                {
                    txtNombre.Text = cli.primer_nom_cli;
                    txtRut.IsEnabled = false;
                    btnCrear.Visibility = Visibility.Hidden;
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
                      string.Format("Error al Buscar la Información"));
                Logger.Mensaje(ex.Message);

            }
        }
        //-----Limpiar----------------------------------------
        private void Limpiar()
        {
            txtRut.Clear();
            txtRut.IsEnabled = true;
            txtNombre.Clear();
            btnCrear.Visibility = Visibility.Visible;
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

       
        //------------------------------------------------------

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Parar Singleton
            _instancia = null;
        }

        private async void btnSalir_Click(object sender, RoutedEventArgs e)
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

        private void btnNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            WPFCliente2.ObtenerinstanciaCLI2().ShowDialog();
        }

        private async void btnAsignar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar datos
                Mesa.ListaMesa i = (Mesa.ListaMesa)dgLista.SelectedItem;                
                int mesa = i.Número;
                string rut = txtRut.Text;

                Atencion a = new Atencion()
                {
                    rut_cliente = rut,
                    mesa = mesa

                };
                bool resp = ate.asignarMesa(a);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Realizado" : "No Realizado"));
                if (resp == true)
                {
                    Limpiar();
                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("mesa_asignada");
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
                     string.Format("Error al Asignar"));
                /*MessageBox.Show("Error al Actualizar");*/
                Logger.Mensaje(ex.Message);

            }
        }

        private void btnPregunta_Click(object sender, RoutedEventArgs e)
        {
            WPFListadoCliente cliente = new WPFListadoCliente(this);
            cliente.ShowDialog();
        }

        private async void btnFiltroAsig_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                string asi = null;
                if (RbOnline.IsChecked == true)
                {
                    asi = "Online";
                }
                else
                {
                    asi = "Presencial";
                }
                if (mes.FiltrarAsign(asi) != null)
                {
                    dgLista.ItemsSource = mes.FiltrarAsign(asi);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Mesas:");
                    dt.Rows.Add("No existe información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;

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

        private async void btnFiltroDisp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string dis = "Disponible";
                if (mes.FiltrarDisp(dis) != null)
                {
                    dgLista.ItemsSource = mes.FiltrarDisp(dis);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Mesas:");
                    dt.Rows.Add("No existe información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;

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
    }
}
