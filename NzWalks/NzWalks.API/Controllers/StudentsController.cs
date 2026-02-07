using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NzWalks.API.Controllers
{
    //https://localhost:44328/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] students = new string[] { "John", "Jane", "Jack" };
            return Ok(students);
        }
    }
}
