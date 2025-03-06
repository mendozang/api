using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.Models
{
    public class Tratamiento
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string? Descripcion { get; set; }

    [Required]
    public int HistorialMedicoId { get; set; }
    
    public required HistorialMedico HistorialMedico { get; set; }
}
}