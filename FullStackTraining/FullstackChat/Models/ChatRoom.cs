using System.ComponentModel.DataAnnotations;

namespace FullstackChat.Models
{
    public class ChatRoom
    {
        [Key]
        public int ChatId { get; set; }
        
        [Required]
        public string ChatName { get; set; }
    }
}