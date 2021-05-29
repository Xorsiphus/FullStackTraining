using System.Collections.Generic;
using System.Threading.Tasks;
using ASP.NETCoreApi.Data;
using ASP.NETCoreApi.Data.Models;
using ASP.NETCoreApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentRepository _studentRepository;

        public StudentsController(AppDbContext context) =>
            _studentRepository = new StudentRepository(context);


        private StatusCodeResult CheckEntity(Student s)
        {
            if (s == null)
            {
                return BadRequest();
            }

            if (_studentRepository.CheckStudentById(s.Id))
            {
                return NotFound();
            }

            return Ok();
        }

        private StatusCodeResult CheckEntity(Student s, int id)
        {
            if (s == null)
            {
                return BadRequest();
            }

            if (s.Id != id)
            {
                return BadRequest();
            }

            if (_studentRepository.CheckStudentById(s.Id))
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> HttpGetStudents() =>
            await _studentRepository.GetStudents();

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Student>> GetStudentById(int id) =>
            await _studentRepository.GetStudentById(id);

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student s)
        {
            var status = CheckEntity(s);

            if (CheckEntity(s).GetType() == typeof(OkResult))
                return status;

            await _studentRepository.AddStudent(s);
            return Ok(s);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Student>> DeleteStudentById(int id)
        {
            if (_studentRepository.CheckStudentById(id))
            {
                return NotFound();
            }

            await _studentRepository.DeleteStudent(id);
            return Ok("Removed student with Id = " + id);
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Student>> UpdateStudentByIdWithPatch(Student s, int id)
        {
            var status = CheckEntity(s, id);

            if (CheckEntity(s).GetType() == typeof(OkResult))
                return status;

            await _studentRepository.UpdateStudent(s);
            return Ok(s);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Student>> UpdateStudentByIdWithPut(Student s, int id)
        {
            var status = CheckEntity(s, id);

            if (CheckEntity(s).GetType() == typeof(OkResult))
                return status;

            await _studentRepository.UpdateStudent(s);
            return Ok(s);
        }

        [HttpHead]
        public async Task<ActionResult<IEnumerable<Student>>> HeadStudents() =>
            await _studentRepository.GetStudents();

        [HttpHead]
        [Route("{id:int}")]
        public async Task<ActionResult<Student>> HeadStudentById(int id) =>
            await _studentRepository.GetStudentById(id);

//         [HttpOptions]
// #pragma warning disable 1998
//         public async Task<ActionResult<HttpResponse>> OptionsAboutApi()
// #pragma warning restore 1998
//         {
//             // HttpContext.Response.Headers.Add("Allow", new StringValues("OPTIONS, GET, HEAD, POST"));
//             HttpContext.Response.Headers.Add("Allow", 
//                 new StringValues(new []{"OPTIONS", "GET", "HEAD", "POST"}));
//             // ResponseHeadersChanger.AddOptions(Response);
//             return Ok();
//         }
    }
}