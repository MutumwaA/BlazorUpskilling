using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace WebUI.SignalRConnection
{
    public class SignalRConnection(NavigationManager NavManager)
    {
        public event Action? ConnectionStateChanged;
        public string ConnectionState = string.Empty;
        public readonly HubConnection hubConnection = new HubConnectionBuilder().WithUrl(NavManager.ToAbsoluteUri("https://localhost:7227/connect")).Build();

        public async Task StartConnection()
        {
            if(hubConnection.State != HubConnectionState.Connected)
            {
                await hubConnection.StartAsync();   
            }
            GetConnectionState();
        }
        public async Task StopConnection()
        {
            if (hubConnection.State != HubConnectionState.Connected)
            {
                await hubConnection.StopAsync();
            }
            GetConnectionState();
        }
        public void GetConnectionState()
        {
            switch(hubConnection.State)
            {
                case HubConnectionState.Connected:
                    Invoke("Connected");
                    break;

                case HubConnectionState.Connecting:
                    Invoke("Connecting");
                    break;
                case HubConnectionState.Reconnecting:
                    Invoke("Reconnecting");
                    break;
                case HubConnectionState.Disconnected:
                    Invoke("Disconnected");
                    break;
                default:
                    ConnectionState = "Unknown error occured";
                    break;

            };
        }
        void Invoke(string message)
        {
            ConnectionState = message;
            ConnectionStateChanged.Invoke();
        }   
    }
}
