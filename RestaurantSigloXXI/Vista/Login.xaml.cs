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
            try
            {
                //Crear Cliente del WS
                RSXXI.WSLogin.WSLOGINClient cliente = new RSXXI.WSLogin.WSLOGINClient();
                //Rescatar parámetros de los textBox
                string usuario = txtUsuario.Text;
                string paswd = TxtContrasenia.Password.ToString();
                //Guardar el resultado en una variable int y entregar parámetros al método login

                //Si la respuesta no es cero quiere decir que es un usuario registrado que ingresó bien sus credenciales, 
                //si es cero las credenciales no son válidas
                
                //Validar Credenciales en el WS
                //Si el tipo de usuario es = 1 es un administrador
                if (cliente.Login(usuario, paswd) == 1)
                {
                    await this.ShowMessageAsync("Mensaje:",
                    //----------------------Nombre del user Con primera letra mayúscula
                    //string.Format("Bienvenido " + usuario.Substring(0, 1).ToUpper()) + usuario.Substring(1).ToLower());
                    "Bienvenido, Administrador");
                    MainWindowAdmin main = new MainWindowAdmin();
                    this.Close();
                    main.ShowDialog();
                }
                //Si el tipo de usuario es = 3 es un encargado de cocina
                if (cliente.Login(usuario, paswd) == 3)
                {
                    await this.ShowMessageAsync("Mensaje:",
                    //----------------------Nombre del user Con primera letra mayúscula
                    //string.Format("Bienvenido " + usuario.Substring(0, 1).ToUpper()) + usuario.Substring(1).ToLower());
                    "Bienvenido, Encargado de Cocina");
                    WindowCocina coc = new WindowCocina();
                    this.Close();
                    coc.ShowDialog();
                }
                //Si el tipo de usuario es = 5 es un recepcionista
                if (cliente.Login(usuario, paswd) == 5)
                {
                    await this.ShowMessageAsync("Mensaje:",
                    //----------------------Nombre del user Con primera letra mayúscula
                    //string.Format("Bienvenido " + usuario.Substring(0, 1).ToUpper()) + usuario.Substring(1).ToLower());
                    "Bienvenido, Recepcionista");
                    WindowRecepcion rec = new WindowRecepcion();
                    this.Close();
                    rec.ShowDialog();
                }
                //Si el tipo de usuario es = 6 es finanzas
                if (cliente.Login(usuario, paswd) == 6)
                {
                    await this.ShowMessageAsync("Mensaje:",
                    //----------------------Nombre del user Con primera letra mayúscula
                    //string.Format("Bienvenido " + usuario.Substring(0, 1).ToUpper()) + usuario.Substring(1).ToLower());
                    "Bienvenido, Encargado de Finanzas");
                    WindowFinanza fin = new WindowFinanza();
                    this.Close();
                    fin.ShowDialog();
                }
                //Si el tipo de usuario es = 7 es Bodega
                if (cliente.Login(usuario, paswd) == 7)
                {
                    await this.ShowMessageAsync("Mensaje:",
                    //----------------------Nombre del user Con primera letra mayúscula
                    //string.Format("Bienvenido " + usuario.Substring(0, 1).ToUpper()) + usuario.Substring(1).ToLower());
                    "Bienvenido, Encargado de Bodega");
                    WindowBodega bod = new WindowBodega();
                    this.Close();
                    bod.ShowDialog();
                }
                //Si el tipo de usuario es = 4 es Garzón
                if (cliente.Login(usuario, paswd) == 4)
                {
                    await this.ShowMessageAsync("Mensaje:",
                    //----------------------Nombre del user Con primera letra mayúscula
                    //string.Format("Bienvenido " + usuario.Substring(0, 1).ToUpper()) + usuario.Substring(1).ToLower());
                    "Bienvenido, Garzón");
                    WindowGarzon bod = new WindowGarzon();
                    this.Close();
                    bod.ShowDialog();
                } 
                //---Si es otro tipo de usuario no eestá autorizado para utilizar el sistema               
                else
                {
                    if (cliente.Login(usuario, paswd) == 0)
                    {
                        await this.ShowMessageAsync("Mensaje:",
                                            string.Format("¡Error de Credenciales!"));  

                        txtUsuario.Clear();
                        TxtContrasenia.Clear();
                        txtUsuario.Focus();
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error:",
                      string.Format("Los sentimos, no tiene los suficientes permisos para utilizar este sistema"));
                        txtUsuario.Clear();
                        TxtContrasenia.Clear();
                        txtUsuario.Focus();
                    }
                    
                }


            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                                        string.Format("¡Error de Credenciales!"));
                Logger.Mensaje(ex.Message);
                txtUsuario.Clear();
                TxtContrasenia.Clear();
                txtUsuario.Focus();
            }
           
        }
    }
}
