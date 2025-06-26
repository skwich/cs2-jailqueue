using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Modules.Utils;
using JailQueue.Interfaces;

namespace JailQueue.Services;

public class ServerService : IServerService
{
    public int CountCT() => GetTeamCount(CsTeam.CounterTerrorist);
    public int CountT() => GetTeamCount(CsTeam.Terrorist);

    /// <summary>
    /// Получить количество игроков определенной команды
    /// </summary>
    /// <param name="team">Команда, игроков которой нужно посчитать</param>
    /// <returns>Количество игроков в команде</returns>
    private int GetTeamCount(CsTeam team)
    {
        return Utilities
            .GetPlayers()
            .Where(player => player.Team == team)
            .Count();
    }
}