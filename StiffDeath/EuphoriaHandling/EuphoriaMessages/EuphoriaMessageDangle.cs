using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// Dangle
/// </summary>

internal class EuphoriaMessageDangle : EuphoriaMessage
{
    private bool doGrab = true;
    /// <summary>
    /// 
    /// </summary>
    public bool DoGrab
    {
        get { return doGrab; } 
        set 
        {  
                
            SetArgument("doGrab", value);
            doGrab = value;
        } 
    }

    private float grabFrequency = 1.00f;
    /// <summary>
    /// 
    /// </summary>
    public float GrabFrequency
    {
        get { return grabFrequency; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("grabFrequency", value);
            grabFrequency = value;
        } 
    }


    public EuphoriaMessageDangle(bool startNow) : base("dangle", startNow)
    { }

    public new void Reset()
    {
        doGrab = true;
        grabFrequency = 1.00f;
        base.Reset();
    }
}
}
