using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageHipsLeanToPosition : EuphoriaMessage
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

    private Vector3 pos = new(0f,  0f,  0f);
    /// <summary>
    /// position to head towards
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


    public EuphoriaMessageHipsLeanToPosition(bool startNow) : base("hipsLeanToPosition", startNow)
    { }

    public new void Reset()
    {
        leanAmount = 0.200f;
        pos = new Vector3(0f,  0f,  0f);
        base.Reset();
    }
}
}
