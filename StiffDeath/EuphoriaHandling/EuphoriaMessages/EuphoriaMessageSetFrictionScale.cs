namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// setFrictionScale:
/// </summary>

internal class EuphoriaMessageSetFrictionScale : EuphoriaMessage
{
    private float scale = 1.00f;
    /// <summary>
    /// Friction scale to be applied to parts in mask.
    /// </summary>
    public float Scale
    {
        get { return scale; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("scale", value);
            scale = value;
        } 
    }

    private float globalMin = 0.00f;
    /// <summary>
    /// Character-wide minimum impact friction. Affects all parts (not just those in mask).
    /// </summary>
    public float GlobalMin
    {
        get { return globalMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1000000.00f);
            SetArgument("globalMin", value);
            globalMin = value;
        } 
    }

    private float globalMax = 999999.00f;
    /// <summary>
    /// Character-wide maximum impact friction. Affects all parts (not just those in mask).
    /// </summary>
    public float GlobalMax
    {
        get { return globalMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1000000.00f);
            SetArgument("globalMax", value);
            globalMax = value;
        } 
    }

    private string mask = "fb";
    /// <summary>
    /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value  (see Active Pose notes for possible values)
    /// </summary>
    public string Mask
    {
        get { return mask; } 
        set 
        {  
                
            SetArgument("mask", value);
            mask = value;
        } 
    }


    public EuphoriaMessageSetFrictionScale(bool startNow) : base("setFrictionScale", startNow)
    { }

    public new void Reset()
    {
        scale = 1.00f;
        globalMin = 0.00f;
        globalMax = 999999.00f;
        mask = "fb";
        base.Reset();
    }
}
}
