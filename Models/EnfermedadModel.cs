using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.Models
{
    public class Enfermedad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaDiagnostico { get; set; }
        public string? Descripcion { get; set; }

        [Required]
        public int HistorialMedicoId { get; set; }
        public required HistorialMedico HistorialMedico { get; set; }
    }
}