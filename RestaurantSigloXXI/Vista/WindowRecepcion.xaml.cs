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
    /// Lógica de interacción para WindowRecepcion.xaml
    /// </summary>
    public partial class WindowRecepcion : MetroWindow
    {
        public WindowRecepcion()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        //Face
        private void FacebookButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/profile.php?id=100073371850357");
        }

        //Twitter
        private void TwitterButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.twitter.com");
        }

        //Insta
        private void InstagramButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.Instagram.com");
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

        private void Mesas_Click(object sender, RoutedEventArgs e)
        {
            WPFAsignarMesa.ObtenerinstanciaAM().ShowDialog();
        }

        private void Reserva_Click(object sender, RoutedEventArgs e)
        {
            WPFReserva.ObtenerinstanciaRE().ShowDialog();
        }

        private void Salida_Click(object sender, RoutedEventArgs e)
        {
            WPFSalida.ObtenerinstanciaSA().ShowDialog();
        }
    }
}
