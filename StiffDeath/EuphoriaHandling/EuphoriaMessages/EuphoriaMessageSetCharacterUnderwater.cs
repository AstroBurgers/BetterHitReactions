using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// setCharacterUnderwater:  Sets viscosity applied to damping limbs
/// </summary>

internal class EuphoriaMessageSetCharacterUnderwater : EuphoriaMessage
{
    private bool underwater = false;
    /// <summary>
    /// is character underwater?
    /// </summary>
    public bool Underwater
    {
        get { return underwater; } 
        set 
        {  
                
            SetArgument("underwater", value);
            underwater = value;
        } 
    }

    private float viscosity = -1.00f;
    /// <summary>
    /// viscosity applied to character's parts
    /// </summary>
    public float Viscosity
    {
        get { return viscosity; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 100.00f);
            SetArgument("viscosity", value);
            viscosity = value;
        } 
    }

    private float gravityFactor = 1.00f;
    /// <summary>
    /// gravity factor applied to character
    /// </summary>
    public float GravityFactor
    {
        get { return gravityFactor; } 
        set 
        {  
            value = MathHelper.Clamp(value, -10.00f, 10.00f);
            SetArgument("gravityFactor", value);
            gravityFactor = value;
        } 
    }

    private float stroke = 0.00f;
    /// <summary>
    /// swimming force applied to character as a function of handVelocity and footVelocity
    /// </summary>
    public float Stroke
    {
        get { return stroke; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1000.00f, 1000.00f);
            SetArgument("stroke", value);
            stroke = value;
        } 
    }

    private bool linearStroke = false;
    /// <summary>
    /// swimming force (linearStroke=true,False) = (f(v),f(v*v))
    /// </summary>
    public bool LinearStroke
    {
        get { return linearStroke; } 
        set 
        {  
                
            SetArgument("linearStroke", value);
            linearStroke = value;
        } 
    }


    public EuphoriaMessageSetCharacterUnderwater(bool startNow) : base("setCharacterUnderwater", startNow)
    { }

    public new void Reset()
    {
        underwater = false;
        viscosity = -1.00f;
        gravityFactor = 1.00f;
        stroke = 0.00f;
        linearStroke = false;
        base.Reset();
    }
}
}
