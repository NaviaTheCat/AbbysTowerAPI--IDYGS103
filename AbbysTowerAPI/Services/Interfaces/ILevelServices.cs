using Domain.Entities;
using Domain.Helpers;
using AbbysTowerAPI.Context;

namespace AbbysTowerAPI.Services.Interfaces
{
    public interface ILevelServices
    {
        public Task<Response<List<Levels>>> GetAllLevels();
        public Task<Response<Levels>> GetLevelById(int id);
        public Task<Response<Levels>> CreateLevel(Levels request);
        public Task<Response<Levels>> UpdateLevel(int id, Levels request);
        public Task<Response<Levels>> DeleteLevel(int id);
    }
}
