using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// setCharacterStrength:  Sets character's strength on the dead-granny-to-healthy-terminator scale: [0..1]
/// </summary>

internal class EuphoriaMessageSetCharacterStrength : EuphoriaMessage
{
    private float characterStrength = 1.00f;
    /// <summary>
    /// strength of character
    /// </summary>
    public float CharacterStrength
    {
        get { return characterStrength; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("characterStrength", value);
            characterStrength = value;
        } 
    }


    public EuphoriaMessageSetCharacterStrength(bool startNow) : base("setCharacterStrength", startNow)
    { }

    public new void Reset()
    {
        characterStrength = 1.00f;
        base.Reset();
    }
}
}
