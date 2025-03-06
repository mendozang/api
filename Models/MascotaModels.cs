namespace PetPalzAPI.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public required string Especie { get; set; }
        public string? Raza { get; set; }
        public double Peso { get; set; }
        public string? ImagenUrl { get; set; }
        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        public ICollection<Recordatorio>? Recordatorios { get; set; }

        public ICollection<Monitoreo>? Monitoreos { get; set; }
    }
}
