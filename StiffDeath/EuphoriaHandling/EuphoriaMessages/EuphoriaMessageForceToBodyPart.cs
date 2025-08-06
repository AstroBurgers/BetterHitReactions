namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// forceToBodyPart:  Apply an impulse to a named body part
/// </summary>

internal class EuphoriaMessageForceToBodyPart : EuphoriaMessage
{
    private int partIndex = 0;
    /// <summary>
    /// part or link or bound index
    /// </summary>
    public int PartIndex
    {
        get { return partIndex; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 28);
            SetArgument("partIndex", value);
            partIndex = value;
        } 
    }

    private Vector3 force = new(0.00f,  -50.00f,  0.00f);
    /// <summary>
    /// force to apply
    /// </summary>
    public Vector3 Force
    {
        get { return force; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, -100000.0f, 100000.0f);
            value.Y = MathHelper.Clamp(value.Y, -100000.0f, 100000.0f);
            value.Z = MathHelper.Clamp(value.Z, -100000.0f, 100000.0f);
            SetArgument("force", value);
            force = value;
        } 
    }

    private bool forceDefinedInPartSpace = false;
    /// <summary>
    /// 
    /// </summary>
    public bool ForceDefinedInPartSpace
    {
        get { return forceDefinedInPartSpace; } 
        set 
        {  
                
            SetArgument("forceDefinedInPartSpace", value);
            forceDefinedInPartSpace = value;
        } 
    }


    public EuphoriaMessageForceToBodyPart(bool startNow) : base("forceToBodyPart", startNow)
    { }

    public new void Reset()
    {
        partIndex = 0;
        force = new Vector3(0.00f,  -50.00f,  0.00f);
        forceDefinedInPartSpace = false;
        base.Reset();
    }
}
}
