using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageActivePose : EuphoriaMessage
{
    private string mask = "fb";
    /// <summary>
    /// Two character body-masking value, bitwise joint mask or bitwise logic string of two character body-masking value  (see notes for explanation)
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

    private bool useGravityCompensation = false;
    /// <summary>
    /// Apply gravity compensation as well?
    /// </summary>
    public bool UseGravityCompensation
    {
        get { return useGravityCompensation; } 
        set 
        {  
                
            SetArgument("useGravityCompensation", value);
            useGravityCompensation = value;
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


    public EuphoriaMessageActivePose(bool startNow) : base("activePose", startNow)
    { }

    public new void Reset()
    {
        mask = "fb";
        useGravityCompensation = false;
        animSource = default(int);
        base.Reset();
    }
}
}
