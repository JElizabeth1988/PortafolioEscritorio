using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Using con DALC
using BibliotecaDALC;
//Using BD
using Oracle.ManagedDataAccess.Client;

namespace BibliotecaNegocio
{
    //Indicar que la variable es serializable
    [Serializable]
    public class TipoUsuario
    {
        public int id_tipo_user { get; set; }
        public String descripcion_user { get; set; }

        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;

        //Crear objeto de la Bdd modelo
        private RSXXI_Entities bdd = new RSXXI_Entities();

        public TipoUsuario()
        {

        }

         public bool Read()
           {
               try
               {
                   BibliotecaDALC.TIPO_USUARIO tip =
                       bdd.TIPO_USUARIO.First(t => t.ID_TIPO_USER == id_tipo_user);
                   descripcion_user = tip.DESCRIPCION_USER;
                   return true;
               }
               catch (Exception ex)
               {
                   return false;
               }
           }

           public List<TipoUsuario> ReadAll()
           {
               try
               {
                   List<TipoUsuario> lista = new List<TipoUsuario>();
                   var lista_emp_bdd = bdd.TIPO_USUARIO.ToList();
                   foreach (TIPO_USUARIO item in lista_emp_bdd)
                   {
                       TipoUsuario tipo = new TipoUsuario();
                       tipo.id_tipo_user = item.ID_TIPO_USER;
                       tipo.descripcion_user = item.DESCRIPCION_USER;
                       lista.Add(tipo);
                   }
                   return lista;

               }
               catch (Exception ex)
               {
                   return null;
               }
           }

       
    }

    
}
