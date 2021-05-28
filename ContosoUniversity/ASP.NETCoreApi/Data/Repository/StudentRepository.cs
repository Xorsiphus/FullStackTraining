using System.Collections.Generic;
using System.Linq;
using ASP.NETCoreApi.Data.DAO;
using ASP.NETCoreApi.Data.Models;

namespace ASP.NETCoreApi.Data.Repository
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