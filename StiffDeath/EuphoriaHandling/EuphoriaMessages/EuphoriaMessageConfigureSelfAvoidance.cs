using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// configureSelfAvoidance: this single message allows to configure self avoidance for the character.BBDD Self avoidance tech.
/// </summary>

internal class EuphoriaMessageConfigureSelfAvoidance : EuphoriaMessage
{
    private bool useSelfAvoidance = false;
    /// <summary>
    /// Enable or disable self avoidance tech.
    /// </summary>
    public bool UseSelfAvoidance
    {
        get { return useSelfAvoidance; } 
        set 
        {  
                
            SetArgument("useSelfAvoidance", value);
            useSelfAvoidance = value;
        } 
    }

    private bool overwriteDragReduction = false;
    /// <summary>
    /// Specify whether self avoidance tech should use original IK input target or the target that has been already modified by getStabilisedPos() tech i.e. function that compensates for rotational and linear velocity of shoulder/thigh.
    /// </summary>
    public bool OverwriteDragReduction
    {
        get { return overwriteDragReduction; } 
        set 
        {  
                
            SetArgument("overwriteDragReduction", value);
            overwriteDragReduction = value;
        } 
    }

    private float torsoSwingFraction = 0.750f;
    /// <summary>
    /// Place the adjusted target this much along the arc between effector (wrist) and target, value in range [0,1].
    /// </summary>
    public float TorsoSwingFraction
    {
        get { return torsoSwingFraction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("torsoSwingFraction", value);
            torsoSwingFraction = value;
        } 
    }

    private float maxTorsoSwingAngleRad = 0.7580f;
    /// <summary>
    /// Max value on the effector (wrist) to adjusted target offset.
    /// </summary>
    public float MaxTorsoSwingAngleRad
    {
        get { return maxTorsoSwingAngleRad; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.570f);
            SetArgument("maxTorsoSwingAngleRad", value);
            maxTorsoSwingAngleRad = value;
        } 
    }

    private bool selfAvoidIfInSpineBoundsOnly = false;
    /// <summary>
    /// Restrict self avoidance to operate on targets that are within character torso bounds only.
    /// </summary>
    public bool SelfAvoidIfInSpineBoundsOnly
    {
        get { return selfAvoidIfInSpineBoundsOnly; } 
        set 
        {  
                
            SetArgument("selfAvoidIfInSpineBoundsOnly", value);
            selfAvoidIfInSpineBoundsOnly = value;
        } 
    }

    private float selfAvoidAmount = 0.50f;
    /// <summary>
    /// Amount of self avoidance offset applied when angle from effector (wrist) to target is greater then right angle i.e. when total offset is a blend between where effector currently is to value that is a product of total arm length and selfAvoidAmount. SelfAvoidAmount is in a range between [0, 1].
    /// </summary>
    public float SelfAvoidAmount
    {
        get { return selfAvoidAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("selfAvoidAmount", value);
            selfAvoidAmount = value;
        } 
    }

    private bool overwriteTwist = false;
    /// <summary>
    /// Overwrite desired IK twist with self avoidance procedural twist.
    /// </summary>
    public bool OverwriteTwist
    {
        get { return overwriteTwist; } 
        set 
        {  
                
            SetArgument("overwriteTwist", value);
            overwriteTwist = value;
        } 
    }

    private bool usePolarPathAlgorithm = false;
    /// <summary>
    /// Use the alternative self avoidance algorithm that is based on linear and polar target blending. WARNING: It only requires "radius" in terms of parametrization.
    /// </summary>
    public bool UsePolarPathAlgorithm
    {
        get { return usePolarPathAlgorithm; } 
        set 
        {  
                
            SetArgument("usePolarPathAlgorithm", value);
            usePolarPathAlgorithm = value;
        } 
    }

    private float radius = 0.30f;
    /// <summary>
    /// Self avoidance radius, measured out from the spine axis along the plane perpendicular to that axis. The closer is the proximity of reaching target to that radius, the more polar (curved) motion is used for offsetting the target. WARNING: Parameter only used by the alternative algorithm that is based on linear and polar target blending.
    /// </summary>
    public float Radius
    {
        get { return radius; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("radius", value);
            radius = value;
        } 
    }


    public EuphoriaMessageConfigureSelfAvoidance(bool startNow) : base("configureSelfAvoidance", startNow)
    { }

    public new void Reset()
    {
        useSelfAvoidance = false;
        overwriteDragReduction = false;
        torsoSwingFraction = 0.750f;
        maxTorsoSwingAngleRad = 0.7580f;
        selfAvoidIfInSpineBoundsOnly = false;
        selfAvoidAmount = 0.50f;
        overwriteTwist = false;
        usePolarPathAlgorithm = false;
        radius = 0.30f;
        base.Reset();
    }
}
}
