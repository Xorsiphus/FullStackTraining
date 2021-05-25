using System.ComponentModel.DataAnnotations;

namespace FirstApp.Models
{
    public class StudentForExpulsion
    {
        [Key]
        public int Id { get; set;  }
        
        [Required]
        public int StudentId { get; set; }

        [Required] 
        public int Misses { get; set;  }

        public Student Student { get; set; }
    }
}