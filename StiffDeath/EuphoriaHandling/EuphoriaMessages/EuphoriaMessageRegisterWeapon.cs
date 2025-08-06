using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// registerWeapon:  Use this message to register weapon.  This is an alternativeto the registerWeapon public function.
/// </summary>

internal class EuphoriaMessageRegisterWeapon : EuphoriaMessage
{
    private int hand = 1;
    /// <summary>
    /// What hand the weapon is in. LeftHand = 0, RightHand = 1
    /// </summary>
    public int Hand
    {
        get { return hand; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 1);
            SetArgument("hand", value);
            hand = value;
        } 
    }

    private int levelIndex = -1;
    /// <summary>
    /// Level index of the weapon
    /// </summary>
    public int LevelIndex
    {
        get { return levelIndex; } 
        set 
        {  
                
            SetArgument("levelIndex", value);
            levelIndex = value;
        } 
    }

    private int constraintHandle = -1;
    /// <summary>
    /// pointer to the hand-gun constraint handle
    /// </summary>
    public int ConstraintHandle
    {
        get { return constraintHandle; } 
        set 
        {  
                
            SetArgument("constraintHandle", value);
            constraintHandle = value;
        } 
    }

    private Vector3 gunToHandA = new(1.00f,  0.00f,  0.00f);
    /// <summary>
    /// A vector of the gunToHand matrix.  The gunToHandMatrix is the desired gunToHandMatrix in the aimingPose. (The gunToHandMatrix when pointGun starts can be different so will be blended to this desired one)
    /// </summary>
    public Vector3 GunToHandA
    {
        get { return gunToHandA; } 
        set 
        {  
                
            SetArgument("gunToHandA", value);
            gunToHandA = value;
        } 
    }

    private Vector3 gunToHandB = new(0.00f,  1.00f,  0.00f);
    /// <summary>
    /// B vector of the gunToHand matrix
    /// </summary>
    public Vector3 GunToHandB
    {
        get { return gunToHandB; } 
        set 
        {  
                
            SetArgument("gunToHandB", value);
            gunToHandB = value;
        } 
    }

    private Vector3 gunToHandC = new(0.00f,  0.00f,  1.00f);
    /// <summary>
    /// C vector of the gunToHand matrix
    /// </summary>
    public Vector3 GunToHandC
    {
        get { return gunToHandC; } 
        set 
        {  
                
            SetArgument("gunToHandC", value);
            gunToHandC = value;
        } 
    }

    private Vector3 gunToHandD = new(0.00f,  0.00f,  0.00f);
    /// <summary>
    /// D vector of the gunToHand matrix
    /// </summary>
    public Vector3 GunToHandD
    {
        get { return gunToHandD; } 
        set 
        {  
                
            SetArgument("gunToHandD", value);
            gunToHandD = value;
        } 
    }

    private Vector3 gunToMuzzleInGun = new(0f,  0f,  0f);
    /// <summary>
    /// Gun centre to muzzle expressed in gun co-ordinates.  To get the line of sight/barrel of the gun. Assumption: the muzzle direction is always along the same primary axis of the gun.
    /// </summary>
    public Vector3 GunToMuzzleInGun
    {
        get { return gunToMuzzleInGun; } 
        set 
        {  
                
            SetArgument("gunToMuzzleInGun", value);
            gunToMuzzleInGun = value;
        } 
    }

    private Vector3 gunToButtInGun = new(0f,  0f,  0f);
    /// <summary>
    /// Gun centre to butt expressed in gun co-ordinates.  The gun pivots around this point when aiming
    /// </summary>
    public Vector3 GunToButtInGun
    {
        get { return gunToButtInGun; } 
        set 
        {  
                
            SetArgument("gunToButtInGun", value);
            gunToButtInGun = value;
        } 
    }


    public EuphoriaMessageRegisterWeapon(bool startNow) : base("registerWeapon", startNow)
    { }

    public new void Reset()
    {
        hand = 1;
        levelIndex = -1;
        constraintHandle = -1;
        gunToHandA = new Vector3(1.00f,  0.00f,  0.00f);
        gunToHandB = new Vector3(0.00f,  1.00f,  0.00f);
        gunToHandC = new Vector3(0.00f,  0.00f,  1.00f);
        gunToHandD = new Vector3(0.00f,  0.00f,  0.00f);
        gunToMuzzleInGun = new Vector3(0f,  0f,  0f);
        gunToButtInGun = new Vector3(0f,  0f,  0f);
        base.Reset();
    }
}
}
