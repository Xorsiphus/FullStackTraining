using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApp.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required] public string Avatar { get; set; }
        public string FirstMidName { get; set; }

        [Required] 
        public int Misses { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }
    }
}