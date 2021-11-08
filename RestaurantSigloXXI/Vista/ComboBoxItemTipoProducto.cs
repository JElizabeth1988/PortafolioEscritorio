namespace Vista
{
    internal class ComboBoxItemTipoProducto
    {
        public int id_tipo_producto { get; set; }
        public string nombre_tipo { get; set; }

        public ComboBoxItemTipoProducto()
        {

        }

        public override string ToString()
        {
            return nombre_tipo;
        }
    }
}
