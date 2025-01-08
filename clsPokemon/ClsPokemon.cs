namespace clsPokemon
{
    public class ClsPokemon
    {
        #region Atributos
        private String name;
        private String url;
        #endregion

        #region Propiedades
        public String Name{get{return name;}}
        public String Url { get { return url; } }

        #endregion

        #region Constructores 
        public ClsPokemon(String _name,String _url) 
        { 
            this.name=_name;
            this.url=_url;
        }
        #endregion

    }
}
