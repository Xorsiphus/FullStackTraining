using System.Collections.Generic;
using ASP.NETCoreApi.Data.Models;

namespace ASP.NETCoreApi.Data.DAO
{
    public interface ICourse
    {
        public IEnumerable<Course> Courses { get; }
                        
        public Course GetCourse(int id);
    }
}