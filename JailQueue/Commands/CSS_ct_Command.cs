using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;
using JailQueueApi.Interfaces;

namespace JailQueue.Commands;

public class CSS_ct_Command
{
    private IQueueService _queueService = new QueueService();
    private ICTService _CTService = new CTService();

    public void Handler(CCSPlayerController player, CommandInfo info)
    {
        if (player.Team == CsTeam.CounterTerrorist)
        {
            info.ReplyToCommand(Plugin.GetInstance().Localizer["jailQueue.inCT"]);
            return;
        }

        if (_queueService.Contains(player))
        {
            var position = _queueService.GetPosition(player);
            info.ReplyToCommand(Plugin.GetInstance().Localizer["jailQueue.position", position]);
            return;
        }

        if (_queueService.CanJoinCT())
        {
            player.ChangeTeam(CsTeam.CounterTerrorist);
            _CTService.Add(player);
            return;
        }

        info.ReplyToCommand(Plugin.GetInstance().Localizer["jailQueue.join"]);
        _queueService.JoinQueue(player);
    }
}