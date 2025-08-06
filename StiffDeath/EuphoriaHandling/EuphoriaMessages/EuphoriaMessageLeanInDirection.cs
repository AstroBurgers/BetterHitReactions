namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageLeanInDirection : EuphoriaMessage
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
            value = MathHelper.Clamp(value, -1.0f, 1.0f);
            SetArgument("leanAmount", value);
            leanAmount = value;
        } 
    }

    private Vector3 dir = new(0.00f,  0.00f,  1.00f);
    /// <summary>
    /// direction to lean in
    /// </summary>
    public Vector3 Dir
    {
        get { return dir; } 
        set 
        {  
                
            SetArgument("dir", value);
            dir = value;
        } 
    }


    public EuphoriaMessageLeanInDirection(bool startNow) : base("leanInDirection", startNow)
    { }

    public new void Reset()
    {
        leanAmount = 0.200f;
        dir = new Vector3(0.00f,  0.00f,  1.00f);
        base.Reset();
    }
}
}
