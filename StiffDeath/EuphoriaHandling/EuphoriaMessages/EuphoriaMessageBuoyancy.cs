using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// buoyancy:  Simple buoyancy model.  No character movement just fluid forces/torques added to parts.
/// </summary>

internal class EuphoriaMessageBuoyancy : EuphoriaMessage
{
    private Vector3 surfacePoint = new(0f,  0f,  0f);
    /// <summary>
    /// Arbitrary point on surface of water.
    /// </summary>
    public Vector3 SurfacePoint
    {
        get { return surfacePoint; } 
        set 
        {  
                
            SetArgument("surfacePoint", value);
            surfacePoint = value;
        } 
    }

    private Vector3 surfaceNormal = new(0f,  0f,  1f);
    /// <summary>
    /// Normal to surface of water.
    /// </summary>
    public Vector3 SurfaceNormal
    {
        get { return surfaceNormal; } 
        set 
        {  
                
            SetArgument("surfaceNormal", value);
            surfaceNormal = value;
        } 
    }

    private float buoyancy = 1.0f;
    /// <summary>
    /// Buoyancy multiplier.
    /// </summary>
    public float Buoyancy
    {
        get { return buoyancy; } 
        set 
        {  
                
            SetArgument("buoyancy", value);
            buoyancy = value;
        } 
    }

    private float chestBuoyancy = 8.0f;
    /// <summary>
    /// Buoyancy mulplier for spine2/3. Helps character float upright.
    /// </summary>
    public float ChestBuoyancy
    {
        get { return chestBuoyancy; } 
        set 
        {  
                
            SetArgument("chestBuoyancy", value);
            chestBuoyancy = value;
        } 
    }

    private float damping = 40.0f;
    /// <summary>
    /// Damping for submerged parts.
    /// </summary>
    public float Damping
    {
        get { return damping; } 
        set 
        {  
                
            SetArgument("damping", value);
            damping = value;
        } 
    }

    private bool righting = true;
    /// <summary>
    /// Use righting torque to being character face-up in water?
    /// </summary>
    public bool Righting
    {
        get { return righting; } 
        set 
        {  
                
            SetArgument("righting", value);
            righting = value;
        } 
    }

    private float rightingStrength = 25.0f;
    /// <summary>
    /// Strength of righting torque.
    /// </summary>
    public float RightingStrength
    {
        get { return rightingStrength; } 
        set 
        {  
                
            SetArgument("rightingStrength", value);
            rightingStrength = value;
        } 
    }

    private float rightingTime = 1.0f;
    /// <summary>
    /// How long to wait after chest hits water to begin righting torque.
    /// </summary>
    public float RightingTime
    {
        get { return rightingTime; } 
        set 
        {  
                
            SetArgument("rightingTime", value);
            rightingTime = value;
        } 
    }


    public EuphoriaMessageBuoyancy(bool startNow) : base("buoyancy", startNow)
    { }

    public new void Reset()
    {
        surfacePoint = new Vector3(0f,  0f,  0f);
        surfaceNormal = new Vector3(0f,  0f,  1f);
        buoyancy = 1.0f;
        chestBuoyancy = 8.0f;
        damping = 40.0f;
        righting = true;
        rightingStrength = 25.0f;
        rightingTime = 1.0f;
        base.Reset();
    }
}
}
