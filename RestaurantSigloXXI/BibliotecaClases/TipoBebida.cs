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
    public class TipoBebida
    {
        public int id_tipo { get; set; }
        public string nombre { get; set; }

        [NonSerialized]
        //Crear objeto de la Bdd modelo
        private RSXXI_Entities bdd = new RSXXI_Entities();

        public TipoBebida()
        {

        }

        public bool Read()
        {
            try
            {
                TIPO_BEBIDA tipo =
                    bdd.TIPO_BEBIDA.First(tip => tip.ID_TIPO == id_tipo);
                nombre = tipo.NOMBRE;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }
        }

        public List<TipoBebida> ReadAll()
        {
            try
            {
                List<TipoBebida> lista = new List<TipoBebida>();
                var lista_beb_bdd = bdd.TIPO_BEBIDA.ToList();
                foreach (TIPO_BEBIDA item in lista_beb_bdd)
                {
                    TipoBebida tipo = new TipoBebida();
                    tipo.id_tipo = item.ID_TIPO;
                    tipo.nombre = item.NOMBRE;
                    lista.Add(tipo);

                }
                return lista;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }
        }
    }
}
