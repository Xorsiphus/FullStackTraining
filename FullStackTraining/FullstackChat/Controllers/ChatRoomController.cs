using System.Collections.Generic;
using System.Threading.Tasks;
using FullstackChat.Data;
using FullstackChat.Data.Repositories;
using FullstackChat.Models;
using FullstackChat.Models.Transfers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullstackChat.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/ChatsList")]
    public class ChatRoomController : ControllerBase
    {
        private readonly ChatRoomRepository _repository;

        public ChatRoomController(ApplicationDbContext repository)
        {
            _repository = new ChatRoomRepository(repository);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatRoom>>> GetChatRoomsWithId(string userId)
        {
            if (userId == null)
            {
                return await _repository.GetChatRooms();
            }
            else
            {
                return await _repository.GetChatRoomsByUserId(userId);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddChatRoom(ChatTransfer transfer)
        {
            return await _repository.NewChatRoom(transfer);
        }
            
    }
}