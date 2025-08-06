using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageArmsWindmill : EuphoriaMessage
{
    private int leftPartID = 10;
    /// <summary>
    /// ID of part that the circle uses as local space for positioning
    /// </summary>
    public int LeftPartID
    {
        get { return leftPartID; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 21);
            SetArgument("leftPartID", value);
            leftPartID = value;
        } 
    }

    private float leftRadius1 = 0.750f;
    /// <summary>
    /// radius for first axis of ellipse
    /// </summary>
    public float LeftRadius1
    {
        get { return leftRadius1; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("leftRadius1", value);
            leftRadius1 = value;
        } 
    }

    private float leftRadius2 = 0.750f;
    /// <summary>
    /// radius for second axis of ellipse
    /// </summary>
    public float LeftRadius2
    {
        get { return leftRadius2; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("leftRadius2", value);
            leftRadius2 = value;
        } 
    }

    private float leftSpeed = 1.00f;
    /// <summary>
    /// speed of target around the circle
    /// </summary>
    public float LeftSpeed
    {
        get { return leftSpeed; } 
        set 
        {  
            value = MathHelper.Clamp(value, -2.00f, 2.00f);
            SetArgument("leftSpeed", value);
            leftSpeed = value;
        } 
    }

    private Vector3 leftNormal = new(0.00f,  0.20f,  0.20f);
    /// <summary>
    /// Euler Angles orientation of circle in space of part with part ID
    /// </summary>
    public Vector3 LeftNormal
    {
        get { return leftNormal; } 
        set 
        {  
                
            SetArgument("leftNormal", value);
            leftNormal = value;
        } 
    }

    private Vector3 leftCentre = new(0.00f,  0.50f,  -0.10f);
    /// <summary>
    /// centre of circle in the space of partID
    /// </summary>
    public Vector3 LeftCentre
    {
        get { return leftCentre; } 
        set 
        {  
                
            SetArgument("leftCentre", value);
            leftCentre = value;
        } 
    }

    private int rightPartID = 10;
    /// <summary>
    /// ID of part that the circle uses as local space for positioning
    /// </summary>
    public int RightPartID
    {
        get { return rightPartID; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 21);
            SetArgument("rightPartID", value);
            rightPartID = value;
        } 
    }

    private float rightRadius1 = 0.750f;
    /// <summary>
    /// radius for first axis of ellipse
    /// </summary>
    public float RightRadius1
    {
        get { return rightRadius1; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("rightRadius1", value);
            rightRadius1 = value;
        } 
    }

    private float rightRadius2 = 0.750f;
    /// <summary>
    /// radius for second axis of ellipse
    /// </summary>
    public float RightRadius2
    {
        get { return rightRadius2; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("rightRadius2", value);
            rightRadius2 = value;
        } 
    }

    private float rightSpeed = 1.00f;
    /// <summary>
    /// speed of target around the circle
    /// </summary>
    public float RightSpeed
    {
        get { return rightSpeed; } 
        set 
        {  
            value = MathHelper.Clamp(value, -2.00f, 2.00f);
            SetArgument("rightSpeed", value);
            rightSpeed = value;
        } 
    }

    private Vector3 rightNormal = new(0.00f,  -0.20f,  -0.20f);
    /// <summary>
    /// Euler Angles orientation of circle in space of part with part ID
    /// </summary>
    public Vector3 RightNormal
    {
        get { return rightNormal; } 
        set 
        {  
                
            SetArgument("rightNormal", value);
            rightNormal = value;
        } 
    }

    private Vector3 rightCentre = new(0.00f,  -0.50f,  -0.10f);
    /// <summary>
    /// centre of circle in the space of partID
    /// </summary>
    public Vector3 RightCentre
    {
        get { return rightCentre; } 
        set 
        {  
                
            SetArgument("rightCentre", value);
            rightCentre = value;
        } 
    }

    private float shoulderStiffness = 12.00f;
    /// <summary>
    /// Stiffness applied to the shoulders
    /// </summary>
    public float ShoulderStiffness
    {
        get { return shoulderStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 1.00f, 16.00f);
            SetArgument("shoulderStiffness", value);
            shoulderStiffness = value;
        } 
    }

    private float shoulderDamping = 1.00f;
    /// <summary>
    /// Damping applied to the shoulders
    /// </summary>
    public float ShoulderDamping
    {
        get { return shoulderDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("shoulderDamping", value);
            shoulderDamping = value;
        } 
    }

    private float elbowStiffness = 12.00f;
    /// <summary>
    /// Stiffness applied to the elbows
    /// </summary>
    public float ElbowStiffness
    {
        get { return elbowStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 1.00f, 16.00f);
            SetArgument("elbowStiffness", value);
            elbowStiffness = value;
        } 
    }

    private float elbowDamping = 1.00f;
    /// <summary>
    /// Damping applied to the elbows
    /// </summary>
    public float ElbowDamping
    {
        get { return elbowDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("elbowDamping", value);
            elbowDamping = value;
        } 
    }

    private float leftElbowMin = 0.50f;
    /// <summary>
    /// Minimum left elbow bend
    /// </summary>
    public float LeftElbowMin
    {
        get { return leftElbowMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.70f);
            SetArgument("leftElbowMin", value);
            leftElbowMin = value;
        } 
    }

    private float rightElbowMin = 0.50f;
    /// <summary>
    /// Minimum right elbow bend
    /// </summary>
    public float RightElbowMin
    {
        get { return rightElbowMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.70f);
            SetArgument("rightElbowMin", value);
            rightElbowMin = value;
        } 
    }

    private float phaseOffset = 0.00f;
    /// <summary>
    /// phase offset(degrees) when phase synchronization is turned on.
    /// </summary>
    public float PhaseOffset
    {
        get { return phaseOffset; } 
        set 
        {  
            value = MathHelper.Clamp(value, -360.00f, 360.00f);
            SetArgument("phaseOffset", value);
            phaseOffset = value;
        } 
    }

    private float dragReduction = 0.20f;
    /// <summary>
    /// how much to compensate for movement of character/target
    /// </summary>
    public float DragReduction
    {
        get { return dragReduction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("dragReduction", value);
            dragReduction = value;
        } 
    }

    private float iKtwist = 0.00f;
    /// <summary>
    /// angle of elbow around twist axis ?
    /// </summary>
    public float IKtwist
    {
        get { return IKtwist; } 
        set 
        {  
            value = MathHelper.Clamp(value, -3.141593f, 3.141593f);
            SetArgument("IKtwist", value);
            IKtwist = value;
        } 
    }

    private float angVelThreshold = 0.10f;
    /// <summary>
    /// value of character angular speed above which adaptive arm motion starts
    /// </summary>
    public float AngVelThreshold
    {
        get { return angVelThreshold; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("angVelThreshold", value);
            angVelThreshold = value;
        } 
    }

    private float angVelGain = 1.00f;
    /// <summary>
    /// multiplies angular speed of character to get speed of arms
    /// </summary>
    public float AngVelGain
    {
        get { return angVelGain; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("angVelGain", value);
            angVelGain = value;
        } 
    }

    private int mirrorMode = 1;
    /// <summary>
    /// 0: circle orientations are independent, 1: they mirror each other, 2: they're parallel (leftArm parmeters are used)
    /// </summary>
    public int MirrorMode
    {
        get { return mirrorMode; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("mirrorMode", value);
            mirrorMode = value;
        } 
    }

    private int adaptiveMode = 0;
    /// <summary>
    /// 0:not adaptive, 1:only direction, 2: dir and speed, 3: dir, speed and strength
    /// </summary>
    public int AdaptiveMode
    {
        get { return adaptiveMode; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 3);
            SetArgument("adaptiveMode", value);
            adaptiveMode = value;
        } 
    }

    private bool forceSync = true;
    /// <summary>
    /// toggles phase synchronization
    /// </summary>
    public bool ForceSync
    {
        get { return forceSync; } 
        set 
        {  
                
            SetArgument("forceSync", value);
            forceSync = value;
        } 
    }

    private bool useLeft = true;
    /// <summary>
    /// Use the left arm
    /// </summary>
    public bool UseLeft
    {
        get { return useLeft; } 
        set 
        {  
                
            SetArgument("useLeft", value);
            useLeft = value;
        } 
    }

    private bool useRight = true;
    /// <summary>
    /// Use the right arm
    /// </summary>
    public bool UseRight
    {
        get { return useRight; } 
        set 
        {  
                
            SetArgument("useRight", value);
            useRight = value;
        } 
    }

    private bool disableOnImpact = true;
    /// <summary>
    /// If true, each arm will stop windmilling if it hits the ground
    /// </summary>
    public bool DisableOnImpact
    {
        get { return disableOnImpact; } 
        set 
        {  
                
            SetArgument("disableOnImpact", value);
            disableOnImpact = value;
        } 
    }


    public EuphoriaMessageArmsWindmill(bool startNow) : base("armsWindmill", startNow)
    { }

    public new void Reset()
    {
        leftPartID = 10;
        leftRadius1 = 0.750f;
        leftRadius2 = 0.750f;
        leftSpeed = 1.00f;
        leftNormal = new Vector3(0.00f,  0.20f,  0.20f);
        leftCentre = new Vector3(0.00f,  0.50f,  -0.10f);
        rightPartID = 10;
        rightRadius1 = 0.750f;
        rightRadius2 = 0.750f;
        rightSpeed = 1.00f;
        rightNormal = new Vector3(0.00f,  -0.20f,  -0.20f);
        rightCentre = new Vector3(0.00f,  -0.50f,  -0.10f);
        shoulderStiffness = 12.00f;
        shoulderDamping = 1.00f;
        elbowStiffness = 12.00f;
        elbowDamping = 1.00f;
        leftElbowMin = 0.50f;
        rightElbowMin = 0.50f;
        phaseOffset = 0.00f;
        dragReduction = 0.20f;
        iKtwist = 0.00f;
        angVelThreshold = 0.10f;
        angVelGain = 1.00f;
        mirrorMode = 1;
        adaptiveMode = 0;
        forceSync = true;
        useLeft = true;
        useRight = true;
        disableOnImpact = true;
        base.Reset();
    }
}
}
