using System.Threading.Tasks;
using FullstackChat.Data;
using FullstackChat.Data.Repositories;
using FullstackChat.Models.Transfers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FullstackChat.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/Linker")]
    public class ChatUserLinkerController : ControllerBase
    {
        private readonly ChatUserLinkerRepository _repository;
        private readonly IHubContext<ChatHub> _hub;

        public ChatUserLinkerController(ApplicationDbContext repository, IHubContext<ChatHub> hubContext)
        {
            _repository = new ChatUserLinkerRepository(repository);
            _hub = hubContext;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddNewLink(LinkTransfer transfer)
        {
            var user = await _repository.GetUserByUsername(transfer.UserName);
            // await _hub.Clients.User(user.Id).SendAsync("ChatInvite", transfer.SenderName + ";" + transfer.ChatName);
            await _hub.Clients.All.SendAsync("ChatInvite", transfer.SenderName + ";" + transfer.ChatName);
            return await _repository.NewChatUserLink(transfer);
        }
    }
}