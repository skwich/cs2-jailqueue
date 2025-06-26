using CounterStrikeSharp.API.Core;
using JailQueueApi.Interfaces;

namespace JailQueue.Services;

public class QueueService : IQueueService
{
    private IServerService _serverService = new ServerService();
    private QueueHelper _queueHelper = new QueueHelper();

    public bool CanJoinCT()
        => _queueHelper.CalculateBalance(_serverService) > 0;

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
}

/// <summary>
/// Класс с вспомогательным методом
/// </summary>
public class QueueHelper
{
    /// <summary>
    /// Высчитывает баланс сторон по формуле: T / balance - CT
    /// </summary>
    /// <returns>
    /// <para>Если больше нуля, то игрок может зайти за КТ</para>
    /// <para>Если меньше или равно -1, то в КТ дисбаланс</para>
    /// </returns>
    public double CalculateBalance(IServerService serverService)
    {
        var CTCount = serverService.CountCT();
        if (CTCount == 0)
            return 1;

        double TCountMinusPlayer = serverService.CountT() - 1;
        var teamBalance = Plugin.GetInstance().Config.Balance;
        return TCountMinusPlayer / teamBalance - CTCount;
    }

    public bool HasCTDisbalance(IServerService serverService)
        => CalculateBalance(serverService) <= -1;
}