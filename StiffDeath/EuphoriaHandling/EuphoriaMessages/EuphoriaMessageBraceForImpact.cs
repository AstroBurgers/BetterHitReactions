using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageBraceForImpact : EuphoriaMessage
{
    private float braceDistance = 0.50f;
    /// <summary>
    /// distance from object at which to raise hands to brace 0.5 good if newBrace=true - otherwise 0.65
    /// </summary>
    public float BraceDistance
    {
        get { return braceDistance; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("braceDistance", value);
            braceDistance = value;
        } 
    }

    private float targetPredictionTime = 0.450f;
    /// <summary>
    /// time epected to get arms up from idle
    /// </summary>
    public float TargetPredictionTime
    {
        get { return targetPredictionTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("targetPredictionTime", value);
            targetPredictionTime = value;
        } 
    }

    private float reachAbsorbtionTime = 0.150f;
    /// <summary>
    /// larger values and he absorbs the impact more
    /// </summary>
    public float ReachAbsorbtionTime
    {
        get { return reachAbsorbtionTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("reachAbsorbtionTime", value);
            reachAbsorbtionTime = value;
        } 
    }

    private int instanceIndex = -1;
    /// <summary>
    /// levelIndex of object to brace
    /// </summary>
    public int InstanceIndex
    {
        get { return instanceIndex; } 
        set 
        {  
                
            SetArgument("instanceIndex", value);
            instanceIndex = value;
        } 
    }

    private float bodyStiffness = 12.00f;
    /// <summary>
    /// stiffness of character. catch_fall stiffness scales with this too, with its defaults at this values default
    /// </summary>
    public float BodyStiffness
    {
        get { return bodyStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.00f, 16.00f);
            SetArgument("bodyStiffness", value);
            bodyStiffness = value;
        } 
    }

    private bool grabDontLetGo = false;
    /// <summary>
    /// Once a constraint is made, keep reaching with whatever hand is allowed
    /// </summary>
    public bool GrabDontLetGo
    {
        get { return grabDontLetGo; } 
        set 
        {  
                
            SetArgument("grabDontLetGo", value);
            grabDontLetGo = value;
        } 
    }

    private float grabStrength = 40.00f;
    /// <summary>
    /// strength in hands for grabbing (kg m/s), -1 to ignore/disable
    /// </summary>
    public float GrabStrength
    {
        get { return grabStrength; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1000.00f);
            SetArgument("grabStrength", value);
            grabStrength = value;
        } 
    }

    private float grabDistance = 2.00f;
    /// <summary>
    /// Relative distance at which the grab starts.
    /// </summary>
    public float GrabDistance
    {
        get { return grabDistance; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 4.00f);
            SetArgument("grabDistance", value);
            grabDistance = value;
        } 
    }

    private float grabReachAngle = 1.50f;
    /// <summary>
    /// Angle from front at which the grab activates. If the point is outside this angle from front will not try to grab.
    /// </summary>
    public float GrabReachAngle
    {
        get { return grabReachAngle; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 3.160f);
            SetArgument("grabReachAngle", value);
            grabReachAngle = value;
        } 
    }

    private float grabHoldTimer = 2.50f;
    /// <summary>
    /// amount of time, in seconds, before grab automatically bails
    /// </summary>
    public float GrabHoldTimer
    {
        get { return grabHoldTimer; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("grabHoldTimer", value);
            grabHoldTimer = value;
        } 
    }

    private float maxGrabCarVelocity = 95.00f;
    /// <summary>
    /// Don't try to grab a car moving above this speed mmmmtodo make this the relative velocity of car to character?
    /// </summary>
    public float MaxGrabCarVelocity
    {
        get { return maxGrabCarVelocity; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1000.00f);
            SetArgument("maxGrabCarVelocity", value);
            maxGrabCarVelocity = value;
        } 
    }

    private float legStiffness = 12.00f;
    /// <summary>
    /// Balancer leg stiffness mmmmtodo remove this parameter and use configureBalance?
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

    private float timeToBackwardsBrace = 1.00f;
    /// <summary>
    /// time before arm brace kicks in when hit from behind
    /// </summary>
    public float TimeToBackwardsBrace
    {
        get { return timeToBackwardsBrace; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("timeToBackwardsBrace", value);
            timeToBackwardsBrace = value;
        } 
    }

    private Vector3 look = new(0f,  0f,  0f);
    /// <summary>
    /// position to look at, e.g. the driver
    /// </summary>
    public Vector3 Look
    {
        get { return look; } 
        set 
        {  
                
            SetArgument("look", value);
            look = value;
        } 
    }

    private Vector3 pos = new(0f,  0f,  0f);
    /// <summary>
    /// location of the front part of the object to brace against. This should be the centre of where his hands should meet the object
    /// </summary>
    public Vector3 Pos
    {
        get { return pos; } 
        set 
        {  
                
            SetArgument("pos", value);
            pos = value;
        } 
    }

    private float minBraceTime = 0.30f;
    /// <summary>
    /// minimum bracing time so the character doesn't look twitchy
    /// </summary>
    public float MinBraceTime
    {
        get { return minBraceTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 3.00f);
            SetArgument("minBraceTime", value);
            minBraceTime = value;
        } 
    }

    private float handsDelayMin = 0.10f;
    /// <summary>
    /// If bracing with 2 hands delay one hand by at least this amount of time to introduce some asymmetry.
    /// </summary>
    public float HandsDelayMin
    {
        get { return handsDelayMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 3.00f);
            SetArgument("handsDelayMin", value);
            handsDelayMin = value;
        } 
    }

    private float handsDelayMax = 0.30f;
    /// <summary>
    /// If bracing with 2 hands delay one hand by at most this amount of time to introduce some asymmetry.
    /// </summary>
    public float HandsDelayMax
    {
        get { return handsDelayMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 3.00f);
            SetArgument("handsDelayMax", value);
            handsDelayMax = value;
        } 
    }

    private bool moveAway = false;
    /// <summary>
    /// move away from the car (if in reaching zone)
    /// </summary>
    public bool MoveAway
    {
        get { return moveAway; } 
        set 
        {  
                
            SetArgument("moveAway", value);
            moveAway = value;
        } 
    }

    private float moveAwayAmount = 0.10f;
    /// <summary>
    /// forceLean away amount (-ve is lean towards)
    /// </summary>
    public float MoveAwayAmount
    {
        get { return moveAwayAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("moveAwayAmount", value);
            moveAwayAmount = value;
        } 
    }

    private float moveAwayLean = 0.050f;
    /// <summary>
    /// Lean away amount (-ve is lean towards)
    /// </summary>
    public float MoveAwayLean
    {
        get { return moveAwayLean; } 
        set 
        {  
            value = MathHelper.Clamp(value, -0.5f, 0.5f);
            SetArgument("moveAwayLean", value);
            moveAwayLean = value;
        } 
    }

    private float moveSideways = 0.30f;
    /// <summary>
    /// Amount of sideways movement if at the front or back of the car to add to the move away from car
    /// </summary>
    public float MoveSideways
    {
        get { return moveSideways; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("moveSideways", value);
            moveSideways = value;
        } 
    }

    private bool bbArms = false;
    /// <summary>
    /// Use bodyBalance arms for the default (non bracing) behaviour if bodyBalance is active
    /// </summary>
    public bool BbArms
    {
        get { return bbArms; } 
        set 
        {  
                
            SetArgument("bbArms", value);
            bbArms = value;
        } 
    }

    private bool newBrace = true;
    /// <summary>
    /// Use the new brace prediction code
    /// </summary>
    public bool NewBrace
    {
        get { return newBrace; } 
        set 
        {  
                
            SetArgument("newBrace", value);
            newBrace = value;
        } 
    }

    private bool braceOnImpact = false;
    /// <summary>
    /// If true then if a shin or thigh is in contact with the car then brace. NB: newBrace must be true.  For those situations where the car has pushed the ped backwards (at the same speed as the car) before the behaviour has been started and so doesn't predict an impact.
    /// </summary>
    public bool BraceOnImpact
    {
        get { return braceOnImpact; } 
        set 
        {  
                
            SetArgument("braceOnImpact", value);
            braceOnImpact = value;
        } 
    }

    private bool roll2Velocity = false;
    /// <summary>
    /// When rollDownStairs is running use roll2Velocity to control the helper torques (this only attempts to roll to the chaarcter's velocity not some default linear velocity mag
    /// </summary>
    public bool Roll2Velocity
    {
        get { return roll2Velocity; } 
        set 
        {  
                
            SetArgument("roll2Velocity", value);
            roll2Velocity = value;
        } 
    }

    private int rollType = 3;
    /// <summary>
    /// 0 = original/roll off/stay on car:  Roll with character velocity, 1 = //Gentle: roll off/stay on car = use relative velocity of character to car to roll against, 2 = //roll over car:  Roll against character velocity.  i.e. roll against any velocity picked up by hitting car, 3 = //Gentle: roll over car:  use relative velocity of character to car to roll with
    /// </summary>
    public int RollType
    {
        get { return rollType; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 3);
            SetArgument("rollType", value);
            rollType = value;
        } 
    }

    private bool snapImpacts = false;
    /// <summary>
    /// Exaggerate impacts using snap
    /// </summary>
    public bool SnapImpacts
    {
        get { return snapImpacts; } 
        set 
        {  
                
            SetArgument("snapImpacts", value);
            snapImpacts = value;
        } 
    }

    private float snapImpact = 7.00f;
    /// <summary>
    /// Exaggeration amount of the initial impact (legs).  +ve fold with car impact (as if pushed at hips in the car velocity direction).  -ve fold away from car impact
    /// </summary>
    public float SnapImpact
    {
        get { return snapImpact; } 
        set 
        {  
            value = MathHelper.Clamp(value, -20.00f, 20.00f);
            SetArgument("snapImpact", value);
            snapImpact = value;
        } 
    }

    private float snapBonnet = -7.00f;
    /// <summary>
    /// Exaggeration amount of the secondary (torso) impact with bonnet. +ve fold with car impact (as if pushed at hips by the impact normal).  -ve fold away from car impact
    /// </summary>
    public float SnapBonnet
    {
        get { return snapBonnet; } 
        set 
        {  
            value = MathHelper.Clamp(value, -20.00f, 20.00f);
            SetArgument("snapBonnet", value);
            snapBonnet = value;
        } 
    }

    private float snapFloor = 7.00f;
    /// <summary>
    /// Exaggeration amount of the impact with the floor after falling off of car +ve fold with floor impact (as if pushed at hips in the impact normal direction).  -ve fold away from car impact
    /// </summary>
    public float SnapFloor
    {
        get { return snapFloor; } 
        set 
        {  
            value = MathHelper.Clamp(value, -20.00f, 20.00f);
            SetArgument("snapFloor", value);
            snapFloor = value;
        } 
    }

    private bool dampVel = false;
    /// <summary>
    /// Damp out excessive spin and upward velocity when on car
    /// </summary>
    public bool DampVel
    {
        get { return dampVel; } 
        set 
        {  
                
            SetArgument("dampVel", value);
            dampVel = value;
        } 
    }

    private float dampSpin = 0.00f;
    /// <summary>
    /// Amount to damp spinning by (cartwheeling and somersaulting)
    /// </summary>
    public float DampSpin
    {
        get { return dampSpin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 40.00f);
            SetArgument("dampSpin", value);
            dampSpin = value;
        } 
    }

    private float dampUpVel = 10.00f;
    /// <summary>
    /// Amount to damp upward velocity by to limit the amount of air above the car the character can get.
    /// </summary>
    public float DampUpVel
    {
        get { return dampUpVel; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 40.00f);
            SetArgument("dampUpVel", value);
            dampUpVel = value;
        } 
    }

    private float dampSpinThresh = 4.00f;
    /// <summary>
    /// Angular velocity above which we start damping
    /// </summary>
    public float DampSpinThresh
    {
        get { return dampSpinThresh; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.00f);
            SetArgument("dampSpinThresh", value);
            dampSpinThresh = value;
        } 
    }

    private float dampUpVelThresh = 2.00f;
    /// <summary>
    /// Upward velocity above which we start damping
    /// </summary>
    public float DampUpVelThresh
    {
        get { return dampUpVelThresh; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.00f);
            SetArgument("dampUpVelThresh", value);
            dampUpVelThresh = value;
        } 
    }

    private bool gsHelp = false;
    /// <summary>
    /// Enhance a glancing spin with the side of the car by modulating body friction.
    /// </summary>
    public bool GsHelp
    {
        get { return gsHelp; } 
        set 
        {  
                
            SetArgument("gsHelp", value);
            gsHelp = value;
        } 
    }

    private float gsEndMin = -0.10f;
    /// <summary>
    /// ID for glancing spin. min depth to be considered from either end (front/rear) of a car (-ve is inside the car area)
    /// </summary>
    public float GsEndMin
    {
        get { return gsEndMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, -10.00f, 1.00f);
            SetArgument("gsEndMin", value);
            gsEndMin = value;
        } 
    }

    private float gsSideMin = -0.20f;
    /// <summary>
    /// ID for glancing spin. min depth to be considered on the side of a car (-ve is inside the car area)
    /// </summary>
    public float GsSideMin
    {
        get { return gsSideMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, -10.00f, 1.00f);
            SetArgument("gsSideMin", value);
            gsSideMin = value;
        } 
    }

    private float gsSideMax = 0.50f;
    /// <summary>
    /// ID for glancing spin. max depth to be considered on the side of a car (+ve is outside the car area)
    /// </summary>
    public float GsSideMax
    {
        get { return gsSideMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, -10.00f, 1.00f);
            SetArgument("gsSideMax", value);
            gsSideMax = value;
        } 
    }

    private float gsUpness = 0.90f;
    /// <summary>
    /// ID for glancing spin. Character has to be more upright than this value for it to be considered on the side of a car. Fully upright = 1, upsideDown = -1.  Max Angle from upright is acos(gsUpness)
    /// </summary>
    public float GsUpness
    {
        get { return gsUpness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("gsUpness", value);
            gsUpness = value;
        } 
    }

    private float gsCarVelMin = 3.00f;
    /// <summary>
    /// ID for glancing spin. Minimum car velocity.
    /// </summary>
    public float GsCarVelMin
    {
        get { return gsCarVelMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("gsCarVelMin", value);
            gsCarVelMin = value;
        } 
    }

    private bool gsScale1Foot = true;
    /// <summary>
    /// Apply gsFricScale1 to the foot if colliding with car.  (Otherwise foot friction - with the ground - is determined by gsFricScale2 if it is in gsFricMask2)
    /// </summary>
    public bool GsScale1Foot
    {
        get { return gsScale1Foot; } 
        set 
        {  
                
            SetArgument("gsScale1Foot", value);
            gsScale1Foot = value;
        } 
    }

    private float gsFricScale1 = 8.00f;
    /// <summary>
    /// Glancing spin help. Friction scale applied when to the side of the car.  e.g. make the character spin more by upping the friction against the car
    /// </summary>
    public float GsFricScale1
    {
        get { return gsFricScale1; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("gsFricScale1", value);
            gsFricScale1 = value;
        } 
    }

    private string gsFricMask1 = "fb";
    /// <summary>
    /// Glancing spin help. Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value  (see notes for explanation). Note gsFricMask1 and gsFricMask2 are made independent by the code so you can have fb for gsFricMask1 but gsFricScale1 will not be applied to any bodyParts in gsFricMask2
    /// </summary>
    public string GsFricMask1
    {
        get { return gsFricMask1; } 
        set 
        {  
                
            SetArgument("gsFricMask1", value);
            gsFricMask1 = value;
        } 
    }

    private float gsFricScale2 = 0.20f;
    /// <summary>
    /// Glancing spin help. Friction scale applied when to the side of the car.  e.g. make the character spin more by lowering the feet friction. You could also lower the wrist friction here to stop the car pulling along the hands i.e. gsFricMask2 = la|uw
    /// </summary>
    public float GsFricScale2
    {
        get { return gsFricScale2; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("gsFricScale2", value);
            gsFricScale2 = value;
        } 
    }

    private string gsFricMask2 = "la";
    /// <summary>
    /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value  (see notes for explanation). Note gsFricMask1 and gsFricMask2 are made independent by the code so you can have fb for gsFricMask1 but gsFricScale1 will not be applied to any bodyParts in gsFricMask2
    /// </summary>
    public string GsFricMask2
    {
        get { return gsFricMask2; } 
        set 
        {  
                
            SetArgument("gsFricMask2", value);
            gsFricMask2 = value;
        } 
    }


    public EuphoriaMessageBraceForImpact(bool startNow) : base("braceForImpact", startNow)
    { }

    public new void Reset()
    {
        braceDistance = 0.50f;
        targetPredictionTime = 0.450f;
        reachAbsorbtionTime = 0.150f;
        instanceIndex = -1;
        bodyStiffness = 12.00f;
        grabDontLetGo = false;
        grabStrength = 40.00f;
        grabDistance = 2.00f;
        grabReachAngle = 1.50f;
        grabHoldTimer = 2.50f;
        maxGrabCarVelocity = 95.00f;
        legStiffness = 12.00f;
        timeToBackwardsBrace = 1.00f;
        look = new Vector3(0f,  0f,  0f);
        pos = new Vector3(0f,  0f,  0f);
        minBraceTime = 0.30f;
        handsDelayMin = 0.10f;
        handsDelayMax = 0.30f;
        moveAway = false;
        moveAwayAmount = 0.10f;
        moveAwayLean = 0.050f;
        moveSideways = 0.30f;
        bbArms = false;
        newBrace = true;
        braceOnImpact = false;
        roll2Velocity = false;
        rollType = 3;
        snapImpacts = false;
        snapImpact = 7.00f;
        snapBonnet = -7.00f;
        snapFloor = 7.00f;
        dampVel = false;
        dampSpin = 0.00f;
        dampUpVel = 10.00f;
        dampSpinThresh = 4.00f;
        dampUpVelThresh = 2.00f;
        gsHelp = false;
        gsEndMin = -0.10f;
        gsSideMin = -0.20f;
        gsSideMax = 0.50f;
        gsUpness = 0.90f;
        gsCarVelMin = 3.00f;
        gsScale1Foot = true;
        gsFricScale1 = 8.00f;
        gsFricMask1 = "fb";
        gsFricScale2 = 0.20f;
        gsFricMask2 = "la";
        base.Reset();
    }
}
}
