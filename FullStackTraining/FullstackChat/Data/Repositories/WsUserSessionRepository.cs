using System.Threading.Tasks;
using FullstackChat.Data.DAO;
using FullstackChat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullstackChat.Data.Repositories
{
    public class WsUserSessionRepository : IWsUserSession
    {
        private readonly ApplicationDbContext _context;

        public WsUserSessionRepository(ApplicationDbContext context) =>
            _context = context;

        public async Task<ActionResult<WsUserSession>> GetTokenByUserId(string userId) =>
            await _context.WsUserSessions.FirstOrDefaultAsync(u => u.UserId == userId);
        
        public int AddToken(string userId, string token)
        {
            _context.WsUserSessions.Add(new WsUserSession { UserId = userId, WsToken = token });
            return _context.SaveChanges();
        }
    }
}