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

            Cliente client = new Cliente();


            //ARRANGE O PREPARACION

            string rut = "16917764-9";
          

            //EJECUCION

            bool result = client.Eliminar(rut);

            Console.WriteLine(result);
            Console.ReadKey();

        }
       

    }
}
