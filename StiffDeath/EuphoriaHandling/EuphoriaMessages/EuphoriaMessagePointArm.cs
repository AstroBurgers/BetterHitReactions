namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// pointArm:BEHAVIOURS REFERENCED: AnimPose - allows animPose to overridebodyParts: Arms (useLeftArm, useRightArm)
/// </summary>

internal class EuphoriaMessagePointArm : EuphoriaMessage
{
    private Vector3 targetLeft = new(0f,  0f,  0f);
    /// <summary>
    /// point to point to (in world space)
    /// </summary>
    public Vector3 TargetLeft
    {
        get { return targetLeft; } 
        set 
        {  
                
            SetArgument("targetLeft", value);
            targetLeft = value;
        } 
    }

    private float twistLeft = 0.3f;
    /// <summary>
    /// twist of the arm around point direction
    /// </summary>
    public float TwistLeft
    {
        get { return twistLeft; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 1.0f);
            SetArgument("twistLeft", value);
            twistLeft = value;
        } 
    }

    private float armStraightnessLeft = 0.8f;
    /// <summary>
    /// values less than 1 can give the arm a more bent look
    /// </summary>
    public float ArmStraightnessLeft
    {
        get { return armStraightnessLeft; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("armStraightnessLeft", value);
            armStraightnessLeft = value;
        } 
    }

    private bool useLeftArm = false;
    /// <summary>
    /// 
    /// </summary>
    public bool UseLeftArm
    {
        get { return useLeftArm; } 
        set 
        {  
                
            SetArgument("useLeftArm", value);
            useLeftArm = value;
        } 
    }

    private float armStiffnessLeft = 15.0f;
    /// <summary>
    /// stiffness of arm
    /// </summary>
    public float ArmStiffnessLeft
    {
        get { return armStiffnessLeft; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("armStiffnessLeft", value);
            armStiffnessLeft = value;
        } 
    }

    private float armDampingLeft = 1.0f;
    /// <summary>
    /// damping value for arm used to point
    /// </summary>
    public float ArmDampingLeft
    {
        get { return armDampingLeft; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("armDampingLeft", value);
            armDampingLeft = value;
        } 
    }

    private int instanceIndexLeft = -1;
    /// <summary>
    /// level index of thing to point at, or -1 for none. if -1, target is specified in world space, otherwise it is an offset from the object specified by this index.
    /// </summary>
    public int InstanceIndexLeft
    {
        get { return instanceIndexLeft; } 
        set 
        {  
                
            SetArgument("instanceIndexLeft", value);
            instanceIndexLeft = value;
        } 
    }

    private float pointSwingLimitLeft = 1.5f;
    /// <summary>
    /// Swing limit
    /// </summary>
    public float PointSwingLimitLeft
    {
        get { return pointSwingLimitLeft; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("pointSwingLimitLeft", value);
            pointSwingLimitLeft = value;
        } 
    }

    private bool useZeroPoseWhenNotPointingLeft = false;
    /// <summary>
    /// 
    /// </summary>
    public bool UseZeroPoseWhenNotPointingLeft
    {
        get { return useZeroPoseWhenNotPointingLeft; } 
        set 
        {  
                
            SetArgument("useZeroPoseWhenNotPointingLeft", value);
            useZeroPoseWhenNotPointingLeft = value;
        } 
    }

    private Vector3 targetRight = new(0f,  0f,  0f);
    /// <summary>
    /// point to point to (in world space)
    /// </summary>
    public Vector3 TargetRight
    {
        get { return targetRight; } 
        set 
        {  
                
            SetArgument("targetRight", value);
            targetRight = value;
        } 
    }

    private float twistRight = 0.3f;
    /// <summary>
    /// twist of the arm around point direction
    /// </summary>
    public float TwistRight
    {
        get { return twistRight; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 1.0f);
            SetArgument("twistRight", value);
            twistRight = value;
        } 
    }

    private float armStraightnessRight = 0.8f;
    /// <summary>
    /// values less than 1 can give the arm a more bent look
    /// </summary>
    public float ArmStraightnessRight
    {
        get { return armStraightnessRight; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("armStraightnessRight", value);
            armStraightnessRight = value;
        } 
    }

    private bool useRightArm = false;
    /// <summary>
    /// 
    /// </summary>
    public bool UseRightArm
    {
        get { return useRightArm; } 
        set 
        {  
                
            SetArgument("useRightArm", value);
            useRightArm = value;
        } 
    }

    private float armStiffnessRight = 15.0f;
    /// <summary>
    /// stiffness of arm
    /// </summary>
    public float ArmStiffnessRight
    {
        get { return armStiffnessRight; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("armStiffnessRight", value);
            armStiffnessRight = value;
        } 
    }

    private float armDampingRight = 1.0f;
    /// <summary>
    /// damping value for arm used to point
    /// </summary>
    public float ArmDampingRight
    {
        get { return armDampingRight; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("armDampingRight", value);
            armDampingRight = value;
        } 
    }

    private int instanceIndexRight = -1;
    /// <summary>
    /// level index of thing to point at, or -1 for none. if -1, target is specified in world space, otherwise it is an offset from the object specified by this index.
    /// </summary>
    public int InstanceIndexRight
    {
        get { return instanceIndexRight; } 
        set 
        {  
                
            SetArgument("instanceIndexRight", value);
            instanceIndexRight = value;
        } 
    }

    private float pointSwingLimitRight = 1.5f;
    /// <summary>
    /// Swing limit
    /// </summary>
    public float PointSwingLimitRight
    {
        get { return pointSwingLimitRight; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("pointSwingLimitRight", value);
            pointSwingLimitRight = value;
        } 
    }

    private bool useZeroPoseWhenNotPointingRight = false;
    /// <summary>
    /// 
    /// </summary>
    public bool UseZeroPoseWhenNotPointingRight
    {
        get { return useZeroPoseWhenNotPointingRight; } 
        set 
        {  
                
            SetArgument("useZeroPoseWhenNotPointingRight", value);
            useZeroPoseWhenNotPointingRight = value;
        } 
    }


    public EuphoriaMessagePointArm(bool startNow) : base("pointArm", startNow)
    { }

    public new void Reset()
    {
        targetLeft = new Vector3(0f,  0f,  0f);
        twistLeft = 0.3f;
        armStraightnessLeft = 0.8f;
        useLeftArm = false;
        armStiffnessLeft = 15.0f;
        armDampingLeft = 1.0f;
        instanceIndexLeft = -1;
        pointSwingLimitLeft = 1.5f;
        useZeroPoseWhenNotPointingLeft = false;
        targetRight = new Vector3(0f,  0f,  0f);
        twistRight = 0.3f;
        armStraightnessRight = 0.8f;
        useRightArm = false;
        armStiffnessRight = 15.0f;
        armDampingRight = 1.0f;
        instanceIndexRight = -1;
        pointSwingLimitRight = 1.5f;
        useZeroPoseWhenNotPointingRight = false;
        base.Reset();
    }
}
}
