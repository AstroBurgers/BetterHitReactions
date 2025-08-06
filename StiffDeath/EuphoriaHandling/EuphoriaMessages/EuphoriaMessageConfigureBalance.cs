using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// configureBalance:  This single message allows you to configure various parameters used on any behaviour that uses the dynamic balance.
/// </summary>

internal class EuphoriaMessageConfigureBalance : EuphoriaMessage
{
    private float stepHeight = 0.100f;
    /// <summary>
    /// maximum height that character steps vertically (above 0.2 is high...but ok for say underwater)
    /// </summary>
    public float StepHeight
    {
        get { return stepHeight; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 0.40f);
            SetArgument("stepHeight", value);
            stepHeight = value;
        } 
    }

    private float stepHeightInc4Step = 0.100f;
    /// <summary>
    /// added to stepHeight if going up steps
    /// </summary>
    public float StepHeightInc4Step
    {
        get { return stepHeightInc4Step; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 0.40f);
            SetArgument("stepHeightInc4Step", value);
            stepHeightInc4Step = value;
        } 
    }

    private float legsApartRestep = 0.200f;
    /// <summary>
    /// if the legs end up more than (legsApartRestep + hipwidth) apart even though balanced, take another step
    /// </summary>
    public float LegsApartRestep
    {
        get { return legsApartRestep; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.00f);
            SetArgument("legsApartRestep", value);
            legsApartRestep = value;
        } 
    }

    private float legsTogetherRestep = 1.0f;
    /// <summary>
    /// mmmm0.1 for drunk if the legs end up less than (hipwidth - legsTogetherRestep) apart even though balanced, take another step.  A value of 1 will turn off this feature and the max value is hipWidth = 0.23f by default but is model dependent
    /// </summary>
    public float LegsTogetherRestep
    {
        get { return legsTogetherRestep; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.00f);
            SetArgument("legsTogetherRestep", value);
            legsTogetherRestep = value;
        } 
    }

    private float legsApartMax = 2.000f;
    /// <summary>
    /// FRICTION WORKAROUND: if the legs end up more than (legsApartMax + hipwidth) apart when balanced, adjust the feet positions to slide back so they are legsApartMax + hipwidth apart.  Needs to be less than legsApartRestep to see any effect
    /// </summary>
    public float LegsApartMax
    {
        get { return legsApartMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("legsApartMax", value);
            legsApartMax = value;
        } 
    }

    private bool taperKneeStrength = true;
    /// <summary>
    /// does the knee strength reduce with angle
    /// </summary>
    public bool TaperKneeStrength
    {
        get { return taperKneeStrength; } 
        set 
        {  
                
            SetArgument("taperKneeStrength", value);
            taperKneeStrength = value;
        } 
    }

    private float legStiffness = 12.000f;
    /// <summary>
    /// stiffness of legs
    /// </summary>
    public float LegStiffness
    {
        get { return legStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("legStiffness", value);
            legStiffness = value;
        } 
    }

    private float leftLegSwingDamping = 1.000f;
    /// <summary>
    /// damping of left leg during swing phase (mmmmDrunk used 1.25 to slow legs movement)
    /// </summary>
    public float LeftLegSwingDamping
    {
        get { return leftLegSwingDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.20f, 4.0f);
            SetArgument("leftLegSwingDamping", value);
            leftLegSwingDamping = value;
        } 
    }

    private float rightLegSwingDamping = 1.000f;
    /// <summary>
    /// damping of right leg during swing phase (mmmmDrunk used 1.25 to slow legs movement)
    /// </summary>
    public float RightLegSwingDamping
    {
        get { return rightLegSwingDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.20f, 4.0f);
            SetArgument("rightLegSwingDamping", value);
            rightLegSwingDamping = value;
        } 
    }

    private float opposeGravityLegs = 1.000f;
    /// <summary>
    /// Gravity opposition applied to hips and knees
    /// </summary>
    public float OpposeGravityLegs
    {
        get { return opposeGravityLegs; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 4.0f);
            SetArgument("opposeGravityLegs", value);
            opposeGravityLegs = value;
        } 
    }

    private float opposeGravityAnkles = 1.000f;
    /// <summary>
    /// Gravity opposition applied to ankles.  General balancer likes 1.0.  StaggerFall likes 0.1
    /// </summary>
    public float OpposeGravityAnkles
    {
        get { return opposeGravityAnkles; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 4.0f);
            SetArgument("opposeGravityAnkles", value);
            opposeGravityAnkles = value;
        } 
    }

    private float leanAcc = 0.00f;
    /// <summary>
    /// Multiplier on the floorAcceleration added to the lean
    /// </summary>
    public float LeanAcc
    {
        get { return leanAcc; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("leanAcc", value);
            leanAcc = value;
        } 
    }

    private float hipLeanAcc = 0.50f;
    /// <summary>
    /// Multiplier on the floorAcceleration added to the leanHips
    /// </summary>
    public float HipLeanAcc
    {
        get { return hipLeanAcc; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.0f);
            SetArgument("hipLeanAcc", value);
            hipLeanAcc = value;
        } 
    }

    private float leanAccMax = 5.000f;
    /// <summary>
    /// Max floorAcceleration allowed for lean and leanHips
    /// </summary>
    public float LeanAccMax
    {
        get { return leanAccMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.0f);
            SetArgument("leanAccMax", value);
            leanAccMax = value;
        } 
    }

    private float resistAcc = 0.50f;
    /// <summary>
    /// Level of cheat force added to character to resist the effect of floorAcceleration (anti-Acceleration) - added to upperbody.
    /// </summary>
    public float ResistAcc
    {
        get { return resistAcc; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.0f);
            SetArgument("resistAcc", value);
            resistAcc = value;
        } 
    }

    private float resistAccMax = 3.00f;
    /// <summary>
    /// Max floorAcceleration allowed for anti-Acceleration. If  GT 20.0 then it is probably in a crash
    /// </summary>
    public float ResistAccMax
    {
        get { return resistAccMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.0f);
            SetArgument("resistAccMax", value);
            resistAccMax = value;
        } 
    }

    private bool footSlipCompOnMovingFloor = true;
    /// <summary>
    /// This parameter will be removed when footSlipCompensation preserves the foot angle on a moving floor]. If the character detects a moving floor and footSlipCompOnMovingFloor is false then it will turn off footSlipCompensation - at footSlipCompensation preserves the global heading of the feet.  If footSlipCompensation is off then the character usually turns to the side in the end although when turning the vehicle turns it looks promising for a while
    /// </summary>
    public bool FootSlipCompOnMovingFloor
    {
        get { return footSlipCompOnMovingFloor; } 
        set 
        {  
                
            SetArgument("footSlipCompOnMovingFloor", value);
            footSlipCompOnMovingFloor = value;
        } 
    }

    private float ankleEquilibrium = 0.000f;
    /// <summary>
    /// ankle equilibrium angle used when static balancing
    /// </summary>
    public float AnkleEquilibrium
    {
        get { return ankleEquilibrium; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.0f);
            SetArgument("ankleEquilibrium", value);
            ankleEquilibrium = value;
        } 
    }

    private float extraFeetApart = 0.000f;
    /// <summary>
    /// additional feet apart setting
    /// </summary>
    public float ExtraFeetApart
    {
        get { return extraFeetApart; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.0f);
            SetArgument("extraFeetApart", value);
            extraFeetApart = value;
        } 
    }

    private float dontStepTime = 0.00f;
    /// <summary>
    /// amount of time at the start of a balance before the character is allowed to start stepping
    /// </summary>
    public float DontStepTime
    {
        get { return dontStepTime; } 
        set 
        {  
                
            SetArgument("dontStepTime", value);
            dontStepTime = value;
        } 
    }

    private float balanceAbortThreshold = 0.600f;
    /// <summary>
    /// when the character gives up and goes into a fall.  Larger values mean that the balancer can lean more before failing.
    /// </summary>
    public float BalanceAbortThreshold
    {
        get { return balanceAbortThreshold; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("balanceAbortThreshold", value);
            balanceAbortThreshold = value;
        } 
    }

    private float giveUpHeight = 0.50f;
    /// <summary>
    /// height between lowest foot and COM below which balancer will give up
    /// </summary>
    public float GiveUpHeight
    {
        get { return giveUpHeight; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.50f);
            SetArgument("giveUpHeight", value);
            giveUpHeight = value;
        } 
    }

    private float stepClampScale = 1.000f;
    /// <summary>
    /// 
    /// </summary>
    public float StepClampScale
    {
        get { return stepClampScale; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("stepClampScale", value);
            stepClampScale = value;
        } 
    }

    private float stepClampScaleVariance = 0.000f;
    /// <summary>
    /// Variance in clamp scale every step. if negative only takes away from clampScale
    /// </summary>
    public float StepClampScaleVariance
    {
        get { return stepClampScaleVariance; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 1.0f);
            SetArgument("stepClampScaleVariance", value);
            stepClampScaleVariance = value;
        } 
    }

    private float predictionTimeHip = 0.30f;
    /// <summary>
    /// amount of time (seconds) into the future that the character tries to move hip to (kind of).  Will be controlled by balancer in future but can help recover spine quicker from bending forwards to much.
    /// </summary>
    public float PredictionTimeHip
    {
        get { return predictionTimeHip; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 1.0f);
            SetArgument("predictionTimeHip", value);
            predictionTimeHip = value;
        } 
    }

    private float predictionTime = 0.20f;
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

    private float predictionTimeVariance = 0.00f;
    /// <summary>
    /// Variance in predictionTime every step. if negative only takes away from predictionTime
    /// </summary>
    public float PredictionTimeVariance
    {
        get { return predictionTimeVariance; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 1.0f);
            SetArgument("predictionTimeVariance", value);
            predictionTimeVariance = value;
        } 
    }

    private int maxSteps = 100;
    /// <summary>
    /// Maximum number of steps that the balancer will take.
    /// </summary>
    public int MaxSteps
    {
        get { return maxSteps; } 
        set 
        {  
                
            SetArgument("maxSteps", value);
            maxSteps = value;
        } 
    }

    private float maxBalanceTime = 50.0f;
    /// <summary>
    /// Maximum time(seconds) that the balancer will balance for.
    /// </summary>
    public float MaxBalanceTime
    {
        get { return maxBalanceTime; } 
        set 
        {  
                
            SetArgument("maxBalanceTime", value);
            maxBalanceTime = value;
        } 
    }

    private int extraSteps = -1;
    /// <summary>
    /// Allow the balancer to take this many more steps before hitting maxSteps. If negative nothing happens(safe default)
    /// </summary>
    public int ExtraSteps
    {
        get { return extraSteps; } 
        set 
        {  
                
            SetArgument("extraSteps", value);
            extraSteps = value;
        } 
    }

    private float extraTime = -1.00f;
    /// <summary>
    /// Allow the balancer to balance for this many more seconds before hitting maxBalanceTime.  If negative nothing happens(safe default)
    /// </summary>
    public float ExtraTime
    {
        get { return extraTime; } 
        set 
        {  
                
            SetArgument("extraTime", value);
            extraTime = value;
        } 
    }

    private int fallType = 0;
    /// <summary>
    /// How to fall after maxSteps or maxBalanceTime: 0=rampDown stiffness, 1= 0 and dontChangeStep, 2= 0 and forceBalance, 3=0 and slump (BCR has to be active)
    /// </summary>
    public int FallType
    {
        get { return fallType; } 
        set 
        {  
                
            SetArgument("fallType", value);
            fallType = value;
        } 
    }

    private float fallMult = 1.0f;
    /// <summary>
    /// Multiply the rampDown of stiffness on falling by this amount ( GT 1 fall quicker)
    /// </summary>
    public float FallMult
    {
        get { return fallMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 100.0f);
            SetArgument("fallMult", value);
            fallMult = value;
        } 
    }

    private bool fallReduceGravityComp = false;
    /// <summary>
    /// Reduce gravity compensation as the legs weaken on falling
    /// </summary>
    public bool FallReduceGravityComp
    {
        get { return fallReduceGravityComp; } 
        set 
        {  
                
            SetArgument("fallReduceGravityComp", value);
            fallReduceGravityComp = value;
        } 
    }

    private bool rampHipPitchOnFail = false;
    /// <summary>
    /// bend over when falling after maxBalanceTime
    /// </summary>
    public bool RampHipPitchOnFail
    {
        get { return rampHipPitchOnFail; } 
        set 
        {  
                
            SetArgument("rampHipPitchOnFail", value);
            rampHipPitchOnFail = value;
        } 
    }

    private float stableLinSpeedThresh = 0.250f;
    /// <summary>
    /// Linear speed threshold for successful balance.
    /// </summary>
    public float StableLinSpeedThresh
    {
        get { return stableLinSpeedThresh; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 10.0f);
            SetArgument("stableLinSpeedThresh", value);
            stableLinSpeedThresh = value;
        } 
    }

    private float stableRotSpeedThresh = 0.250f;
    /// <summary>
    /// Rotational speed threshold for successful balance.
    /// </summary>
    public float StableRotSpeedThresh
    {
        get { return stableRotSpeedThresh; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 10.0f);
            SetArgument("stableRotSpeedThresh", value);
            stableRotSpeedThresh = value;
        } 
    }

    private bool failMustCollide = false;
    /// <summary>
    /// The upper body of the character must be colliding and other failure conditions met to fail
    /// </summary>
    public bool FailMustCollide
    {
        get { return failMustCollide; } 
        set 
        {  
                
            SetArgument("failMustCollide", value);
            failMustCollide = value;
        } 
    }

    private bool ignoreFailure = false;
    /// <summary>
    /// Ignore maxSteps and maxBalanceTime and try to balance forever
    /// </summary>
    public bool IgnoreFailure
    {
        get { return ignoreFailure; } 
        set 
        {  
                
            SetArgument("ignoreFailure", value);
            ignoreFailure = value;
        } 
    }

    private float changeStepTime = -1.00f;
    /// <summary>
    /// time not in contact (airborne) before step is changed. If -ve don't change step
    /// </summary>
    public float ChangeStepTime
    {
        get { return changeStepTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 5.0f);
            SetArgument("changeStepTime", value);
            changeStepTime = value;
        } 
    }

    private bool balanceIndefinitely = false;
    /// <summary>
    /// Ignore maxSteps and maxBalanceTime and try to balance forever
    /// </summary>
    public bool BalanceIndefinitely
    {
        get { return balanceIndefinitely; } 
        set 
        {  
                
            SetArgument("balanceIndefinitely", value);
            balanceIndefinitely = value;
        } 
    }

    private bool movingFloor = false;
    /// <summary>
    /// temporary variable to ignore movingFloor code that generally causes the character to fall over if the feet probe a moving object e.g. treading on a gun
    /// </summary>
    public bool MovingFloor
    {
        get { return movingFloor; } 
        set 
        {  
                
            SetArgument("movingFloor", value);
            movingFloor = value;
        } 
    }

    private bool airborneStep = true;
    /// <summary>
    /// when airborne try to step.  Set to false for e.g. shotGun reaction
    /// </summary>
    public bool AirborneStep
    {
        get { return airborneStep; } 
        set 
        {  
                
            SetArgument("airborneStep", value);
            airborneStep = value;
        } 
    }

    private float useComDirTurnVelThresh = 0.0f;
    /// <summary>
    /// Velocity below which the balancer turns in the direction of the COM forward instead of the ComVel - for use with shot from running with high upright constraint use 1.9
    /// </summary>
    public float UseComDirTurnVelThresh
    {
        get { return useComDirTurnVelThresh; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("useComDirTurnVelThresh", value);
            useComDirTurnVelThresh = value;
        } 
    }

    private float minKneeAngle = -0.50f;
    /// <summary>
    /// Minimum knee angle (-ve value will mean this functionality is not applied).  0.4 seems a good value
    /// </summary>
    public float MinKneeAngle
    {
        get { return minKneeAngle; } 
        set 
        {  
            value = MathHelper.Clamp(value, -0.50f, 1.50f);
            SetArgument("minKneeAngle", value);
            minKneeAngle = value;
        } 
    }

    private bool flatterSwingFeet = false;
    /// <summary>
    /// 
    /// </summary>
    public bool FlatterSwingFeet
    {
        get { return flatterSwingFeet; } 
        set 
        {  
                
            SetArgument("flatterSwingFeet", value);
            flatterSwingFeet = value;
        } 
    }

    private bool flatterStaticFeet = false;
    /// <summary>
    /// 
    /// </summary>
    public bool FlatterStaticFeet
    {
        get { return flatterStaticFeet; } 
        set 
        {  
                
            SetArgument("flatterStaticFeet", value);
            flatterStaticFeet = value;
        } 
    }

    private bool avoidLeg = false;
    /// <summary>
    /// If true then balancer tries to avoid leg2leg collisions/avoid crossing legs. Avoid tries to not step across a line of the inside of the stance leg's foot
    /// </summary>
    public bool AvoidLeg
    {
        get { return avoidLeg; } 
        set 
        {  
                
            SetArgument("avoidLeg", value);
            avoidLeg = value;
        } 
    }

    private float avoidFootWidth = 0.10f;
    /// <summary>
    /// NB. Very sensitive. Avoid tries to not step across a line of the inside of the stance leg's foot. avoidFootWidth = how much inwards from the ankle this line is in (m).
    /// </summary>
    public float AvoidFootWidth
    {
        get { return avoidFootWidth; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.0f);
            SetArgument("avoidFootWidth", value);
            avoidFootWidth = value;
        } 
    }

    private float avoidFeedback = 0.60f;
    /// <summary>
    /// NB. Very sensitive. Avoid tries to not step across a line of the inside of the stance leg's foot. Avoid doesn't allow the desired stepping foot to cross the line.  avoidFeedback = how much of the actual crossing of that line is fedback as an error.
    /// </summary>
    public float AvoidFeedback
    {
        get { return avoidFeedback; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.0f);
            SetArgument("avoidFeedback", value);
            avoidFeedback = value;
        } 
    }

    private float leanAgainstVelocity = 0.0f;
    /// <summary>
    /// 
    /// </summary>
    public float LeanAgainstVelocity
    {
        get { return leanAgainstVelocity; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.0f);
            SetArgument("leanAgainstVelocity", value);
            leanAgainstVelocity = value;
        } 
    }

    private float stepDecisionThreshold = 0.0f;
    /// <summary>
    /// 
    /// </summary>
    public float StepDecisionThreshold
    {
        get { return stepDecisionThreshold; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.0f);
            SetArgument("stepDecisionThreshold", value);
            stepDecisionThreshold = value;
        } 
    }

    private bool stepIfInSupport = true;
    /// <summary>
    /// The balancer sometimes decides to step even if balanced
    /// </summary>
    public bool StepIfInSupport
    {
        get { return stepIfInSupport; } 
        set 
        {  
                
            SetArgument("stepIfInSupport", value);
            stepIfInSupport = value;
        } 
    }

    private bool alwaysStepWithFarthest = false;
    /// <summary>
    /// 
    /// </summary>
    public bool AlwaysStepWithFarthest
    {
        get { return alwaysStepWithFarthest; } 
        set 
        {  
                
            SetArgument("alwaysStepWithFarthest", value);
            alwaysStepWithFarthest = value;
        } 
    }

    private bool standUp = false;
    /// <summary>
    /// standup more with increased velocity
    /// </summary>
    public bool StandUp
    {
        get { return standUp; } 
        set 
        {  
                
            SetArgument("standUp", value);
            standUp = value;
        } 
    }

    private float depthFudge = 0.010f;
    /// <summary>
    /// Supposed to increase foot friction: Impact depth of a collision with the foot is changed when the balancer is running - impact.SetDepth(impact.GetDepth() - depthFudge)
    /// </summary>
    public float DepthFudge
    {
        get { return depthFudge; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.0f);
            SetArgument("depthFudge", value);
            depthFudge = value;
        } 
    }

    private float depthFudgeStagger = 0.010f;
    /// <summary>
    /// Supposed to increase foot friction: Impact depth of a collision with the foot is changed when staggerFall is running - impact.SetDepth(impact.GetDepth() - depthFudgeStagger)
    /// </summary>
    public float DepthFudgeStagger
    {
        get { return depthFudgeStagger; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.0f);
            SetArgument("depthFudgeStagger", value);
            depthFudgeStagger = value;
        } 
    }

    private float footFriction = 1.0f;
    /// <summary>
    /// Foot friction multiplier is multiplied by this amount if balancer is running
    /// </summary>
    public float FootFriction
    {
        get { return footFriction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 40.0f);
            SetArgument("footFriction", value);
            footFriction = value;
        } 
    }

    private float footFrictionStagger = 1.0f;
    /// <summary>
    /// Foot friction multiplier is multiplied by this amount if staggerFall is running
    /// </summary>
    public float FootFrictionStagger
    {
        get { return footFrictionStagger; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 40.0f);
            SetArgument("footFrictionStagger", value);
            footFrictionStagger = value;
        } 
    }

    private float backwardsLeanCutoff = 1.10f;
    /// <summary>
    /// Backwards lean threshold to cut off stay upright forces. 0.0 Vertical - 1.0 horizontal.  0.6 is a sensible value.  NB: the balancer does not fail in order to give stagger that extra step as it falls.  A backwards lean of GT 0.6 will generally mean the balancer will soon fail without stayUpright forces.
    /// </summary>
    public float BackwardsLeanCutoff
    {
        get { return backwardsLeanCutoff; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("backwardsLeanCutoff", value);
            backwardsLeanCutoff = value;
        } 
    }

    private float giveUpHeightEnd = 0.50f;
    /// <summary>
    /// if this value is different from giveUpHeight, actual giveUpHeight will be ramped toward this value
    /// </summary>
    public float GiveUpHeightEnd
    {
        get { return giveUpHeightEnd; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.50f);
            SetArgument("giveUpHeightEnd", value);
            giveUpHeightEnd = value;
        } 
    }

    private float balanceAbortThresholdEnd = 0.60f;
    /// <summary>
    /// if this value is different from balanceAbortThreshold, actual balanceAbortThreshold will be ramped toward this value
    /// </summary>
    public float BalanceAbortThresholdEnd
    {
        get { return balanceAbortThresholdEnd; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("balanceAbortThresholdEnd", value);
            balanceAbortThresholdEnd = value;
        } 
    }

    private float giveUpRampDuration = -1.00f;
    /// <summary>
    /// duration of ramp from start of behaviour for above two parameters. If smaller than 0, no ramp is applied
    /// </summary>
    public float GiveUpRampDuration
    {
        get { return giveUpRampDuration; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 10.0f);
            SetArgument("giveUpRampDuration", value);
            giveUpRampDuration = value;
        } 
    }

    private float leanToAbort = 0.60f;
    /// <summary>
    /// lean at which to send abort message when maxSteps or maxBalanceTime is reached
    /// </summary>
    public float LeanToAbort
    {
        get { return leanToAbort; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("leanToAbort", value);
            leanToAbort = value;
        } 
    }


    public EuphoriaMessageConfigureBalance(bool startNow) : base("configureBalance", startNow)
    { }

    public new void Reset()
    {
        stepHeight = 0.100f;
        stepHeightInc4Step = 0.100f;
        legsApartRestep = 0.200f;
        legsTogetherRestep = 1.0f;
        legsApartMax = 2.000f;
        taperKneeStrength = true;
        legStiffness = 12.000f;
        leftLegSwingDamping = 1.000f;
        rightLegSwingDamping = 1.000f;
        opposeGravityLegs = 1.000f;
        opposeGravityAnkles = 1.000f;
        leanAcc = 0.00f;
        hipLeanAcc = 0.50f;
        leanAccMax = 5.000f;
        resistAcc = 0.50f;
        resistAccMax = 3.00f;
        footSlipCompOnMovingFloor = true;
        ankleEquilibrium = 0.000f;
        extraFeetApart = 0.000f;
        dontStepTime = 0.00f;
        balanceAbortThreshold = 0.600f;
        giveUpHeight = 0.50f;
        stepClampScale = 1.000f;
        stepClampScaleVariance = 0.000f;
        predictionTimeHip = 0.30f;
        predictionTime = 0.20f;
        predictionTimeVariance = 0.00f;
        maxSteps = 100;
        maxBalanceTime = 50.0f;
        extraSteps = -1;
        extraTime = -1.00f;
        fallType = 0;
        fallMult = 1.0f;
        fallReduceGravityComp = false;
        rampHipPitchOnFail = false;
        stableLinSpeedThresh = 0.250f;
        stableRotSpeedThresh = 0.250f;
        failMustCollide = false;
        ignoreFailure = false;
        changeStepTime = -1.00f;
        balanceIndefinitely = false;
        movingFloor = false;
        airborneStep = true;
        useComDirTurnVelThresh = 0.0f;
        minKneeAngle = -0.50f;
        flatterSwingFeet = false;
        flatterStaticFeet = false;
        avoidLeg = false;
        avoidFootWidth = 0.10f;
        avoidFeedback = 0.60f;
        leanAgainstVelocity = 0.0f;
        stepDecisionThreshold = 0.0f;
        stepIfInSupport = true;
        alwaysStepWithFarthest = false;
        standUp = false;
        depthFudge = 0.010f;
        depthFudgeStagger = 0.010f;
        footFriction = 1.0f;
        footFrictionStagger = 1.0f;
        backwardsLeanCutoff = 1.10f;
        giveUpHeightEnd = 0.50f;
        balanceAbortThresholdEnd = 0.60f;
        giveUpRampDuration = -1.00f;
        leanToAbort = 0.60f;
        base.Reset();
    }
}
}
