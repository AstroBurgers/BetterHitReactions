using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageLeanTowardsObject : EuphoriaMessage
{
    private float leanAmount = 0.200f;
    /// <summary>
    /// amount of lean, 0 to about 0.5. -ve will move away from the target.
    /// </summary>
    public float LeanAmount
    {
        get { return leanAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, -0.50f, 0.50f);
            SetArgument("leanAmount", value);
            leanAmount = value;
        } 
    }

    private Vector3 offset = new(0f,  0f,  0f);
    /// <summary>
    /// offset from instance position added when calculating position to lean to
    /// </summary>
    public Vector3 Offset
    {
        get { return offset; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, -100.0f, 100.0f);
            value.Y = MathHelper.Clamp(value.Y, -100.0f, 100.0f);
            value.Z = MathHelper.Clamp(value.Z, -100.0f, 100.0f);
            SetArgument("offset", value);
            offset = value;
        } 
    }

    private int instanceIndex = -1;
    /// <summary>
    /// levelIndex of object to lean towards
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

    private int boundIndex = 0;
    /// <summary>
    /// boundIndex of object to lean towards (0 = just use instance coordinates)
    /// </summary>
    public int BoundIndex
    {
        get { return boundIndex; } 
        set 
        {  
                
            SetArgument("boundIndex", value);
            boundIndex = value;
        } 
    }


    public EuphoriaMessageLeanTowardsObject(bool startNow) : base("leanTowardsObject", startNow)
    { }

    public new void Reset()
    {
        leanAmount = 0.200f;
        offset = new Vector3(0f,  0f,  0f);
        instanceIndex = -1;
        boundIndex = 0;
        base.Reset();
    }
}
}
