using CounterStrikeSharp.API.Core;
using JailQueue.Services;

namespace JailQueue.Events;

public class PlayerDisconnectEvent
{
    private QueueService _queueService = new();
    private CTService _ctService = new();

    public HookResult Handler(EventPlayerDisconnect @event, GameEventInfo info)
    {
        var player = @event.Userid!;
        
        if (_queueService.Contains(player))
            _queueService.LeaveQueue(player);

        if (_ctService.Contains(player))
            _ctService.Remove(player);

        return HookResult.Continue;
    }
}