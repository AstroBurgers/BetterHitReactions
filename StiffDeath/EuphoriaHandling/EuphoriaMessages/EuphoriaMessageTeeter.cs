using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessageTeeter : EuphoriaMessage
{
    private Vector3 edgeLeft = new(39.470f,  38.890f,  21.120f);
    /// <summary>
    /// Defines the left edge point (left of character facing edge)
    /// </summary>
    public Vector3 EdgeLeft
    {
        get { return edgeLeft; } 
        set 
        {  
                
            SetArgument("edgeLeft", value);
            edgeLeft = value;
        } 
    }

    private Vector3 edgeRight = new(39.470f,  39.890f,  21.120f);
    /// <summary>
    /// Defines the right edge point (right of character facing edge)
    /// </summary>
    public Vector3 EdgeRight
    {
        get { return edgeRight; } 
        set 
        {  
                
            SetArgument("edgeRight", value);
            edgeRight = value;
        } 
    }

    private bool useExclusionZone = true;
    /// <summary>
    /// stop stepping across the line defined by edgeLeft and edgeRight
    /// </summary>
    public bool UseExclusionZone
    {
        get { return useExclusionZone; } 
        set 
        {  
                
            SetArgument("useExclusionZone", value);
            useExclusionZone = value;
        } 
    }

    private bool useHeadLook = true;
    /// <summary>
    /// 
    /// </summary>
    public bool UseHeadLook
    {
        get { return useHeadLook; } 
        set 
        {  
                
            SetArgument("useHeadLook", value);
            useHeadLook = value;
        } 
    }

    private bool callHighFall = true;
    /// <summary>
    /// call highFall if fallen over the edge.  If false just call blended writhe (to go over the top of the fall behaviour of the underlying behaviour e.g. bodyBalance)
    /// </summary>
    public bool CallHighFall
    {
        get { return callHighFall; } 
        set 
        {  
                
            SetArgument("callHighFall", value);
            callHighFall = value;
        } 
    }

    private bool leanAway = true;
    /// <summary>
    /// lean away from the edge based on velocity towards the edge (if closer than 2m from edge)
    /// </summary>
    public bool LeanAway
    {
        get { return leanAway; } 
        set 
        {  
                
            SetArgument("leanAway", value);
            leanAway = value;
        } 
    }

    private float preTeeterTime = 2.00f;
    /// <summary>
    /// Time-to-edge threshold to start pre-teeter (windmilling, etc).
    /// </summary>
    public float PreTeeterTime
    {
        get { return preTeeterTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("preTeeterTime", value);
            preTeeterTime = value;
        } 
    }

    private float leanAwayTime = 1.00f;
    /// <summary>
    /// Time-to-edge threshold to start leaning away from a potential fall.
    /// </summary>
    public float LeanAwayTime
    {
        get { return leanAwayTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("leanAwayTime", value);
            leanAwayTime = value;
        } 
    }

    private float leanAwayScale = 0.50f;
    /// <summary>
    /// Scales stay upright lean and hip pitch.
    /// </summary>
    public float LeanAwayScale
    {
        get { return leanAwayScale; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("leanAwayScale", value);
            leanAwayScale = value;
        } 
    }

    private float teeterTime = 1.00f;
    /// <summary>
    /// Time-to-edge threshold to start full-on teeter (more aggressive lean, drop-and-twist, etc).
    /// </summary>
    public float TeeterTime
    {
        get { return teeterTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("teeterTime", value);
            teeterTime = value;
        } 
    }


    public EuphoriaMessageTeeter(bool startNow) : base("teeter", startNow)
    { }

    public new void Reset()
    {
        edgeLeft = new Vector3(39.470f,  38.890f,  21.120f);
        edgeRight = new Vector3(39.470f,  39.890f,  21.120f);
        useExclusionZone = true;
        useHeadLook = true;
        callHighFall = true;
        leanAway = true;
        preTeeterTime = 2.00f;
        leanAwayTime = 1.00f;
        leanAwayScale = 0.50f;
        teeterTime = 1.00f;
        base.Reset();
    }
}
}
