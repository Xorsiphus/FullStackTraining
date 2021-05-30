using System.Collections.Generic;
using System.Threading.Tasks;
using ASP.NETCoreApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreApi.Data.DAO
{
    public interface ICourse
    {
        public Task<ActionResult<IEnumerable<Course>>> GetCourses();
                        
        public Task<ActionResult<Course>> GetCourse(int id);
    }
}