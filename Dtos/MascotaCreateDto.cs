using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class MascotaCreateDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public required string Nombre { get; set; }

        [Required]
        public required DateTime FechaNacimiento { get; set; }

        [Required]
        public required string Especie { get; set; }

        public string? Raza { get; set; }

        [Required]
        public required double Peso { get; set; }
        public string? ImagenUrl { get; set; }


        [Required]
        public int UsuarioId { get; set; } // Relación con el usuario
    }
}
