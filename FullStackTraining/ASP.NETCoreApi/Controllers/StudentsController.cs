using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreApi.Data;
using ASP.NETCoreApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context) =>
            _context = context;

        private StatusCodeResult CheckEntity(Student s)
        {
            if (s == null)
            {
                return BadRequest();
            }
            
            if (_context.Students.Any(cs => cs.Id != s.Id))
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
            
            if (_context.Students.Any(cs => cs.Id == s.Id))
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents() =>
            await _context.Students.ToListAsync();
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Student>> GetStudentById(int id) =>
            await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student s)
        {
            var status = CheckEntity(s);
        
            if (CheckEntity(s).GetType() == typeof(OkResult))
                return status;
        
            _context.Students.Add(s);
            await _context.SaveChangesAsync();
            return Ok(s);
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Student>> DeleteStudentById(int id)
        {
            if (_context.Students.Any(cs => cs.Id != id))
            {
                return NotFound();
            }
            
            _context.Students
                .Remove(new Student {Id = id});
            await _context.SaveChangesAsync();
            return Ok("Removed student with Id = " + id);
        }
        
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Student>> UpdateStudentByIdWithPatch(int id, Student s)
        {
            var status = CheckEntity(s, id);
            
            if (CheckEntity(s).GetType() == typeof(OkResult))
                return status;
            
            var updated = _context.Update(s).Entity;
            await _context.SaveChangesAsync();
            return Ok(updated);
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Student>> UpdateStudentByIdWithPut(Student s, int id)
        {
            var status = CheckEntity(s, id);
        
            if (CheckEntity(s).GetType() == typeof(OkResult))
                return status;
            
            var updated = _context.Students.Update(s);
            await _context.SaveChangesAsync();
            return Ok(updated);
        }
        
        [HttpHead]
        public async Task<ActionResult<IEnumerable<Student>>> HeadStudents() =>
            await _context.Students.ToListAsync();
        
        [HttpHead]
        [Route("{id:int}")]
        public async Task<ActionResult<Student>> HeadStudentById(int id) =>
            await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

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