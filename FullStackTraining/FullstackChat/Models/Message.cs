using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullstackChat.Models
{
    public class Message
    {
        [Key] 
        public int Id { get; set; }

        [ForeignKey("ChatRoom")]
        [Required]
        public int ChatId { get; set; }

        [ForeignKey("AspNetUsers")] 
        [Required]
        public string UserId { get; set; }
        
        public string UserName { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
    }
}