using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;

namespace JailQueue.Events;

public class PlayerDisconnectEvent
{
    public HookResult Handler(EventPlayerDisconnect @event, GameEventInfo info)
    {
        var player = @event.Userid;
        if (player != null && player.IsValid)
        {
            if (QueueService.IsPlayerInQueue[player.Index] && player.Team != CsTeam.CounterTerrorist)
            {
                QueueService.RemovePlayerFromCTQueue(player);
                QueueService.RemovePlayerFromQueue(player);
            }
        }

        return HookResult.Continue;
    }
}