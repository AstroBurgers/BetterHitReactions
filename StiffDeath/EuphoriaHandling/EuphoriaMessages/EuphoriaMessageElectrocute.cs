using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageElectrocute : EuphoriaMessage
{
    private float stunMag = 0.250f;
    /// <summary>
    /// The magnitude of the reaction
    /// </summary>
    public float StunMag
    {
        get { return stunMag; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("stunMag", value);
            stunMag = value;
        } 
    }

    private float initialMult = 1.00f;
    /// <summary>
    /// initialMult*stunMag = The magnitude of the 1st snap reaction (other mults are applied after this)
    /// </summary>
    public float InitialMult
    {
        get { return initialMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.00f);
            SetArgument("initialMult", value);
            initialMult = value;
        } 
    }

    private float largeMult = 1.00f;
    /// <summary>
    /// largeMult*stunMag = The magnitude of a random large snap reaction (other mults are applied after this)
    /// </summary>
    public float LargeMult
    {
        get { return largeMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.0f);
            SetArgument("largeMult", value);
            largeMult = value;
        } 
    }

    private float largeMinTime = 1.00f;
    /// <summary>
    /// min time to next large random snap (about 14 snaps with stunInterval = 0.07s)
    /// </summary>
    public float LargeMinTime
    {
        get { return largeMinTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 200.00f);
            SetArgument("largeMinTime", value);
            largeMinTime = value;
        } 
    }

    private float largeMaxTime = 2.00f;
    /// <summary>
    /// max time to next large random snap (about 28 snaps with stunInterval = 0.07s)
    /// </summary>
    public float LargeMaxTime
    {
        get { return largeMaxTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 200.00f);
            SetArgument("largeMaxTime", value);
            largeMaxTime = value;
        } 
    }

    private float movingMult = 1.00f;
    /// <summary>
    /// movingMult*stunMag = The magnitude of the reaction if moving(comVelMag) faster than movingThresh
    /// </summary>
    public float MovingMult
    {
        get { return movingMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.00f);
            SetArgument("movingMult", value);
            movingMult = value;
        } 
    }

    private float balancingMult = 1.00f;
    /// <summary>
    /// balancingMult*stunMag = The magnitude of the reaction if balancing = (not lying on the floor/ not upper body not collided) and not airborne
    /// </summary>
    public float BalancingMult
    {
        get { return balancingMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.00f);
            SetArgument("balancingMult", value);
            balancingMult = value;
        } 
    }

    private float airborneMult = 1.00f;
    /// <summary>
    /// airborneMult*stunMag = The magnitude of the reaction if airborne
    /// </summary>
    public float AirborneMult
    {
        get { return airborneMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.00f);
            SetArgument("airborneMult", value);
            airborneMult = value;
        } 
    }

    private float movingThresh = 1.00f;
    /// <summary>
    /// If moving(comVelMag) faster than movingThresh then mvingMult applied to stunMag
    /// </summary>
    public float MovingThresh
    {
        get { return movingThresh; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.00f);
            SetArgument("movingThresh", value);
            movingThresh = value;
        } 
    }

    private float stunInterval = 0.070f;
    /// <summary>
    /// Direction flips every stunInterval
    /// </summary>
    public float StunInterval
    {
        get { return stunInterval; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("stunInterval", value);
            stunInterval = value;
        } 
    }

    private float directionRandomness = 0.30f;
    /// <summary>
    /// The character vibrates in a prescribed way - Higher the value the more random this direction is.
    /// </summary>
    public float DirectionRandomness
    {
        get { return directionRandomness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("directionRandomness", value);
            directionRandomness = value;
        } 
    }

    private bool leftArm = true;
    /// <summary>
    /// vibrate the leftArm.
    /// </summary>
    public bool LeftArm
    {
        get { return leftArm; } 
        set 
        {  
                
            SetArgument("leftArm", value);
            leftArm = value;
        } 
    }

    private bool rightArm = true;
    /// <summary>
    /// vibrate the rightArm.
    /// </summary>
    public bool RightArm
    {
        get { return rightArm; } 
        set 
        {  
                
            SetArgument("rightArm", value);
            rightArm = value;
        } 
    }

    private bool leftLeg = true;
    /// <summary>
    /// vibrate the leftLeg.
    /// </summary>
    public bool LeftLeg
    {
        get { return leftLeg; } 
        set 
        {  
                
            SetArgument("leftLeg", value);
            leftLeg = value;
        } 
    }

    private bool rightLeg = true;
    /// <summary>
    /// vibrate the rightLeg.
    /// </summary>
    public bool RightLeg
    {
        get { return rightLeg; } 
        set 
        {  
                
            SetArgument("rightLeg", value);
            rightLeg = value;
        } 
    }

    private bool spine = true;
    /// <summary>
    /// vibrate the spine.
    /// </summary>
    public bool Spine
    {
        get { return spine; } 
        set 
        {  
                
            SetArgument("spine", value);
            spine = value;
        } 
    }

    private bool neck = true;
    /// <summary>
    /// vibrate the neck.
    /// </summary>
    public bool Neck
    {
        get { return neck; } 
        set 
        {  
                
            SetArgument("neck", value);
            neck = value;
        } 
    }

    private bool phasedLegs = true;
    /// <summary>
    /// Legs are either in phase with each other or not
    /// </summary>
    public bool PhasedLegs
    {
        get { return phasedLegs; } 
        set 
        {  
                
            SetArgument("phasedLegs", value);
            phasedLegs = value;
        } 
    }

    private bool applyStiffness = true;
    /// <summary>
    /// let electrocute apply a (higher generally) stiffness to the character whilst being vibrated
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

    private bool useTorques = true;
    /// <summary>
    /// use torques to make vibration otherwise use a change in the parts angular velocity
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

    private int hipType = 2;
    /// <summary>
    /// type of hip reaction 0=none, 1=side2side 2=steplike
    /// </summary>
    public int HipType
    {
        get { return hipType; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("hipType", value);
            hipType = value;
        } 
    }


    public EuphoriaMessageElectrocute(bool startNow) : base("electrocute", startNow)
    { }

    public new void Reset()
    {
        stunMag = 0.250f;
        initialMult = 1.00f;
        largeMult = 1.00f;
        largeMinTime = 1.00f;
        largeMaxTime = 2.00f;
        movingMult = 1.00f;
        balancingMult = 1.00f;
        airborneMult = 1.00f;
        movingThresh = 1.00f;
        stunInterval = 0.070f;
        directionRandomness = 0.30f;
        leftArm = true;
        rightArm = true;
        leftLeg = true;
        rightLeg = true;
        spine = true;
        neck = true;
        phasedLegs = true;
        applyStiffness = true;
        useTorques = true;
        hipType = 2;
        base.Reset();
    }
}
}
