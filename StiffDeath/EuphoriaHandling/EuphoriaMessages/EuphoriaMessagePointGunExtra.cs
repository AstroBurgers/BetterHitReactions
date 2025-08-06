using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// pointGunExtra:  Seldom set parameters for pointGun - just to keep number of parameters in any message less than or equal to 64
/// </summary>

internal class EuphoriaMessagePointGunExtra : EuphoriaMessage
{
    private float constraintStrength = 2.00f;
    /// <summary>
    /// For supportConstraint = 2: force constraint strength of the supporting hands - it gets shaky at about 4.0
    /// </summary>
    public float ConstraintStrength
    {
        get { return constraintStrength; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 5.00f);
            SetArgument("constraintStrength", value);
            constraintStrength = value;
        } 
    }

    private float constraintThresh = 0.10f;
    /// <summary>
    /// For supportConstraint = 2:  Like makeConstraintDistance. Force starts acting when the hands are  LT  3.0*thresh apart but is maximum strength  LT  thresh. For comparison: 0.1 is used for reachForWound in shot, 0.25 is used in grab.
    /// </summary>
    public float ConstraintThresh
    {
        get { return constraintThresh; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("constraintThresh", value);
            constraintThresh = value;
        } 
    }

    private int weaponMask = 1024;
    /// <summary>
    /// Currently unused - no intoWorldTest. RAGE bit mask to exclude weapons from ray probe - currently defaults to MP3 weapon flag
    /// </summary>
    public int WeaponMask
    {
        get { return weaponMask; } 
        set 
        {  
                
            SetArgument("weaponMask", value);
            weaponMask = value;
        } 
    }

    private bool timeWarpActive = false;
    /// <summary>
    /// Is timeWarpActive enabled?
    /// </summary>
    public bool TimeWarpActive
    {
        get { return timeWarpActive; } 
        set 
        {  
                
            SetArgument("timeWarpActive", value);
            timeWarpActive = value;
        } 
    }

    private float timeWarpStrengthScale = 1.00f;
    /// <summary>
    /// Scale for arm and helper strength when timewarp is enabled. 1 = normal compensation.
    /// </summary>
    public float TimeWarpStrengthScale
    {
        get { return timeWarpStrengthScale; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 2.00f);
            SetArgument("timeWarpStrengthScale", value);
            timeWarpStrengthScale = value;
        } 
    }

    private float oriStiff = 0.00f;
    /// <summary>
    /// Hand stabilization controller stiffness.
    /// </summary>
    public float OriStiff
    {
        get { return oriStiff; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.00f);
            SetArgument("oriStiff", value);
            oriStiff = value;
        } 
    }

    private float oriDamp = 0.00f;
    /// <summary>
    /// Hand stabilization controller damping.
    /// </summary>
    public float OriDamp
    {
        get { return oriDamp; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("oriDamp", value);
            oriDamp = value;
        } 
    }

    private float posStiff = 0.00f;
    /// <summary>
    /// Hand stabilization controller stiffness.
    /// </summary>
    public float PosStiff
    {
        get { return posStiff; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.00f);
            SetArgument("posStiff", value);
            posStiff = value;
        } 
    }

    private float posDamp = 0.00f;
    /// <summary>
    /// Hand stabilization controller damping.
    /// </summary>
    public float PosDamp
    {
        get { return posDamp; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("posDamp", value);
            posDamp = value;
        } 
    }


    public EuphoriaMessagePointGunExtra(bool startNow) : base("pointGunExtra", startNow)
    { }

    public new void Reset()
    {
        constraintStrength = 2.00f;
        constraintThresh = 0.10f;
        weaponMask = 1024;
        timeWarpActive = false;
        timeWarpStrengthScale = 1.00f;
        oriStiff = 0.00f;
        oriDamp = 0.00f;
        posStiff = 0.00f;
        posDamp = 0.00f;
        base.Reset();
    }
}
}
