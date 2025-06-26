using CounterStrikeSharp.API.Core;

namespace JailQueue.Interfaces;

public interface ICTService
{
    /// <summary>
    /// Список, в котором хранятся игроки, которые зашли за кт
    /// </summary>
    public static readonly List<CCSPlayerController> ListCT = new();

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
    /// Находится ли игрок в списке
    /// </summary>
    /// <param name="player">игрок</param>
    /// <returns>true - находится в списке, false - не находится</returns>
    public bool Contains(CCSPlayerController player);

    /// <summary>
    /// Убрать первого зашедшего игрока за КТ из списка
    /// </summary>
    /// <returns>Игрок, которого убрали из списка</returns>
    public CCSPlayerController RemoveFirst();
}