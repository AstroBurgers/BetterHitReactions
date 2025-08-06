namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageUpperBodyFlinch : EuphoriaMessage
{
    private float handDistanceLeftRight = 0.1f;
    /// <summary>
    /// Left-Right distance between the hands
    /// </summary>
    public float HandDistanceLeftRight
    {
        get { return handDistanceLeftRight; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("handDistanceLeftRight", value);
            handDistanceLeftRight = value;
        } 
    }

    private float handDistanceFrontBack = 0.06f;
    /// <summary>
    /// Front-Back distance between the hands
    /// </summary>
    public float HandDistanceFrontBack
    {
        get { return handDistanceFrontBack; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("handDistanceFrontBack", value);
            handDistanceFrontBack = value;
        } 
    }

    private float handDistanceVertical = 0.1f;
    /// <summary>
    /// Vertical distance between the hands
    /// </summary>
    public float HandDistanceVertical
    {
        get { return handDistanceVertical; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("handDistanceVertical", value);
            handDistanceVertical = value;
        } 
    }

    private float bodyStiffness = 11.0f;
    /// <summary>
    /// stiffness of body. Value carries over to head look, spine twist
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

    private float bodyDamping = 1.0f;
    /// <summary>
    /// damping value used for upper body
    /// </summary>
    public float BodyDamping
    {
        get { return bodyDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("bodyDamping", value);
            bodyDamping = value;
        } 
    }

    private float backBendAmount = -0.55f;
    /// <summary>
    /// Amount to bend the back during the flinch
    /// </summary>
    public float BackBendAmount
    {
        get { return backBendAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 1.0f);
            SetArgument("backBendAmount", value);
            backBendAmount = value;
        } 
    }

    private bool useRightArm = true;
    /// <summary>
    /// Toggle to use the right arm.
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

    private bool useLeftArm = true;
    /// <summary>
    /// Toggle to Use the Left arm
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

    private float noiseScale = 0.1f;
    /// <summary>
    /// Amplitude of the perlin noise applied to the arms positions in the flicnh to the front part of the behaviour.
    /// </summary>
    public float NoiseScale
    {
        get { return noiseScale; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("noiseScale", value);
            noiseScale = value;
        } 
    }

    private bool newHit = true;
    /// <summary>
    /// Relaxes the character for 1 frame if set.
    /// </summary>
    public bool NewHit
    {
        get { return newHit; } 
        set 
        {  
                
            SetArgument("newHit", value);
            newHit = value;
        } 
    }

    private bool protectHeadToggle = false;
    /// <summary>
    /// Always protect head. Note if false then character flinches if target is in front, protects head if target is behind
    /// </summary>
    public bool ProtectHeadToggle
    {
        get { return protectHeadToggle; } 
        set 
        {  
                
            SetArgument("protectHeadToggle", value);
            protectHeadToggle = value;
        } 
    }

    private bool dontBraceHead = false;
    /// <summary>
    /// don't protect head only brace from front. Turned on by bcr
    /// </summary>
    public bool DontBraceHead
    {
        get { return dontBraceHead; } 
        set 
        {  
                
            SetArgument("dontBraceHead", value);
            dontBraceHead = value;
        } 
    }

    private bool applyStiffness = true;
    /// <summary>
    /// Turned of by bcr
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

    private bool headLookAwayFromTarget = false;
    /// <summary>
    /// Look away from target (unless protecting head then look between feet)
    /// </summary>
    public bool HeadLookAwayFromTarget
    {
        get { return headLookAwayFromTarget; } 
        set 
        {  
                
            SetArgument("headLookAwayFromTarget", value);
            headLookAwayFromTarget = value;
        } 
    }

    private bool useHeadLook = true;
    /// <summary>
    /// Use headlook
    /// </summary>
    public bool UseHeadLook
    {
        get { return useHeadLook; } 
        set 
        {  
                
            SetArgument("useHeadLook", value);
            useHeadLook = value;
        } 
    }

    private int turnTowards = 1;
    /// <summary>
    /// ve balancer turn Towards, negative balancer turn Away, 0 balancer won't turn. NB.There is a 50% chance that the character will not turn even if this parameter is set to turn
    /// </summary>
    public int TurnTowards
    {
        get { return turnTowards; } 
        set 
        {  
            value = MathHelper.Clamp(value, -2, 2);
            SetArgument("turnTowards", value);
            turnTowards = value;
        } 
    }

    private Vector3 pos = new(0f,  0f,  0f);
    /// <summary>
    /// position in world-space of object to flinch from
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


    public EuphoriaMessageUpperBodyFlinch(bool startNow) : base("upperBodyFlinch", startNow)
    { }

    public new void Reset()
    {
        handDistanceLeftRight = 0.1f;
        handDistanceFrontBack = 0.06f;
        handDistanceVertical = 0.1f;
        bodyStiffness = 11.0f;
        bodyDamping = 1.0f;
        backBendAmount = -0.55f;
        useRightArm = true;
        useLeftArm = true;
        noiseScale = 0.1f;
        newHit = true;
        protectHeadToggle = false;
        dontBraceHead = false;
        applyStiffness = true;
        headLookAwayFromTarget = false;
        useHeadLook = true;
        turnTowards = 1;
        pos = new Vector3(0f,  0f,  0f);
        base.Reset();
    }
}
}
