using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PsychoUnedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamQuestionAnswersController : ControllerBase
    {

        // GET: api/<ExamQuestionAnswersController>
        [HttpGet]
        public IEnumerable<string> Get([FromQuery] int? year, [FromQuery] int? week, [FromQuery] int? idExam)
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/<ExamQuestionAnswersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExamQuestionAnswersController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<ExamQuestionAnswersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<ExamQuestionAnswersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
