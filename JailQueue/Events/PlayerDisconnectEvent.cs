using CounterStrikeSharp.API.Core;
using JailQueue.Services;
using JailQueueApi.Interfaces;

namespace JailQueue.Events;

public class PlayerDisconnectEvent
{
    private IQueueService _queueService = new QueueService();
    private ICTService _CTService = new CTService();

    public HookResult Handler(EventPlayerDisconnect @event, GameEventInfo info)
    {
        var player = @event.Userid!;
        
        if (_queueService.Contains(player))
            _queueService.LeaveQueue(player);

        if (ICTService.CTList.Contains(player))
            _CTService.Remove(player);

        return HookResult.Continue;
    }
}