using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class MascotaUpdateDTO
    {
        [StringLength(20, MinimumLength = 2)]
        public required string Nombre { get; set; }
        public required string? AnoNacimiento { get; set; }
        public required string Especie { get; set; }
        public string? Raza { get; set; }
        public string? Color { get; set; }
        public string? Genero { get; set; }
        public required double Peso { get; set; }
        public string? Tamano { get; set; }
        public string? ImagenUrl { get; set; }
    }
}
