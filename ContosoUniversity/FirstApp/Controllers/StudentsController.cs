using System;
using System.Collections.Generic;
using System.Linq;
using FirstApp.Models;
using FirstApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [Route("")]
    public class StudentsController : Controller
    {
        private readonly AppDbContext Context;
        // private readonly StudentRepository _studentRepository;

        public StudentsController(AppDbContext context) => 
            Context = context;

        public ViewResult Resolver()
        {
            ViewData["Title"] = "Students";
            IEnumerable<Student> transfer = Context.Students.ToList();
            return View(transfer);
        }
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