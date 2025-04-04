using Microsoft.AspNetCore.SignalR;

namespace API.SignalRConnectionHub
{
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;

    public class SignalRConnectionHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("AllClientsNotification", $"{Context.ConnectionId} has joined {Environment.NewLine}");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("AllClientsNotification", $"{Context.ConnectionId} left");
            await base.OnDisconnectedAsync(exception);
        }
    }



}
