using System.Collections.Generic;
using ASP.NETCoreApi.Data.Models;

namespace ASP.NETCoreApi.Data.DAO
{
    public interface IEnrollment
    {
         public IEnumerable<Enrollment> Enrollments { get; }
                
         public Enrollment GetEnrollment(int id);
    }
}