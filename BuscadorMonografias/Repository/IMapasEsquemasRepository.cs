using BuscadorMonografias.Models;

namespace BuscadorMonografias.Repository
{
    public interface IMapasEsquemasRepository
    {
        public Task<List<MapaEsquema>> GetMapasEsquemas();
        public Task<MapaEsquema> GetMapasEsquema(int mapasEsquemaId);
        public Task<MapaEsquema> AddMapasEsquema(MapaEsquema addMapasEsquema);
        public Task<MapaEsquema> UpdateMapasEsquema(int mapasEsquemaId, MapaEsquema mapasEsquema);
        public Task DeleteMapasEsquema(int mapasEsquemaId);
    }
}
