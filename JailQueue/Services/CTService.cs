using CounterStrikeSharp.API.Core;
using JailQueueApi.Interfaces;

namespace JailQueue.Services;

public class CTService : ICTService
{    
    public void Add(CCSPlayerController player)
        => ICTService.CTList.Add(player);

    public void Remove(CCSPlayerController player)
        => ICTService.CTList.Remove(player);

    public void RemoveLast()
        => Remove(ICTService.CTList.Last());
}