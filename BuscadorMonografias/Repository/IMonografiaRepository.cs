using BuscadorMonografias.Models;

namespace BuscadorMonografias.Repository
{
    public interface IMonografiaRepository
    {
        public Task<List<Monografia>> GetMonografias();
        public Task<Monografia> GetMonografia(int monografiaId);
        public Task<Monografia> AddMonografia(Monografia addMonografia);
        public Task<Monografia> UpdateMonografia(int monografiaId, Monografia monografia);
        public Task DeleteMonografia(int monografiaId);
    }
}
