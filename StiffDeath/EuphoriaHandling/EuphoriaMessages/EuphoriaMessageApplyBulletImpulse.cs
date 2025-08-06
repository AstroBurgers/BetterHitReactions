using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageApplyBulletImpulse : EuphoriaMessage
{
    private float equalizeAmount = 0.000f;
    /// <summary>
    /// 0 means straight impulse, 1 means multiply by the mass (change in velocity)
    /// </summary>
    public float EqualizeAmount
    {
        get { return equalizeAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("equalizeAmount", value);
            equalizeAmount = value;
        } 
    }

    private int partIndex = 0;
    /// <summary>
    /// index of part being hit.
    /// </summary>
    public int PartIndex
    {
        get { return partIndex; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 28);
            SetArgument("partIndex", value);
            partIndex = value;
        } 
    }

    private Vector3 impulse = new(0f,  0f,  0f);
    /// <summary>
    /// impulse vector (impulse is change in momentum)
    /// </summary>
    public Vector3 Impulse
    {
        get { return impulse; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, -1000.0f, 1000.0f);
            value.Y = MathHelper.Clamp(value.Y, -1000.0f, 1000.0f);
            value.Z = MathHelper.Clamp(value.Z, -1000.0f, 1000.0f);
            SetArgument("impulse", value);
            impulse = value;
        } 
    }

    private Vector3 hitPoint = new(0f,  0f,  0f);
    /// <summary>
    /// optional point on part where hit
    /// </summary>
    public Vector3 HitPoint
    {
        get { return hitPoint; } 
        set 
        {  
                
            SetArgument("hitPoint", value);
            hitPoint = value;
        } 
    }

    private bool localHitPointInfo = false;
    /// <summary>
    /// true = hitPoint is in local coordinates of bodyPart, false = hitpoint is in world coordinates
    /// </summary>
    public bool LocalHitPointInfo
    {
        get { return localHitPointInfo; } 
        set 
        {  
                
            SetArgument("localHitPointInfo", value);
            localHitPointInfo = value;
        } 
    }

    private float extraShare = 0.00f;
    /// <summary>
    /// if not 0.0 then have an extra bullet applied to spine0 (approximates the COM).  Uses setup from configureBulletsExtra.  0-1 shared 0.0 = no extra bullet, 0.5 = impulse split equally between extra and bullet,  1.0 only extra bullet.  LT 0.0 then bullet + scaled extra bullet.  Eg.-0.5 = bullet + 0.5 impulse extra bullet
    /// </summary>
    public float ExtraShare
    {
        get { return extraShare; } 
        set 
        {  
            value = MathHelper.Clamp(value, -2.00f, 1.00f);
            SetArgument("extraShare", value);
            extraShare = value;
        } 
    }


    public EuphoriaMessageApplyBulletImpulse(bool startNow) : base("applyBulletImpulse", startNow)
    { }

    public new void Reset()
    {
        equalizeAmount = 0.000f;
        partIndex = 0;
        impulse = new Vector3(0f,  0f,  0f);
        hitPoint = new Vector3(0f,  0f,  0f);
        localHitPointInfo = false;
        extraShare = 0.00f;
        base.Reset();
    }
}
}
