using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueueApi.Interfaces;
using JailQueue.Services;

namespace JailQueue.Events;

public class RoundEndEvent
{
    private IQueueService _queueService = new QueueService();
    private IServerService _serverService = new ServerService();
    private QueueHelper _queueHelper = new QueueHelper();
    private ICTService _CTService = new CTService();

    public HookResult Handler(EventRoundEnd @event, GameEventInfo info)
    {
        if (_serverService.CountCT() > 1 && _queueHelper.HasCTDisbalance(_serverService))
        {
            while (_queueHelper.HasCTDisbalance(_serverService))
            {
                ForceChangeTeamAndDisbalanceNotify();
            }
        }
        else if (_queueService.Count() != 0 && _queueService.CanJoinCT())
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

    private void ForceChangeTeamAndDisbalanceNotify()
    {
        var player = _CTService.RemoveLast();
        player.ChangeTeam(CsTeam.Terrorist);
        var text = Plugin._instance.Localizer["jailQueue.forceSwitch"]
            + Plugin._instance.Localizer["jailQueue.disbalance"];
        player.PrintToChat(text);
    }
}