namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageArmsWindmillAdaptive : EuphoriaMessage
{
    private float angSpeed = 6.280f;
    /// <summary>
    /// Controls the speed of the windmilling
    /// </summary>
    public float AngSpeed
    {
        get { return angSpeed; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 10.0f);
            SetArgument("angSpeed", value);
            angSpeed = value;
        } 
    }

    private float bodyStiffness = 11.000f;
    /// <summary>
    /// Controls how stiff the rest of the body is
    /// </summary>
    public float BodyStiffness
    {
        get { return bodyStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 6.0f, 16.0f);
            SetArgument("bodyStiffness", value);
            bodyStiffness = value;
        } 
    }

    private float amplitude = 0.600f;
    /// <summary>
    /// Controls how large the motion is, higher values means the character waves his arms in a massive arc
    /// </summary>
    public float Amplitude
    {
        get { return amplitude; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("amplitude", value);
            amplitude = value;
        } 
    }

    private float phase = 0.000f;
    /// <summary>
    /// Set to a non-zero value to desynchronise the left and right arms motion.
    /// </summary>
    public float Phase
    {
        get { return phase; } 
        set 
        {  
            value = MathHelper.Clamp(value, -4.0f, 8.0f);
            SetArgument("phase", value);
            phase = value;
        } 
    }

    private float armStiffness = 14.140f;
    /// <summary>
    /// How stiff the arms are controls how pronounced the windmilling motion appears
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

    private float leftElbowAngle = -1.0f;
    /// <summary>
    /// If not negative then left arm will blend to this angle
    /// </summary>
    public float LeftElbowAngle
    {
        get { return leftElbowAngle; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 6.0f);
            SetArgument("leftElbowAngle", value);
            leftElbowAngle = value;
        } 
    }

    private float rightElbowAngle = -1.0f;
    /// <summary>
    /// If not negative then right arm will blend to this angle
    /// </summary>
    public float RightElbowAngle
    {
        get { return rightElbowAngle; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.0f, 6.0f);
            SetArgument("rightElbowAngle", value);
            rightElbowAngle = value;
        } 
    }

    private float lean1mult = 1.0f;
    /// <summary>
    /// 0 arms go up and down at the side. 1 circles. 0..1 elipse
    /// </summary>
    public float Lean1mult
    {
        get { return lean1mult; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("lean1mult", value);
            lean1mult = value;
        } 
    }

    private float lean1offset = 0.0f;
    /// <summary>
    /// 0.f centre of circle at side.
    /// </summary>
    public float Lean1offset
    {
        get { return lean1offset; } 
        set 
        {  
            value = MathHelper.Clamp(value, -6.0f, 6.0f);
            SetArgument("lean1offset", value);
            lean1offset = value;
        } 
    }

    private float elbowRate = 1.0f;
    /// <summary>
    /// rate at which elbow tries to match *ElbowAngle
    /// </summary>
    public float ElbowRate
    {
        get { return elbowRate; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 6.0f);
            SetArgument("elbowRate", value);
            elbowRate = value;
        } 
    }

    private int armDirection = 0;
    /// <summary>
    /// Arm circling direction.  -1 = Backwards, 0 = Adaptive, 1 = Forwards
    /// </summary>
    public int ArmDirection
    {
        get { return armDirection; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1, 1);
            SetArgument("armDirection", value);
            armDirection = value;
        } 
    }

    private bool disableOnImpact = true;
    /// <summary>
    /// If true, each arm will stop windmilling if it hits the ground
    /// </summary>
    public bool DisableOnImpact
    {
        get { return disableOnImpact; } 
        set 
        {  
                
            SetArgument("disableOnImpact", value);
            disableOnImpact = value;
        } 
    }

    private bool setBackAngles = true;
    /// <summary>
    /// If true, back angles will be set to compliment arms windmill
    /// </summary>
    public bool SetBackAngles
    {
        get { return setBackAngles; } 
        set 
        {  
                
            SetArgument("setBackAngles", value);
            setBackAngles = value;
        } 
    }

    private bool useAngMom = false;
    /// <summary>
    /// If true, use angular momentum about com to choose arm circling direction. Otherwise use com angular velocity
    /// </summary>
    public bool UseAngMom
    {
        get { return useAngMom; } 
        set 
        {  
                
            SetArgument("useAngMom", value);
            useAngMom = value;
        } 
    }

    private bool bendLeftElbow = false;
    /// <summary>
    /// If true, bend the left elbow to give a stuntman type scramble look
    /// </summary>
    public bool BendLeftElbow
    {
        get { return bendLeftElbow; } 
        set 
        {  
                
            SetArgument("bendLeftElbow", value);
            bendLeftElbow = value;
        } 
    }

    private bool bendRightElbow = false;
    /// <summary>
    /// If true, bend the right elbow to give a stuntman type scramble look
    /// </summary>
    public bool BendRightElbow
    {
        get { return bendRightElbow; } 
        set 
        {  
                
            SetArgument("bendRightElbow", value);
            bendRightElbow = value;
        } 
    }

    private string mask = "ub";
    /// <summary>
    /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value  (see Active Pose notes for possible values)
    /// </summary>
    public string Mask
    {
        get { return mask; } 
        set 
        {  
                
            SetArgument("mask", value);
            mask = value;
        } 
    }


    public EuphoriaMessageArmsWindmillAdaptive(bool startNow) : base("armsWindmillAdaptive", startNow)
    { }

    public new void Reset()
    {
        angSpeed = 6.280f;
        bodyStiffness = 11.000f;
        amplitude = 0.600f;
        phase = 0.000f;
        armStiffness = 14.140f;
        leftElbowAngle = -1.0f;
        rightElbowAngle = -1.0f;
        lean1mult = 1.0f;
        lean1offset = 0.0f;
        elbowRate = 1.0f;
        armDirection = 0;
        disableOnImpact = true;
        setBackAngles = true;
        useAngMom = false;
        bendLeftElbow = false;
        bendRightElbow = false;
        mask = "ub";
        base.Reset();
    }
}
}
