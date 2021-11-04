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
    /// Lógica de interacción para WPFPedidoProveedor.xaml
    /// </summary>
    public partial class WPFPedidoProveedor : MetroWindow
    {
        //PatronSingleton--------------------------
        private static WPFPedidoProveedor _instancia;


        public static WPFPedidoProveedor ObtenerinstanciaPED()
        {
            if (_instancia == null)
            {
                _instancia = new WPFPedidoProveedor();
            }

            return _instancia;
        }
        public WPFPedidoProveedor()
        {
            InitializeComponent();
        }

        public void CargarGrilla()
        {

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSolicitar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
