using System.Linq;
using FirstApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("")]
    public class StudentsController : Controller
    {
        private readonly AppDbContext Context;

        public StudentsController(AppDbContext context) =>
            Context = context;

        public ViewResult Resolver()
        {
            ViewData["Title"] = "Students";
            
            StudentsListViewModel transfer = new StudentsListViewModel
            {
                Students = Context.Students.ToList(),
                Courses = Context.Courses
                    .ToList()
                    .ConvertAll(c => c.Title)
                    .Distinct()
            };
            
            return View(transfer);
        }

        // public RedirectToActionResult GroupByCourse(string course)
        // {
        //     
        //     
        //     return RedirectToAction("Resolver");
        // }
    }
}


// [HttpGet]
// public IActionResult GetStudent()
// {
//     var students = Context.Students.ToList();
//     // var enr = new Enrollment()
//     // {
//     //     StudentId=1,
//     //     CourseId=1050,
//     //     Grade=Grade.A
//     // };
//     //
//     // Context.Enrollments.Add(enr);
//     Context.SaveChanges();
//     
//     return Ok(students);
// }
//
//
// [HttpPost]
// public IActionResult CreateStudent()
// {
//     var student = new Student()
//     {
//         FirstMidName = "Nino", 
//         LastName = "Olivetto", 
//         EnrollmentDate = DateTime.Parse("2005-09-01")
//     };
//
//     Context.Add(student);
//     Context.SaveChanges();
//
//     return Ok("PostSuccess!");
// }