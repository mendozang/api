using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class TratamientoCreateDTO
    {
        [Required]
        public int HistorialMedicoId { get; set; } // Relación con el historial médico

        public string Nombre { get; set; } = string.Empty;

        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public string? Descripcion { get; set; }
    }
}
