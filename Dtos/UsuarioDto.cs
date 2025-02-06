public class UsuarioDto

    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Email { get; set; }
        public required string Contraseña { get; set; }
        public string? ImagenUrl { get; set; }
         public List<MascotaDto>? Mascotas { get; set; }
    }