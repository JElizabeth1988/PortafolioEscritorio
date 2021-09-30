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

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

using BibliotecaNegocio;
using BibliotecaDALC;

namespace Vista
{
    public partial class Cliente : MetroWindow
    {
        OracleConnection conn = null;
        BibliotecaNegocio.Cliente cli = new BibliotecaNegocio.Cliente();

        public Cliente()
        {
            InitializeComponent();
            conn = new Conexion().Getcone();//Instanciar la conexión

            txtDV.IsEnabled = false;//DV no se puede editar
            btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve
            btnEliminar.Visibility = Visibility.Hidden;
            txtRut.Focus();//Focus en el rut

                  
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
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        //-----------Botón Pregunta Llama al listado de Clientes en caso de que se desconozca el Rut-------------------
        private void btnPregunta_Click(object sender, RoutedEventArgs e)
        {
            /*ListadoCliente liCli = new ListadoCliente(this);
            liCli.ShowDialog();*/
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
            txtCelular.Text = "0";
            txtTelefono.Text = "0";
            txtEmail.Clear();
            txtRut.IsEnabled = true;

            btnModificar.Visibility = Visibility.Hidden;//Botón modificar se esconde
            btnGuardar.Visibility = Visibility.Visible;//botón guardar aparece
            btnEliminar.Visibility = Visibility.Hidden;

            txtRut.Focus();//Mover el cursor a la poscición Rut
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
                int celular = int.Parse(txtCelular.Text);    
                int telefono = int.Parse(txtTelefono.Text); 
                                             
                BibliotecaNegocio.Cliente c = new BibliotecaNegocio.Cliente()
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
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                /*MessageBox.Show("Error de ingreso de datos");*/
                Logger.Mensaje(ex.Message);

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
                                
                BibliotecaNegocio.Cliente c = new BibliotecaNegocio.Cliente()
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

        //------------------Llamado del botón traspasar--------------
       /* public async void Buscar()
         {
             try
             {
                string rut = txtRut.Text + "-" + txtDV.Text;

                if (rut.Length == 9)
                {
                    rut = "0" + txtRut.Text + "-" + txtDV.Text;//Seagrega un 0 al inicio, rut queda de 10 caracteres
                }
                OracleCommand CMD = new OracleCommand();
                CMD.CommandType = System.Data.CommandType.StoredProcedure;
                List<BibliotecaNegocio.Cliente> clie = new List<BibliotecaNegocio.Cliente>();
                //nombre de la conexion
                CMD.Connection = conn;
                //nombre del procedimeinto almacenado
                CMD.CommandText = "SP_BUSCAR_CLIENTE2";
                //////////se crea un nuevo de tipo parametro//P_ID//el tipo//el largo// 
                CMD.Parameters.Add(new OracleParameter("P_RUT", OracleDbType.Varchar2, 10)).Value = rut;
                CMD.Parameters.Add(new OracleParameter("CLIENTES", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;

                //se abre la conexion
                conn.Open();
                OracleDataReader reader = CMD.ExecuteReader();
                BibliotecaNegocio.Cliente c = null;
                while (reader.Read())//Mientras lee
                {
                    c = new BibliotecaNegocio.Cliente();

                    c.rut_cliente = reader[0].ToString();
                    c.primer_nombre = reader[1].ToString();
                    c.segundo_nombre = reader[2].ToString();
                    c.ap_paterno = reader[3].ToString();
                    c.ap_materno = reader[4].ToString();
                    c.direccion = reader[5].ToString();
                    c.telefono = int.Parse(reader[6].ToString());
                    c.email = reader[7].ToString();
                    c.id_comuna = int.Parse(reader[8].ToString());

                    clie.Add(c);

                }
                //Cerrar conexión
                conn.Close();
                if (c != null)//Si la lista no esta vacía entrego parámetros a los textBox y CB
                {
                    txtRut.Text = c.rut_cliente.Substring(0, 8);
                    txtDV.Text = c.rut_cliente.Substring(9, 1);
                    txtRut.IsEnabled = false;//Rut no se modifica
                    txtDV.IsEnabled = false;//DV tampoco

                    txtNombre.Text = c.primer_nombre;
                    txtSegNombre.Text = c.segundo_nombre;
                    txtApeMaterno.Text = c.ap_paterno;
                    txtApPaterno.Text = c.ap_materno;
                    txtEmail.Text = c.email;
                    txtDireccion.Text = c.direccion;
                    txtTelefono.Text = c.telefono.ToString();
                    //-------Cambiar a nombre
                    Comuna co = new Comuna();
                    co.id_comuna = c.id_comuna;
                    co.Read();
                    cboComuna.Text = co.nombre;//Cambiar a nombre
                    //--------------------
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
                     string.Format("Error al Buscar Información! "));
                Logger.Mensaje(ex.Message);
            }
        }*/
       
        //----------------------Botón Buscar (de administrar cliente)---------------
        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
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
                txtApeMaterno.Text = cli.ap_paterno_cli;
                txtApPaterno.Text = cli.ap_materno_cli;
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
    }
}
