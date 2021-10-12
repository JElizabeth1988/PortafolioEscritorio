using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaNegocio;

namespace TESTProyecto
{
    class Program
    {
       /*  static void Main(string[] args)
         {
              TipoUsuario c = new TipoUsuario();

              List<TipoUsuario> lista = c.ReadAll();

              foreach (TipoUsuario item in lista)
              {
                  Console.WriteLine(item.descripcion_user);
              }
              Console.ReadKey();



         }*/
        static void Main(string[] args)
        {
            TipoProducto c = new TipoProducto();

            List<TipoProducto> lista = c.ReadAll();

            foreach (TipoProducto item in lista)
            {
                Console.WriteLine(item.nombre_tipo);
            }
            Console.ReadKey();


        }
    }
}
