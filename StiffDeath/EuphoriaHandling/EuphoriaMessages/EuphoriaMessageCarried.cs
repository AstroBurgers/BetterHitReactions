using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// Carried
/// </summary>

internal class EuphoriaMessageCarried : EuphoriaMessage
{

    public EuphoriaMessageCarried(bool startNow) : base("carried", startNow)
    { }

    public new void Reset()
    {
        base.Reset();
    }
}
}
