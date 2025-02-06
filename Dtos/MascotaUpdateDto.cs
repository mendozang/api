using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class MascotaUpdateDTO
    {
        [StringLength(20, MinimumLength = 2)]
        public required string Nombre { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required string Especie { get; set; }
        public string? Raza { get; set; }
        public required double Peso { get; set; }
        public string? ImagenUrl { get; set; }
    }
}
