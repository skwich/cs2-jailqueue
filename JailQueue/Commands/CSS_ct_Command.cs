using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;

namespace JailQueue.Commands;

public class CSS_ct_Command
{
    private IServerService _serverService = new ServerService();
    private IQueueService _queueService = new QueueService();

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

        if (_queueService.Contains(player) || _serverService.CountT() == 1)
        {
            if (!player.PawnIsAlive || _serverService.CountCT() == 0)
            {
                player.ChangeTeam(CsTeam.CounterTerrorist);
                return;
            }
        }

        info.ReplyToCommand(Plugin.GetInstance().Localizer["jailQueue.join"]);
        _queueService.JoinQueue(player);
    }
}