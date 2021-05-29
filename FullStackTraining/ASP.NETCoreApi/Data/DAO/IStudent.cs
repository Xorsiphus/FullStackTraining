using System.Collections.Generic;
using System.Threading.Tasks;
using ASP.NETCoreApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreApi.Data.DAO
{
    public interface IStudent
    {
        public Task<ActionResult<IEnumerable<Student>>> GetStudents();
        
        public Task<ActionResult<Student>> GetStudentById(int id);

        public Task<int> AddStudent(Student s);
        
        public Task<int> UpdateStudent(Student s);

        public Task<int> DeleteStudent(int id);

        public bool CheckStudentById(int id);
    }
}