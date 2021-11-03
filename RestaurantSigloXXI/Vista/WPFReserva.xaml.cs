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

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

using BibliotecaNegocio;


using Oracle.ManagedDataAccess.Client;

using System.Data;


namespace Vista
{

    public partial class WPFReserva : MetroWindow
    {
        //PatronSingleton--------------------------
        private static WPFReserva _instancia;


        public static WPFReserva ObtenerinstanciaRE()
        {
            if (_instancia == null)
            {
                _instancia = new WPFReserva();
            }

            return _instancia;
        }
        //----------------------------------------


        Reserva rs = new Reserva();
        Atencion at = new Atencion();

        public WPFReserva()
        {
            InitializeComponent();

            //Botón no se ve
            btnIngreso.Visibility = Visibility.Hidden;
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Parar Singleton
            _instancia = null;
        }

       
        //----Botón Salir-------------------------------------------
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //-----Refrescar------------------------------------------
        private void limpiar()
        {
            try
            {
                dgLista.Columns.Clear();
                //Botón no se ve
                btnIngreso.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private async void btnCodigo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int codigo = int.Parse(txtCodigo.Text);
                if (rs.BuscarCodigo(codigo) != null)
                {
                    dgLista.ItemsSource = rs.BuscarCodigo(codigo);
                    //Botón se ve
                    btnIngreso.Visibility = Visibility.Visible;
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Reservas:");
                    dt.Rows.Add("No Existe información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    txtCodigo.Clear();

                }

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al filtrar la Información"));
                Logger.Mensaje(ex.Message);
                
            }
        }

        private async void btnRut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rut = txtRut.Text;
                if (rs.BuscarRut(rut) != null)
                {
                    dgLista.ItemsSource = rs.BuscarRut(rut);
                    //Botón se ve
                    btnIngreso.Visibility = Visibility.Visible;
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Reservas:");
                    dt.Rows.Add("No Existe información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    txtCodigo.Clear();

                }

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al filtrar la Información"));
                Logger.Mensaje(ex.Message);

            }
        }

        //-----Notificar ingreso de cliente al local-------------------------
        private async void btnNotificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar datos
                Reserva.ListaReserva i = (Reserva.ListaReserva)dgLista.SelectedItem;
                string rut = i.rut_cliente;
                int mesa = i.Mesa;
                int reserva = i.Id;

                Atencion a = new Atencion()
                {
                    rut_cliente = rut,
                    mesa = mesa

                };

                Reserva r = new Reserva()
                {
                    id_reserva = reserva
                };
                bool resp = at.Entrada(a, r);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Realizado" : "No Realizado"));
                if (resp == true)
                {
                    limpiar();
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
                     string.Format("Error al Notificar"));
                /*MessageBox.Show("Error al Actualizar");*/
                Logger.Mensaje(ex.Message);

            }
        }
    }
}

