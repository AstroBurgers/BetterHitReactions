using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// InjuredOnGround
/// </summary>

internal class EuphoriaMessageInjuredOnGround : EuphoriaMessage
{
    private int numInjuries = 0;
    /// <summary>
    /// 
    /// </summary>
    public int NumInjuries
    {
        get { return numInjuries; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("numInjuries", value);
            numInjuries = value;
        } 
    }

    private int injury1Component = 0;
    /// <summary>
    /// 
    /// </summary>
    public int Injury1Component
    {
        get { return injury1Component; } 
        set 
        {  
                
            SetArgument("injury1Component", value);
            injury1Component = value;
        } 
    }

    private int injury2Component = 0;
    /// <summary>
    /// 
    /// </summary>
    public int Injury2Component
    {
        get { return injury2Component; } 
        set 
        {  
                
            SetArgument("injury2Component", value);
            injury2Component = value;
        } 
    }

    private Vector3 injury1LocalPosition = new(0f,  0f,  0f);
    /// <summary>
    /// 
    /// </summary>
    public Vector3 Injury1LocalPosition
    {
        get { return injury1LocalPosition; } 
        set 
        {  
                
            SetArgument("injury1LocalPosition", value);
            injury1LocalPosition = value;
        } 
    }

    private Vector3 injury2LocalPosition = new(0f,  0f,  0f);
    /// <summary>
    /// 
    /// </summary>
    public Vector3 Injury2LocalPosition
    {
        get { return injury2LocalPosition; } 
        set 
        {  
                
            SetArgument("injury2LocalPosition", value);
            injury2LocalPosition = value;
        } 
    }

    private Vector3 injury1LocalNormal = new(1f,  0f,  0f);
    /// <summary>
    /// 
    /// </summary>
    public Vector3 Injury1LocalNormal
    {
        get { return injury1LocalNormal; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, 0.0f, 1.0f);
            value.Y = MathHelper.Clamp(value.Y, 0.0f, 1.0f);
            value.Z = MathHelper.Clamp(value.Z, 0.0f, 1.0f);
            SetArgument("injury1LocalNormal", value);
            injury1LocalNormal = value;
        } 
    }

    private Vector3 injury2LocalNormal = new(1f,  0f,  0f);
    /// <summary>
    /// 
    /// </summary>
    public Vector3 Injury2LocalNormal
    {
        get { return injury2LocalNormal; } 
        set 
        {  
            value.X = MathHelper.Clamp(value.X, 0.0f, 1.0f);
            value.Y = MathHelper.Clamp(value.Y, 0.0f, 1.0f);
            value.Z = MathHelper.Clamp(value.Z, 0.0f, 1.0f);
            SetArgument("injury2LocalNormal", value);
            injury2LocalNormal = value;
        } 
    }

    private Vector3 attackerPos = new(1f,  0f,  0f);
    /// <summary>
    /// 
    /// </summary>
    public Vector3 AttackerPos
    {
        get { return attackerPos; } 
        set 
        {  
                
            SetArgument("attackerPos", value);
            attackerPos = value;
        } 
    }

    private bool dontReachWithLeft = false;
    /// <summary>
    /// 
    /// </summary>
    public bool DontReachWithLeft
    {
        get { return dontReachWithLeft; } 
        set 
        {  
                
            SetArgument("dontReachWithLeft", value);
            dontReachWithLeft = value;
        } 
    }

    private bool dontReachWithRight = false;
    /// <summary>
    /// 
    /// </summary>
    public bool DontReachWithRight
    {
        get { return dontReachWithRight; } 
        set 
        {  
                
            SetArgument("dontReachWithRight", value);
            dontReachWithRight = value;
        } 
    }

    private bool strongRollForce = false;
    /// <summary>
    /// 
    /// </summary>
    public bool StrongRollForce
    {
        get { return strongRollForce; } 
        set 
        {  
                
            SetArgument("strongRollForce", value);
            strongRollForce = value;
        } 
    }


    public EuphoriaMessageInjuredOnGround(bool startNow) : base("injuredOnGround", startNow)
    { }

    public new void Reset()
    {
        numInjuries = 0;
        injury1Component = 0;
        injury2Component = 0;
        injury1LocalPosition = new Vector3(0f,  0f,  0f);
        injury2LocalPosition = new Vector3(0f,  0f,  0f);
        injury1LocalNormal = new Vector3(1f,  0f,  0f);
        injury2LocalNormal = new Vector3(1f,  0f,  0f);
        attackerPos = new Vector3(1f,  0f,  0f);
        dontReachWithLeft = false;
        dontReachWithRight = false;
        strongRollForce = false;
        base.Reset();
    }
}
}
