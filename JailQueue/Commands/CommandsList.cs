using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Extensions;

namespace JailQueue.Commands;

public class CommandsList
{
    [ConsoleCommand("css_ct")]
    [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY)]
    public void CssCT(CCSPlayerController? player, CommandInfo info)
    {
        new CSS_ct_Command().Handler(player, info);
    }

    [ConsoleCommand("css_t")]
    [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY)]
    public void CssT(CCSPlayerController? player, CommandInfo info)
    {
        new CSS_t_Command().Handler(player, info);
    }

    [ConsoleCommand("css_jq_reload_config")]
    [CommandHelper(whoCanExecute: CommandUsage.SERVER_ONLY)]
    public void OnReloadConfig(CCSPlayerController? player, CommandInfo commandInfo)
    {
        Plugin.Instance.Config.Reload();
    }
}