namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageAnimPose : EuphoriaMessage
{
    private float muscleStiffness = -1.0f;
    /// <summary>
    /// muscleStiffness of masked joints. -values mean don't apply (just use defaults or ones applied by behaviours - safer if you are going to return to a behaviour)
    /// </summary>
    public float MuscleStiffness
    {
        get { return muscleStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.10f, 10.00f);
            SetArgument("muscleStiffness", value);
            muscleStiffness = value;
        } 
    }

    private float stiffness = -1.0f;
    /// <summary>
    /// stiffness of masked joints. -ve values mean don't apply stiffness or damping (just use defaults or ones applied by behaviours).  If you are using animpose fullbody on its own then this gives the opprtunity to use setStffness and setMuscleStiffness messages to set up the character's muscles. mmmmtodo get rid of this -ve
    /// </summary>
    public float Stiffness
    {
        get { return stiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.10f, 16.00f);
            SetArgument("stiffness", value);
            stiffness = value;
        } 
    }

    private float damping = 1.0f;
    /// <summary>
    /// damping of masked joints
    /// </summary>
    public float Damping
    {
        get { return damping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("damping", value);
            damping = value;
        } 
    }

    private string effectorMask = "ub";
    /// <summary>
    /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value  (see notes for explanation)
    /// </summary>
    public string EffectorMask
    {
        get { return effectorMask; } 
        set 
        {  
                
            SetArgument("effectorMask", value);
            effectorMask = value;
        } 
    }

    private bool overideHeadlook = false;
    /// <summary>
    /// overide Headlook behaviour (if animPose includes the head)
    /// </summary>
    public bool OverideHeadlook
    {
        get { return overideHeadlook; } 
        set 
        {  
                
            SetArgument("overideHeadlook", value);
            overideHeadlook = value;
        } 
    }

    private bool overidePointArm = false;
    /// <summary>
    /// overide PointArm behaviour (if animPose includes the arm/arms)
    /// </summary>
    public bool OveridePointArm
    {
        get { return overidePointArm; } 
        set 
        {  
                
            SetArgument("overidePointArm", value);
            overidePointArm = value;
        } 
    }

    private bool overidePointGun = false;
    /// <summary>
    /// overide PointGun behaviour (if animPose includes the arm/arms)//mmmmtodo not used at moment
    /// </summary>
    public bool OveridePointGun
    {
        get { return overidePointGun; } 
        set 
        {  
                
            SetArgument("overidePointGun", value);
            overidePointGun = value;
        } 
    }

    private bool useZMPGravityCompensation = true;
    /// <summary>
    /// If true then modify gravity compensation based on stance (can reduce gravity compensation to zero if cofm is outside of balance area)
    /// </summary>
    public bool UseZMPGravityCompensation
    {
        get { return useZMPGravityCompensation; } 
        set 
        {  
                
            SetArgument("useZMPGravityCompensation", value);
            useZMPGravityCompensation = value;
        } 
    }

    private float gravityCompensation = -1.0f;
    /// <summary>
    /// gravity compensation applied to joints in the effectorMask. If -ve then not applied (use current setting)
    /// </summary>
    public float GravityCompensation
    {
        get { return gravityCompensation; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 14.00f);
            SetArgument("gravityCompensation", value);
            gravityCompensation = value;
        } 
    }

    private float muscleStiffnessLeftArm = -1.0f;
    /// <summary>
    /// muscle stiffness applied to left arm (applied after stiffness). If -ve then not applied (use current setting)
    /// </summary>
    public float MuscleStiffnessLeftArm
    {
        get { return muscleStiffnessLeftArm; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 10.00f);
            SetArgument("muscleStiffnessLeftArm", value);
            muscleStiffnessLeftArm = value;
        } 
    }

    private float muscleStiffnessRightArm = -1.0f;
    /// <summary>
    /// muscle stiffness applied to right arm (applied after stiffness). If -ve then not applied (use current setting)
    /// </summary>
    public float MuscleStiffnessRightArm
    {
        get { return muscleStiffnessRightArm; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 10.00f);
            SetArgument("muscleStiffnessRightArm", value);
            muscleStiffnessRightArm = value;
        } 
    }

    private float muscleStiffnessSpine = -1.0f;
    /// <summary>
    /// muscle stiffness applied to spine (applied after stiffness). If -ve then not applied (use current setting)
    /// </summary>
    public float MuscleStiffnessSpine
    {
        get { return muscleStiffnessSpine; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 10.00f);
            SetArgument("muscleStiffnessSpine", value);
            muscleStiffnessSpine = value;
        } 
    }

    private float muscleStiffnessLeftLeg = -1.0f;
    /// <summary>
    /// muscle stiffness applied to left leg (applied after stiffness). If -ve then not applied (use current setting)
    /// </summary>
    public float MuscleStiffnessLeftLeg
    {
        get { return muscleStiffnessLeftLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 10.00f);
            SetArgument("muscleStiffnessLeftLeg", value);
            muscleStiffnessLeftLeg = value;
        } 
    }

    private float muscleStiffnessRightLeg = -1.0f;
    /// <summary>
    /// muscle stiffness applied to right leg (applied after stiffness). If -ve then not applied (use current setting)
    /// </summary>
    public float MuscleStiffnessRightLeg
    {
        get { return muscleStiffnessRightLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 10.00f);
            SetArgument("muscleStiffnessRightLeg", value);
            muscleStiffnessRightLeg = value;
        } 
    }

    private float stiffnessLeftArm = -1.0f;
    /// <summary>
    /// stiffness  applied to left arm (applied after stiffness). If -ve then not applied (use current setting)
    /// </summary>
    public float StiffnessLeftArm
    {
        get { return stiffnessLeftArm; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 16.00f);
            SetArgument("stiffnessLeftArm", value);
            stiffnessLeftArm = value;
        } 
    }

    private float stiffnessRightArm = -1.0f;
    /// <summary>
    /// stiffness applied to right arm (applied after stiffness). If -ve then not applied (use current setting)
    /// </summary>
    public float StiffnessRightArm
    {
        get { return stiffnessRightArm; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 16.00f);
            SetArgument("stiffnessRightArm", value);
            stiffnessRightArm = value;
        } 
    }

    private float stiffnessSpine = -1.0f;
    /// <summary>
    /// stiffness applied to spine (applied after stiffness). If -ve then not applied (use current setting)
    /// </summary>
    public float StiffnessSpine
    {
        get { return stiffnessSpine; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 16.00f);
            SetArgument("stiffnessSpine", value);
            stiffnessSpine = value;
        } 
    }

    private float stiffnessLeftLeg = -1.0f;
    /// <summary>
    /// stiffness applied to left leg (applied after stiffness). If -ve then not applied (use current setting)
    /// </summary>
    public float StiffnessLeftLeg
    {
        get { return stiffnessLeftLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 16.00f);
            SetArgument("stiffnessLeftLeg", value);
            stiffnessLeftLeg = value;
        } 
    }

    private float stiffnessRightLeg = -1.0f;
    /// <summary>
    /// stiffness applied to right leg (applied after stiffness). If -ve then not applied (use current setting)
    /// </summary>
    public float StiffnessRightLeg
    {
        get { return stiffnessRightLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 16.00f);
            SetArgument("stiffnessRightLeg", value);
            stiffnessRightLeg = value;
        } 
    }

    private float dampingLeftArm = 1.0f;
    /// <summary>
    /// damping applied to left arm (applied after stiffness). If stiffness -ve then not applied (use current setting)
    /// </summary>
    public float DampingLeftArm
    {
        get { return dampingLeftArm; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.00f);
            SetArgument("dampingLeftArm", value);
            dampingLeftArm = value;
        } 
    }

    private float dampingRightArm = 1.0f;
    /// <summary>
    /// damping applied to right arm (applied after stiffness). If stiffness -ve then not applied (use current setting)
    /// </summary>
    public float DampingRightArm
    {
        get { return dampingRightArm; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.00f);
            SetArgument("dampingRightArm", value);
            dampingRightArm = value;
        } 
    }

    private float dampingSpine = 1.0f;
    /// <summary>
    /// damping applied to spine (applied after stiffness). If stiffness-ve then not applied (use current setting)
    /// </summary>
    public float DampingSpine
    {
        get { return dampingSpine; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.00f);
            SetArgument("dampingSpine", value);
            dampingSpine = value;
        } 
    }

    private float dampingLeftLeg = 1.0f;
    /// <summary>
    /// damping applied to left leg (applied after stiffness). If stiffness-ve then not applied (use current setting)
    /// </summary>
    public float DampingLeftLeg
    {
        get { return dampingLeftLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.00f);
            SetArgument("dampingLeftLeg", value);
            dampingLeftLeg = value;
        } 
    }

    private float dampingRightLeg = 1.0f;
    /// <summary>
    /// damping applied to right leg (applied after stiffness). If stiffness -ve then not applied (use current setting)
    /// </summary>
    public float DampingRightLeg
    {
        get { return dampingRightLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.00f);
            SetArgument("dampingRightLeg", value);
            dampingRightLeg = value;
        } 
    }

    private float gravCompLeftArm = -1.0f;
    /// <summary>
    /// gravity compensation applied to left arm (applied after gravityCompensation). If -ve then not applied (use current setting)
    /// </summary>
    public float GravCompLeftArm
    {
        get { return gravCompLeftArm; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 14.00f);
            SetArgument("gravCompLeftArm", value);
            gravCompLeftArm = value;
        } 
    }

    private float gravCompRightArm = -1.0f;
    /// <summary>
    /// gravity compensation applied to right arm (applied after gravityCompensation). If -ve then not applied (use current setting)
    /// </summary>
    public float GravCompRightArm
    {
        get { return gravCompRightArm; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 14.00f);
            SetArgument("gravCompRightArm", value);
            gravCompRightArm = value;
        } 
    }

    private float gravCompSpine = -1.0f;
    /// <summary>
    /// gravity compensation applied to spine (applied after gravityCompensation). If -ve then not applied (use current setting)
    /// </summary>
    public float GravCompSpine
    {
        get { return gravCompSpine; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 14.00f);
            SetArgument("gravCompSpine", value);
            gravCompSpine = value;
        } 
    }

    private float gravCompLeftLeg = -1.0f;
    /// <summary>
    /// gravity compensation applied to left leg (applied after gravityCompensation). If -ve then not applied (use current setting)
    /// </summary>
    public float GravCompLeftLeg
    {
        get { return gravCompLeftLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 14.00f);
            SetArgument("gravCompLeftLeg", value);
            gravCompLeftLeg = value;
        } 
    }

    private float gravCompRightLeg = -1.0f;
    /// <summary>
    /// gravity compensation applied to right leg (applied after gravityCompensation). If -ve then not applied (use current setting)
    /// </summary>
    public float GravCompRightLeg
    {
        get { return gravCompRightLeg; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 14.00f);
            SetArgument("gravCompRightLeg", value);
            gravCompRightLeg = value;
        } 
    }

    private int connectedLeftHand = 0;
    /// <summary>
    /// Is the left hand constrained to the world/ an object: -1=auto decide by impact info, 0=no, 1=part fully constrained (not implemented:, 2=part point constraint, 3=line constraint)
    /// </summary>
    public int ConnectedLeftHand
    {
        get { return connectedLeftHand; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1, 2);
            SetArgument("connectedLeftHand", value);
            connectedLeftHand = value;
        } 
    }

    private int connectedRightHand = 0;
    /// <summary>
    /// Is the right hand constrained to the world/ an object: -1=auto decide by impact info, 0=no, 1=part fully constrained (not implemented:, 2=part point constraint, 3=line constraint)
    /// </summary>
    public int ConnectedRightHand
    {
        get { return connectedRightHand; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1, 2);
            SetArgument("connectedRightHand", value);
            connectedRightHand = value;
        } 
    }

    private int connectedLeftFoot = -2;
    /// <summary>
    /// Is the left foot constrained to the world/ an object: -2=do not set in animpose (e.g. let the balancer decide), -1=auto decide by impact info, 0=no, 1=part fully constrained (not implemented:, 2=part point constraint, 3=line constraint)
    /// </summary>
    public int ConnectedLeftFoot
    {
        get { return connectedLeftFoot; } 
        set 
        {  
            value = MathHelper.Clamp(value, -2, 2);
            SetArgument("connectedLeftFoot", value);
            connectedLeftFoot = value;
        } 
    }

    private int connectedRightFoot = -2;
    /// <summary>
    /// Is the right foot constrained to the world/ an object: -2=do not set in animpose (e.g. let the balancer decide),-1=auto decide by impact info, 0=no, 1=part fully constrained (not implemented:, 2=part point constraint, 3=line constraint)
    /// </summary>
    public int ConnectedRightFoot
    {
        get { return connectedRightFoot; } 
        set 
        {  
            value = MathHelper.Clamp(value, -2, 2);
            SetArgument("connectedRightFoot", value);
            connectedRightFoot = value;
        } 
    }

    private int animSource;
    /// <summary>
    /// AnimSource 0 = CurrentItms, 1 = PreviousItms, 2 = AnimItms
    /// </summary>
    public int AnimSource
    {
        get { return animSource; } 
        set 
        {  
                
            SetArgument("animSource", value);
            animSource = value;
        } 
    }

    private int dampenSideMotionInstanceIndex = -1;
    /// <summary>
    /// LevelIndex of object to dampen side motion relative to. -1 means not used.
    /// </summary>
    public int DampenSideMotionInstanceIndex
    {
        get { return dampenSideMotionInstanceIndex; } 
        set 
        {  
                
            SetArgument("dampenSideMotionInstanceIndex", value);
            dampenSideMotionInstanceIndex = value;
        } 
    }


    public EuphoriaMessageAnimPose(bool startNow) : base("animPose", startNow)
    { }

    public new void Reset()
    {
        muscleStiffness = -1.0f;
        stiffness = -1.0f;
        damping = 1.0f;
        effectorMask = "ub";
        overideHeadlook = false;
        overidePointArm = false;
        overidePointGun = false;
        useZMPGravityCompensation = true;
        gravityCompensation = -1.0f;
        muscleStiffnessLeftArm = -1.0f;
        muscleStiffnessRightArm = -1.0f;
        muscleStiffnessSpine = -1.0f;
        muscleStiffnessLeftLeg = -1.0f;
        muscleStiffnessRightLeg = -1.0f;
        stiffnessLeftArm = -1.0f;
        stiffnessRightArm = -1.0f;
        stiffnessSpine = -1.0f;
        stiffnessLeftLeg = -1.0f;
        stiffnessRightLeg = -1.0f;
        dampingLeftArm = 1.0f;
        dampingRightArm = 1.0f;
        dampingSpine = 1.0f;
        dampingLeftLeg = 1.0f;
        dampingRightLeg = 1.0f;
        gravCompLeftArm = -1.0f;
        gravCompRightArm = -1.0f;
        gravCompSpine = -1.0f;
        gravCompLeftLeg = -1.0f;
        gravCompRightLeg = -1.0f;
        connectedLeftHand = 0;
        connectedRightHand = 0;
        connectedLeftFoot = -2;
        connectedRightFoot = -2;
        animSource = default(int);
        dampenSideMotionInstanceIndex = -1;
        base.Reset();
    }
}
}
