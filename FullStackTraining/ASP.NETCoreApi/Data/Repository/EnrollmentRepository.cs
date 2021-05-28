using System.Collections.Generic;
using System.Linq;
using ASP.NETCoreApi.Data.DAO;
using ASP.NETCoreApi.Data.Models;

namespace ASP.NETCoreApi.Data.Repository
{
    public class EnrollmentRepository : IEnrollment
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context) =>
            _context = context;

        public IEnumerable<Enrollment> Enrollments =>
            _context.Enrollments.ToList();

        public Enrollment GetEnrollment(int id) =>
            _context.Enrollments.FirstOrDefault(p => p.EnrollmentId == id);
    }
}