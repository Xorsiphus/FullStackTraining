using System.Collections.Generic;
using FirstApp.Models;

namespace FirstApp.ViewModels
{
    public class StudentsListViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public bool IsCart { get; set; }
    }
}