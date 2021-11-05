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

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para WPFStock.xaml
    /// </summary>
    public partial class WPFStock : MetroWindow
    {
        public WPFStock()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        //------Productos
        private void Productos_Click(object sender, RoutedEventArgs e)
        {

        }
        //----Bebidas
        private void Bebidas_Click(object sender, RoutedEventArgs e)
        {
           // WPFStockBebida.ObtenerinstanciaSBE().ShowDialog();
        }
        //--------Platos
        private void Platos_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
