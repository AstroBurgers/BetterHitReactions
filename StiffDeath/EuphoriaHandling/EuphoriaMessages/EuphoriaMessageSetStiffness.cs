namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// setStiffness:  Use this message to manually set the body stiffness values -before using Active Pose to drive to an animated pose, for example.
/// </summary>

internal class EuphoriaMessageSetStiffness : EuphoriaMessage
{
    private float bodyStiffness = 12.000f;
    /// <summary>
    /// stiffness of whole character
    /// </summary>
    public float BodyStiffness
    {
        get { return bodyStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 2.0f, 20.0f);
            SetArgument("bodyStiffness", value);
            bodyStiffness = value;
        } 
    }

    private float damping = 1.000f;
    /// <summary>
    /// damping amount, less is underdamped
    /// </summary>
    public float Damping
    {
        get { return damping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("damping", value);
            damping = value;
        } 
    }

    private string mask = "fb";
    /// <summary>
    /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value  (see Active Pose notes for possible values)
    /// </summary>
    public string Mask
    {
        get { return mask; } 
        set 
        {  
                
            SetArgument("mask", value);
            mask = value;
        } 
    }


    public EuphoriaMessageSetStiffness(bool startNow) : base("setStiffness", startNow)
    { }

    public new void Reset()
    {
        bodyStiffness = 12.000f;
        damping = 1.000f;
        mask = "fb";
        base.Reset();
    }
}
}
