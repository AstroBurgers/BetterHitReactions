using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageForceLeanRandom : EuphoriaMessage
{
    private float leanAmountMin = 0.300f;
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

    private float leanAmountMax = 0.400f;
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

    private float changeTimeMin = 2.00f;
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

    private float changeTimeMax = 4.00f;
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

    private int bodyPart = 0;
    /// <summary>
    /// body part that the force is applied to
    /// </summary>
    public int BodyPart
    {
        get { return bodyPart; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 21);
            SetArgument("bodyPart", value);
            bodyPart = value;
        } 
    }


    public EuphoriaMessageForceLeanRandom(bool startNow) : base("forceLeanRandom", startNow)
    { }

    public new void Reset()
    {
        leanAmountMin = 0.300f;
        leanAmountMax = 0.400f;
        changeTimeMin = 2.00f;
        changeTimeMax = 4.00f;
        bodyPart = 0;
        base.Reset();
    }
}
}
