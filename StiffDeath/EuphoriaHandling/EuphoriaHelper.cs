using static BetterHitReactions.EntryPoint;

namespace BetterHitReactions.EuphoriaHandling;

internal class EuphoriaHelper
{
    private static void MakePedDropWeapon(Ped ped)
    {
        var dropWeapon = Settings.DoesPedDropWeapon && (int)GenerateChance() <= Settings.Chance;
        if (!dropWeapon || !ped.Exists() || !ped.IsAlive ||
            !NativeFunction.Natives.x475768A975D5AD17<bool>(ped, 1 | 2 | 4)) return; // IS_PED_ARMED
        Game.LogTrivial("Making ped drop weapon...");
        NativeFunction.Natives.x6B7513D9966FBEC0(ped); // SET_PED_DROPS_WEAPON
    }

    internal static void MakePedRagdoll(Ped ped, int minTime, int maxTime, int ragdollType) {
        Vector3 dir = new Vector3(ped.Velocity.X,
            ped.Velocity.Y + (ped.Speed + 1.5f), ped.Velocity.Z);
        NativeFunction.Natives.SET_PED_TO_RAGDOLL_WITH_FALL(ped, minTime, maxTime, 0, dir,
            World.GetGroundZ(ped.Position, true, false), Vector3.Zero, Vector3.Zero);
    }

    internal static void ApplyTazerEuphoria(Ped ped)
    {
        try
        {
            // Make the ped drop their weapon when stunned
            MakePedDropWeapon(ped);

            // Create the electrocute euphoria message
            EuphoriaMessageElectrocute euphoriaMessageElectrocute = new(true)
            {
                LeftArm = false,
                RightArm = false,
                LeftLeg = false,
                RightLeg = false,
                Spine = false,
                Neck = false,
                ApplyStiffness = true,
                StunMag = 1.0f // Adjust the stun magnitude based on desired effect strength
            };
            
            // Get the velocity and apply force based on that
            var velocity = ped.Velocity;
            var force = velocity * 10f;

            // Create the windmill animation
            EuphoriaMessageArmsWindmill windmill = new(true);

            // Send initial euphoria effects
            windmill.SendTo(ped);
            euphoriaMessageElectrocute.SendTo(ped);

            // Optionally, adjust force over time to simulate ongoing stun effect
            for (int i = 0; i < 4; i++) // Applying weaker force after initial bursts
            {
                var reducedForce = force * 0.75f; // Reduce force over time
                ped.ApplyForce(reducedForce, velocity, false, true);
                windmill.SendTo(ped);
                euphoriaMessageElectrocute.SendTo(ped);
                GameFiber.Wait(500); // Longer wait between weaker bursts
            }
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
            float stiffnessReduction = 1.0f; // Start with max stiffness
            for (int i = 0; i < 10; i++) // Loop to gradually reduce stiffness
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
                ped.Kill();
            }

            // Check if the ped is dead after the collapse force and then ragdoll them if they are
            if (ped.IsDead)
            {
                // Trigger the ragdoll effect for the dead ped
                ped.IsRagdoll = true; // Make the ped ragdoll, allowing it to fall to the ground
            }
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
            // Make the ped stagger first to simulate the loss of balance
            var velocity = ped.Velocity;
            var force = velocity * 5f; // Moderate force to make them stumble
        
            // Apply force to simulate the stumble
            ped.ApplyForce(force, velocity, false, true);

            // Wait a brief moment for the stumble animation to take effect
            GameFiber.Wait(200);

            // Now apply the shot euphoria with the ReachForWound parameter to simulate the ped reaching for the neck
            EuphoriaMessageShot shotMessage = new(true)
            {
                ReachForWound = true, // This makes the ped grab their neck wound
            };

            shotMessage.SendTo(ped); // Send the message to trigger the reaction

            // Optionally, apply more force for more staggering
            ped.ApplyForce(force, velocity, false, true);

            // Wait for a brief period to allow the reaction to play out
            GameFiber.Wait(1500);
            shotMessage.ReachForWound = false;
            shotMessage.SendTo(ped);
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
                BodyStiffness = 0.2f,
                ArmStiffness = 0.15f,
                NeckStiffness = 0.1f,
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
            var shot = new EuphoriaMessageShot(true)
            {
                ReachForWound = true,
                BodyStiffness = 0.0f,
                ArmStiffness = 0.0f,
                NeckStiffness = 0.0f,
            };

            shot.SendTo(ped);

            // Optional: add a stumble message to make it more dramatic
            var stumble = new EuphoriaMessageBodyBalance(startNow: true)
            {
                SpineStiffness = 0.1f,
                UseHeadLook = false,
                MinBraceTime = 300, // how long before they collapse fully
            };

            stumble.SendTo(ped);
        }
        catch (Exception ex)
        {
            Game.DisplayNotification("~r~Leg Euphoria Error:~s~ " + ex.Message);
        }
    }

    internal static void ApplyArmEuphoria(Ped ped)
    {
        try
        {
            MakePedDropWeapon(ped);

            var shot = new EuphoriaMessageShot(true)
            {
                ReachForWound = true,
                BodyStiffness = 0.0f,
                ArmStiffness = 2.0f,
                NeckStiffness = 0.0f,
            };

            shot.SendTo(ped);
        }
        catch (Exception ex)
        {
            Game.DisplayNotification("~r~Arm Euphoria Error:~s~ " + ex.Message);
        }
    }
}
// TODO OBSOLETE?