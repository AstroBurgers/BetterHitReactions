using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageShotSnap : EuphoriaMessage
{
    private bool snap = false;
    /// <summary>
    /// Add a Snap to shot.
    /// </summary>
    public bool Snap
    {
        get { return snap; } 
        set 
        {  
                
            SetArgument("snap", value);
            snap = value;
        } 
    }

    private float snapMag = 0.40f;
    /// <summary>
    /// The magnitude of the reaction
    /// </summary>
    public float SnapMag
    {
        get { return snapMag; } 
        set 
        {  
            value = MathHelper.Clamp(value, -10.00f, 10.0f);
            SetArgument("snapMag", value);
            snapMag = value;
        } 
    }

    private float snapMovingMult = 1.0f;
    /// <summary>
    /// movingMult*snapMag = The magnitude of the reaction if moving(comVelMag) faster than movingThresh
    /// </summary>
    public float SnapMovingMult
    {
        get { return snapMovingMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 20.0f);
            SetArgument("snapMovingMult", value);
            snapMovingMult = value;
        } 
    }

    private float snapBalancingMult = 1.0f;
    /// <summary>
    /// balancingMult*snapMag = The magnitude of the reaction if balancing = (not lying on the floor/ not upper body not collided) and not airborne
    /// </summary>
    public float SnapBalancingMult
    {
        get { return snapBalancingMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 20.0f);
            SetArgument("snapBalancingMult", value);
            snapBalancingMult = value;
        } 
    }

    private float snapAirborneMult = 1.0f;
    /// <summary>
    /// airborneMult*snapMag = The magnitude of the reaction if airborne
    /// </summary>
    public float SnapAirborneMult
    {
        get { return snapAirborneMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 20.0f);
            SetArgument("snapAirborneMult", value);
            snapAirborneMult = value;
        } 
    }

    private float snapMovingThresh = 1.0f;
    /// <summary>
    /// If moving(comVelMag) faster than movingThresh then mvingMult applied to stunMag
    /// </summary>
    public float SnapMovingThresh
    {
        get { return snapMovingThresh; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 20.0f);
            SetArgument("snapMovingThresh", value);
            snapMovingThresh = value;
        } 
    }

    private float snapDirectionRandomness = 0.30f;
    /// <summary>
    /// The character snaps in a prescribed way (decided by bullet direction) - Higher the value the more random this direction is.
    /// </summary>
    public float SnapDirectionRandomness
    {
        get { return snapDirectionRandomness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.0f);
            SetArgument("snapDirectionRandomness", value);
            snapDirectionRandomness = value;
        } 
    }

    private bool snapLeftArm = false;
    /// <summary>
    /// snap the leftArm.
    /// </summary>
    public bool SnapLeftArm
    {
        get { return snapLeftArm; } 
        set 
        {  
                
            SetArgument("snapLeftArm", value);
            snapLeftArm = value;
        } 
    }

    private bool snapRightArm = false;
    /// <summary>
    /// snap the rightArm.
    /// </summary>
    public bool SnapRightArm
    {
        get { return snapRightArm; } 
        set 
        {  
                
            SetArgument("snapRightArm", value);
            snapRightArm = value;
        } 
    }

    private bool snapLeftLeg = false;
    /// <summary>
    /// snap the leftLeg.
    /// </summary>
    public bool SnapLeftLeg
    {
        get { return snapLeftLeg; } 
        set 
        {  
                
            SetArgument("snapLeftLeg", value);
            snapLeftLeg = value;
        } 
    }

    private bool snapRightLeg = false;
    /// <summary>
    /// snap the rightLeg.
    /// </summary>
    public bool SnapRightLeg
    {
        get { return snapRightLeg; } 
        set 
        {  
                
            SetArgument("snapRightLeg", value);
            snapRightLeg = value;
        } 
    }

    private bool snapSpine = true;
    /// <summary>
    /// snap the spine.
    /// </summary>
    public bool SnapSpine
    {
        get { return snapSpine; } 
        set 
        {  
                
            SetArgument("snapSpine", value);
            snapSpine = value;
        } 
    }

    private bool snapNeck = true;
    /// <summary>
    /// snap the neck.
    /// </summary>
    public bool SnapNeck
    {
        get { return snapNeck; } 
        set 
        {  
                
            SetArgument("snapNeck", value);
            snapNeck = value;
        } 
    }

    private bool snapPhasedLegs = true;
    /// <summary>
    /// Legs are either in phase with each other or not
    /// </summary>
    public bool SnapPhasedLegs
    {
        get { return snapPhasedLegs; } 
        set 
        {  
                
            SetArgument("snapPhasedLegs", value);
            snapPhasedLegs = value;
        } 
    }

    private int snapHipType = 0;
    /// <summary>
    /// type of hip reaction 0=none, 1=side2side 2=steplike
    /// </summary>
    public int SnapHipType
    {
        get { return snapHipType; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("snapHipType", value);
            snapHipType = value;
        } 
    }

    private bool snapUseBulletDir = true;
    /// <summary>
    /// Legs are either in phase with each other or not
    /// </summary>
    public bool SnapUseBulletDir
    {
        get { return snapUseBulletDir; } 
        set 
        {  
                
            SetArgument("snapUseBulletDir", value);
            snapUseBulletDir = value;
        } 
    }

    private bool snapHitPart = false;
    /// <summary>
    /// Snap only around the wounded part//mmmmtodo check whether bodyPart doesn't have to be remembered for unSnap
    /// </summary>
    public bool SnapHitPart
    {
        get { return snapHitPart; } 
        set 
        {  
                
            SetArgument("snapHitPart", value);
            snapHitPart = value;
        } 
    }

    private float unSnapInterval = 0.010f;
    /// <summary>
    /// Interval before applying reverse snap
    /// </summary>
    public float UnSnapInterval
    {
        get { return unSnapInterval; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.0f);
            SetArgument("unSnapInterval", value);
            unSnapInterval = value;
        } 
    }

    private float unSnapRatio = 0.70f;
    /// <summary>
    /// The magnitude of the reverse snap
    /// </summary>
    public float UnSnapRatio
    {
        get { return unSnapRatio; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.0f);
            SetArgument("unSnapRatio", value);
            unSnapRatio = value;
        } 
    }

    private bool snapUseTorques = true;
    /// <summary>
    /// use torques to make the snap otherwise use a change in the parts angular velocity
    /// </summary>
    public bool SnapUseTorques
    {
        get { return snapUseTorques; } 
        set 
        {  
                
            SetArgument("snapUseTorques", value);
            snapUseTorques = value;
        } 
    }


    public EuphoriaMessageShotSnap(bool startNow) : base("shotSnap", startNow)
    { }

    public new void Reset()
    {
        snap = false;
        snapMag = 0.40f;
        snapMovingMult = 1.0f;
        snapBalancingMult = 1.0f;
        snapAirborneMult = 1.0f;
        snapMovingThresh = 1.0f;
        snapDirectionRandomness = 0.30f;
        snapLeftArm = false;
        snapRightArm = false;
        snapLeftLeg = false;
        snapRightLeg = false;
        snapSpine = true;
        snapNeck = true;
        snapPhasedLegs = true;
        snapHipType = 0;
        snapUseBulletDir = true;
        snapHitPart = false;
        unSnapInterval = 0.010f;
        unSnapRatio = 0.70f;
        snapUseTorques = true;
        base.Reset();
    }
}
}
