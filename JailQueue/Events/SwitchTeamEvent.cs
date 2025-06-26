using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;
using JailQueueApi.Interfaces;

namespace JailQueue.Events;

public class SwitchTeamEvent
{
    private IServerService _serverService = new ServerService();
    private IQueueService _queueService = new QueueService();
    private ICTService _CTService = new CTService();

    public HookResult Handler(EventSwitchTeam @event, GameEventInfo info)
    {
        if (_serverService.CountCT() == 0 && _queueService.Count() != 0)
        {
            foreach (var player in IQueueService.queue)
            {
                if (!_queueService.CanJoinCT())
                    break;

                _queueService.LeaveQueue(player);
                player.ChangeTeam(CsTeam.CounterTerrorist);
                _CTService.Add(player);
            }
        }

        return HookResult.Continue;
    }
}