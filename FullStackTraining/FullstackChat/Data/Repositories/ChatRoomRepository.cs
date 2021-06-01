using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullstackChat.Data.DAO;
using FullstackChat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullstackChat.Data.Repositories
{
    public class ChatRoomRepository : IChatRoom
    {
        private readonly ApplicationDbContext _context;

        public ChatRoomRepository(ApplicationDbContext context) =>
            _context = context;
        
        public async Task<ActionResult<IEnumerable<ChatRoom>>> GetChatRooms() =>
            await _context.ChatRooms.ToListAsync();

        public async Task<ActionResult<IEnumerable<ChatRoom>>> GetChatRoomsByUserId(string id) =>
            await _context.ApplicationUsers
                .Where(u => u.Id == id)
                .Join(
                    _context.ChatUserLinkers,
                    u => u.Id,
                    l => l.UserId,
                    (u, l) => l)
                .Join(
                    _context.ChatRooms,
                    l => l.ChatId,
                    c => c.ChatId,
                    (l, c) => c)
                .ToListAsync();
    }
}