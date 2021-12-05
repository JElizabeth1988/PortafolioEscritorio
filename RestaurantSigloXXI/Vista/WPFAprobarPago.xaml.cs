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
    /// Lógica de interacción para WPFAprobarPago.xaml
    /// </summary>
    public partial class WPFAprobarPago : MetroWindow
    {
        //PatronSingleton--------------------------
        private static WPFAprobarPago _instancia;


        public static WPFAprobarPago ObtenerinstanciaAPA()
        {
            if (_instancia == null)
            {
                _instancia = new WPFAprobarPago();
            }

            return _instancia;
        }

        Pedido pe = new Pedido();
        //----------------------------------------
        private WPFAprobarPago()
        {
            InitializeComponent();
            //btnAprobar.Visibility = Visibility.Hidden;//No se ve hasta que se presenta la información
            CargarGrilla();

            //Cuando se guarda una mesa nueva se refresca la grilla
            NotificationCenter.Subscribe("estado_cambiado", CargarGrilla);

            //llenar comboBox
            foreach (Mesa.ListaMesaCBO item in new Mesa.ListaMesaCBO().ListarCbo())
            {
                cbMesa.Items.Add(item.Número.ToString());
            }
            //Inicializar comboBox
            cbMesa.SelectedIndex = 0;
            cbMesa.Focus();
            
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Parar Singleton
            _instancia = null;
        }
        private void CargarGrilla()
        {
            try
            {
                // Dispatcher invoke: Permite ejecutar una acción de forma asincrónica
                //desde un subproceso o desde otra ventana (es un método q llama a una acción)
                //(() => { }); función anónima
                Dispatcher.Invoke(() => {
                    dgLista.ItemsSource = pe.Listar();
                    dgLista.Items.Refresh();
                });
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message); throw;
            }
        }
        //----Botón Salir-------------------------------------------
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
        //---filtro
        private async void btnCodigo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = int.Parse(cbMesa.Text);
                if (pe.Filtrar(num) != null)
                {
                    dgLista.ItemsSource = pe.Filtrar(num);
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("");
                    dt.Columns.Add("Pedidos:");
                    dt.Rows.Add("", "No hay información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    cbMesa.SelectedItem = 0;

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

        private async void btnNotificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar datos
                Pedido.ListaPedido i = (Pedido.ListaPedido)dgLista.SelectedItem;
                int id = i.id;

                bool resp = pe.CambiarEstado(id);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Realizado" : "No Realizado"));
                if (resp == true)
                {
                    //CargarGrilla();
                    //Notificación (Actualiza la grilla en tiempo real)
                    NotificationCenter.Notify("estado_cambiado");
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
