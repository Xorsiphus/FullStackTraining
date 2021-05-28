using System.Collections.Generic;
using System.Linq;
using FirstApp.DAO;
using FirstApp.Models;

namespace FirstApp.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) =>
            _context = context;

        public IEnumerable<Student> Students =>
            _context.Students.ToList();

        public Student GetStudent(int id) =>
            _context.Students.FirstOrDefault(p => p.Id == id);
    }
}