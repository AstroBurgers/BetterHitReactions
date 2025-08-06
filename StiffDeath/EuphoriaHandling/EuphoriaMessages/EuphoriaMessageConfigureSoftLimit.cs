using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageConfigureSoftLimit : EuphoriaMessage
{
    private int index = 0;
    /// <summary>
    /// Select limb that the soft limit is going to be applied to
    /// </summary>
    public int Index
    {
        get { return index; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 3);
            SetArgument("index", value);
            index = value;
        } 
    }

    private float stiffness = 15.00f;
    /// <summary>
    /// Stiffness of the soft limit. Parameter is used to calculate spring term that contributes to the desired acceleration.
    /// </summary>
    public float Stiffness
    {
        get { return stiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 30.00f);
            SetArgument("stiffness", value);
            stiffness = value;
        } 
    }

    private float damping = 1.00f;
    /// <summary>
    /// Damping of the soft limit. Parameter is used to calculate damper term that contributes to the desired acceleration. To have the system critically dampened set it to 1.0.
    /// </summary>
    public float Damping
    {
        get { return damping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.90f, 1.10f);
            SetArgument("damping", value);
            damping = value;
        } 
    }

    private float limitAngle = 0.40f;
    /// <summary>
    /// Soft limit angle. Positive angle in RAD, measured relatively either from hard limit maxAngle (approach direction = -1) or minAngle (approach direction = 1). This angle will be clamped if outside the joint hard limit range.
    /// </summary>
    public float LimitAngle
    {
        get { return limitAngle; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 6.283185f);
            SetArgument("limitAngle", value);
            limitAngle = value;
        } 
    }

    private int approachDirection = 1;
    /// <summary>
    /// Limit angle can be measured relatively to joints hard limit minAngle or maxAngle. Set approachDirection to +1 to measure soft limit angle relatively to hard limit minAngle that corresponds to the maximum stretch of the elbow. Set it to -1 to measure soft limit angle relatively to hard limit maxAngle that corresponds to the maximum stretch of the knee.
    /// </summary>
    public int ApproachDirection
    {
        get { return approachDirection; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1, 1);
            SetArgument("approachDirection", value);
            approachDirection = value;
        } 
    }

    private bool velocityScaled = false;
    /// <summary>
    /// Scale stiffness based on character angular velocity.
    /// </summary>
    public bool VelocityScaled
    {
        get { return velocityScaled; } 
        set 
        {  
                
            SetArgument("velocityScaled", value);
            velocityScaled = value;
        } 
    }


    public EuphoriaMessageConfigureSoftLimit(bool startNow) : base("configureSoftLimit", startNow)
    { }

    public new void Reset()
    {
        index = 0;
        stiffness = 15.00f;
        damping = 1.00f;
        limitAngle = 0.40f;
        approachDirection = 1;
        velocityScaled = false;
        base.Reset();
    }
}
}
