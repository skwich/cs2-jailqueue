using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;

namespace JailQueue.Commands;

public class CSS_t
{
    private QueueService _queueService = new();
    private CTService _ctService = new();

    [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY)]
    public void Handler(CCSPlayerController player, CommandInfo info)
    {        
        if (player.Team == CsTeam.CounterTerrorist)
        {
            player.ChangeTeam(CsTeam.Terrorist);
            _ctService.Remove(player);
            return;
        }
        
        if (_queueService.Contains(player))
        {
            _queueService.LeaveQueue(player);
            info.ReplyToCommand(Plugin.GetInstance().Localizer["jailQueue.leave"]);
        }
    }
}