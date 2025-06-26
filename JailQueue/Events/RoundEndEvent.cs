using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Interfaces;
using JailQueue.Services;
using Microsoft.Extensions.Localization;

namespace JailQueue.Events;

public class RoundEndEvent
{
    private QueueService _queueService = new();
    private CTService _ctService = new();
    private Plugin _plugin = Plugin.GetInstance();
    private IStringLocalizer _localizer => _plugin.Localizer;

    public HookResult Handler(EventRoundEnd @event, GameEventInfo info)
    {        
        if (_queueService.AreTeamsUnbalanced())
        {
            do
            {
                KickFromCT();
            } while (_queueService.AreTeamsUnbalanced());
        }
        else if (_queueService.Count() != 0 && _queueService.CanJoinCT())
        {
            foreach (var player in _queueService.GetQueue())
            {
                if (!_queueService.CanJoinCT())
                    break;

                _queueService.LeaveQueue(player);
                player.ChangeTeam(CsTeam.CounterTerrorist);
                _ctService.Add(player);
            }
        }

        return HookResult.Continue;
    }

    private void KickFromCT()
    {
        var player = _ctService.RemoveFirst();
        player.ChangeTeam(CsTeam.Terrorist);
        var reason = _localizer["jailQueue.forceSwitch"] + " " + _localizer["jailQueue.unbalance"];
        player.PrintToChat(reason);
    }
}