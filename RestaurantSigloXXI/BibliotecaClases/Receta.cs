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
    //Indicar que la clase es serializable
    [Serializable]
    public class Receta
    {
        public int id_receta { get; set; }
        public string nom_receta { get; set; }
        public string instrucciones { get; set; }
        public int tiempo_cocion { get; set; }
        public int id_producto { get; set; }
        public string rut_empleado { get; set; }

        public Receta()
        {

        }

        [NonSerialized]
        //Crear objeto de la Bdd
        OracleConnection conn = null;
        [NonSerialized]
        //Capturar Errores
        DaoErrores err = new DaoErrores();
        public DaoErrores retornar() { return err; }

        //Crear objeto de la Bdd modelo
        [NonSerialized]
        private RSXXI_Entities bdd = new RSXXI_Entities();

        public bool Read()
        {
            try
            {
                BibliotecaDALC.RECETA rec =
                    bdd.RECETA.First(tip => tip.ID_RECETA == id_receta);
                nom_receta = rec.NOM_RECETA;
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<Receta> ReadAll()
        {
            try
            {
                List<Receta> lista = new List<Receta>();
                var lista_receta_bdd = bdd.RECETA.ToList();
                foreach (RECETA item in lista_receta_bdd)
                {
                    Receta tipo = new Receta();
                    tipo.id_receta = item.ID_RECETA;
                    tipo.nom_receta = item.NOM_RECETA;
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
