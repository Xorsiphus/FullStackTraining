using System;
using System.Threading.Tasks;
using FullstackChat.Data;
using FullstackChat.Data.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace FullstackChat.Controllers
{
    public class ChatHub : Hub
    {
        // public override Task OnConnectedAsync()
        // {
        //     Console.WriteLine(Context.User);
        //     return base.OnConnectedAsync();
        // }
        
        // public async Task LinkerClient(string senderName, string chatName)
        // {
        //     Console.WriteLine(senderName + chatName + Context.ConnectionId);
        //     // await Clients.All.SendAsync("ServerClientMessage", senderName, chatName);
        // }
    }
}