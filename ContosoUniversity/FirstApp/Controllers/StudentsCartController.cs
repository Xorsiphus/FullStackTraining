using System.Linq;
using FirstApp.DAO;
using FirstApp.Models;
using FirstApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class StudentsCartController : Controller
    {
        private readonly StudentsCart _studentsCart;
        private readonly IStudent _studentRepository;

        public StudentsCartController(StudentsCart studentsCart, IStudent studentRepository)
        {
            _studentRepository = studentRepository;
            _studentsCart = studentsCart;
        }

        [Route("Cart")]
        public ViewResult Resolver()
        {
            var items = _studentsCart.GetStudentsForExpulsion();
            _studentsCart.StudentList = items;
            StudentsCartViewModel transfer = new StudentsCartViewModel
            {
                StudentsCart = _studentsCart,
                SummaryMisses = _studentsCart.StudentList
                    .ConvertAll(s => s.Misses)
                    .Aggregate(0, (cur, next) => cur + next)
            };
            return View(transfer);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var student = _studentRepository.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _studentsCart.AddToCart(student);
            }

            return RedirectToAction("Resolver");
        }

        public RedirectToActionResult ClearCart()
        {
            _studentsCart.Clear();
            
            return RedirectToAction("Resolver", "Students");
        }
    }
}