using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApp.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    
    [Table("Enrollments")]
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        
        [Required]
        public int CourseId { get; set; }
        
        [Required]
        public int StudentId { get; set; }
        
        public Grade? Grade { get; set; }
    }
}