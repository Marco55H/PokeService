using clsPokemon;
using Ent;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services
{
    public class ClsManejadora
    {
        public async Task<List<ClsPokemon>> getPokemons(int cont)
        {
            Uri miUri = new Uri($"https://pokeapi.co/api/v2/pokemon?offset={cont}&limit=20");

            List<ClsPokemon> listadoPokemons = new List<ClsPokemon>();

            HttpClient mihttpClient = new HttpClient();

            try
            {
                HttpResponseMessage miCodigoRespuesta = await mihttpClient.GetAsync(miUri);

                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    string textoJsonRespuesta = await miCodigoRespuesta.Content.ReadAsStringAsync();

                    // Deserializa el JSON en un objeto de tipo ClsResultadoApi con sus cosas 
                    var apiResponse = JsonConvert.DeserializeObject<ClsResultadoApi>(textoJsonRespuesta);

                    // Results de la respuesta inicial
                    listadoPokemons = apiResponse?.Results?.Select(r => new ClsPokemon { Name = r.Name, Url = r.Url }).ToList() ?? new List<ClsPokemon>();
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos: {ex.Message}");
            }

            return listadoPokemons;
        }

    }
}
