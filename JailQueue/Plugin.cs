using CounterStrikeSharp.API.Core;
using JailQueue.Commands;
using JailQueue.Config;
using JailQueue.Events;

namespace JailQueue;

public class Plugin : BasePlugin, IPluginConfig<JailQueueConfig>
{

    public override string ModuleName => "JailQueue";

    public override string ModuleVersion => "1.2.0";
    public override string ModuleAuthor => "akel21";
    public static Plugin Instance { get; set; } = null!;
    public JailQueueConfig Config { get; set; } = null!;

    public override void Load(bool hotReload)
    {
        Instance = this;
        RegisterConsoleCommandAttributeHandlers(new CommandsList());
        RegisterAttributeHandlers(new EventsList());
    }

    public void OnConfigParsed(JailQueueConfig config)
    {
        Config = config;
    }
}
