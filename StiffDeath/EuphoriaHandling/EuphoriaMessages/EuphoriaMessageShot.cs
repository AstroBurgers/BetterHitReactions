namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageShot : EuphoriaMessage
{
    private float bodyStiffness = 11.00f;
    /// <summary>
    /// stiffness of body. Feeds through to roll_up
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

    private float spineDamping = 1.00f;
    /// <summary>
    /// stiffness of body. Feeds through to roll_up
    /// </summary>
    public float SpineDamping
    {
        get { return spineDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 2.00f);
            SetArgument("spineDamping", value);
            spineDamping = value;
        } 
    }

    private float armStiffness = 10.00f;
    /// <summary>
    /// arm stiffness
    /// </summary>
    public float ArmStiffness
    {
        get { return armStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.00f, 16.00f);
            SetArgument("armStiffness", value);
            armStiffness = value;
        } 
    }

    private float initialNeckStiffness = 14.00f;
    /// <summary>
    /// initial stiffness of neck after being shot.
    /// </summary>
    public float InitialNeckStiffness
    {
        get { return initialNeckStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 3.00f, 16.00f);
            SetArgument("initialNeckStiffness", value);
            initialNeckStiffness = value;
        } 
    }

    private float initialNeckDamping = 1.00f;
    /// <summary>
    /// intial damping of neck after being shot.
    /// </summary>
    public float InitialNeckDamping
    {
        get { return initialNeckDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 10.00f);
            SetArgument("initialNeckDamping", value);
            initialNeckDamping = value;
        } 
    }

    private float neckStiffness = 14.00f;
    /// <summary>
    /// stiffness of neck.
    /// </summary>
    public float NeckStiffness
    {
        get { return neckStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 3.00f, 16.00f);
            SetArgument("neckStiffness", value);
            neckStiffness = value;
        } 
    }

    private float neckDamping = 1.00f;
    /// <summary>
    /// damping of neck.
    /// </summary>
    public float NeckDamping
    {
        get { return neckDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 2.00f);
            SetArgument("neckDamping", value);
            neckDamping = value;
        } 
    }

    private float kMultOnLoose = 0.00f;
    /// <summary>
    /// how much to add to upperbody stiffness dependent on looseness
    /// </summary>
    public float KMultOnLoose
    {
        get { return kMultOnLoose; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("kMultOnLoose", value);
            kMultOnLoose = value;
        } 
    }

    private float kMult4Legs = 0.30f;
    /// <summary>
    /// how much to add to leg stiffnesses dependent on looseness
    /// </summary>
    public float KMult4Legs
    {
        get { return kMult4Legs; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("kMult4Legs", value);
            kMult4Legs = value;
        } 
    }

    private float loosenessAmount = 1.00f;
    /// <summary>
    /// how loose the character is made by a newBullet. between 0 and 1
    /// </summary>
    public float LoosenessAmount
    {
        get { return loosenessAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("loosenessAmount", value);
            loosenessAmount = value;
        } 
    }

    private float looseness4Fall = 0.00f;
    /// <summary>
    /// how loose the character is made by a newBullet if falling
    /// </summary>
    public float Looseness4Fall
    {
        get { return looseness4Fall; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("looseness4Fall", value);
            looseness4Fall = value;
        } 
    }

    private float looseness4Stagger = 0.00f;
    /// <summary>
    /// how loose the upperBody of the character is made by a newBullet if staggerFall is running (and not falling).  Note atm the neck ramp values are ignored in staggerFall
    /// </summary>
    public float Looseness4Stagger
    {
        get { return looseness4Stagger; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("looseness4Stagger", value);
            looseness4Stagger = value;
        } 
    }

    private float minArmsLooseness = 0.10f;
    /// <summary>
    /// minimum looseness to apply to the arms
    /// </summary>
    public float MinArmsLooseness
    {
        get { return minArmsLooseness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("minArmsLooseness", value);
            minArmsLooseness = value;
        } 
    }

    private float minLegsLooseness = 0.10f;
    /// <summary>
    /// minimum looseness to apply to the Legs
    /// </summary>
    public float MinLegsLooseness
    {
        get { return minLegsLooseness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("minLegsLooseness", value);
            minLegsLooseness = value;
        } 
    }

    private float grabHoldTime = 2.00f;
    /// <summary>
    /// how long to hold for before returning to relaxed arm position
    /// </summary>
    public float GrabHoldTime
    {
        get { return grabHoldTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("grabHoldTime", value);
            grabHoldTime = value;
        } 
    }

    private bool spineBlendExagCPain = false;
    /// <summary>
    /// true: spine is blended with zero pose, false: spine is blended with zero pose if not setting exag or cpain
    /// </summary>
    public bool SpineBlendExagCPain
    {
        get { return spineBlendExagCPain; } 
        set 
        {  
                
            SetArgument("spineBlendExagCPain", value);
            spineBlendExagCPain = value;
        } 
    }

    private float spineBlendZero = 0.60f;
    /// <summary>
    /// spine is always blended with zero pose this much and up to 1 as the character become stationary.  If negative no blend is ever applied.
    /// </summary>
    public float SpineBlendZero
    {
        get { return spineBlendZero; } 
        set 
        {  
            value = MathHelper.Clamp(value, -0.10f, 1.0f);
            SetArgument("spineBlendZero", value);
            spineBlendZero = value;
        } 
    }

    private bool bulletProofVest = false;
    /// <summary>
    /// looseness applied to spine is different if bulletProofVest is true
    /// </summary>
    public bool BulletProofVest
    {
        get { return bulletProofVest; } 
        set 
        {  
                
            SetArgument("bulletProofVest", value);
            bulletProofVest = value;
        } 
    }

    private bool alwaysResetLooseness = true;
    /// <summary>
    /// looseness always reset on shotNewBullet even if previous looseness ramp still running.  Except for the neck which has it's own ramp.
    /// </summary>
    public bool AlwaysResetLooseness
    {
        get { return alwaysResetLooseness; } 
        set 
        {  
                
            SetArgument("alwaysResetLooseness", value);
            alwaysResetLooseness = value;
        } 
    }

    private bool alwaysResetNeckLooseness = true;
    /// <summary>
    /// Neck looseness always reset on shotNewBullet even if previous looseness ramp still running
    /// </summary>
    public bool AlwaysResetNeckLooseness
    {
        get { return alwaysResetNeckLooseness; } 
        set 
        {  
                
            SetArgument("alwaysResetNeckLooseness", value);
            alwaysResetNeckLooseness = value;
        } 
    }

    private float angVelScale = 1.00f;
    /// <summary>
    /// How much to scale the angular velocity coming in from animation of a part if it is in angVelScaleMask (otherwise scale by 1.0)
    /// </summary>
    public float AngVelScale
    {
        get { return angVelScale; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("angVelScale", value);
            angVelScale = value;
        } 
    }

    private string angVelScaleMask = "fb";
    /// <summary>
    /// Parts to scale the initial angular velocity by angVelScale (otherwize scale by 1.0)
    /// </summary>
    public string AngVelScaleMask
    {
        get { return angVelScaleMask; } 
        set 
        {  
                
            SetArgument("angVelScaleMask", value);
            angVelScaleMask = value;
        } 
    }

    private float flingWidth = 0.50f;
    /// <summary>
    /// Width of the fling behaviour.
    /// </summary>
    public float FlingWidth
    {
        get { return flingWidth; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("flingWidth", value);
            flingWidth = value;
        } 
    }

    private float flingTime = 0.60f;
    /// <summary>
    /// Duration of the fling behaviour.
    /// </summary>
    public float FlingTime
    {
        get { return flingTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("flingTime", value);
            flingTime = value;
        } 
    }

    private float timeBeforeReachForWound = 0.20f;
    /// <summary>
    /// time, in seconds, before the character begins to grab for the wound on the first hit
    /// </summary>
    public float TimeBeforeReachForWound
    {
        get { return timeBeforeReachForWound; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("timeBeforeReachForWound", value);
            timeBeforeReachForWound = value;
        } 
    }

    private float exagDuration = 0.00f;
    /// <summary>
    /// exaggerate bullet duration (at exagMag/exagTwistMag)
    /// </summary>
    public float ExagDuration
    {
        get { return exagDuration; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("exagDuration", value);
            exagDuration = value;
        } 
    }

    private float exagMag = 1.00f;
    /// <summary>
    /// exaggerate bullet spine Lean magnitude
    /// </summary>
    public float ExagMag
    {
        get { return exagMag; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("exagMag", value);
            exagMag = value;
        } 
    }

    private float exagTwistMag = 0.50f;
    /// <summary>
    /// exaggerate bullet spine Twist magnitude
    /// </summary>
    public float ExagTwistMag
    {
        get { return exagTwistMag; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("exagTwistMag", value);
            exagTwistMag = value;
        } 
    }

    private float exagSmooth2Zero = 0.00f;
    /// <summary>
    /// exaggerate bullet duration ramping to zero after exagDuration
    /// </summary>
    public float ExagSmooth2Zero
    {
        get { return exagSmooth2Zero; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("exagSmooth2Zero", value);
            exagSmooth2Zero = value;
        } 
    }

    private float exagZeroTime = 0.00f;
    /// <summary>
    /// exaggerate bullet time spent at 0 spine lean/twist after exagDuration + exagSmooth2Zero
    /// </summary>
    public float ExagZeroTime
    {
        get { return exagZeroTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("exagZeroTime", value);
            exagZeroTime = value;
        } 
    }

    private float cpainSmooth2Time = 0.20f;
    /// <summary>
    /// conscious pain duration ramping from zero to cpainMag/cpainTwistMag
    /// </summary>
    public float CpainSmooth2Time
    {
        get { return cpainSmooth2Time; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("cpainSmooth2Time", value);
            cpainSmooth2Time = value;
        } 
    }

    private float cpainDuration = 0.00f;
    /// <summary>
    /// conscious pain duration at cpainMag/cpainTwistMag after cpainSmooth2Time
    /// </summary>
    public float CpainDuration
    {
        get { return cpainDuration; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("cpainDuration", value);
            cpainDuration = value;
        } 
    }

    private float cpainMag = 1.00f;
    /// <summary>
    /// conscious pain spine Lean(back/Forward) magnitude (Replaces spinePainMultiplier)
    /// </summary>
    public float CpainMag
    {
        get { return cpainMag; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.00f);
            SetArgument("cpainMag", value);
            cpainMag = value;
        } 
    }

    private float cpainTwistMag = 0.50f;
    /// <summary>
    /// conscious pain spine Twist/Lean2Side magnitude Replaces spinePainTwistMultiplier)
    /// </summary>
    public float CpainTwistMag
    {
        get { return cpainTwistMag; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("cpainTwistMag", value);
            cpainTwistMag = value;
        } 
    }

    private float cpainSmooth2Zero = 1.50f;
    /// <summary>
    /// conscious pain ramping to zero after cpainSmooth2Time + cpainDuration (Replaces spinePainTime)
    /// </summary>
    public float CpainSmooth2Zero
    {
        get { return cpainSmooth2Zero; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("cpainSmooth2Zero", value);
            cpainSmooth2Zero = value;
        } 
    }

    private bool crouching = false;
    /// <summary>
    /// is the guy crouching or not
    /// </summary>
    public bool Crouching
    {
        get { return crouching; } 
        set 
        {  
                
            SetArgument("crouching", value);
            crouching = value;
        } 
    }

    private bool chickenArms = false;
    /// <summary>
    /// Type of reaction
    /// </summary>
    public bool ChickenArms
    {
        get { return chickenArms; } 
        set 
        {  
                
            SetArgument("chickenArms", value);
            chickenArms = value;
        } 
    }

    private bool reachForWound = true;
    /// <summary>
    /// Type of reaction
    /// </summary>
    public bool ReachForWound
    {
        get { return reachForWound; } 
        set 
        {  
                
            SetArgument("reachForWound", value);
            reachForWound = value;
        } 
    }

    private bool fling = false;
    /// <summary>
    /// Type of reaction
    /// </summary>
    public bool Fling
    {
        get { return fling; } 
        set 
        {  
                
            SetArgument("fling", value);
            fling = value;
        } 
    }

    private bool allowInjuredArm = false;
    /// <summary>
    /// injured arm code runs if arm hit (turns and steps and bends injured arm)
    /// </summary>
    public bool AllowInjuredArm
    {
        get { return allowInjuredArm; } 
        set 
        {  
                
            SetArgument("allowInjuredArm", value);
            allowInjuredArm = value;
        } 
    }

    private bool allowInjuredLeg = true;
    /// <summary>
    /// when false injured leg is not bent and character does not bend to reach it
    /// </summary>
    public bool AllowInjuredLeg
    {
        get { return allowInjuredLeg; } 
        set 
        {  
                
            SetArgument("allowInjuredLeg", value);
            allowInjuredLeg = value;
        } 
    }

    private bool allowInjuredLowerLegReach = false;
    /// <summary>
    /// when false don't try to reach for injured Lower Legs (shins/feet)
    /// </summary>
    public bool AllowInjuredLowerLegReach
    {
        get { return allowInjuredLowerLegReach; } 
        set 
        {  
                
            SetArgument("allowInjuredLowerLegReach", value);
            allowInjuredLowerLegReach = value;
        } 
    }

    private bool allowInjuredThighReach = true;
    /// <summary>
    /// when false don't try to reach for injured Thighs
    /// </summary>
    public bool AllowInjuredThighReach
    {
        get { return allowInjuredThighReach; } 
        set 
        {  
                
            SetArgument("allowInjuredThighReach", value);
            allowInjuredThighReach = value;
        } 
    }

    private bool stableHandsAndNeck = false;
    /// <summary>
    /// additional stability for hands and neck (less loose)
    /// </summary>
    public bool StableHandsAndNeck
    {
        get { return stableHandsAndNeck; } 
        set 
        {  
                
            SetArgument("stableHandsAndNeck", value);
            stableHandsAndNeck = value;
        } 
    }

    private bool melee = false;
    /// <summary>
    /// 
    /// </summary>
    public bool Melee
    {
        get { return melee; } 
        set 
        {  
                
            SetArgument("melee", value);
            melee = value;
        } 
    }

    private int fallingReaction = 0;
    /// <summary>
    /// 0=Rollup, 1=Catchfall, 2=rollDownStairs, 3=smartFall
    /// </summary>
    public int FallingReaction
    {
        get { return fallingReaction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 3);
            SetArgument("fallingReaction", value);
            fallingReaction = value;
        } 
    }

    private bool useExtendedCatchFall = false;
    /// <summary>
    /// keep the character active instead of relaxing at the end of the catch fall
    /// </summary>
    public bool UseExtendedCatchFall
    {
        get { return useExtendedCatchFall; } 
        set 
        {  
                
            SetArgument("useExtendedCatchFall", value);
            useExtendedCatchFall = value;
        } 
    }

    private float initialWeaknessZeroDuration = 0.00f;
    /// <summary>
    /// duration for which the character's upper body stays at minimum stiffness (not quite zero)
    /// </summary>
    public float InitialWeaknessZeroDuration
    {
        get { return initialWeaknessZeroDuration; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("initialWeaknessZeroDuration", value);
            initialWeaknessZeroDuration = value;
        } 
    }

    private float initialWeaknessRampDuration = 0.40f;
    /// <summary>
    /// duration of the ramp to bring the character's upper body stiffness back to normal levels
    /// </summary>
    public float InitialWeaknessRampDuration
    {
        get { return initialWeaknessRampDuration; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("initialWeaknessRampDuration", value);
            initialWeaknessRampDuration = value;
        } 
    }

    private float initialNeckDuration = 0.00f;
    /// <summary>
    /// duration for which the neck stays at intial stiffness/damping
    /// </summary>
    public float InitialNeckDuration
    {
        get { return initialNeckDuration; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("initialNeckDuration", value);
            initialNeckDuration = value;
        } 
    }

    private float initialNeckRampDuration = 0.40f;
    /// <summary>
    /// duration of the ramp to bring the neck stiffness/damping back to normal levels
    /// </summary>
    public float InitialNeckRampDuration
    {
        get { return initialNeckRampDuration; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("initialNeckRampDuration", value);
            initialNeckRampDuration = value;
        } 
    }

    private bool useCStrModulation = false;
    /// <summary>
    /// if enabled upper and lower body strength scales with character strength, using the range given by parameters below
    /// </summary>
    public bool UseCStrModulation
    {
        get { return useCStrModulation; } 
        set 
        {  
                
            SetArgument("useCStrModulation", value);
            useCStrModulation = value;
        } 
    }

    private float cStrUpperMin = 0.10f;
    /// <summary>
    /// proportions to what the strength would be normally
    /// </summary>
    public float CStrUpperMin
    {
        get { return cStrUpperMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 1.00f);
            SetArgument("cStrUpperMin", value);
            cStrUpperMin = value;
        } 
    }

    private float cStrUpperMax = 1.00f;
    /// <summary>
    /// 
    /// </summary>
    public float CStrUpperMax
    {
        get { return cStrUpperMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 1.00f);
            SetArgument("cStrUpperMax", value);
            cStrUpperMax = value;
        } 
    }

    private float cStrLowerMin = 0.10f;
    /// <summary>
    /// 
    /// </summary>
    public float CStrLowerMin
    {
        get { return cStrLowerMin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 1.00f);
            SetArgument("cStrLowerMin", value);
            cStrLowerMin = value;
        } 
    }

    private float cStrLowerMax = 1.00f;
    /// <summary>
    /// 
    /// </summary>
    public float CStrLowerMax
    {
        get { return cStrLowerMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 1.00f);
            SetArgument("cStrLowerMax", value);
            cStrLowerMax = value;
        } 
    }

    private float deathTime = -1.00f;
    /// <summary>
    /// time to death (HACK for underwater). If -ve don't ever die
    /// </summary>
    public float DeathTime
    {
        get { return deathTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 1000.0f);
            SetArgument("deathTime", value);
            deathTime = value;
        } 
    }


    public EuphoriaMessageShot(bool startNow) : base("shot", startNow)
    { }

    public new void Reset()
    {
        bodyStiffness = 11.00f;
        spineDamping = 1.00f;
        armStiffness = 10.00f;
        initialNeckStiffness = 14.00f;
        initialNeckDamping = 1.00f;
        neckStiffness = 14.00f;
        neckDamping = 1.00f;
        kMultOnLoose = 0.00f;
        kMult4Legs = 0.30f;
        loosenessAmount = 1.00f;
        looseness4Fall = 0.00f;
        looseness4Stagger = 0.00f;
        minArmsLooseness = 0.10f;
        minLegsLooseness = 0.10f;
        grabHoldTime = 2.00f;
        spineBlendExagCPain = false;
        spineBlendZero = 0.60f;
        bulletProofVest = false;
        alwaysResetLooseness = true;
        alwaysResetNeckLooseness = true;
        angVelScale = 1.00f;
        angVelScaleMask = "fb";
        flingWidth = 0.50f;
        flingTime = 0.60f;
        timeBeforeReachForWound = 0.20f;
        exagDuration = 0.00f;
        exagMag = 1.00f;
        exagTwistMag = 0.50f;
        exagSmooth2Zero = 0.00f;
        exagZeroTime = 0.00f;
        cpainSmooth2Time = 0.20f;
        cpainDuration = 0.00f;
        cpainMag = 1.00f;
        cpainTwistMag = 0.50f;
        cpainSmooth2Zero = 1.50f;
        crouching = false;
        chickenArms = false;
        reachForWound = true;
        fling = false;
        allowInjuredArm = false;
        allowInjuredLeg = true;
        allowInjuredLowerLegReach = false;
        allowInjuredThighReach = true;
        stableHandsAndNeck = false;
        melee = false;
        fallingReaction = 0;
        useExtendedCatchFall = false;
        initialWeaknessZeroDuration = 0.00f;
        initialWeaknessRampDuration = 0.40f;
        initialNeckDuration = 0.00f;
        initialNeckRampDuration = 0.40f;
        useCStrModulation = false;
        cStrUpperMin = 0.10f;
        cStrUpperMax = 1.00f;
        cStrLowerMin = 0.10f;
        cStrLowerMax = 1.00f;
        deathTime = -1.00f;
        base.Reset();
    }
}
}
