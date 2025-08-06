using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// configureConstraints:  One shot to give state of constraints on character and response to constraints
/// </summary>

internal class EuphoriaMessageConfigureConstraints : EuphoriaMessage
{
    private bool handCuffs = false;
    /// <summary>
    /// 
    /// </summary>
    public bool HandCuffs
    {
        get { return handCuffs; } 
        set 
        {  
                
            SetArgument("handCuffs", value);
            handCuffs = value;
        } 
    }

    private bool handCuffsBehindBack = false;
    /// <summary>
    /// not implemented
    /// </summary>
    public bool HandCuffsBehindBack
    {
        get { return handCuffsBehindBack; } 
        set 
        {  
                
            SetArgument("handCuffsBehindBack", value);
            handCuffsBehindBack = value;
        } 
    }

    private bool legCuffs = false;
    /// <summary>
    /// not implemented
    /// </summary>
    public bool LegCuffs
    {
        get { return legCuffs; } 
        set 
        {  
                
            SetArgument("legCuffs", value);
            legCuffs = value;
        } 
    }

    private bool rightDominant = false;
    /// <summary>
    /// 
    /// </summary>
    public bool RightDominant
    {
        get { return rightDominant; } 
        set 
        {  
                
            SetArgument("rightDominant", value);
            rightDominant = value;
        } 
    }

    private int passiveMode = 0;
    /// <summary>
    /// 0 setCurrent, 1= IK to dominant, (2=pointGunLikeIK //not implemented)
    /// </summary>
    public int PassiveMode
    {
        get { return passiveMode; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 5);
            SetArgument("passiveMode", value);
            passiveMode = value;
        } 
    }

    private bool bespokeBehaviour = false;
    /// <summary>
    /// not implemented
    /// </summary>
    public bool BespokeBehaviour
    {
        get { return bespokeBehaviour; } 
        set 
        {  
                
            SetArgument("bespokeBehaviour", value);
            bespokeBehaviour = value;
        } 
    }

    private float blend2ZeroPose = 0f;
    /// <summary>
    /// Blend Arms to zero pose
    /// </summary>
    public float Blend2ZeroPose
    {
        get { return blend2ZeroPose; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("blend2ZeroPose", value);
            blend2ZeroPose = value;
        } 
    }


    public EuphoriaMessageConfigureConstraints(bool startNow) : base("configureConstraints", startNow)
    { }

    public new void Reset()
    {
        handCuffs = false;
        handCuffsBehindBack = false;
        legCuffs = false;
        rightDominant = false;
        passiveMode = 0;
        bespokeBehaviour = false;
        blend2ZeroPose = 0f;
        base.Reset();
    }
}
}
