using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageGrab : EuphoriaMessage
{
    private bool useLeft = false;
    /// <summary>
    /// Flag to toggle use of left hand
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

    private bool useRight = false;
    /// <summary>
    /// Flag to toggle the use of the Right hand
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

    private bool dropWeaponIfNecessary = false;
    /// <summary>
    /// if hasn't grabbed when weapon carrying hand is close to target, grab anyway
    /// </summary>
    public bool DropWeaponIfNecessary
    {
        get { return dropWeaponIfNecessary; } 
        set 
        {  
                
            SetArgument("dropWeaponIfNecessary", value);
            dropWeaponIfNecessary = value;
        } 
    }

    private float dropWeaponDistance = 0.30f;
    /// <summary>
    /// distance below which a weapon carrying hand will request weapon to be dropped
    /// </summary>
    public float DropWeaponDistance
    {
        get { return dropWeaponDistance; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("dropWeaponDistance", value);
            dropWeaponDistance = value;
        } 
    }

    private float grabStrength = -1.0f;
    /// <summary>
    /// strength in hands for grabbing (kg m/s), -1 to ignore/disable
    /// </summary>
    public float GrabStrength
    {
        get { return grabStrength; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 10000.0f);
            SetArgument("grabStrength", value);
            grabStrength = value;
        } 
    }

    private float stickyHands = 4.0f;
    /// <summary>
    /// strength of cheat force on hands to pull towards target and stick to target ("cleverHandIK" strength)
    /// </summary>
    public float StickyHands
    {
        get { return stickyHands; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("stickyHands", value);
            stickyHands = value;
        } 
    }

    private int turnToTarget = 1;
    /// <summary>
    /// 0=don't turn, 1=turnToTarget, 2=turnAwayFromTarget
    /// </summary>
    public int TurnToTarget
    {
        get { return turnToTarget; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("turnToTarget", value);
            turnToTarget = value;
        } 
    }

    private float grabHoldMaxTimer = 100.0f;
    /// <summary>
    /// amount of time, in seconds, before grab automatically bails
    /// </summary>
    public float GrabHoldMaxTimer
    {
        get { return grabHoldMaxTimer; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1000.0f);
            SetArgument("grabHoldMaxTimer", value);
            grabHoldMaxTimer = value;
        } 
    }

    private float pullUpTime = 1.0f;
    /// <summary>
    /// Time to reach the full pullup strength
    /// </summary>
    public float PullUpTime
    {
        get { return pullUpTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 4.0f);
            SetArgument("pullUpTime", value);
            pullUpTime = value;
        } 
    }

    private float pullUpStrengthRight = 0.0f;
    /// <summary>
    /// Strength to pull up with the right arm. 0 = no pull up.
    /// </summary>
    public float PullUpStrengthRight
    {
        get { return pullUpStrengthRight; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("pullUpStrengthRight", value);
            pullUpStrengthRight = value;
        } 
    }

    private float pullUpStrengthLeft = 0.0f;
    /// <summary>
    /// Strength to pull up with the left arm. 0 = no pull up.
    /// </summary>
    public float PullUpStrengthLeft
    {
        get { return pullUpStrengthLeft; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("pullUpStrengthLeft", value);
            pullUpStrengthLeft = value;
        } 
    }

    private Vector3 pos1 = new(0f,  0f,  0f);
    /// <summary>
    /// Grab pos1, right hand if not using line or surface grab.
    /// </summary>
    public Vector3 Pos1
    {
        get { return pos1; } 
        set 
        {  
                
            SetArgument("pos1", value);
            pos1 = value;
        } 
    }

    private Vector3 pos2 = new(0f,  0f,  0f);
    /// <summary>
    /// Grab pos2, left hand if not using line or surface grab.
    /// </summary>
    public Vector3 Pos2
    {
        get { return pos2; } 
        set 
        {  
                
            SetArgument("pos2", value);
            pos2 = value;
        } 
    }

    private Vector3 pos3 = new(0f,  0f,  0f);
    /// <summary>
    /// 
    /// </summary>
    public Vector3 Pos3
    {
        get { return pos3; } 
        set 
        {  
                
            SetArgument("pos3", value);
            pos3 = value;
        } 
    }

    private Vector3 pos4 = new(0f,  0f,  0f);
    /// <summary>
    /// 
    /// </summary>
    public Vector3 Pos4
    {
        get { return pos4; } 
        set 
        {  
                
            SetArgument("pos4", value);
            pos4 = value;
        } 
    }

    private Vector3 normalR = new(0f,  0f,  0f);
    /// <summary>
    /// Normal for the right grab point.
    /// </summary>
    public Vector3 NormalR
    {
        get { return normalR; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, -1.0f, 1.0f);
            value.Y = MathHelper.Clamp(value.Y, -1.0f, 1.0f);
            value.Z = MathHelper.Clamp(value.Z, -1.0f, 1.0f);
            SetArgument("normalR", value);
            normalR = value;
        } 
    }

    private Vector3 normalL = new(0f,  0f,  0f);
    /// <summary>
    /// Normal for the left grab point.
    /// </summary>
    public Vector3 NormalL
    {
        get { return normalL; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, -1.0f, 1.0f);
            value.Y = MathHelper.Clamp(value.Y, -1.0f, 1.0f);
            value.Z = MathHelper.Clamp(value.Z, -1.0f, 1.0f);
            SetArgument("normalL", value);
            normalL = value;
        } 
    }

    private Vector3 normalR2 = new(0f,  0f,  0f);
    /// <summary>
    /// Normal for the 2nd right grab point (if pointsX4grab=true).
    /// </summary>
    public Vector3 NormalR2
    {
        get { return normalR2; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, -1.0f, 1.0f);
            value.Y = MathHelper.Clamp(value.Y, -1.0f, 1.0f);
            value.Z = MathHelper.Clamp(value.Z, -1.0f, 1.0f);
            SetArgument("normalR2", value);
            normalR2 = value;
        } 
    }

    private Vector3 normalL2 = new(0f,  0f,  0f);
    /// <summary>
    /// Normal for the 3rd left grab point (if pointsX4grab=true).
    /// </summary>
    public Vector3 NormalL2
    {
        get { return normalL2; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, -1.0f, 1.0f);
            value.Y = MathHelper.Clamp(value.Y, -1.0f, 1.0f);
            value.Z = MathHelper.Clamp(value.Z, -1.0f, 1.0f);
            SetArgument("normalL2", value);
            normalL2 = value;
        } 
    }

    private bool handsCollide = false;
    /// <summary>
    /// Hand collisions on when grabbing (false turns off hand collisions making grab more stable esp. to grab points slightly inside geometry)
    /// </summary>
    public bool HandsCollide
    {
        get { return handsCollide; } 
        set 
        {  
                
            SetArgument("handsCollide", value);
            handsCollide = value;
        } 
    }

    private bool justBrace = false;
    /// <summary>
    /// Flag to toggle between grabbing and bracing
    /// </summary>
    public bool JustBrace
    {
        get { return justBrace; } 
        set 
        {  
                
            SetArgument("justBrace", value);
            justBrace = value;
        } 
    }

    private bool useLineGrab = false;
    /// <summary>
    /// use the line grab, Grab along the line (x-x2)
    /// </summary>
    public bool UseLineGrab
    {
        get { return useLineGrab; } 
        set 
        {  
                
            SetArgument("useLineGrab", value);
            useLineGrab = value;
        } 
    }

    private bool pointsX4grab = false;
    /// <summary>
    /// use 2 point
    /// </summary>
    public bool PointsX4grab
    {
        get { return pointsX4grab; } 
        set 
        {  
                
            SetArgument("pointsX4grab", value);
            pointsX4grab = value;
        } 
    }

    private bool fromEA = false;
    /// <summary>
    /// use 2 point
    /// </summary>
    public bool FromEA
    {
        get { return fromEA; } 
        set 
        {  
                
            SetArgument("fromEA", value);
            fromEA = value;
        } 
    }

    private bool surfaceGrab = false;
    /// <summary>
    /// Toggle surface grab on. Requires pos1,pos2,pos3 and pos4 to be specified.
    /// </summary>
    public bool SurfaceGrab
    {
        get { return surfaceGrab; } 
        set 
        {  
                
            SetArgument("surfaceGrab", value);
            surfaceGrab = value;
        } 
    }

    private int instanceIndex = -1;
    /// <summary>
    /// levelIndex of instance to grab (-1 = world coordinates)
    /// </summary>
    public int InstanceIndex
    {
        get { return instanceIndex; } 
        set 
        {  
                
            SetArgument("instanceIndex", value);
            instanceIndex = value;
        } 
    }

    private int instancePartIndex = 0;
    /// <summary>
    /// boundIndex of part on instance to grab (0 = just use instance coordinates)
    /// </summary>
    public int InstancePartIndex
    {
        get { return instancePartIndex; } 
        set 
        {  
                
            SetArgument("instancePartIndex", value);
            instancePartIndex = value;
        } 
    }

    private bool dontLetGo = false;
    /// <summary>
    /// Once a constraint is made, keep reaching with whatever hand is allowed - no matter what the angle/distance and whether or not the constraint has broken due to constraintForce  GT  grabStrength.  mmmtodo this is a badly named parameter
    /// </summary>
    public bool DontLetGo
    {
        get { return dontLetGo; } 
        set 
        {  
                
            SetArgument("dontLetGo", value);
            dontLetGo = value;
        } 
    }

    private float bodyStiffness = 11.0f;
    /// <summary>
    /// stiffness of upper body. Scales the arm grab such that the armStiffness is default when this is at default value
    /// </summary>
    public float BodyStiffness
    {
        get { return bodyStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("bodyStiffness", value);
            bodyStiffness = value;
        } 
    }

    private float reachAngle = 2.80f;
    /// <summary>
    /// Angle from front at which the grab activates. If the point is outside this angle from front will not try to grab.
    /// </summary>
    public float ReachAngle
    {
        get { return reachAngle; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("reachAngle", value);
            reachAngle = value;
        } 
    }

    private float oneSideReachAngle = 1.4f;
    /// <summary>
    /// Angle at which we will only reach with one hand.
    /// </summary>
    public float OneSideReachAngle
    {
        get { return oneSideReachAngle; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("oneSideReachAngle", value);
            oneSideReachAngle = value;
        } 
    }

    private float grabDistance = 1.0f;
    /// <summary>
    /// Relative distance at which the grab starts.
    /// </summary>
    public float GrabDistance
    {
        get { return grabDistance; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 4.0f);
            SetArgument("grabDistance", value);
            grabDistance = value;
        } 
    }

    private float move2Radius = 0.0f;
    /// <summary>
    /// Relative distance (additional to grabDistance - doesn't try to move inside grabDistance)at which the grab tries to use the balancer to move to the grab point.
    /// </summary>
    public float Move2Radius
    {
        get { return move2Radius; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 14.0f);
            SetArgument("move2Radius", value);
            move2Radius = value;
        } 
    }

    private float armStiffness = 14.0f;
    /// <summary>
    /// Stiffness of the arm.
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

    private float maxReachDistance = 0.7f;
    /// <summary>
    /// distance to reach out towards the grab point.
    /// </summary>
    public float MaxReachDistance
    {
        get { return maxReachDistance; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 4.0f);
            SetArgument("maxReachDistance", value);
            maxReachDistance = value;
        } 
    }

    private float orientationConstraintScale = 1.0f;
    /// <summary>
    /// scale torque used to rotate hands to face normals
    /// </summary>
    public float OrientationConstraintScale
    {
        get { return orientationConstraintScale; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 4.0f);
            SetArgument("orientationConstraintScale", value);
            orientationConstraintScale = value;
        } 
    }

    private float maxWristAngle = 3.141593f;
    /// <summary>
    /// When we are grabbing the max angle the wrist ccan be at before we break the grab.
    /// </summary>
    public float MaxWristAngle
    {
        get { return maxWristAngle; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.151593f);
            SetArgument("maxWristAngle", value);
            maxWristAngle = value;
        } 
    }

    private bool useHeadLookToTarget = false;
    /// <summary>
    /// if true, the character will look at targetForHeadLook after a hand grabs until the end of the behavior. (Before grabbing it looks at the grab target)
    /// </summary>
    public bool UseHeadLookToTarget
    {
        get { return useHeadLookToTarget; } 
        set 
        {  
                
            SetArgument("useHeadLookToTarget", value);
            useHeadLookToTarget = value;
        } 
    }

    private bool lookAtGrab = true;
    /// <summary>
    /// if true, the character will look at the grab
    /// </summary>
    public bool LookAtGrab
    {
        get { return lookAtGrab; } 
        set 
        {  
                
            SetArgument("lookAtGrab", value);
            lookAtGrab = value;
        } 
    }

    private Vector3 targetForHeadLook = new(0f,  0f,  0f);
    /// <summary>
    /// Only used if useHeadLookToTarget is true, the target in world space to look at.
    /// </summary>
    public Vector3 TargetForHeadLook
    {
        get { return targetForHeadLook; } 
        set 
        {  
                
            SetArgument("targetForHeadLook", value);
            targetForHeadLook = value;
        } 
    }


    public EuphoriaMessageGrab(bool startNow) : base("grab", startNow)
    { }

    public new void Reset()
    {
        useLeft = false;
        useRight = false;
        dropWeaponIfNecessary = false;
        dropWeaponDistance = 0.30f;
        grabStrength = -1.0f;
        stickyHands = 4.0f;
        turnToTarget = 1;
        grabHoldMaxTimer = 100.0f;
        pullUpTime = 1.0f;
        pullUpStrengthRight = 0.0f;
        pullUpStrengthLeft = 0.0f;
        pos1 = new Vector3(0f,  0f,  0f);
        pos2 = new Vector3(0f,  0f,  0f);
        pos3 = new Vector3(0f,  0f,  0f);
        pos4 = new Vector3(0f,  0f,  0f);
        normalR = new Vector3(0f,  0f,  0f);
        normalL = new Vector3(0f,  0f,  0f);
        normalR2 = new Vector3(0f,  0f,  0f);
        normalL2 = new Vector3(0f,  0f,  0f);
        handsCollide = false;
        justBrace = false;
        useLineGrab = false;
        pointsX4grab = false;
        fromEA = false;
        surfaceGrab = false;
        instanceIndex = -1;
        instancePartIndex = 0;
        dontLetGo = false;
        bodyStiffness = 11.0f;
        reachAngle = 2.80f;
        oneSideReachAngle = 1.4f;
        grabDistance = 1.0f;
        move2Radius = 0.0f;
        armStiffness = 14.0f;
        maxReachDistance = 0.7f;
        orientationConstraintScale = 1.0f;
        maxWristAngle = 3.141593f;
        useHeadLookToTarget = false;
        lookAtGrab = true;
        targetForHeadLook = new Vector3(0f,  0f,  0f);
        base.Reset();
    }
}
}
