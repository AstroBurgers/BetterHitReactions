using BetterHitReactions.EuphoriaHandling.EuphoriaMessages;
using static BetterHitReactions.EntryPoint;
using static BetterHitReactions.RandomHelper;
using EuphoriaMessageShot = BetterHitReactions.EuphoriaHandling.EuphoriaMessages.EuphoriaMessageShot;

namespace BetterHitReactions.EuphoriaHandling;

internal static class EuphoriaHelper
{
    private static void MakePedDropWeapon(Ped ped)
    {
        var dropWeapon = Settings.DoesPedDropWeapon && (int)GenerateChance() <= Settings.Chance;
        if (!dropWeapon || !ped.Exists() || !ped.IsAlive ||
            !NativeFunction.Natives.x475768A975D5AD17<bool>(ped, 1 | 2 | 4)) return; // IS_PED_ARMED
        Game.LogTrivial("Making ped drop weapon...");
        NativeFunction.Natives.x6B7513D9966FBEC0(ped); // SET_PED_DROPS_WEAPON
    }

    internal static bool IsValidPed(Ped ped) =>
        ped != null && ped.Exists();

    internal static void MakePedRagdoll(Ped ped, int minTime, int maxTime, int ragdollType) {
        var dir = new Vector3(ped.Velocity.X,
            ped.Velocity.Y + (ped.Speed + 1.5f), ped.Velocity.Z);
        NativeFunction.Natives.SET_PED_TO_RAGDOLL_WITH_FALL(ped, minTime, maxTime, 0, dir,
            World.GetGroundZ(ped.Position, true, false), Vector3.Zero, Vector3.Zero);
    }

    internal static void ApplyTazerEuphoria(Ped ped)
    {
        try
        {
            // First, check if the headshot damage has killed the ped
            //if (ped.IsDead) return; // If the ped is already dead, stop processing

            var stop = new EuphoriaMessageStopAllBehaviours(startNow: true);
            stop.SendTo(ped);
            // Apply instant stiffness when the headshot occurs
            var stiffness = 1f;
            EuphoriaMessageElectrocute euphoriaMessageElectrocute = new(true)
            {
                LeftArm = false,
                RightArm = false,
                LeftLeg = false,
                RightLeg = false,
                Spine = false,
                Neck = false,
                ApplyStiffness = true,
                StunMag = stiffness // Maximum stiffness for the initial effect
            };
            
            // Apply stiffness immediately
            euphoriaMessageElectrocute.SendTo(ped);

            // Stiffening time - keep the ped in a stiffened state for a brief moment
            GameFiber.Wait(450); // 0.45 seconds for the stiffening effect to kick in

            // Gradually reduce stiffness and start the slumping effect
            var stiffnessReduction = stiffness; // Start with max stiffness
            for (var i = 0; i < 10; i++) // Loop to gradually reduce stiffness
            {
                if (!IsValidPed(ped))
                    break;
                stiffnessReduction -= 0.1f; // Reduce stiffness by 10% each iteration
                if (stiffnessReduction <= 0)
                    stiffnessReduction = 0;

                // Apply gradual stiffness reduction
                euphoriaMessageElectrocute.StunMag = stiffnessReduction;
                euphoriaMessageElectrocute.SendTo(ped);

                // Apply a small force to simulate the ped losing control and slumping
                var velocity = ped.Velocity;
                var force = velocity * 5f; // Apply less force to simulate a slow slump
                ped.ApplyForce(force, velocity, false, true);

                // Wait a little before applying the next stiffness reduction
                GameFiber.Wait(250); // Adjust the wait time as necessary to control the slump speed

                // Check if the ped is dead after each iteration
            }
            euphoriaMessageElectrocute.StunMag = 0;
            euphoriaMessageElectrocute.SendTo(ped);
        }
        catch (Exception e)
        {
            // Log any errors
            Error(e);
        }
    }

