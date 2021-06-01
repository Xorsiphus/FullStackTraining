using System.Collections.Generic;
using System.Threading.Tasks;
using FullstackChat.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullstackChat.Data.DAO
{
    public interface IChatRoom
    {
        public Task<ActionResult<IEnumerable<ChatRoom>>> GetChatRooms();

        public Task<ActionResult<IEnumerable<ChatRoom>>> GetChatRoomsByUserId(string id);
        
        public Task<ActionResult<int>> NewChatRoom(ChatTransfer transfer);
    }
}