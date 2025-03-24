using System.ComponentModel.DataAnnotations;

namespace PetPalzAPI.DTOs
{
    public class VeterinarioCreateDTO
    {
        [Required]
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public string? Direccion { get; set; }

        public string? Horario { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public double Calificacion { get; set; }
    }
}
