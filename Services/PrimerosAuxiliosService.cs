using PetPalzAPI.Data;
using PetPalzAPI.Models;
using PetPalzAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PetPalzAPI.Services
{
    public class PrimerosAuxiliosService
    {
        private readonly AppDbContext _context;

        public PrimerosAuxiliosService(AppDbContext context)
        {
            _context = context;
        }

        public PrimerosAuxilios CrearPrimerosAuxilios(PrimerosAuxiliosCreateDto primerosAuxiliosDto)
        {
            var primerosAuxilios = new PrimerosAuxilios
            {
                Titulo = primerosAuxiliosDto.Titulo,
                Categoria = primerosAuxiliosDto.Categoria,
                Contenido = primerosAuxiliosDto.Contenido
            };

            if (_context != null)
            {
                if (_context.PrimerosAuxilios != null)
                {
                    _context.PrimerosAuxilios.Add(primerosAuxilios);
                    _context.SaveChanges();
                }
            }

            return primerosAuxilios;
        }

        public async Task<List<PrimerosAuxiliosDto>> GetAllPrimerosAuxiliosAsync(int pageNumber, int pageSize, string searchTerm = null)
        {
            var query = _context.PrimerosAuxilios.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.Titulo.Contains(searchTerm) || p.Categoria.Contains(searchTerm));
            }

            return await query
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PrimerosAuxiliosDto
                {
                    Id = p.Id,
                    Titulo = p.Titulo,
                    Categoria = p.Categoria,
                    Contenido = p.Contenido
                })
                .ToListAsync();
        }

        public async Task<PrimerosAuxiliosDto> GetPrimerosAuxiliosByIdAsync(int id)
        {
            var primerosAuxilios = await _context.PrimerosAuxilios
                .Where(p => p.Id == id)
                .Select(p => new PrimerosAuxiliosDto
                {
                    Id = p.Id,
                    Titulo = p.Titulo,
                    Categoria = p.Categoria,
                    Contenido = p.Contenido
                }).FirstOrDefaultAsync();

            if (primerosAuxilios == null)
            {
                throw new KeyNotFoundException($"PrimerosAuxilios with Id {id} not found.");
            }

            return primerosAuxilios;
        }

        public bool ActualizarPrimerosAuxilios(int id, PrimerosAuxiliosCreateDto primerosAuxiliosDto)
        {
            var primerosAuxilios = _context.PrimerosAuxilios.FirstOrDefault(p => p.Id == id);
            if (primerosAuxilios == null) return false;

            if (!string.IsNullOrEmpty(primerosAuxiliosDto.Titulo))
                primerosAuxilios.Titulo = primerosAuxiliosDto.Titulo;

            if (!string.IsNullOrEmpty(primerosAuxiliosDto.Categoria))
                primerosAuxilios.Categoria = primerosAuxiliosDto.Categoria;

            if (!string.IsNullOrEmpty(primerosAuxiliosDto.Contenido))
                primerosAuxilios.Contenido = primerosAuxiliosDto.Contenido;

            _context.SaveChanges();
            return true;
        }

        public bool EliminarPrimerosAuxilios(int id)
        {
            var primerosAuxilios = _context.PrimerosAuxilios.FirstOrDefault(p => p.Id == id);
            if (primerosAuxilios == null) return false;

            _context.PrimerosAuxilios.Remove(primerosAuxilios);
            _context.SaveChanges();
            return true;
        }
}
}