using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FullstackChat.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullstackChat.Data.DAO
{
    public interface IMessage
    {
         public Task<ActionResult<IEnumerable<Message>>> GetMessagesByUserAndChatId(string userId, int chatId);
         
         public Task<ActionResult<int>> AddMessage(Message message);
    }
}