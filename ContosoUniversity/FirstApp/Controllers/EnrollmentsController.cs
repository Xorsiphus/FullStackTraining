using System.Collections.Generic;
using System.Linq;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("Enrollments")]
    public class EnrollmentsController : Controller
    {
        private readonly AppDbContext Context;
        // private readonly StudentRepository _studentRepository;

        public EnrollmentsController(AppDbContext context) => 
            Context = context;
        
        public ViewResult Resolver()
        {
            ViewData["Title"] = "Enrollments";
            IEnumerable<Enrollment> transfer = Context.Enrollments.ToList();
            return View(transfer);
        }
    }
}