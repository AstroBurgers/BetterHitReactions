namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// setMuscleStiffness:  Use this message to manually set the muscle stiffness values -before using Active Pose to drive to an animated pose, for example.
/// </summary>

internal class EuphoriaMessageSetMuscleStiffness : EuphoriaMessage
{
    private float muscleStiffness = 1.000f;
    /// <summary>
    /// muscle stiffness of joint/s
    /// </summary>
    public float MuscleStiffness
    {
        get { return muscleStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 20.0f);
            SetArgument("muscleStiffness", value);
            muscleStiffness = value;
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


    public EuphoriaMessageSetMuscleStiffness(bool startNow) : base("setMuscleStiffness", startNow)
    { }

    public new void Reset()
    {
        muscleStiffness = 1.000f;
        mask = "fb";
        base.Reset();
    }
}
}
