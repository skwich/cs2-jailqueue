using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Services;

namespace JailQueue.Commands;

public class CSS_ct_Command
{
    public void Handler(CCSPlayerController? player, CommandInfo info)
    {
        if (player == null || !player.IsValid)
            return;

        if (player.Team == CsTeam.CounterTerrorist)
        {
            player.PrintToChat(Plugin.Instance.Localizer["AlreadyInCT"]);
            return;
        }

        if (QueueService.IsPlayerInQueue[player.Index])
        {
            var place = QueueService.GetPlayerPlace(player);
            player.PrintToChat(Plugin.Instance.Localizer["AlreadyInQueue", place]);
            return;
        }
        
        if (QueueService.IsPlayerCanJoinToCT() || ServerService.TCount == 1)
        {
            if (!player.PawnIsAlive || RoundService.IsRoundEnd || ServerService.CTCount == 0)
            {
                player.ChangeTeam(CsTeam.CounterTerrorist);
                return;
            }
        }

        player.PrintToChat(Plugin.Instance.Localizer["GetInQueue"]);
        QueueService.AddPlayerToCTQueue(player);
        QueueService.SetPlayerInQueue(player);
    }
}