using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullstackChat.Models
{
    public class ChatUserLinker
    {
        [Key] 
        public int LinkId { get; set; }

        [ForeignKey("ChatRoom")]
        public int ChatId { get; set; }

        [ForeignKey("AspNetUsers")] 
        public string UserId { get; set; }
    }
}