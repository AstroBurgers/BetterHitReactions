using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageShotRelax : EuphoriaMessage
{
    private float relaxPeriodUpper = 2.000f;
    /// <summary>
    /// time over which to relax to full relaxation for upper body
    /// </summary>
    public float RelaxPeriodUpper
    {
        get { return relaxPeriodUpper; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 40.0f);
            SetArgument("relaxPeriodUpper", value);
            relaxPeriodUpper = value;
        } 
    }

    private float relaxPeriodLower = 0.400f;
    /// <summary>
    /// time over which to relax to full relaxation for lower body
    /// </summary>
    public float RelaxPeriodLower
    {
        get { return relaxPeriodLower; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 40.0f);
            SetArgument("relaxPeriodLower", value);
            relaxPeriodLower = value;
        } 
    }


    public EuphoriaMessageShotRelax(bool startNow) : base("shotRelax", startNow)
    { }

    public new void Reset()
    {
        relaxPeriodUpper = 2.000f;
        relaxPeriodLower = 0.400f;
        base.Reset();
    }
}
}
