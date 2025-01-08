using clsPokemon;
using Newtonsoft.Json;

namespace Services
{
    public class ClsManejadora
    {
        public async Task<List<ClsPokemon>> getPokemons()
        {
            //Pido la cadena de la Uri al método estático

            string miCadenaUrl = clsUriBase.getUriBase();

            Uri miUri = new Uri($"{miCadenaUrl}Personas");

            List<ClsPokemon> listadoPokemons = new List<ClsPokemon>();

            HttpClient mihttpClient;

            HttpResponseMessage miCodigoRespuesta;

            string textoJsonRespuesta;

            //Instanciamos el cliente Http

            mihttpClient = new HttpClient();

            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);

                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);

                    mihttpClient.Dispose();

                    //JsonConvert necesita using Newtonsoft.Json;

                    //Es el paquete Nuget de Newtonsoft

                    listadoPokemons = JsonConvert.DeserializeObject<List<ClsPokemon>>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listadoPokemons;

        }
    }
}
