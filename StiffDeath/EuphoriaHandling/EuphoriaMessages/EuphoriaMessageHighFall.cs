using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageHighFall : EuphoriaMessage
{
    private float bodyStiffness = 11.00f;
    /// <summary>
    /// stiffness of body. Value feeds through to bodyBalance (synched with defaults), to armsWindmill (14 for this value at default ), legs pedal, head look and roll down stairs directly
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

    private float bodydamping = 1.00f;
    /// <summary>
    /// The damping of the joints.
    /// </summary>
    public float Bodydamping
    {
        get { return bodydamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 3.00f);
            SetArgument("bodydamping", value);
            bodydamping = value;
        } 
    }

    private float catchfalltime = 0.300f;
    /// <summary>
    /// The length of time before the impact that the character transitions to the landing.
    /// </summary>
    public float Catchfalltime
    {
        get { return catchfalltime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("catchfalltime", value);
            catchfalltime = value;
        } 
    }

    private float crashOrLandCutOff = 0.8680f;
    /// <summary>
    /// 0.52angle is 0.868 dot//A threshold for deciding how far away from upright the character needs to be before bailing out (going into a foetal) instead of trying to land (keeping stretched out).  NB: never does bailout if ignorWorldCollisions true
    /// </summary>
    public float CrashOrLandCutOff
    {
        get { return crashOrLandCutOff; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("crashOrLandCutOff", value);
            crashOrLandCutOff = value;
        } 
    }

    private float pdStrength = 0.00f;
    /// <summary>
    /// Strength of the controller to keep the character at angle aimAngleBase from vertical.
    /// </summary>
    public float PdStrength
    {
        get { return pdStrength; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("pdStrength", value);
            pdStrength = value;
        } 
    }

    private float pdDamping = 1.00f;
    /// <summary>
    /// Damping multiplier of the controller to keep the character at angle aimAngleBase from vertical.  The actual damping is pdDamping*pdStrength*constant*angVel.
    /// </summary>
    public float PdDamping
    {
        get { return pdDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 5.00f);
            SetArgument("pdDamping", value);
            pdDamping = value;
        } 
    }

    private float armAngSpeed = 7.850f;
    /// <summary>
    /// arm circling speed in armWindMillAdaptive
    /// </summary>
    public float ArmAngSpeed
    {
        get { return armAngSpeed; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 20.0f);
            SetArgument("armAngSpeed", value);
            armAngSpeed = value;
        } 
    }

    private float armAmplitude = 2.00f;
    /// <summary>
    /// in armWindMillAdaptive
    /// </summary>
    public float ArmAmplitude
    {
        get { return armAmplitude; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("armAmplitude", value);
            armAmplitude = value;
        } 
    }

    private float armPhase = 3.10f;
    /// <summary>
    /// in armWindMillAdaptive 3.1 opposite for stuntman.  1.0 old default.  0.0 in phase.
    /// </summary>
    public float ArmPhase
    {
        get { return armPhase; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 6.283185f);
            SetArgument("armPhase", value);
            armPhase = value;
        } 
    }

    private bool armBendElbows = true;
    /// <summary>
    /// in armWindMillAdaptive bend the elbows as a function of armAngle.  For stuntman true otherwise false.
    /// </summary>
    public bool ArmBendElbows
    {
        get { return armBendElbows; } 
        set 
        {  
                
            SetArgument("armBendElbows", value);
            armBendElbows = value;
        } 
    }

    private float legRadius = 0.40f;
    /// <summary>
    /// radius of legs on pedal
    /// </summary>
    public float LegRadius
    {
        get { return legRadius; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.010f, 0.50f);
            SetArgument("legRadius", value);
            legRadius = value;
        } 
    }

    private float legAngSpeed = 7.850f;
    /// <summary>
    /// in pedal
    /// </summary>
    public float LegAngSpeed
    {
        get { return legAngSpeed; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 15.0f);
            SetArgument("legAngSpeed", value);
            legAngSpeed = value;
        } 
    }

    private float legAsymmetry = 4.00f;
    /// <summary>
    /// 0.0 for stuntman.  Random offset applied per leg to the angular speed to desynchronise the pedaling - set to 0 to disable, otherwise should be set to less than the angularSpeed value.
    /// </summary>
    public float LegAsymmetry
    {
        get { return legAsymmetry; } 
        set 
        {  
            value = MathHelper.Clamp(value, -10.00f, 10.00f);
            SetArgument("legAsymmetry", value);
            legAsymmetry = value;
        } 
    }

    private float arms2LegsPhase = 0.00f;
    /// <summary>
    /// phase angle between the arms and legs circling angle
    /// </summary>
    public float Arms2LegsPhase
    {
        get { return arms2LegsPhase; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 6.50f);
            SetArgument("arms2LegsPhase", value);
            arms2LegsPhase = value;
        } 
    }

    private int arms2LegsSync = 1;
    /// <summary>
    /// 0=not synched, 1=always synched, 2= synch at start only.  Synchs the arms angle to what the leg angle is.  All speed/direction parameters of armswindmill are overwritten if = 1.  If 2 and you want synced arms/legs then armAngSpeed=legAngSpeed, legAsymmetry = 0.0 (to stop randomizations of the leg cicle speed)
    /// </summary>
    public int Arms2LegsSync
    {
        get { return arms2LegsSync; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("arms2LegsSync", value);
            arms2LegsSync = value;
        } 
    }

    private float armsUp = -3.10f;
    /// <summary>
    /// Where to put the arms when preparing to land. Approx 1 = above head, 0 = head height, -1 = down.   LT -2.0 use catchFall arms,  LT -3.0 use prepare for landing pose if Agent is due to land vertically, feet first.
    /// </summary>
    public float ArmsUp
    {
        get { return armsUp; } 
        set 
        {  
            value = MathHelper.Clamp(value, -4.00f, 2.00f);
            SetArgument("armsUp", value);
            armsUp = value;
        } 
    }

    private bool orientateBodyToFallDirection = false;
    /// <summary>
    /// toggle to orientate to fall direction.  i.e. orientate so that the character faces the horizontal velocity direction
    /// </summary>
    public bool OrientateBodyToFallDirection
    {
        get { return orientateBodyToFallDirection; } 
        set 
        {  
                
            SetArgument("orientateBodyToFallDirection", value);
            orientateBodyToFallDirection = value;
        } 
    }

    private bool orientateTwist = true;
    /// <summary>
    /// If false don't worry about the twist angle of the character when orientating the character.  If false this allows the twist axis of the character to be free (You can get a nice twisting highFall like the one in dieHard 4 when the car goes into the helicopter)
    /// </summary>
    public bool OrientateTwist
    {
        get { return orientateTwist; } 
        set 
        {  
                
            SetArgument("orientateTwist", value);
            orientateTwist = value;
        } 
    }

    private float orientateMax = 300.00f;
    /// <summary>
    /// DEVEL parameter - suggest you don't edit it.  Maximum torque the orientation controller can apply.  If 0 then no helper torques will be used.  300 will orientate the character soflty for all but extreme angles away from aimAngleBase.  If abs (current -aimAngleBase) is getting near 3.0 then this can be reduced to give a softer feel.
    /// </summary>
    public float OrientateMax
    {
        get { return orientateMax; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2000.00f);
            SetArgument("orientateMax", value);
            orientateMax = value;
        } 
    }

    private bool alanRickman = false;
    /// <summary>
    /// If true then orientate the character to face the point from where it started falling.  HighFall like the one in dieHard with Alan Rickman
    /// </summary>
    public bool AlanRickman
    {
        get { return alanRickman; } 
        set 
        {  
                
            SetArgument("alanRickman", value);
            alanRickman = value;
        } 
    }

    private bool fowardRoll = false;
    /// <summary>
    /// Try to execute a forward Roll on landing
    /// </summary>
    public bool FowardRoll
    {
        get { return fowardRoll; } 
        set 
        {  
                
            SetArgument("fowardRoll", value);
            fowardRoll = value;
        } 
    }

    private bool useZeroPose_withFowardRoll = false;
    /// <summary>
    /// Blend to a zero pose when forward roll is attempted.
    /// </summary>
    public bool UseZeroPose_withFowardRoll
    {
        get { return useZeroPose_withFowardRoll; } 
        set 
        {  
                
            SetArgument("useZeroPose_withFowardRoll", value);
            useZeroPose_withFowardRoll = value;
        } 
    }

    private float aimAngleBase = 0.180f;
    /// <summary>
    /// Angle from vertical the pdController is driving to ( positive = forwards)
    /// </summary>
    public float AimAngleBase
    {
        get { return aimAngleBase; } 
        set 
        {  
            value = MathHelper.Clamp(value, -3.141593f, 3.141593f);
            SetArgument("aimAngleBase", value);
            aimAngleBase = value;
        } 
    }

    private float fowardVelRotation = -0.020f;
    /// <summary>
    /// scale to add/subtract from aimAngle based on forward speed (Internal)
    /// </summary>
    public float FowardVelRotation
    {
        get { return fowardVelRotation; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("fowardVelRotation", value);
            fowardVelRotation = value;
        } 
    }

    private float footVelCompScale = 0.050f;
    /// <summary>
    /// Scale to change to amount of vel that is added to the foot ik from the velocity (Internal)
    /// </summary>
    public float FootVelCompScale
    {
        get { return footVelCompScale; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("footVelCompScale", value);
            footVelCompScale = value;
        } 
    }

    private float sideD = 0.20f;
    /// <summary>
    /// sideoffset for the feet during prepareForLanding. +ve = right.
    /// </summary>
    public float SideD
    {
        get { return sideD; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("sideD", value);
            sideD = value;
        } 
    }

    private float fowardOffsetOfLegIK = 0.00f;
    /// <summary>
    /// Forward offset for the feet during prepareForLanding
    /// </summary>
    public float FowardOffsetOfLegIK
    {
        get { return fowardOffsetOfLegIK; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("fowardOffsetOfLegIK", value);
            fowardOffsetOfLegIK = value;
        } 
    }

    private float legL = 1.00f;
    /// <summary>
    /// Leg Length for ik (Internal)//unused
    /// </summary>
    public float LegL
    {
        get { return legL; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.00f);
            SetArgument("legL", value);
            legL = value;
        } 
    }

    private float catchFallCutOff = 0.8780f;
    /// <summary>
    /// 0.5angle is 0.878 dot. Cutoff to go to the catchFall ( internal) //mmmtodo do like crashOrLandCutOff
    /// </summary>
    public float CatchFallCutOff
    {
        get { return catchFallCutOff; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("catchFallCutOff", value);
            catchFallCutOff = value;
        } 
    }

    private float legStrength = 12.00f;
    /// <summary>
    /// Strength of the legs at landing
    /// </summary>
    public float LegStrength
    {
        get { return legStrength; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.00f, 16.0f);
            SetArgument("legStrength", value);
            legStrength = value;
        } 
    }

    private bool balance = true;
    /// <summary>
    /// If true have enough strength to balance.  If false not enough strength in legs to balance (even though bodyBlance called)
    /// </summary>
    public bool Balance
    {
        get { return balance; } 
        set 
        {  
                
            SetArgument("balance", value);
            balance = value;
        } 
    }

    private bool ignorWorldCollisions = false;
    /// <summary>
    /// Never go into bailout (foetal)
    /// </summary>
    public bool IgnorWorldCollisions
    {
        get { return ignorWorldCollisions; } 
        set 
        {  
                
            SetArgument("ignorWorldCollisions", value);
            ignorWorldCollisions = value;
        } 
    }

    private bool adaptiveCircling = true;
    /// <summary>
    /// stuntman type fall.  Arm and legs circling direction controlled by angmom and orientation
    /// </summary>
    public bool AdaptiveCircling
    {
        get { return adaptiveCircling; } 
        set 
        {  
                
            SetArgument("adaptiveCircling", value);
            adaptiveCircling = value;
        } 
    }

    private bool hula = true;
    /// <summary>
    /// With stuntman type fall.  Hula reaction if can't see floor and not rotating fast
    /// </summary>
    public bool Hula
    {
        get { return hula; } 
        set 
        {  
                
            SetArgument("hula", value);
            hula = value;
        } 
    }

    private float maxSpeedForRecoverableFall = 15.00f;
    /// <summary>
    /// Character needs to be moving less than this speed to consider fall as a recoverable one.
    /// </summary>
    public float MaxSpeedForRecoverableFall
    {
        get { return maxSpeedForRecoverableFall; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.00f);
            SetArgument("maxSpeedForRecoverableFall", value);
            maxSpeedForRecoverableFall = value;
        } 
    }

    private float minSpeedForBrace = 10.00f;
    /// <summary>
    /// Character needs to be moving at least this fast horizontally to start bracing for impact if there is an object along its trajectory.
    /// </summary>
    public float MinSpeedForBrace
    {
        get { return minSpeedForBrace; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 100.00f);
            SetArgument("minSpeedForBrace", value);
            minSpeedForBrace = value;
        } 
    }

    private float landingNormal = 0.60f;
    /// <summary>
    /// Ray-cast normal doted with up direction has to be greater than this number to consider object flat enough to land on it.
    /// </summary>
    public float LandingNormal
    {
        get { return landingNormal; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("landingNormal", value);
            landingNormal = value;
        } 
    }


    public EuphoriaMessageHighFall(bool startNow) : base("highFall", startNow)
    { }

    public new void Reset()
    {
        bodyStiffness = 11.00f;
        bodydamping = 1.00f;
        catchfalltime = 0.300f;
        crashOrLandCutOff = 0.8680f;
        pdStrength = 0.00f;
        pdDamping = 1.00f;
        armAngSpeed = 7.850f;
        armAmplitude = 2.00f;
        armPhase = 3.10f;
        armBendElbows = true;
        legRadius = 0.40f;
        legAngSpeed = 7.850f;
        legAsymmetry = 4.00f;
        arms2LegsPhase = 0.00f;
        arms2LegsSync = 1;
        armsUp = -3.10f;
        orientateBodyToFallDirection = false;
        orientateTwist = true;
        orientateMax = 300.00f;
        alanRickman = false;
        fowardRoll = false;
        useZeroPose_withFowardRoll = false;
        aimAngleBase = 0.180f;
        fowardVelRotation = -0.020f;
        footVelCompScale = 0.050f;
        sideD = 0.20f;
        fowardOffsetOfLegIK = 0.00f;
        legL = 1.00f;
        catchFallCutOff = 0.8780f;
        legStrength = 12.00f;
        balance = true;
        ignorWorldCollisions = false;
        adaptiveCircling = true;
        hula = true;
        maxSpeedForRecoverableFall = 15.00f;
        minSpeedForBrace = 10.00f;
        landingNormal = 0.60f;
        base.Reset();
    }
}
}
