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

namespace Vista
{
   
    public partial class WPFUtilidades : MetroWindow
    {
        //PatronSingleton--------------------------
        public static WPFUtilidades _instancia;

        public static WPFUtilidades ObtenerinstanciaUTI()
        {
            if (_instancia == null)
            {
                _instancia = new WPFUtilidades();
            }

            return _instancia;
        }
        //----------------------------------------

        Ingreso ing = new Ingreso();
        Egreso eg = new Egreso();
        public WPFUtilidades()
        {
            InitializeComponent();

            dpDesdeE.SelectedDate = DateTime.Today;
            dpDesdeI.SelectedDate = DateTime.Today;
            dpHastaE.SelectedDate = DateTime.Today;
            dpHastaI.SelectedDate = DateTime.Today;

            btnCalcIng.Visibility = Visibility.Hidden;
            btnCalcEgre.Visibility = Visibility.Hidden;
        }
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            //Parar Singleton
            _instancia = null;
        }

        private async void btnFiltroIngreso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime desde = dpDesdeI.SelectedDate.Value;
                DateTime hasta = dpHastaI.SelectedDate.Value;

                if (ing.Listar(desde,hasta) != null)
                {
                    dgListaIng.ItemsSource = ing.Listar(desde, hasta);
                    btnCalcIng.Visibility = Visibility.Visible;
                }
                else
                {
                    dgListaIng.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Ingresos:");
                    dt.Rows.Add("No Existe información relacionada a su búsqueda");
                    dgListaIng.ItemsSource = dt.DefaultView;

                    btnCalcIng.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al filtrar la Información"));
                Logger.Mensaje(ex.Message);
            }
        }

        private async void btnFiltroEgreso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime desde = dpDesdeE.SelectedDate.Value;
                DateTime hasta = dpHastaE.SelectedDate.Value;

                if (eg.Listar(desde, hasta) != null)
                {
                    dgListaEgr.ItemsSource = eg.Listar(desde, hasta);
                    btnCalcEgre.Visibility = Visibility.Visible;
                }
                else
                {
                    dgListaEgr.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Egresos:");
                    dt.Rows.Add("No Existe información relacionada a su búsqueda");
                    dgListaEgr.ItemsSource = dt.DefaultView;

                    btnCalcEgre.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al filtrar la Información"));
                Logger.Mensaje(ex.Message);
            }
        }

        private void dgListaIng_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (this.dgListaIng.Columns != null)
            {
                this.dgListaIng.Columns[0].Visibility = Visibility.Collapsed;
            }
        }

        private void dgListaEgr_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (this.dgListaEgr.Columns != null)
            {
                this.dgListaEgr.Columns[0].Visibility = Visibility.Collapsed;
            }
        }

        private void btnCalcIngreso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime desde = dpDesdeI.SelectedDate.Value;
                DateTime hasta = dpHastaI.SelectedDate.Value;

                string total = ing.Total(desde, hasta).ToString();
                lblIngresos.Content = "$ "+total;
            }
            catch (Exception ex)            {

                Logger.Mensaje(ex.Message);
            }
        }
        private void btnCalcEgreso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime desde = dpDesdeE.SelectedDate.Value;
                DateTime hasta = dpHastaE.SelectedDate.Value;
                string total = eg.Total(desde, hasta).ToString();

                lblEgresos.Content = "$ "+total;

            }
            catch (Exception ex)
            {

                Logger.Mensaje(ex.Message);
            }
        }
    }
}
