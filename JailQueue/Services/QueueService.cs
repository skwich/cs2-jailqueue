using CounterStrikeSharp.API.Core;

namespace JailQueue.Services;

public class QueueService : IQueueService
{
    private IServerService _serverService = new ServerService();

    public bool CanJoinCT()
    {
        var CTCount = _serverService.CountCT();
        if (CTCount == 0)
            return true;

        double TCountMinusPlayer = _serverService.CountT() - 1;
        var teamBalance = Plugin.GetInstance().Config.Balance;
        return (TCountMinusPlayer / teamBalance - CTCount) > 0;
    }

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