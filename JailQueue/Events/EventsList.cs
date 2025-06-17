using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;

namespace JailQueue.Events;

public class EventsList
{
    [GameEventHandler]
    public HookResult OnEventPlayerDisconnect(EventPlayerDisconnect @event, GameEventInfo info)
    {
        var result = new PlayerDisconnectEvent().Handler(@event, info);
        return result;
    }

    [GameEventHandler]
    public HookResult OnEventRoundEnd(EventRoundEnd @event, GameEventInfo info)
    {
        var result = new RoundEndEvent().Handler(@event, info);
        return result;
    }

    [GameEventHandler]
    public HookResult OnEventRoundStart(EventRoundStart @event, GameEventInfo info)
    {
        var result = new RoundStartEvent().Handler(@event, info);
        return result;
    }

    [GameEventHandler]
    public HookResult OnEventSwitchTeam(EventSwitchTeam @event, GameEventInfo info)
    {
        var result = new SwitchTeamEvent().Handler(@event, info);
        return result;
    }
}