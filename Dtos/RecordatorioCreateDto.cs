using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class RecordatorioCreateDTO
    {

        public required string Tipo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public TimeSpan? Hora { get; set; }

        public string? Frecuencia { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public DateTime? FechaUnica { get; set; }
        public int MascotaId { get; set; }
    }
}
