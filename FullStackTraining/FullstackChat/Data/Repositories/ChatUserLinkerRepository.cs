using System.Linq;
using System.Threading.Tasks;
using FullstackChat.Data.DAO;
using FullstackChat.Models;
using FullstackChat.Models.Transfers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullstackChat.Data.Repositories
{
    public class ChatUserLinkerRepository : IChatUserLinker
    {
        private readonly ApplicationDbContext _context;

        public ChatUserLinkerRepository(ApplicationDbContext context) =>
            _context = context;

        public async Task<ActionResult<int>> NewChatUserLink(LinkTransfer transfer)
        {
            var user = await _context.ApplicationUsers.Where(u => u.Email == transfer.UserName).FirstOrDefaultAsync();

            if (user == new ApplicationUser())
                return await _context.SaveChangesAsync();

            await _context.ChatUserLinkers.AddAsync(new ChatUserLinker
                {ChatId = transfer.ChatId, UserId = user.Id});
            return await _context.SaveChangesAsync();
        }

        public async Task<ChatRoom> GetChatById(int id) =>
            await _context.ChatRooms.FirstOrDefaultAsync(u => u.ChatId == id);

        public async Task<ApplicationUser> GetUserByUsername(string userName) =>
            await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.UserName == userName);
    }
}