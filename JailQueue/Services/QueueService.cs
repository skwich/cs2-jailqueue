using CounterStrikeSharp.API.Core;
using JailQueue.Interfaces;

namespace JailQueue.Services;

public class QueueService : IQueueService
{
    private ServerService _serverService = new();

    public List<CCSPlayerController> GetQueue()
        => IQueueService.queue;

    public bool CanJoinCT()
        => CalculateBalance() > 0;

    public bool AreTeamsUnbalanced()
        => (_serverService.CountCT() > 1) && (CalculateBalance() < -1);

    public bool Contains(CCSPlayerController player)
        => IQueueService.queue.Contains(player);

    public void JoinQueue(CCSPlayerController player)
        => IQueueService.queue.Add(player);

    public void LeaveQueue(CCSPlayerController player)
        => IQueueService.queue.Remove(player);

    public int GetPosition(CCSPlayerController player)
        => IQueueService.queue.TakeWhile(x => x != player).Count() + 1;

    public int Count()
        => IQueueService.queue.Count;
    
    /// <summary>
    /// Высчитывает баланс сторон по формуле: T / balance - CT
    /// </summary>
    /// <returns>
    /// <para>Если больше нуля, то игрок может зайти за КТ</para>
    /// <para>Если меньше -1, то в КТ дисбаланс</para>
    /// </returns>
    private double CalculateBalance()
    {
        var CTCount = _serverService.CountCT();
        if (CTCount == 0)
            return 1;

        double TCountMinusPlayer = _serverService.CountT() - 1;
        var teamBalance = Plugin.GetInstance().Config.Balance;
        var result = TCountMinusPlayer / teamBalance - CTCount;
        return result;
    }
}