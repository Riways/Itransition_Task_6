using Microsoft.AspNetCore.SignalR;
using Task_6_Blazor_Server.Models;

namespace Task_6_Blazor_Server.Hubs
{
    public class MessageHub : Hub
    {

        public async Task AddMessage(UserModel reciever, MessageModel message)
        {
            await Clients.All.SendAsync("RecieveMessage", reciever, message);
        }
        
        public async Task NewUser(UserModel user)
        {
            await Clients.All.SendAsync("AddUser", user);
        }
    }
}
