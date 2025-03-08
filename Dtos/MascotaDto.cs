public class MascotaDto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string? AnoNacimiento { get; set; }
        public required string Especie { get; set; }
        public string? Raza { get; set; }
        public string? Color { get; set; }
        public string? Genero { get; set; }
        public required double Peso { get; set; }
        public string? Tamano { get; set; }
        public string? ImagenUrl { get; set; }
        public int UsuarioId { get; set; }
    }