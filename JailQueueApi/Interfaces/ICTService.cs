using CounterStrikeSharp.API.Core;

namespace JailQueueApi.Interfaces;

public interface ICTService : IService
{
    /// <summary>
    /// Список, в котором хранятся игроки, которые зашли за кт
    /// </summary>
    public static readonly HashSet<CCSPlayerController> CTList = new();

    /// <summary>
    /// Добавить последнего зашедшего игрока за КТ в список
    /// </summary>
    /// <param name="player">Игрок, которого нужно добавить в список</param>
    public void Add(CCSPlayerController player);

    /// <summary>
    /// Убрать игрока из списка КТ
    /// </summary>
    /// <param name="player">Игрок, которого нужно убрать из списка</param>
    public void Remove(CCSPlayerController player);

    /// <summary>
    /// Убрать последнего зашедшего игрока за КТ из списка
    /// </summary>
    public void RemoveLast();
}