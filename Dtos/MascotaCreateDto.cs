using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class MascotaCreateDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public required string Nombre { get; set; }

        public string? AñoNacimiento { get; set; }

        [Required]
        public required string Especie { get; set; }

        public string? Raza { get; set; }
        public string? Color { get; set; }
        public string? Genero { get; set; }

        public double Peso { get; set; }
        public string? Tamaño { get; set; }
        public string? ImagenUrl { get; set; }


        [Required]
        public int UsuarioId { get; set; } // Relación con el usuario

    }
}
