namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// stopAllBehaviours:  Send this message to immediately stop all behaviours from executing.
/// </summary>

internal class EuphoriaMessageStopAllBehaviours : EuphoriaMessage
{

    public EuphoriaMessageStopAllBehaviours(bool startNow) : base("stopAllBehaviours", startNow)
    { }

    public new void Reset()
    {
        base.Reset();
    }
}
}
