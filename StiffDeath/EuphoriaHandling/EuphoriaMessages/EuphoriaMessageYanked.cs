using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageYanked : EuphoriaMessage
{
    private float armStiffness = 11.0f;
    /// <summary>
    /// stiffness of arms when upright.
    /// </summary>
    public float ArmStiffness
    {
        get { return armStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("armStiffness", value);
            armStiffness = value;
        } 
    }

    private float armDamping = 1.0f;
    /// <summary>
    /// Sets damping value for the arms when upright.
    /// </summary>
    public float ArmDamping
    {
        get { return armDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("armDamping", value);
            armDamping = value;
        } 
    }

    private float spineDamping = 1.0f;
    /// <summary>
    /// Spine Damping when upright.
    /// </summary>
    public float SpineDamping
    {
        get { return spineDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("spineDamping", value);
            spineDamping = value;
        } 
    }

    private float spineStiffness = 10.0f;
    /// <summary>
    /// Spine Stiffness  when upright..
    /// </summary>
    public float SpineStiffness
    {
        get { return spineStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("spineStiffness", value);
            spineStiffness = value;
        } 
    }

    private float armStiffnessStart = 3.0f;
    /// <summary>
    /// armStiffness during the yanked timescale ie timeAtStartValues
    /// </summary>
    public float ArmStiffnessStart
    {
        get { return armStiffnessStart; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
            SetArgument("armStiffnessStart", value);
            armStiffnessStart = value;
        } 
    }

    private float armDampingStart = 0.1f;
    /// <summary>
    /// armDamping during the yanked timescale ie timeAtStartValues
    /// </summary>
    public float ArmDampingStart
    {
        get { return armDampingStart; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("armDampingStart", value);
            armDampingStart = value;
        } 
    }

    private float spineDampingStart = 0.1f;
    /// <summary>
    /// spineDamping during the yanked timescale ie timeAtStartValues
    /// </summary>
    public float SpineDampingStart
    {
        get { return spineDampingStart; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("spineDampingStart", value);
            spineDampingStart = value;
        } 
    }

    private float spineStiffnessStart = 3.0f;
    /// <summary>
    /// spineStiffness during the yanked timescale ie timeAtStartValues
    /// </summary>
    public float SpineStiffnessStart
    {
        get { return spineStiffnessStart; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
            SetArgument("spineStiffnessStart", value);
            spineStiffnessStart = value;
        } 
    }

    private float timeAtStartValues = 0.4f;
    /// <summary>
    /// time spent with Start values for arms and spine stiffness and damping ie for whiplash efffect
    /// </summary>
    public float TimeAtStartValues
    {
        get { return timeAtStartValues; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("timeAtStartValues", value);
            timeAtStartValues = value;
        } 
    }

    private float rampTimeFromStartValues = 0.1f;
    /// <summary>
    /// time spent ramping from Start to end values for arms and spine stiffness and damping ie for whiplash efffect (occurs after timeAtStartValues)
    /// </summary>
    public float RampTimeFromStartValues
    {
        get { return rampTimeFromStartValues; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("rampTimeFromStartValues", value);
            rampTimeFromStartValues = value;
        } 
    }

    private int stepsTillStartEnd = 2;
    /// <summary>
    /// steps taken before lowerBodyStiffness starts ramping down
    /// </summary>
    public int StepsTillStartEnd
    {
        get { return stepsTillStartEnd; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 100);
            SetArgument("stepsTillStartEnd", value);
            stepsTillStartEnd = value;
        } 
    }

    private float timeStartEnd = 100.0f;
    /// <summary>
    /// time from start of behaviour before lowerBodyStiffness starts ramping down by perStepReduction1
    /// </summary>
    public float TimeStartEnd
    {
        get { return timeStartEnd; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 100.0f);
            SetArgument("timeStartEnd", value);
            timeStartEnd = value;
        } 
    }

    private float rampTimeToEndValues = 0.0f;
    /// <summary>
    /// time spent ramping from lowerBodyStiffness to lowerBodyStiffnessEnd
    /// </summary>
    public float RampTimeToEndValues
    {
        get { return rampTimeToEndValues; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("rampTimeToEndValues", value);
            rampTimeToEndValues = value;
        } 
    }

    private float lowerBodyStiffness = 12.0f;
    /// <summary>
    /// lowerBodyStiffness should be 12
    /// </summary>
    public float LowerBodyStiffness
    {
        get { return lowerBodyStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
            SetArgument("lowerBodyStiffness", value);
            lowerBodyStiffness = value;
        } 
    }

    private float lowerBodyStiffnessEnd = 8.0f;
    /// <summary>
    /// lowerBodyStiffness at end
    /// </summary>
    public float LowerBodyStiffnessEnd
    {
        get { return lowerBodyStiffnessEnd; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
            SetArgument("lowerBodyStiffnessEnd", value);
            lowerBodyStiffnessEnd = value;
        } 
    }

    private float perStepReduction = 1.50f;
    /// <summary>
    /// LowerBody stiffness will be reduced every step to make the character fallover
    /// </summary>
    public float PerStepReduction
    {
        get { return perStepReduction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("perStepReduction", value);
            perStepReduction = value;
        } 
    }

    private float hipPitchForward = 0.60f;
    /// <summary>
    /// Amount to bend forward at the hips (+ve forward, -ve backwards).  Behaviour switches between hipPitchForward and hipPitchBack
    /// </summary>
    public float HipPitchForward
    {
        get { return hipPitchForward; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.30f, 1.30f);
            SetArgument("hipPitchForward", value);
            hipPitchForward = value;
        } 
    }

    private float hipPitchBack = 1.0f;
    /// <summary>
    /// Amount to bend backwards at the hips (+ve backwards, -ve forwards).  Behaviour switches between hipPitchForward and hipPitchBack
    /// </summary>
    public float HipPitchBack
    {
        get { return hipPitchBack; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.30f, 1.30f);
            SetArgument("hipPitchBack", value);
            hipPitchBack = value;
        } 
    }

    private float spineBend = 0.70f;
    /// <summary>
    /// Bend/Twist the spine amount
    /// </summary>
    public float SpineBend
    {
        get { return spineBend; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("spineBend", value);
            spineBend = value;
        } 
    }

    private float footFriction = 1.0f;
    /// <summary>
    /// Foot friction when standing/stepping.  0.5 gives a good slide sometimes
    /// </summary>
    public float FootFriction
    {
        get { return footFriction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("footFriction", value);
            footFriction = value;
        } 
    }

    private float turnThresholdMin = 0.60f;
    /// <summary>
    /// min angle at which the turn with toggle to the other direction (actual toggle angle is chosen randomly in range min to max). If it is 1 then it will never toggle. If negative then no turn is applied.
    /// </summary>
    public float TurnThresholdMin
    {
        get { return turnThresholdMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, -0.10f, 1.00f);
            SetArgument("turnThresholdMin", value);
            turnThresholdMin = value;
        } 
    }

    private float turnThresholdMax = 0.60f;
    /// <summary>
    /// max angle at which the turn with toggle to the other direction (actual toggle angle is chosen randomly in range min to max). If it is 1 then it will never toggle. If negative then no turn is applied.
    /// </summary>
    public float TurnThresholdMax
    {
        get { return turnThresholdMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, -0.10f, 1.00f);
            SetArgument("turnThresholdMax", value);
            turnThresholdMax = value;
        } 
    }

    private bool useHeadLook = false;
    /// <summary>
    /// enable and provide a look-at target to make the character's head turn to face it while balancing
    /// </summary>
    public bool UseHeadLook
    {
        get { return useHeadLook; } 
        set 
        {  
                
            SetArgument("useHeadLook", value);
            useHeadLook = value;
        } 
    }

    private Vector3 headLookPos = new(0f,  0f,  0f);
    /// <summary>
    /// position of thing to look at
    /// </summary>
    public Vector3 HeadLookPos
    {
        get { return headLookPos; } 
        set 
        {  
                
            SetArgument("headLookPos", value);
            headLookPos = value;
        } 
    }

    private int headLookInstanceIndex = -1;
    /// <summary>
    /// level index of thing to look at
    /// </summary>
    public int HeadLookInstanceIndex
    {
        get { return headLookInstanceIndex; } 
        set 
        {  
                
            SetArgument("headLookInstanceIndex", value);
            headLookInstanceIndex = value;
        } 
    }

    private float headLookAtVelProb = -1.0f;
    /// <summary>
    /// Probability [0-1] that headLook will be looking in the direction of velocity when stepping
    /// </summary>
    public float HeadLookAtVelProb
    {
        get { return headLookAtVelProb; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 1.0f);
            SetArgument("headLookAtVelProb", value);
            headLookAtVelProb = value;
        } 
    }

    private float comVelRDSThresh = 2.0f;
    /// <summary>
    /// for handsAndKnees catchfall ONLY: comVel above which rollDownstairs will start
    /// </summary>
    public float ComVelRDSThresh
    {
        get { return comVelRDSThresh; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 20.0f);
            SetArgument("comVelRDSThresh", value);
            comVelRDSThresh = value;
        } 
    }

    private float hulaPeriod = 0.25f;
    /// <summary>
    /// 0.25 A complete wiggle will take 4*hulaPeriod
    /// </summary>
    public float HulaPeriod
    {
        get { return hulaPeriod; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("hulaPeriod", value);
            hulaPeriod = value;
        } 
    }

    private float hipAmplitude = 1.0f;
    /// <summary>
    /// Amount of hip movement
    /// </summary>
    public float HipAmplitude
    {
        get { return hipAmplitude; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 4.0f);
            SetArgument("hipAmplitude", value);
            hipAmplitude = value;
        } 
    }

    private float spineAmplitude = 1.0f;
    /// <summary>
    /// Amount of spine movement
    /// </summary>
    public float SpineAmplitude
    {
        get { return spineAmplitude; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 4.0f);
            SetArgument("spineAmplitude", value);
            spineAmplitude = value;
        } 
    }

    private float minRelaxPeriod = 0.3f;
    /// <summary>
    /// wriggle relaxes for a minimum of minRelaxPeriod (if it is negative it is a multiplier on the time previously spent wriggling)
    /// </summary>
    public float MinRelaxPeriod
    {
        get { return minRelaxPeriod; } 
        set 
        {  
            value = MathHelper.Clamp(value, -5.0f, 5.0f);
            SetArgument("minRelaxPeriod", value);
            minRelaxPeriod = value;
        } 
    }

    private float maxRelaxPeriod = 1.5f;
    /// <summary>
    /// wriggle relaxes for a maximum of maxRelaxPeriod (if it is negative it is a multiplier on the time previously spent wriggling)
    /// </summary>
    public float MaxRelaxPeriod
    {
        get { return maxRelaxPeriod; } 
        set 
        {  
            value = MathHelper.Clamp(value, -5.0f, 5.0f);
            SetArgument("maxRelaxPeriod", value);
            maxRelaxPeriod = value;
        } 
    }

    private float rollHelp = 0.5f;
    /// <summary>
    /// Amount of cheat torque applied to turn the character over
    /// </summary>
    public float RollHelp
    {
        get { return rollHelp; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("rollHelp", value);
            rollHelp = value;
        } 
    }

    private float groundLegStiffness = 11f;
    /// <summary>
    /// Leg Stiffness when on the ground
    /// </summary>
    public float GroundLegStiffness
    {
        get { return groundLegStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
            SetArgument("groundLegStiffness", value);
            groundLegStiffness = value;
        } 
    }

    private float groundArmStiffness = 11f;
    /// <summary>
    /// Arm Stiffness when on the ground
    /// </summary>
    public float GroundArmStiffness
    {
        get { return groundArmStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
            SetArgument("groundArmStiffness", value);
            groundArmStiffness = value;
        } 
    }

    private float groundSpineStiffness = 14f;
    /// <summary>
    /// Spine Stiffness when on the ground
    /// </summary>
    public float GroundSpineStiffness
    {
        get { return groundSpineStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
            SetArgument("groundSpineStiffness", value);
            groundSpineStiffness = value;
        } 
    }

    private float groundLegDamping = 0.5f;
    /// <summary>
    /// Leg Damping when on the ground
    /// </summary>
    public float GroundLegDamping
    {
        get { return groundLegDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("groundLegDamping", value);
            groundLegDamping = value;
        } 
    }

    private float groundArmDamping = 0.5f;
    /// <summary>
    /// Arm Damping when on the ground
    /// </summary>
    public float GroundArmDamping
    {
        get { return groundArmDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("groundArmDamping", value);
            groundArmDamping = value;
        } 
    }

    private float groundSpineDamping = 0.5f;
    /// <summary>
    /// Spine Damping when on the ground
    /// </summary>
    public float GroundSpineDamping
    {
        get { return groundSpineDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("groundSpineDamping", value);
            groundSpineDamping = value;
        } 
    }

    private float groundFriction = 8.0f;
    /// <summary>
    /// Friction multiplier on bodyParts when on ground.  Character can look too slidy with groundFriction = 1.  Higher values give a more jerky reation but this seems timestep dependent especially for dragged by the feet.
    /// </summary>
    public float GroundFriction
    {
        get { return groundFriction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("groundFriction", value);
            groundFriction = value;
        } 
    }


    public EuphoriaMessageYanked(bool startNow) : base("yanked", startNow)
    { }

    public new void Reset()
    {
        armStiffness = 11.0f;
        armDamping = 1.0f;
        spineDamping = 1.0f;
        spineStiffness = 10.0f;
        armStiffnessStart = 3.0f;
        armDampingStart = 0.1f;
        spineDampingStart = 0.1f;
        spineStiffnessStart = 3.0f;
        timeAtStartValues = 0.4f;
        rampTimeFromStartValues = 0.1f;
        stepsTillStartEnd = 2;
        timeStartEnd = 100.0f;
        rampTimeToEndValues = 0.0f;
        lowerBodyStiffness = 12.0f;
        lowerBodyStiffnessEnd = 8.0f;
        perStepReduction = 1.50f;
        hipPitchForward = 0.60f;
        hipPitchBack = 1.0f;
        spineBend = 0.70f;
        footFriction = 1.0f;
        turnThresholdMin = 0.60f;
        turnThresholdMax = 0.60f;
        useHeadLook = false;
        headLookPos = new Vector3(0f,  0f,  0f);
        headLookInstanceIndex = -1;
        headLookAtVelProb = -1.0f;
        comVelRDSThresh = 2.0f;
        hulaPeriod = 0.25f;
        hipAmplitude = 1.0f;
        spineAmplitude = 1.0f;
        minRelaxPeriod = 0.3f;
        maxRelaxPeriod = 1.5f;
        rollHelp = 0.5f;
        groundLegStiffness = 11f;
        groundArmStiffness = 11f;
        groundSpineStiffness = 14f;
        groundLegDamping = 0.5f;
        groundArmDamping = 0.5f;
        groundSpineDamping = 0.5f;
        groundFriction = 8.0f;
        base.Reset();
    }
}
}
