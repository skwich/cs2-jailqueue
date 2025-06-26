using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;

namespace JailQueue.Events;

public class EventsList
{
    [GameEventHandler(HookMode.Pre)]
    public HookResult OnPlayerDisconnect(EventPlayerDisconnect @event, GameEventInfo info)
    {
        if (@event.Userid == null)
            return HookResult.Continue;

        var result = new PlayerDisconnectEvent().Handler(@event, info);
        return result;
    }

    [GameEventHandler]
    public HookResult OnRoundEnd(EventRoundEnd @event, GameEventInfo info)
    {
        var result = new RoundEndEvent().Handler(@event, info);
        return result;
    }
}