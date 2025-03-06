using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class MonitoreoService
    {
        private readonly AppDbContext _context;

        public MonitoreoService(AppDbContext context)
        {
            _context = context;
        }

        public Monitoreo CrearMonitoreo(MonitoreoCreateDto monitoreoDto)
        {
            var monitoreo = new Monitoreo
            {
                Pulso = monitoreoDto.Pulso,
                Temperatura = monitoreoDto.Temperatura,
                Respiracion = monitoreoDto.Respiracion,
                VFC = monitoreoDto.VFC,
                Latitud = monitoreoDto.Latitud,
                Longitud = monitoreoDto.Longitud,
                FechaRegistro = monitoreoDto.FechaRegistro,
                MascotaId = monitoreoDto.MascotaId
            };

            _context.Monitoreos.Add(monitoreo);
            _context.SaveChanges();

            return monitoreo;
        }

        public async Task<MonitoreoDto> GetMonitoreoByIdAsync(int id)
        {
            var monitoreo = await _context.Monitoreos
                .Include(m => m.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (monitoreo == null) return null;

            return new MonitoreoDto
            {
                Pulso = monitoreo.Pulso,
                Temperatura = monitoreo.Temperatura,
                Respiracion = monitoreo.Respiracion,
                VFC = monitoreo.VFC,
                Latitud = monitoreo.Latitud,
                Longitud = monitoreo.Longitud,
                FechaRegistro = monitoreo.FechaRegistro,
                MascotaId = monitoreo.MascotaId
            };
        }

        public async Task<List<MonitoreoDto>> GetAllMonitoreosAsync(int pageNumber, int pageSize)
        {
            return await _context.Monitoreos
                .OrderBy(m => m.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(m => m.Mascota)
                .Select(m => new MonitoreoDto
                {
                    Id = m.Id,
                    Pulso = m.Pulso,
                    Temperatura = m.Temperatura,
                    Respiracion = m.Respiracion,
                    VFC = m.VFC,
                    Latitud = m.Latitud,
                    Longitud = m.Longitud,
                    FechaRegistro = m.FechaRegistro,
                    MascotaId = m.MascotaId
                })
                .ToListAsync();
        }

        public async Task<List<MonitoreoDto>> GetAllMonitoreosByMascotaIdAsync(int mascotaId, DateTime? date = null)
        {
            if (date != null)
            {
                return await _context.Monitoreos
                    .Where(m => m.MascotaId == mascotaId && m.FechaRegistro.Date == date.Value.Date)
                    .Include(m => m.Mascota)
                    .Select(m => new MonitoreoDto
                    {
                        Id = m.Id,
                        Pulso = m.Pulso,
                        Temperatura = m.Temperatura,
                        Respiracion = m.Respiracion,
                        VFC = m.VFC,
                        Latitud = m.Latitud,
                        Longitud = m.Longitud,
                        FechaRegistro = m.FechaRegistro,
                        MascotaId = m.MascotaId
                    })
                    .ToListAsync();
            }

            return await _context.Monitoreos
                .Where(m => m.MascotaId == mascotaId)
                .Include(m => m.Mascota)
                .Select(m => new MonitoreoDto
                {
                    Id = m.Id,
                    Pulso = m.Pulso,
                    Temperatura = m.Temperatura,
                    Respiracion = m.Respiracion,
                    VFC = m.VFC,
                    Latitud = m.Latitud,
                    Longitud = m.Longitud,
                    FechaRegistro = m.FechaRegistro,
                    MascotaId = m.MascotaId
                })
                .ToListAsync();
        }

        public bool EliminarMonitoreo(int id)
        {
            var monitoreo = _context.Monitoreos.FirstOrDefault(m => m.Id == id);
            if (monitoreo == null) return false;

            _context.Monitoreos.Remove(monitoreo);
            _context.SaveChanges();

            return true;
        }
    }
}