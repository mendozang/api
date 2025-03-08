using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class MascotaService
    {
        private readonly AppDbContext _context;

        public MascotaService(AppDbContext context)
        {
            _context = context;
        }

        public Mascota CrearMascota(MascotaCreateDTO mascotaDto)
        {
            var mascota = new Mascota
            {
                Nombre = mascotaDto.Nombre,
                Especie = mascotaDto.Especie,
                Raza = mascotaDto.Raza,
                AnoNacimiento = mascotaDto.AnoNacimiento,
                Color = mascotaDto.Color,
                Genero = mascotaDto.Genero,
                Peso = mascotaDto.Peso,
                Tamano = mascotaDto.Tamano,
                ImagenUrl = mascotaDto.ImagenUrl,
                UsuarioId = mascotaDto.UsuarioId,
                Usuario = _context.Usuarios?.FirstOrDefault(u => u.Id == mascotaDto.UsuarioId) ?? throw new InvalidOperationException("Usuario not found")
            };

            _context.Mascotas.Add(mascota);
            _context.SaveChanges();

            return mascota;
        }

        public async Task<List<MascotaDto>> GetAllMascotasAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {
            var query = _context.Mascotas.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(m => (m.Nombre != null && m.Nombre.Contains(searchTerm)) ||
                                           (m.Especie != null && m.Especie.Contains(searchTerm)) ||
                                           (m.Raza != null && m.Raza.Contains(searchTerm)));
            }

            return await query
                .OrderBy(m => m.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new MascotaDto
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Especie = m.Especie,
                    Raza = m.Raza,
                    AnoNacimiento = m.AnoNacimiento,
                    Color = m.Color,
                    Genero = m.Genero,
                    Peso = m.Peso,
                    Tamano = m.Tamano,
                    ImagenUrl = m.ImagenUrl,
                    UsuarioId = m.UsuarioId
                })
                .ToListAsync();
        }

        public async Task<MascotaDto> GetMascotaByIdAsync(int id)
        {
            var mascota = await _context.Mascotas
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mascota == null) return null;

            return new MascotaDto
            {
                Id = mascota.Id,
                Nombre = mascota.Nombre,
                Especie = mascota.Especie,
                Raza = mascota.Raza,
                AnoNacimiento = mascota.AnoNacimiento,
                Color = mascota.Color,
                Genero = mascota.Genero,
                Peso = mascota.Peso,
                Tamano = mascota.Tamano,
                ImagenUrl = mascota.ImagenUrl,
                UsuarioId = mascota.UsuarioId
            };
        }

        public bool ActualizarMascota(int id, MascotaUpdateDTO mascotaDto)
        {
            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota == null) return false;

            if (!string.IsNullOrEmpty(mascotaDto.Nombre))
                mascota.Nombre = mascotaDto.Nombre;

            if (!string.IsNullOrEmpty(mascotaDto.AnoNacimiento))
                mascota.AnoNacimiento = mascotaDto.AnoNacimiento;

            if (!string.IsNullOrEmpty(mascotaDto.Especie))
                mascota.Especie = mascotaDto.Especie;

            if (!string.IsNullOrEmpty(mascotaDto.Raza))
                mascota.Raza = mascotaDto.Raza;

            if (!string.IsNullOrEmpty(mascotaDto.Color))
                mascota.Color = mascotaDto.Color;

            if (!string.IsNullOrEmpty(mascotaDto.Genero))
                mascota.Genero = mascotaDto.Genero;

            if (mascotaDto.Peso != default(double))
                mascota.Peso = mascotaDto.Peso;

            if (!string.IsNullOrEmpty(mascotaDto.Tamano))
                mascota.Tamano = mascotaDto.Tamano;

            if (!string.IsNullOrEmpty(mascotaDto.ImagenUrl))
                mascota.ImagenUrl = mascotaDto.ImagenUrl;

            _context.SaveChanges();
            return true;
        }

        public bool EliminarMascota(int id)
        {
            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota == null) return false;

            _context.Mascotas.Remove(mascota);
            _context.SaveChanges();
            return true;
        }
    }
}
