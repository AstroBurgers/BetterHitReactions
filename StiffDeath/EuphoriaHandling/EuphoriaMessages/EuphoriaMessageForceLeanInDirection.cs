namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageForceLeanInDirection : EuphoriaMessage
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

    private int bodyPart = 0;
    /// <summary>
    /// body part that the force is applied to
    /// </summary>
    public int BodyPart
    {
        get { return bodyPart; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 21);
            SetArgument("bodyPart", value);
            bodyPart = value;
        } 
    }


    public EuphoriaMessageForceLeanInDirection(bool startNow) : base("forceLeanInDirection", startNow)
    { }

    public new void Reset()
    {
        leanAmount = 0.200f;
        dir = new Vector3(0.00f,  0.00f,  1.00f);
        bodyPart = 0;
        base.Reset();
    }
}
}
