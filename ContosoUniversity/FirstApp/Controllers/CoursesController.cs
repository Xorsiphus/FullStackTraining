using System.Collections.Generic;
using System.Linq;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class CoursesController
    {
        private readonly AppDbContext Context;
        // private readonly StudentRepository _studentRepository;

        public CoursesController(AppDbContext context) =>
            Context = context;

        // public ViewResult Resolver()
        // {
        //     IEnumerable<Course> transfer = Context.Courses.ToList();
        //     return View(transfer);
        // }
    }
}
