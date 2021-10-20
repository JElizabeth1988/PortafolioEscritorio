﻿using System;
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
    
    public partial class WPFVerPedidosListos : MetroWindow
    {
        
        //Clase orden
        Orden ord = new Orden();

        //PatronSingleton--------------------------
        private static WPFVerPedidosListos _instancia;


        public static WPFVerPedidosListos ObtenerinstanciaORL()
        {
            if (_instancia == null)
            {
                _instancia = new WPFVerPedidosListos();
            }

            return _instancia;
        }
        //----------------------------------------
        //Instanciar la conexión
        OracleConnection conn = null;

        public WPFVerPedidosListos()
        {
            InitializeComponent();
            //Inicializar datePicker en la fecha actual
            dpFecha.SelectedDate = DateTime.Now;//Día actual
           
            //Cargar Grilla
            CargarGrilla();

        }

        //*********Cargar Grilla***************
        private void CargarGrilla()
        {
            try
            {
                //Trae la lista del método Listar
                dgLista.ItemsSource = ord.Listar();
                dgLista.Items.Refresh();
            }
            catch (Exception ex)
            {

                Logger.Mensaje(ex.Message);
            }

        }

        //**********Botones********************
        //---------Botón Refrescar-----------------------------------
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            txtFiltroRut.Clear();
            dpFecha.SelectedDate = DateTime.Now;
            CargarGrilla();
        }
        //---------FiltroFecha------------------------------------------
        private async void btnFiltroFecha_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String fecha = dpFecha.Text;
                if (ord.FiltrarFecha(fecha) != null)
                {
                    dgLista.ItemsSource = ord.FiltrarFecha(fecha);
                }
                else
                {
                    dgLista.Columns[0].Visibility = Visibility.Visible;
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Pedidos:");
                    dt.Rows.Add("No hay información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    txtFiltroRut.Clear();
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
        //---------Filtro Rut cliente----------------------------
        private async void btnFiltro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtFiltroRut.Text;
                if (ord.FiltrarRut(rut) !=null)
                {
                    dgLista.ItemsSource = ord.FiltrarRut(rut);
                }
                else
                {
                    dgLista.Columns[0].Visibility = Visibility.Visible;
                    dgLista.ItemsSource = null;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Pedidos:");
                    dt.Rows.Add("No hay información relacionada a su búsqueda");
                    dgLista.ItemsSource = dt.DefaultView;
                    txtFiltroRut.Clear();
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

       //-----Botón Salir--------------------------------- 
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

             

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Parar Singleton
            _instancia = null;
        }

        
    }
}
