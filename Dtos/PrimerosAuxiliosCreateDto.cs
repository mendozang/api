using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class PrimerosAuxiliosCreateDto
    {
        [Required]
        public required string Titulo { get; set; }

        [Required]
        public required string Categoria { get; set; }

        [Required]
        public required string Contenido { get; set; }
    }
}