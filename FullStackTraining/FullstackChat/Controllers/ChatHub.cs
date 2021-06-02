using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace FullstackChat.Controllers
{
    public class ChatHub : Hub
    {
        // public override Task OnConnectedAsync()
        // {
        //     
        //     return base.OnConnectedAsync();
        // }
        
        // public async Task ClientServerMessage(string user, string message)
        // {
        //     Console.WriteLine(user + message);
        //     await Clients.All.SendAsync("ServerClientMessage", user, message);
        // }
    }
}