using static BetterHitReactions.EntryPoint;

namespace BetterHitReactions.EuphoriaHandling;

internal class EuphoriaHelper
{
    private static void MakePedDropWeapon(Ped ped)
    {
        var dropWeapon = Settings.DoesPedDropWeapon && (int)EntryPoint.GenerateChance() <= Settings.Chance;
        if (!dropWeapon || !ped.Exists() || !ped.IsAlive ||
            !NativeFunction.Natives.x475768A975D5AD17<bool>(ped, 1 | 2 | 4)) return; // IS_PED_ARMED
        Game.LogTrivial("Making ped drop weapon...");
        NativeFunction.Natives.x6B7513D9966FBEC0(ped); // SET_PED_DROPS_WEAPON
    }

    internal static void MakePedRagdoll(Ped ped, int minTime, int maxTime)
    {
        Vector3 dir = new Vector3(ped.Velocity.X,
            ped.Velocity.Y + (ped.Speed + 1.5f), ped.Velocity.Z);
        NativeFunction.Natives.SET_PED_TO_RAGDOLL_WITH_FALL(ped, minTime, maxTime, 0, dir,
            World.GetGroundZ(ped.Position, true, false), Vector3.Zero, Vector3.Zero);
    }

    internal static void ApplyTazerEuphoria(Ped ped, EuphoriaMessageShot euphoriaMessage)
    {
        try
        {
            euphoriaMessage ??= new EuphoriaMessageShot();
            MakePedDropWeapon(ped);
            MakePedRagdoll(ped, 5500, 6500);
            euphoriaMessage.ArmStiffness = 16f;
            euphoriaMessage.BodyStiffness = 16f;
            euphoriaMessage.KMult4Legs = 0.6f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.ArmStiffness = 14f;
            euphoriaMessage.BodyStiffness = 14f;
            euphoriaMessage.KMult4Legs = 0.4f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.ArmStiffness = 12f;
            euphoriaMessage.BodyStiffness = 12f;
            euphoriaMessage.KMult4Legs = 0.2f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.ArmStiffness = 10f;
            euphoriaMessage.BodyStiffness = 10f;
            euphoriaMessage.KMult4Legs = 0f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.ArmStiffness = 0f;
            euphoriaMessage.BodyStiffness = 0f;
            euphoriaMessage.KMult4Legs = 0f;
            euphoriaMessage.SendTo(ped);
        }
        catch (Exception e)
        {
            Error(e);
        }
    }

    // Specific Bone IDs
    internal static void ApplyHeadshotEuphoria(Ped ped, EuphoriaMessageShot euphoriaMessage)
    {
        try
        {
            if (euphoriaMessage is null)
            {
                euphoriaMessage = new EuphoriaMessageShot();
            }

            euphoriaMessage.KMult4Legs = 1f;
            euphoriaMessage.BodyStiffness = 16f;
            euphoriaMessage.ArmStiffness = 16f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.BodyStiffness = 15f;
            euphoriaMessage.ArmStiffness = 15f;
            euphoriaMessage.KMult4Legs = 0.9f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.BodyStiffness = 14f;
            euphoriaMessage.ArmStiffness = 14f;
            euphoriaMessage.KMult4Legs = 0.8f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.BodyStiffness = 13f;
            euphoriaMessage.ArmStiffness = 13f;
            euphoriaMessage.KMult4Legs = 0.7f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.BodyStiffness = 12f;
            euphoriaMessage.BodyStiffness = 12f;
            euphoriaMessage.KMult4Legs = 0.6f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.BodyStiffness = 10f;
            euphoriaMessage.ArmStiffness = 10f;
            euphoriaMessage.KMult4Legs = 0.4f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.BodyStiffness = 9f;
            euphoriaMessage.ArmStiffness = 9f;
            euphoriaMessage.KMult4Legs = 0.3f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.BodyStiffness = 5f;
            euphoriaMessage.ArmStiffness = 5f;
            euphoriaMessage.KMult4Legs = 0.1f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.ArmStiffness = 0f;
            euphoriaMessage.BodyStiffness = 0f;
            euphoriaMessage.KMult4Legs = 0f;
            euphoriaMessage.SendTo(ped);
        }
        catch (Exception e)
        {
            Error(e);
        }

    }

