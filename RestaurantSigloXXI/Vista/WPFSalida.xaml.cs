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
    public partial class WPFSalida : MetroWindow
    {
        //PatronSingleton--------------------------
        private static WPFSalida _instancia;


        public static WPFSalida ObtenerinstanciaSA()
        {
            if (_instancia == null)
            {
                _instancia = new WPFSalida();
            }

            return _instancia;
        }
        //----------------------------------------

        Atencion at = new Atencion();

        public WPFSalida()
        {
            InitializeComponent();

            btnSalida.Visibility = Visibility.Hidden;//No se ve hasta que se presenta la información
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
                btnSalida.Visibility = Visibility.Hidden;
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
                int numero = int.Parse(txtCodigo.Text);
                if (at.Buscar(numero) != null)
                {
                    dgLista.ItemsSource = at.Buscar(numero);
                    //Botón se ve
                    btnSalida.Visibility = Visibility.Visible;
                }
                else
                {
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Resultado:");
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
                Atencion i = (Atencion)dgLista.SelectedItem;
                string rut = i.rut_cliente;
                int mesa = i.mesa;

                Atencion a = new Atencion()
                {
                    rut_cliente = rut,
                    mesa = mesa

                };
                bool resp = at.Salida(a);
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

        private void dgLista_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (this.dgLista.Columns != null)
            {
                this.dgLista.Columns[0].Visibility = Visibility.Collapsed;
            }
        }
    }
}
