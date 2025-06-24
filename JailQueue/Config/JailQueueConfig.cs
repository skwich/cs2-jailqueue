using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

namespace JailQueue.Config;

public class JailQueueConfig : BasePluginConfig
{
    /// <summary>
    /// Сколько нужно Т для одного КТ
    /// </summary>
    [JsonPropertyName(nameof(Balance))]
    public int Balance { get; set; } = 4;
}

