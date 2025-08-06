namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageDefineAttachedObject : EuphoriaMessage
{
    private int partIndex = -1;
    /// <summary>
    /// index of part to attach to
    /// </summary>
    public int PartIndex
    {
        get { return partIndex; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1, 21);
            SetArgument("partIndex", value);
            partIndex = value;
        } 
    }

    private float objectMass = 0.000f;
    /// <summary>
    /// mass of the attached object
    /// </summary>
    public float ObjectMass
    {
        get { return objectMass; } 
        set 
        {  
                
            SetArgument("objectMass", value);
            objectMass = value;
        } 
    }

    private Vector3 worldPos = new(0f,  0f,  0f);
    /// <summary>
    /// world position of attached object's centre of mass. must be updated each frame.
    /// </summary>
    public Vector3 WorldPos
    {
        get { return worldPos; } 
        set 
        {  
                
            SetArgument("worldPos", value);
            worldPos = value;
        } 
    }


    public EuphoriaMessageDefineAttachedObject(bool startNow) : base("defineAttachedObject", startNow)
    { }

    public new void Reset()
    {
        partIndex = -1;
        objectMass = 0.000f;
        worldPos = new Vector3(0f,  0f,  0f);
        base.Reset();
    }
}
}
