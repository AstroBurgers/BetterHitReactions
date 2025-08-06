using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// shotInGuts:  configure the shot in guts reaction
/// </summary>

internal class EuphoriaMessageShotInGuts : EuphoriaMessage
{
    private bool shotInGuts = false;
    /// <summary>
    /// Type of reaction
    /// </summary>
    public bool ShotInGuts
    {
        get { return shotInGuts; } 
        set 
        {  
                
            SetArgument("shotInGuts", value);
            shotInGuts = value;
        } 
    }

    private float sigSpineAmount = 2.00f;
    /// <summary>
    /// SpineBend.
    /// </summary>
    public float SigSpineAmount
    {
        get { return sigSpineAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("sigSpineAmount", value);
            sigSpineAmount = value;
        } 
    }

    private float sigNeckAmount = 1.00f;
    /// <summary>
    /// Neck Bend.
    /// </summary>
    public float SigNeckAmount
    {
        get { return sigNeckAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("sigNeckAmount", value);
            sigNeckAmount = value;
        } 
    }

    private float sigHipAmount = 1.00f;
    /// <summary>
    /// hip Pitch
    /// </summary>
    public float SigHipAmount
    {
        get { return sigHipAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("sigHipAmount", value);
            sigHipAmount = value;
        } 
    }

    private float sigKneeAmount = 0.050f;
    /// <summary>
    /// knee bend
    /// </summary>
    public float SigKneeAmount
    {
        get { return sigKneeAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("sigKneeAmount", value);
            sigKneeAmount = value;
        } 
    }

    private float sigPeriod = 2.00f;
    /// <summary>
    /// active time after being shot
    /// </summary>
    public float SigPeriod
    {
        get { return sigPeriod; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 10.00f);
            SetArgument("sigPeriod", value);
            sigPeriod = value;
        } 
    }

    private float sigForceBalancePeriod = 0.00f;
    /// <summary>
    /// amount of time not taking a step
    /// </summary>
    public float SigForceBalancePeriod
    {
        get { return sigForceBalancePeriod; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("sigForceBalancePeriod", value);
            sigForceBalancePeriod = value;
        } 
    }

    private float sigKneesOnset = 0.00f;
    /// <summary>
    /// amount of time not taking a step
    /// </summary>
    public float SigKneesOnset
    {
        get { return sigKneesOnset; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("sigKneesOnset", value);
            sigKneesOnset = value;
        } 
    }


    public EuphoriaMessageShotInGuts(bool startNow) : base("shotInGuts", startNow)
    { }

    public new void Reset()
    {
        shotInGuts = false;
        sigSpineAmount = 2.00f;
        sigNeckAmount = 1.00f;
        sigHipAmount = 1.00f;
        sigKneeAmount = 0.050f;
        sigPeriod = 2.00f;
        sigForceBalancePeriod = 0.00f;
        sigKneesOnset = 0.00f;
        base.Reset();
    }
}
}
