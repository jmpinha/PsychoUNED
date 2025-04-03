using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsychoUnedApi.DataModel;
using PsychoUnedApi.Interfaces;
using PsychoUnedApi.Models;

namespace PsychoUnedApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : Controller
    {

        private readonly ILogger<ExamController> _logger;
        private readonly IExamsService _examsService;

        public ExamController(ILogger<ExamController> logger, IExamsService examsService)
        {
            _logger = logger;
            _examsService = examsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetExams()
        {
            var exams = await _examsService.GetAllExamsAsync();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var exam = await _examsService.GetExamAsync(id);
            if (exam == null) return NotFoundResponse(id);
            return Ok(exam);
        }


        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody] ExamDTO exam)
        {
            var actualizada = await _examsService.UpdateExamAsync(exam);
            if (actualizada == null) return NotFoundResponse(exam.Id);

            return Ok(actualizada);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExamDTO exam)
        {
            if (exam == null) return BadRequest("Los datos de la exam son inválidos.");

            var creada = await _examsService.AddExamAsync(exam);
            return CreatedAtAction(nameof(Details), new { id = creada.Id }, creada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exam = await _examsService.GetExamAsync(id);
            if (exam == null) return NotFound($"No se encontró el examen con ID {id}.");

            await _examsService.DeleteExamsAsync(id);
            return NoContent();
        }
        // Método auxiliar para manejar la respuesta NotFound con mensaje detallado
        private IActionResult NotFoundResponse(int id)
        {
            return NotFound($"No se encontró el examen con ID {id}.");
        }
    }
}
