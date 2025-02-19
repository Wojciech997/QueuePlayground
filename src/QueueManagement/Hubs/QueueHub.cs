using Microsoft.AspNetCore.SignalR;
using QueueManagement.Dtos;
using QueueManagement.Services;

namespace QueueManagement.Hubs;

public class QueueHub(IQueueService queueService) : Hub
{
    public async Task Enqueue()
    {
        var queueDto = new QueueDto();
        queueDto.Id = Guid.NewGuid();
        await queueService.EnqueueAsync(queueDto);
        var queue = await queueService.GetAllAsync();
        await Clients.All.SendAsync("QueueUpdated", queue);
    }

    public async Task Dequeue()
    {
        var dequeuedUser = await queueService.DequeueAsync();
        var queue = await queueService.GetAllAsync();
        var next = await queueService.GetFirst();
        await Clients.All.SendAsync("QueueUpdated", queue);
    }
    
    public override async Task OnConnectedAsync()
    {
        var queue = await queueService.GetAllAsync();
        await Clients.Caller.SendAsync("QueueUpdated", queue);
        await base.OnConnectedAsync();
    }
    
    
}