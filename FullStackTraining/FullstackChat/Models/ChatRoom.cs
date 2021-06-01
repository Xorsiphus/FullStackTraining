using System.ComponentModel.DataAnnotations;

namespace FullstackChat.Models
{
    public class ChatRoom
    {
        [Key]
        public int ChatId { get; set; }
        
        public string ChatName { get; set; }
    }
}