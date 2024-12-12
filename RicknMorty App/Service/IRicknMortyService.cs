using RicknMorty_App.Models;

namespace RicknMorty_App.Service
{
    public interface IRicknMortyService
    {
        //Methods
        public Task<List<CharactersModel>> GetCharactersAsync();
    }
}
