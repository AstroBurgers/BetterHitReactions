using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageStayUpright : EuphoriaMessage
{
    private bool useForces = false;
    /// <summary>
    /// enable force based constraint
    /// </summary>
    public bool UseForces
    {
        get { return useForces; } 
        set 
        {  
                
            SetArgument("useForces", value);
            useForces = value;
        } 
    }

    private bool useTorques = false;
    /// <summary>
    /// enable torque based constraint
    /// </summary>
    public bool UseTorques
    {
        get { return useTorques; } 
        set 
        {  
                
            SetArgument("useTorques", value);
            useTorques = value;
        } 
    }

    private bool lastStandMode = false;
    /// <summary>
    /// Uses position/orientation control on the spine and drifts in the direction of bullets.  This ignores all other stayUpright settings.
    /// </summary>
    public bool LastStandMode
    {
        get { return lastStandMode; } 
        set 
        {  
                
            SetArgument("lastStandMode", value);
            lastStandMode = value;
        } 
    }

    private float lastStandSinkRate = 0.30f;
    /// <summary>
    /// The sink rate (higher for a faster drop).
    /// </summary>
    public float LastStandSinkRate
    {
        get { return lastStandSinkRate; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("lastStandSinkRate", value);
            lastStandSinkRate = value;
        } 
    }

    private float lastStandHorizDamping = 0.40f;
    /// <summary>
    /// Higher values for more damping
    /// </summary>
    public float LastStandHorizDamping
    {
        get { return lastStandHorizDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("lastStandHorizDamping", value);
            lastStandHorizDamping = value;
        } 
    }

    private float lastStandMaxTime = 0.40f;
    /// <summary>
    /// Max time allowed in last stand mode
    /// </summary>
    public float LastStandMaxTime
    {
        get { return lastStandMaxTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 5.0f);
            SetArgument("lastStandMaxTime", value);
            lastStandMaxTime = value;
        } 
    }

    private bool turnTowardsBullets = false;
    /// <summary>
    /// Use cheat torques to face the direction of bullets if not facing too far away
    /// </summary>
    public bool TurnTowardsBullets
    {
        get { return turnTowardsBullets; } 
        set 
        {  
                
            SetArgument("turnTowardsBullets", value);
            turnTowardsBullets = value;
        } 
    }

    private bool velocityBased = false;
    /// <summary>
    /// make strength of constraint function of COM velocity.  Uses -1 for forceDamping if the damping is positive.
    /// </summary>
    public bool VelocityBased
    {
        get { return velocityBased; } 
        set 
        {  
                
            SetArgument("velocityBased", value);
            velocityBased = value;
        } 
    }

    private bool torqueOnlyInAir = false;
    /// <summary>
    /// only apply torque based constraint when airBorne
    /// </summary>
    public bool TorqueOnlyInAir
    {
        get { return torqueOnlyInAir; } 
        set 
        {  
                
            SetArgument("torqueOnlyInAir", value);
            torqueOnlyInAir = value;
        } 
    }

    private float forceStrength = 3.00f;
    /// <summary>
    /// strength of constraint
    /// </summary>
    public float ForceStrength
    {
        get { return forceStrength; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
            SetArgument("forceStrength", value);
            forceStrength = value;
        } 
    }

    private float forceDamping = -1.00f;
    /// <summary>
    /// damping in constraint: -1 makes it scale automagically with forceStrength.  Other negative values will scale this automagic damping.
    /// </summary>
    public float ForceDamping
    {
        get { return forceDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 50.0f);
            SetArgument("forceDamping", value);
            forceDamping = value;
        } 
    }

    private float forceFeetMult = 1.00f;
    /// <summary>
    /// multiplier to the force applied to the feet
    /// </summary>
    public float ForceFeetMult
    {
        get { return forceFeetMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("forceFeetMult", value);
            forceFeetMult = value;
        } 
    }

    private float forceSpine3Share = 0.30f;
    /// <summary>
    /// share of pelvis force applied to spine3
    /// </summary>
    public float ForceSpine3Share
    {
        get { return forceSpine3Share; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("forceSpine3Share", value);
            forceSpine3Share = value;
        } 
    }

    private float forceLeanReduction = 1.00f;
    /// <summary>
    /// how much the character lean is taken into account when reducing the force.
    /// </summary>
    public float ForceLeanReduction
    {
        get { return forceLeanReduction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("forceLeanReduction", value);
            forceLeanReduction = value;
        } 
    }

    private float forceInAirShare = 0.50f;
    /// <summary>
    /// share of the feet force to the airborne foot
    /// </summary>
    public float ForceInAirShare
    {
        get { return forceInAirShare; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("forceInAirShare", value);
            forceInAirShare = value;
        } 
    }

    private float forceMin = -1.00f;
    /// <summary>
    /// when min and max are greater than 0 the constraint strength is determined from character strength, scaled into the range given by min and max
    /// </summary>
    public float ForceMin
    {
        get { return forceMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 16.0f);
            SetArgument("forceMin", value);
            forceMin = value;
        } 
    }

    private float forceMax = -1.00f;
    /// <summary>
    /// see above
    /// </summary>
    public float ForceMax
    {
        get { return forceMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 16.0f);
            SetArgument("forceMax", value);
            forceMax = value;
        } 
    }

    private float forceSaturationVel = 4.00f;
    /// <summary>
    /// when in velocityBased mode, the COM velocity at which constraint reaches maximum strength (forceStrength)
    /// </summary>
    public float ForceSaturationVel
    {
        get { return forceSaturationVel; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 10.0f);
            SetArgument("forceSaturationVel", value);
            forceSaturationVel = value;
        } 
    }

    private float forceThresholdVel = 0.50f;
    /// <summary>
    /// when in velocityBased mode, the COM velocity above which constraint starts applying forces
    /// </summary>
    public float ForceThresholdVel
    {
        get { return forceThresholdVel; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 5.00f);
            SetArgument("forceThresholdVel", value);
            forceThresholdVel = value;
        } 
    }

    private float torqueStrength = 0.00f;
    /// <summary>
    /// strength of torque based constraint
    /// </summary>
    public float TorqueStrength
    {
        get { return torqueStrength; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 16.0f);
            SetArgument("torqueStrength", value);
            torqueStrength = value;
        } 
    }

    private float torqueDamping = 0.50f;
    /// <summary>
    /// damping of torque based constraint
    /// </summary>
    public float TorqueDamping
    {
        get { return torqueDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 16.0f);
            SetArgument("torqueDamping", value);
            torqueDamping = value;
        } 
    }

    private float torqueSaturationVel = 4.00f;
    /// <summary>
    /// when in velocityBased mode, the COM velocity at which constraint reaches maximum strength (torqueStrength)
    /// </summary>
    public float TorqueSaturationVel
    {
        get { return torqueSaturationVel; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 10.0f);
            SetArgument("torqueSaturationVel", value);
            torqueSaturationVel = value;
        } 
    }

    private float torqueThresholdVel = 2.50f;
    /// <summary>
    /// when in velocityBased mode, the COM velocity above which constraint starts applying torques
    /// </summary>
    public float TorqueThresholdVel
    {
        get { return torqueThresholdVel; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 5.00f);
            SetArgument("torqueThresholdVel", value);
            torqueThresholdVel = value;
        } 
    }

    private float supportPosition = 2.00f;
    /// <summary>
    /// distance the foot is behind Com projection that is still considered able to generate the support for the upright constraint
    /// </summary>
    public float SupportPosition
    {
        get { return supportPosition; } 
        set 
        {  
            value = MathHelper.Clamp(value, -2.00f, 2.00f);
            SetArgument("supportPosition", value);
            supportPosition = value;
        } 
    }

    private float noSupportForceMult = 1.00f;
    /// <summary>
    /// still apply this fraction of the upright constaint force if the foot is not in a position (defined by supportPosition) to generate the support for the upright constraint
    /// </summary>
    public float NoSupportForceMult
    {
        get { return noSupportForceMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("noSupportForceMult", value);
            noSupportForceMult = value;
        } 
    }

    private float stepUpHelp = 0.00f;
    /// <summary>
    /// strength of cheat force applied upwards to spine3 to help the character up steps/slopes
    /// </summary>
    public float StepUpHelp
    {
        get { return stepUpHelp; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 16.0f);
            SetArgument("stepUpHelp", value);
            stepUpHelp = value;
        } 
    }

    private float stayUpAcc = 0.70f;
    /// <summary>
    /// How much the cheat force takes into account the acceleration of moving platforms
    /// </summary>
    public float StayUpAcc
    {
        get { return stayUpAcc; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("stayUpAcc", value);
            stayUpAcc = value;
        } 
    }

    private float stayUpAccMax = 5.00f;
    /// <summary>
    /// The maximum floorAcceleration (of a moving platform) that the cheat force takes into account
    /// </summary>
    public float StayUpAccMax
    {
        get { return stayUpAccMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 15.0f);
            SetArgument("stayUpAccMax", value);
            stayUpAccMax = value;
        } 
    }


    public EuphoriaMessageStayUpright(bool startNow) : base("stayUpright", startNow)
    { }

    public new void Reset()
    {
        useForces = false;
        useTorques = false;
        lastStandMode = false;
        lastStandSinkRate = 0.30f;
        lastStandHorizDamping = 0.40f;
        lastStandMaxTime = 0.40f;
        turnTowardsBullets = false;
        velocityBased = false;
        torqueOnlyInAir = false;
        forceStrength = 3.00f;
        forceDamping = -1.00f;
        forceFeetMult = 1.00f;
        forceSpine3Share = 0.30f;
        forceLeanReduction = 1.00f;
        forceInAirShare = 0.50f;
        forceMin = -1.00f;
        forceMax = -1.00f;
        forceSaturationVel = 4.00f;
        forceThresholdVel = 0.50f;
        torqueStrength = 0.00f;
        torqueDamping = 0.50f;
        torqueSaturationVel = 4.00f;
        torqueThresholdVel = 2.50f;
        supportPosition = 2.00f;
        noSupportForceMult = 1.00f;
        stepUpHelp = 0.00f;
        stayUpAcc = 0.70f;
        stayUpAccMax = 5.00f;
        base.Reset();
    }
}
}
