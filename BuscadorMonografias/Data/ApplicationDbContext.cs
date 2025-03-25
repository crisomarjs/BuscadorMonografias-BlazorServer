using BuscadorMonografias.Models;
using Microsoft.EntityFrameworkCore;

namespace BuscadorMonografias.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        //Add Models
        public DbSet<Monografia> Monografia { get; set; }
        public DbSet<MapaEsquema> MapasEsquema { get; set; }
    }
}
