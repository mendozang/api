using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class HistorialMedicoService
    {
        private readonly AppDbContext _context;

        public HistorialMedicoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HistorialMedico> CrearHistorialAsync(HistorialMedicoCreateDTO historialDto)
        {
            var historial = new HistorialMedico
            {
                MascotaId = historialDto.MascotaId,
                Mascota = await _context.Mascotas.FindAsync(historialDto.MascotaId) ?? throw new InvalidOperationException("Mascota not found")
            };

            _context.HistorialesMedicos.Add(historial);
            await _context.SaveChangesAsync();

            return historial;
        }

        public async Task<HistorialMedico?> GetHistorialMedicoByIdAsync(int id)
        {
            return await _context.HistorialesMedicos
                .Include(h => h.Vacunas)
                .Include(h => h.Tratamientos)
                .Include(h => h.Enfermedades)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<HistorialMedico?> GetHistorialByMascotaIdAsync(int mascotaId)
        {
            return await _context.HistorialesMedicos
                .Include(h => h.Vacunas)
                .Include(h => h.Tratamientos)
                .Include(h => h.Enfermedades)
                .FirstOrDefaultAsync(h => h.MascotaId == mascotaId);
        }

        public async Task<bool> EliminarHistorialAsync(int id)
        {
            var historial = await _context.HistorialesMedicos.FindAsync(id);
            if (historial == null) return false;

            _context.HistorialesMedicos.Remove(historial);
            await _context.SaveChangesAsync();
            return true;
        }

        // Métodos para manejar vacunas, enfermedades y tratamientos
        public async Task<bool> AgregarVacunaAsync(VacunaCreateDTO vacunaDto)
        {
            var historial = await _context.HistorialesMedicos.FindAsync(vacunaDto.HistorialMedicoId);
            if (historial == null) return false;

            var vacuna = new Vacuna
            {
                HistorialMedicoId = vacunaDto.HistorialMedicoId,
                HistorialMedico = historial,
                Nombre = vacunaDto.Nombre,
                FechaAplicacion = vacunaDto.FechaAplicacion,
                Descripcion = vacunaDto.Descripcion
            };

            _context.Vacunas.Add(vacuna);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Vacuna>> GetVacunasByHistorialIdAsync(int historialId)
        {
            return await _context.Vacunas
                .Where(v => v.HistorialMedicoId == historialId)
                .ToListAsync();
        }

        public async Task<bool> ActualizarVacunaAsync(int id, VacunaCreateDTO vacunaDto)
        {
            var vacuna = await _context.Vacunas.FindAsync(id);
            if (vacuna == null) return false;

            vacuna.Nombre = vacunaDto.Nombre;
            vacuna.FechaAplicacion = vacunaDto.FechaAplicacion;
            vacuna.Descripcion = vacunaDto.Descripcion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarVacunaAsync(int id)
        {
            var vacuna = await _context.Vacunas.FindAsync(id);
            if (vacuna == null) return false;

            _context.Vacunas.Remove(vacuna);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AgregarEnfermedadAsync(EnfermedadCreateDTO enfermedadDto)
        {
            var historial = await _context.HistorialesMedicos.FindAsync(enfermedadDto.HistorialMedicoId);
            if (historial == null) return false;

            var enfermedad = new Enfermedad
            {
                HistorialMedicoId = enfermedadDto.HistorialMedicoId,
                HistorialMedico = historial,
                Nombre = enfermedadDto.Nombre,
                FechaDiagnostico = enfermedadDto.FechaDiagnostico,
                Descripcion = enfermedadDto.Descripcion
            };

            _context.Enfermedades.Add(enfermedad);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Enfermedad>> GetEnfermedadesByHistorialIdAsync(int historialId)
        {
            return await _context.Enfermedades
                .Where(e => e.HistorialMedicoId == historialId)
                .ToListAsync();
        }

        public async Task<bool> ActualizarEnfermedadAsync(int id, EnfermedadCreateDTO enfermedadDto)
        {
            var enfermedad = await _context.Enfermedades.FindAsync(id);
            if (enfermedad == null) return false;

            enfermedad.Nombre = enfermedadDto.Nombre;
            enfermedad.FechaDiagnostico = enfermedadDto.FechaDiagnostico;
            enfermedad.Descripcion = enfermedadDto.Descripcion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarEnfermedadAsync(int id)
        {
            var enfermedad = await _context.Enfermedades.FindAsync(id);
            if (enfermedad == null) return false;

            _context.Enfermedades.Remove(enfermedad);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AgregarTratamientoAsync(TratamientoCreateDTO tratamientoDto)
        {
            var historial = await _context.HistorialesMedicos.FindAsync(tratamientoDto.HistorialMedicoId);
            if (historial == null) return false;

            var tratamiento = new Tratamiento
            {
                HistorialMedicoId = tratamientoDto.HistorialMedicoId,
                HistorialMedico = historial,
                Nombre = tratamientoDto.Nombre,
                FechaInicio = tratamientoDto.FechaInicio,
                FechaFin = tratamientoDto.FechaFin,
                Descripcion = tratamientoDto.Descripcion
            };

            _context.Tratamientos.Add(tratamiento);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Tratamiento>> GetTratamientosByHistorialIdAsync(int historialId)
        {
            return await _context.Tratamientos
                .Where(t => t.HistorialMedicoId == historialId)
                .ToListAsync();
        }

        public async Task<bool> ActualizarTratamientoAsync(int id, TratamientoCreateDTO tratamientoDto)
        {
            var tratamiento = await _context.Tratamientos.FindAsync(id);
            if (tratamiento == null) return false;

            tratamiento.Nombre = tratamientoDto.Nombre;
            tratamiento.FechaInicio = tratamientoDto.FechaInicio;
            tratamiento.FechaFin = tratamientoDto.FechaFin;
            tratamiento.Descripcion = tratamientoDto.Descripcion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarTratamientoAsync(int id)
        {
            var tratamiento = await _context.Tratamientos.FindAsync(id);
            if (tratamiento == null) return false;

            _context.Tratamientos.Remove(tratamiento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
