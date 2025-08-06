namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageApplyImpulse : EuphoriaMessage
{
    private float equalizeAmount = 0.000f;
    /// <summary>
    /// 0 means straight impulse, 1 means multiply by the mass (change in velocity)
    /// </summary>
    public float EqualizeAmount
    {
        get { return equalizeAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("equalizeAmount", value);
            equalizeAmount = value;
        } 
    }

    private int partIndex = 0;
    /// <summary>
    /// index of part being hit. -1 apply impulse to COM.
    /// </summary>
    public int PartIndex
    {
        get { return partIndex; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1, 28);
            SetArgument("partIndex", value);
            partIndex = value;
        } 
    }

    private Vector3 impulse = new(0f,  0f,  0f);
    /// <summary>
    /// impulse vector (impulse is change in momentum)
    /// </summary>
    public Vector3 Impulse
    {
        get { return impulse; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, -4500.0f, 4500.0f);
            value.Y = MathHelper.Clamp(value.Y, -4500.0f, 4500.0f);
            value.Z = MathHelper.Clamp(value.Z, -4500.0f, 4500.0f);
            SetArgument("impulse", value);
            impulse = value;
        } 
    }

    private Vector3 hitPoint = new(0f,  0f,  0f);
    /// <summary>
    /// optional point on part where hit.  If not supplied then the impulse is applied at the part centre.
    /// </summary>
    public Vector3 HitPoint
    {
        get { return hitPoint; } 
        set 
        {  
                
            SetArgument("hitPoint", value);
            hitPoint = value;
        } 
    }

    private bool localHitPointInfo = false;
    /// <summary>
    /// hitPoint in local coordinates of bodyPart
    /// </summary>
    public bool LocalHitPointInfo
    {
        get { return localHitPointInfo; } 
        set 
        {  
                
            SetArgument("localHitPointInfo", value);
            localHitPointInfo = value;
        } 
    }

    private bool localImpulseInfo = false;
    /// <summary>
    /// impulse in local coordinates of bodyPart
    /// </summary>
    public bool LocalImpulseInfo
    {
        get { return localImpulseInfo; } 
        set 
        {  
                
            SetArgument("localImpulseInfo", value);
            localImpulseInfo = value;
        } 
    }

    private bool angularImpulse = false;
    /// <summary>
    /// impulse should be considered an angular impulse
    /// </summary>
    public bool AngularImpulse
    {
        get { return angularImpulse; } 
        set 
        {  
                
            SetArgument("angularImpulse", value);
            angularImpulse = value;
        } 
    }


    public EuphoriaMessageApplyImpulse(bool startNow) : base("applyImpulse", startNow)
    { }

    public new void Reset()
    {
        equalizeAmount = 0.000f;
        partIndex = 0;
        impulse = new Vector3(0f,  0f,  0f);
        hitPoint = new Vector3(0f,  0f,  0f);
        localHitPointInfo = false;
        localImpulseInfo = false;
        angularImpulse = false;
        base.Reset();
    }
}
}
