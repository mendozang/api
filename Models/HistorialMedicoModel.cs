using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.Models
{
    public class HistorialMedico
    {
        public int Id { get; set; }

        [Required]
        public int MascotaId { get; set; }

        [Required]
        public required Mascota Mascota { get; set; } // Relación con la mascota

        public List<Vacuna> Vacunas { get; set; } = new List<Vacuna>();
        public List<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
        public List<Enfermedad> Enfermedades { get; set; } = new List<Enfermedad>();
    }
}
