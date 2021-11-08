namespace Vista
{
    internal class comboBoxItemTipoUser
    {
        /*Para clases: TipoUsuario
           */
        public int id_tipo_user { get; set; }
        public string descripcion_user { get; set; }


        public comboBoxItemTipoUser()
        {

        }

        public override string ToString()
        {
            return descripcion_user;
        }
    }
}
