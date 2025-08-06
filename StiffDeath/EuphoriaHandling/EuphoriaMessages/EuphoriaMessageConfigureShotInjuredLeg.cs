using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// configureShotInjuredLeg:  This single message allows you to configure the injured leg reaction during shot
/// </summary>

internal class EuphoriaMessageConfigureShotInjuredLeg : EuphoriaMessage
{
    private float timeBeforeCollapseWoundLeg = 0.30f;
    /// <summary>
    /// time before a wounded leg is set to be weak and cause the character to collapse
    /// </summary>
    public float TimeBeforeCollapseWoundLeg
    {
        get { return timeBeforeCollapseWoundLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("timeBeforeCollapseWoundLeg", value);
            timeBeforeCollapseWoundLeg = value;
        } 
    }

    private float legInjuryTime = 0.40f;
    /// <summary>
    /// Leg inury duration (reaction to being shot in leg)
    /// </summary>
    public float LegInjuryTime
    {
        get { return legInjuryTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("legInjuryTime", value);
            legInjuryTime = value;
        } 
    }

    private bool legForceStep = true;
    /// <summary>
    /// force a step to be taken whether pushed out of balance or not
    /// </summary>
    public bool LegForceStep
    {
        get { return legForceStep; } 
        set 
        {  
                
            SetArgument("legForceStep", value);
            legForceStep = value;
        } 
    }

    private float legLimpBend = 0.00f;
    /// <summary>
    /// Bend the legs via the balancer by this amount if stepping on the injured leg. 0.2 seems a good default
    /// </summary>
    public float LegLimpBend
    {
        get { return legLimpBend; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("legLimpBend", value);
            legLimpBend = value;
        } 
    }

    private float legLiftTime = 0.00f;
    /// <summary>
    /// Leg lift duration (reaction to being shot in leg) (lifting happens when not stepping with other leg)
    /// </summary>
    public float LegLiftTime
    {
        get { return legLiftTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("legLiftTime", value);
            legLiftTime = value;
        } 
    }

    private float legInjury = 0.30f;
    /// <summary>
    /// Leg injury - leg strength is reduced
    /// </summary>
    public float LegInjury
    {
        get { return legInjury; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("legInjury", value);
            legInjury = value;
        } 
    }

    private float legInjuryHipPitch = 0.00f;
    /// <summary>
    /// Leg injury bend forwards amount when not lifting leg
    /// </summary>
    public float LegInjuryHipPitch
    {
        get { return legInjuryHipPitch; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("legInjuryHipPitch", value);
            legInjuryHipPitch = value;
        } 
    }

    private float legInjuryLiftHipPitch = 0.00f;
    /// <summary>
    /// Leg injury bend forwards amount when lifting leg (lifting happens when not stepping with other leg)
    /// </summary>
    public float LegInjuryLiftHipPitch
    {
        get { return legInjuryLiftHipPitch; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("legInjuryLiftHipPitch", value);
            legInjuryLiftHipPitch = value;
        } 
    }

    private float legInjurySpineBend = 0.10f;
    /// <summary>
    /// Leg injury bend forwards amount when not lifting leg
    /// </summary>
    public float LegInjurySpineBend
    {
        get { return legInjurySpineBend; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("legInjurySpineBend", value);
            legInjurySpineBend = value;
        } 
    }

    private float legInjuryLiftSpineBend = 0.20f;
    /// <summary>
    /// Leg injury bend forwards amount when lifting leg (lifting happens when not stepping with other leg)
    /// </summary>
    public float LegInjuryLiftSpineBend
    {
        get { return legInjuryLiftSpineBend; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("legInjuryLiftSpineBend", value);
            legInjuryLiftSpineBend = value;
        } 
    }


    public EuphoriaMessageConfigureShotInjuredLeg(bool startNow) : base("configureShotInjuredLeg", startNow)
    { }

    public new void Reset()
    {
        timeBeforeCollapseWoundLeg = 0.30f;
        legInjuryTime = 0.40f;
        legForceStep = true;
        legLimpBend = 0.00f;
        legLiftTime = 0.00f;
        legInjury = 0.30f;
        legInjuryHipPitch = 0.00f;
        legInjuryLiftHipPitch = 0.00f;
        legInjurySpineBend = 0.10f;
        legInjuryLiftSpineBend = 0.20f;
        base.Reset();
    }
}
}
