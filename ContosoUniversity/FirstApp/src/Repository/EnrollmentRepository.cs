using System.Collections.Generic;
using System.Linq;
using FirstApp.DAO;
using FirstApp.Models;

namespace FirstApp.Repository
{
    public class EnrollmentRepository : IEnrollment
    {
        private readonly AppDbContext Context;

        public EnrollmentRepository(AppDbContext context) =>
            Context = context;

        public IEnumerable<Enrollment> Enrollments =>
            Context.Enrollments.ToList();

        public Enrollment GetEnrollment(int id) =>
            Context.Enrollments.FirstOrDefault(p => p.EnrollmentId == id);
    }
}