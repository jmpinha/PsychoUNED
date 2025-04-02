using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PsychoUnedApi.Data;
using PsychoUnedApi.DataModel;
using PsychoUnedApi.Interfaces;
using PsychoUnedApi.Models;
using System.Threading.Tasks;

namespace PsychoUnedApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : Controller
    {

        private readonly ILogger<SubjectController> _logger;
        private readonly ISubjectService _subjectsService;

        public SubjectController(ILogger<SubjectController> logger, ISubjectService subjectsService)
        {
            _logger = logger;
            _subjectsService = subjectsService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var subjects = await _subjectsService.GetAllSubjectAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var subject = await _subjectsService.GetSubjectAsync(id);
            if (subject == null) return NotFoundResponse(id);
            return Ok(subject);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> DetailsByName(
            [FromQuery] string? name,
            [FromQuery] int? course = 0,
            [FromQuery] int? semester = 0)
        {
            if(!name.IsNullOrEmpty())
            {
                var subject = await _subjectsService.GetFilterSubjectByName(name);
                if (subject.IsNullOrEmpty()) return NotFoundFilterResponse(name);
                return Ok(subject);
            }
            else if(semester != 0 && course != 0)
            {

                var subject = await _subjectsService.GetFilterSubjectByCourseAndSemester(course ?? 0, semester ?? 0);
                if (subject.IsNullOrEmpty()) return NotFound($"No se encontró una asignatura con ese curso y ese semestre.");
                return Ok(subject);
            }

            return BadRequest("Los datos de la subject son inválidos.");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubjectDTO subject)
        {
            if (subject == null) return BadRequest("Los datos de la subject son inválidos.");

            var creada = await _subjectsService.AddSubjectAsync(subject);
            return CreatedAtAction(nameof(Details), new { id = creada.Id }, creada);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody] SubjectDTO subject)
        {
            var actualizada = await _subjectsService.UpdateSubjectAsync(subject);
            if (actualizada == null) return NotFoundResponse(subject.Id);

            return Ok(actualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _subjectsService.GetSubjectAsync(id);
            if (subject == null) return NotFound($"No se encontró la subject con ID {id}.");

            await _subjectsService.DeleteSubjectAsync(id);
            return NoContent();
        }

        // Método auxiliar para manejar la respuesta NotFound con mensaje detallado
        private IActionResult NotFoundResponse(int id)
        {
            return NotFound($"No se encontró la asignatura con ID {id}.");
        }
        private IActionResult NotFoundFilterResponse(string name)
        {
            return NotFound($"No se encontró una asignatura que contenga: {name}.");
        }
    }
}