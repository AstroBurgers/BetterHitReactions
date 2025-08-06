namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageBodyWrithe : EuphoriaMessage
{
    private float armStiffness = 13.000f;
    /// <summary>
    /// 
    /// </summary>
    public float ArmStiffness
    {
        get { return armStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("armStiffness", value);
            armStiffness = value;
        } 
    }

    private float backStiffness = 13.000f;
    /// <summary>
    /// 
    /// </summary>
    public float BackStiffness
    {
        get { return backStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("backStiffness", value);
            backStiffness = value;
        } 
    }

    private float legStiffness = 13.000f;
    /// <summary>
    /// The stiffness of the character will determine how 'determined' a writhe this is - high values will make him thrash about wildly
    /// </summary>
    public float LegStiffness
    {
        get { return legStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("legStiffness", value);
            legStiffness = value;
        } 
    }

    private float armDamping = 0.500f;
    /// <summary>
    /// damping amount, less is underdamped
    /// </summary>
    public float ArmDamping
    {
        get { return armDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("armDamping", value);
            armDamping = value;
        } 
    }

    private float backDamping = 0.500f;
    /// <summary>
    /// damping amount, less is underdamped
    /// </summary>
    public float BackDamping
    {
        get { return backDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("backDamping", value);
            backDamping = value;
        } 
    }

    private float legDamping = 0.500f;
    /// <summary>
    /// damping amount, less is underdamped
    /// </summary>
    public float LegDamping
    {
        get { return legDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("legDamping", value);
            legDamping = value;
        } 
    }

    private float armPeriod = 1.000f;
    /// <summary>
    /// Controls how fast the writhe is executed, smaller values make faster motions
    /// </summary>
    public float ArmPeriod
    {
        get { return armPeriod; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 4.0f);
            SetArgument("armPeriod", value);
            armPeriod = value;
        } 
    }

    private float backPeriod = 1.000f;
    /// <summary>
    /// Controls how fast the writhe is executed, smaller values make faster motions
    /// </summary>
    public float BackPeriod
    {
        get { return backPeriod; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 4.0f);
            SetArgument("backPeriod", value);
            backPeriod = value;
        } 
    }

    private float legPeriod = 1.000f;
    /// <summary>
    /// Controls how fast the writhe is executed, smaller values make faster motions
    /// </summary>
    public float LegPeriod
    {
        get { return legPeriod; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 4.0f);
            SetArgument("legPeriod", value);
            legPeriod = value;
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

    private float armAmplitude = 1.000f;
    /// <summary>
    /// 
    /// </summary>
    public float ArmAmplitude
    {
        get { return armAmplitude; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("armAmplitude", value);
            armAmplitude = value;
        } 
    }

    private float backAmplitude = 1.000f;
    /// <summary>
    /// scales the amount of writhe. 0 = no writhe
    /// </summary>
    public float BackAmplitude
    {
        get { return backAmplitude; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("backAmplitude", value);
            backAmplitude = value;
        } 
    }

    private float legAmplitude = 1.000f;
    /// <summary>
    /// scales the amount of writhe. 0 = no writhe
    /// </summary>
    public float LegAmplitude
    {
        get { return legAmplitude; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("legAmplitude", value);
            legAmplitude = value;
        } 
    }

    private float elbowAmplitude = 1.000f;
    /// <summary>
    /// 
    /// </summary>
    public float ElbowAmplitude
    {
        get { return elbowAmplitude; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("elbowAmplitude", value);
            elbowAmplitude = value;
        } 
    }

    private float kneeAmplitude = 1.000f;
    /// <summary>
    /// 
    /// </summary>
    public float KneeAmplitude
    {
        get { return kneeAmplitude; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("kneeAmplitude", value);
            kneeAmplitude = value;
        } 
    }

    private bool rollOverFlag = false;
    /// <summary>
    /// Flag to set trying to rollOver
    /// </summary>
    public bool RollOverFlag
    {
        get { return rollOverFlag; } 
        set 
        {  
                
            SetArgument("rollOverFlag", value);
            rollOverFlag = value;
        } 
    }

    private float blendArms = 1.0f;
    /// <summary>
    /// Blend the writhe arms with the current desired arms (0=don't apply any writhe, 1=only writhe)
    /// </summary>
    public float BlendArms
    {
        get { return blendArms; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("blendArms", value);
            blendArms = value;
        } 
    }

    private float blendBack = 1.0f;
    /// <summary>
    /// Blend the writhe spine and neck with the current desired (0=don't apply any writhe, 1=only writhe)
    /// </summary>
    public float BlendBack
    {
        get { return blendBack; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("blendBack", value);
            blendBack = value;
        } 
    }

    private float blendLegs = 1.0f;
    /// <summary>
    /// Blend the writhe legs with the current desired legs (0=don't apply any writhe, 1=only writhe)
    /// </summary>
    public float BlendLegs
    {
        get { return blendLegs; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("blendLegs", value);
            blendLegs = value;
        } 
    }

    private bool applyStiffness = true;
    /// <summary>
    /// Use writhe stiffnesses if true. If false don't set any stiffnesses
    /// </summary>
    public bool ApplyStiffness
    {
        get { return applyStiffness; } 
        set 
        {  
                
            SetArgument("applyStiffness", value);
            applyStiffness = value;
        } 
    }

    private bool onFire = false;
    /// <summary>
    /// Extra shoulderBlend. Rolling:one way only, maxRollOverTime, rollOverRadius, doesn't reduce arm stiffness to help rolling. No shoulder twist
    /// </summary>
    public bool OnFire
    {
        get { return onFire; } 
        set 
        {  
                
            SetArgument("onFire", value);
            onFire = value;
        } 
    }

    private float shoulderLean1 = 0.70f;
    /// <summary>
    /// Blend writhe shoulder desired lean1 with this angle in RAD. Note that onFire has to be set to true for this parameter to take any effect.
    /// </summary>
    public float ShoulderLean1
    {
        get { return shoulderLean1; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 6.283185f);
            SetArgument("shoulderLean1", value);
            shoulderLean1 = value;
        } 
    }

    private float shoulderLean2 = 0.40f;
    /// <summary>
    /// Blend writhe shoulder desired lean2 with this angle in RAD. Note that onFire has to be set to true for this parameter to take any effect.
    /// </summary>
    public float ShoulderLean2
    {
        get { return shoulderLean2; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 6.283185f);
            SetArgument("shoulderLean2", value);
            shoulderLean2 = value;
        } 
    }

    private float lean1BlendFactor = 0.00f;
    /// <summary>
    /// Shoulder desired lean1 with shoulderLean1 angle blend factor. Set it to 0 to use original shoulder withe desired lean1 angle for shoulders. Note that onFire has to be set to true for this parameter to take any effect.
    /// </summary>
    public float Lean1BlendFactor
    {
        get { return lean1BlendFactor; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("lean1BlendFactor", value);
            lean1BlendFactor = value;
        } 
    }

    private float lean2BlendFactor = 0.00f;
    /// <summary>
    /// Shoulder desired lean2 with shoulderLean2 angle blend factor. Set it to 0 to use original shoulder withe desired lean2 angle for shoulders. Note that onFire has to be set to true for this parameter to take any effect.
    /// </summary>
    public float Lean2BlendFactor
    {
        get { return lean2BlendFactor; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("lean2BlendFactor", value);
            lean2BlendFactor = value;
        } 
    }

    private float rollTorqueScale = 150.00f;
    /// <summary>
    /// Scale rolling torque that is applied to character spine.
    /// </summary>
    public float RollTorqueScale
    {
        get { return rollTorqueScale; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 300.00f);
            SetArgument("rollTorqueScale", value);
            rollTorqueScale = value;
        } 
    }

    private float maxRollOverTime = 8.00f;
    /// <summary>
    /// Rolling torque is ramped down over time. At this time in seconds torque value converges to zero. Use this parameter to restrict time the character is rolling. Note that onFire has to be set to true for this parameter to take any effect.
    /// </summary>
    public float MaxRollOverTime
    {
        get { return maxRollOverTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 60.00f);
            SetArgument("maxRollOverTime", value);
            maxRollOverTime = value;
        } 
    }

    private float rollOverRadius = 2.00f;
    /// <summary>
    /// Rolling torque is ramped down with distance measured from position where character hit the ground and started rolling. At this distance in meters torque value converges to zero. Use this parameter to restrict distance the character travels due to rolling. Note that onFire has to be set to true for this parameter to take any effect.
    /// </summary>
    public float RollOverRadius
    {
        get { return rollOverRadius; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("rollOverRadius", value);
            rollOverRadius = value;
        } 
    }


    public EuphoriaMessageBodyWrithe(bool startNow) : base("bodyWrithe", startNow)
    { }

    public new void Reset()
    {
        armStiffness = 13.000f;
        backStiffness = 13.000f;
        legStiffness = 13.000f;
        armDamping = 0.500f;
        backDamping = 0.500f;
        legDamping = 0.500f;
        armPeriod = 1.000f;
        backPeriod = 1.000f;
        legPeriod = 1.000f;
        mask = "fb";
        armAmplitude = 1.000f;
        backAmplitude = 1.000f;
        legAmplitude = 1.000f;
        elbowAmplitude = 1.000f;
        kneeAmplitude = 1.000f;
        rollOverFlag = false;
        blendArms = 1.0f;
        blendBack = 1.0f;
        blendLegs = 1.0f;
        applyStiffness = true;
        onFire = false;
        shoulderLean1 = 0.70f;
        shoulderLean2 = 0.40f;
        lean1BlendFactor = 0.00f;
        lean2BlendFactor = 0.00f;
        rollTorqueScale = 150.00f;
        maxRollOverTime = 8.00f;
        rollOverRadius = 2.00f;
        base.Reset();
    }
}
}
