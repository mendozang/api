public class MascotaDto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required string Especie { get; set; }
        public string? Raza { get; set; }
        public required double Peso { get; set; }
        public string? ImagenUrl { get; set; }
        public int UsuarioId { get; set; }
    }