using Microsoft.EntityFrameworkCore;
using PetPalzAPI.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PetPalzAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Monitoreo> Monitoreos { get; set; }
        public DbSet<HistorialMedico> HistorialesMedicos { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }
        public DbSet<Enfermedad> Enfermedades { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<Recordatorio> Recordatorios { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<PrimerosAuxilios> PrimerosAuxilios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            // Configuración de conversión de fechas a UTC
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(new ValueConverter<DateTime, DateTime>(
                            v => v.ToUniversalTime(), // Almacena como UTC
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc) // Convierte al leer
                        ));
                    }

                    if (property.ClrType == typeof(DateTimeOffset))
                    {
                        property.SetValueConverter(new ValueConverter<DateTimeOffset, DateTimeOffset>(
                            v => v.ToUniversalTime(), // Almacena como UTC
                            v => v.ToUniversalTime() // Convierte al leer
                        ));
                    }
                }
            }

            // Relación Usuario-Mascotas (1:N)
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Mascotas)
                .WithOne(m => m.Usuario)
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Mascota-Historial Médico (1:1)
            modelBuilder.Entity<HistorialMedico>()
                .HasOne(h => h.Mascota)
                .WithOne()
                .HasForeignKey<HistorialMedico>(h => h.MascotaId)
                .OnDelete(DeleteBehavior.Cascade);


            // Relación Historial Médico - Vacunas (1:N)
            modelBuilder.Entity<HistorialMedico>()
                .HasMany(h => h.Vacunas)
                .WithOne(v => v.HistorialMedico)
                .HasForeignKey(v => v.HistorialMedicoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Historial Médico - Enfermedades (1:N)
            modelBuilder.Entity<HistorialMedico>()
                .HasMany(h => h.Enfermedades)
                .WithOne(e => e.HistorialMedico)
                .HasForeignKey(e => e.HistorialMedicoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Historial Médico - Tratamientos (1:N)
            modelBuilder.Entity<HistorialMedico>()
                .HasMany(h => h.Tratamientos)
                .WithOne(t => t.HistorialMedico)
                .HasForeignKey(t => t.HistorialMedicoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Mascota-Recordatorio (1:N)
            modelBuilder.Entity<Mascota>()
                .HasMany(m => m.Recordatorios)
                .WithOne(r => r.Mascota)
                .HasForeignKey(r => r.MascotaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Mascota-Monitoreo (1:N)
            modelBuilder.Entity<Mascota>()
                .HasMany(m => m.Monitoreos)
                .WithOne(mo => mo.Mascota)
                .HasForeignKey(mo => mo.MascotaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de Veterinario: Sin relaciones directas
            modelBuilder.Entity<Veterinario>();

            // Configuración de PrimerosAuxilios: Tabla independiente
            modelBuilder.Entity<PrimerosAuxilios>();

            base.OnModelCreating(modelBuilder);
        }
    }
}