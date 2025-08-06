using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageRollDownStairs : EuphoriaMessage
{
    private float stiffness = 11.0f;
    /// <summary>
    /// Effector Stiffness. value feeds through to rollUp directly
    /// </summary>
    public float Stiffness
    {
        get { return stiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("stiffness", value);
            stiffness = value;
        } 
    }

    private float damping = 1.4f;
    /// <summary>
    /// Effector  Damping.
    /// </summary>
    public float Damping
    {
        get { return damping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 4.0f);
            SetArgument("damping", value);
            damping = value;
        } 
    }

    private float forcemag = 0.55f;
    /// <summary>
    /// Helper force strength.  Do not go above 1 for a rollDownStairs/roll along ground reaction.
    /// </summary>
    public float Forcemag
    {
        get { return forcemag; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("forcemag", value);
            forcemag = value;
        } 
    }

    private float m_useArmToSlowDown = -1.9f;
    /// <summary>
    /// the degree to which the character will try to stop a barrel roll with his arms
    /// </summary>
    public float M_useArmToSlowDown
    {
        get { return m_useArmToSlowDown; } 
        set 
        {  
            value = MathHelper.Clamp(value, -3.0f, 3.0f);
            SetArgument("m_useArmToSlowDown", value);
            m_useArmToSlowDown = value;
        } 
    }

    private bool useZeroPose = false;
    /// <summary>
    /// Blends between a zeroPose and the Rollup, Faster the character is rotating the less the zeroPose
    /// </summary>
    public bool UseZeroPose
    {
        get { return useZeroPose; } 
        set 
        {  
                
            SetArgument("useZeroPose", value);
            useZeroPose = value;
        } 
    }

    private bool spinWhenInAir = false;
    /// <summary>
    /// Applied cheat forces to spin the character when in the air, the forces are 40% of the forces applied when touching the ground.  Be careful little bunny rabbits, the character could spin unnaturally in the air.
    /// </summary>
    public bool SpinWhenInAir
    {
        get { return spinWhenInAir; } 
        set 
        {  
                
            SetArgument("spinWhenInAir", value);
            spinWhenInAir = value;
        } 
    }

    private float m_armReachAmount = 1.4f;
    /// <summary>
    /// how much the character reaches with his arms to brace against the ground
    /// </summary>
    public float M_armReachAmount
    {
        get { return m_armReachAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.0f);
            SetArgument("m_armReachAmount", value);
            m_armReachAmount = value;
        } 
    }

    private float m_legPush = 1.0f;
    /// <summary>
    /// amount that the legs push outwards when tumbling
    /// </summary>
    public float M_legPush
    {
        get { return m_legPush; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("m_legPush", value);
            m_legPush = value;
        } 
    }

    private bool tryToAvoidHeadButtingGround = false;
    /// <summary>
    /// Blends between a zeroPose and the Rollup, Faster the character is rotating the less the zeroPose
    /// </summary>
    public bool TryToAvoidHeadButtingGround
    {
        get { return tryToAvoidHeadButtingGround; } 
        set 
        {  
                
            SetArgument("tryToAvoidHeadButtingGround", value);
            tryToAvoidHeadButtingGround = value;
        } 
    }

    private float armReachLength = 0.4f;
    /// <summary>
    /// the length that the arm reaches and so how much it straightens
    /// </summary>
    public float ArmReachLength
    {
        get { return armReachLength; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("armReachLength", value);
            armReachLength = value;
        } 
    }

    private Vector3 customRollDir = new(0f,  0f,  1f);
    /// <summary>
    /// pass in a custom direction in to have the character try and roll in that direction
    /// </summary>
    public Vector3 CustomRollDir
    {
        get { return customRollDir; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, 1.0f, 1.0f);
            value.Y = MathHelper.Clamp(value.Y, 1.0f, 1.0f);
            value.Z = MathHelper.Clamp(value.Z, 1.0f, 1.0f);
            SetArgument("customRollDir", value);
            customRollDir = value;
        } 
    }

    private bool useCustomRollDir = false;
    /// <summary>
    /// pass in true to use the customRollDir parameter
    /// </summary>
    public bool UseCustomRollDir
    {
        get { return useCustomRollDir; } 
        set 
        {  
                
            SetArgument("useCustomRollDir", value);
            useCustomRollDir = value;
        } 
    }

    private float stiffnessDecayTarget = 9.0f;
    /// <summary>
    /// The target linear velocity used to start the rolling.
    /// </summary>
    public float StiffnessDecayTarget
    {
        get { return stiffnessDecayTarget; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 20.0f);
            SetArgument("stiffnessDecayTarget", value);
            stiffnessDecayTarget = value;
        } 
    }

    private float stiffnessDecayTime = -1.0f;
    /// <summary>
    /// time, in seconds, to decay stiffness down to the stiffnessDecayTarget value (or -1 to disable)
    /// </summary>
    public float StiffnessDecayTime
    {
        get { return stiffnessDecayTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 10.0f);
            SetArgument("stiffnessDecayTime", value);
            stiffnessDecayTime = value;
        } 
    }

    private float asymmetricalLegs = 0.0f;
    /// <summary>
    /// 0 is no leg asymmetry in 'foetal' position.  greater than 0 a asymmetricalLegs-rand(30%), added/minus each joint of the legs in radians.  Random number changes about once every roll.  0.4 gives a lot of asymmetry
    /// </summary>
    public float AsymmetricalLegs
    {
        get { return asymmetricalLegs; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 1.0f);
            SetArgument("asymmetricalLegs", value);
            asymmetricalLegs = value;
        } 
    }

    private float zAxisSpinReduction = 0.0f;
    /// <summary>
    /// Tries to reduce the spin around the z axis. Scale 0 - 1
    /// </summary>
    public float ZAxisSpinReduction
    {
        get { return zAxisSpinReduction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("zAxisSpinReduction", value);
            zAxisSpinReduction = value;
        } 
    }

    private float targetLinearVelocityDecayTime = 0.5f;
    /// <summary>
    /// Time for the targetlinearVelocity to decay to zero.
    /// </summary>
    public float TargetLinearVelocityDecayTime
    {
        get { return targetLinearVelocityDecayTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("targetLinearVelocityDecayTime", value);
            targetLinearVelocityDecayTime = value;
        } 
    }

    private float targetLinearVelocity = 1.0f;
    /// <summary>
    /// Helper torques are applied to match the spin of the character to the max of targetLinearVelocity and COMVelMag
    /// </summary>
    public float TargetLinearVelocity
    {
        get { return targetLinearVelocity; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("targetLinearVelocity", value);
            targetLinearVelocity = value;
        } 
    }

    private bool onlyApplyHelperForces = false;
    /// <summary>
    /// Don't use rollup if true
    /// </summary>
    public bool OnlyApplyHelperForces
    {
        get { return onlyApplyHelperForces; } 
        set 
        {  
                
            SetArgument("onlyApplyHelperForces", value);
            onlyApplyHelperForces = value;
        } 
    }

    private bool useVelocityOfObjectBelow = false;
    /// <summary>
    /// scale applied cheat forces/torques to (zero) if object underneath character has velocity greater than 1.f
    /// </summary>
    public bool UseVelocityOfObjectBelow
    {
        get { return useVelocityOfObjectBelow; } 
        set 
        {  
                
            SetArgument("useVelocityOfObjectBelow", value);
            useVelocityOfObjectBelow = value;
        } 
    }

    private bool useRelativeVelocity = false;
    /// <summary>
    /// useVelocityOfObjectBelow uses a relative velocity of the character to the object underneath
    /// </summary>
    public bool UseRelativeVelocity
    {
        get { return useRelativeVelocity; } 
        set 
        {  
                
            SetArgument("useRelativeVelocity", value);
            useRelativeVelocity = value;
        } 
    }

    private bool applyFoetalToLegs = false;
    /// <summary>
    /// if true, use rollup for upper body and a kind of foetal behavior for legs
    /// </summary>
    public bool ApplyFoetalToLegs
    {
        get { return applyFoetalToLegs; } 
        set 
        {  
                
            SetArgument("applyFoetalToLegs", value);
            applyFoetalToLegs = value;
        } 
    }

    private float movementLegsInFoetalPosition = 1.30f;
    /// <summary>
    /// Only used if applyFoetalToLegs = true : define the variation of angles for the joints of the legs
    /// </summary>
    public float MovementLegsInFoetalPosition
    {
        get { return movementLegsInFoetalPosition; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("movementLegsInFoetalPosition", value);
            movementLegsInFoetalPosition = value;
        } 
    }

    private float maxAngVelAroundFrontwardAxis = 2.0f;
    /// <summary>
    /// Only used if applyNewRollingCheatingTorques or applyHelPerTorqueToAlign defined to true : maximal angular velocity around frontward axis of the pelvis to apply cheating torques.
    /// </summary>
    public float MaxAngVelAroundFrontwardAxis
    {
        get { return maxAngVelAroundFrontwardAxis; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 10.0f);
            SetArgument("maxAngVelAroundFrontwardAxis", value);
            maxAngVelAroundFrontwardAxis = value;
        } 
    }

    private float minAngVel = 0.5f;
    /// <summary>
    /// Only used if applyNewRollingCheatingTorques or applyHelPerTorqueToAlign defined to true : minimal angular velocity of the roll to apply cheating torques
    /// </summary>
    public float MinAngVel
    {
        get { return minAngVel; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("minAngVel", value);
            minAngVel = value;
        } 
    }

    private bool applyNewRollingCheatingTorques = false;
    /// <summary>
    /// if true will use the new way to apply cheating torques (like in fallOverWall), otherwise will use the old way
    /// </summary>
    public bool ApplyNewRollingCheatingTorques
    {
        get { return applyNewRollingCheatingTorques; } 
        set 
        {  
                
            SetArgument("applyNewRollingCheatingTorques", value);
            applyNewRollingCheatingTorques = value;
        } 
    }

    private float maxAngVel = 5.0f;
    /// <summary>
    /// Only used if applyNewRollingCheatingTorques defined to true : maximal angular velocity of the roll to apply cheating torque
    /// </summary>
    public float MaxAngVel
    {
        get { return maxAngVel; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("maxAngVel", value);
            maxAngVel = value;
        } 
    }

    private float magOfTorqueToRoll = 50.0f;
    /// <summary>
    /// Only used if applyNewRollingCheatingTorques defined to true : magnitude of the torque to roll down the stairs
    /// </summary>
    public float MagOfTorqueToRoll
    {
        get { return magOfTorqueToRoll; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 500.0f);
            SetArgument("magOfTorqueToRoll", value);
            magOfTorqueToRoll = value;
        } 
    }

    private bool applyHelPerTorqueToAlign = false;
    /// <summary>
    /// apply torque to align the body orthogonally to the direction of the roll
    /// </summary>
    public bool ApplyHelPerTorqueToAlign
    {
        get { return applyHelPerTorqueToAlign; } 
        set 
        {  
                
            SetArgument("applyHelPerTorqueToAlign", value);
            applyHelPerTorqueToAlign = value;
        } 
    }

    private float delayToAlignBody = 0.2f;
    /// <summary>
    /// Only used if applyHelPerTorqueToAlign defined to true : delay to start to apply torques
    /// </summary>
    public float DelayToAlignBody
    {
        get { return delayToAlignBody; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 10.0f);
            SetArgument("delayToAlignBody", value);
            delayToAlignBody = value;
        } 
    }

    private float magOfTorqueToAlign = 50.0f;
    /// <summary>
    /// Only used if applyHelPerTorqueToAlign defined to true : magnitude of the torque to align orthogonally the body
    /// </summary>
    public float MagOfTorqueToAlign
    {
        get { return magOfTorqueToAlign; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 500.0f);
            SetArgument("magOfTorqueToAlign", value);
            magOfTorqueToAlign = value;
        } 
    }

    private float airborneReduction = 0.85f;
    /// <summary>
    /// Ordinarily keep at 0.85.  Make this lower if you want spinning in the air.
    /// </summary>
    public float AirborneReduction
    {
        get { return airborneReduction; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("airborneReduction", value);
            airborneReduction = value;
        } 
    }

    private bool applyMinMaxFriction = true;
    /// <summary>
    /// Pass-through to Roll Up. Controls whether or not behaviour enforces min/max friction.
    /// </summary>
    public bool ApplyMinMaxFriction
    {
        get { return applyMinMaxFriction; } 
        set 
        {  
                
            SetArgument("applyMinMaxFriction", value);
            applyMinMaxFriction = value;
        } 
    }

    private bool limitSpinReduction = false;
    /// <summary>
    /// Scale zAxisSpinReduction back when rotating end-over-end (somersault) to give the body a chance to align with the axis of rotation.
    /// </summary>
    public bool LimitSpinReduction
    {
        get { return limitSpinReduction; } 
        set 
        {  
                
            SetArgument("limitSpinReduction", value);
            limitSpinReduction = value;
        } 
    }


    public EuphoriaMessageRollDownStairs(bool startNow) : base("rollDownStairs", startNow)
    { }

    public new void Reset()
    {
        stiffness = 11.0f;
        damping = 1.4f;
        forcemag = 0.55f;
        m_useArmToSlowDown = -1.9f;
        useZeroPose = false;
        spinWhenInAir = false;
        m_armReachAmount = 1.4f;
        m_legPush = 1.0f;
        tryToAvoidHeadButtingGround = false;
        armReachLength = 0.4f;
        customRollDir = new Vector3(0f,  0f,  1f);
        useCustomRollDir = false;
        stiffnessDecayTarget = 9.0f;
        stiffnessDecayTime = -1.0f;
        asymmetricalLegs = 0.0f;
        zAxisSpinReduction = 0.0f;
        targetLinearVelocityDecayTime = 0.5f;
        targetLinearVelocity = 1.0f;
        onlyApplyHelperForces = false;
        useVelocityOfObjectBelow = false;
        useRelativeVelocity = false;
        applyFoetalToLegs = false;
        movementLegsInFoetalPosition = 1.30f;
        maxAngVelAroundFrontwardAxis = 2.0f;
        minAngVel = 0.5f;
        applyNewRollingCheatingTorques = false;
        maxAngVel = 5.0f;
        magOfTorqueToRoll = 50.0f;
        applyHelPerTorqueToAlign = false;
        delayToAlignBody = 0.2f;
        magOfTorqueToAlign = 50.0f;
        airborneReduction = 0.85f;
        applyMinMaxFriction = true;
        limitSpinReduction = false;
        base.Reset();
    }
}
}
