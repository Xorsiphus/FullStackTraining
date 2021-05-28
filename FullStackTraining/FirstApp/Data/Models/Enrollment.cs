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
        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        
        [Required]
        [ForeignKey("Students")]
        public int StudentId { get; set; }
        
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}