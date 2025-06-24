using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;

namespace JailQueue.Events;

public class PlayerDisconnectEvent
{
    private IQueueService _queueService = new QueueService();

    public HookResult Handler(EventPlayerDisconnect @event, GameEventInfo info)
    {
        var player = @event.Userid!;
        if (_queueService.Contains(player) && player.Team != CsTeam.CounterTerrorist)
        {
            _queueService.LeaveQueue(player);
        }

        return HookResult.Continue;
    }
}