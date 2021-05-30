using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreApi.Data.DAO;
using ASP.NETCoreApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreApi.Data.Repository
{
    public class CourseRepository : ICourse
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context) =>
            _context = context;

        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.GroupBy(c => c.Title)
                .Select(g => g.OrderBy(c => c.Title).FirstOrDefault())
                .OrderBy(c => c.Title)
                .ToListAsync();
            // return await _context.Courses.ToListAsync();
        }

        public async Task<ActionResult<Course>> GetCourse(int id) =>
            await _context.Courses.FirstOrDefaultAsync(p => p.CourseId == id);
    }
}