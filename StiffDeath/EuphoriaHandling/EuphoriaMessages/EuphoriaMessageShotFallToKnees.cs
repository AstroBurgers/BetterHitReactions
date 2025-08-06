using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// shotFallToKnees:  configure the fall to knees shot.
/// </summary>

internal class EuphoriaMessageShotFallToKnees : EuphoriaMessage
{
    private bool fallToKnees = false;
    /// <summary>
    /// Type of reaction
    /// </summary>
    public bool FallToKnees
    {
        get { return fallToKnees; } 
        set 
        {  
                
            SetArgument("fallToKnees", value);
            fallToKnees = value;
        } 
    }

    private bool ftkAlwaysChangeFall = false;
    /// <summary>
    /// Always change fall behaviour.  If false only change when falling forward
    /// </summary>
    public bool FtkAlwaysChangeFall
    {
        get { return ftkAlwaysChangeFall; } 
        set 
        {  
                
            SetArgument("ftkAlwaysChangeFall", value);
            ftkAlwaysChangeFall = value;
        } 
    }

    private float ftkBalanceTime = 0.70f;
    /// <summary>
    /// How long the balancer runs for before fallToKnees starts
    /// </summary>
    public float FtkBalanceTime
    {
        get { return ftkBalanceTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 5.00f);
            SetArgument("ftkBalanceTime", value);
            ftkBalanceTime = value;
        } 
    }

    private float ftkHelperForce = 200.0f;
    /// <summary>
    /// Hip helper force magnitude - to help character lean over balance point of line between toes
    /// </summary>
    public float FtkHelperForce
    {
        get { return ftkHelperForce; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2000.00f);
            SetArgument("ftkHelperForce", value);
            ftkHelperForce = value;
        } 
    }

    private bool ftkHelperForceOnSpine = true;
    /// <summary>
    /// Helper force applied to spine3 aswell
    /// </summary>
    public bool FtkHelperForceOnSpine
    {
        get { return ftkHelperForceOnSpine; } 
        set 
        {  
                
            SetArgument("ftkHelperForceOnSpine", value);
            ftkHelperForceOnSpine = value;
        } 
    }

    private float ftkLeanHelp = 0.050f;
    /// <summary>
    /// Help balancer lean amount - to help character lean over balance point of line between toes.  Half of this is also applied as hipLean
    /// </summary>
    public float FtkLeanHelp
    {
        get { return ftkLeanHelp; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 0.30f);
            SetArgument("ftkLeanHelp", value);
            ftkLeanHelp = value;
        } 
    }

    private float ftkSpineBend = -0.00f;
    /// <summary>
    /// Bend applied to spine when falling from knees. (+ve forward - try -0.1) (only if rds called)
    /// </summary>
    public float FtkSpineBend
    {
        get { return ftkSpineBend; } 
        set 
        {  
            value = MathHelper.Clamp(value, -0.20f, 0.30f);
            SetArgument("ftkSpineBend", value);
            ftkSpineBend = value;
        } 
    }

    private bool ftkStiffSpine = false;
    /// <summary>
    /// Stiffen spine when falling from knees (only if rds called)
    /// </summary>
    public bool FtkStiffSpine
    {
        get { return ftkStiffSpine; } 
        set 
        {  
                
            SetArgument("ftkStiffSpine", value);
            ftkStiffSpine = value;
        } 
    }

    private float ftkImpactLooseness = 0.50f;
    /// <summary>
    /// Looseness (muscleStiffness = 1.01f - m_parameters.ftkImpactLooseness) applied to upperBody on knee impacts
    /// </summary>
    public float FtkImpactLooseness
    {
        get { return ftkImpactLooseness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.0f);
            SetArgument("ftkImpactLooseness", value);
            ftkImpactLooseness = value;
        } 
    }

    private float ftkImpactLoosenessTime = 0.20f;
    /// <summary>
    /// Time that looseness is applied after knee impacts
    /// </summary>
    public float FtkImpactLoosenessTime
    {
        get { return ftkImpactLoosenessTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, -0.10f, 1.00f);
            SetArgument("ftkImpactLoosenessTime", value);
            ftkImpactLoosenessTime = value;
        } 
    }

    private float ftkBendRate = 0.70f;
    /// <summary>
    /// Rate at which the legs are bent to go from standing to on knees
    /// </summary>
    public float FtkBendRate
    {
        get { return ftkBendRate; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 4.00f);
            SetArgument("ftkBendRate", value);
            ftkBendRate = value;
        } 
    }

    private float ftkHipBlend = 0.30f;
    /// <summary>
    /// Blend from current hip to balancing on knees hip angle
    /// </summary>
    public float FtkHipBlend
    {
        get { return ftkHipBlend; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("ftkHipBlend", value);
            ftkHipBlend = value;
        } 
    }

    private float ftkLungeProb = 0.00f;
    /// <summary>
    /// Probability that a lunge reaction will be allowed
    /// </summary>
    public float FtkLungeProb
    {
        get { return ftkLungeProb; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("ftkLungeProb", value);
            ftkLungeProb = value;
        } 
    }

    private bool ftkKneeSpin = false;
    /// <summary>
    /// When on knees allow some spinning of the character.  If false then the balancers' footSlipCompensation remains on and tends to keep the character facing the same way as when it was balancing.
    /// </summary>
    public bool FtkKneeSpin
    {
        get { return ftkKneeSpin; } 
        set 
        {  
                
            SetArgument("ftkKneeSpin", value);
            ftkKneeSpin = value;
        } 
    }

    private float ftkFricMult = 1.00f;
    /// <summary>
    /// Multiplier on the reduction of friction for the feet based on angle away from horizontal - helps the character fall to knees quicker
    /// </summary>
    public float FtkFricMult
    {
        get { return ftkFricMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 5.00f);
            SetArgument("ftkFricMult", value);
            ftkFricMult = value;
        } 
    }

    private float ftkHipAngleFall = 0.50f;
    /// <summary>
    /// Apply this hip angle when the character starts to fall backwards when on knees
    /// </summary>
    public float FtkHipAngleFall
    {
        get { return ftkHipAngleFall; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("ftkHipAngleFall", value);
            ftkHipAngleFall = value;
        } 
    }

    private float ftkPitchForwards = 0.10f;
    /// <summary>
    /// Hip pitch applied (+ve forward, -ve backwards) if character is falling forwards on way down to it's knees
    /// </summary>
    public float FtkPitchForwards
    {
        get { return ftkPitchForwards; } 
        set 
        {  
            value = MathHelper.Clamp(value, -0.50f, 0.50f);
            SetArgument("ftkPitchForwards", value);
            ftkPitchForwards = value;
        } 
    }

    private float ftkPitchBackwards = 0.10f;
    /// <summary>
    /// Hip pitch applied (+ve forward, -ve backwards) if character is falling backwards on way down to it's knees
    /// </summary>
    public float FtkPitchBackwards
    {
        get { return ftkPitchBackwards; } 
        set 
        {  
            value = MathHelper.Clamp(value, -0.50f, 0.50f);
            SetArgument("ftkPitchBackwards", value);
            ftkPitchBackwards = value;
        } 
    }

    private float ftkFallBelowStab = 0.50f;
    /// <summary>
    /// Balancer instability below which the character starts to bend legs even if it isn't going to fall on to it's knees (i.e. if going backwards). 0.3 almost ensures a fall to knees but means the character will keep stepping backward until it slows down enough.
    /// </summary>
    public float FtkFallBelowStab
    {
        get { return ftkFallBelowStab; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 15.00f);
            SetArgument("ftkFallBelowStab", value);
            ftkFallBelowStab = value;
        } 
    }

    private float ftkBalanceAbortThreshold = 2.00f;
    /// <summary>
    /// when the character gives up and goes into a fall
    /// </summary>
    public float FtkBalanceAbortThreshold
    {
        get { return ftkBalanceAbortThreshold; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 4.00f);
            SetArgument("ftkBalanceAbortThreshold", value);
            ftkBalanceAbortThreshold = value;
        } 
    }

    private int ftkOnKneesArmType = 2;
    /// <summary>
    /// Type of arm response when on knees falling forward 0=useFallArms (from RollDownstairs or catchFall), 1= armsIn, 2=armsOut
    /// </summary>
    public int FtkOnKneesArmType
    {
        get { return ftkOnKneesArmType; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("ftkOnKneesArmType", value);
            ftkOnKneesArmType = value;
        } 
    }

    private float ftkReleaseReachForWound = -1.00f;
    /// <summary>
    /// Release the reachForWound this amount of time after the knees have hit.  If  LT  0.0 then keep reaching for wound regardless of fall/onground state.
    /// </summary>
    public float FtkReleaseReachForWound
    {
        get { return ftkReleaseReachForWound; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 5.00f);
            SetArgument("ftkReleaseReachForWound", value);
            ftkReleaseReachForWound = value;
        } 
    }

    private bool ftkReachForWound = true;
    /// <summary>
    /// true = Keep reaching for wound regardless of fall/onground state.  false = respect the shotConfigureArms params: reachFalling, reachFallingWithOneHand, reachOnFloor
    /// </summary>
    public bool FtkReachForWound
    {
        get { return ftkReachForWound; } 
        set 
        {  
                
            SetArgument("ftkReachForWound", value);
            ftkReachForWound = value;
        } 
    }

    private bool ftkReleasePointGun = false;
    /// <summary>
    /// Override the pointGun when knees hit
    /// </summary>
    public bool FtkReleasePointGun
    {
        get { return ftkReleasePointGun; } 
        set 
        {  
                
            SetArgument("ftkReleasePointGun", value);
            ftkReleasePointGun = value;
        } 
    }

    private bool ftkFailMustCollide = true;
    /// <summary>
    /// The upper body of the character must be colliding and other failure conditions met to fail
    /// </summary>
    public bool FtkFailMustCollide
    {
        get { return ftkFailMustCollide; } 
        set 
        {  
                
            SetArgument("ftkFailMustCollide", value);
            ftkFailMustCollide = value;
        } 
    }


    public EuphoriaMessageShotFallToKnees(bool startNow) : base("shotFallToKnees", startNow)
    { }

    public new void Reset()
    {
        fallToKnees = false;
        ftkAlwaysChangeFall = false;
        ftkBalanceTime = 0.70f;
        ftkHelperForce = 200.0f;
        ftkHelperForceOnSpine = true;
        ftkLeanHelp = 0.050f;
        ftkSpineBend = -0.00f;
        ftkStiffSpine = false;
        ftkImpactLooseness = 0.50f;
        ftkImpactLoosenessTime = 0.20f;
        ftkBendRate = 0.70f;
        ftkHipBlend = 0.30f;
        ftkLungeProb = 0.00f;
        ftkKneeSpin = false;
        ftkFricMult = 1.00f;
        ftkHipAngleFall = 0.50f;
        ftkPitchForwards = 0.10f;
        ftkPitchBackwards = 0.10f;
        ftkFallBelowStab = 0.50f;
        ftkBalanceAbortThreshold = 2.00f;
        ftkOnKneesArmType = 2;
        ftkReleaseReachForWound = -1.00f;
        ftkReachForWound = true;
        ftkReleasePointGun = false;
        ftkFailMustCollide = true;
        base.Reset();
    }
}
}
