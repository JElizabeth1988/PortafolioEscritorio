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

using Oracle.ManagedDataAccess.Client;
//using System.Data.OracleClient;

using System.Data;
//Metro
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
//Bibliotecas
using BibliotecaNegocio;


using System.Threading; //Hilos
//FileCache
using System.Runtime.Caching;

namespace Vista
{
    public partial class WPFCliente : MetroWindow
    {
        //PatronSingleton--------------------------
        public static WPFCliente _instancia;


        public static WPFCliente ObtenerinstanciaCLI()
        {
            if (_instancia == null)
            {
                _instancia = new WPFCliente();
            }

            return _instancia;
        }
        //----------------------------------------

        //Hilo para cache
        Thread hilo = null;

        //Instanciar BD
        OracleConnection conn = null;
        //Traer clase cliente
        Cliente cli = new Cliente();

        
        public WPFCliente()
        {
            InitializeComponent();
            
            txtDV.IsEnabled = false;//DV no se puede editar
            btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve
            btnEliminar.Visibility = Visibility.Hidden;
            txtRut.Focus();//Focus en el rut

            txtTelefono.Text = "0";
            txtCelular.Text = "0";

            //---Tarea automática CACHÉ-------
            Task tarea = new Task(() =>
            {
                hilo = Thread.CurrentThread;
                while (true)
                {
                    Thread.Sleep(5000);//cada 5 segundos guarda
                    generaRespaldo();
                }
            });

            tarea.Start();

            FileCache filecache = new FileCache(new ObjectBinder());

            if (filecache["hora"] != null)
            {
                lblCache.Content = filecache["hora"].ToString();
            }
            //---------------------------------
        }
        //Método generar respaldo------------------
        private void generaRespaldo()
        {

            Dispatcher.Invoke(()=> {

                //Llama a la clase cliente donde se gusradarán los datos
                Cliente.ListaClientes cl = new Cliente.ListaClientes();

                if (txtRut.Text != null)
                {
                    //Guardo el rut 
                    String rut = txtRut.Text + "-" + txtDV.Text;
                    if (rut.Length == 9)//Si el rut tiene solo 9 caracteres se le agrega cero al comienzo para que quede de 10
                    {
                        rut = "0" + txtRut.Text + "-" + txtDV.Text;
                    }
                    cl.Rut = rut;
                }
                else
                {
                    cl.Rut = null;
                }

                if (txtNombre.Text != null)
                {
                    cl.Nombre = txtNombre.Text;
                }
                if (txtSegNombre.Text != null)
                {
                    cl.Segundo_Nombre = txtSegNombre.Text;
                }
                if (txtApPaterno.Text != null)
                {
                    cl.Apellido_Paterno = txtApPaterno.Text;
                }
                if (txtApeMaterno.Text != null)
                {
                    cl.Apellido_Materno = txtApeMaterno.Text;
                }
                int Celular = 0;
                if (int.TryParse(txtCelular.Text, out Celular))
                {
                    cl.Celular = int.Parse(txtCelular.Text);
                }
                int telefono = 0;
                if (int.TryParse(txtTelefono.Text, out telefono))
                {
                    cl.Teléfono = int.Parse(txtTelefono.Text);
                }
                if (txtEmail.Text != null)
                {
                    cl.Email = txtEmail.Text;
                }

                //Proceso de respaldo
                //Con la ampolleta agregó el using Runtime.Caching
                FileCache filecahe = new FileCache(new ObjectBinder());

                String hora = DateTime.Now.ToString("dd-MM-yy HH:mm:ss");

                filecahe["cliente"] = cl;
                filecahe["hora"] = hora;

                lblCache.Content = hora;

            });
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
        //-----------Botón Pregunta Llama al listado de Clientes en caso de que se desconozca el Rut-------------------
        private async void btnPregunta_Click(object sender, RoutedEventArgs e)
        {
            WPFListadoCliente cliente = new WPFListadoCliente(this);
            cliente.ShowDialog();

        }

        //---------Método Limpiar--------------------
        private void Limpiar()
        {
            txtRut.Clear();
            txtDV.Clear();
            txtNombre.Clear();
            txtSegNombre.Clear();
            txtApPaterno.Clear();
            txtApeMaterno.Clear();
            txtCelular.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtRut.IsEnabled = true;
            lblCache.Content = null;

            txtTelefono.Text = "0";
            txtCelular.Text = "0";

            btnModificar.Visibility = Visibility.Hidden;//Botón modificar se esconde
            btnGuardar.Visibility = Visibility.Visible;//botón guardar aparece
            btnEliminar.Visibility = Visibility.Hidden;

            txtRut.Focus();//Mover el cursor a la poscición Rut

            //Limpiar cache
            FileCache filecahe = new FileCache(new ObjectBinder());
            filecahe.Remove("Cliente", null);
            
            try
            {

                lblCache.Content = "Se limpió caché";

            }
            catch (Exception ex)
            {
                lblCache.Content = "Error al limpiar";
                Logger.Mensaje(ex.Message);
            }
        }

        //-----------Botón Limpiar-------------------
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();

        }
        //------------------------CRUD----------------------------------------------------------------
        //--------------------------------------------------------------------------------------------

