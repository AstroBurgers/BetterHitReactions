using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// shotFromBehind:  configure the shot from behind reaction
/// </summary>

internal class EuphoriaMessageShotFromBehind : EuphoriaMessage
{
    private bool shotFromBehind = false;
    /// <summary>
    /// Type of reaction
    /// </summary>
    public bool ShotFromBehind
    {
        get { return shotFromBehind; } 
        set 
        {  
                
            SetArgument("shotFromBehind", value);
            shotFromBehind = value;
        } 
    }

    private float sfbSpineAmount = 4.00f;
    /// <summary>
    /// SpineBend.
    /// </summary>
    public float SfbSpineAmount
    {
        get { return sfbSpineAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("sfbSpineAmount", value);
            sfbSpineAmount = value;
        } 
    }

    private float sfbNeckAmount = 1.00f;
    /// <summary>
    /// Neck Bend.
    /// </summary>
    public float SfbNeckAmount
    {
        get { return sfbNeckAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("sfbNeckAmount", value);
            sfbNeckAmount = value;
        } 
    }

    private float sfbHipAmount = 1.00f;
    /// <summary>
    /// hip Pitch
    /// </summary>
    public float SfbHipAmount
    {
        get { return sfbHipAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("sfbHipAmount", value);
            sfbHipAmount = value;
        } 
    }

    private float sfbKneeAmount = 0.050f;
    /// <summary>
    /// knee bend
    /// </summary>
    public float SfbKneeAmount
    {
        get { return sfbKneeAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("sfbKneeAmount", value);
            sfbKneeAmount = value;
        } 
    }

    private float sfbPeriod = 0.70f;
    /// <summary>
    /// shotFromBehind reaction period after being shot
    /// </summary>
    public float SfbPeriod
    {
        get { return sfbPeriod; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 10.00f);
            SetArgument("sfbPeriod", value);
            sfbPeriod = value;
        } 
    }

    private float sfbForceBalancePeriod = 0.30f;
    /// <summary>
    /// amount of time not taking a step
    /// </summary>
    public float SfbForceBalancePeriod
    {
        get { return sfbForceBalancePeriod; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("sfbForceBalancePeriod", value);
            sfbForceBalancePeriod = value;
        } 
    }

    private float sfbArmsOnset = 0.00f;
    /// <summary>
    /// amount of time before applying spread out arms pose
    /// </summary>
    public float SfbArmsOnset
    {
        get { return sfbArmsOnset; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("sfbArmsOnset", value);
            sfbArmsOnset = value;
        } 
    }

    private float sfbKneesOnset = 0.00f;
    /// <summary>
    /// amount of time before bending knees a bit
    /// </summary>
    public float SfbKneesOnset
    {
        get { return sfbKneesOnset; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("sfbKneesOnset", value);
            sfbKneesOnset = value;
        } 
    }

    private float sfbNoiseGain = 0.00f;
    /// <summary>
    /// Controls additional independent randomized bending of left/right elbows
    /// </summary>
    public float SfbNoiseGain
    {
        get { return sfbNoiseGain; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("sfbNoiseGain", value);
            sfbNoiseGain = value;
        } 
    }

    private int sfbIgnoreFail = 0;
    /// <summary>
    /// 0=balancer fails as normal,  1= ignore backArchedBack and leanedTooFarBack balancer failures,  2= ignore backArchedBack balancer failure only,  3= ignore leanedTooFarBack balancer failure only
    /// </summary>
    public int SfbIgnoreFail
    {
        get { return sfbIgnoreFail; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 3);
            SetArgument("sfbIgnoreFail", value);
            sfbIgnoreFail = value;
        } 
    }


    public EuphoriaMessageShotFromBehind(bool startNow) : base("shotFromBehind", startNow)
    { }

    public new void Reset()
    {
        shotFromBehind = false;
        sfbSpineAmount = 4.00f;
        sfbNeckAmount = 1.00f;
        sfbHipAmount = 1.00f;
        sfbKneeAmount = 0.050f;
        sfbPeriod = 0.70f;
        sfbForceBalancePeriod = 0.30f;
        sfbArmsOnset = 0.00f;
        sfbKneesOnset = 0.00f;
        sfbNoiseGain = 0.00f;
        sfbIgnoreFail = 0;
        base.Reset();
    }
}
}
