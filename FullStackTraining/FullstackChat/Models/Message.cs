using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullstackChat.Models
{
    public class Message
    {
        [Key] 
        public string Id { get; set; }

        [ForeignKey("ChatRoom")]
        public int ChatId { get; set; }

        [ForeignKey("AspNetUsers")] 
        public int UserId { get; set; }
        
        public string Text { get; set; }
        
        public DateTime Date { get; set; }
    }
}