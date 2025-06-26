using CounterStrikeSharp.API.Core;

namespace JailQueue.Interfaces;

public interface IQueueService
{
    /// <summary>
    /// Список, в котором хранятся игроки, стоящие в очереди
    /// </summary>
    public static readonly List<CCSPlayerController> queue = new();

    /// <summary>
    /// Получить список очереди
    /// </summary>
    /// <returns>список</returns>
    public List<CCSPlayerController> GetQueue();

    /// <summary>
    /// Может ли игрок присоединиться к КТ
    /// </summary>
    /// <returns>true - игрок может присоединиться, false - игрок не может</returns>
    public bool CanJoinCT();

    /// <summary>
    /// Нарушен ли баланс между командами
    /// </summary>
    /// <returns>true - если нарушен, false - если не нарушен</returns>
    public bool AreTeamsUnbalanced();

    /// <summary>
    /// Стоит ли игрок в очереди
    /// </summary>
    /// <returns>Игрок</returns>
    public bool Contains(CCSPlayerController player);

    /// <summary>
    /// Поставить игрока в очередь
    /// </summary>
    /// <param name="player">Игрок, которого поставить в очередь</param>
    public void JoinQueue(CCSPlayerController player);

    /// <summary>
    /// Убрать игрока из очереди
    /// </summary>
    /// <param name="player">Игрок, которого убрать из очереди</param>
    public void LeaveQueue(CCSPlayerController player);

    /// <summary>
    /// Получить позицию игрока в очереди
    /// </summary>
    /// <param name="player">Игрок, позицию которого нужно посмотреть</param>
    /// <returns></returns>
    public int GetPosition(CCSPlayerController player);

    /// <summary>
    /// Получить количество игроков в очереди
    /// </summary>
    /// <returns>Количество игроков</returns>
    public int Count();
}