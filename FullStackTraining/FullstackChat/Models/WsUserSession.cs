using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullstackChat.Models
{
    public class WsUserSession
    {
        [Key]
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        [Required]
        public string WsToken { get; set; }
    }
}