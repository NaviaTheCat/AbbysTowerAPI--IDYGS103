using Domain.Helpers;
using Domain.Entities;

namespace AbbysTowerAPI.Services.Interfaces
{
    public interface ICharacterServices
    {
        public Task<Response<List<Characters>>> GetAllCharacters(); 
        public Task<Response<Characters>> CharacterById(int id);
        public Task<Response<Characters>> CreateCharacter(Characters request);
        public Task<Response<Characters>> UpdateCharacter(int id, Characters request);
        public Task<Response<Characters>> DeleteCharacter(int id); 
    
    }
}
