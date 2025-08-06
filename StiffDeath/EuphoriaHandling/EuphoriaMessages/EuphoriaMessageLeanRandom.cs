namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageLeanRandom : EuphoriaMessage
{
    private float leanAmountMin = 0.200f;
    /// <summary>
    /// minimum amount of lean
    /// </summary>
    public float LeanAmountMin
    {
        get { return leanAmountMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("leanAmountMin", value);
            leanAmountMin = value;
        } 
    }

    private float leanAmountMax = 0.200f;
    /// <summary>
    /// maximum amount of lean
    /// </summary>
    public float LeanAmountMax
    {
        get { return leanAmountMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("leanAmountMax", value);
            leanAmountMax = value;
        } 
    }

    private float changeTimeMin = 0.50f;
    /// <summary>
    /// min time until changing direction
    /// </summary>
    public float ChangeTimeMin
    {
        get { return changeTimeMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 20.0f);
            SetArgument("changeTimeMin", value);
            changeTimeMin = value;
        } 
    }

    private float changeTimeMax = 1.00f;
    /// <summary>
    /// maximum time until changing direction
    /// </summary>
    public float ChangeTimeMax
    {
        get { return changeTimeMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 20.0f);
            SetArgument("changeTimeMax", value);
            changeTimeMax = value;
        } 
    }


    public EuphoriaMessageLeanRandom(bool startNow) : base("leanRandom", startNow)
    { }

    public new void Reset()
    {
        leanAmountMin = 0.200f;
        leanAmountMax = 0.200f;
        changeTimeMin = 0.50f;
        changeTimeMax = 1.00f;
        base.Reset();
    }
}
}
