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
                Direccion = dto.Direccion,
                InformacionContacto = dto.InformacionContacto,
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
                Direccion = veterinario.Direccion,
                InformacionContacto = veterinario.InformacionContacto
            };
        }

        public async Task<List<VeterinarioDto>> GetAllVeterinariosAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {
            var query = _context.Veterinarios.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(v => (v.Nombre != null && v.Nombre.Contains(searchTerm)) ||
                                         (v.Direccion != null && v.Direccion.Contains(searchTerm)) ||
                                         (v.InformacionContacto != null && v.InformacionContacto.Contains(searchTerm)));
            }

            return await query
                .OrderBy(v => v.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(v => new VeterinarioDto
                {
                    Id = v.Id,
                    Nombre = v.Nombre,
                    Direccion = v.Direccion,
                    InformacionContacto = v.InformacionContacto
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

            if (!string.IsNullOrEmpty(dto.InformacionContacto))
                veterinario.InformacionContacto = dto.InformacionContacto;

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
