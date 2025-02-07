using Microsoft.AspNetCore.Mvc;
using PetPalzAPI.DTOs;
using PetPalzAPI.Services;

namespace PetPalzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MonitoreoController : ControllerBase
    {
        private readonly MonitoreoService _monitoreoService;

        public MonitoreoController(MonitoreoService monitoreoService)
        {
            _monitoreoService = monitoreoService;
        }

        [HttpPost]
        public IActionResult CrearMonitoreo([FromBody] MonitoreoCreateDto monitoreoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var monitoreo = _monitoreoService.CrearMonitoreo(monitoreoDto);
            return CreatedAtAction(nameof(GetMonitoreo), new { id = monitoreo.Id }, monitoreo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonitoreo(int id)
        {
            var monitoreoDto = await _monitoreoService.GetMonitoreoByIdAsync(id);

            if (monitoreoDto == null)
                return NotFound();

            return Ok(monitoreoDto);
        }

        [HttpGet("mascota/{mascotaId}")]
        public async Task<IActionResult> GetMonitoreoByMascotaId(int mascotaId)
        {
            var monitoreoDto = await _monitoreoService.GetAllMonitoreosByMascotaIdAsync(mascotaId);

            if (monitoreoDto == null)
                return NotFound();

            return Ok(monitoreoDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMonitoreo(int pageNumber = 1, int pageSize = 10, string? searchTerm = null)
        {
            var monitoreoDto = await _monitoreoService.GetAllMonitoreosAsync(pageNumber, pageSize);
            return Ok(monitoreoDto);
        }


        [HttpDelete("{id}")]
        public IActionResult EliminarMonitoreo(int id)
        {
            var eliminado = _monitoreoService.EliminarMonitoreo(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}