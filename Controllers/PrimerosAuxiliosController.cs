using Microsoft.AspNetCore.Mvc;
using PetPalzAPI.DTOs;
using PetPalzAPI.Services;

namespace PetPalzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PrimerosAuxiliosController : ControllerBase
    {
        private readonly PrimerosAuxiliosService _primerosAuxiliosService;

        public PrimerosAuxiliosController(PrimerosAuxiliosService primerosAuxiliosService)
        {
            _primerosAuxiliosService = primerosAuxiliosService;
        }

        [HttpPost]
        public IActionResult CrearPrimerosAuxilios([FromBody] PrimerosAuxiliosCreateDto primerosAuxiliosDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var primerosAuxilios = _primerosAuxiliosService.CrearPrimerosAuxilios(primerosAuxiliosDto);
            return CreatedAtAction(nameof(GetPrimerosAuxilios), new { id = primerosAuxilios.Id }, primerosAuxilios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrimerosAuxilios(int id)
        {
            var primerosAuxiliosDto = await _primerosAuxiliosService.GetPrimerosAuxiliosByIdAsync(id);

            if (primerosAuxiliosDto == null)
                return NotFound();

            return Ok(primerosAuxiliosDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrimerosAuxilios(int pageNumber = 1, int pageSize = 10, string? searchTerm = null)
        {
            var primerosAuxiliosDto = await _primerosAuxiliosService.GetAllPrimerosAuxiliosAsync(pageNumber, pageSize, searchTerm ?? string.Empty);
            return Ok(primerosAuxiliosDto);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarPrimerosAuxilios(int id, [FromBody] PrimerosAuxiliosCreateDto primerosAuxiliosDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = _primerosAuxiliosService.ActualizarPrimerosAuxilios(id, primerosAuxiliosDto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarPrimerosAuxilios(int id)
        {
            var eliminado = _primerosAuxiliosService.EliminarPrimerosAuxilios(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
}
}