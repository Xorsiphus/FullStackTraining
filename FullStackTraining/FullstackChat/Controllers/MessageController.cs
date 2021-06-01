using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FullstackChat.Data;
using FullstackChat.Data.Repositories;
using FullstackChat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FullstackChat.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/Messages")]
    public class MessageController : ControllerBase
    {
        private readonly MessageRepository _repository;
        private readonly IHubContext<ChatHub> _hub;

        public MessageController(ApplicationDbContext repository, IHubContext<ChatHub> hubContext)
        {
            _repository = new MessageRepository(repository);
            _hub = hubContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByUserAndChatId(string userId, int chatId) =>
            await _repository.GetMessagesByUserAndChatId(userId, chatId);


        [HttpPost]
        public async Task<ActionResult<int>> AddMessage(Message message)
        {
            message.Date = DateTime.Now;
            await _hub.Clients.All.SendAsync("NewMessage", message);
            return await _repository.AddMessage(message);
        }
    }
}