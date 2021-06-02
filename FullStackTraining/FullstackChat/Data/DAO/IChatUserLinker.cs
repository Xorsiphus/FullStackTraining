using System.Threading.Tasks;
using FullstackChat.Models;
using FullstackChat.Models.Transfers;
using Microsoft.AspNetCore.Mvc;

namespace FullstackChat.Data.DAO
{
    public interface IChatUserLinker
    {
        public Task<ActionResult<int>> NewChatUserLink(LinkTransfer transfer);
        
        public Task<ChatRoom> GetChatById(int id);
        
        public Task<ApplicationUser> GetUserByUsername(string userName);
    }
}