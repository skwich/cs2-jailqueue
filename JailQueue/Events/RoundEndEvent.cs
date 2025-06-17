using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;

namespace JailQueue.Events;

public class RoundEndEvent
{
    public HookResult Handler(EventRoundEnd @event, GameEventInfo info)
    {
        RoundService.IsRoundEnd = true;
        if (QueueService.CTQueue.Count != 0 && QueueService.IsPlayerCanJoinToCT())
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