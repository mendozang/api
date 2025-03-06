using Microsoft.AspNetCore.Mvc;
using PetPalzAPI.Services;
using PetPalzAPI.DTOs;
using System.Threading.Tasks;

namespace PetPalzAPI.Controllers
{
    [ApiController]
    [Route("api/historial-medico")]
    public class HistorialMedicoController : ControllerBase
    {
        private readonly HistorialMedicoService _historialMedicoService;

        public HistorialMedicoController(HistorialMedicoService historialMedicoService)
        {
            _historialMedicoService = historialMedicoService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearHistorial([FromBody] HistorialMedicoCreateDTO historialDto)
        {
            var historial = await _historialMedicoService.CrearHistorialAsync(historialDto);
            return CreatedAtAction(nameof(GetHistorialPorId), new { id = historial.Id }, historial);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistorialPorId(int id)
        {
            var historial = await _historialMedicoService.GetHistorialMedicoByIdAsync(id);
            if (historial == null) return NotFound();

            return Ok(historial);
        }

        [HttpGet("mascota/{mascotaId}")]
        public async Task<IActionResult> GetHistorialPorMascotaId(int mascotaId)
        {
            var historial = await _historialMedicoService.GetHistorialByMascotaIdAsync(mascotaId);
            if (historial == null) return NotFound();

            return Ok(historial);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarHistorial(int id)
        {
            var eliminado = await _historialMedicoService.EliminarHistorialAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }

        // Endpoints para manejar vacunas
        [HttpPost("{id}/vacunas")]
        public async Task<IActionResult> AgregarVacuna(int id, [FromBody] VacunaCreateDTO vacunaDto)
        {
            vacunaDto.HistorialMedicoId = id;
            var agregado = await _historialMedicoService.AgregarVacunaAsync(vacunaDto);
            if (!agregado) return NotFound();

            return Ok();
        }

        [HttpGet("vacunas/{historialId}")]
        public async Task<IActionResult> GetVacunas(int historialId)
        {
            var vacunas = await _historialMedicoService.GetVacunasByHistorialIdAsync(historialId);
            return Ok(vacunas);
        }

        [HttpPut("vacunas/{id}")]
        public async Task<IActionResult> ActualizarVacuna(int id, [FromBody] VacunaCreateDTO vacunaDto)
        {
            vacunaDto.HistorialMedicoId = id;
            var actualizado = await _historialMedicoService.ActualizarVacunaAsync(id, vacunaDto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("vacunas/{id}")]
        public async Task<IActionResult> EliminarVacuna(int id)
        {
            var eliminado = await _historialMedicoService.EliminarVacunaAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }

        // Endpoints para manejar enfermedades
        [HttpPost("{id}/enfermedades")]
        public async Task<IActionResult> AgregarEnfermedad(int id, [FromBody] EnfermedadCreateDTO enfermedadDto)
        {
            enfermedadDto.HistorialMedicoId = id;
            var agregado = await _historialMedicoService.AgregarEnfermedadAsync(enfermedadDto);
            if (!agregado) return NotFound();

            return Ok();
        }

        [HttpGet("enfermedades/{historialId}")]
        public async Task<IActionResult> GetEnfermedades(int historialId)
        {
            var enfermedades = await _historialMedicoService.GetEnfermedadesByHistorialIdAsync(historialId);
            return Ok(enfermedades);
        }

        [HttpPut("enfermedades/{id}")]
        public async Task<IActionResult> ActualizarEnfermedad(int id, [FromBody] EnfermedadCreateDTO enfermedadDto)
        {
            enfermedadDto.HistorialMedicoId = id;
            var actualizado = await _historialMedicoService.ActualizarEnfermedadAsync(id, enfermedadDto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("enfermedades/{id}")]
        public async Task<IActionResult> EliminarEnfermedad(int id)
        {
            var eliminado = await _historialMedicoService.EliminarEnfermedadAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }

        // Endpoints para manejar tratamientos
        [HttpPost("{id}/tratamientos")]
        public async Task<IActionResult> AgregarTratamiento(int id, [FromBody] TratamientoCreateDTO tratamientoDto)
        {
            tratamientoDto.HistorialMedicoId = id;
            var agregado = await _historialMedicoService.AgregarTratamientoAsync(tratamientoDto);
            if (!agregado) return NotFound();

            return Ok();
        }

        [HttpGet("tratamientos/{historialId}")]
        public async Task<IActionResult> GetTratamientos(int historialId)
        {
            var tratamientos = await _historialMedicoService.GetTratamientosByHistorialIdAsync(historialId);
            return Ok(tratamientos);
        }

        [HttpPut("tratamientos/{id}")]
        public async Task<IActionResult> ActualizarTratamiento(int id, [FromBody] TratamientoCreateDTO tratamientoDto)
        {
            tratamientoDto.HistorialMedicoId = id;
            var actualizado = await _historialMedicoService.ActualizarTratamientoAsync(id, tratamientoDto);
            if (!actualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("tratamientos/{id}")]
        public async Task<IActionResult> EliminarTratamiento(int id)
        {
            var eliminado = await _historialMedicoService.EliminarTratamientoAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}

