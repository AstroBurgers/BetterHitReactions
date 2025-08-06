using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// setCharacterCollisions:
/// </summary>

internal class EuphoriaMessageSetCharacterCollisions : EuphoriaMessage
{
    private float spin = 0.00f;
    /// <summary>
    /// sliding friction turned into spin 80.0 (used in demo videos) good for rest of default params below.  If 0.0 then no collision enhancement
    /// </summary>
    public float Spin
    {
        get { return spin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.00f);
            SetArgument("spin", value);
            spin = value;
        } 
    }

    private float maxVelocity = 8.00f;
    /// <summary>
    /// torque = spin*(relative velocity) up to this maximum for relative velocity
    /// </summary>
    public float MaxVelocity
    {
        get { return maxVelocity; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.00f);
            SetArgument("maxVelocity", value);
            maxVelocity = value;
        } 
    }

    private bool applyToAll = false;
    /// <summary>
    /// 
    /// </summary>
    public bool ApplyToAll
    {
        get { return applyToAll; } 
        set 
        {  
                
            SetArgument("applyToAll", value);
            applyToAll = value;
        } 
    }

    private bool applyToSpine = true;
    /// <summary>
    /// 
    /// </summary>
    public bool ApplyToSpine
    {
        get { return applyToSpine; } 
        set 
        {  
                
            SetArgument("applyToSpine", value);
            applyToSpine = value;
        } 
    }

    private bool applyToThighs = true;
    /// <summary>
    /// 
    /// </summary>
    public bool ApplyToThighs
    {
        get { return applyToThighs; } 
        set 
        {  
                
            SetArgument("applyToThighs", value);
            applyToThighs = value;
        } 
    }

    private bool applyToClavicles = true;
    /// <summary>
    /// 
    /// </summary>
    public bool ApplyToClavicles
    {
        get { return applyToClavicles; } 
        set 
        {  
                
            SetArgument("applyToClavicles", value);
            applyToClavicles = value;
        } 
    }

    private bool applyToUpperArms = true;
    /// <summary>
    /// 
    /// </summary>
    public bool ApplyToUpperArms
    {
        get { return applyToUpperArms; } 
        set 
        {  
                
            SetArgument("applyToUpperArms", value);
            applyToUpperArms = value;
        } 
    }

    private bool footSlip = true;
    /// <summary>
    /// allow foot slipping if collided
    /// </summary>
    public bool FootSlip
    {
        get { return footSlip; } 
        set 
        {  
                
            SetArgument("footSlip", value);
            footSlip = value;
        } 
    }

    private int vehicleClass = 15;
    /// <summary>
    /// ClassType of the object against which to enhance the collision.  All character vehicle interaction (e.g. braceForImpact glancing spins) relies on this value so EDIT WISELY. If it is used for things other than vehicles then NM should be informed.
    /// </summary>
    public int VehicleClass
    {
        get { return vehicleClass; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 100);
            SetArgument("vehicleClass", value);
            vehicleClass = value;
        } 
    }


    public EuphoriaMessageSetCharacterCollisions(bool startNow) : base("setCharacterCollisions", startNow)
    { }

    public new void Reset()
    {
        spin = 0.00f;
        maxVelocity = 8.00f;
        applyToAll = false;
        applyToSpine = true;
        applyToThighs = true;
        applyToClavicles = true;
        applyToUpperArms = true;
        footSlip = true;
        vehicleClass = 15;
        base.Reset();
    }
}
}
