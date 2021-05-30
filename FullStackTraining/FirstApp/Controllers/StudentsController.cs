using System.Linq;
using FirstApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("")]
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context) =>
            _context = context;

        public ViewResult Resolver()
        {
            ViewData["Title"] = "Students";

            StudentsListViewModel transfer = new StudentsListViewModel
            {
                Students = _context.Students.ToList(),
                Courses = _context.Courses
                    .ToList()
                    .ConvertAll(c => c.Title)
                    .Distinct()
            };

            return View(transfer);
        }
    }
}
