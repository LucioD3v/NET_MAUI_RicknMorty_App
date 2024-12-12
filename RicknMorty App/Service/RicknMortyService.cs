using RicknMorty_App.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RicknMorty_App.Service
{
    public class RicknMortyService : IRicknMortyService
    {
        private string urlAPI = "https://rickandmortyapi.com/api/character";

        public async Task<List<CharactersModel>> GetCharactersAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(urlAPI);
            var responseBody = await response.Content.ReadAsStringAsync();
            JsonNode nodes = JsonNode.Parse(responseBody);
            JsonNode results = nodes["results"];

            var charactersData = JsonSerializer.Deserialize<List<CharactersModel>>(results.ToString());
            return charactersData;
        }
    }
}
