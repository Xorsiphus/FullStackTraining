using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FirstApp.Models
{
    public class StudentsCart
    {
        private readonly AppDbContext _context;

        public StudentsCart(AppDbContext context) =>
            _context = context;

        private string CartId { get; set; }
        public List<StudentForExpulsion> StudentList { get; set; }
        
        // public int GetCartId { set; get; }

        public static StudentsCart GetStudentsCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            string studentsCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", studentsCartId);
            var context = services.GetService<AppDbContext>();
            return new StudentsCart(context) { CartId = studentsCartId };
        }

        public void AddToCart(Student student)
        {
            _context.StudentsForExpulsion.Add(new StudentForExpulsion
            {
                CartId = CartId,
                Student = student,
                Misses = student.Misses
            });
            _context.SaveChanges();
        }

        public List<StudentForExpulsion> GetStudentsForExpulsion()
        {
            var temp = _context.StudentsForExpulsion.Where(p => p.CartId == CartId)
                .Include(s => s.Student).ToList();
                // .Where(p => p.CartId == CartId);
            foreach (var t in temp)
            {
                Console.WriteLine(t.Student);
            }
            return _context.StudentsForExpulsion
                .Where(p => p.CartId == CartId)
                .Include(s => s.Student).ToList();
        }
    }
}