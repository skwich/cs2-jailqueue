using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;

namespace JailQueue.Services;

public static class QueueService
{
    public static bool[] IsPlayerInQueue = new bool[Server.MaxPlayers];
    public static HashSet<CCSPlayerController> CTQueue = new();

    public static bool IsPlayerCanJoinToCT()
    {
        if (ServerService.CTCount == 0)
            return true;

        var TCountExcludeSelf = ServerService.TCount - 1;
        return
            Convert.ToDouble(TCountExcludeSelf) / Plugin.Instance.Config.Balance - ServerService.CTCount > 0;
    }

    public static void AddPlayerToCTQueue(CCSPlayerController player)
        => CTQueue.Add(player);

    public static void RemovePlayerFromCTQueue(CCSPlayerController player)
        => CTQueue.Remove(player);

    public static void SetPlayerInQueue(CCSPlayerController player)
        => ChangePlayerQueueState(player, true);

    public static void RemovePlayerFromQueue(CCSPlayerController player)
        => ChangePlayerQueueState(player, false);

    public static int GetPlayerPlace(CCSPlayerController player)
        => CTQueue.Select((p, i) => (p, i)).Where(pair => pair.p == player).First().i + 1;

    private static void ChangePlayerQueueState(CCSPlayerController player, bool state)
    {
        IsPlayerInQueue[player.Index] = state;
    }
}