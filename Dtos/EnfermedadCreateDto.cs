using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class EnfermedadCreateDTO
    {
        [Required]
        public int HistorialMedicoId { get; set; } // Relación con el historial médico

        public string Nombre { get; set; } = string.Empty;

        public DateTime FechaDiagnostico { get; set; }

        public string? Descripcion { get; set; }
    }
}