using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// shotConfigureArms:  configure the arm reactions in shot
/// </summary>

internal class EuphoriaMessageShotConfigureArms : EuphoriaMessage
{
    private bool brace = true;
    /// <summary>
    /// blind brace with arms if appropriate
    /// </summary>
    public bool Brace
    {
        get { return brace; } 
        set 
        {  
                
            SetArgument("brace", value);
            brace = value;
        } 
    }

    private bool pointGun = false;
    /// <summary>
    /// Point gun if appropriate.
    /// </summary>
    public bool PointGun
    {
        get { return pointGun; } 
        set 
        {  
                
            SetArgument("pointGun", value);
            pointGun = value;
        } 
    }

    private bool useArmsWindmill = true;
    /// <summary>
    /// armsWindmill if going backwards fast enough
    /// </summary>
    public bool UseArmsWindmill
    {
        get { return useArmsWindmill; } 
        set 
        {  
                
            SetArgument("useArmsWindmill", value);
            useArmsWindmill = value;
        } 
    }

    private int releaseWound = 1;
    /// <summary>
    /// release wound if going sideways/forward fast enough.  0 = don't. 1 = only if bracing. 2 = any default arm reaction
    /// </summary>
    public int ReleaseWound
    {
        get { return releaseWound; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("releaseWound", value);
            releaseWound = value;
        } 
    }

    private int reachFalling = 0;
    /// <summary>
    /// reachForWound when falling 0 = false, 1 = true, 2 = once per shot performance
    /// </summary>
    public int ReachFalling
    {
        get { return reachFalling; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("reachFalling", value);
            reachFalling = value;
        } 
    }

