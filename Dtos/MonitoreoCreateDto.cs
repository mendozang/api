using System.ComponentModel.DataAnnotations;

public class MonitoreoCreateDto {

        [Required]
        public required int Pulso { get; set; } 

        [Required]
        public required double Temperatura { get; set; }

        [Required]
        public required int Respiración { get; set; } 

        [Required]
        public required int VFC { get; set; } 

        [Required]
        public required double Latitud { get; set; } 

        [Required]
        public required double Longitud { get; set; } 

        [Required]
        public required DateTime FechaRegistro { get; set; } 

        [Required]
        public int MascotaId { get; set; }
}