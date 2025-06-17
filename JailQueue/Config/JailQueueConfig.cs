using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

namespace JailQueue.Config;

public class JailQueueConfig : BasePluginConfig
{
    [JsonPropertyName(nameof(Balance))]
    public int Balance { get; set; } = 4;
}

