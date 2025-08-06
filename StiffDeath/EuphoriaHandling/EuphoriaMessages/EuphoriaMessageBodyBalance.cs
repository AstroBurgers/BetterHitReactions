namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageBodyBalance : EuphoriaMessage
{
    private float armStiffness = 9.0f;
    /// <summary>
    /// NB. WAS m_bodyStiffness ClaviclesStiffness=9.0f
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

    private float elbow = 0.9f;
    /// <summary>
    /// How much the elbow swings based on the leg movement
    /// </summary>
    public float Elbow
    {
        get { return elbow; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 4.0f);
            SetArgument("elbow", value);
            elbow = value;
        } 
    }

    private float shoulder = 1.00f;
    /// <summary>
    /// How much the shoulder(lean1) swings based on the leg movement
    /// </summary>
    public float Shoulder
    {
        get { return shoulder; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 4.0f);
            SetArgument("shoulder", value);
            shoulder = value;
        } 
    }

    private float armDamping = 0.7f;
    /// <summary>
    /// NB. WAS m_damping NeckDamping=1 ClaviclesDamping=1
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

    private float spineStiffness = 10.0f;
    /// <summary>
    /// 
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

    private float somersaultAngle = 1.0f;
    /// <summary>
    /// multiplier of the somersault 'angle' (lean forward/back) for arms out (lean2)
    /// </summary>
    public float SomersaultAngle
    {
        get { return somersaultAngle; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("somersaultAngle", value);
            somersaultAngle = value;
        } 
    }

    private float somersaultAngleThreshold = 0.25f;
    /// <summary>
    /// Amount of somersault 'angle' before m_somersaultAngle is used for ArmsOut. Unless drunk - DO NOT EXCEED 0.8
    /// </summary>
    public float SomersaultAngleThreshold
    {
        get { return somersaultAngleThreshold; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("somersaultAngleThreshold", value);
            somersaultAngleThreshold = value;
        } 
    }

    private float sideSomersaultAngle = 1.0f;
    /// <summary>
    /// Amount of side somersault 'angle' before sideSomersault is used for ArmsOut. Unless drunk - DO NOT EXCEED 0.8
    /// </summary>
    public float SideSomersaultAngle
    {
        get { return sideSomersaultAngle; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("sideSomersaultAngle", value);
            sideSomersaultAngle = value;
        } 
    }

    private float sideSomersaultAngleThreshold = 0.25f;
    /// <summary>
    /// 
    /// </summary>
    public float SideSomersaultAngleThreshold
    {
        get { return sideSomersaultAngleThreshold; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("sideSomersaultAngleThreshold", value);
            sideSomersaultAngleThreshold = value;
        } 
    }

    private bool backwardsAutoTurn = false;
    /// <summary>
    /// Automatically turn around if moving backwards
    /// </summary>
    public bool BackwardsAutoTurn
    {
        get { return backwardsAutoTurn; } 
        set 
        {  
                
            SetArgument("backwardsAutoTurn", value);
            backwardsAutoTurn = value;
        } 
    }

    private float turnWithBumpRadius = -1.00f;
    /// <summary>
    /// 0.9 is a sensible value.  If pusher within this distance then turn to get out of the way of the pusher
    /// </summary>
    public float TurnWithBumpRadius
    {
        get { return turnWithBumpRadius; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 10.00f);
            SetArgument("turnWithBumpRadius", value);
            turnWithBumpRadius = value;
        } 
    }

    private bool backwardsArms = false;
    /// <summary>
    /// Bend elbows, relax shoulders and inhibit spine twist when moving backwards
    /// </summary>
    public bool BackwardsArms
    {
        get { return backwardsArms; } 
        set 
        {  
                
            SetArgument("backwardsArms", value);
            backwardsArms = value;
        } 
    }

    private bool blendToZeroPose = false;
    /// <summary>
    /// Blend upper body to zero pose as the character comes to rest. If false blend to a stored pose
    /// </summary>
    public bool BlendToZeroPose
    {
        get { return blendToZeroPose; } 
        set 
        {  
                
            SetArgument("blendToZeroPose", value);
            blendToZeroPose = value;
        } 
    }

    private bool armsOutOnPush = true;
    /// <summary>
    /// Put arms out based on lean2 of legs, or angular velocity (lean or twist), or lean (front/back or side/side)
    /// </summary>
    public bool ArmsOutOnPush
    {
        get { return armsOutOnPush; } 
        set 
        {  
                
            SetArgument("armsOutOnPush", value);
            armsOutOnPush = value;
        } 
    }

    private float armsOutOnPushMultiplier = 1.0f;
    /// <summary>
    /// Arms out based on lean2 of the legs to simulate being pushed
    /// </summary>
    public float ArmsOutOnPushMultiplier
    {
        get { return armsOutOnPushMultiplier; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("armsOutOnPushMultiplier", value);
            armsOutOnPushMultiplier = value;
        } 
    }

    private float armsOutOnPushTimeout = 1.1f;
    /// <summary>
    /// number of seconds before turning off the armsOutOnPush response only for Arms out based on lean2 of the legs (NOT for the angle or angular velocity)
    /// </summary>
    public float ArmsOutOnPushTimeout
    {
        get { return armsOutOnPushTimeout; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("armsOutOnPushTimeout", value);
            armsOutOnPushTimeout = value;
        } 
    }

    private float returningToBalanceArmsOut = 0.0f;
    /// <summary>
    /// range 0:1 0 = don't raise arms if returning to upright position, 0.x = 0.x*raise arms based on angvel and 'angle' settings, 1 = raise arms based on angvel and 'angle' settings
    /// </summary>
    public float ReturningToBalanceArmsOut
    {
        get { return returningToBalanceArmsOut; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("returningToBalanceArmsOut", value);
            returningToBalanceArmsOut = value;
        } 
    }

    private float armsOutStraightenElbows = 0.0f;
    /// <summary>
    /// multiplier for straightening the elbows based on the amount of arms out(lean2) 0 = dont straighten elbows. Otherwise straighten elbows proportionately to armsOut
    /// </summary>
    public float ArmsOutStraightenElbows
    {
        get { return armsOutStraightenElbows; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("armsOutStraightenElbows", value);
            armsOutStraightenElbows = value;
        } 
    }

    private float armsOutMinLean2 = -9.9f;
    /// <summary>
    /// Minimum desiredLean2 applied to shoulder (to stop arms going above shoulder height or not)
    /// </summary>
    public float ArmsOutMinLean2
    {
        get { return armsOutMinLean2; } 
        set 
        {  
            value = MathHelper.Clamp(value, -10.0f, 0.0f);
            SetArgument("armsOutMinLean2", value);
            armsOutMinLean2 = value;
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

    private bool useBodyTurn = true;
    /// <summary>
    /// 
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

    private float elbowAngleOnContact = 1.9f;
    /// <summary>
    /// on contact with upperbody the desired elbow angle is set to at least this value
    /// </summary>
    public float ElbowAngleOnContact
    {
        get { return elbowAngleOnContact; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("elbowAngleOnContact", value);
            elbowAngleOnContact = value;
        } 
    }

    private float bendElbowsTime = 0.3f;
    /// <summary>
    /// Time after contact (with Upper body) that the min m_elbowAngleOnContact is applied
    /// </summary>
    public float BendElbowsTime
    {
        get { return bendElbowsTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("bendElbowsTime", value);
            bendElbowsTime = value;
        } 
    }

    private float bendElbowsGait = 0.7f;
    /// <summary>
    /// Minimum desired angle of elbow during non contact arm swing
    /// </summary>
    public float BendElbowsGait
    {
        get { return bendElbowsGait; } 
        set 
        {  
            value = MathHelper.Clamp(value, -3.0f, 3.0f);
            SetArgument("bendElbowsGait", value);
            bendElbowsGait = value;
        } 
    }

    private float hipL2ArmL2 = 0.3f;
    /// <summary>
    /// mmmmdrunk = 0.2 multiplier of hip lean2 (star jump) to give shoulder lean2 (flapping)
    /// </summary>
    public float HipL2ArmL2
    {
        get { return hipL2ArmL2; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("hipL2ArmL2", value);
            hipL2ArmL2 = value;
        } 
    }

    private float shoulderL2 = 0.5f;
    /// <summary>
    /// mmmmdrunk = 0.7 shoulder lean2 offset
    /// </summary>
    public float ShoulderL2
    {
        get { return shoulderL2; } 
        set 
        {  
            value = MathHelper.Clamp(value, -3.0f, 3.0f);
            SetArgument("shoulderL2", value);
            shoulderL2 = value;
        } 
    }

    private float shoulderL1 = 0.0f;
    /// <summary>
    /// mmmmdrunk 1.1 shoulder lean1 offset (+ve frankenstein)
    /// </summary>
    public float ShoulderL1
    {
        get { return shoulderL1; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 2.0f);
            SetArgument("shoulderL1", value);
            shoulderL1 = value;
        } 
    }

    private float shoulderTwist = -0.35f;
    /// <summary>
    /// mmmmdrunk = 0.0 shoulder twist
    /// </summary>
    public float ShoulderTwist
    {
        get { return shoulderTwist; } 
        set 
        {  
            value = MathHelper.Clamp(value, -3.0f, 3.0f);
            SetArgument("shoulderTwist", value);
            shoulderTwist = value;
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

    private float turnOffProb = 0.1f;
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

    private float turn2VelProb = 0.3f;
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

    private float turnAwayProb = 0.15f;
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

    private float turnLeftProb = 0.125f;
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

    private float turnRightProb = 0.125f;
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

    private float turn2TargetProb = 0.2f;
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

    private Vector3 angVelMultiplier = new(4.00f,  1.00f,  4.00f);
    /// <summary>
    /// somersault, twist, sideSomersault) multiplier of the angular velocity  for arms out (lean2) (somersault, twist, sideSomersault)
    /// </summary>
    public Vector3 AngVelMultiplier
    {
        get { return angVelMultiplier; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, 0.0f, 20.0f);
            value.Y = MathHelper.Clamp(value.Y, 0.0f, 20.0f);
            value.Z = MathHelper.Clamp(value.Z, 0.0f, 20.0f);
            SetArgument("angVelMultiplier", value);
            angVelMultiplier = value;
        } 
    }

    private Vector3 angVelThreshold = new(1.20f,  3.00f,  1.20f);
    /// <summary>
    /// somersault, twist, sideSomersault) threshold above which angVel is used for arms out (lean2) Unless drunk - DO NOT EXCEED 7.0 for each component
    /// </summary>
    public Vector3 AngVelThreshold
    {
        get { return angVelThreshold; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, 0.0f, 40.0f);
            value.Y = MathHelper.Clamp(value.Y, 0.0f, 40.0f);
            value.Z = MathHelper.Clamp(value.Z, 0.0f, 40.0f);
            SetArgument("angVelThreshold", value);
            angVelThreshold = value;
        } 
    }

    private float braceDistance = -1.00f;
    /// <summary>
    /// if -ve then do not brace.  distance from object at which to raise hands to brace 0.5 good if newBrace=true - otherwise 0.65
    /// </summary>
    public float BraceDistance
    {
        get { return braceDistance; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("braceDistance", value);
            braceDistance = value;
        } 
    }

    private float targetPredictionTime = 0.450f;
    /// <summary>
    /// time expected to get arms up from idle
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

    private float braceStiffness = 12.00f;
    /// <summary>
    /// stiffness of character. catch_fall stiffness scales with this too, with its defaults at this values default
    /// </summary>
    public float BraceStiffness
    {
        get { return braceStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.00f, 16.00f);
            SetArgument("braceStiffness", value);
            braceStiffness = value;
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

    private float timeToBackwardsBrace = 0.50f;
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

    private float handsDelayMin = 0.30f;
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

    private float handsDelayMax = 0.70f;
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

    private float braceOffset = 0.00f;
    /// <summary>
    /// braceTarget is global headLookPos plus braceOffset m in the up direction
    /// </summary>
    public float BraceOffset
    {
        get { return braceOffset; } 
        set 
        {  
            value = MathHelper.Clamp(value, -2.00f, 2.00f);
            SetArgument("braceOffset", value);
            braceOffset = value;
        } 
    }

    private float moveRadius = -1.00f;
    /// <summary>
    /// if -ve don't move away from pusher unless moveWhenBracing is true and braceDistance  GT  0.0f.  if the pusher is closer than moveRadius then move away from it.
    /// </summary>
    public float MoveRadius
    {
        get { return moveRadius; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 2.00f);
            SetArgument("moveRadius", value);
            moveRadius = value;
        } 
    }

    private float moveAmount = 0.30f;
    /// <summary>
    /// amount of leanForce applied away from pusher
    /// </summary>
    public float MoveAmount
    {
        get { return moveAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("moveAmount", value);
            moveAmount = value;
        } 
    }

    private bool moveWhenBracing = false;
    /// <summary>
    /// Only move away from pusher when bracing against pusher
    /// </summary>
    public bool MoveWhenBracing
    {
        get { return moveWhenBracing; } 
        set 
        {  
                
            SetArgument("moveWhenBracing", value);
            moveWhenBracing = value;
        } 
    }


    public EuphoriaMessageBodyBalance(bool startNow) : base("bodyBalance", startNow)
    { }

    public new void Reset()
    {
        armStiffness = 9.0f;
        elbow = 0.9f;
        shoulder = 1.00f;
        armDamping = 0.7f;
        useHeadLook = false;
        headLookPos = new Vector3(0f,  0f,  0f);
        headLookInstanceIndex = -1;
        spineStiffness = 10.0f;
        somersaultAngle = 1.0f;
        somersaultAngleThreshold = 0.25f;
        sideSomersaultAngle = 1.0f;
        sideSomersaultAngleThreshold = 0.25f;
        backwardsAutoTurn = false;
        turnWithBumpRadius = -1.00f;
        backwardsArms = false;
        blendToZeroPose = false;
        armsOutOnPush = true;
        armsOutOnPushMultiplier = 1.0f;
        armsOutOnPushTimeout = 1.1f;
        returningToBalanceArmsOut = 0.0f;
        armsOutStraightenElbows = 0.0f;
        armsOutMinLean2 = -9.9f;
        spineDamping = 1.0f;
        useBodyTurn = true;
        elbowAngleOnContact = 1.9f;
        bendElbowsTime = 0.3f;
        bendElbowsGait = 0.7f;
        hipL2ArmL2 = 0.3f;
        shoulderL2 = 0.5f;
        shoulderL1 = 0.0f;
        shoulderTwist = -0.35f;
        headLookAtVelProb = -1.0f;
        turnOffProb = 0.1f;
        turn2VelProb = 0.3f;
        turnAwayProb = 0.15f;
        turnLeftProb = 0.125f;
        turnRightProb = 0.125f;
        turn2TargetProb = 0.2f;
        angVelMultiplier = new Vector3(4.00f,  1.00f,  4.00f);
        angVelThreshold = new Vector3(1.20f,  3.00f,  1.20f);
        braceDistance = -1.00f;
        targetPredictionTime = 0.450f;
        reachAbsorbtionTime = 0.150f;
        braceStiffness = 12.00f;
        minBraceTime = 0.30f;
        timeToBackwardsBrace = 0.50f;
        handsDelayMin = 0.30f;
        handsDelayMax = 0.70f;
        braceOffset = 0.00f;
        moveRadius = -1.00f;
        moveAmount = 0.30f;
        moveWhenBracing = false;
        base.Reset();
    }
}
}
