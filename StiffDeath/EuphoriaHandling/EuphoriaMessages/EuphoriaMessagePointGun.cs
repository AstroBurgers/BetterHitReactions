using Rage.Euphoria;

namespace BetterHitReactions.EuphoriaMessages
{
/// <summary>
/// 
/// </summary>

internal class EuphoriaMessagePointGun : EuphoriaMessage
{
    private bool enableRight = true;
    /// <summary>
    /// Allow right hand to point/support?
    /// </summary>
    public bool EnableRight
    {
        get { return enableRight; } 
        set 
        {  
                
            SetArgument("enableRight", value);
            enableRight = value;
        } 
    }

    private bool enableLeft = true;
    /// <summary>
    /// Allow right hand to point/support?
    /// </summary>
    public bool EnableLeft
    {
        get { return enableLeft; } 
        set 
        {  
                
            SetArgument("enableLeft", value);
            enableLeft = value;
        } 
    }

    private Vector3 leftHandTarget = new(0f,  0f,  0f);
    /// <summary>
    /// Target for the left Hand
    /// </summary>
    public Vector3 LeftHandTarget
    {
        get { return leftHandTarget; } 
        set 
        {  
                
            SetArgument("leftHandTarget", value);
            leftHandTarget = value;
        } 
    }

    private int leftHandTargetIndex = -1;
    /// <summary>
    /// Index of the object that the left hand target is specified in, -1 is world space.
    /// </summary>
    public int LeftHandTargetIndex
    {
        get { return leftHandTargetIndex; } 
        set 
        {  
                
            SetArgument("leftHandTargetIndex", value);
            leftHandTargetIndex = value;
        } 
    }

    private Vector3 rightHandTarget = new(0f,  0f,  0f);
    /// <summary>
    /// Target for the right Hand
    /// </summary>
    public Vector3 RightHandTarget
    {
        get { return rightHandTarget; } 
        set 
        {  
                
            SetArgument("rightHandTarget", value);
            rightHandTarget = value;
        } 
    }

    private int rightHandTargetIndex = -1;
    /// <summary>
    /// Index of the object that the right hand target is specified in, -1 is world space.
    /// </summary>
    public int RightHandTargetIndex
    {
        get { return rightHandTargetIndex; } 
        set 
        {  
                
            SetArgument("rightHandTargetIndex", value);
            rightHandTargetIndex = value;
        } 
    }

    private float leadTarget = 0.00f;
    /// <summary>
    /// NB: Only Applied to single handed weapons (some more work is required to have this tech on two handed weapons). Amount to lead target based on target velocity relative to the chest.
    /// </summary>
    public float LeadTarget
    {
        get { return leadTarget; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 10.00f);
            SetArgument("leadTarget", value);
            leadTarget = value;
        } 
    }

    private float armStiffness = 14.00f;
    /// <summary>
    /// Stiffness of the arm.
    /// </summary>
    public float ArmStiffness
    {
        get { return armStiffness; } 
        set 
        {  
            value = MathHelper.Clamp(value, 2.00f, 15.00f);
            SetArgument("armStiffness", value);
            armStiffness = value;
        } 
    }

    private float armStiffnessDetSupport = 8.00f;
    /// <summary>
    /// Stiffness of the arm on pointing arm when a support arm is detached from a two-handed weapon.
    /// </summary>
    public float ArmStiffnessDetSupport
    {
        get { return armStiffnessDetSupport; } 
        set 
        {  
            value = MathHelper.Clamp(value, 2.00f, 15.00f);
            SetArgument("armStiffnessDetSupport", value);
            armStiffnessDetSupport = value;
        } 
    }

