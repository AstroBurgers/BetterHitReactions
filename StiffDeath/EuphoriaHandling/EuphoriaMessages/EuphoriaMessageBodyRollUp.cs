using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageBodyRollUp : EuphoriaMessage
{
    private float stiffness = 10.000f;
    /// <summary>
    /// stiffness of whole body
    /// </summary>
    public float Stiffness
    {
        get { return stiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("stiffness", value);
            stiffness = value;
        } 
    }

    private float useArmToSlowDown = 1.300f;
    /// <summary>
    /// the degree to which the character will try to stop a barrel roll with his arms
    /// </summary>
    public float UseArmToSlowDown
    {
        get { return useArmToSlowDown; } 
        set 
        {  
            value = MathHelper.Clamp(value, -2.0f, 3.0f);
            SetArgument("useArmToSlowDown", value);
            useArmToSlowDown = value;
        } 
    }

    private float armReachAmount = 1.400f;
    /// <summary>
    /// the likeliness of the character reaching for the ground with its arms
    /// </summary>
    public float ArmReachAmount
    {
        get { return armReachAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("armReachAmount", value);
            armReachAmount = value;
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

    private float legPush = 0.000f;
    /// <summary>
    /// used to keep rolling down slope, 1 is full (kicks legs out when pointing upwards)
    /// </summary>
    public float LegPush
    {
        get { return legPush; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 2.0f);
            SetArgument("legPush", value);
            legPush = value;
        } 
    }

    private float asymmetricalLegs = 0.000f;
    /// <summary>
    /// 0 is no leg asymmetry in 'foetal' position.  greater than 0 a asymmetricalLegs-rand(30%), added/minus each joint of the legs in radians.  Random number changes about once every roll.  0.4 gives a lot of asymmetry
    /// </summary>
    public float AsymmetricalLegs
    {
        get { return asymmetricalLegs; } 
        set 
        {  
            value = MathHelper.Clamp(value, -2.0f, 2.0f);
            SetArgument("asymmetricalLegs", value);
            asymmetricalLegs = value;
        } 
    }

    private float noRollTimeBeforeSuccess = 0.50f;
    /// <summary>
    /// time that roll velocity has to be lower than rollVelForSuccess, before success message is sent
    /// </summary>
    public float NoRollTimeBeforeSuccess
    {
        get { return noRollTimeBeforeSuccess; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("noRollTimeBeforeSuccess", value);
            noRollTimeBeforeSuccess = value;
        } 
    }

    private float rollVelForSuccess = 0.20f;
    /// <summary>
    /// lower threshold for roll velocity at which success message can be sent
    /// </summary>
    public float RollVelForSuccess
    {
        get { return rollVelForSuccess; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("rollVelForSuccess", value);
            rollVelForSuccess = value;
        } 
    }

    private float rollVelLinearContribution = 1.00f;
    /// <summary>
    /// contribution of linear COM velocity to roll Velocity (if 0, roll velocity equal to COM angular velocity)
    /// </summary>
    public float RollVelLinearContribution
    {
        get { return rollVelLinearContribution; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("rollVelLinearContribution", value);
            rollVelLinearContribution = value;
        } 
    }

    private float velocityScale = 0.20f;
    /// <summary>
    /// Scales perceived body velocity.  The higher this value gets, the more quickly the velocity measure saturates, resulting in a tighter roll at slower speeds. (NB: Set to 1 to match earlier behaviour)
    /// </summary>
    public float VelocityScale
    {
        get { return velocityScale; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("velocityScale", value);
            velocityScale = value;
        } 
    }

    private float velocityOffset = 2.00f;
    /// <summary>
    /// Offsets perceived body velocity.  Increase to create larger "dead zone" around zero velocity where character will be less rolled. (NB: Reset to 0 to match earlier behaviour)
    /// </summary>
    public float VelocityOffset
    {
        get { return velocityOffset; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("velocityOffset", value);
            velocityOffset = value;
        } 
    }

    private bool applyMinMaxFriction = true;
    /// <summary>
    /// Controls whether or not behaviour enforces min/max friction
    /// </summary>
    public bool ApplyMinMaxFriction
    {
        get { return applyMinMaxFriction; } 
        set 
        {  
                
            SetArgument("applyMinMaxFriction", value);
            applyMinMaxFriction = value;
        } 
    }


    public EuphoriaMessageBodyRollUp(bool startNow) : base("bodyRollUp", startNow)
    { }

    public new void Reset()
    {
        stiffness = 10.000f;
        useArmToSlowDown = 1.300f;
        armReachAmount = 1.400f;
        mask = "fb";
        legPush = 0.000f;
        asymmetricalLegs = 0.000f;
        noRollTimeBeforeSuccess = 0.50f;
        rollVelForSuccess = 0.20f;
        rollVelLinearContribution = 1.00f;
        velocityScale = 0.20f;
        velocityOffset = 2.00f;
        applyMinMaxFriction = true;
        base.Reset();
    }
}
}
