namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// configureShotInjuredArm:  This single message allows you to configure the injured arm reaction during shot
/// </summary>

internal class EuphoriaMessageConfigureShotInjuredArm : EuphoriaMessage
{
    private float injuredArmTime = 0.250f;
    /// <summary>
    /// length of the reaction
    /// </summary>
    public float InjuredArmTime
    {
        get { return injuredArmTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("injuredArmTime", value);
            injuredArmTime = value;
        } 
    }

    private float hipYaw = 0.80f;
    /// <summary>
    /// Amount of hip twist.  (Negative values twist into bullet direction - probably not what is wanted)
    /// </summary>
    public float HipYaw
    {
        get { return hipYaw; } 
        set 
        {  
            value = MathHelper.Clamp(value, -2.00f, 2.00f);
            SetArgument("hipYaw", value);
            hipYaw = value;
        } 
    }

    private float hipRoll = 0.00f;
    /// <summary>
    /// Amount of hip roll
    /// </summary>
    public float HipRoll
    {
        get { return hipRoll; } 
        set 
        {  
            value = MathHelper.Clamp(value, -2.00f, 2.00f);
            SetArgument("hipRoll", value);
            hipRoll = value;
        } 
    }

    private float forceStepExtraHeight = 0.070f;
    /// <summary>
    /// Additional height added to stepping foot
    /// </summary>
    public float ForceStepExtraHeight
    {
        get { return forceStepExtraHeight; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 0.70f);
            SetArgument("forceStepExtraHeight", value);
            forceStepExtraHeight = value;
        } 
    }

    private bool forceStep = true;
    /// <summary>
    /// force a step to be taken whether pushed out of balance or not
    /// </summary>
    public bool ForceStep
    {
        get { return forceStep; } 
        set 
        {  
                
            SetArgument("forceStep", value);
            forceStep = value;
        } 
    }

    private bool stepTurn = true;
    /// <summary>
    /// turn the character using the balancer
    /// </summary>
    public bool StepTurn
    {
        get { return stepTurn; } 
        set 
        {  
                
            SetArgument("stepTurn", value);
            stepTurn = value;
        } 
    }

    private float velMultiplierStart = 1.0f;
    /// <summary>
    /// Start velocity where parameters begin to be ramped down to zero linearly
    /// </summary>
    public float VelMultiplierStart
    {
        get { return velMultiplierStart; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.00f);
            SetArgument("velMultiplierStart", value);
            velMultiplierStart = value;
        } 
    }

    private float velMultiplierEnd = 5.0f;
    /// <summary>
    /// End velocity of ramp where parameters are scaled to zero
    /// </summary>
    public float VelMultiplierEnd
    {
        get { return velMultiplierEnd; } 
        set 
        {  
            value = MathHelper.Clamp(value, 1.00f, 40.00f);
            SetArgument("velMultiplierEnd", value);
            velMultiplierEnd = value;
        } 
    }

    private float velForceStep = 0.80f;
    /// <summary>
    /// Velocity above which a step is not forced
    /// </summary>
    public float VelForceStep
    {
        get { return velForceStep; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.00f);
            SetArgument("velForceStep", value);
            velForceStep = value;
        } 
    }

    private float velStepTurn = 0.80f;
    /// <summary>
    /// Velocity above which a stepTurn is not asked for
    /// </summary>
    public float VelStepTurn
    {
        get { return velStepTurn; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.00f);
            SetArgument("velStepTurn", value);
            velStepTurn = value;
        } 
    }

    private bool velScales = true;
    /// <summary>
    /// Use the velocity scaling parameters.  Tune for standing still then use velocity scaling to make sure a running character stays balanced (the turning tends to make the character fall over more at speed)
    /// </summary>
    public bool VelScales
    {
        get { return velScales; } 
        set 
        {  
                
            SetArgument("velScales", value);
            velScales = value;
        } 
    }


    public EuphoriaMessageConfigureShotInjuredArm(bool startNow) : base("configureShotInjuredArm", startNow)
    { }

    public new void Reset()
    {
        injuredArmTime = 0.250f;
        hipYaw = 0.80f;
        hipRoll = 0.00f;
        forceStepExtraHeight = 0.070f;
        forceStep = true;
        stepTurn = true;
        velMultiplierStart = 1.0f;
        velMultiplierEnd = 5.0f;
        velForceStep = 0.80f;
        velStepTurn = 0.80f;
        velScales = true;
        base.Reset();
    }
}
}
