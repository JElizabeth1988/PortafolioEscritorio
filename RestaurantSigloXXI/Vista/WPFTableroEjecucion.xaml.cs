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
    /// <summary>
    /// Lógica de interacción para WPFTableroEjecucion.xaml
    /// </summary>
    public partial class WPFTableroEjecucion : MetroWindow
    {
        //PatronSingleton--------------------------
        private static WPFTableroEjecucion _instancia;


        public static WPFTableroEjecucion ObtenerinstanciaTE()
        {
            if (_instancia == null)
            {
                _instancia = new WPFTableroEjecucion();
            }

            return _instancia;
        }

        //Clase orden
        Orden ord = new Orden();
        public WPFTableroEjecucion()
        {
            InitializeComponent();
            CargarGrilla();
            
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
                    dgLista.ItemsSource = ord.ListarTablero();
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

        

        private async void btnRut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtRut.Text;
                if (ord.FiltrarRutTablero(rut) != null)
                {
                    dgLista.ItemsSource = ord.FiltrarRutTablero(rut);
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

        private async void btnCambiar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar datos
                Orden.ListaOrden2 i = (Orden.ListaOrden2)dgLista.SelectedItem;
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

               bool resp = ord.CambiarEstado(id, estado );
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
    }
}
