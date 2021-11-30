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
    /// <summary>
    /// Lógica de interacción para WPFPago.xaml
    /// </summary>
    public partial class WPFPago : MetroWindow
    {
        //PatronSingleton--------------------------
        public static WPFPago _instancia;

        public static WPFPago ObtenerinstanciaPAG()
        {
            if (_instancia == null)
            {
                _instancia = new WPFPago();
            }

            return _instancia;
        }
        //----------------------------------------

        Pago pag = new Pago();
        Boleta bo = new Boleta();

        public WPFPago()
        {
            InitializeComponent();
            txtTotal.Text = "0";
            txtDcto.Text = "0";
            txtPagado.Text = "0";
            txtTotal.Focus();
            btnGuardar.Visibility = Visibility.Visible;
            btnBoleta.Visibility = Visibility.Hidden;


            CargarGrilla();
            NotificationCenter.Subscribe("agregado", CargarGrilla);

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

        //---------------Cargar Grilla
        private void CargarGrilla()
        {
            try
            {
                // Dispatcher invoke: Permite ejecutar una acción de forma asincrónica
                //desde un subproceso o desde otra ventana (es un método q llama a una acción)
                //(() => { }); función anónima
                Dispatcher.Invoke(() => {
                    dgLista.ItemsSource = pag.Listar();
                    dgLista.Items.Refresh();
                });
            }
            catch (Exception ex)
            {
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

        //------------Limpiar-------------------------------------------
        //----Método limpiar
        private void Limpiar()
        {
            txtTotal.Text = "0";
            txtDcto.Text = "0";
            txtPagado.Text = "0";
            txtVuelto.Text = "0";
            txtRut.Clear();
            txtNombre.Clear();
            txtTotal.Clear();
            txtPedido.Clear();

            btnGuardar.Visibility = Visibility.Visible;
            btnBoleta.Visibility = Visibility.Hidden;

            //-------------------------------------------
            //boleta
            lblNumero.Content = "-";
            lblEmpleado.Content = "-";
            lblFecha.Content = "-";
            lblHora.Content = "-";
            lblPedido.Content = "-";            

            lblSubTotal.Content = "-";
            lblIva.Content = "-";
            lblPropina.Content = "-";
            lblDcto.Content = "-";
            lblTotal.Content = "-";
            lblMonto.Content = "-";
            lblVuelto.Content = "-";
            lblMesa.Content = "-";

        }

        //----Botón limpiar
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();

        }

        

        private void btnPasar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pago.ListaPedido m = (Pago.ListaPedido)dgLista.SelectedItem;
                txtPedido.Text = m.id.ToString();
                txtRut.Text = m.rut_cliente;
                txtNombre.Text = m.cliente;
                //total
                var totLargo = (m.Total.Length - 2);
                txtTotal.Text = m.Total.Substring(2, totLargo);
                //dcto                
                var LDes = (m.descuento.Length - 2);
                txtDcto.Text = m.descuento.Substring(2, LDes);                                             


            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
            }
        }



        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {           

            //Parar Singleton
            _instancia = null;
        }

        private async void btnBoleta_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                bo.ListarBoleta();
                if (bo != null)//Si la lista no esta vacía entrego parámetros a los labels
                {                    
                    lblNumero.Content = bo.numero;                    
                    lblFecha.Content = bo.Fecha;
                    lblHora.Content = bo.hora;
                    lblPropina.Content = bo.propina;
                    lblIva.Content = bo.iva;
                    lblTotal.Content = bo.Total;
                    lblSubTotal.Content = bo.Subtotal;
                    lblDcto.Content = bo.dcto;
                    lblMonto.Content = bo.efectivo;
                    lblVuelto.Content = bo.vuelto;
                    lblMesa.Content = bo.mesa.ToString();
                    lblEmpleado.Content = bo.empleado;
                    lblPedido.Content = bo.pedido;                  

                    
                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                        string.Format("No se encontraron resultados!"));
                }

            }
            catch (Exception ex)
            {

                Logger.Mensaje(ex.Message);
            }
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(txtVuelto.Text) >= 0)
                {
                    int valor = int.Parse(txtTotal.Text);
                    int efectivo = int.Parse(txtPagado.Text);
                    int dcto = int.Parse(txtDcto.Text);
                    string rut = txtRut.Text;
                    int pedido = int.Parse(txtPedido.Text);

                    Pago p = new Pago()
                    {
                        valor_pago = valor,
                        monto_pagado = efectivo,
                        descuento = dcto,
                        rut_cliente = rut,
                        id_pedido = pedido
                    };

                    bool resp = pag.Agregar(p);
                    await this.ShowMessageAsync("Mensaje:",
                          string.Format(resp ? "Guardado" : "No Guardado"));
                    if (resp == true)
                    {
                        btnBoleta.Visibility = Visibility.Visible;
                        btnGuardar.Visibility = Visibility.Hidden;
                        NotificationCenter.Notify("agregado");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("El monto pagado no puede ser menor al total"));
                }
                

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos", ex));
                Logger.Mensaje(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtPagado_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                txtVuelto.Text = (int.Parse(txtPagado.Text) - int.Parse(txtTotal.Text)).ToString();
                if (txtPagado.Text == "" || txtPagado.Text == "0")
                {
                    txtVuelto.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
            }

            
        }
    }
}
