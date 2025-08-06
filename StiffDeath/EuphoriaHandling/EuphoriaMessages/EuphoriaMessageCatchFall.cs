using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageCatchFall : EuphoriaMessage
{
    private float torsoStiffness = 9.0f;
    /// <summary>
    /// stiffness of torso
    /// </summary>
    public float TorsoStiffness
    {
        get { return torsoStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("torsoStiffness", value);
            torsoStiffness = value;
        } 
    }

    private float legsStiffness = 6.0f;
    /// <summary>
    /// stiffness of legs
    /// </summary>
    public float LegsStiffness
    {
        get { return legsStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 4.0f, 16.0f);
            SetArgument("legsStiffness", value);
            legsStiffness = value;
        } 
    }

    private float armsStiffness = 15.0f;
    /// <summary>
    /// stiffness of arms
    /// </summary>
    public float ArmsStiffness
    {
        get { return armsStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("armsStiffness", value);
            armsStiffness = value;
        } 
    }

    private float backwardsMinArmOffset = -0.25f;
    /// <summary>
    /// 0 will prop arms up near his shoulders. -0.3 will place hands nearer his behind
    /// </summary>
    public float BackwardsMinArmOffset
    {
        get { return backwardsMinArmOffset; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 0.0f);
            SetArgument("backwardsMinArmOffset", value);
            backwardsMinArmOffset = value;
        } 
    }

    private float forwardMaxArmOffset = 0.35f;
    /// <summary>
    /// 0 will point arms down with angled body, 0.45 will point arms forward a bit to catch nearer the head
    /// </summary>
    public float ForwardMaxArmOffset
    {
        get { return forwardMaxArmOffset; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("forwardMaxArmOffset", value);
            forwardMaxArmOffset = value;
        } 
    }

    private float zAxisSpinReduction = 0.0f;
    /// <summary>
    /// Tries to reduce the spin around the Z axis. Scale 0 - 1.
    /// </summary>
    public float ZAxisSpinReduction
    {
        get { return zAxisSpinReduction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("zAxisSpinReduction", value);
            zAxisSpinReduction = value;
        } 
    }

    private float extraSit = 1.0f;
    /// <summary>
    /// Scale extra-sit value 0..1. Setting to 0 helps with arched-back issues.  Set to 1 for a more alive-looking finish.
    /// </summary>
    public float ExtraSit
    {
        get { return extraSit; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("extraSit", value);
            extraSit = value;
        } 
    }

    private bool useHeadLook = true;
    /// <summary>
    /// Toggle to use the head look in this behaviour.
    /// </summary>
    public bool UseHeadLook
    {
        get { return useHeadLook; } 
        set 
        {  
                
            SetArgument("useHeadLook", value);
            useHeadLook = value;
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


    public EuphoriaMessageCatchFall(bool startNow) : base("catchFall", startNow)
    { }

    public new void Reset()
    {
        torsoStiffness = 9.0f;
        legsStiffness = 6.0f;
        armsStiffness = 15.0f;
        backwardsMinArmOffset = -0.25f;
        forwardMaxArmOffset = 0.35f;
        zAxisSpinReduction = 0.0f;
        extraSit = 1.0f;
        useHeadLook = true;
        mask = "fb";
        base.Reset();
    }
}
}
