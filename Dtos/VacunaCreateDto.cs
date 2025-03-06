using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class VacunaCreateDTO
    {
        [Required]
        public int HistorialMedicoId { get; set; } // Relación con el historial médico

        public string Nombre { get; set; } = string.Empty;

        public DateTime FechaAplicacion { get; set; }

        public string? Descripcion { get; set; }
    }
}