    private int reachFallingWithOneHand = 3;
    /// <summary>
    /// Force character to reach for wound with only one hand when falling or fallen.  0= allow 2 handed reach, 1= left only if 2 handed possible, 2= right only if 2 handed possible, 3 = one handed but automatic (allows switching of hands)
    /// </summary>
    public int ReachFallingWithOneHand
    {
        get { return reachFallingWithOneHand; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 3);
            SetArgument("reachFallingWithOneHand", value);
            reachFallingWithOneHand = value;
        } 
    }

    private int reachOnFloor = 0;
    /// <summary>
    /// reachForWound when on floor - 0 = false, 1 = true, 2 = once per shot performance
    /// </summary>
    public int ReachOnFloor
    {
        get { return reachOnFloor; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("reachOnFloor", value);
            reachOnFloor = value;
        } 
    }

    private float alwaysReachTime = 0.30f;
    /// <summary>
    /// Inhibit arms brace for this amount of time after reachForWound has begun
    /// </summary>
    public float AlwaysReachTime
    {
        get { return alwaysReachTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("alwaysReachTime", value);
            alwaysReachTime = value;
        } 
    }

    private float aWSpeedMult = 1.0f;
    /// <summary>
    /// For armsWindmill, multiplier on character speed - increase of speed of circling is proportional to character speed (max speed of circliing increase = 1.5). eg. lowering the value increases the range of velocity that the 0-1.5 is applied over
    /// </summary>
    public float AWSpeedMult
    {
        get { return AWSpeedMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("AWSpeedMult", value);
            AWSpeedMult = value;
        } 
    }

    private float aWRadiusMult = 1.0f;
    /// <summary>
    /// For armsWindmill, multiplier on character speed - increase of radii is proportional to character speed (max radius increase = 0.45). eg. lowering the value increases the range of velocity that the 0-0.45 is applied over
    /// </summary>
    public float AWRadiusMult
    {
        get { return AWRadiusMult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("AWRadiusMult", value);
            AWRadiusMult = value;
        } 
    }

    private float aWStiffnessAdd = 4.0f;
    /// <summary>
    /// For armsWindmill, added arm stiffness ranges from 0 to AWStiffnessAdd
    /// </summary>
    public float AWStiffnessAdd
    {
        get { return AWStiffnessAdd; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 16.0f);
            SetArgument("AWStiffnessAdd", value);
            AWStiffnessAdd = value;
        } 
    }

    private int reachWithOneHand = 0;
    /// <summary>
    /// Force character to reach for wound with only one hand.  0= allow 2 handed reach, 1= left only if 2 handed possible, 2= right only if 2 handed possible
    /// </summary>
    public int ReachWithOneHand
    {
        get { return reachWithOneHand; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("reachWithOneHand", value);
            reachWithOneHand = value;
        } 
    }

    private bool allowLeftPistolRFW = true;
    /// <summary>
    /// Allow character to reach for wound with left hand if holding a pistol.  It never will for a rifle. If pointGun is running this will only happen if the hand cannot point and pointGun:poseUnusedGunArm = false
    /// </summary>
    public bool AllowLeftPistolRFW
    {
        get { return allowLeftPistolRFW; } 
        set 
        {  
                
            SetArgument("allowLeftPistolRFW", value);
            allowLeftPistolRFW = value;
        } 
    }

    private bool allowRightPistolRFW = false;
    /// <summary>
    /// Allow character to reach for wound with right hand if holding a pistol. It never will for a rifle. If pointGun is running this will only happen if the hand cannot point and pointGun:poseUnusedGunArm = false
    /// </summary>
    public bool AllowRightPistolRFW
    {
        get { return allowRightPistolRFW; } 
        set 
        {  
                
            SetArgument("allowRightPistolRFW", value);
            allowRightPistolRFW = value;
        } 
    }

    private bool rfwWithPistol = false;
    /// <summary>
    /// Override pointGun and reachForWound if desired if holding a pistol.  It never will for a rifle
    /// </summary>
    public bool RfwWithPistol
    {
        get { return rfwWithPistol; } 
        set 
        {  
                
            SetArgument("rfwWithPistol", value);
            rfwWithPistol = value;
        } 
    }

    private bool fling2 = false;
    /// <summary>
    /// Type of reaction
    /// </summary>
    public bool Fling2
    {
        get { return fling2; } 
        set 
        {  
                
            SetArgument("fling2", value);
            fling2 = value;
        } 
    }

    private bool fling2Left = true;
    /// <summary>
    /// Fling the left arm
    /// </summary>
    public bool Fling2Left
    {
        get { return fling2Left; } 
        set 
        {  
                
            SetArgument("fling2Left", value);
            fling2Left = value;
        } 
    }

    private bool fling2Right = true;
    /// <summary>
    /// Fling the right arm
    /// </summary>
    public bool Fling2Right
    {
        get { return fling2Right; } 
        set 
        {  
                
            SetArgument("fling2Right", value);
            fling2Right = value;
        } 
    }

    private bool fling2OverrideStagger = false;
    /// <summary>
    /// Override stagger arms even if staggerFall:m_upperBodyReaction = true
    /// </summary>
    public bool Fling2OverrideStagger
    {
        get { return fling2OverrideStagger; } 
        set 
        {  
                
            SetArgument("fling2OverrideStagger", value);
            fling2OverrideStagger = value;
        } 
    }

    private float fling2TimeBefore = 0.10f;
    /// <summary>
    /// Time after hit that the fling will start (allows for a bit of loose arm movement from bullet impact.snap etc)
    /// </summary>
    public float Fling2TimeBefore
    {
        get { return fling2TimeBefore; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("fling2TimeBefore", value);
            fling2TimeBefore = value;
        } 
    }

    private float fling2Time = 0.50f;
    /// <summary>
    /// Duration of the fling behaviour.
    /// </summary>
    public float Fling2Time
    {
        get { return fling2Time; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("fling2Time", value);
            fling2Time = value;
        } 
    }

    private float fling2MStiffL = 0.950f;
    /// <summary>
    /// MuscleStiffness of the left arm.  If negative then uses the shots underlying muscle stiffness from controlStiffness (i.e. respects looseness)
    /// </summary>
    public float Fling2MStiffL
    {
        get { return fling2MStiffL; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.50f);
            SetArgument("fling2MStiffL", value);
            fling2MStiffL = value;
        } 
    }

    private float fling2MStiffR = -1.00f;
    /// <summary>
    /// MuscleStiffness of the right arm.  If negative then uses the shots underlying muscle stiffness from controlStiffness (i.e. respects looseness)
    /// </summary>
    public float Fling2MStiffR
    {
        get { return fling2MStiffR; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.50f);
            SetArgument("fling2MStiffR", value);
            fling2MStiffR = value;
        } 
    }

    private float fling2RelaxTimeL = 0.50f;
    /// <summary>
    /// Maximum time before the left arm relaxes in the fling.  It will relax automatically when the arm has completed it's bent arm fling.  This is what causes the arm to straighten.
    /// </summary>
    public float Fling2RelaxTimeL
    {
        get { return fling2RelaxTimeL; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("fling2RelaxTimeL", value);
            fling2RelaxTimeL = value;
        } 
    }

    private float fling2RelaxTimeR = 0.50f;
    /// <summary>
    /// Maximum time before the right arm relaxes in the fling.  It will relax automatically when the arm has completed it's bent arm fling.  This is what causes the arm to straighten.
    /// </summary>
    public float Fling2RelaxTimeR
    {
        get { return fling2RelaxTimeR; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("fling2RelaxTimeR", value);
            fling2RelaxTimeR = value;
        } 
    }

    private float fling2AngleMinL = -1.50f;
    /// <summary>
    /// Min fling angle for left arm.  Fling angle is random in the range fling2AngleMin:fling2AngleMax. Angle of fling in radians measured from the body horizontal sideways from shoulder. positive is up, 0 shoulder level, negative down
    /// </summary>
    public float Fling2AngleMinL
    {
        get { return fling2AngleMinL; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.50f, 1.00f);
            SetArgument("fling2AngleMinL", value);
            fling2AngleMinL = value;
        } 
    }

    private float fling2AngleMaxL = 1.00f;
    /// <summary>
    /// Max fling angle for left arm
    /// </summary>
    public float Fling2AngleMaxL
    {
        get { return fling2AngleMaxL; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.50f, 1.00f);
            SetArgument("fling2AngleMaxL", value);
            fling2AngleMaxL = value;
        } 
    }

    private float fling2AngleMinR = -1.50f;
    /// <summary>
    /// Min fling angle for right arm.
    /// </summary>
    public float Fling2AngleMinR
    {
        get { return fling2AngleMinR; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.50f, 1.00f);
            SetArgument("fling2AngleMinR", value);
            fling2AngleMinR = value;
        } 
    }

    private float fling2AngleMaxR = 1.00f;
    /// <summary>
    /// Max fling angle for right arm
    /// </summary>
    public float Fling2AngleMaxR
    {
        get { return fling2AngleMaxR; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.50f, 1.00f);
            SetArgument("fling2AngleMaxR", value);
            fling2AngleMaxR = value;
        } 
    }

    private float fling2LengthMinL = 0.250f;
    /// <summary>
    /// Min left arm length.  Armlength is random in the range fling2LengthMin:fling2LengthMax.  Armlength maps one to one with elbow angle.  (These values are scaled internally for the female character)
    /// </summary>
    public float Fling2LengthMinL
    {
        get { return fling2LengthMinL; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.250f, 0.60f);
            SetArgument("fling2LengthMinL", value);
            fling2LengthMinL = value;
        } 
    }

    private float fling2LengthMaxL = 0.60f;
    /// <summary>
    /// Max left arm length.
    /// </summary>
    public float Fling2LengthMaxL
    {
        get { return fling2LengthMaxL; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.250f, 0.60f);
            SetArgument("fling2LengthMaxL", value);
            fling2LengthMaxL = value;
        } 
    }

    private float fling2LengthMinR = 0.250f;
    /// <summary>
    /// Min right arm length.
    /// </summary>
    public float Fling2LengthMinR
    {
        get { return fling2LengthMinR; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.250f, 0.60f);
            SetArgument("fling2LengthMinR", value);
            fling2LengthMinR = value;
        } 
    }

    private float fling2LengthMaxR = 0.60f;
    /// <summary>
    /// Max right arm length.
    /// </summary>
    public float Fling2LengthMaxR
    {
        get { return fling2LengthMaxR; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.250f, 0.60f);
            SetArgument("fling2LengthMaxR", value);
            fling2LengthMaxR = value;
        } 
    }

    private bool bust = false;
    /// <summary>
    /// Has the character got a bust.  If so then cupBust (move bust reach targets below bust) or bustElbowLift and cupSize (stop upperArm penetrating bust and move bust targets to surface of bust) are implemented.
    /// </summary>
    public bool Bust
    {
        get { return bust; } 
        set 
        {  
                
            SetArgument("bust", value);
            bust = value;
        } 
    }

    private float bustElbowLift = 0.70f;
    /// <summary>
    /// Lift the elbows up this much extra to avoid upper arm penetrating the bust (when target hits spine2 or spine3)
    /// </summary>
    public float BustElbowLift
    {
        get { return bustElbowLift; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("bustElbowLift", value);
            bustElbowLift = value;
        } 
    }

    private float cupSize = 0.10f;
    /// <summary>
    /// Amount reach target to bust (spine2) will be offset forward by
    /// </summary>
    public float CupSize
    {
        get { return cupSize; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("cupSize", value);
            cupSize = value;
        } 
    }

    private bool cupBust = false;
    /// <summary>
    /// All reach targets above or on the bust will cause a reach below the bust. (specifically moves spine3 and spine2 targets to spine1). bustElbowLift and cupSize are ignored.
    /// </summary>
    public bool CupBust
    {
        get { return cupBust; } 
        set 
        {  
                
            SetArgument("cupBust", value);
            cupBust = value;
        } 
    }


    public EuphoriaMessageShotConfigureArms(bool startNow) : base("shotConfigureArms", startNow)
    { }

    public new void Reset()
    {
        brace = true;
        pointGun = false;
        useArmsWindmill = true;
        releaseWound = 1;
        reachFalling = 0;
        reachFallingWithOneHand = 3;
        reachOnFloor = 0;
        alwaysReachTime = 0.30f;
        aWSpeedMult = 1.0f;
        aWRadiusMult = 1.0f;
        aWStiffnessAdd = 4.0f;
        reachWithOneHand = 0;
        allowLeftPistolRFW = true;
        allowRightPistolRFW = false;
        rfwWithPistol = false;
        fling2 = false;
        fling2Left = true;
        fling2Right = true;
        fling2OverrideStagger = false;
        fling2TimeBefore = 0.10f;
        fling2Time = 0.50f;
        fling2MStiffL = 0.950f;
        fling2MStiffR = -1.00f;
        fling2RelaxTimeL = 0.50f;
        fling2RelaxTimeR = 0.50f;
        fling2AngleMinL = -1.50f;
        fling2AngleMaxL = 1.00f;
        fling2AngleMinR = -1.50f;
        fling2AngleMaxR = 1.00f;
        fling2LengthMinL = 0.250f;
        fling2LengthMaxL = 0.60f;
        fling2LengthMinR = 0.250f;
        fling2LengthMaxR = 0.60f;
        bust = false;
        bustElbowLift = 0.70f;
        cupSize = 0.10f;
        cupBust = false;
        base.Reset();
    }
}
}
