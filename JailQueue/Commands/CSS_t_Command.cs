using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;

namespace JailQueue.Commands;

public class CSS_t_Command
{
    private IQueueService _queueService = new QueueService();

    [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY)]
    public void Handler(CCSPlayerController player, CommandInfo info)
    {
        if (player.Team == CsTeam.CounterTerrorist)
        {
            player.ChangeTeam(CsTeam.Terrorist);
        }
        else
        {
            if (_queueService.Contains(player))
            {
                _queueService.LeaveQueue(player);
                info.ReplyToCommand(Plugin.GetInstance().Localizer["jailQueue.leave"]);
            }
        }
    }
}