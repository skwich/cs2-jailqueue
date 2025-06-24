using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;

namespace JailQueue.Events;

public class RoundEndEvent
{
    private IQueueService _queueService = new QueueService();

    public HookResult Handler(EventRoundEnd @event, GameEventInfo info)
    {
        if (_queueService.Count() != 0 && _queueService.CanJoinCT())
        {
            foreach (var player in IQueueService.queue)
            {
                if (!_queueService.CanJoinCT())
                    break;

                _queueService.LeaveQueue(player);
                player.ChangeTeam(CsTeam.CounterTerrorist);
            }
        }

        return HookResult.Continue;
    }
}