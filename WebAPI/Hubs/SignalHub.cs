using Microsoft.AspNetCore.SignalR;
using WebAPI.Model;

namespace WebAPI.Hubs
{
    public class SignalHub : Hub
    {
        public void BroadcastEmployee(Employee emp)
        {
            Clients.Client(emp.clientid).SendAsync("ReceiveEmployee", emp);
        }
        public void BroadcastMessage(string message)
        {
            Clients.All.SendAsync("ReceiveMessage", message);
        }
        public override Task OnConnectedAsync()
        {
            ConnectedUsers.Ids.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            ConnectedUsers.Ids.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
