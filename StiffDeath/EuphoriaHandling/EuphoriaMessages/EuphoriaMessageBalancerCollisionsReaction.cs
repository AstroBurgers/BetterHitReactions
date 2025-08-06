namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageBalancerCollisionsReaction : EuphoriaMessage
{
    private int numStepsTillSlump = 4;
    /// <summary>
    /// Begin slump and stop stepping after this many steps
    /// </summary>
    public int NumStepsTillSlump
    {
        get { return numStepsTillSlump; } 
        set 
        {  
                
            SetArgument("numStepsTillSlump", value);
            numStepsTillSlump = value;
        } 
    }

    private float stable2SlumpTime = 0.0f;
    /// <summary>
    /// Time after becoming stable leaning against a wall that slump starts
    /// </summary>
    public float Stable2SlumpTime
    {
        get { return stable2SlumpTime; } 
        set 
        {  
                
            SetArgument("stable2SlumpTime", value);
            stable2SlumpTime = value;
        } 
    }

    private float exclusionZone = 0.2f;
    /// <summary>
    /// Steps are ihibited to not go closer to the wall than this (after impact).
    /// </summary>
    public float ExclusionZone
    {
        get { return exclusionZone; } 
        set 
        {  
                
            SetArgument("exclusionZone", value);
            exclusionZone = value;
        } 
    }

    private float footFrictionMultStart = 1.0f;
    /// <summary>
    /// Friction multiplier applied to feet when slump starts
    /// </summary>
    public float FootFrictionMultStart
    {
        get { return footFrictionMultStart; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 4.0f);
            SetArgument("footFrictionMultStart", value);
            footFrictionMultStart = value;
        } 
    }

    private float footFrictionMultRate = 2.0f;
    /// <summary>
    /// Friction multiplier reduced by this amount every second after slump starts (only if character is not slumping)
    /// </summary>
    public float FootFrictionMultRate
    {
        get { return footFrictionMultRate; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 50.0f);
            SetArgument("footFrictionMultRate", value);
            footFrictionMultRate = value;
        } 
    }

    private float backFrictionMultStart = 1.0f;
    /// <summary>
    /// Friction multiplier applied to back when slump starts
    /// </summary>
    public float BackFrictionMultStart
    {
        get { return backFrictionMultStart; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 4.0f);
            SetArgument("backFrictionMultStart", value);
            backFrictionMultStart = value;
        } 
    }

    private float backFrictionMultRate = 2.0f;
    /// <summary>
    /// Friction multiplier reduced by this amount every second after slump starts (only if character is not slumping)
    /// </summary>
    public float BackFrictionMultRate
    {
        get { return backFrictionMultRate; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 50.0f);
            SetArgument("backFrictionMultRate", value);
            backFrictionMultRate = value;
        } 
    }

    private float impactLegStiffReduction = 3.0f;
    /// <summary>
    /// Reduce the stiffness of the legs by this much as soon as an impact is detected
    /// </summary>
    public float ImpactLegStiffReduction
    {
        get { return impactLegStiffReduction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
            SetArgument("impactLegStiffReduction", value);
            impactLegStiffReduction = value;
        } 
    }

    private float slumpLegStiffReduction = 1.0f;
    /// <summary>
    /// Reduce the stiffness of the legs by this much as soon as slump starts
    /// </summary>
    public float SlumpLegStiffReduction
    {
        get { return slumpLegStiffReduction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
            SetArgument("slumpLegStiffReduction", value);
            slumpLegStiffReduction = value;
        } 
    }

    private float slumpLegStiffRate = 8.0f;
    /// <summary>
    /// Rate at which the stiffness of the legs is reduced during slump
    /// </summary>
    public float SlumpLegStiffRate
    {
        get { return slumpLegStiffRate; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 50.0f);
            SetArgument("slumpLegStiffRate", value);
            slumpLegStiffRate = value;
        } 
    }

    private float reactTime = 0.3f;
    /// <summary>
    /// Time that the character reacts to the impact with ub flinch and writhe
    /// </summary>
    public float ReactTime
    {
        get { return reactTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("reactTime", value);
            reactTime = value;
        } 
    }

    private float impactExagTime = 0.3f;
    /// <summary>
    /// Time that the character exaggerates impact with spine
    /// </summary>
    public float ImpactExagTime
    {
        get { return impactExagTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("impactExagTime", value);
            impactExagTime = value;
        } 
    }

    private float glanceSpinTime = 0.5f;
    /// <summary>
    /// Duration that the glance torque is applied for
    /// </summary>
    public float GlanceSpinTime
    {
        get { return glanceSpinTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("glanceSpinTime", value);
            glanceSpinTime = value;
        } 
    }

    private float glanceSpinMag = 50.0f;
    /// <summary>
    /// Magnitude of the glance torque
    /// </summary>
    public float GlanceSpinMag
    {
        get { return glanceSpinMag; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1000.0f);
            SetArgument("glanceSpinMag", value);
            glanceSpinMag = value;
        } 
    }

    private float glanceSpinDecayMult = 0.3f;
    /// <summary>
    /// multiplier used when decaying torque spin over time
    /// </summary>
    public float GlanceSpinDecayMult
    {
        get { return glanceSpinDecayMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("glanceSpinDecayMult", value);
            glanceSpinDecayMult = value;
        } 
    }

    private int ignoreColWithIndex = -2;
    /// <summary>
    /// used so impact with the character that is pushing you over doesn't set off the behaviour
    /// </summary>
    public int IgnoreColWithIndex
    {
        get { return ignoreColWithIndex; } 
        set 
        {  
                
            SetArgument("ignoreColWithIndex", value);
            ignoreColWithIndex = value;
        } 
    }

    private int slumpMode = 1;
    /// <summary>
    /// 0=Normal slump(less movement then slump and movement LT small), 1=fast slump, 2=less movement then slump
    /// </summary>
    public int SlumpMode
    {
        get { return slumpMode; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("slumpMode", value);
            slumpMode = value;
        } 
    }

    private int reboundMode = 0;
    /// <summary>
    /// 0=fall2knees/slump if shot not running, 1=stumble, 2=slump, 3=restart
    /// </summary>
    public int ReboundMode
    {
        get { return reboundMode; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 3);
            SetArgument("reboundMode", value);
            reboundMode = value;
        } 
    }

    private float ignoreColMassBelow = 20.0f;
    /// <summary>
    /// collisions with non-fixed objects with mass below this will not set this behaviour off (e.g. ignore guns)
    /// </summary>
    public float IgnoreColMassBelow
    {
        get { return ignoreColMassBelow; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 1000.0f);
            SetArgument("ignoreColMassBelow", value);
            ignoreColMassBelow = value;
        } 
    }

    private int forwardMode = 0;
    /// <summary>
    /// 0=slump, 1=fallToKnees if shot is running, otherwise slump
    /// </summary>
    public int ForwardMode
    {
        get { return forwardMode; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 1);
            SetArgument("forwardMode", value);
            forwardMode = value;
        } 
    }

    private float timeToForward = 0.50f;
    /// <summary>
    /// time after a forwards impact before forwardMode is called (leave sometime for a rebound or brace - the min of 0.1 is to ensure fallOverWall can start although it probably needs only 1or2 frames for the probes to return)
    /// </summary>
    public float TimeToForward
    {
        get { return timeToForward; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 2.00f);
            SetArgument("timeToForward", value);
            timeToForward = value;
        } 
    }

    private float reboundForce = 0.00f;
    /// <summary>
    /// if forwards impact only: cheat force to try to get the character away from the wall.  3 is a good value.
    /// </summary>
    public float ReboundForce
    {
        get { return reboundForce; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("reboundForce", value);
            reboundForce = value;
        } 
    }

    private bool braceWall = true;
    /// <summary>
    /// Brace against wall if forwards impact(at the moment only if bodyBalance is running/in charge of arms)
    /// </summary>
    public bool BraceWall
    {
        get { return braceWall; } 
        set 
        {  
                
            SetArgument("braceWall", value);
            braceWall = value;
        } 
    }

    private float ignoreColVolumeBelow = 0.1f;
    /// <summary>
    /// collisions with non-fixed objects with volume below this will not set this behaviour off
    /// </summary>
    public float IgnoreColVolumeBelow
    {
        get { return ignoreColVolumeBelow; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 1000.0f);
            SetArgument("ignoreColVolumeBelow", value);
            ignoreColVolumeBelow = value;
        } 
    }

    private bool fallOverWallDrape = true;
    /// <summary>
    /// use fallOverWall as the main drape reaction
    /// </summary>
    public bool FallOverWallDrape
    {
        get { return fallOverWallDrape; } 
        set 
        {  
                
            SetArgument("fallOverWallDrape", value);
            fallOverWallDrape = value;
        } 
    }

    private bool fallOverHighWalls = false;
    /// <summary>
    /// trigger fall over wall if hit up to spine2 else only if hit up to spine1
    /// </summary>
    public bool FallOverHighWalls
    {
        get { return fallOverHighWalls; } 
        set 
        {  
                
            SetArgument("fallOverHighWalls", value);
            fallOverHighWalls = value;
        } 
    }

    private bool snap = false;
    /// <summary>
    /// Add a Snap to when you hit a wall to emphasize the hit.
    /// </summary>
    public bool Snap
    {
        get { return snap; } 
        set 
        {  
                
            SetArgument("snap", value);
            snap = value;
        } 
    }

    private float snapMag = -0.60f;
    /// <summary>
    /// The magnitude of the snap reaction
    /// </summary>
    public float SnapMag
    {
        get { return snapMag; } 
        set 
        {  
            value = MathHelper.Clamp(value, -10.00f, 10.0f);
            SetArgument("snapMag", value);
            snapMag = value;
        } 
    }

    private float snapDirectionRandomness = 0.30f;
    /// <summary>
    /// The character snaps in a prescribed way (decided by bullet direction) - Higher the value the more random this direction is.
    /// </summary>
    public float SnapDirectionRandomness
    {
        get { return snapDirectionRandomness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.0f);
            SetArgument("snapDirectionRandomness", value);
            snapDirectionRandomness = value;
        } 
    }

    private bool snapLeftArm = false;
    /// <summary>
    /// snap the leftArm.
    /// </summary>
    public bool SnapLeftArm
    {
        get { return snapLeftArm; } 
        set 
        {  
                
            SetArgument("snapLeftArm", value);
            snapLeftArm = value;
        } 
    }

    private bool snapRightArm = false;
    /// <summary>
    /// snap the rightArm.
    /// </summary>
    public bool SnapRightArm
    {
        get { return snapRightArm; } 
        set 
        {  
                
            SetArgument("snapRightArm", value);
            snapRightArm = value;
        } 
    }

    private bool snapLeftLeg = false;
    /// <summary>
    /// snap the leftLeg.
    /// </summary>
    public bool SnapLeftLeg
    {
        get { return snapLeftLeg; } 
        set 
        {  
                
            SetArgument("snapLeftLeg", value);
            snapLeftLeg = value;
        } 
    }

    private bool snapRightLeg = false;
    /// <summary>
    /// snap the rightLeg.
    /// </summary>
    public bool SnapRightLeg
    {
        get { return snapRightLeg; } 
        set 
        {  
                
            SetArgument("snapRightLeg", value);
            snapRightLeg = value;
        } 
    }

    private bool snapSpine = true;
    /// <summary>
    /// snap the spine.
    /// </summary>
    public bool SnapSpine
    {
        get { return snapSpine; } 
        set 
        {  
                
            SetArgument("snapSpine", value);
            snapSpine = value;
        } 
    }

    private bool snapNeck = true;
    /// <summary>
    /// snap the neck.
    /// </summary>
    public bool SnapNeck
    {
        get { return snapNeck; } 
        set 
        {  
                
            SetArgument("snapNeck", value);
            snapNeck = value;
        } 
    }

    private bool snapPhasedLegs = true;
    /// <summary>
    /// Legs are either in phase with each other or not
    /// </summary>
    public bool SnapPhasedLegs
    {
        get { return snapPhasedLegs; } 
        set 
        {  
                
            SetArgument("snapPhasedLegs", value);
            snapPhasedLegs = value;
        } 
    }

    private int snapHipType = 0;
    /// <summary>
    /// type of hip reaction 0=none, 1=side2side 2=steplike
    /// </summary>
    public int SnapHipType
    {
        get { return snapHipType; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("snapHipType", value);
            snapHipType = value;
        } 
    }

    private float unSnapInterval = 0.010f;
    /// <summary>
    /// Interval before applying reverse snap
    /// </summary>
    public float UnSnapInterval
    {
        get { return unSnapInterval; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.0f);
            SetArgument("unSnapInterval", value);
            unSnapInterval = value;
        } 
    }

    private float unSnapRatio = 0.70f;
    /// <summary>
    /// The magnitude of the reverse snap
    /// </summary>
    public float UnSnapRatio
    {
        get { return unSnapRatio; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.0f);
            SetArgument("unSnapRatio", value);
            unSnapRatio = value;
        } 
    }

    private bool snapUseTorques = true;
    /// <summary>
    /// use torques to make the snap otherwise use a change in the parts angular velocity
    /// </summary>
    public bool SnapUseTorques
    {
        get { return snapUseTorques; } 
        set 
        {  
                
            SetArgument("snapUseTorques", value);
            snapUseTorques = value;
        } 
    }

    private float impactWeaknessZeroDuration = 0.20f;
    /// <summary>
    /// duration for which the character's upper body stays at minimum stiffness (not quite zero)
    /// </summary>
    public float ImpactWeaknessZeroDuration
    {
        get { return impactWeaknessZeroDuration; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("impactWeaknessZeroDuration", value);
            impactWeaknessZeroDuration = value;
        } 
    }

    private float impactWeaknessRampDuration = 0.010f;
    /// <summary>
    /// duration of the ramp to bring the character's upper body stiffness back to normal levels
    /// </summary>
    public float ImpactWeaknessRampDuration
    {
        get { return impactWeaknessRampDuration; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 10.00f);
            SetArgument("impactWeaknessRampDuration", value);
            impactWeaknessRampDuration = value;
        } 
    }

    private float impactLoosenessAmount = 1.00f;
    /// <summary>
    /// how loose the character is on impact. between 0 and 1
    /// </summary>
    public float ImpactLoosenessAmount
    {
        get { return impactLoosenessAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("impactLoosenessAmount", value);
            impactLoosenessAmount = value;
        } 
    }

    private bool objectBehindVictim = false;
    /// <summary>
    /// detected an object behind a shot victim in the direction of a bullet?
    /// </summary>
    public bool ObjectBehindVictim
    {
        get { return objectBehindVictim; } 
        set 
        {  
                
            SetArgument("objectBehindVictim", value);
            objectBehindVictim = value;
        } 
    }

    private Vector3 objectBehindVictimPos = new(0f,  0f,  0f);
    /// <summary>
    /// the intersection pos of a detected object behind a shot victim in the direction of a bullet
    /// </summary>
    public Vector3 ObjectBehindVictimPos
    {
        get { return objectBehindVictimPos; } 
        set 
        {  
                
            SetArgument("objectBehindVictimPos", value);
            objectBehindVictimPos = value;
        } 
    }

    private Vector3 objectBehindVictimNormal = new(0f,  0f,  0f);
    /// <summary>
    /// the normal of a detected object behind a shot victim in the direction of a bullet
    /// </summary>
    public Vector3 ObjectBehindVictimNormal
    {
        get { return objectBehindVictimNormal; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, -1.00f, 1.00f);
            value.Y = MathHelper.Clamp(value.Y, -1.00f, 1.00f);
            value.Z = MathHelper.Clamp(value.Z, -1.00f, 1.00f);
            SetArgument("objectBehindVictimNormal", value);
            objectBehindVictimNormal = value;
        } 
    }


    public EuphoriaMessageBalancerCollisionsReaction(bool startNow) : base("balancerCollisionsReaction", startNow)
    { }

    public new void Reset()
    {
        numStepsTillSlump = 4;
        stable2SlumpTime = 0.0f;
        exclusionZone = 0.2f;
        footFrictionMultStart = 1.0f;
        footFrictionMultRate = 2.0f;
        backFrictionMultStart = 1.0f;
        backFrictionMultRate = 2.0f;
        impactLegStiffReduction = 3.0f;
        slumpLegStiffReduction = 1.0f;
        slumpLegStiffRate = 8.0f;
        reactTime = 0.3f;
        impactExagTime = 0.3f;
        glanceSpinTime = 0.5f;
        glanceSpinMag = 50.0f;
        glanceSpinDecayMult = 0.3f;
        ignoreColWithIndex = -2;
        slumpMode = 1;
        reboundMode = 0;
        ignoreColMassBelow = 20.0f;
        forwardMode = 0;
        timeToForward = 0.50f;
        reboundForce = 0.00f;
        braceWall = true;
        ignoreColVolumeBelow = 0.1f;
        fallOverWallDrape = true;
        fallOverHighWalls = false;
        snap = false;
        snapMag = -0.60f;
        snapDirectionRandomness = 0.30f;
        snapLeftArm = false;
        snapRightArm = false;
        snapLeftLeg = false;
        snapRightLeg = false;
        snapSpine = true;
        snapNeck = true;
        snapPhasedLegs = true;
        snapHipType = 0;
        unSnapInterval = 0.010f;
        unSnapRatio = 0.70f;
        snapUseTorques = true;
        impactWeaknessZeroDuration = 0.20f;
        impactWeaknessRampDuration = 0.010f;
        impactLoosenessAmount = 1.00f;
        objectBehindVictim = false;
        objectBehindVictimPos = new Vector3(0f,  0f,  0f);
        objectBehindVictimNormal = new Vector3(0f,  0f,  0f);
        base.Reset();
    }
}
}
