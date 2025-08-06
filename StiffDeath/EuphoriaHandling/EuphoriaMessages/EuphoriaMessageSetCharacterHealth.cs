namespace BetterHitReactions.EuphoriaHandling.EuphoriaMessages
{
/// <summary>
/// setCharacterHealth:  Sets character's health on the dead-to-alive scale: [0..1]
/// </summary>

internal class EuphoriaMessageSetCharacterHealth : EuphoriaMessage
{
    private float characterHealth = 1.00f;
    /// <summary>
    /// health of character
    /// </summary>
    public float CharacterHealth
    {
        get { return characterHealth; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("characterHealth", value);
            characterHealth = value;
        } 
    }


    public EuphoriaMessageSetCharacterHealth(bool startNow) : base("setCharacterHealth", startNow)
    { }

    public new void Reset()
    {
        characterHealth = 1.00f;
        base.Reset();
    }
}
}
