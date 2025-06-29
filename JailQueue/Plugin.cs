using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Commands;
using JailQueue.Config;
using JailQueue.Events;

namespace JailQueue;

public class Plugin : BasePlugin, IPluginConfig<JailQueueConfig>
{

    public override string ModuleName => "JailQueue";

    public override string ModuleVersion => "1.0.0";
    public JailQueueConfig Config { get; set; } = null!;
    private static Plugin _instance = null!;

    public override void Load(bool hotReload)
    {
        _instance = this;
        RegisterConsoleCommandAttributeHandlers(new CommandsList());
        RegisterAttributeHandlers(new EventsList());
        AddCommandListener("jointeam", (player, info) => 
        {
            var teamNum = int.Parse(info.GetArg(1));
            if (CsTeam.CounterTerrorist == (CsTeam)teamNum)
                return HookResult.Handled;
            
            return HookResult.Continue;
        });
    }

    public void OnConfigParsed(JailQueueConfig config)
    {
        Config = config;
    }

    public static Plugin GetInstance()
        => _instance;
}
