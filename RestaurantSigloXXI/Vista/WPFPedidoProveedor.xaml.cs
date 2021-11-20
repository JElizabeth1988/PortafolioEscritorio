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
    /// Lógica de interacción para WPFPedidoProveedor.xaml
    /// </summary>
    public partial class WPFPedidoProveedor : MetroWindow
    {
        public WPFPedidoProveedor()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        PedidoProveedor ped = new PedidoProveedor();

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            
                
        }

        private void Pedido_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
