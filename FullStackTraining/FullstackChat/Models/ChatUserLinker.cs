using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullstackChat.Models
{
    public class ChatUserLinker
    {
        [Key] 
        public int LinkId { get; set; }

        [ForeignKey("ChatRoom")]
        [Required]
        public int ChatId { get; set; }

        [ForeignKey("AspNetUsers")] 
        [Required]
        public string UserId { get; set; }
    }
}