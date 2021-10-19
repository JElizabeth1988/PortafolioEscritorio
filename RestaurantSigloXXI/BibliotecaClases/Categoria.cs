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
    public class Categoria
    {
        public int id_categoria { get; set; }
        public string nombre_cat { get; set; }

        public Categoria()
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
                BibliotecaDALC.CATEGORIA cat =
                    bdd.CATEGORIA.First(tip => tip.ID_CATEGORIA == id_categoria);
                nombre_cat = cat.NOMBRE_CAT;
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<Categoria> ReadAll()
        {
            try
            {
                List<Categoria> lista = new List<Categoria>();
                var lista_cat_bdd = bdd.CATEGORIA.ToList();
                foreach (CATEGORIA item in lista_cat_bdd)
                {
                    Categoria tipo = new Categoria();
                    tipo.id_categoria = item.ID_CATEGORIA;
                    tipo.nombre_cat = item.NOMBRE_CAT;
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
