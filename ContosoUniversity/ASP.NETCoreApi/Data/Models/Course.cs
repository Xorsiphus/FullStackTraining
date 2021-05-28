using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NETCoreApi.Data.Models
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        
        [Required]
        public string Title { get; set; }
        public int Credits { get; set; }
        
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}