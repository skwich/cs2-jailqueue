using CounterStrikeSharp.API.Core;
using JailQueue.Interfaces;

namespace JailQueue.Services;

public class CTService : ICTService
{
    public void Add(CCSPlayerController player)
        => ICTService.ListCT.Add(player);

    public bool Contains(CCSPlayerController player)
        => ICTService.ListCT.Contains(player);

    public void Remove(CCSPlayerController player)
        => ICTService.ListCT.Remove(player);

    public CCSPlayerController RemoveFirst()
    {
        var player = ICTService.ListCT.First();
        Remove(player);
        return player;
    }
}