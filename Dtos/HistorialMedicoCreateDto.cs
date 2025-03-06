using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class HistorialMedicoCreateDTO
    {
        [Required]
        public int MascotaId { get; set; } // Relación con la mascota
    }
}

