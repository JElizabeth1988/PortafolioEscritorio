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
    /// Lógica de interacción para WindowBodega.xaml
    /// </summary>
    public partial class WindowBodega : MetroWindow
    {
        public WindowBodega()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        //------------RRSS---------------------
        //Face
        private void FacebookButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/profile.php?id=100073371850357");
        }

        //Twitter
        private void TwitterButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/XxiRestaurant");
        }

        //Insta
        private void InstagramButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/sigloxxi.restaurant/");
        }

        //CerrarSesion_Click
        private async void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            var x =
           await this.ShowMessageAsync("Advertencia", "¿Desea cerrar sesión?",
                   MessageDialogStyle.AffirmativeAndNegative);
            if (x == MessageDialogResult.Affirmative)
            {
                Login log = new Login();
                this.Close();
                log.ShowDialog();
            }
            else
            {

            }
        }
        //--------------Productos-----------------
        private void Productos_CLick(object sender, RoutedEventArgs e)
        {
            WPFProducto.ObtenerinstanciaPROD().ShowDialog();
        }
        //-----------Stock--------------------
        private void Stock_Click(object sender, RoutedEventArgs e)
        {
            WPFStock st = new WPFStock();
            st.ShowDialog();
        }
        //------------Recetas-------------------
        private void Recetas_CLick(object sender, RoutedEventArgs e)
        {
            WPFReceta.ObtenerinstanciaREC().ShowDialog();
        }

        private async void Pedido_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("EN CONSTRUCCIÓN:",
                       string.Format("Disculpe las Molestias"));
        }
    }
}