    private float armDamping = 1.00f;
    /// <summary>
    /// Damping.
    /// </summary>
    public float ArmDamping
    {
        get { return armDamping; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 5.00f);
            SetArgument("armDamping", value);
            armDamping = value;
        } 
    }

    private float gravityOpposition = 1.00f;
    /// <summary>
    /// Amount of gravity opposition on pointing arm.
    /// </summary>
    public float GravityOpposition
    {
        get { return gravityOpposition; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("gravityOpposition", value);
            gravityOpposition = value;
        } 
    }

    private float gravOppDetachedSupport = 0.50f;
    /// <summary>
    /// Amount of gravity opposition on pointing arm when a support arm is detached from a two-handed weapon.
    /// </summary>
    public float GravOppDetachedSupport
    {
        get { return gravOppDetachedSupport; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 2.00f);
            SetArgument("gravOppDetachedSupport", value);
            gravOppDetachedSupport = value;
        } 
    }

    private float massMultDetachedSupport = 0.10f;
    /// <summary>
    /// Amount of mass of weapon taken into account by gravity opposition on pointing arm when a support arm is detached from a two-handed weapon.  The lower the value the more the character doesn't know about the weapon mass and therefore is more affected by it.
    /// </summary>
    public float MassMultDetachedSupport
    {
        get { return massMultDetachedSupport; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("massMultDetachedSupport", value);
            massMultDetachedSupport = value;
        } 
    }

    private bool allowShotLooseness = false;
    /// <summary>
    /// Allow shot to set a lower arm muscleStiffness than pointGun normally would.
    /// </summary>
    public bool AllowShotLooseness
    {
        get { return allowShotLooseness; } 
        set 
        {  
                
            SetArgument("allowShotLooseness", value);
            allowShotLooseness = value;
        } 
    }

    private float clavicleBlend = 0.00f;
    /// <summary>
    /// How much of blend should come from incoming transforms 0(all IK) .. 1(all ITMs)   For pointing arms only.  (Support arm uses the IK solution as is for clavicles)
    /// </summary>
    public float ClavicleBlend
    {
        get { return clavicleBlend; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("clavicleBlend", value);
            clavicleBlend = value;
        } 
    }

    private float elbowAttitude = 0.30f;
    /// <summary>
    /// Controls arm twist. (except in pistolIK)
    /// </summary>
    public float ElbowAttitude
    {
        get { return elbowAttitude; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("elbowAttitude", value);
            elbowAttitude = value;
        } 
    }

    private int supportConstraint = 1;
    /// <summary>
    /// Type of constraint between the support hand and gun.  0=no constraint, 1=hard distance constraint, 2=Force based constraint, 3=hard spherical constraint
    /// </summary>
    public int SupportConstraint
    {
        get { return supportConstraint; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 3);
            SetArgument("supportConstraint", value);
            supportConstraint = value;
        } 
    }

    private float constraintMinDistance = 0.0150f;
    /// <summary>
    /// For supportConstraint = 1: Support hand constraint distance will be slowly reduced until it hits this value.  This is for stability and also allows the pointing arm to lead a little.  Don't set lower than NM_MIN_STABLE_DISTANCECONSTRAINT_DISTANCE 0.001f
    /// </summary>
    public float ConstraintMinDistance
    {
        get { return constraintMinDistance; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.0010f, 0.10f);
            SetArgument("constraintMinDistance", value);
            constraintMinDistance = value;
        } 
    }

    private float makeConstraintDistance = 0.10f;
    /// <summary>
    /// For supportConstraint = 1:  Minimum distance within which support hand constraint will be made.
    /// </summary>
    public float MakeConstraintDistance
    {
        get { return makeConstraintDistance; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 3.00f);
            SetArgument("makeConstraintDistance", value);
            makeConstraintDistance = value;
        } 
    }

    private float reduceConstraintLengthVel = 1.50f;
    /// <summary>
    /// For supportConstraint = 1:  Velocity at which to reduce the support hand constraint length
    /// </summary>
    public float ReduceConstraintLengthVel
    {
        get { return reduceConstraintLengthVel; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 10.00f);
            SetArgument("reduceConstraintLengthVel", value);
            reduceConstraintLengthVel = value;
        } 
    }

    private float breakingStrength = -1.00f;
    /// <summary>
    /// For supportConstraint = 1: strength of the supporting hands constraint (kg m/s), -1 to ignore/disable
    /// </summary>
    public float BreakingStrength
    {
        get { return breakingStrength; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1000.00f);
            SetArgument("breakingStrength", value);
            breakingStrength = value;
        } 
    }

    private float brokenSupportTime = 1.00f;
    /// <summary>
    /// Once constraint is broken then do not try to reconnect/support for this amount of time
    /// </summary>
    public float BrokenSupportTime
    {
        get { return brokenSupportTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 5.00f);
            SetArgument("brokenSupportTime", value);
            brokenSupportTime = value;
        } 
    }

    private float brokenToSideProb = 0.50f;
    /// <summary>
    /// Probability that the when a constraint is broken that during brokenSupportTime a side pose will be selected.
    /// </summary>
    public float BrokenToSideProb
    {
        get { return brokenToSideProb; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 1.00f);
            SetArgument("brokenToSideProb", value);
            brokenToSideProb = value;
        } 
    }

    private float connectAfter = 0.70f;
    /// <summary>
    /// If gunArm has been controlled by other behaviours for this time when it could have been pointing but couldn't due to pointing only allowed if connected, change gunArm pose to something that could connect for connectFor seconds
    /// </summary>
    public float ConnectAfter
    {
        get { return connectAfter; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 5.00f);
            SetArgument("connectAfter", value);
            connectAfter = value;
        } 
    }

    private float connectFor = 0.550f;
    /// <summary>
    /// Time to try to reconnect for
    /// </summary>
    public float ConnectFor
    {
        get { return connectFor; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 5.00f);
            SetArgument("connectFor", value);
            connectFor = value;
        } 
    }

    private int oneHandedPointing = 1;
    /// <summary>
    /// 0 = don't allow, 1= allow for kPistol(two handed pistol) only, 2 = allow for kRifle only, 3 = allow for kPistol and kRifle. Allow one handed pointing - no constraint if cant be supported .  If not allowed then gunHand does not try to point at target if it cannot be supported - the constraint will be controlled by always support.
    /// </summary>
    public int OneHandedPointing
    {
        get { return oneHandedPointing; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 3);
            SetArgument("oneHandedPointing", value);
            oneHandedPointing = value;
        } 
    }

    private bool alwaysSupport = false;
    /// <summary>
    /// Support a non pointing gunHand i.e. if in zero pose (constrain as well  if constraint possible)
    /// </summary>
    public bool AlwaysSupport
    {
        get { return alwaysSupport; } 
        set 
        {  
                
            SetArgument("alwaysSupport", value);
            alwaysSupport = value;
        } 
    }

    private bool poseUnusedGunArm = false;
    /// <summary>
    /// Apply neutral pose when a gun arm isn't in use.  NB: at the moment Rifle hand is always controlled by pointGun.
    /// </summary>
    public bool PoseUnusedGunArm
    {
        get { return poseUnusedGunArm; } 
        set 
        {  
                
            SetArgument("poseUnusedGunArm", value);
            poseUnusedGunArm = value;
        } 
    }

    private bool poseUnusedSupportArm = false;
    /// <summary>
    /// Apply neutral pose when a support arm isn't in use.
    /// </summary>
    public bool PoseUnusedSupportArm
    {
        get { return poseUnusedSupportArm; } 
        set 
        {  
                
            SetArgument("poseUnusedSupportArm", value);
            poseUnusedSupportArm = value;
        } 
    }

    private bool poseUnusedOtherArm = false;
    /// <summary>
    /// Apply neutral pose to the non-gun arm (otherwise it is always under the control of other behaviours or not set). If the non-gun hand is a supporting hand it is not controlled by this parameter but by poseUnusedSupportArm
    /// </summary>
    public bool PoseUnusedOtherArm
    {
        get { return poseUnusedOtherArm; } 
        set 
        {  
                
            SetArgument("poseUnusedOtherArm", value);
            poseUnusedOtherArm = value;
        } 
    }

    private float maxAngleAcross = 90.00f;
    /// <summary>
    /// max aiming angle(deg) sideways across body midline measured from chest forward that the character will try to point
    /// </summary>
    public float MaxAngleAcross
    {
        get { return maxAngleAcross; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 180.00f);
            SetArgument("maxAngleAcross", value);
            maxAngleAcross = value;
        } 
    }

    private float maxAngleAway = 90.00f;
    /// <summary>
    /// max aiming angle(deg) sideways away from body midline measured from chest forward that the character will try to point
    /// </summary>
    public float MaxAngleAway
    {
        get { return maxAngleAway; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 180.00f);
            SetArgument("maxAngleAway", value);
            maxAngleAway = value;
        } 
    }

    private int fallingLimits = 0;
    /// <summary>
    /// 0= don't apply limits.  1=apply the limits below only when the character is falling.  2 =  always apply these limits (instead of applying maxAngleAcross and maxAngleAway which only limits the horizontal angle but implicity limits the updown (the limit shape is a vertical hinge)
    /// </summary>
    public int FallingLimits
    {
        get { return fallingLimits; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("fallingLimits", value);
            fallingLimits = value;
        } 
    }

    private float acrossLimit = 90.00f;
    /// <summary>
    /// max aiming angle(deg) sideways across body midline measured from chest forward that the character will try to point.  i.e. for rightHanded gun this is the angle left of the midline
    /// </summary>
    public float AcrossLimit
    {
        get { return acrossLimit; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 180.00f);
            SetArgument("acrossLimit", value);
            acrossLimit = value;
        } 
    }

    private float awayLimit = 90.00f;
    /// <summary>
    /// max aiming angle(deg) sideways away from body midline measured from chest forward that the character will try to point.  i.e. for rightHanded gun this is the angle right of the midline
    /// </summary>
    public float AwayLimit
    {
        get { return awayLimit; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 180.00f);
            SetArgument("awayLimit", value);
            awayLimit = value;
        } 
    }

    private float upLimit = 90.00f;
    /// <summary>
    /// max aiming angle(deg) upwards from body midline measured from chest forward that the character will try to point.
    /// </summary>
    public float UpLimit
    {
        get { return upLimit; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 180.00f);
            SetArgument("upLimit", value);
            upLimit = value;
        } 
    }

    private float downLimit = 45.00f;
    /// <summary>
    /// max aiming angle(deg) downwards from body midline measured from chest forward that the character will try to point
    /// </summary>
    public float DownLimit
    {
        get { return downLimit; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 180.00f);
            SetArgument("downLimit", value);
            downLimit = value;
        } 
    }

    private int rifleFall = 0;
    /// <summary>
    /// Pose the rifle hand to reduce complications with collisions. 0 = false, 1 = always when falling, 2 = when falling except if falling backwards
    /// </summary>
    public int RifleFall
    {
        get { return rifleFall; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("rifleFall", value);
            rifleFall = value;
        } 
    }

    private int fallingSupport = 1;
    /// <summary>
    /// Allow supporting of a rifle(or two handed pistol) when falling. 0 = false, 1 = support if allowed, 2 = support until constraint not active (don't allow support to restart), 3 = support until constraint not effective (support hand to support distance must be less than 0.15 - don't allow support to restart).
    /// </summary>
    public int FallingSupport
    {
        get { return fallingSupport; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 3);
            SetArgument("fallingSupport", value);
            fallingSupport = value;
        } 
    }

    private int fallingTypeSupport = 0;
    /// <summary>
    /// What is considered a fall by fallingSupport). Apply fallingSupport 0=never(will support if allowed), 1 = falling, 2 = falling except if falling backwards, 3 = falling and collided, 4 = falling and collided except if falling backwards, 5 = falling except if falling backwards until collided
    /// </summary>
    public int FallingTypeSupport
    {
        get { return fallingTypeSupport; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 5);
            SetArgument("fallingTypeSupport", value);
            fallingTypeSupport = value;
        } 
    }

    private int pistolNeutralType = 0;
    /// <summary>
    /// 0 = byFace, 1=acrossFront, 2=bySide.  NB: bySide is not connectible so be careful if combined with kPistol and oneHandedPointing = 0 or 2
    /// </summary>
    public int PistolNeutralType
    {
        get { return pistolNeutralType; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0, 2);
            SetArgument("pistolNeutralType", value);
            pistolNeutralType = value;
        } 
    }

    private bool neutralPoint4Pistols = false;
    /// <summary>
    /// NOT IMPLEMENTED YET KEEP=false - use pointing for neutral targets in pistol modes
    /// </summary>
    public bool NeutralPoint4Pistols
    {
        get { return neutralPoint4Pistols; } 
        set 
        {  
                
            SetArgument("neutralPoint4Pistols", value);
            neutralPoint4Pistols = value;
        } 
    }

    private bool neutralPoint4Rifle = true;
    /// <summary>
    /// use pointing for neutral targets in rifle mode
    /// </summary>
    public bool NeutralPoint4Rifle
    {
        get { return neutralPoint4Rifle; } 
        set 
        {  
                
            SetArgument("neutralPoint4Rifle", value);
            neutralPoint4Rifle = value;
        } 
    }

    private bool checkNeutralPoint = false;
    /// <summary>
    /// Check the neutral pointing is pointable, if it isn't then choose a neutral pose instead
    /// </summary>
    public bool CheckNeutralPoint
    {
        get { return checkNeutralPoint; } 
        set 
        {  
                
            SetArgument("checkNeutralPoint", value);
            checkNeutralPoint = value;
        } 
    }

    private Vector3 point2Side = new(5.00f,  -5.00f,  -2.00f);
    /// <summary>
    /// side, up, back) side is left for left arm, right for right arm mmmmtodo
    /// </summary>
    public Vector3 Point2Side
    {
        get { return point2Side; } 
        set 
        {  
                
            SetArgument("point2Side", value);
            point2Side = value;
        } 
    }

    private float add2WeaponDistSide = 0.30f;
    /// <summary>
    /// add to weaponDistance for point2Side neutral pointing (to straighten the arm)
    /// </summary>
    public float Add2WeaponDistSide
    {
        get { return add2WeaponDistSide; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1000.00f);
            SetArgument("add2WeaponDistSide", value);
            add2WeaponDistSide = value;
        } 
    }

    private Vector3 point2Connect = new(-1.00f,  -0.90f,  -0.20f);
    /// <summary>
    /// side, up, back) side is left for left arm, right for rght arm mmmmtodo
    /// </summary>
    public Vector3 Point2Connect
    {
        get { return point2Connect; } 
        set 
        {  
                
            SetArgument("point2Connect", value);
            point2Connect = value;
        } 
    }

    private float add2WeaponDistConnect = 0.00f;
    /// <summary>
    /// add to weaponDistance for point2Connect neutral pointing (to straighten the arm)
    /// </summary>
    public float Add2WeaponDistConnect
    {
        get { return add2WeaponDistConnect; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1000.00f);
            SetArgument("add2WeaponDistConnect", value);
            add2WeaponDistConnect = value;
        } 
    }

    private bool usePistolIK = true;
    /// <summary>
    /// enable new ik for pistol pointing.
    /// </summary>
    public bool UsePistolIK
    {
        get { return usePistolIK; } 
        set 
        {  
                
            SetArgument("usePistolIK", value);
            usePistolIK = value;
        } 
    }

    private bool useSpineTwist = true;
    /// <summary>
    /// Use spine twist to orient chest?
    /// </summary>
    public bool UseSpineTwist
    {
        get { return useSpineTwist; } 
        set 
        {  
                
            SetArgument("useSpineTwist", value);
            useSpineTwist = value;
        } 
    }

    private bool useTurnToTarget = false;
    /// <summary>
    /// Turn balancer to help gun point at target
    /// </summary>
    public bool UseTurnToTarget
    {
        get { return useTurnToTarget; } 
        set 
        {  
                
            SetArgument("useTurnToTarget", value);
            useTurnToTarget = value;
        } 
    }

    private bool useHeadLook = true;
    /// <summary>
    /// Use head look to drive head?
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

    private float errorThreshold = 0.39260f;
    /// <summary>
    /// angular difference between pointing direction and target direction above which feedback will be generated.
    /// </summary>
    public float ErrorThreshold
    {
        get { return errorThreshold; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 3.141590f);
            SetArgument("errorThreshold", value);
            errorThreshold = value;
        } 
    }

    private float fireWeaponRelaxTime = 0.40f;
    /// <summary>
    /// Duration of arms relax following firing weapon.  NB:This is clamped (0,5) in pointGun
    /// </summary>
    public float FireWeaponRelaxTime
    {
        get { return fireWeaponRelaxTime; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 5.00f);
            SetArgument("fireWeaponRelaxTime", value);
            fireWeaponRelaxTime = value;
        } 
    }

    private float fireWeaponRelaxAmount = 0.50f;
    /// <summary>
    /// Relax multiplier following firing weapon. Recovers over relaxTime.
    /// </summary>
    public float FireWeaponRelaxAmount
    {
        get { return fireWeaponRelaxAmount; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.10f, 1.00f);
            SetArgument("fireWeaponRelaxAmount", value);
            fireWeaponRelaxAmount = value;
        } 
    }

    private float fireWeaponRelaxDistance = 0.050f;
    /// <summary>
    /// Range of motion for ik-based recoil.
    /// </summary>
    public float FireWeaponRelaxDistance
    {
        get { return fireWeaponRelaxDistance; } 
        set 
        {  
            value = MathHelper.Clamp(value, 0.00f, 0.250f);
            SetArgument("fireWeaponRelaxDistance", value);
            fireWeaponRelaxDistance = value;
        } 
    }

    private bool useIncomingTransforms = true;
    /// <summary>
    /// Use the incoming transforms to inform the pointGun of the primaryWeaponDistance, poleVector for the arm
    /// </summary>
    public bool UseIncomingTransforms
    {
        get { return useIncomingTransforms; } 
        set 
        {  
                
            SetArgument("useIncomingTransforms", value);
            useIncomingTransforms = value;
        } 
    }

    private bool measureParentOffset = true;
    /// <summary>
    /// If useIncomingTransforms = true and measureParentOffset=true then measure the Pointing-from offset from parent effector, using itms - this should point the barrel of the gun to the target.  This is added to the rightHandParentOffset. NB NOT used if rightHandParentEffector LT 0
    /// </summary>
    public bool MeasureParentOffset
    {
        get { return measureParentOffset; } 
        set 
        {  
                
            SetArgument("measureParentOffset", value);
            measureParentOffset = value;
        } 
    }

    private Vector3 leftHandParentOffset = new(0f,  0f,  0f);
    /// <summary>
    /// Pointing-from offset from parent effector, expressed in spine3's frame, x = back/forward, y = right/left, z = up/down.
    /// </summary>
    public Vector3 LeftHandParentOffset
    {
        get { return leftHandParentOffset; } 
        set 
        {  
                
            SetArgument("leftHandParentOffset", value);
            leftHandParentOffset = value;
        } 
    }

    private int leftHandParentEffector = -1;
    /// <summary>
    /// 1 = Use leftShoulder. Effector from which the left hand pointing originates. ie, point from this part to the target. -1 causes default offset for active weapon mode to be applied.
    /// </summary>
    public int LeftHandParentEffector
    {
        get { return leftHandParentEffector; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1, 21);
            SetArgument("leftHandParentEffector", value);
            leftHandParentEffector = value;
        } 
    }

    private Vector3 rightHandParentOffset = new(0f,  0f,  0f);
    /// <summary>
    /// Pointing-from offset from parent effector, expressed in spine3's frame, x = back/forward, y = right/left, z = up/down. This is added to the measured one if useIncomingTransforms=true and measureParentOffset=true.  NB NOT used if rightHandParentEffector LT 0.  Pistol(0,0,0) Rifle(0.0032, 0.0, -0.0)
    /// </summary>
    public Vector3 RightHandParentOffset
    {
        get { return rightHandParentOffset; } 
        set 
        {  
                
            SetArgument("rightHandParentOffset", value);
            rightHandParentOffset = value;
        } 
    }

    private int rightHandParentEffector = -1;
    /// <summary>
    /// 1 = Use rightShoulder.. Effector from which the right hand pointing originates. ie, point from this part to the target. -1 causes default offset for active weapon mode to be applied.
    /// </summary>
    public int RightHandParentEffector
    {
        get { return rightHandParentEffector; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1, 21);
            SetArgument("rightHandParentEffector", value);
            rightHandParentEffector = value;
        } 
    }

    private float primaryHandWeaponDistance = -1.00f;
    /// <summary>
    /// Distance from the shoulder to hold the weapon. If -1 and useIncomingTransforms then weaponDistance is read from ITMs. weaponDistance=primaryHandWeaponDistance clamped [0.2f:m_maxArmReach=0.65] if useIncomingTransforms = false. pistol 0.60383, rifle 0.336
    /// </summary>
    public float PrimaryHandWeaponDistance
    {
        get { return primaryHandWeaponDistance; } 
        set 
        {  
            value = MathHelper.Clamp(value, -1.00f, 1.00f);
            SetArgument("primaryHandWeaponDistance", value);
            primaryHandWeaponDistance = value;
        } 
    }

    private bool constrainRifle = true;
    /// <summary>
    /// Use hard constraint to keep rifle stock against shoulder?
    /// </summary>
    public bool ConstrainRifle
    {
        get { return constrainRifle; } 
        set 
        {  
                
            SetArgument("constrainRifle", value);
            constrainRifle = value;
        } 
    }

    private float rifleConstraintMinDistance = 0.20f;
    /// <summary>
    /// Rifle constraint distance. Deliberately kept large to create a flat constraint surface where rifle meets the shoulder.
    /// </summary>
    public float RifleConstraintMinDistance
    {
        get { return rifleConstraintMinDistance; } 
        set 
        {  
                
            SetArgument("rifleConstraintMinDistance", value);
            rifleConstraintMinDistance = value;
        } 
    }

    private bool disableArmCollisions = false;
    /// <summary>
    /// Disable collisions between right hand/forearm and the torso/legs.
    /// </summary>
    public bool DisableArmCollisions
    {
        get { return disableArmCollisions; } 
        set 
        {  
                
            SetArgument("disableArmCollisions", value);
            disableArmCollisions = value;
        } 
    }

    private bool disableRifleCollisions = false;
    /// <summary>
    /// Disable collisions between right hand/forearm and spine3/spine2 if in rifle mode.
    /// </summary>
    public bool DisableRifleCollisions
    {
        get { return disableRifleCollisions; } 
        set 
        {  
                
            SetArgument("disableRifleCollisions", value);
            disableRifleCollisions = value;
        } 
    }


    public EuphoriaMessagePointGun(bool startNow) : base("pointGun", startNow)
    { }

    public new void Reset()
    {
        enableRight = true;
        enableLeft = true;
        leftHandTarget = new Vector3(0f,  0f,  0f);
        leftHandTargetIndex = -1;
        rightHandTarget = new Vector3(0f,  0f,  0f);
        rightHandTargetIndex = -1;
        leadTarget = 0.00f;
        armStiffness = 14.00f;
        armStiffnessDetSupport = 8.00f;
        armDamping = 1.00f;
        gravityOpposition = 1.00f;
        gravOppDetachedSupport = 0.50f;
        massMultDetachedSupport = 0.10f;
        allowShotLooseness = false;
        clavicleBlend = 0.00f;
        elbowAttitude = 0.30f;
        supportConstraint = 1;
        constraintMinDistance = 0.0150f;
        makeConstraintDistance = 0.10f;
        reduceConstraintLengthVel = 1.50f;
        breakingStrength = -1.00f;
        brokenSupportTime = 1.00f;
        brokenToSideProb = 0.50f;
        connectAfter = 0.70f;
        connectFor = 0.550f;
        oneHandedPointing = 1;
        alwaysSupport = false;
        poseUnusedGunArm = false;
        poseUnusedSupportArm = false;
        poseUnusedOtherArm = false;
        maxAngleAcross = 90.00f;
        maxAngleAway = 90.00f;
        fallingLimits = 0;
        acrossLimit = 90.00f;
        awayLimit = 90.00f;
        upLimit = 90.00f;
        downLimit = 45.00f;
        rifleFall = 0;
        fallingSupport = 1;
        fallingTypeSupport = 0;
        pistolNeutralType = 0;
        neutralPoint4Pistols = false;
        neutralPoint4Rifle = true;
        checkNeutralPoint = false;
        point2Side = new Vector3(5.00f,  -5.00f,  -2.00f);
        add2WeaponDistSide = 0.30f;
        point2Connect = new Vector3(-1.00f,  -0.90f,  -0.20f);
        add2WeaponDistConnect = 0.00f;
        usePistolIK = true;
        useSpineTwist = true;
        useTurnToTarget = false;
        useHeadLook = true;
        errorThreshold = 0.39260f;
        fireWeaponRelaxTime = 0.40f;
        fireWeaponRelaxAmount = 0.50f;
        fireWeaponRelaxDistance = 0.050f;
        useIncomingTransforms = true;
        measureParentOffset = true;
        leftHandParentOffset = new Vector3(0f,  0f,  0f);
        leftHandParentEffector = -1;
        rightHandParentOffset = new Vector3(0f,  0f,  0f);
        rightHandParentEffector = -1;
        primaryHandWeaponDistance = -1.00f;
        constrainRifle = true;
        rifleConstraintMinDistance = 0.20f;
        disableArmCollisions = false;
        disableRifleCollisions = false;
        base.Reset();
    }
}
}
