using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullstackChat.Data.DAO;
using FullstackChat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullstackChat.Data.Repositories
{
    public class MessageRepository : IMessage
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context) =>
            _context = context;


        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByChatId(int chatId) =>
            await _context.Messages.Where(m => m.ChatId == chatId).ToListAsync();

        public async Task<ActionResult<int>> AddMessage(Message message)
        {
            await _context.Messages.AddAsync(message);
            return await _context.SaveChangesAsync();
        }
    }
}