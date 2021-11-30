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
    public class TipoProducto
    {
        public int id_tipo_producto { get; set; }
        public String nombre_tipo { get; set; }

        [NonSerialized]
        //Crear objeto de la Bdd modelo
        private RSXXI_Entities bdd = new RSXXI_Entities();

        public TipoProducto()
        {

        }

        public bool Read()
        {
            try
            {
                BibliotecaDALC.TIPO_PRODUCTO tipo =
                    bdd.TIPO_PRODUCTO.First(tip => tip.ID_TIPO_PRODUCTO == id_tipo_producto);
                nombre_tipo = tipo.NOMBRE_TIPO;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }
        }

        public List<TipoProducto> ReadAll()
        {
            try
            {
                List<TipoProducto> lista = new List<TipoProducto>();
                var lista_prod_bdd = bdd.TIPO_PRODUCTO.ToList();
                foreach (TIPO_PRODUCTO item in lista_prod_bdd)
                {
                    TipoProducto tipo = new TipoProducto();
                    tipo.id_tipo_producto = item.ID_TIPO_PRODUCTO;
                    tipo.nombre_tipo = item.NOMBRE_TIPO;
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
