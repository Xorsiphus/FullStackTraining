using System.Collections.Generic;
using System.Linq;
using FirstApp.Models;

namespace FirstApp.Repository
{
    public class StudentForExpulsionRepository
    {
         private readonly AppDbContext _context;

         public StudentForExpulsionRepository(AppDbContext context) =>
             _context = context;

         public IEnumerable<StudentForExpulsion> StudentsForExpulsion =>
             _context.StudentsForExpulsion.ToList();

         public StudentForExpulsion GetStudentForExpulsion(int id) =>
             _context.StudentsForExpulsion.FirstOrDefault(p => p.Id == id);
    }
}