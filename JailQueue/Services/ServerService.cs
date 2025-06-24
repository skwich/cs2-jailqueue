using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueueApi.Interfaces;

namespace JailQueue.Services;

public class ServerService : IServerService
{
    public int GetTeamCount(CsTeam team)
    {
        return Utilities
            .GetPlayers()
            .Where(player => player.Team == team)
            .Count();
    }
}