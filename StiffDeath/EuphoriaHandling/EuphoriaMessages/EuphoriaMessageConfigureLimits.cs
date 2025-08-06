using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// configureLimits:  Enable/disable/edit character limits in real time.  This adjusts limits in RAGE-native space and will *not* reorient the joint.
/// </summary>

internal class EuphoriaMessageConfigureLimits : EuphoriaMessage
{
    private string mask = "fb";
    /// <summary>
    /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value  for joint limits to configure. Ignored if index != -1.
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

    private bool enable = true;
    /// <summary>
    /// If false, disable (set all to PI, -PI) limits.
    /// </summary>
    public bool Enable
    {
        get { return enable; } 
        set 
        {  
                
            SetArgument("enable", value);
            enable = value;
        } 
    }

    private bool toDesired = false;
    /// <summary>
    /// If true, set limits to accommodate current desired angles
    /// </summary>
    public bool ToDesired
    {
        get { return toDesired; } 
        set 
        {  
                
            SetArgument("toDesired", value);
            toDesired = value;
        } 
    }

    private bool restore = false;
    /// <summary>
    /// Return to cached defaults?
    /// </summary>
    public bool Restore
    {
        get { return restore; } 
        set 
        {  
                
            SetArgument("restore", value);
            restore = value;
        } 
    }

    private bool toCurAnimation = false;
    /// <summary>
    /// If true, set limits to the current animated limits
    /// </summary>
    public bool ToCurAnimation
    {
        get { return toCurAnimation; } 
        set 
        {  
                
            SetArgument("toCurAnimation", value);
            toCurAnimation = value;
        } 
    }

    private int index = -1;
    /// <summary>
    /// Index of effector to configure.  Set to -1 to use mask.
    /// </summary>
    public int Index
    {
        get { return index; } 
        set 
        {  
                
            SetArgument("index", value);
            index = value;
        } 
    }

    private float lean1 = 1.570796f;
    /// <summary>
    /// Custom limit values to use if not setting limits to desired. Limits are RAGE-native, not NM-wrapper-native.
    /// </summary>
    public float Lean1
    {
        get { return lean1; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.141593f);
            SetArgument("lean1", value);
            lean1 = value;
        } 
    }

    private float lean2 = 1.570796f;
    /// <summary>
    /// 
    /// </summary>
    public float Lean2
    {
        get { return lean2; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.141593f);
            SetArgument("lean2", value);
            lean2 = value;
        } 
    }

    private float twist = 1.570796f;
    /// <summary>
    /// 
    /// </summary>
    public float Twist
    {
        get { return twist; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.141593f);
            SetArgument("twist", value);
            twist = value;
        } 
    }

    private float margin = 0.196350f;
    /// <summary>
    /// Joint limit margin to add to current animation limits when using those to set runtime limits.
    /// </summary>
    public float Margin
    {
        get { return margin; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 3.141593f);
            SetArgument("margin", value);
            margin = value;
        } 
    }


    public EuphoriaMessageConfigureLimits(bool startNow) : base("configureLimits", startNow)
    { }

    public new void Reset()
    {
        mask = "fb";
        enable = true;
        toDesired = false;
        restore = false;
        toCurAnimation = false;
        index = -1;
        lean1 = 1.570796f;
        lean2 = 1.570796f;
        twist = 1.570796f;
        margin = 0.196350f;
        base.Reset();
    }
}
}
