using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageFallOverWall : EuphoriaMessage
{
    private float bodyStiffness = 9.000f;
    /// <summary>
    /// stiffness of the body, roll up stiffness scales with this and defaults at this default value
    /// </summary>
    public float BodyStiffness
    {
        get { return bodyStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.00f, 16.00f);
            SetArgument("bodyStiffness", value);
            bodyStiffness = value;
        } 
    }

    private float damping = 0.500f;
    /// <summary>
    /// Damping in the effectors
    /// </summary>
    public float Damping
    {
        get { return damping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 3.00f);
            SetArgument("damping", value);
            damping = value;
        } 
    }

    private float magOfForce = 0.50f;
    /// <summary>
    /// Magnitude of the falloverWall helper force
    /// </summary>
    public float MagOfForce
    {
        get { return magOfForce; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("magOfForce", value);
            magOfForce = value;
        } 
    }

    private float maxDistanceFromPelToHitPoint = 0.250f;
    /// <summary>
    /// The maximum distance away from the pelvis that hit points will be registered.
    /// </summary>
    public float MaxDistanceFromPelToHitPoint
    {
        get { return maxDistanceFromPelToHitPoint; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 1.00f);
            SetArgument("maxDistanceFromPelToHitPoint", value);
            maxDistanceFromPelToHitPoint = value;
        } 
    }

    private float maxForceDist = 0.80f;
    /// <summary>
    /// maximum distance between hitPoint and body part at which forces are applied to part
    /// </summary>
    public float MaxForceDist
    {
        get { return maxForceDist; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 2.00f);
            SetArgument("maxForceDist", value);
            maxForceDist = value;
        } 
    }

    private float stepExclusionZone = 0.50f;
    /// <summary>
    /// Specifies extent of area in front of the wall in which balancer won't try to take another step
    /// </summary>
    public float StepExclusionZone
    {
        get { return stepExclusionZone; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 2.00f);
            SetArgument("stepExclusionZone", value);
            stepExclusionZone = value;
        } 
    }

    private float minLegHeight = 0.40f;
    /// <summary>
    /// minimum height of pelvis above feet at which fallOverWall is attempted
    /// </summary>
    public float MinLegHeight
    {
        get { return minLegHeight; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 2.00f);
            SetArgument("minLegHeight", value);
            minLegHeight = value;
        } 
    }

    private float bodyTwist = 0.540f;
    /// <summary>
    /// amount of twist to apply to the spine as the character tries to fling himself over the wall, provides more of a believable roll but increases the amount of lateral space the character needs to successfully flip.
    /// </summary>
    public float BodyTwist
    {
        get { return bodyTwist; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("bodyTwist", value);
            bodyTwist = value;
        } 
    }

    private float maxTwist = 3.141593f;
    /// <summary>
    /// max angle the character can twist before twsit helper torques are turned off
    /// </summary>
    public float MaxTwist
    {
        get { return maxTwist; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("maxTwist", value);
            maxTwist = value;
        } 
    }

    private Vector3 fallOverWallEndA = new(0f,  0f,  0f);
    /// <summary>
    /// One end of the wall to try to fall over.
    /// </summary>
    public Vector3 FallOverWallEndA
    {
        get { return fallOverWallEndA; } 
        set 
        {  
                
            SetArgument("fallOverWallEndA", value);
            fallOverWallEndA = value;
        } 
    }

    private Vector3 fallOverWallEndB = new(0f,  0f,  0f);
    /// <summary>
    /// One end of the wall over which we are trying to fall over.
    /// </summary>
    public Vector3 FallOverWallEndB
    {
        get { return fallOverWallEndB; } 
        set 
        {  
                
            SetArgument("fallOverWallEndB", value);
            fallOverWallEndB = value;
        } 
    }

    private float forceAngleAbort = -0.20f;
    /// <summary>
    /// The angle abort threshold.
    /// </summary>
    public float ForceAngleAbort
    {
        get { return forceAngleAbort; } 
        set 
        {  
                
            SetArgument("forceAngleAbort", value);
            forceAngleAbort = value;
        } 
    }

    private float forceTimeOut = 2.00f;
    /// <summary>
    /// The force time out.
    /// </summary>
    public float ForceTimeOut
    {
        get { return forceTimeOut; } 
        set 
        {  
                
            SetArgument("forceTimeOut", value);
            forceTimeOut = value;
        } 
    }

    private bool moveArms = true;
    /// <summary>
    /// Lift the arms up if true.  Do nothing with the arms if false (eg when using catchfall arms or brace etc)
    /// </summary>
    public bool MoveArms
    {
        get { return moveArms; } 
        set 
        {  
                
            SetArgument("moveArms", value);
            moveArms = value;
        } 
    }

    private bool moveLegs = true;
    /// <summary>
    /// Move the legs if true.  Do nothing with the legs if false (eg when using dynamicBalancer etc)
    /// </summary>
    public bool MoveLegs
    {
        get { return moveLegs; } 
        set 
        {  
                
            SetArgument("moveLegs", value);
            moveLegs = value;
        } 
    }

    private bool bendSpine = true;
    /// <summary>
    /// Bend spine to help falloverwall if true.  Do nothing with the spine if false.
    /// </summary>
    public bool BendSpine
    {
        get { return bendSpine; } 
        set 
        {  
                
            SetArgument("bendSpine", value);
            bendSpine = value;
        } 
    }

    private float angleDirWithWallNormal = 180.00f;
    /// <summary>
    /// Maximum angle in degrees (between the direction of the velocity of the COM and the wall normal) to start to apply forces and torques to fall over the wall.
    /// </summary>
    public float AngleDirWithWallNormal
    {
        get { return angleDirWithWallNormal; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 180.00f);
            SetArgument("angleDirWithWallNormal", value);
            angleDirWithWallNormal = value;
        } 
    }

    private float leaningAngleThreshold = 180.00f;
    /// <summary>
    /// Maximum angle in degrees (between the vertical vector and a vector from pelvis to lower neck) to start to apply forces and torques to fall over the wall.
    /// </summary>
    public float LeaningAngleThreshold
    {
        get { return leaningAngleThreshold; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 180.00f);
            SetArgument("leaningAngleThreshold", value);
            leaningAngleThreshold = value;
        } 
    }

    private float maxAngVel = 2.00f;
    /// <summary>
    /// if the angular velocity is higher than maxAngVel, the torques and forces are not applied.
    /// </summary>
    public float MaxAngVel
    {
        get { return maxAngVel; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 30.00f);
            SetArgument("maxAngVel", value);
            maxAngVel = value;
        } 
    }

    private bool adaptForcesToLowWall = false;
    /// <summary>
    /// Will reduce the magnitude of the forces applied to the character to help him to fall over wall
    /// </summary>
    public bool AdaptForcesToLowWall
    {
        get { return adaptForcesToLowWall; } 
        set 
        {  
                
            SetArgument("adaptForcesToLowWall", value);
            adaptForcesToLowWall = value;
        } 
    }

    private float maxWallHeight = -1.00f;
    /// <summary>
    /// Maximum height (from the lowest foot) to start to apply forces and torques to fall over the wall.
    /// </summary>
    public float MaxWallHeight
    {
        get { return maxWallHeight; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 3.00f);
            SetArgument("maxWallHeight", value);
            maxWallHeight = value;
        } 
    }

    private float distanceToSendSuccessMessage = -1.00f;
    /// <summary>
    /// Minimum distance between the pelvis and the wall to send the success message. If negative doesn't take this parameter into account when sending feedback.
    /// </summary>
    public float DistanceToSendSuccessMessage
    {
        get { return distanceToSendSuccessMessage; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 3.00f);
            SetArgument("distanceToSendSuccessMessage", value);
            distanceToSendSuccessMessage = value;
        } 
    }

    private float rollingBackThr = 0.50f;
    /// <summary>
    /// Value of the angular velocity about the wallEgde above which the character is considered as rolling backwards i.e. goes in to fow_RollingBack state
    /// </summary>
    public float RollingBackThr
    {
        get { return rollingBackThr; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("rollingBackThr", value);
            rollingBackThr = value;
        } 
    }

    private float rollingPotential = 0.30f;
    /// <summary>
    /// On impact with the wall if the rollingPotential(calculated from the characters linear velocity w.r.t the wall) is greater than this value the character will try to go over the wall otherwise it won't try (fow_Aborted).
    /// </summary>
    public float RollingPotential
    {
        get { return rollingPotential; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 10.00f);
            SetArgument("rollingPotential", value);
            rollingPotential = value;
        } 
    }

    private bool useArmIK = false;
    /// <summary>
    /// Try to reach the wallEdge. To configure the IK : use limitAngleBack, limitAngleFront and limitAngleTotallyBack.
    /// </summary>
    public bool UseArmIK
    {
        get { return useArmIK; } 
        set 
        {  
                
            SetArgument("useArmIK", value);
            useArmIK = value;
        } 
    }

    private float reachDistanceFromHitPoint = 0.30f;
    /// <summary>
    /// distance from predicted hitpoint where each hands will try to reach the wall.
    /// </summary>
    public float ReachDistanceFromHitPoint
    {
        get { return reachDistanceFromHitPoint; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("reachDistanceFromHitPoint", value);
            reachDistanceFromHitPoint = value;
        } 
    }

    private float minReachDistanceFromHitPoint = 0.10f;
    /// <summary>
    /// minimal distance from predicted hitpoint where each hands will try to reach the wall. Used if the hand target is outside the wall Edge.
    /// </summary>
    public float MinReachDistanceFromHitPoint
    {
        get { return minReachDistanceFromHitPoint; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("minReachDistanceFromHitPoint", value);
            minReachDistanceFromHitPoint = value;
        } 
    }

    private float angleTotallyBack = 15.00f;
    /// <summary>
    /// max angle in degrees (between 1.the vector between two hips and 2. wallEdge) to try to reach the wall just behind his pelvis with his arms when the character is back to the wall.
    /// </summary>
    public float AngleTotallyBack
    {
        get { return angleTotallyBack; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 180.00f);
            SetArgument("angleTotallyBack", value);
            angleTotallyBack = value;
        } 
    }


    public EuphoriaMessageFallOverWall(bool startNow) : base("fallOverWall", startNow)
    { }

    public new void Reset()
    {
        bodyStiffness = 9.000f;
        damping = 0.500f;
        magOfForce = 0.50f;
        maxDistanceFromPelToHitPoint = 0.250f;
        maxForceDist = 0.80f;
        stepExclusionZone = 0.50f;
        minLegHeight = 0.40f;
        bodyTwist = 0.540f;
        maxTwist = 3.141593f;
        fallOverWallEndA = new Vector3(0f,  0f,  0f);
        fallOverWallEndB = new Vector3(0f,  0f,  0f);
        forceAngleAbort = -0.20f;
        forceTimeOut = 2.00f;
        moveArms = true;
        moveLegs = true;
        bendSpine = true;
        angleDirWithWallNormal = 180.00f;
        leaningAngleThreshold = 180.00f;
        maxAngVel = 2.00f;
        adaptForcesToLowWall = false;
        maxWallHeight = -1.00f;
        distanceToSendSuccessMessage = -1.00f;
        rollingBackThr = 0.50f;
        rollingPotential = 0.30f;
        useArmIK = false;
        reachDistanceFromHitPoint = 0.30f;
        minReachDistanceFromHitPoint = 0.10f;
        angleTotallyBack = 15.00f;
        base.Reset();
    }
}
}
