namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageShotHeadLook : EuphoriaMessage
{
    private bool useHeadLook = false;
    /// <summary>
    /// Use headLook.  Default: looks at provided target or if this is zero -  looks forward or in velocity direction. If reachForWound is enabled, switches between looking at the wound and at the default target.
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

    private Vector3 headLook = new(0f,  0f,  0f);
    /// <summary>
    /// position to look at with headlook flag
    /// </summary>
    public Vector3 HeadLook
    {
        get { return headLook; } 
        set 
        {  
                
            SetArgument("headLook", value);
            headLook = value;
        } 
    }

    private float headLookAtWoundMinTimer = 0.250f;
    /// <summary>
    /// Min time to look at wound
    /// </summary>
    public float HeadLookAtWoundMinTimer
    {
        get { return headLookAtWoundMinTimer; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("headLookAtWoundMinTimer", value);
            headLookAtWoundMinTimer = value;
        } 
    }

    private float headLookAtWoundMaxTimer = 0.80f;
    /// <summary>
    /// Max time to look at wound
    /// </summary>
    public float HeadLookAtWoundMaxTimer
    {
        get { return headLookAtWoundMaxTimer; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("headLookAtWoundMaxTimer", value);
            headLookAtWoundMaxTimer = value;
        } 
    }

    private float headLookAtHeadPosMaxTimer = 1.70f;
    /// <summary>
    /// Min time to look headLook or if zero - forward or in velocity direction
    /// </summary>
    public float HeadLookAtHeadPosMaxTimer
    {
        get { return headLookAtHeadPosMaxTimer; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("headLookAtHeadPosMaxTimer", value);
            headLookAtHeadPosMaxTimer = value;
        } 
    }

    private float headLookAtHeadPosMinTimer = 0.60f;
    /// <summary>
    /// Max time to look headLook or if zero - forward or in velocity direction
    /// </summary>
    public float HeadLookAtHeadPosMinTimer
    {
        get { return headLookAtHeadPosMinTimer; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("headLookAtHeadPosMinTimer", value);
            headLookAtHeadPosMinTimer = value;
        } 
    }


    public EuphoriaMessageShotHeadLook(bool startNow) : base("shotHeadLook", startNow)
    { }

    public new void Reset()
    {
        useHeadLook = false;
        headLook = new Vector3(0f,  0f,  0f);
        headLookAtWoundMinTimer = 0.250f;
        headLookAtWoundMaxTimer = 0.80f;
        headLookAtHeadPosMaxTimer = 1.70f;
        headLookAtHeadPosMinTimer = 0.60f;
        base.Reset();
    }
}
}
