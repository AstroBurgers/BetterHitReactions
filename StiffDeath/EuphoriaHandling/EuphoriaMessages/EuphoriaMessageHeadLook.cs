namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageHeadLook : EuphoriaMessage
{
    private float damping = 1.000f;
    /// <summary>
    /// Damping  of the muscles
    /// </summary>
    public float Damping
    {
        get { return damping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("damping", value);
            damping = value;
        } 
    }

    private float stiffness = 10.000f;
    /// <summary>
    /// Stiffness of the muscles
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

    private int instanceIndex = -1;
    /// <summary>
    /// levelIndex of object to be looked at. vel parameters are ignored if this is non -1
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

    private Vector3 vel = new(0f,  0f,  0f);
    /// <summary>
    /// The velocity of the point being looked at
    /// </summary>
    public Vector3 Vel
    {
        get { return vel; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, -100.0f, 100.0f);
            value.Y = MathHelper.Clamp(value.Y, -100.0f, 100.0f);
            value.Z = MathHelper.Clamp(value.Z, -100.0f, 100.0f);
            SetArgument("vel", value);
            vel = value;
        } 
    }

    private Vector3 pos = new(0f,  0f,  0f);
    /// <summary>
    /// The point being looked at
    /// </summary>
    public Vector3 Pos
    {
        get { return pos; } 
        set 
        {  
                
            SetArgument("pos", value);
            pos = value;
        } 
    }

    private bool alwaysLook = false;
    /// <summary>
    /// Flag to force always to look
    /// </summary>
    public bool AlwaysLook
    {
        get { return alwaysLook; } 
        set 
        {  
                
            SetArgument("alwaysLook", value);
            alwaysLook = value;
        } 
    }

    private bool eyesHorizontal = true;
    /// <summary>
    /// Keep the eyes horizontal.  Use true for impact with cars.  Use false if you want better look at target accuracy when the character is on the floor or leaned over alot.
    /// </summary>
    public bool EyesHorizontal
    {
        get { return eyesHorizontal; } 
        set 
        {  
                
            SetArgument("eyesHorizontal", value);
            eyesHorizontal = value;
        } 
    }

    private bool alwaysEyesHorizontal = true;
    /// <summary>
    /// Keep the eyes horizontal.  Use true for impact with cars.  Use false if you want better look at target accuracy when the character is on the floor or leaned over (when not leaned over the eyes are still kept horizontal if eyesHorizontal=true ) alot.
    /// </summary>
    public bool AlwaysEyesHorizontal
    {
        get { return alwaysEyesHorizontal; } 
        set 
        {  
                
            SetArgument("alwaysEyesHorizontal", value);
            alwaysEyesHorizontal = value;
        } 
    }

    private bool keepHeadAwayFromGround = false;
    /// <summary>
    /// 
    /// </summary>
    public bool KeepHeadAwayFromGround
    {
        get { return keepHeadAwayFromGround; } 
        set 
        {  
                
            SetArgument("keepHeadAwayFromGround", value);
            keepHeadAwayFromGround = value;
        } 
    }

    private bool twistSpine = true;
    /// <summary>
    /// Allow headlook to twist spine.
    /// </summary>
    public bool TwistSpine
    {
        get { return twistSpine; } 
        set 
        {  
                
            SetArgument("twistSpine", value);
            twistSpine = value;
        } 
    }


    public EuphoriaMessageHeadLook(bool startNow) : base("headLook", startNow)
    { }

    public new void Reset()
    {
        damping = 1.000f;
        stiffness = 10.000f;
        instanceIndex = -1;
        vel = new Vector3(0f,  0f,  0f);
        pos = new Vector3(0f,  0f,  0f);
        alwaysLook = false;
        eyesHorizontal = true;
        alwaysEyesHorizontal = true;
        keepHeadAwayFromGround = false;
        twistSpine = true;
        base.Reset();
    }
}
}
