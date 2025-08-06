using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// setWeaponMode:  Use this message to set the character's weapon mode.  This is an alternativeto the setWeaponMode public function.
/// </summary>

internal class EuphoriaMessageSetWeaponMode : EuphoriaMessage
{
    private int weaponMode = 5;
    /// <summary>
    /// Weapon mode. kNone = -1, kPistol = 0, kDual = 1, kRifle = 2, kSidearm = 3, kPistolLeft = 4, kPistolRight = 5. See WeaponMode enum in NmRsUtils.h and -1 from that.
    /// </summary>
    public int WeaponMode
    {
        get { return weaponMode; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1, 6);
            SetArgument("weaponMode", value);
            weaponMode = value;
        } 
    }


    public EuphoriaMessageSetWeaponMode(bool startNow) : base("setWeaponMode", startNow)
    { }

    public new void Reset()
    {
        weaponMode = 5;
        base.Reset();
    }
}
}