               //----------------Botón Guardar-----------------------
        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtRut.Text + "-" + txtDV.Text;
                if (rut.Length == 9)//Si el rut tiene solo 9 caracteres se le agrega cero al comienzo para que quede de 10
                {
                    rut = "0" + txtRut.Text + "-" + txtDV.Text;
                }
                String Nombre = txtNombre.Text;
                String segNombre = txtSegNombre.Text;
                String apPaterno = txtApPaterno.Text;
                String apMaterno = txtApeMaterno.Text;
                String mail = txtEmail.Text;
                //int celular = int.Parse(txtCelular.Text);   
                int celular = 0;
                if (int.TryParse(txtCelular.Text, out celular))
                {

                }
                else
                {
                   /* await this.ShowMessageAsync("Mensaje:",
                      string.Format("Ingrese un número de 9 dígitos"));
                    txtTelefono.Focus();*/
                    return;
                }
                //int telefono = int.Parse(txtTelefono.Text); 
                int telefono = 0;
                if (int.TryParse(txtTelefono.Text, out telefono))
                {

                }
                else
                {
                    /*await this.ShowMessageAsync("Mensaje:",
                     string.Format("Ingrese un número de 9 dígitos"));
                    txtTelefono.Focus();*/
                    return;
                }

                Cliente c = new Cliente()
                {
                    rut_cliente = rut,
                    primer_nom_cli = Nombre,
                    segundo_nom_cli = segNombre,
                    ap_paterno_cli = apPaterno,
                    ap_materno_cli = apMaterno,
                    celular_cli = celular,
                    telefono_cli = telefono,
                    correo_cli = mail,
                    
                };

