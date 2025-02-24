using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class RecordatorioService
    {
        private readonly AppDbContext _context;

        public RecordatorioService(AppDbContext context)
        {
            _context = context;
        }

        public Recordatorio CrearRecordatorio(RecordatorioCreateDTO recordatorioDto)
        {
            var recordatorio = new Recordatorio
            {
                Tipo = recordatorioDto.Tipo,
                Nombre = recordatorioDto.Nombre,
                Descripcion = recordatorioDto.Descripcion,
                Hora = recordatorioDto.Hora,
                Frecuencia = recordatorioDto.Frecuencia,
                FechaInicio = recordatorioDto.FechaInicio,
                FechaFin = recordatorioDto.FechaFin,
                FechaUnica = recordatorioDto.FechaUnica,
                MascotaId = recordatorioDto.MascotaId
            };

            _context.Recordatorios.Add(recordatorio);
            _context.SaveChanges();

            return recordatorio;
        }

        public async Task<RecordatorioDto> GetRecordatorioByIdAsync(int id)
        {
            var recordatorio = await _context.Recordatorios
                .Include(r => r.Mascota)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recordatorio == null) return null;

            return new RecordatorioDto
            {
                Tipo = recordatorio.Tipo,
                Nombre = recordatorio.Nombre,
                Descripcion = recordatorio.Descripcion,
                Hora = recordatorio.Hora,
                Frecuencia = recordatorio.Frecuencia,
                FechaInicio = recordatorio.FechaInicio,
                FechaFin = recordatorio.FechaFin,
                FechaUnica = recordatorio.FechaUnica,
                MascotaId = recordatorio.MascotaId
            };
        }

        public async Task<List<RecordatorioDto>> GetAllRecordatoriosAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {
            var query = _context.Recordatorios.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(r => (r.Tipo != null && r.Tipo.Contains(searchTerm)) || (r.Nombre != null && r.Nombre.Contains(searchTerm)));
            }

            return await query
                .OrderBy(r => r.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(r => r.Mascota)
                .Select(r => new RecordatorioDto
                {
                    Id = r.Id,
                    Tipo = r.Tipo,
                    Nombre = r.Nombre,
                    Descripcion = r.Descripcion,
                    Hora = r.Hora,
                    Frecuencia = r.Frecuencia,
                    FechaInicio = r.FechaInicio,
                    FechaFin = r.FechaFin,
                    FechaUnica = r.FechaUnica,
                    MascotaId = r.MascotaId
                })
                .ToListAsync();
        }

        public async Task<List<RecordatorioDto>> GetRecordatoriosByMascotaIdAsync(int mascotaId, DateTime? startDate = null, DateTime? endDate = null)
{
    var query = _context.Recordatorios.AsQueryable();

    query = query.Where(r => r.MascotaId == mascotaId);

    if (startDate.HasValue)
    {
        query = query.Where(r => r.FechaInicio >= startDate.Value || (r.FechaUnica.HasValue && r.FechaUnica.Value >= startDate.Value));
    }

    if (endDate.HasValue)
    {
        query = query.Where(r => r.FechaFin <= endDate.Value || (r.FechaUnica.HasValue && r.FechaUnica.Value <= endDate.Value));
    }

    return await query
        .OrderBy(r => r.Id)
        .Include(r => r.Mascota)
        .Select(r => new RecordatorioDto
        {
            Id = r.Id,
            Tipo = r.Tipo,
            Nombre = r.Nombre,
            Descripcion = r.Descripcion,
            Hora = r.Hora,
            Frecuencia = r.Frecuencia,
            FechaInicio = r.FechaInicio,
            FechaFin = r.FechaFin,
            FechaUnica = r.FechaUnica,
            MascotaId = r.MascotaId
        })
        .ToListAsync();
}


        public bool ActualizarRecordatorio(int id, RecordatorioUpdateDTO recordatorioDto)
        {
            var recordatorio = _context.Recordatorios.FirstOrDefault(r => r.Id == id);
            if (recordatorio == null) return false;

            if (!string.IsNullOrEmpty(recordatorioDto.Tipo))
                recordatorio.Tipo = recordatorioDto.Tipo;

            if (!string.IsNullOrEmpty(recordatorioDto.Nombre))
                recordatorio.Nombre = recordatorioDto.Nombre;

            if (!string.IsNullOrEmpty(recordatorioDto.Descripcion))
                recordatorio.Descripcion = recordatorioDto.Descripcion;
            
            if (recordatorioDto.Hora != null)
                recordatorio.Hora = recordatorioDto.Hora;

            if (!string.IsNullOrEmpty(recordatorioDto.Frecuencia))
                recordatorio.Frecuencia = recordatorioDto.Frecuencia;

            if (recordatorioDto.FechaInicio != null)
                recordatorio.FechaInicio = recordatorioDto.FechaInicio;

            if (recordatorioDto.FechaFin != null)
                recordatorio.FechaFin = recordatorioDto.FechaFin;

            if (recordatorioDto.FechaUnica != null)
                recordatorio.FechaUnica = recordatorioDto.FechaUnica;

            _context.SaveChanges();
            return true;
        }

        public bool EliminarRecordatorio(int id)
        {
            var recordatorio = _context.Recordatorios.FirstOrDefault(r => r.Id == id);
            if (recordatorio == null) return false;

            _context.Recordatorios.Remove(recordatorio);
            _context.SaveChanges();
            return true;
        }
    }
}
