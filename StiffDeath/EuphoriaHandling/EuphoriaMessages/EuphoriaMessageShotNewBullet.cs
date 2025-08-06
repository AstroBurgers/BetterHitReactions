namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// shotNewBullet:  Send new wound information to the shot.  Can cause shot to restart it's performance in part or in whole.
/// </summary>

internal class EuphoriaMessageShotNewBullet : EuphoriaMessage
{
    private int bodyPart = 0;
    /// <summary>
    /// part ID on the body where the bullet hit
    /// </summary>
    public int BodyPart
    {
        get { return bodyPart; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 21);
            SetArgument("bodyPart", value);
            bodyPart = value;
        } 
    }

    private bool localHitPointInfo = true;
    /// <summary>
    /// if true then normal and hitPoint should be supplied in local coordinates of bodyPart.  If false then normal and hitPoint should be supplied in World coordinates
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

    private Vector3 normal = new(0f,  0f,  -1f);
    /// <summary>
    /// Normal coming out of impact point on character.  Can be local or global depending on localHitPointInfo
    /// </summary>
    public Vector3 Normal
    {
        get { return normal; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, -1.0f, 1.0f);
            value.Y = MathHelper.Clamp(value.Y, -1.0f, 1.0f);
            value.Z = MathHelper.Clamp(value.Z, -1.0f, 1.0f);
            SetArgument("normal", value);
            normal = value;
        } 
    }

    private Vector3 hitPoint = new(0f,  0f,  0f);
    /// <summary>
    /// position of impact on character. Can be local or global depending on localHitPointInfo
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

    private Vector3 bulletVel = new(0f,  0f,  0f);
    /// <summary>
    /// bullet velocity in world coordinates
    /// </summary>
    public Vector3 BulletVel
    {
        get { return bulletVel; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, -2000.0f, 2000.0f);
            value.Y = MathHelper.Clamp(value.Y, -2000.0f, 2000.0f);
            value.Z = MathHelper.Clamp(value.Z, -2000.0f, 2000.0f);
            SetArgument("bulletVel", value);
            bulletVel = value;
        } 
    }


    public EuphoriaMessageShotNewBullet(bool startNow) : base("shotNewBullet", startNow)
    { }

    public new void Reset()
    {
        bodyPart = 0;
        localHitPointInfo = true;
        normal = new Vector3(0f,  0f,  -1f);
        hitPoint = new Vector3(0f,  0f,  0f);
        bulletVel = new Vector3(0f,  0f,  0f);
        base.Reset();
    }
}
}
