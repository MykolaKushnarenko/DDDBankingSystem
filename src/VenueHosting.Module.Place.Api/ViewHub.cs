using Microsoft.AspNetCore.SignalR;

namespace VenueHosting.Module.Place.Api;

public class ViewHub : Hub
{
    public static int ViewCount { get; set; } = 0;

    public async Task NotifyWatching()
    {
        ViewCount++;

        await Clients.All.SendAsync("viewCountUpdate", ViewCount);
    }


    public override async Task OnConnectedAsync()
    {
        ViewCount++;

        await Clients.All.SendAsync("viewCountUpdate", ViewCount);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        ViewCount--;

        await Clients.All.SendAsync("viewCountUpdate", ViewCount);
        await base.OnDisconnectedAsync(exception);
    }
}