using CounterStrikeSharp.API.Core;
using JailQueue.Commands;
using JailQueue.Config;
using JailQueue.Events;

namespace JailQueue;

public class Plugin : BasePlugin, IPluginConfig<JailQueueConfig>
{

    public override string ModuleName => "JailQueue";

    public override string ModuleVersion => "0.0.1";
    public static Plugin _instance = null!;
    public JailQueueConfig Config { get; set; } = null!;

    public override void Load(bool hotReload)
    {
        _instance = this;
        RegisterConsoleCommandAttributeHandlers(new CommandsList());
        RegisterAttributeHandlers(new EventsList());
    }

    public void OnConfigParsed(JailQueueConfig config)
    {
        Config = config;
    }

    public static Plugin GetInstance()
        => _instance;
}
