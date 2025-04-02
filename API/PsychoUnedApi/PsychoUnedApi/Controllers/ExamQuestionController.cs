using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PsychoUnedApi.DataModel;
using PsychoUnedApi.Interfaces;
using PsychoUnedApi.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PsychoUnedApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamQuestionController : ControllerBase
    {

        private readonly ILogger<ExamQuestionController> _logger;
        private readonly IExamQuestionService _examsQuestionService;

        public ExamQuestionController(ILogger<ExamQuestionController> logger, IExamQuestionService examsService)
        {
            _logger = logger;
            _examsQuestionService = examsService;
        }
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilterExam([FromQuery] int idExam)
        {
            var subjects = await _examsQuestionService.GetExamsQuestionByExamAsync(idExam);
            return Ok(subjects);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionExams(int id)
        {

            var subject = await _examsQuestionService.GetExamQuestionAsync(id);
            if (subject == null) return NotFoundResponse(id);
            return Ok(subject);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ExamsQuestionDTO value)
        {
            if (value == null) return BadRequest("Los datos de la subject son inválidos.");

            var creada = await _examsQuestionService.AddExamQuestionAsync(value);
            return CreatedAtAction(nameof(Details), new { id = creada.Id }, creada);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditQuestion([FromBody] ExamsQuestionDTO value)
        {
            var actualizada = await _examsQuestionService.UpdateExamQuestionAsync(value);
            if (actualizada == null) return NotFoundResponse(value.Id);

            return Ok(actualizada);
        }
        private IActionResult NotFoundResponse(int id)
        {
            return NotFound($"No se encontró la pregunta con ID {id}.");
        }
    }
}
