using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageConfigureBulletsExtra : EuphoriaMessage
{
    private bool impulseSpreadOverParts = false;
    /// <summary>
    /// spreads impulse across parts. currently only for spine parts, not limbs.
    /// </summary>
    public bool ImpulseSpreadOverParts
    {
        get { return impulseSpreadOverParts; } 
        set 
        {  
                
            SetArgument("impulseSpreadOverParts", value);
            impulseSpreadOverParts = value;
        } 
    }

    private float impulsePeriod = 0.10f;
    /// <summary>
    /// duration that impulse is spread over (triangular shaped)
    /// </summary>
    public float ImpulsePeriod
    {
        get { return impulsePeriod; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("impulsePeriod", value);
            impulsePeriod = value;
        } 
    }

    private float impulseTorqueScale = 1.00f;
    /// <summary>
    /// An impulse applied at a point on a body equivalent to an impulse at the centre of the body and a torque.  This parameter scales the torque component. (The torque component seems to be excite the rage looseness bug which sends the character in a sometimes wildly different direction to an applied impulse)
    /// </summary>
    public float ImpulseTorqueScale
    {
        get { return impulseTorqueScale; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("impulseTorqueScale", value);
            impulseTorqueScale = value;
        } 
    }

    private bool loosenessFix = false;
    /// <summary>
    /// Fix the rage looseness bug by applying only the impulse at the centre of the body unless it is a spine part then apply the twist component only of the torque as well.
    /// </summary>
    public bool LoosenessFix
    {
        get { return loosenessFix; } 
        set 
        {  
                
            SetArgument("loosenessFix", value);
            loosenessFix = value;
        } 
    }

    private float impulseDelay = 0.00f;
    /// <summary>
    /// time from hit before impulses are being applied
    /// </summary>
    public float ImpulseDelay
    {
        get { return impulseDelay; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("impulseDelay", value);
            impulseDelay = value;
        } 
    }

    private int torqueMode = 0;
    /// <summary>
    /// 0: Disabled | 1: character strength proportional (can reduce impulse amount) | 2: Additive (no reduction of impulse and not proportional to character strength)
    /// </summary>
    public int TorqueMode
    {
        get { return torqueMode; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("torqueMode", value);
            torqueMode = value;
        } 
    }

    private int torqueSpinMode = 0;
    /// <summary>
    /// 0: spin direction from impulse direction | 1: random direction | 2: direction flipped with each bullet (for burst effect)
    /// </summary>
    public int TorqueSpinMode
    {
        get { return torqueSpinMode; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("torqueSpinMode", value);
            torqueSpinMode = value;
        } 
    }

    private int torqueFilterMode = 0;
    /// <summary>
    /// 0: apply torque for every bullet | 1: only apply new torque if previous has finished | 2: Only apply new torque if its spin direction is different from previous torque
    /// </summary>
    public int TorqueFilterMode
    {
        get { return torqueFilterMode; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("torqueFilterMode", value);
            torqueFilterMode = value;
        } 
    }

    private bool torqueAlwaysSpine3 = true;
    /// <summary>
    /// always apply torques to spine3 instead of actual part hit
    /// </summary>
    public bool TorqueAlwaysSpine3
    {
        get { return torqueAlwaysSpine3; } 
        set 
        {  
                
            SetArgument("torqueAlwaysSpine3", value);
            torqueAlwaysSpine3 = value;
        } 
    }

    private float torqueDelay = 0.00f;
    /// <summary>
    /// time from hit before torques are being applied
    /// </summary>
    public float TorqueDelay
    {
        get { return torqueDelay; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("torqueDelay", value);
            torqueDelay = value;
        } 
    }

    private float torquePeriod = 0.120f;
    /// <summary>
    /// duration of torque
    /// </summary>
    public float TorquePeriod
    {
        get { return torquePeriod; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("torquePeriod", value);
            torquePeriod = value;
        } 
    }

    private float torqueGain = 4.00f;
    /// <summary>
    /// multiplies impulse magnitude to arrive at torque that is applied
    /// </summary>
    public float TorqueGain
    {
        get { return torqueGain; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("torqueGain", value);
            torqueGain = value;
        } 
    }

    private float torqueCutoff = 0.00f;
    /// <summary>
    /// minimum ratio of impulse that remains after converting to torque (if in strength-proportional mode)
    /// </summary>
    public float TorqueCutoff
    {
        get { return torqueCutoff; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("torqueCutoff", value);
            torqueCutoff = value;
        } 
    }

    private float torqueReductionPerTick = 0.00f;
    /// <summary>
    /// ratio of torque for next tick (e.g. 1.0: not reducing over time, 0.9: each tick torque is reduced by 10%)
    /// </summary>
    public float TorqueReductionPerTick
    {
        get { return torqueReductionPerTick; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("torqueReductionPerTick", value);
            torqueReductionPerTick = value;
        } 
    }

    private float liftGain = 0.00f;
    /// <summary>
    /// amount of lift (directly multiplies torque axis to give lift force)
    /// </summary>
    public float LiftGain
    {
        get { return liftGain; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("liftGain", value);
            liftGain = value;
        } 
    }

    private float counterImpulseDelay = 0.033330f;
    /// <summary>
    /// time after impulse is applied that counter impulse is applied
    /// </summary>
    public float CounterImpulseDelay
    {
        get { return counterImpulseDelay; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("counterImpulseDelay", value);
            counterImpulseDelay = value;
        } 
    }

    private float counterImpulseMag = 0.50f;
    /// <summary>
    /// amount of the original impulse that is countered
    /// </summary>
    public float CounterImpulseMag
    {
        get { return counterImpulseMag; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("counterImpulseMag", value);
            counterImpulseMag = value;
        } 
    }

    private bool counterAfterMagReached = false;
    /// <summary>
    /// applies the counter impulse counterImpulseDelay(secs) after counterImpulseMag of the Impulse has been applied
    /// </summary>
    public bool CounterAfterMagReached
    {
        get { return counterAfterMagReached; } 
        set 
        {  
                
            SetArgument("counterAfterMagReached", value);
            counterAfterMagReached = value;
        } 
    }

    private bool doCounterImpulse = false;
    /// <summary>
    /// add a counter impulse to the pelvis
    /// </summary>
    public bool DoCounterImpulse
    {
        get { return doCounterImpulse; } 
        set 
        {  
                
            SetArgument("doCounterImpulse", value);
            doCounterImpulse = value;
        } 
    }

    private float counterImpulse2Hips = 1.00f;
    /// <summary>
    /// amount of the counter impulse applied to hips - the rest is applied to the part originally hit
    /// </summary>
    public float CounterImpulse2Hips
    {
        get { return counterImpulse2Hips; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("counterImpulse2Hips", value);
            counterImpulse2Hips = value;
        } 
    }

    private float impulseNoBalMult = 1.00f;
    /// <summary>
    /// amount to scale impulse by if the dynamicBalance is not OK.  1.0 means this functionality is not applied.
    /// </summary>
    public float ImpulseNoBalMult
    {
        get { return impulseNoBalMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("impulseNoBalMult", value);
            impulseNoBalMult = value;
        } 
    }

    private float impulseBalStabStart = 3.00f;
    /// <summary>
    /// 100% LE Start to impulseBalStabMult*100% GT End. NB: Start LT End
    /// </summary>
    public float ImpulseBalStabStart
    {
        get { return impulseBalStabStart; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.00f);
            SetArgument("impulseBalStabStart", value);
            impulseBalStabStart = value;
        } 
    }

    private float impulseBalStabEnd = 10.00f;
    /// <summary>
    /// 100% LE Start to impulseBalStabMult*100% GT End. NB: Start LT End
    /// </summary>
    public float ImpulseBalStabEnd
    {
        get { return impulseBalStabEnd; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.00f);
            SetArgument("impulseBalStabEnd", value);
            impulseBalStabEnd = value;
        } 
    }

    private float impulseBalStabMult = 1.00f;
    /// <summary>
    /// 100% LE Start to impulseBalStabMult*100% GT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
    /// </summary>
    public float ImpulseBalStabMult
    {
        get { return impulseBalStabMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("impulseBalStabMult", value);
            impulseBalStabMult = value;
        } 
    }

    private float impulseSpineAngStart = 0.70f;
    /// <summary>
    /// 100% GE Start to impulseSpineAngMult*100% LT End. NB: Start GT End.  This the dot of hip2Head with up.
    /// </summary>
    public float ImpulseSpineAngStart
    {
        get { return impulseSpineAngStart; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("impulseSpineAngStart", value);
            impulseSpineAngStart = value;
        } 
    }

    private float impulseSpineAngEnd = 0.20f;
    /// <summary>
    /// 100% GE Start to impulseSpineAngMult*100% LT End. NB: Start GT End.  This the dot of hip2Head with up.
    /// </summary>
    public float ImpulseSpineAngEnd
    {
        get { return impulseSpineAngEnd; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("impulseSpineAngEnd", value);
            impulseSpineAngEnd = value;
        } 
    }

    private float impulseSpineAngMult = 1.00f;
    /// <summary>
    /// 100% GE Start to impulseSpineAngMult*100% LT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
    /// </summary>
    public float ImpulseSpineAngMult
    {
        get { return impulseSpineAngMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("impulseSpineAngMult", value);
            impulseSpineAngMult = value;
        } 
    }

    private float impulseVelStart = 4.00f;
    /// <summary>
    /// 100% LE Start to impulseVelMult*100% GT End. NB: Start LT End
    /// </summary>
    public float ImpulseVelStart
    {
        get { return impulseVelStart; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.00f);
            SetArgument("impulseVelStart", value);
            impulseVelStart = value;
        } 
    }

    private float impulseVelEnd = 4.00f;
    /// <summary>
    /// 100% LE Start to impulseVelMult*100% GT End. NB: Start LT End
    /// </summary>
    public float ImpulseVelEnd
    {
        get { return impulseVelEnd; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.00f);
            SetArgument("impulseVelEnd", value);
            impulseVelEnd = value;
        } 
    }

    private float impulseVelMult = 1.00f;
    /// <summary>
    /// 100% LE Start to impulseVelMult*100% GT End. NB: leaving this as 1.0 means this functionality is not applied and Start and End have no effect.
    /// </summary>
    public float ImpulseVelMult
    {
        get { return impulseVelMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("impulseVelMult", value);
            impulseVelMult = value;
        } 
    }

    private float impulseAirMult = 1.00f;
    /// <summary>
    /// amount to scale impulse by if the character is airborne and dynamicBalance is OK and impulse is above impulseAirMultStart
    /// </summary>
    public float ImpulseAirMult
    {
        get { return impulseAirMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("impulseAirMult", value);
            impulseAirMult = value;
        } 
    }

    private float impulseAirMultStart = 100.0f;
    /// <summary>
    /// if impulse is above this value scale it by impulseAirMult
    /// </summary>
    public float ImpulseAirMultStart
    {
        get { return impulseAirMultStart; } 
        set 
        {  
                
            SetArgument("impulseAirMultStart", value);
            impulseAirMultStart = value;
        } 
    }

    private float impulseAirMax = 100.0f;
    /// <summary>
    /// amount to clamp impulse to if character is airborne  and dynamicBalance is OK
    /// </summary>
    public float ImpulseAirMax
    {
        get { return impulseAirMax; } 
        set 
        {  
                
            SetArgument("impulseAirMax", value);
            impulseAirMax = value;
        } 
    }

    private float impulseAirApplyAbove = 399.0f;
    /// <summary>
    /// if impulse is above this amount then do not scale/clamp just let it through as is - it's a shotgun or cannon
    /// </summary>
    public float ImpulseAirApplyAbove
    {
        get { return impulseAirApplyAbove; } 
        set 
        {  
                
            SetArgument("impulseAirApplyAbove", value);
            impulseAirApplyAbove = value;
        } 
    }

    private bool impulseAirOn = false;
    /// <summary>
    /// scale and/or clamp impulse if the character is airborne and dynamicBalance is OK
    /// </summary>
    public bool ImpulseAirOn
    {
        get { return impulseAirOn; } 
        set 
        {  
                
            SetArgument("impulseAirOn", value);
            impulseAirOn = value;
        } 
    }

    private float impulseOneLegMult = 1.00f;
    /// <summary>
    /// amount to scale impulse by if the character is contacting with one foot only and dynamicBalance is OK and impulse is above impulseAirMultStart
    /// </summary>
    public float ImpulseOneLegMult
    {
        get { return impulseOneLegMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("impulseOneLegMult", value);
            impulseOneLegMult = value;
        } 
    }

    private float impulseOneLegMultStart = 100.0f;
    /// <summary>
    /// if impulse is above this value scale it by impulseOneLegMult
    /// </summary>
    public float ImpulseOneLegMultStart
    {
        get { return impulseOneLegMultStart; } 
        set 
        {  
                
            SetArgument("impulseOneLegMultStart", value);
            impulseOneLegMultStart = value;
        } 
    }

    private float impulseOneLegMax = 100.0f;
    /// <summary>
    /// amount to clamp impulse to if character is contacting with one foot only  and dynamicBalance is OK
    /// </summary>
    public float ImpulseOneLegMax
    {
        get { return impulseOneLegMax; } 
        set 
        {  
                
            SetArgument("impulseOneLegMax", value);
            impulseOneLegMax = value;
        } 
    }

    private float impulseOneLegApplyAbove = 399.0f;
    /// <summary>
    /// if impulse is above this amount then do not scale/clamp just let it through as is - it's a shotgun or cannon
    /// </summary>
    public float ImpulseOneLegApplyAbove
    {
        get { return impulseOneLegApplyAbove; } 
        set 
        {  
                
            SetArgument("impulseOneLegApplyAbove", value);
            impulseOneLegApplyAbove = value;
        } 
    }

    private bool impulseOneLegOn = false;
    /// <summary>
    /// scale and/or clamp impulse if the character is contacting with one leg only and dynamicBalance is OK
    /// </summary>
    public bool ImpulseOneLegOn
    {
        get { return impulseOneLegOn; } 
        set 
        {  
                
            SetArgument("impulseOneLegOn", value);
            impulseOneLegOn = value;
        } 
    }

    private float rbRatio = 0.000f;
    /// <summary>
    /// 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody
    /// </summary>
    public float RbRatio
    {
        get { return rbRatio; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("rbRatio", value);
            rbRatio = value;
        } 
    }

    private float rbLowerShare = 0.50f;
    /// <summary>
    /// rigid body response is shared between the upper and lower body (rbUpperShare = 1-rbLowerShare). rbLowerShare=0.5 gives upper and lower share scaled by mass.  i.e. if 70% ub mass and 30% lower mass then rbLowerShare=0.5 gives actualrbShare of 0.7ub and 0.3lb. rbLowerShare GT 0.5 scales the ub share down from 0.7 and the lb up from 0.3.
    /// </summary>
    public float RbLowerShare
    {
        get { return rbLowerShare; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("rbLowerShare", value);
            rbLowerShare = value;
        } 
    }

    private float rbMoment = 1.000f;
    /// <summary>
    /// 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment
    /// </summary>
    public float RbMoment
    {
        get { return rbMoment; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("rbMoment", value);
            rbMoment = value;
        } 
    }

    private float rbMaxTwistMomentArm = 0.50f;
    /// <summary>
    /// Maximum twist arm moment of bullet applied
    /// </summary>
    public float RbMaxTwistMomentArm
    {
        get { return rbMaxTwistMomentArm; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("rbMaxTwistMomentArm", value);
            rbMaxTwistMomentArm = value;
        } 
    }

    private float rbMaxBroomMomentArm = 1.00f;
    /// <summary>
    /// Maximum broom((everything but the twist) arm moment of bullet applied
    /// </summary>
    public float RbMaxBroomMomentArm
    {
        get { return rbMaxBroomMomentArm; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("rbMaxBroomMomentArm", value);
            rbMaxBroomMomentArm = value;
        } 
    }

    private float rbRatioAirborne = 0.000f;
    /// <summary>
    /// if Airborne: 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody
    /// </summary>
    public float RbRatioAirborne
    {
        get { return rbRatioAirborne; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("rbRatioAirborne", value);
            rbRatioAirborne = value;
        } 
    }

    private float rbMomentAirborne = 1.000f;
    /// <summary>
    /// if Airborne: 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment
    /// </summary>
    public float RbMomentAirborne
    {
        get { return rbMomentAirborne; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("rbMomentAirborne", value);
            rbMomentAirborne = value;
        } 
    }

    private float rbMaxTwistMomentArmAirborne = 0.50f;
    /// <summary>
    /// if Airborne: Maximum twist arm moment of bullet applied
    /// </summary>
    public float RbMaxTwistMomentArmAirborne
    {
        get { return rbMaxTwistMomentArmAirborne; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("rbMaxTwistMomentArmAirborne", value);
            rbMaxTwistMomentArmAirborne = value;
        } 
    }

    private float rbMaxBroomMomentArmAirborne = 1.00f;
    /// <summary>
    /// if Airborne: Maximum broom((everything but the twist) arm moment of bullet applied
    /// </summary>
    public float RbMaxBroomMomentArmAirborne
    {
        get { return rbMaxBroomMomentArmAirborne; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("rbMaxBroomMomentArmAirborne", value);
            rbMaxBroomMomentArmAirborne = value;
        } 
    }

    private float rbRatioOneLeg = 0.000f;
    /// <summary>
    /// if only one leg in contact: 0.0 no rigidBody response, 0.5 half partForce half rigidBody, 1.0 = no partForce full rigidBody
    /// </summary>
    public float RbRatioOneLeg
    {
        get { return rbRatioOneLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("rbRatioOneLeg", value);
            rbRatioOneLeg = value;
        } 
    }

    private float rbMomentOneLeg = 1.000f;
    /// <summary>
    /// if only one leg in contact: 0.0 only force, 0.5 = force and half the rigid body moment applied, 1.0 = force and full rigidBody moment
    /// </summary>
    public float RbMomentOneLeg
    {
        get { return rbMomentOneLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("rbMomentOneLeg", value);
            rbMomentOneLeg = value;
        } 
    }

    private float rbMaxTwistMomentArmOneLeg = 0.50f;
    /// <summary>
    /// if only one leg in contact: Maximum twist arm moment of bullet applied
    /// </summary>
    public float RbMaxTwistMomentArmOneLeg
    {
        get { return rbMaxTwistMomentArmOneLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("rbMaxTwistMomentArmOneLeg", value);
            rbMaxTwistMomentArmOneLeg = value;
        } 
    }

    private float rbMaxBroomMomentArmOneLeg = 1.00f;
    /// <summary>
    /// if only one leg in contact: Maximum broom((everything but the twist) arm moment of bullet applied
    /// </summary>
    public float RbMaxBroomMomentArmOneLeg
    {
        get { return rbMaxBroomMomentArmOneLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("rbMaxBroomMomentArmOneLeg", value);
            rbMaxBroomMomentArmOneLeg = value;
        } 
    }

    private int rbTwistAxis = 0;
    /// <summary>
    /// Twist axis 0=World Up, 1=CharacterCOM up
    /// </summary>
    public int RbTwistAxis
    {
        get { return rbTwistAxis; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 1);
            SetArgument("rbTwistAxis", value);
            rbTwistAxis = value;
        } 
    }

    private bool rbPivot = false;
    /// <summary>
    /// if false pivot around COM always, if true change pivot depending on foot contact:  to feet centre if both feet in contact, or foot position if 1 foot in contact or COM position if no feet in contact
    /// </summary>
    public bool RbPivot
    {
        get { return rbPivot; } 
        set 
        {  
                
            SetArgument("rbPivot", value);
            rbPivot = value;
        } 
    }


    public EuphoriaMessageConfigureBulletsExtra(bool startNow) : base("configureBulletsExtra", startNow)
    { }

    public new void Reset()
    {
        impulseSpreadOverParts = false;
        impulsePeriod = 0.10f;
        impulseTorqueScale = 1.00f;
        loosenessFix = false;
        impulseDelay = 0.00f;
        torqueMode = 0;
        torqueSpinMode = 0;
        torqueFilterMode = 0;
        torqueAlwaysSpine3 = true;
        torqueDelay = 0.00f;
        torquePeriod = 0.120f;
        torqueGain = 4.00f;
        torqueCutoff = 0.00f;
        torqueReductionPerTick = 0.00f;
        liftGain = 0.00f;
        counterImpulseDelay = 0.033330f;
        counterImpulseMag = 0.50f;
        counterAfterMagReached = false;
        doCounterImpulse = false;
        counterImpulse2Hips = 1.00f;
        impulseNoBalMult = 1.00f;
        impulseBalStabStart = 3.00f;
        impulseBalStabEnd = 10.00f;
        impulseBalStabMult = 1.00f;
        impulseSpineAngStart = 0.70f;
        impulseSpineAngEnd = 0.20f;
        impulseSpineAngMult = 1.00f;
        impulseVelStart = 4.00f;
        impulseVelEnd = 4.00f;
        impulseVelMult = 1.00f;
        impulseAirMult = 1.00f;
        impulseAirMultStart = 100.0f;
        impulseAirMax = 100.0f;
        impulseAirApplyAbove = 399.0f;
        impulseAirOn = false;
        impulseOneLegMult = 1.00f;
        impulseOneLegMultStart = 100.0f;
        impulseOneLegMax = 100.0f;
        impulseOneLegApplyAbove = 399.0f;
        impulseOneLegOn = false;
        rbRatio = 0.000f;
        rbLowerShare = 0.50f;
        rbMoment = 1.000f;
        rbMaxTwistMomentArm = 0.50f;
        rbMaxBroomMomentArm = 1.00f;
        rbRatioAirborne = 0.000f;
        rbMomentAirborne = 1.000f;
        rbMaxTwistMomentArmAirborne = 0.50f;
        rbMaxBroomMomentArmAirborne = 1.00f;
        rbRatioOneLeg = 0.000f;
        rbMomentOneLeg = 1.000f;
        rbMaxTwistMomentArmOneLeg = 0.50f;
        rbMaxBroomMomentArmOneLeg = 1.00f;
        rbTwistAxis = 0;
        rbPivot = false;
        base.Reset();
    }
}
}
