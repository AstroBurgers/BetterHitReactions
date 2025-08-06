using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageForceLeanToPosition : EuphoriaMessage
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


    public EuphoriaMessageForceLeanToPosition(bool startNow) : base("forceLeanToPosition", startNow)
    { }

    public new void Reset()
    {
        leanAmount = 0.200f;
        pos = new Vector3(0f,  0f,  0f);
        bodyPart = 0;
        base.Reset();
    }
}
}
