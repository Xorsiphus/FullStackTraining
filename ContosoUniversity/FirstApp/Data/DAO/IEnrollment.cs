using System.Collections.Generic;
using FirstApp.Models;

namespace FirstApp.DAO
{
    public interface IEnrollment
    {
         public IEnumerable<Enrollment> Enrollments { get; }
                
         public Enrollment GetEnrollment(int id);
    }
}