using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;

namespace JailQueue.Commands;

public class CSS_t_Command
{
    [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY)]
    public void Handler(CCSPlayerController? player, CommandInfo info)
    {
        if (player == null || !player.IsValid)
            return;

        if (player.Team == CsTeam.CounterTerrorist)
        {
            player.ChangeTeam(CsTeam.Terrorist);
            player.PrintToChat(Plugin.Instance.Localizer["GetBackToTeam"]);
        }
        else
        {
            if (QueueService.IsPlayerInQueue[player.Index])
            {
                QueueService.RemovePlayerFromCTQueue(player);
                QueueService.RemovePlayerFromQueue(player);
            }
        }
    }
}