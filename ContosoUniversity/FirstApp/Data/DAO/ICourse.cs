using System.Collections.Generic;
using FirstApp.Models;

namespace FirstApp.DAO
{
    public interface ICourse
    {
        public IEnumerable<Course> Courses { get; }
                        
        public Course GetCourse(int id);
    }
}