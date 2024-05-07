using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

namespace D2XCP0_HFT_2022232.Endpoint.Services
{
    public class SignalRHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.Caller.SendAsync("Disconnected", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task NotifyItemCreated(object item)
        {
            await Clients.All.SendAsync(item.GetType().ToString() + "Created", item);
        }

        public async Task NotifyItemDeleted(object item)
        {
            Type itemType = item.GetType();
            string propName = itemType.Name + "ID";
            PropertyInfo property = itemType.GetProperty(propName);

            if (property != null && property.PropertyType == typeof(int))
            {
                await Clients.All.SendAsync(item.GetType().ToString() + "Deleted", (int)property.GetValue(item));
            }
            
        }

        public async Task NotifyItemUpdated(object item)
        {
            await Clients.All.SendAsync(item.GetType().ToString() + "Updated", item);
        }
    }
}
