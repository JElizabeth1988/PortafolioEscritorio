using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaNegocio;
using System.Globalization;

namespace TESTProyecto
{
    class AgregarNuevaMesa
    {
        static void Main(string[] args)
        {

            Mesa me = new Mesa();


            //ARRANGE O PREPARACION

            int cant_per = 15;
            string dispo = "Disponible";
            string asig = "Presencial";
            string rut_emp = "20040415-7";
            Mesa mes = new Mesa();
            {
                mes.capacidad_persona = cant_per;
                mes.disponibilidad = dispo;
                mes.asignacion = asig;
                mes.rut_empleado = rut_emp;

            };

            //EJECUCION

            bool result = me.Agregar(mes);

            //ASSERT

            Console.WriteLine(result);
            Console.ReadKey();

        }

    }
}