                bool resp = cli.Agregar(c);
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Guardado" : "No Guardado"));
                //-----------------------------------------------------------------------------------------------
                //MOSTRAR LISTA DE ERRORES (validación de la clase)
                if (resp == false)//If para que no muestre mensaje en blanco en caso de éxito
                {
                    DaoErrores de = c.retornar();
                    string li = "";
                    foreach (string item in de.ListarErrores())
                    {
                        li += item + " \n";
                    }
                    await this.ShowMessageAsync("Mensaje:",
                        string.Format(li));
                }
                else
                {
                    Limpiar();
                }
            }
            catch (ArgumentException exa)//mensajes de reglas de negocios
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format((exa.Message)));
                DaoErrores de = cli.retornar();
                string li = "";
                foreach (string item in de.ListarErrores())
                {
                    li += item + " \n";
                }
                await this.ShowMessageAsync("Mensaje:",
                    string.Format(li));
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                /*MessageBox.Show("Error de ingreso de datos");*/
                Logger.Mensaje(ex.Message);
                DaoErrores de = cli.retornar();
                string li = "";
                foreach (string item in de.ListarErrores())
                {
                    li += item + " \n";
                }
                await this.ShowMessageAsync("Mensaje:",
                    string.Format(li));

            }
        }
       
        //--------------Botón modificar------------------------------------------------
        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtRut.Text + "-" + txtDV.Text;
                String nombre = txtNombre.Text;
                String segNombre = txtSegNombre.Text;
                String apPaterno = txtApPaterno.Text;
                String apMaterno = txtApeMaterno.Text;
                String mail = txtEmail.Text;
                int celular = int.Parse(txtCelular.Text);
                int telefono = int.Parse(txtTelefono.Text);
                                
                Cliente c = new Cliente()
                {
                    rut_cliente = rut,
                    primer_nom_cli = nombre,
                    segundo_nom_cli = segNombre,
                    ap_paterno_cli = apPaterno,
                    ap_materno_cli = apMaterno,
                    celular_cli = celular,
                    telefono_cli = telefono,
                    correo_cli = mail

                };
                bool resp = cli.Actualizar(c);
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Actualizado" : "No Actualizado"));

                //-----------------------------------------------------------------------------------------------
                //MOSTRAR LISTA DE ERRORES
                if (resp == false)//If para que no muestre mensaje en blanco en caso de éxito
                {

                    DaoErrores de = c.retornar();
                    string li = "";
                    foreach (string item in de.ListarErrores())
                    {
                        li += item + " \n";
                    }
                    await this.ShowMessageAsync("Mensaje:",
                        string.Format(li));
                }
                else
                {
                    Limpiar();
                }

            }
            catch (ArgumentException exa)//mensajes de reglas de negocios
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format((exa.Message)));
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al Actualizar Datos"));
                /*MessageBox.Show("Error al Actualizar");*/
                Logger.Mensaje(ex.Message);

            }
        }
               
        //----------------------Botón Buscar (de administrar cliente)---------------
        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtRut.Text + "-" + txtDV.Text;
                if (rut.Length == 9)//Si el rut tiene solo 9 caracteres se le agrega cero al comienzo para que quede de 10
                {
                    rut = "0" + txtRut.Text + "-" + txtDV.Text;
                }
                cli.Buscar(rut);
                if (cli != null)//Si la lista no esta vacía entrego parámetros a los textBox
                {
                    txtRut.Text = cli.rut_cliente.Substring(0, 8);
                    txtDV.Text = cli.rut_cliente.Substring(9, 1);
                    txtRut.IsEnabled = false;//Rut no se modifica
                    txtDV.IsEnabled = false;//DV tampoco

                    txtNombre.Text = cli.primer_nom_cli;
                    txtSegNombre.Text = cli.segundo_nom_cli;
                    txtApPaterno.Text = cli.ap_paterno_cli;
                    txtApeMaterno.Text = cli.ap_materno_cli;
                    txtEmail.Text = cli.correo_cli;
                    txtCelular.Text = cli.celular_cli.ToString();
                    txtTelefono.Text = cli.telefono_cli.ToString();

                    btnModificar.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Hidden;
                    btnEliminar.Visibility = Visibility.Visible;

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                        string.Format("No se encontraron resultados!"));
                }
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Debe ingresar un rut correcto"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
            }
            
        }

        
        //-------------Botón Eliminar------------------------------------------------------
        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Rescatar Rut
                string rut = txtRut.Text + "-" + txtDV.Text;
                if (rut.Length == 9)
                {
                    rut = "0" + txtRut.Text + "-" + txtDV.Text;
                }
                BibliotecaNegocio.Cliente cli = new BibliotecaNegocio.Cliente();
                string nombre = txtNombre.Text + " " + txtApPaterno.Text;
                var x = await this.ShowMessageAsync("Eliminar Datos: ",
                         "¿Está Seguro de eliminar a "+nombre +"?",
                        MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                    bool resp = cli.Eliminar(rut);//Entrega rut por parametro
                    if (resp == true)//Si el método fue éxitoso muestra el mensaje
                    {
                        await this.ShowMessageAsync("Éxito:",
                          string.Format("Cliente Eliminado"));
                        Limpiar();
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error:",
                          string.Format("No Eliminado"));
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                          string.Format("Operación Cancelada"));
                }
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al Eliminar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
            }
        }

        //-------------------------------------------------------------------------------------
        //----------------------añadir formato al rut-----------------------------------------
        //--------------------------------------------------------------------------------------
        private void txtRut_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtRut.Text.Length >= 7 && txtRut.Text.Length <= 8)
            {
                string v = new Verificar().ValidarRut(txtRut.Text);
                txtDV.Text = v;
                try
                {
                    string rutSinFormato = txtRut.Text;

                    //si el rut ingresado tiene "." o "," o "-" son ratirados para realizar la formula 
                    rutSinFormato = rutSinFormato.Replace(",", "");
                    rutSinFormato = rutSinFormato.Replace(".", "");
                    rutSinFormato = rutSinFormato.Replace("-", "");
                    string rutFormateado = String.Empty;

                    //obtengo la parte numerica del RUT
                    //string rutTemporal = rutSinFormato.Substring(0, rutSinFormato.Length - 1);
                    string rutTemporal = rutSinFormato;
                    //obtengo el Digito Verificador del RUT
                    //string dv = rutSinFormato.Substring(rutSinFormato.Length - 1, 1);

                    Int64 rut;

                    //aqui convierto a un numero el RUT si ocurre un error lo deja en CERO
                    if (!Int64.TryParse(rutTemporal, out rut))
                    {
                        rut = 0;
                    }

                    //este comando es el que formatea con los separadores de miles
                    //rutFormateado = rut.ToString("N0"); (11.111.111-1)
                    rutFormateado = rut.ToString();

                    if (rutFormateado.Equals("0"))
                    {
                        rutFormateado = string.Empty;
                    }
                    else
                    {
                        //si no hubo problemas con el formateo agrego el DV a la salida
                        // rutFormateado += "-" + dv;

                        //y hago este replace por si el servidor tuviese configuracion anglosajona y reemplazo las comas por puntos
                        rutFormateado = rutFormateado.Replace(",", ".");
                    }

                    //se pasa a mayuscula si tiene letra k
                    rutFormateado = rutFormateado.ToUpper();

                    //Si se uso rutFormateado = rut.ToString("N0"); la salida esperada para el ejemplo es 99.999.999-K
                    txtRut.Text = rutFormateado;
                }
                catch (Exception ex)
                {
                    Logger.Mensaje(ex.Message);
                }
            }
            else
            {
                txtRut.Text = "";
            }
        }

        private void BtnCache_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileCache filecahe = new FileCache(new ObjectBinder());

                if (filecahe["cliente"] != null)
                {
                    Cliente.ListaClientes c = (Cliente.ListaClientes)filecahe["cliente"];
                    
                    txtNombre.Text = c.Nombre;
                    txtSegNombre.Text = c.Segundo_Nombre;
                    txtApPaterno.Text = c.Apellido_Paterno;
                    txtApeMaterno.Text = c.Apellido_Materno;
                    txtEmail.Text = c.Email;
                    txtCelular.Text = c.Celular.ToString();
                    txtTelefono.Text = c.Teléfono.ToString();
                    if (c.Rut != null)
                    {
                        txtRut.Text = c.Rut.Substring(0, 8);
                        txtDV.Text = c.Rut.Substring(9, 1);
                    }
                    else
                    {
                        txtRut.Text = null;
                        txtDV.Text = null;
                    }

                }
                else
                {
                    lblCache.Content = "Error al recuperar";
                    //MessageBox.Show("Error al recuperar");
                }
            }
            catch (Exception ex)
            {

                Logger.Mensaje(ex.Message);
            }
            
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Terminar con la tarea caché al cerrar la ventana
            hilo.Abort();

            //Parar Singleton
            _instancia = null;
        }
    }
}
