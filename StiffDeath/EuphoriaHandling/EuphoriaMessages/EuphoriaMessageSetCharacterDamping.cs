namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// setCharacterDamping:  Damp out cartwheeling and somersaulting above a certain threshold
/// </summary>

internal class EuphoriaMessageSetCharacterDamping : EuphoriaMessage
{
    private float somersaultThresh = 34.00f;
    /// <summary>
    /// Somersault AngularMomentum measure above which we start damping - try 34.0.  Falling over straight backwards gives 54 on hitting ground.
    /// </summary>
    public float SomersaultThresh
    {
        get { return somersaultThresh; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 200.00f);
            SetArgument("somersaultThresh", value);
            somersaultThresh = value;
        } 
    }

    private float somersaultDamp = 0.00f;
    /// <summary>
    /// Amount to damp somersaulting by (spinning around left/right axis) - try 0.45
    /// </summary>
    public float SomersaultDamp
    {
        get { return somersaultDamp; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("somersaultDamp", value);
            somersaultDamp = value;
        } 
    }

    private float cartwheelThresh = 27.00f;
    /// <summary>
    /// Cartwheel AngularMomentum measure above which we start damping - try 27.0
    /// </summary>
    public float CartwheelThresh
    {
        get { return cartwheelThresh; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 200.00f);
            SetArgument("cartwheelThresh", value);
            cartwheelThresh = value;
        } 
    }

    private float cartwheelDamp = 0.00f;
    /// <summary>
    /// Amount to damp somersaulting by (spinning around front/back axis) - try 0.8
    /// </summary>
    public float CartwheelDamp
    {
        get { return cartwheelDamp; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("cartwheelDamp", value);
            cartwheelDamp = value;
        } 
    }

    private float vehicleCollisionTime = 0.00f;
    /// <summary>
    /// Time after impact with a vehicle to apply characterDamping. -ve values mean always apply whether collided with vehicle or not. =0.0 never apply. =timestep apply for only that frame.  A typical roll from being hit by a car lasts about 4secs.
    /// </summary>
    public float VehicleCollisionTime
    {
        get { return vehicleCollisionTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1000.00f);
            SetArgument("vehicleCollisionTime", value);
            vehicleCollisionTime = value;
        } 
    }

    private bool v2 = false;
    /// <summary>
    /// If true damping is proportional to Angular momentum squared.  If false proportional to Angular momentum
    /// </summary>
    public bool V2
    {
        get { return v2; } 
        set 
        {  
                
            SetArgument("v2", value);
            v2 = value;
        } 
    }


    public EuphoriaMessageSetCharacterDamping(bool startNow) : base("setCharacterDamping", startNow)
    { }

    public new void Reset()
    {
        somersaultThresh = 34.00f;
        somersaultDamp = 0.00f;
        cartwheelThresh = 27.00f;
        cartwheelDamp = 0.00f;
        vehicleCollisionTime = 0.00f;
        v2 = false;
        base.Reset();
    }
}
}
