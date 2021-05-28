using System.Collections.Generic;
using System.Linq;
using ASP.NETCoreApi.Data.DAO;
using ASP.NETCoreApi.Data.Models;

namespace ASP.NETCoreApi.Data.Repository
{
    public class CourseRepository : ICourse
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context) =>
            _context = context;

        public IEnumerable<Course> Courses =>
            _context.Courses.ToList();

        public Course GetCourse(int id) =>
            _context.Courses.FirstOrDefault(p => p.CourseId == id);
    }
}