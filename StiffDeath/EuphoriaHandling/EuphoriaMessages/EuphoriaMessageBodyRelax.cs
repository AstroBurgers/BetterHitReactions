using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// bodyRelax:  Set the amount of relaxation across the whole body; Used to collapse the character into a rag-doll-like state.
/// </summary>

internal class EuphoriaMessageBodyRelax : EuphoriaMessage
{
    private float relaxation = 50.000f;
    /// <summary>
    /// How relaxed the body becomes, in percentage relaxed. 100 being totally rag-dolled, 0 being very stiff and rigid.
    /// </summary>
    public float Relaxation
    {
        get { return relaxation; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 100.0f);
            SetArgument("relaxation", value);
            relaxation = value;
        } 
    }

    private float damping = 1.0f;
    /// <summary>
    /// 
    /// </summary>
    public float Damping
    {
        get { return damping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
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

    private bool holdPose = false;
    /// <summary>
    /// automatically hold the current pose as the character relaxes - can be used to avoid relaxing into a t-pose
    /// </summary>
    public bool HoldPose
    {
        get { return holdPose; } 
        set 
        {  
                
            SetArgument("holdPose", value);
            holdPose = value;
        } 
    }

    private bool disableJointDriving = false;
    /// <summary>
    /// sets the drive state to free - this reduces drifting on the ground
    /// </summary>
    public bool DisableJointDriving
    {
        get { return disableJointDriving; } 
        set 
        {  
                
            SetArgument("disableJointDriving", value);
            disableJointDriving = value;
        } 
    }


    public EuphoriaMessageBodyRelax(bool startNow) : base("bodyRelax", startNow)
    { }

    public new void Reset()
    {
        relaxation = 50.000f;
        damping = 1.0f;
        mask = "fb";
        holdPose = false;
        disableJointDriving = false;
        base.Reset();
    }
}
}
