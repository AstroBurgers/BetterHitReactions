using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageBodyFoetal : EuphoriaMessage
{
    private float stiffness = 9.000f;
    /// <summary>
    /// The stiffness of the body determines how fast the character moves into the position, and how well that they hold it.
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

    private float dampingFactor = 1.400f;
    /// <summary>
    /// Sets damping value for the character joints
    /// </summary>
    public float DampingFactor
    {
        get { return dampingFactor; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 2.0f);
            SetArgument("dampingFactor", value);
            dampingFactor = value;
        } 
    }

    private float asymmetry = 0.000f;
    /// <summary>
    /// A value between 0-1 that controls how asymmetric the results are by varying stiffness across the body
    /// </summary>
    public float Asymmetry
    {
        get { return asymmetry; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("asymmetry", value);
            asymmetry = value;
        } 
    }

    private int randomSeed = 100;
    /// <summary>
    /// Random seed used to generate asymmetry values
    /// </summary>
    public int RandomSeed
    {
        get { return randomSeed; } 
        set 
        {  
                
            SetArgument("randomSeed", value);
            randomSeed = value;
        } 
    }

    private float backTwist = 0.000f;
    /// <summary>
    /// Amount of random back twist to add
    /// </summary>
    public float BackTwist
    {
        get { return backTwist; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0f, 1.0f);
            SetArgument("backTwist", value);
            backTwist = value;
        } 
    }

    private string mask = "fb";
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


    public EuphoriaMessageBodyFoetal(bool startNow) : base("bodyFoetal", startNow)
    { }

    public new void Reset()
    {
        stiffness = 9.000f;
        dampingFactor = 1.400f;
        asymmetry = 0.000f;
        randomSeed = 100;
        backTwist = 0.000f;
        mask = "fb";
        base.Reset();
    }
}
}
