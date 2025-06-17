using CounterStrikeSharp.API.Core;
using JailQueue.Services;

namespace JailQueue.Events;

public class RoundStartEvent
{
    public HookResult Handler(EventRoundStart @event, GameEventInfo info)
    {
        RoundService.IsRoundEnd = false;
        return HookResult.Continue;
    }
}