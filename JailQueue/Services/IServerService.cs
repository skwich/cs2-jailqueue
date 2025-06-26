using CounterStrikeSharp.API.Modules.Utils;

namespace JailQueue.Services;

public interface IServerService
{
    /// <summary>
    /// Получить количество игроков определенной команды
    /// </summary>
    /// <param name="team">Команда, игроков которой нужно посчитать</param>
    /// <returns>Количество игроков в команде</returns>
    public int GetTeamCount(CsTeam team);

    /// <summary>
    /// Посчитать количество КТ
    /// </summary>
    /// <returns>Количество КТ</returns>
    public int CountCT() => GetTeamCount(CsTeam.CounterTerrorist);

    /// <summary>
    /// Посчитать количество Т
    /// </summary>
    /// <returns>Количество Т</returns>
    public int CountT() => GetTeamCount(CsTeam.Terrorist);

    /// <summary>
    /// Удалает игрока из все очередей и списков
    /// </summary>
    /// <param name="player">Игрок</param>
    // public void RemovePlayerFromAllLists(CCSPlayerController player);
}