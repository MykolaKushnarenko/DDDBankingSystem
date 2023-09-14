using Microsoft.AspNetCore.SignalR;

namespace VenueHosting.Module.Place.Api;

public class CategoryHub : Hub
{
    public async Task AddToCategory(string category)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, category);
    }

    public async Task TriggerGroup(string category)
    {
        await Clients.Groups(category).SendAsync("onTriggerGroup");
    }
}