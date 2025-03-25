using BuscadorMonografias.Data;
using BuscadorMonografias.Models;
using Microsoft.EntityFrameworkCore;

namespace BuscadorMonografias.Repository
{
    public class MonografiaRepository : IMonografiaRepository
    {
        private readonly ApplicationDbContext _context;

        public MonografiaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Monografia> AddMonografia(Monografia addMonografia)
        {
            if(addMonografia != null)
            {
                await _context.Monografia.AddAsync(addMonografia);
                await _context.SaveChangesAsync();

                return addMonografia;
            }
            else
            {
                return new Monografia();
            }
        }

        public async Task DeleteMonografia(int monografiaId)
        {
            var monografiaDB = await _context.Monografia.FindAsync(monografiaId);
            _context.Remove(monografiaDB);

            await _context.SaveChangesAsync();
        }

        public async Task<Monografia> GetMonografia(int monografiaId)
        {
            var monografiaDB = await _context.Monografia.FindAsync(monografiaId);
            if(monografiaDB == null)
            {
                return new Monografia();
            }
            return monografiaDB;
        }

        public Task<List<Monografia>> GetMonografias()
        {
            return _context.Monografia.ToListAsync();
        }

        public async Task<Monografia> UpdateMonografia(int monografiaId, Monografia monografia)
        {
            var monografiaDB = await _context.Monografia.FindAsync(monografiaId);
            monografiaDB.Nombre = monografia.Nombre;

            await _context.SaveChangesAsync();
            return monografiaDB;
        }
    }
}
