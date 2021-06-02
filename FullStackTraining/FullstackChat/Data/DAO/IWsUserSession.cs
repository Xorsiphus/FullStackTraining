using System.Threading.Tasks;
using FullstackChat.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullstackChat.Data.DAO
{
    public interface IWsUserSession
    {
        public Task<ActionResult<WsUserSession>> GetTokenByUserId(string userId);
        
        public int AddToken(string userId, string token);
    }
}