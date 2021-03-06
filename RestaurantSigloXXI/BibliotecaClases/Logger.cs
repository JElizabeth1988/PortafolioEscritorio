using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//Entrada y salida

namespace BibliotecaNegocio
{
    public class Logger
    {
        public static void Mensaje(String msg)
        {
            string ruta = @"c:\log";
            //si el directorio no existe se crea (carpeta log en disco c)
            if (!Directory.Exists(ruta))
            {                
                DirectoryInfo di = Directory.CreateDirectory(ruta);
            }

            msg = DateTime.Now + " | " + msg + Environment.NewLine;
            
            File.AppendAllText(@"c:\log\logger.txt", msg);           


            //Environment.NewLine: cambio de linea
            //DateTime.Now: fecha actual
        }
    }
}
