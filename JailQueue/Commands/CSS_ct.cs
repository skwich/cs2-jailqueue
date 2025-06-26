using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;

namespace JailQueue.Commands;

public class CSS_ct
{
    private QueueService _queueService = new();
    private ServerService _serverService = new();
    private CTService _ctService = new();

    public void Handler(CCSPlayerController player, CommandInfo info)
    {
        if (player.Team == CsTeam.CounterTerrorist)
        {
            info.ReplyToCommand(Plugin.GetInstance().Localizer["jailQueue.inCT"]);
            return;
        }

        if (_serverService.CountCT() == 0)
        {
            player.ChangeTeam(CsTeam.CounterTerrorist);
            _ctService.Add(player);
            return;
        }

        if (!_queueService.Contains(player))
        {
            info.ReplyToCommand(Plugin.GetInstance().Localizer["jailQueue.join"]);
            _queueService.JoinQueue(player);
        }

        var position = _queueService.GetPosition(player);
        info.ReplyToCommand(Plugin.GetInstance().Localizer["jailQueue.position", position]);
        for (var index = 0; index < _queueService.Count(); index++)
        {
            info.ReplyToCommand($"{1 + index}. {_queueService.GetQueue()[index].PlayerName}");
        }
    }
}