using CounterStrikeSharp.API.Core;
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
        AddCommandListener("jointeam", (player, info) => HookResult.Handled);
    }

    public void OnConfigParsed(JailQueueConfig config)
    {
        Config = config;
    }

    public static Plugin GetInstance()
        => _instance;
}
