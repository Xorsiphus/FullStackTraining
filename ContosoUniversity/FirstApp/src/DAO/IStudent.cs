using System.Collections.Generic;
using FirstApp.Models;

namespace FirstApp.DAO
{
    public interface IStudent
    {
        public IEnumerable<Student> Students { get; }
        
        public Student GetStudent(int id);
    }
}