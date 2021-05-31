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
    public class CoursesController
    {
        private readonly CourseRepository _courseRepository;

        public CoursesController(AppDbContext context) =>
            _courseRepository = new CourseRepository(context);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> HttpGetCourses() =>
            await _courseRepository.GetCourses();
    }
}