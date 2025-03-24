using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class VeterinarioService
    {
        private readonly AppDbContext _context;

        public VeterinarioService(AppDbContext context)
        {
            _context = context;
        }

        public Veterinario CrearVeterinario(VeterinarioCreateDTO dto)
        {
            var veterinario = new Veterinario
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Direccion = dto.Direccion,
                Horario = dto.Horario,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                Calificacion = dto.Calificacion
                
            };

            _context.Veterinarios.Add(veterinario);
            _context.SaveChanges();
            return veterinario;
        }


        public async Task<VeterinarioDto?> GetVeterinarioByIdAsync(int id)
        {
            var veterinario = await _context.Veterinarios
                .FirstOrDefaultAsync(v => v.Id == id);

            if (veterinario == null)
            {
                throw new KeyNotFoundException($"Veterinario with Id {id} not found.");
            }

            return new VeterinarioDto
            {
                Id = veterinario.Id,
                Nombre = veterinario.Nombre,
                Descripcion = veterinario.Descripcion,
                Direccion = veterinario.Direccion,
                Horario = veterinario.Horario,
                Telefono = veterinario.Telefono,
                Email = veterinario.Email,
                Latitud = veterinario.Latitud,
                Longitud = veterinario.Longitud,
                Calificacion = veterinario.Calificacion
            };
        }

        public async Task<List<VeterinarioDto>> GetAllVeterinariosAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {
            var query = _context.Veterinarios.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(v => v.Nombre != null && v.Nombre.Contains(searchTerm));
            }

            return await query
                .OrderBy(v => v.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(v => new VeterinarioDto
                {
                    Id = v.Id,
                    Nombre = v.Nombre,
                    Descripcion = v.Descripcion,
                    Direccion = v.Direccion,
                    Horario = v.Horario,
                    Telefono = v.Telefono,
                    Email = v.Email,
                    Latitud = v.Latitud,
                    Longitud = v.Longitud,
                    Calificacion = v.Calificacion
                }).ToListAsync();
        }

        public bool ActualizarVeterinario(int id, VeterinarioUpdateDTO dto)
        {
            var veterinario = _context.Veterinarios.FirstOrDefault(v => v.Id == id);
            if (veterinario == null) return false;

            if (!string.IsNullOrEmpty(dto.Nombre))
                veterinario.Nombre = dto.Nombre;

            if (!string.IsNullOrEmpty(dto.Direccion))
                veterinario.Direccion = dto.Direccion;

            if (!string.IsNullOrEmpty(dto.Descripcion))
                veterinario.Descripcion = dto.Descripcion;

            if (!string.IsNullOrEmpty(dto.Horario))
                veterinario.Horario = dto.Horario;

            if (!string.IsNullOrEmpty(dto.Telefono))
                veterinario.Telefono = dto.Telefono;

            if (!string.IsNullOrEmpty(dto.Email))
                veterinario.Email = dto.Email;

            if (dto.Latitud != 0)
                veterinario.Latitud = dto.Latitud;

            if (dto.Longitud != 0)
                veterinario.Longitud = dto.Longitud;

            if (dto.Calificacion != 0)
                veterinario.Calificacion = dto.Calificacion;

            _context.SaveChanges();
            return true;
        }

        public bool EliminarVeterinario(int id)
        {
            var veterinario = _context.Veterinarios.FirstOrDefault(v => v.Id == id);
            if (veterinario == null) return false;

            _context.Veterinarios.Remove(veterinario);
            _context.SaveChanges();
            return true;
        }
    }
}
