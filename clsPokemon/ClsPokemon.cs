namespace clsPokemon
{
    public class ClsPokemon
    {
        #region Atributos
        private String name;
        #endregion

        #region Propiedades
        public String Name{get{return name;}}
        #endregion

        #region Constructores 
        public ClsPokemon(String _name) 
        { 
            this.name=_name;
        }
        #endregion

    }
}
