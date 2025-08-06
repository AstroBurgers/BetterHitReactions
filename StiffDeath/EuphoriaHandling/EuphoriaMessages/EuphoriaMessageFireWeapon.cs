using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// fireWeapon:  One shot message apply a force to the hand as we fire the gun that should be in this hand
/// </summary>

internal class EuphoriaMessageFireWeapon : EuphoriaMessage
{
    private float firedWeaponStrength = 1000.0f;
    /// <summary>
    /// The force of the gun.
    /// </summary>
    public float FiredWeaponStrength
    {
        get { return firedWeaponStrength; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10000.0f);
            SetArgument("firedWeaponStrength", value);
            firedWeaponStrength = value;
        } 
    }

    private int gunHandEnum = 0;
    /// <summary>
    /// Which hand in the gun in, 0 = left, 1 = right.
    /// </summary>
    public int GunHandEnum
    {
        get { return gunHandEnum; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 1);
            SetArgument("gunHandEnum", value);
            gunHandEnum = value;
        } 
    }

    private bool applyFireGunForceAtClavicle = false;
    /// <summary>
    /// Should we apply some of the force at the shoulder. Force double handed weapons (Ak47 etc).
    /// </summary>
    public bool ApplyFireGunForceAtClavicle
    {
        get { return applyFireGunForceAtClavicle; } 
        set 
        {  
                
            SetArgument("applyFireGunForceAtClavicle", value);
            applyFireGunForceAtClavicle = value;
        } 
    }

    private float inhibitTime = 0.40f;
    /// <summary>
    /// Minimum time before next fire impulse
    /// </summary>
    public float InhibitTime
    {
        get { return inhibitTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("inhibitTime", value);
            inhibitTime = value;
        } 
    }

    private Vector3 direction = new(0f,  0f,  0f);
    /// <summary>
    /// direction of impulse in gun frame
    /// </summary>
    public Vector3 Direction
    {
        get { return direction; } 
        set 
        {  
                
            SetArgument("direction", value);
            direction = value;
        } 
    }

    private float split = 0.50f;
    /// <summary>
    /// Split force between hand and clavicle when applyFireGunForceAtClavicle is true. 1 = all hand, 0 = all clavicle.
    /// </summary>
    public float Split
    {
        get { return split; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("split", value);
            split = value;
        } 
    }


    public EuphoriaMessageFireWeapon(bool startNow) : base("fireWeapon", startNow)
    { }

    public new void Reset()
    {
        firedWeaponStrength = 1000.0f;
        gunHandEnum = 0;
        applyFireGunForceAtClavicle = false;
        inhibitTime = 0.40f;
        direction = new Vector3(0f,  0f,  0f);
        split = 0.50f;
        base.Reset();
    }
}
}
