namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessagePedalLegs : EuphoriaMessage
{
    private bool pedalLeftLeg = true;
    /// <summary>
    /// pedal with this leg or not
    /// </summary>
    public bool PedalLeftLeg
    {
        get { return pedalLeftLeg; } 
        set 
        {  
                
            SetArgument("pedalLeftLeg", value);
            pedalLeftLeg = value;
        } 
    }

    private bool pedalRightLeg = true;
    /// <summary>
    /// pedal with this leg or not
    /// </summary>
    public bool PedalRightLeg
    {
        get { return pedalRightLeg; } 
        set 
        {  
                
            SetArgument("pedalRightLeg", value);
            pedalRightLeg = value;
        } 
    }

    private bool backPedal = false;
    /// <summary>
    /// pedal forwards or backwards
    /// </summary>
    public bool BackPedal
    {
        get { return backPedal; } 
        set 
        {  
                
            SetArgument("backPedal", value);
            backPedal = value;
        } 
    }

    private float radius = 0.250f;
    /// <summary>
    /// base radius of pedal action
    /// </summary>
    public float Radius
    {
        get { return radius; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 2.00f);
            SetArgument("radius", value);
            radius = value;
        } 
    }

    private float angularSpeed = 10.00f;
    /// <summary>
    /// rate of pedaling. If adaptivePedal4Dragging is true then the legsAngularSpeed calculated to match the linear speed of the character can have a maximum value of angularSpeed (this max used to be hard coded to 13.0)
    /// </summary>
    public float AngularSpeed
    {
        get { return angularSpeed; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.00f);
            SetArgument("angularSpeed", value);
            angularSpeed = value;
        } 
    }

    private float legStiffness = 10.00f;
    /// <summary>
    /// stiffness of legs
    /// </summary>
    public float LegStiffness
    {
        get { return legStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.00f, 16.00f);
            SetArgument("legStiffness", value);
            legStiffness = value;
        } 
    }

    private float pedalOffset = 0.00f;
    /// <summary>
    /// Move the centre of the pedal for the left leg up by this amount, the right leg down by this amount
    /// </summary>
    public float PedalOffset
    {
        get { return pedalOffset; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("pedalOffset", value);
            pedalOffset = value;
        } 
    }

    private int randomSeed = 100;
    /// <summary>
    /// Random seed used to generate speed changes
    /// </summary>
    public int RandomSeed
    {
        get { return randomSeed; } 
        set 
        {  
                
            SetArgument("randomSeed", value);
            randomSeed = value;
        } 
    }

    private float speedAsymmetry = 8.00f;
    /// <summary>
    /// Random offset applied per leg to the angular speed to desynchronise the pedaling - set to 0 to disable, otherwise should be set to less than the angularSpeed value.
    /// </summary>
    public float SpeedAsymmetry
    {
        get { return speedAsymmetry; } 
        set 
        {  
            value = MathHelper.Clamp(value, -10.00f, 10.00f);
            SetArgument("speedAsymmetry", value);
            speedAsymmetry = value;
        } 
    }

    private bool adaptivePedal4Dragging = false;
    /// <summary>
    /// Will pedal in the direction of travel (if backPedal = false, against travel if backPedal = true) and with an angular velocity relative to speed upto a maximum of 13(rads/sec).  Use when being dragged by a car.  Overrides angularSpeed.
    /// </summary>
    public bool AdaptivePedal4Dragging
    {
        get { return adaptivePedal4Dragging; } 
        set 
        {  
                
            SetArgument("adaptivePedal4Dragging", value);
            adaptivePedal4Dragging = value;
        } 
    }

    private float angSpeedMultiplier4Dragging = 0.30f;
    /// <summary>
    /// newAngularSpeed = Clamp(angSpeedMultiplier4Dragging * linear_speed/pedalRadius, 0.0, angularSpeed)
    /// </summary>
    public float AngSpeedMultiplier4Dragging
    {
        get { return angSpeedMultiplier4Dragging; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.00f);
            SetArgument("angSpeedMultiplier4Dragging", value);
            angSpeedMultiplier4Dragging = value;
        } 
    }

    private float radiusVariance = 0.40f;
    /// <summary>
    /// 0-1 value used to add variance to the radius value while pedalling, to desynchonize the legs' movement and provide some variety
    /// </summary>
    public float RadiusVariance
    {
        get { return radiusVariance; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("radiusVariance", value);
            radiusVariance = value;
        } 
    }

    private float legAngleVariance = 0.50f;
    /// <summary>
    /// 0-1 value used to vary the angle of the legs from the hips during the pedal
    /// </summary>
    public float LegAngleVariance
    {
        get { return legAngleVariance; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("legAngleVariance", value);
            legAngleVariance = value;
        } 
    }

    private float centreSideways = 0.00f;
    /// <summary>
    /// Move the centre of the pedal for both legs sideways (+ve = right).  NB: not applied to hula.
    /// </summary>
    public float CentreSideways
    {
        get { return centreSideways; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("centreSideways", value);
            centreSideways = value;
        } 
    }

    private float centreForwards = 0.00f;
    /// <summary>
    /// Move the centre of the pedal for both legs forward (or backward -ve)
    /// </summary>
    public float CentreForwards
    {
        get { return centreForwards; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("centreForwards", value);
            centreForwards = value;
        } 
    }

    private float centreUp = 0.00f;
    /// <summary>
    /// Move the centre of the pedal for both legs up (or down -ve)
    /// </summary>
    public float CentreUp
    {
        get { return centreUp; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("centreUp", value);
            centreUp = value;
        } 
    }

    private float ellipse = 1.00f;
    /// <summary>
    /// Turn the circle into an ellipse.  Ellipse has horizontal radius a and vertical radius b.  If ellipse is +ve then a=radius*ellipse and b=radius.  If ellipse is -ve then a=radius and b = radius*ellipse.  0.0 = vertical line of length 2*radius, 0.0:1.0 circle squashed horizontally (vertical radius = radius), 1.0=circle.  -0.001 = horizontal line of length 2*radius, -0.0:-1.0 circle squashed vertically (horizontal radius = radius), -1.0 = circle
    /// </summary>
    public float Ellipse
    {
        get { return ellipse; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("ellipse", value);
            ellipse = value;
        } 
    }

    private float dragReduction = 0.250f;
    /// <summary>
    /// how much to account for the target moving through space rather than being static
    /// </summary>
    public float DragReduction
    {
        get { return dragReduction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("dragReduction", value);
            dragReduction = value;
        } 
    }

    private float spread = 0.00f;
    /// <summary>
    /// Spread legs.
    /// </summary>
    public float Spread
    {
        get { return spread; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("spread", value);
            spread = value;
        } 
    }

    private bool hula = false;
    /// <summary>
    /// If true circle the legs in a hula motion.
    /// </summary>
    public bool Hula
    {
        get { return hula; } 
        set 
        {  
                
            SetArgument("hula", value);
            hula = value;
        } 
    }


    public EuphoriaMessagePedalLegs(bool startNow) : base("pedalLegs", startNow)
    { }

    public new void Reset()
    {
        pedalLeftLeg = true;
        pedalRightLeg = true;
        backPedal = false;
        radius = 0.250f;
        angularSpeed = 10.00f;
        legStiffness = 10.00f;
        pedalOffset = 0.00f;
        randomSeed = 100;
        speedAsymmetry = 8.00f;
        adaptivePedal4Dragging = false;
        angSpeedMultiplier4Dragging = 0.30f;
        radiusVariance = 0.40f;
        legAngleVariance = 0.50f;
        centreSideways = 0.00f;
        centreForwards = 0.00f;
        centreUp = 0.00f;
        ellipse = 1.00f;
        dragReduction = 0.250f;
        spread = 0.00f;
        hula = false;
        base.Reset();
    }
}
}
