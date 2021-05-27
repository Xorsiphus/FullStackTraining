using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApp.Models
{
    public class StudentForExpulsion
    {
        [Key] 
        public int Id { get; set; }

        public string CartId { get; set; }
        
        [Required]
        public int StudentId { get; set; }

        [Required] 
        public int Misses { get; set;  }
        
        public Student Student { get; set; }
    }
}