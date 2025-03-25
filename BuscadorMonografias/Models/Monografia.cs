using System.ComponentModel.DataAnnotations;

namespace BuscadorMonografias.Models
{
    public class Monografia
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }
    }
}
