using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreApi.Data.DAO;
using ASP.NETCoreApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreApi.Data.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) =>
            _context = context;

        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(p => p.Id == id);
        }
            
        public async Task<int> AddStudent(Student s)
        {
            await _context.Students.AddAsync(s);
            return await _context.SaveChangesAsync();
        }
        
        public async Task<int> UpdateStudent(Student s)
        {
            _context.Students.Update(s);
            return await _context.SaveChangesAsync();
        }
        
        public async Task<int> DeleteStudent(int id)
        {
            _context.Students.Remove(new Student { Id = id });
            return await _context.SaveChangesAsync();
        }

        public bool CheckStudentById(int id)
        {
            return _context.Students.Any(p => p.Id == id);
        }
    }
}