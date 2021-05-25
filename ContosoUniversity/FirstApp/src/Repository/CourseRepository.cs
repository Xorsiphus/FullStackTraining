using System.Collections.Generic;
using System.Linq;
using FirstApp.DAO;
using FirstApp.Models;

namespace FirstApp.Repository
{
    public class CourseRepository : ICourse
    {
        private readonly AppDbContext Context;

        public CourseRepository(AppDbContext context) =>
            Context = context;

        public IEnumerable<Course> Courses =>
            Context.Courses.ToList();

        public Course GetCourse(int id) =>
            Context.Courses.FirstOrDefault(p => p.CourseId == id);
    }
}