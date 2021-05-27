using System.Linq;
using FirstApp.DAO;
using FirstApp.Models;
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
            return View(_studentsCart);
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
    }
}