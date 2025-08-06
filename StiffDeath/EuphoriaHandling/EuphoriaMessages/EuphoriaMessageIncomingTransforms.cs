using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageIncomingTransforms : EuphoriaMessage
{

    public EuphoriaMessageIncomingTransforms(bool startNow) : base("incomingTransforms", startNow)
    { }

    public new void Reset()
    {
        base.Reset();
    }
}
}
