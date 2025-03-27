using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychoUnedApi.Data;
using PsychoUnedApi.Models;
using PsychoUnedApi.Services;
using System.Threading.Tasks;

namespace PsychoUnedApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : Controller
    {

        private readonly ILogger<SubjectController> _logger;
        private readonly ISubjectService _asignaturasService;

        public SubjectController(ILogger<SubjectController> logger, ISubjectService asignaturasService)
        {
            _logger = logger;
            _asignaturasService = asignaturasService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var asignaturas = await _asignaturasService.GetAllAsignaturas();
            return Ok(asignaturas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var asignatura = await _asignaturasService.get(id);
            if (asignatura == null) return NotFoundResponse(id);
            return Ok(asignatura);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Asignaturas asignatura)
        {
            if (asignatura == null) return BadRequest("Los datos de la asignatura son inválidos.");

            var creada = await _asignaturasService.CreateAsignatura(asignatura);
            return CreatedAtAction(nameof(Details), new { id = creada.Id }, creada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Asignaturas asignatura)
        {
            if (id != asignatura.Id) return BadRequest("El ID de la URL y el de la asignatura no coinciden.");

            var actualizada = await _asignaturasService.UpdateAsignatura(asignatura);
            if (actualizada == null) return NotFoundResponse(id);

            return Ok(actualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignatura = await _asignaturasService.GetAsignatura(id);
            if (asignatura == null) return NotFound($"No se encontró la asignatura con ID {id}.");

            await _asignaturasService.DeleteAsignatura(id);
            return NoContent();
        }

        // Método auxiliar para manejar la respuesta NotFound con mensaje detallado
        private IActionResult NotFoundResponse(int id)
        {
            return NotFound($"No se encontró la asignatura con ID {id}.");
        }
    }
}