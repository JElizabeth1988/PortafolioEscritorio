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

using BibliotecaDALC;
using BibliotecaNegocio;
using Oracle.ManagedDataAccess.Client;

namespace Vista
{
    public partial class Login : MetroWindow
    {
        Empleado emp = new Empleado();

        public Login()
        {
            InitializeComponent();
            txtUsuario.Focus();
        }
        
        //----Botón Login llama al método login
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Rescatar parámetros de los textBox
            string usuario = txtUsuario.Text;
            string paswd = TxtContrasenia.Password.ToString();
            //Guardar el resultado en una variable int y entregar parámetros al método login
            int resp = emp.Metodologin(usuario, paswd);
            //Si la respuesta no es cero quiere decir que es un usuario registrado que ingresó bien sus credenciales, si es cero las credenciales no son válidas
            if (resp !=0)
            {
                //Si el tipo de usuario es = 1 es un administrador
                if (resp == 1)
                {
                    await this.ShowMessageAsync("Mensaje:",
                    //----------------------Nombre del user Con primera letra mayúscula
                    //string.Format("Bienvenido " + usuario.Substring(0, 1).ToUpper()) + usuario.Substring(1).ToLower());
                    "Bienvenido Administrador");
                    MainWindowAdmin main = new MainWindowAdmin();
                    this.Close();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No es un admin");
                }
            }      
                
            else
            {
                await this.ShowMessageAsync("Mensaje:",
                                    string.Format("¡Error de Credenciales!"));
                txtUsuario.Clear();
                TxtContrasenia.Clear();
                txtUsuario.Focus();
            }
                
        }
    }
}
