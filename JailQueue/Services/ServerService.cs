using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Modules.Utils;

namespace JailQueue.Services;

public static class ServerService
{
    public static int CTCount => CountPlayerInTeam(CsTeam.CounterTerrorist);
    public static int TCount => CountPlayerInTeam(CsTeam.Terrorist);
    private static int CountPlayerInTeam(CsTeam team)
    {
        return Utilities
            .GetPlayers()
            .Where(player => player.Team == team)
            .Count();
    }
}