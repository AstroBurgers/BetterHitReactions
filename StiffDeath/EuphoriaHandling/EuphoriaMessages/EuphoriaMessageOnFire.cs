using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageOnFire : EuphoriaMessage
{
    private float staggerTime = 2.50f;
    /// <summary>
    /// Max time for stumbling around before falling to ground.
    /// </summary>
    public float StaggerTime
    {
        get { return staggerTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 30.00f);
            SetArgument("staggerTime", value);
            staggerTime = value;
        } 
    }

    private float staggerLeanRate = 0.90f;
    /// <summary>
    /// How quickly the character leans hips when staggering.
    /// </summary>
    public float StaggerLeanRate
    {
        get { return staggerLeanRate; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("staggerLeanRate", value);
            staggerLeanRate = value;
        } 
    }

    private float stumbleMaxLeanBack = 0.40f;
    /// <summary>
    /// max the character leans hips back when staggering
    /// </summary>
    public float StumbleMaxLeanBack
    {
        get { return stumbleMaxLeanBack; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.50f);
            SetArgument("stumbleMaxLeanBack", value);
            stumbleMaxLeanBack = value;
        } 
    }

    private float stumbleMaxLeanForward = 0.50f;
    /// <summary>
    /// max the character leans hips forwards when staggering
    /// </summary>
    public float StumbleMaxLeanForward
    {
        get { return stumbleMaxLeanForward; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.50f);
            SetArgument("stumbleMaxLeanForward", value);
            stumbleMaxLeanForward = value;
        } 
    }

    private float armsWindmillWritheBlend = 0.40f;
    /// <summary>
    /// Blend armsWindmill with the bodyWrithe arms when character is upright.
    /// </summary>
    public float ArmsWindmillWritheBlend
    {
        get { return armsWindmillWritheBlend; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("armsWindmillWritheBlend", value);
            armsWindmillWritheBlend = value;
        } 
    }

    private float spineStumbleWritheBlend = 0.70f;
    /// <summary>
    /// Blend spine stumble with the bodyWrithe spine when character is upright.
    /// </summary>
    public float SpineStumbleWritheBlend
    {
        get { return spineStumbleWritheBlend; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("spineStumbleWritheBlend", value);
            spineStumbleWritheBlend = value;
        } 
    }

    private float legsStumbleWritheBlend = 0.20f;
    /// <summary>
    /// Blend legs stumble with the bodyWrithe legs when character is upright.
    /// </summary>
    public float LegsStumbleWritheBlend
    {
        get { return legsStumbleWritheBlend; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("legsStumbleWritheBlend", value);
            legsStumbleWritheBlend = value;
        } 
    }

    private float armsPoseWritheBlend = 0.70f;
    /// <summary>
    /// Blend the bodyWrithe arms with the current desired pose from on fire behaviour when character is on the floor.
    /// </summary>
    public float ArmsPoseWritheBlend
    {
        get { return armsPoseWritheBlend; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("armsPoseWritheBlend", value);
            armsPoseWritheBlend = value;
        } 
    }

    private float spinePoseWritheBlend = 0.550f;
    /// <summary>
    /// Blend the bodyWrithe back with the current desired pose from on fire behaviour when character is on the floor.
    /// </summary>
    public float SpinePoseWritheBlend
    {
        get { return spinePoseWritheBlend; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("spinePoseWritheBlend", value);
            spinePoseWritheBlend = value;
        } 
    }

    private float legsPoseWritheBlend = 0.50f;
    /// <summary>
    /// Blend the bodyWrithe legs with the current desired pose from on fire behaviour when character is on the floor.
    /// </summary>
    public float LegsPoseWritheBlend
    {
        get { return legsPoseWritheBlend; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("legsPoseWritheBlend", value);
            legsPoseWritheBlend = value;
        } 
    }

    private bool rollOverFlag = true;
    /// <summary>
    /// Flag to set bodyWrithe trying to rollOver.
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

    private float rollTorqueScale = 25.00f;
    /// <summary>
    /// Scale rolling torque that is applied to character spine by bodyWrithe. Torque magnitude is calculated with the following formula: m_rollOverDirection*rollOverPhase*rollTorqueScale.
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

    private float predictTime = 0.10f;
    /// <summary>
    /// Character pose depends on character facing direction that is evaluated from its COMTM orientation. Set this value to 0 to use no orientation prediction i.e. current character COMTM orientation will be used to determine character facing direction and finally the pose bodyWrithe is blending to. Set this value to  GT  0 to predict character COMTM orientation this amout of time in seconds to the future.
    /// </summary>
    public float PredictTime
    {
        get { return predictTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("predictTime", value);
            predictTime = value;
        } 
    }

    private float maxRollOverTime = 8.00f;
    /// <summary>
    /// Rolling torque is ramped down over time. At this time in seconds torque value converges to zero. Use this parameter to restrict time the character is rolling.
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
    /// Rolling torque is ramped down with distance measured from position where character hit the ground and started rolling. At this distance in meters torque value converges to zero. Use this parameter to restrict distance the character travels due to rolling.
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


    public EuphoriaMessageOnFire(bool startNow) : base("onFire", startNow)
    { }

    public new void Reset()
    {
        staggerTime = 2.50f;
        staggerLeanRate = 0.90f;
        stumbleMaxLeanBack = 0.40f;
        stumbleMaxLeanForward = 0.50f;
        armsWindmillWritheBlend = 0.40f;
        spineStumbleWritheBlend = 0.70f;
        legsStumbleWritheBlend = 0.20f;
        armsPoseWritheBlend = 0.70f;
        spinePoseWritheBlend = 0.550f;
        legsPoseWritheBlend = 0.50f;
        rollOverFlag = true;
        rollTorqueScale = 25.00f;
        predictTime = 0.10f;
        maxRollOverTime = 8.00f;
        rollOverRadius = 2.00f;
        base.Reset();
    }
}
}
