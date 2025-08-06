namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// setFallingReaction:  Sets the type of reaction if catchFall is called
/// </summary>

internal class EuphoriaMessageSetFallingReaction : EuphoriaMessage
{
    private bool handsAndKnees = false;
    /// <summary>
    /// set to true to get handsAndKnees catchFall if catchFall called. If true allows the dynBalancer to stay on during the catchfall and modifies the catch fall to give a more alive looking performance (hands and knees for front landing or sitting up for back landing)
    /// </summary>
    public bool HandsAndKnees
    {
        get { return handsAndKnees; } 
        set 
        {  
                
            SetArgument("handsAndKnees", value);
            handsAndKnees = value;
        } 
    }

    private bool callRDS = false;
    /// <summary>
    /// If true catchFall will call rollDownstairs if comVel GT comVelRDSThresh - prevents excessive sliding in catchFall.  Was previously only true for handsAndKnees
    /// </summary>
    public bool CallRDS
    {
        get { return callRDS; } 
        set 
        {  
                
            SetArgument("callRDS", value);
            callRDS = value;
        } 
    }

    private float comVelRDSThresh = 2.00f;
    /// <summary>
    /// comVel above which rollDownstairs will start - prevents excessive sliding in catchFall
    /// </summary>
    public float ComVelRDSThresh
    {
        get { return comVelRDSThresh; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.00f);
            SetArgument("comVelRDSThresh", value);
            comVelRDSThresh = value;
        } 
    }

    private bool resistRolling = false;
    /// <summary>
    /// For rds catchFall only: True to resist rolling motion (rolling motion is set off by ub contact and a sliding velocity), false to allow more of a continuous rolling  (rolling motion is set off at a sliding velocity)
    /// </summary>
    public bool ResistRolling
    {
        get { return resistRolling; } 
        set 
        {  
                
            SetArgument("resistRolling", value);
            resistRolling = value;
        } 
    }

    private float armReduceSpeed = 2.50f;
    /// <summary>
    /// Strength is reduced in the catchFall when the arms contact the ground.  0.2 is good for handsAndKnees.  2.5 is good for normal catchFall, anything lower than 1.0 for normal catchFall may lead to bad catchFall poses.
    /// </summary>
    public float ArmReduceSpeed
    {
        get { return armReduceSpeed; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("armReduceSpeed", value);
            armReduceSpeed = value;
        } 
    }

    private float reachLengthMultiplier = 1.00f;
    /// <summary>
    /// Reach length multiplier that scales characters arm topological length, value in range from (0, 1 GT  where 1.0 means reach length is maximum.
    /// </summary>
    public float ReachLengthMultiplier
    {
        get { return reachLengthMultiplier; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.30f, 1.00f);
            SetArgument("reachLengthMultiplier", value);
            reachLengthMultiplier = value;
        } 
    }

    private float inhibitRollingTime = 0.20f;
    /// <summary>
    /// Time after hitting ground that the catchFall can call rds
    /// </summary>
    public float InhibitRollingTime
    {
        get { return inhibitRollingTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("inhibitRollingTime", value);
            inhibitRollingTime = value;
        } 
    }

    private float changeFrictionTime = 0.20f;
    /// <summary>
    /// Time after hitting ground that the catchFall can change the friction of parts to inhibit sliding
    /// </summary>
    public float ChangeFrictionTime
    {
        get { return changeFrictionTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("changeFrictionTime", value);
            changeFrictionTime = value;
        } 
    }

    private float groundFriction = 1.00f;
    /// <summary>
    /// 8.0 was used on yanked) Friction multiplier on bodyParts when on ground.  Character can look too slidy with groundFriction = 1.  Higher values give a more jerky reation but this seems timestep dependent especially for dragged by the feet.
    /// </summary>
    public float GroundFriction
    {
        get { return groundFriction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("groundFriction", value);
            groundFriction = value;
        } 
    }

    private float frictionMin = 0.00f;
    /// <summary>
    /// Min Friction of an impact with a body part (not head, hands or feet) - to increase friction of slippy environment to get character to roll better.  Applied in catchFall and rollUp(rollDownStairs)
    /// </summary>
    public float FrictionMin
    {
        get { return frictionMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("frictionMin", value);
            frictionMin = value;
        } 
    }

    private float frictionMax = 9999.00f;
    /// <summary>
    /// Max Friction of an impact with a body part (not head, hands or feet) - to increase friction of slippy environment to get character to roll better.  Applied in catchFall and rollUp(rollDownStairs)
    /// </summary>
    public float FrictionMax
    {
        get { return frictionMax; } 
        set 
        {  
                
            SetArgument("frictionMax", value);
            frictionMax = value;
        } 
    }

    private bool stopOnSlopes = false;
    /// <summary>
    /// Apply tactics to help stop on slopes.
    /// </summary>
    public bool StopOnSlopes
    {
        get { return stopOnSlopes; } 
        set 
        {  
                
            SetArgument("stopOnSlopes", value);
            stopOnSlopes = value;
        } 
    }

    private float stopManual = 0.00f;
    /// <summary>
    /// Override slope value to manually force stopping on flat ground.  Encourages character to come to rest face down or face up.
    /// </summary>
    public float StopManual
    {
        get { return stopManual; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("stopManual", value);
            stopManual = value;
        } 
    }

    private float stoppedStrengthDecay = 5.00f;
    /// <summary>
    /// Speed at which strength reduces when stopped.
    /// </summary>
    public float StoppedStrengthDecay
    {
        get { return stoppedStrengthDecay; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.00f);
            SetArgument("stoppedStrengthDecay", value);
            stoppedStrengthDecay = value;
        } 
    }

    private float spineLean1Offset = 0.00f;
    /// <summary>
    /// Bias spine post towards hunched (away from arched).
    /// </summary>
    public float SpineLean1Offset
    {
        get { return spineLean1Offset; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("spineLean1Offset", value);
            spineLean1Offset = value;
        } 
    }

    private bool riflePose = false;
    /// <summary>
    /// Hold rifle in a safe position to reduce complications with collision.  Only applied if holding a rifle
    /// </summary>
    public bool RiflePose
    {
        get { return riflePose; } 
        set 
        {  
                
            SetArgument("riflePose", value);
            riflePose = value;
        } 
    }

    private bool hkHeadAvoid = true;
    /// <summary>
    /// Enable head ground avoidance when handsAndKnees is true.
    /// </summary>
    public bool HkHeadAvoid
    {
        get { return hkHeadAvoid; } 
        set 
        {  
                
            SetArgument("hkHeadAvoid", value);
            hkHeadAvoid = value;
        } 
    }

    private bool antiPropClav = false;
    /// <summary>
    /// Discourage the character getting stuck propped up by elbows when falling backwards - by inhibiting backwards moving clavicles (keeps the arms slightly wider)
    /// </summary>
    public bool AntiPropClav
    {
        get { return antiPropClav; } 
        set 
        {  
                
            SetArgument("antiPropClav", value);
            antiPropClav = value;
        } 
    }

    private bool antiPropWeak = false;
    /// <summary>
    /// Discourage the character getting stuck propped up by elbows when falling backwards - by weakening the arms as soon they hit the floor.  (Also stops the hands lifting up when flat on back)
    /// </summary>
    public bool AntiPropWeak
    {
        get { return antiPropWeak; } 
        set 
        {  
                
            SetArgument("antiPropWeak", value);
            antiPropWeak = value;
        } 
    }

    private bool headAsWeakAsArms = true;
    /// <summary>
    /// Head weakens as arms weaken. If false and antiPropWeak when falls onto back doesn't loosen neck so early (matches bodyStrength instead)
    /// </summary>
    public bool HeadAsWeakAsArms
    {
        get { return headAsWeakAsArms; } 
        set 
        {  
                
            SetArgument("headAsWeakAsArms", value);
            headAsWeakAsArms = value;
        } 
    }

    private float successStrength = 1.00f;
    /// <summary>
    /// When bodyStrength is less than successStrength send a success feedback - DO NOT GO OUTSIDE MIN/MAX PARAMETER VALUES OTHERWISE NO SUCCESS FEEDBACK WILL BE SENT
    /// </summary>
    public float SuccessStrength
    {
        get { return successStrength; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.30f, 1.00f);
            SetArgument("successStrength", value);
            successStrength = value;
        } 
    }


    public EuphoriaMessageSetFallingReaction(bool startNow) : base("setFallingReaction", startNow)
    { }

    public new void Reset()
    {
        handsAndKnees = false;
        callRDS = false;
        comVelRDSThresh = 2.00f;
        resistRolling = false;
        armReduceSpeed = 2.50f;
        reachLengthMultiplier = 1.00f;
        inhibitRollingTime = 0.20f;
        changeFrictionTime = 0.20f;
        groundFriction = 1.00f;
        frictionMin = 0.00f;
        frictionMax = 9999.00f;
        stopOnSlopes = false;
        stopManual = 0.00f;
        stoppedStrengthDecay = 5.00f;
        spineLean1Offset = 0.00f;
        riflePose = false;
        hkHeadAvoid = true;
        antiPropClav = false;
        antiPropWeak = false;
        headAsWeakAsArms = true;
        successStrength = 1.00f;
        base.Reset();
    }
}
}
