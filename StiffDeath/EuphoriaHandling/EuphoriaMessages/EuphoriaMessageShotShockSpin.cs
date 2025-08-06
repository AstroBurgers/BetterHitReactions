namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// shotShockSpin: configure the shockSpin effect in shot.  Spin/Lift the character using cheat torques/forces
/// </summary>

internal class EuphoriaMessageShotShockSpin : EuphoriaMessage
{
    private bool addShockSpin = false;
    /// <summary>
    /// if enabled, add a short 'shock' of torque to the character's spine to exaggerate bullet impact
    /// </summary>
    public bool AddShockSpin
    {
        get { return addShockSpin; } 
        set 
        {  
                
            SetArgument("addShockSpin", value);
            addShockSpin = value;
        } 
    }

    private bool randomizeShockSpinDirection = false;
    /// <summary>
    /// for use with close-range shotgun blasts, or similar
    /// </summary>
    public bool RandomizeShockSpinDirection
    {
        get { return randomizeShockSpinDirection; } 
        set 
        {  
                
            SetArgument("randomizeShockSpinDirection", value);
            randomizeShockSpinDirection = value;
        } 
    }

    private bool alwaysAddShockSpin = false;
    /// <summary>
    /// if true, apply the shock spin no matter which body component was hit. otherwise only apply if the spine or clavicles get hit
    /// </summary>
    public bool AlwaysAddShockSpin
    {
        get { return alwaysAddShockSpin; } 
        set 
        {  
                
            SetArgument("alwaysAddShockSpin", value);
            alwaysAddShockSpin = value;
        } 
    }

    private float shockSpinMin = 50.0f;
    /// <summary>
    /// minimum amount of torque to add if using shock-spin feature
    /// </summary>
    public float ShockSpinMin
    {
        get { return shockSpinMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1000.0f);
            SetArgument("shockSpinMin", value);
            shockSpinMin = value;
        } 
    }

    private float shockSpinMax = 90.0f;
    /// <summary>
    /// maxiumum amount of torque to add if using shock-spin feature
    /// </summary>
    public float ShockSpinMax
    {
        get { return shockSpinMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1000.0f);
            SetArgument("shockSpinMax", value);
            shockSpinMax = value;
        } 
    }

    private float shockSpinLiftForceMult = 0.0f;
    /// <summary>
    /// if greater than 0, apply a force to lift the character up while the torque is applied, trying to produce a dramatic spun/twist shotgun-to-the-chest effect. this is a scale of the torque applied, so 8.0 or so would give a reasonable amount of lift
    /// </summary>
    public float ShockSpinLiftForceMult
    {
        get { return shockSpinLiftForceMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("shockSpinLiftForceMult", value);
            shockSpinLiftForceMult = value;
        } 
    }

    private float shockSpinDecayMult = 4.0f;
    /// <summary>
    /// multiplier used when decaying torque spin over time
    /// </summary>
    public float ShockSpinDecayMult
    {
        get { return shockSpinDecayMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("shockSpinDecayMult", value);
            shockSpinDecayMult = value;
        } 
    }

    private float shockSpinScalePerComponent = 0.5f;
    /// <summary>
    /// torque applied is scaled by this amount across the spine components - spine2 recieving the full amount, then 3 and 1 and finally 0. each time, this value is used to scale it down. 0.5 means half the torque each time.
    /// </summary>
    public float ShockSpinScalePerComponent
    {
        get { return shockSpinScalePerComponent; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("shockSpinScalePerComponent", value);
            shockSpinScalePerComponent = value;
        } 
    }

    private float shockSpinMaxTwistVel = -1.0f;
    /// <summary>
    /// shock spin ends when twist velocity is greater than this value (try 6.0).  If set to -1 does not stop
    /// </summary>
    public float ShockSpinMaxTwistVel
    {
        get { return shockSpinMaxTwistVel; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 200.0f);
            SetArgument("shockSpinMaxTwistVel", value);
            shockSpinMaxTwistVel = value;
        } 
    }

    private bool shockSpinScaleByLeverArm = true;
    /// <summary>
    /// shock spin scales by lever arm of bullet i.e. bullet impact point to centre line
    /// </summary>
    public bool ShockSpinScaleByLeverArm
    {
        get { return shockSpinScaleByLeverArm; } 
        set 
        {  
                
            SetArgument("shockSpinScaleByLeverArm", value);
            shockSpinScaleByLeverArm = value;
        } 
    }

    private float shockSpinAirMult = 1.0f;
    /// <summary>
    /// shockSpin's torque is multipied by this value when both the character's feet are not in contact
    /// </summary>
    public float ShockSpinAirMult
    {
        get { return shockSpinAirMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("shockSpinAirMult", value);
            shockSpinAirMult = value;
        } 
    }

    private float shockSpin1FootMult = 1.0f;
    /// <summary>
    /// shockSpin's torque is multipied by this value when the one of the character's feet are not in contact
    /// </summary>
    public float ShockSpin1FootMult
    {
        get { return shockSpin1FootMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("shockSpin1FootMult", value);
            shockSpin1FootMult = value;
        } 
    }

    private float shockSpinFootGripMult = 1.0f;
    /// <summary>
    /// shockSpin scales the torques applied to the feet by footSlipCompensation
    /// </summary>
    public float ShockSpinFootGripMult
    {
        get { return shockSpinFootGripMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("shockSpinFootGripMult", value);
            shockSpinFootGripMult = value;
        } 
    }

    private float bracedSideSpinMult = 1.0f;
    /// <summary>
    /// If shot on a side with a forward foot and both feet are on the ground and balanced, increase the shockspin to compensate for the balancer naturally resisting spin to that side
    /// </summary>
    public float BracedSideSpinMult
    {
        get { return bracedSideSpinMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 1.0f, 5.0f);
            SetArgument("bracedSideSpinMult", value);
            bracedSideSpinMult = value;
        } 
    }


    public EuphoriaMessageShotShockSpin(bool startNow) : base("shotShockSpin", startNow)
    { }

    public new void Reset()
    {
        addShockSpin = false;
        randomizeShockSpinDirection = false;
        alwaysAddShockSpin = false;
        shockSpinMin = 50.0f;
        shockSpinMax = 90.0f;
        shockSpinLiftForceMult = 0.0f;
        shockSpinDecayMult = 4.0f;
        shockSpinScalePerComponent = 0.5f;
        shockSpinMaxTwistVel = -1.0f;
        shockSpinScaleByLeverArm = true;
        shockSpinAirMult = 1.0f;
        shockSpin1FootMult = 1.0f;
        shockSpinFootGripMult = 1.0f;
        bracedSideSpinMult = 1.0f;
        base.Reset();
    }
}
}
