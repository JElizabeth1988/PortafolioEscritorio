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
    
    public partial class WPFPedidos : MetroWindow
    {
        //PatronSingleton--------------------------
        private static WPFPedidos _instancia;


        public static WPFPedidos ObtenerinstanciaPED()
        {
            if (_instancia == null)
            {
                _instancia = new WPFPedidos();
            }

            return _instancia;
        }

        //Clase orden
        Orden ord = new Orden();

        //----------------------------------------
        public WPFPedidos()
        {
            InitializeComponent();
            CargarGrilla();
            dpFecha.SelectedDate = DateTime.Now;
            //Cuando se guarda una mesa nueva se refresca la grilla
            NotificationCenter.Subscribe("orden_cambiada", CargarGrilla);

        }

        private void CargarGrilla()
        {
            try
            {
                // Dispatcher invoke: Permite ejecutar una acción de forma asincrónica
                //desde un subproceso o desde otra ventana (es un método q llama a una acción)
                //(() => { }); función anónima
                Dispatcher.Invoke(() => {
                    dgLista.ItemsSource = ord.Listar2();
                    dgLista.Items.Refresh();
                });
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message); throw;
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Parar Singleton
            _instancia = null;
        }

        //---Filtro x fecha-----------------------------
        private async  void btnFecha_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String fecha = dpFecha.Text;
                if (ord.FiltrarFecha2(fecha) != null)
                {
                    dgLista.ItemsSource = ord.FiltrarFecha2(fecha);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("");
                    dt.Columns.Add("Órdenes:");
                    dt.Rows.Add("", "No hay información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    txtRut.Clear();
                    dpFecha.SelectedDate = DateTime.Now;
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
        //Filtro x rut------------------------------
        private async void btnRut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtRut.Text;
                if (ord.FiltrarRut2(rut) != null)
                {
                    dgLista.ItemsSource = ord.FiltrarRut2(rut);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("");
                    dt.Columns.Add("Órdenes:");
                    dt.Rows.Add("", "No hay información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    txtRut.Clear();
                    dpFecha.SelectedDate = DateTime.Now;
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
        //---Cancelar
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

        //----CAMBIAR ESTADO DEL PEDIDO
        private async void btnCambiar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar datos
                Orden.ListaOrden i = (Orden.ListaOrden)dgLista.SelectedItem;
                int id = i.Id;
                string estado = null;
                if (rbListo.IsChecked == true)
                {
                    estado = "Listo";
                }
                else
                {
                    estado = "En Preparación";
                }
                
                bool resp = ord.CambiarEstado(id, estado);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Realizado" : "No Realizado"));
                if (resp == true)
                {
                    //CargarGrilla();
                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("orden_cambiada");
                }


            }
            catch (ArgumentException exa)//mensajes de reglas de negocios
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format((exa.Message)));
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:",
                     string.Format("Debe seleccionar un registro"));
                /*MessageBox.Show("Error al Actualizar");*/
                Logger.Mensaje(ex.Message);

            }
        }
        //-------------Botón refrescar
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
        }
        //Esconder id en gráfica-----------------------------
        private void dgLista_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (this.dgLista.Columns != null)
            {
                this.dgLista.Columns[0].Visibility = Visibility.Collapsed;
            }
        }

        
    }
}
