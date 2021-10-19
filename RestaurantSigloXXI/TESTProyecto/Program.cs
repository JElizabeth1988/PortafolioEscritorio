using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaNegocio;
using System.Globalization;

namespace TESTProyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            /*TipoUsuario c = new TipoUsuario();

            List<TipoUsuario> lista = c.ReadAll();

            foreach (TipoUsuario item in lista)
            {
                Console.WriteLine(item.descripcion_user);
            }
            Console.ReadKey();*/

            /*var culture = new CultureInfo("es-ES");
            DateTime fechin = DateTime.Parse("2021/10/05", culture);*/

            var texto = "hola mundo";
            var largo = texto.Length - 5;
            
            Console.WriteLine(largo);
            Console.ReadKey();


        }


    }
}
