using BuscadorMonografias.Data;
using BuscadorMonografias.Models;
using Microsoft.EntityFrameworkCore;

namespace BuscadorMonografias.Repository
{
    public class MapasEsquemasRepository : IMapasEsquemasRepository
    {
        public readonly ApplicationDbContext _context;

        public MapasEsquemasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MapaEsquema> AddMapasEsquema(MapaEsquema addMapasEsquema)
        {
            if (addMapasEsquema != null)
            {
                await _context.MapasEsquema.AddAsync(addMapasEsquema);
                await _context.SaveChangesAsync();
                return addMapasEsquema;
            }
            else
            {
                return new MapaEsquema();
            }
        }

        public Task DeleteMapasEsquema(int mapasEsquemaId)
        {
            var mapasEsquemaDB = _context.MapasEsquema.FindAsync(mapasEsquemaId);
            _context.Remove(mapasEsquemaDB);
            return _context.SaveChangesAsync();
        }

        public async Task<MapaEsquema> GetMapasEsquema(int mapasEsquemaId)
        {
            var mapasEsquemaDB = await _context.MapasEsquema.FindAsync(mapasEsquemaId);
            if(mapasEsquemaDB == null)
            {
                return new MapaEsquema();
            }
            return mapasEsquemaDB;
        }

        public Task<List<MapaEsquema>> GetMapasEsquemas()
        {
            return _context.MapasEsquema.ToListAsync();
        }

        public async Task<MapaEsquema> UpdateMapasEsquema(int mapasEsquemaId, MapaEsquema mapasEsquema)
        {
            var mapaEsquemaDB = await _context.MapasEsquema.FindAsync(mapasEsquemaId);
            mapaEsquemaDB.Nombre = mapasEsquema.Nombre;

            await _context.SaveChangesAsync();
            return mapaEsquemaDB;
        }
    }
}
