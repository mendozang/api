using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public Usuario CrearUsuario(UsuarioCreateDTO usuarioDto)
        {
            var usuario = new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Email = usuarioDto.Email,
                Contraseña = usuarioDto.Contraseña,
                ImagenUrl = usuarioDto.ImagenUrl
            };

            if (_context != null)
            {
                if (_context.Usuarios != null)
                {
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();
                }
            }

            return usuario;
        }

        public async Task<List<UsuarioDto>> GetAllUsuariosAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {
            var query = _context.Usuarios.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(u => u.Nombre.Contains(searchTerm) || u.Email.Contains(searchTerm));
            }

            return await query
                .OrderBy(u => u.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(u => u.Mascotas)
                .Select(u => new UsuarioDto
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Contraseña = u.Contraseña,
                    ImagenUrl = u.ImagenUrl,
                    Mascotas = u.Mascotas.Select(m => new MascotaDto
                    {
                        Id = m.Id,
                        Nombre = m.Nombre,
                        Especie = m.Especie,
                        AnoNacimiento = m.AnoNacimiento,
                        Peso = m.Peso,
                        Color = m.Color,
                        Genero = m.Genero,
                        Tamano = m.Tamano,
                        Raza = m.Raza,
                        ImagenUrl = m.ImagenUrl,
                        UsuarioId = m.UsuarioId
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<UsuarioDto> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Mascotas) // Incluir las mascotas
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null) return null;

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Contraseña = usuario.Contraseña,
                ImagenUrl = usuario.ImagenUrl,
                Mascotas = usuario.Mascotas.Select(m => new MascotaDto
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Especie = m.Especie,
                    AnoNacimiento = m.AnoNacimiento,
                    Raza = m.Raza,
                    Color = m.Color,
                    Genero = m.Genero,
                    Peso = m.Peso,
                    Tamano = m.Tamano,
                    ImagenUrl = m.ImagenUrl
                }).ToList()
            };
        }

        public bool ActualizarUsuario(int id, UsuarioUpdateDTO usuarioDto)
        {
            var usuario = _context.Usuarios?.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return false;

            if (!string.IsNullOrEmpty(usuarioDto.Nombre))
                usuario.Nombre = usuarioDto.Nombre;

            if (!string.IsNullOrEmpty(usuarioDto.Email))
                usuario.Email = usuarioDto.Email;

            if (!string.IsNullOrEmpty(usuarioDto.NuevaContraseña))
                usuario.Contraseña = usuarioDto.NuevaContraseña;

            if (!string.IsNullOrEmpty(usuarioDto.ImagenUrl))
                usuario.ImagenUrl = usuarioDto.ImagenUrl;

            _context.SaveChanges();
            return true;
        }

        public bool EliminarUsuario(int id)
        {
            var usuario = _context.Usuarios?.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return false;

            if (_context.Usuarios != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            _context.SaveChanges();
            return true;
        }
    }
}