    internal static void ApplyNeckEuphoria(Ped ped, EuphoriaMessageShot euphoriaMessage)
    {
        try
        {
            if (euphoriaMessage is null)
            {
                euphoriaMessage = new EuphoriaMessageShot();
            }

            euphoriaMessage.KMult4Legs = 1f;
            euphoriaMessage.CStrUpperMax += 50f;
            euphoriaMessage.CStrUpperMin += 50f;
            euphoriaMessage.UseExtendedCatchFall = true;
            euphoriaMessage.ExagDuration = 2500f;
            euphoriaMessage.TimeBeforeReachForWound = 0f;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.Fling = false;
            euphoriaMessage.DeathTime = 1000f;
            euphoriaMessage.FallingReaction = 1;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 0.9f;
            euphoriaMessage.UseExtendedCatchFall = true;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.Fling = false;
            euphoriaMessage.CStrUpperMax += 50f;
            euphoriaMessage.CStrUpperMin += 50f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 0.8f;
            euphoriaMessage.UseExtendedCatchFall = true;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.Fling = false;
            euphoriaMessage.CStrUpperMax += 50f;
            euphoriaMessage.CStrUpperMin += 50f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 0.7f;
            euphoriaMessage.UseExtendedCatchFall = true;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.Fling = false;
            euphoriaMessage.CStrUpperMax += 50f;
            euphoriaMessage.CStrUpperMin += 50f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 0.5f;
            euphoriaMessage.UseExtendedCatchFall = true;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.Fling = false;
            euphoriaMessage.CStrUpperMax += 50f;
            euphoriaMessage.CStrUpperMin += 50f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 0.4f;
            euphoriaMessage.UseExtendedCatchFall = true;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.Fling = false;
            euphoriaMessage.CStrUpperMax += 50f;
            euphoriaMessage.CStrUpperMin += 50f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 0.3f;
            euphoriaMessage.UseExtendedCatchFall = true;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.Fling = false;
            euphoriaMessage.CStrUpperMax += 50f;
            euphoriaMessage.CStrUpperMin += 50f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 0.2f;
            euphoriaMessage.UseExtendedCatchFall = true;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.Fling = false;
            euphoriaMessage.CStrUpperMax += 50f;
            euphoriaMessage.CStrUpperMin += 50f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 0f;
            euphoriaMessage.UseExtendedCatchFall = true;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.Fling = false;
            euphoriaMessage.CStrUpperMax += 50f;
            euphoriaMessage.CStrUpperMin += 50f;
            euphoriaMessage.SendTo(ped);
        }
        catch (Exception e)
        {
            Error(e);
        }

    }

    internal static void ApplyPelvisEuphoria(Ped ped, EuphoriaMessageShot euphoriaMessage)
    {
        try
        {
            euphoriaMessage ??= new EuphoriaMessageShot();

            euphoriaMessage.Fling = false;
            euphoriaMessage.FallingReaction = 1;
            euphoriaMessage.BodyStiffness = 16f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.BodyStiffness = 15f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.BodyStiffness = 14f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.SendTo(ped);
            euphoriaMessage.BodyStiffness = 10f;
            GameFiber.Wait(250);

            euphoriaMessage.BodyStiffness = 8f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.BodyStiffness = 2f;
            euphoriaMessage.SendTo(ped);
        }
        catch (Exception e)
        {
            Error(e);
        }

    }

    // Body Regions
    internal static void ApplyTorsoEuphoria(Ped ped, EuphoriaMessageShot euphoriaMessage)
    {
        try
        {
            euphoriaMessage ??= new EuphoriaMessageShot();

            euphoriaMessage.UseExtendedCatchFall = true;
            euphoriaMessage.Fling = false;
            euphoriaMessage.BodyStiffness = 16f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.BodyStiffness = 15f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.BodyStiffness = 14f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.BodyStiffness = 13f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.BodyStiffness = 12f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(250);

            euphoriaMessage.BodyStiffness = 11f;
            euphoriaMessage.SendTo(ped);
        }
        catch (Exception e)
        {
            Error(e);
        }

    }

    internal static void ApplyLegEuphoria(Ped ped, EuphoriaMessageShot euphoriaMessage)
    {
        try
        {
            euphoriaMessage ??= new EuphoriaMessageShot();

            euphoriaMessage.FallingReaction = 3;
            euphoriaMessage.Fling = false;
            euphoriaMessage.LoosenessAmount = 0f;
            euphoriaMessage.KMult4Legs = 16f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 14f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 13f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 12f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 10f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 9f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 8f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 7f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 6f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 5f;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.KMult4Legs = 2f;
            euphoriaMessage.SendTo(ped);
        }
        catch (Exception e)
        {
            Error(e);
        }
    }

    internal static void ApplyArmEuphoria(Ped ped, EuphoriaMessageShot euphoriaMessage)
    {
        try
        {
            if (euphoriaMessage is null)
            {
                euphoriaMessage = new EuphoriaMessageShot();
            }

            MakePedDropWeapon(ped);
            euphoriaMessage.ArmStiffness = 16f;
            euphoriaMessage.TimeBeforeReachForWound = 0f;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.ArmStiffness = 14f;
            euphoriaMessage.TimeBeforeReachForWound = 0f;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.SendTo(ped);
            GameFiber.Wait(150);

            euphoriaMessage.TimeBeforeReachForWound = 0f;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.SendTo(ped);
            euphoriaMessage.ArmStiffness = 12f;
            GameFiber.Wait(150);

            euphoriaMessage.TimeBeforeReachForWound = 0f;
            euphoriaMessage.ReachForWound = true;
            euphoriaMessage.SendTo(ped);
            euphoriaMessage.ArmStiffness = 10f;
            GameFiber.Wait(150);

            euphoriaMessage.ArmStiffness = 0f;
            euphoriaMessage.ReachForWound = false;
            euphoriaMessage.SendTo(ped);
        }
        catch (Exception e)
        {
            Error(e);
        }
    }
}