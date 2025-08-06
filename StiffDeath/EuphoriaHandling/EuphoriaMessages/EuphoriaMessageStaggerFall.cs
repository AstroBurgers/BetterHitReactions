namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageStaggerFall : EuphoriaMessage
{
    private float armStiffness = 12.0f;
    /// <summary>
    /// stiffness of arms. catch_fall's stiffness scales with this value, but has default values when this is default
    /// </summary>
    public float ArmStiffness
    {
        get { return armStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
            SetArgument("armStiffness", value);
            armStiffness = value;
        } 
    }

    private float armDamping = 1.0f;
    /// <summary>
    /// Sets damping value for the arms
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
    /// 
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
    /// 
    /// </summary>
    public float SpineStiffness
    {
        get { return spineStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
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

    private float timeAtStartValues = 0.0f;
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

    private float rampTimeFromStartValues = 0.0f;
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

    private float staggerStepProb = 0.0f;
    /// <summary>
    /// Probability per step of time spent in a stagger step
    /// </summary>
    public float StaggerStepProb
    {
        get { return staggerStepProb; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("staggerStepProb", value);
            staggerStepProb = value;
        } 
    }

    private int stepsTillStartEnd = 2;
    /// <summary>
    /// steps taken before lowerBodyStiffness starts ramping down by perStepReduction1
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
    /// time from start of behaviour before lowerBodyStiffness starts ramping down for rampTimeToEndValues to endValues
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

    private float lowerBodyStiffness = 13.0f;
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

    private float predictionTime = 0.10f;
    /// <summary>
    /// amount of time (seconds) into the future that the character tries to step to. bigger values try to recover with fewer, bigger steps. smaller values recover with smaller steps, and generally recover less.
    /// </summary>
    public float PredictionTime
    {
        get { return predictionTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("predictionTime", value);
            predictionTime = value;
        } 
    }

    private float perStepReduction1 = 0.70f;
    /// <summary>
    /// LowerBody stiffness will be reduced every step to make the character fallover
    /// </summary>
    public float PerStepReduction1
    {
        get { return perStepReduction1; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("perStepReduction1", value);
            perStepReduction1 = value;
        } 
    }

    private float leanInDirRate = 1.0f;
    /// <summary>
    /// leanInDirection will be increased from 0 to leanInDirMax linearly at this rate
    /// </summary>
    public float LeanInDirRate
    {
        get { return leanInDirRate; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("leanInDirRate", value);
            leanInDirRate = value;
        } 
    }

    private float leanInDirMaxF = 0.10f;
    /// <summary>
    /// Max of leanInDirection magnitude when going forwards
    /// </summary>
    public float LeanInDirMaxF
    {
        get { return leanInDirMaxF; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("leanInDirMaxF", value);
            leanInDirMaxF = value;
        } 
    }

    private float leanInDirMaxB = 0.30f;
    /// <summary>
    /// Max of leanInDirection magnitude when going backwards
    /// </summary>
    public float LeanInDirMaxB
    {
        get { return leanInDirMaxB; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("leanInDirMaxB", value);
            leanInDirMaxB = value;
        } 
    }

    private float leanHipsMaxF = 0.00f;
    /// <summary>
    /// Max of leanInDirectionHips magnitude when going forwards
    /// </summary>
    public float LeanHipsMaxF
    {
        get { return leanHipsMaxF; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("leanHipsMaxF", value);
            leanHipsMaxF = value;
        } 
    }

    private float leanHipsMaxB = 0.00f;
    /// <summary>
    /// Max of leanInDirectionHips magnitude when going backwards
    /// </summary>
    public float LeanHipsMaxB
    {
        get { return leanHipsMaxB; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("leanHipsMaxB", value);
            leanHipsMaxB = value;
        } 
    }

    private float lean2multF = -1.00f;
    /// <summary>
    /// Lean of spine to side in side velocity direction when going forwards
    /// </summary>
    public float Lean2multF
    {
        get { return lean2multF; } 
        set 
        {  
            value = MathHelper.Clamp(value, -5.00f, 5.00f);
            SetArgument("lean2multF", value);
            lean2multF = value;
        } 
    }

    private float lean2multB = -2.00f;
    /// <summary>
    /// Lean of spine to side in side velocity direction when going backwards
    /// </summary>
    public float Lean2multB
    {
        get { return lean2multB; } 
        set 
        {  
            value = MathHelper.Clamp(value, -5.00f, 5.00f);
            SetArgument("lean2multB", value);
            lean2multB = value;
        } 
    }

    private float pushOffDist = 0.20f;
    /// <summary>
    /// amount stance foot is behind com in the direction of velocity before the leg tries to pushOff to increase momentum.  Increase to lower the probability of the pushOff making the character bouncy
    /// </summary>
    public float PushOffDist
    {
        get { return pushOffDist; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 1.0f);
            SetArgument("pushOffDist", value);
            pushOffDist = value;
        } 
    }

    private float maxPushoffVel = 20.00f;
    /// <summary>
    /// stance leg will only pushOff to increase momentum if the vertical hip velocity is less than this value. 0.4 seems like a good value.  The higher it is the the less this functionality is applied.  If it is very low or negative this can stop the pushOff altogether
    /// </summary>
    public float MaxPushoffVel
    {
        get { return maxPushoffVel; } 
        set 
        {  
            value = MathHelper.Clamp(value, -20.0f, 20.0f);
            SetArgument("maxPushoffVel", value);
            maxPushoffVel = value;
        } 
    }

    private float hipBendMult = 0.00f;
    /// <summary>
    /// hipBend scaled with velocity
    /// </summary>
    public float HipBendMult
    {
        get { return hipBendMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, -10.0f, 10.0f);
            SetArgument("hipBendMult", value);
            hipBendMult = value;
        } 
    }

    private bool alwaysBendForwards = false;
    /// <summary>
    /// bend forwards at the hip (hipBendMult) whether moving backwards or forwards
    /// </summary>
    public bool AlwaysBendForwards
    {
        get { return alwaysBendForwards; } 
        set 
        {  
                
            SetArgument("alwaysBendForwards", value);
            alwaysBendForwards = value;
        } 
    }

    private float spineBendMult = 0.40f;
    /// <summary>
    /// spine bend scaled with velocity
    /// </summary>
    public float SpineBendMult
    {
        get { return spineBendMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, -10.0f, 10.0f);
            SetArgument("spineBendMult", value);
            spineBendMult = value;
        } 
    }

    private bool useHeadLook = true;
    /// <summary>
    /// enable and provide a look-at target to make the character's head turn to face it while balancing, balancer default is 0.2
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

    private float headLookAtVelProb = 1.0f;
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

    private float turnOffProb = 0.0f;
    /// <summary>
    /// Weighted Probability that turn will be off. This is one of six turn type weights.
    /// </summary>
    public float TurnOffProb
    {
        get { return turnOffProb; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("turnOffProb", value);
            turnOffProb = value;
        } 
    }

    private float turn2TargetProb = 0.0f;
    /// <summary>
    /// Weighted Probability of turning towards headLook target. This is one of six turn type weights.
    /// </summary>
    public float Turn2TargetProb
    {
        get { return turn2TargetProb; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("turn2TargetProb", value);
            turn2TargetProb = value;
        } 
    }

    private float turn2VelProb = 1.0f;
    /// <summary>
    /// Weighted Probability of turning towards velocity. This is one of six turn type weights.
    /// </summary>
    public float Turn2VelProb
    {
        get { return turn2VelProb; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("turn2VelProb", value);
            turn2VelProb = value;
        } 
    }

    private float turnAwayProb = 0.0f;
    /// <summary>
    /// Weighted Probability of turning away from headLook target. This is one of six turn type weights.
    /// </summary>
    public float TurnAwayProb
    {
        get { return turnAwayProb; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("turnAwayProb", value);
            turnAwayProb = value;
        } 
    }

    private float turnLeftProb = 0.0f;
    /// <summary>
    /// Weighted Probability of turning left. This is one of six turn type weights.
    /// </summary>
    public float TurnLeftProb
    {
        get { return turnLeftProb; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("turnLeftProb", value);
            turnLeftProb = value;
        } 
    }

    private float turnRightProb = 0.0f;
    /// <summary>
    /// Weighted Probability of turning right. This is one of six turn type weights.
    /// </summary>
    public float TurnRightProb
    {
        get { return turnRightProb; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("turnRightProb", value);
            turnRightProb = value;
        } 
    }

    private bool useBodyTurn = false;
    /// <summary>
    /// enable and provide a positive bodyTurnTimeout and provide a look-at target to make the character turn to face it while balancing
    /// </summary>
    public bool UseBodyTurn
    {
        get { return useBodyTurn; } 
        set 
        {  
                
            SetArgument("useBodyTurn", value);
            useBodyTurn = value;
        } 
    }

    private bool upperBodyReaction = true;
    /// <summary>
    /// enable upper body reaction ie blindBrace and armswindmill
    /// </summary>
    public bool UpperBodyReaction
    {
        get { return upperBodyReaction; } 
        set 
        {  
                
            SetArgument("upperBodyReaction", value);
            upperBodyReaction = value;
        } 
    }


    public EuphoriaMessageStaggerFall(bool startNow) : base("staggerFall", startNow)
    { }

    public new void Reset()
    {
        armStiffness = 12.0f;
        armDamping = 1.0f;
        spineDamping = 1.0f;
        spineStiffness = 10.0f;
        armStiffnessStart = 3.0f;
        armDampingStart = 0.1f;
        spineDampingStart = 0.1f;
        spineStiffnessStart = 3.0f;
        timeAtStartValues = 0.0f;
        rampTimeFromStartValues = 0.0f;
        staggerStepProb = 0.0f;
        stepsTillStartEnd = 2;
        timeStartEnd = 100.0f;
        rampTimeToEndValues = 0.0f;
        lowerBodyStiffness = 13.0f;
        lowerBodyStiffnessEnd = 8.0f;
        predictionTime = 0.10f;
        perStepReduction1 = 0.70f;
        leanInDirRate = 1.0f;
        leanInDirMaxF = 0.10f;
        leanInDirMaxB = 0.30f;
        leanHipsMaxF = 0.00f;
        leanHipsMaxB = 0.00f;
        lean2multF = -1.00f;
        lean2multB = -2.00f;
        pushOffDist = 0.20f;
        maxPushoffVel = 20.00f;
        hipBendMult = 0.00f;
        alwaysBendForwards = false;
        spineBendMult = 0.40f;
        useHeadLook = true;
        headLookPos = new Vector3(0f,  0f,  0f);
        headLookInstanceIndex = -1;
        headLookAtVelProb = 1.0f;
        turnOffProb = 0.0f;
        turn2TargetProb = 0.0f;
        turn2VelProb = 1.0f;
        turnAwayProb = 0.0f;
        turnLeftProb = 0.0f;
        turnRightProb = 0.0f;
        useBodyTurn = false;
        upperBodyReaction = true;
        base.Reset();
    }
}
}
