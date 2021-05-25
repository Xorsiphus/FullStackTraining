using System.Collections.Generic;
using System.Linq;
using FirstApp.DAO;
using FirstApp.Models;

namespace FirstApp.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly AppDbContext Context;

        public StudentRepository(AppDbContext context) =>
            Context = context;

        public IEnumerable<Student> Students =>
            Context.Students.ToList();

        public Student GetStudent(int id) =>
            Context.Students.FirstOrDefault(p => p.id == id);
    }
}