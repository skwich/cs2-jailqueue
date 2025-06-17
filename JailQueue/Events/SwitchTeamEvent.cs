using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;

namespace JailQueue.Events;

public class SwitchTeamEvent
{
    public HookResult Handler(EventSwitchTeam @event, GameEventInfo info)
    {
        if (ServerService.CTCount == 0 && QueueService.CTQueue.Count != 0)
        {
            foreach (var player in QueueService.CTQueue)
            {
                if (!QueueService.IsPlayerCanJoinToCT())
                    break;

                QueueService.RemovePlayerFromCTQueue(player);
                QueueService.RemovePlayerFromQueue(player);
                player.ChangeTeam(CsTeam.CounterTerrorist);
            }
        }

        return HookResult.Continue;
    }
}