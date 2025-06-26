using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Extensions;

namespace JailQueue.Commands;

public class CommandsList
{
    #region Player
        [ConsoleCommand("css_ct")]
        [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY)]
        public void CssCT(CCSPlayerController? player, CommandInfo info)
        {
            if (player == null || !player.IsValid)
                return;
    
            new CSS_ct().Handler(player, info);
        }
    
        [ConsoleCommand("css_t")]
        [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY)]
        public void CssT(CCSPlayerController? player, CommandInfo info)
        {
            if (player == null || !player.IsValid)
                return;
    
            new CSS_t().Handler(player, info);
        }
    #endregion

    #region Config
        [ConsoleCommand("css_jq_reload_config")]
        [CommandHelper(whoCanExecute: CommandUsage.SERVER_ONLY)]
        public void OnReloadConfig(CCSPlayerController? player, CommandInfo commandInfo)
        {
            Plugin.GetInstance().Config.Reload();
        }
    #endregion
}