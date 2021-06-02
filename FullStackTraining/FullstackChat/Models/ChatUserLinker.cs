using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FullstackChat.Models
{
    [Index(nameof(ChatId), nameof(UserId), IsUnique = true)]
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