    // Specific Bone IDs
    internal static void ApplyHeadshotEuphoria(Ped ped)
    {
        try
        {
            // First, check if the headshot damage has killed the ped
            //if (ped.IsDead) return; // If the ped is already dead, stop processing

            // Apply instant stiffness when the headshot occurs
            EuphoriaMessageElectrocute euphoriaMessageElectrocute = new(true)
            {
                LeftArm = false,
                RightArm = false,
                LeftLeg = false,
                RightLeg = false,
                Spine = false,
                Neck = false,
                ApplyStiffness = true,
                StunMag = 1.0f // Maximum stiffness for the initial effect
            };

            // Apply stiffness immediately
            euphoriaMessageElectrocute.SendTo(ped);

            // Stiffening time - keep the ped in a stiffened state for a brief moment
            GameFiber.Wait(500); // 0.5 seconds for the stiffening effect to kick in

            // Gradually reduce stiffness and start the slumping effect
            var stiffnessReduction = 1.0f; // Start with max stiffness
            for (var i = 0; i < 10; i++) // Loop to gradually reduce stiffness
            {
                stiffnessReduction -= 0.1f; // Reduce stiffness by 10% each iteration
                if (stiffnessReduction <= 0)
                    stiffnessReduction = 0;

                // Apply gradual stiffness reduction
                euphoriaMessageElectrocute.StunMag = stiffnessReduction;
                euphoriaMessageElectrocute.SendTo(ped);

                // Apply a small force to simulate the ped losing control and slumping
                var velocity = ped.Velocity;
                var force = velocity * 5f; // Apply less force to simulate a slow slump
                ped.ApplyForce(force, velocity, false, true);

                // Wait a little before applying the next stiffness reduction
                GameFiber.Wait(500); // Adjust the wait time as necessary to control the slump speed

                // Check if the ped is dead after each iteration
                if (ped.IsDead) break; // Stop if the ped has died during the reaction
            }

            // If the ped is not dead after stiffness is reduced, apply death force to simulate collapse
            if (!ped.IsDead)
            {
                euphoriaMessageElectrocute.StunMag = 0;
                euphoriaMessageElectrocute.SendTo(ped);

                // Apply force to make the ped collapse or fall
                var collapseForce = new Vector3(0, 0, -5f); // Apply downward force to simulate collapse
                ped.ApplyForce(collapseForce, Vector3.Zero, false, true);
                if (IsValidPed(ped)) ped.Kill();
            }

            // Check if the ped is dead after the collapse force and then ragdoll them if they are
            if (ped.IsDead)
            {
                // Trigger the ragdoll effect for the dead ped
                ped.IsRagdoll = true; // Make the ped ragdoll, allowing it to fall to the ground
            }
            if (IsValidPed(ped)) ped.Kill();
        }
        catch (Exception e)
        {
            // Log any errors
            Error(e);
        }
    }



    internal static void ApplyNeckEuphoria(Ped ped)
    {
        try
        {
            // 1. Trigger a staggered fall reaction to simulate stumbling
            var staggerFall = new EuphoriaMessageStaggerFall(true)
            {
                AlwaysBendForwards = true,
                ArmDamping = 0.2f,
                ArmDampingStart = 0.1f,
                ArmStiffness = 0.3f,
                ArmStiffnessStart = 0.4f,
                HeadLookAtVelProb = 0.5f,
                HeadLookPos = ped.Position + ped.ForwardVector * 2f,
                HipBendMult = 0.4f,
                Lean2multB = 0.3f
            };

            var shotMessage = new EuphoriaMessageShot(true)
            {
                ReachForWound = true,
                DeathTime = 2500,
                TimeBeforeReachForWound = 0f
            };
            
            staggerFall.SendTo(ped);
            GameFiber.Wait(200);
            shotMessage.SendTo(ped);
            GameFiber.Wait(3000);

            // 5. Collapse and die
            if (IsValidPed(ped)) ped.Kill();
        }
        catch (Exception e)
        {
            Error(e);
        }
    }



    internal static void ApplyTorsoEuphoria(Ped ped)
    {
        try
        {
            var shot = new EuphoriaMessageShot(true)
            {
                ReachForWound = true,
                BodyStiffness = GetRandomFloat(0.1f, 0.4f),
                ArmStiffness = GetRandomFloat(0.1f, 0.4f),
                NeckStiffness = GetRandomFloat(0.1f, 0.4f),
            };

            shot.SendTo(ped);
        }
        catch (Exception ex)
        {
            Game.DisplayNotification("~r~Body Euphoria Error:~s~ " + ex.Message);
        }
    }


    internal static void ApplyLegEuphoria(Ped ped)
    {
        try
        {
            EuphoriaMessageCatchFall catchFall = new(true)
            {
                ArmsStiffness = GetRandomFloat(0.1f, 1f),
                ForwardMaxArmOffset = GetRandomFloat(0f, 0.3f),
                BackwardsMinArmOffset = GetRandomFloat(-3f, 0f),
                ExtraSit = GetRandomFloat(0f, 1f),
                LegsStiffness = GetRandomFloat(0.6f, 2f),
            };

            catchFall.SendTo(ped);
        }
        catch (Exception ex)
        {
            Game.DisplayNotification("~r~Leg Euphoria Error:~s~ " + ex.Message);
        }
    }

    internal static void ApplyArmEuphoria(Ped ped, PedDamageInfo damageInfo)
    {
        try
        {
            if (damageInfo.BoneInfo.Limb == Limb.RightArm)
            {
                MakePedDropWeapon(ped);
            }

            var shot = new EuphoriaMessageShot(true)
            {
                ReachForWound = true,
                ArmStiffness = 2.0f,
            };

            shot.SendTo(ped);
        }
        catch (Exception ex)
        {
            Game.DisplayNotification("~r~Arm Euphoria Error:~s~ " + ex.Message);
        }
    }
}