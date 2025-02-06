using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.Models
{
    public class Recordatorio
    {
        public int Id { get; set; }

        [Required]
        public required string Tipo { get; set; } 

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public TimeSpan? Hora { get; set; }

        public string? Frecuencia { get; set; }

        public DateTime? FechaInicio { get; set; } 

        public DateTime? FechaFin { get; set; }

        public DateTime? FechaUnica { get; set; }

        [Required]
        public int MascotaId { get; set; }

        [Required]
        public Mascota? Mascota { get; set; }
    }
}
