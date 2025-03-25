using System.ComponentModel.DataAnnotations;

namespace BuscadorMonografias.Models
{
    public class MapaEsquema
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }
    }
}
