using System.Collections.Generic;
using ASP.NETCoreApi.Data.Models;

namespace ASP.NETCoreApi.Data.DAO
{
    public interface IStudent
    {
        public IEnumerable<Student> Students { get; }
        
        public Student GetStudent(int id);
    }
}