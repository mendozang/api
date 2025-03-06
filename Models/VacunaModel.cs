using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.Models
{
    public class Vacuna
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaAplicacion { get; set; }
        public string? Descripcion { get; set; }

        [Required]
        public int HistorialMedicoId { get; set; }
        public required HistorialMedico HistorialMedico { get; set; }
    }
}