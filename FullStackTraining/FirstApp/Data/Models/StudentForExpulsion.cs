using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Models
{
    [Index("StudentId", IsUnique = false)]
    public class StudentForExpulsion
    {
        [Key] 
        public int Id { get; set; }

        public string CartId { get; set; }
        
        [Required]
        public int StudentId { get; set; }

        [Required] 
        public int Misses { get; set;  }
        
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}