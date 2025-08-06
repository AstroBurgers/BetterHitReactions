using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// configureBalanceReset:  reset the values configurable by the Configure Balance message to their defaults.
/// </summary>

internal class EuphoriaMessageConfigureBalanceReset : EuphoriaMessage
{

    public EuphoriaMessageConfigureBalanceReset(bool startNow) : base("configureBalanceReset", startNow)
    { }

    public new void Reset()
    {
        base.Reset();
    }
}
}
