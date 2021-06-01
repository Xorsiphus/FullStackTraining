using System.Threading.Tasks;
using FullstackChat.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullstackChat.Data.DAO
{
    public interface IChatUserLinker
    {
        public Task<ActionResult<int>> NewChatUserLink(LinkTransfer transfer);
    }
}