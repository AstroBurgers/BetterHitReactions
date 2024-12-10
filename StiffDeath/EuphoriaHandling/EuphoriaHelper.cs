using System.Threading;
using static BetterHitReactions.EntryPoint;

namespace BetterHitReactions.EuphoriaHandling;

internal class EuphoriaHelper
{
    internal static void SendNmMessage(Ped ped, string msg)
    {
        if (!ped.Exists())
        {
            Game.LogTrivial("BetterHitReactions - Ped was invalid...");
            return;
        }
        EuphoriaMessage euphoriaMessage = new(msg, true);
        euphoriaMessage.SendTo(ped);
    }

    internal static void SetAndSendNmMessage(Ped ped, string msg, object value)
    {
        if (!ped.Exists())
        {
            Game.LogTrivial("BetterHitReactions - Ped was invalid...");
            return;
        }
        EuphoriaMessage euphoriaMessage = new(msg, true);
        euphoriaMessage.SetArgument(msg, value);
        euphoriaMessage.SendTo(ped);
    }
    
    internal static void SendEuphoriaMessage(Ped pedToAffect,float armStiffness = 0f, float bodyStiffness = 0f, float kMult4Legs = 0f,
        float cStrUpperMax = 0f, float cStrUpperMin = 0f, bool useExtendedCatchFall = false, float exagDuration = 0f,
        float timeBeforeReachForWound = 0f, bool reachForWound = false, bool fling = false, float deathTime = 0f, int fallingReaction = 1, float loosenessAmount = 0f)
    {
        if (!pedToAffect.Exists())
        {
            Game.LogTrivial("BetterHitReactions - Ped was invalid...");
            return;
        }
        EuphoriaMessageShot euphoriaMessage = new()
        {
            ArmStiffness = armStiffness,
            BodyStiffness = bodyStiffness,
            KMult4Legs = kMult4Legs,
            CStrUpperMax = cStrUpperMax,
            CStrUpperMin = cStrUpperMin,
            UseExtendedCatchFall = useExtendedCatchFall,
            ExagDuration = exagDuration,
            TimeBeforeReachForWound = timeBeforeReachForWound,
            ReachForWound = reachForWound,
            Fling = fling,
            DeathTime = deathTime,
            FallingReaction = fallingReaction,
            LoosenessAmount = loosenessAmount,
            
        };
        euphoriaMessage.SendTo(pedToAffect);
    }

    private static void MakePedDropWeapon(Ped ped)
    {
        var dropWeapon = Settings.DoesPedDropWeapon && (int)GenerateChance() <= Settings.Chance;
        if (!dropWeapon || !ped.Exists() || !ped.IsAlive ||
            !NativeFunction.Natives.x475768A975D5AD17<bool>(ped, 1 | 2 | 4)) return; // IS_PED_ARMED
        Game.LogTrivial("Making ped drop weapon...");
        NativeFunction.Natives.x6B7513D9966FBEC0(ped); // SET_PED_DROPS_WEAPON
    }

    internal static void MakePedRagdoll(Ped ped, int minTime, int maxTime)
    {
        Vector3 dir = new(ped.Velocity.X,
            ped.Velocity.Y + (ped.Speed + 1.5f), ped.Velocity.Z);
        NativeFunction.Natives.SET_PED_TO_RAGDOLL_WITH_FALL(ped, minTime, maxTime, 0, dir,
            World.GetGroundZ(ped.Position, true, false), Vector3.Zero, Vector3.Zero);
    }

    internal static void ApplyTazerEuphoria(Ped ped)
    {
        try
        {
            MakePedDropWeapon(ped);
            MakePedRagdoll(ped, 5500, 6500);
            SendEuphoriaMessage(ped, armStiffness:16f, bodyStiffness:16f, kMult4Legs:0.6f);
            GameFiber.Wait(250);
            
            SendEuphoriaMessage(ped, armStiffness:14f, bodyStiffness:14f, kMult4Legs:0.4f);
            GameFiber.Wait(250);
            
            SendEuphoriaMessage(ped, armStiffness:12f, bodyStiffness:12f, kMult4Legs:0.2f);
            GameFiber.Wait(250);

            SendEuphoriaMessage(ped, armStiffness:10f, bodyStiffness:10f);
            GameFiber.Wait(250);

            SendEuphoriaMessage(ped);
        }
        catch (Exception e)
        {
            Error(e);
        }
    }

    // Specific Bone IDs
    internal static void ApplyHeadshotEuphoria(Ped ped)
    {
        try
        {
            SendNmMessage(ped, "NM_WINDMILL_MSG");
            SetAndSendNmMessage(ped, "NM_ROLLUP_STIFFNESS", 16f);
            SendEuphoriaMessage(ped, armStiffness:16f, bodyStiffness:16f, kMult4Legs:1f);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, armStiffness:15f, bodyStiffness:15f, kMult4Legs:0.9f);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, armStiffness:14f, bodyStiffness:14f, kMult4Legs:0.8f);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, armStiffness:13f, bodyStiffness:13f, kMult4Legs:0.7f);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, armStiffness:12f, bodyStiffness:12f, kMult4Legs:0.6f);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, armStiffness:10f, bodyStiffness:10f, kMult4Legs:0.4f);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, armStiffness:9f, bodyStiffness:9f, kMult4Legs:0.3f);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, armStiffness:5f, bodyStiffness:5f, kMult4Legs:0.1f);
            GameFiber.Wait(150);

            SendEuphoriaMessage(ped);
        }
        catch (Exception e)
        {
            Error(e);
        }

    }

    internal static void ApplyNeckEuphoria(Ped ped)
    {
        try
        {
            SendNmMessage(ped, "NM_CATCHFALL_MSG");
            SendEuphoriaMessage(ped, kMult4Legs: 1f, cStrUpperMax: 50f, cStrUpperMin: 50f, useExtendedCatchFall: true,
                exagDuration: 2500f, timeBeforeReachForWound: 0f, reachForWound: true, fling: false, deathTime: 1000f,
                fallingReaction: 1);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, kMult4Legs: 0.9f, cStrUpperMax: 50f, cStrUpperMin: 50f, useExtendedCatchFall: true,
                reachForWound: true, fling: false);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, kMult4Legs: 0.8f, cStrUpperMax: 50f, cStrUpperMin: 50f, useExtendedCatchFall: true,
                reachForWound: true, fling: false);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, kMult4Legs: 0.7f, cStrUpperMax: 50f, cStrUpperMin: 50f, useExtendedCatchFall: true,
                reachForWound: true, fling: false);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, kMult4Legs: 0.5f, cStrUpperMax: 50f, cStrUpperMin: 50f, useExtendedCatchFall: true,
                reachForWound: true, fling: false);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, kMult4Legs: 0.4f, cStrUpperMax: 50f, cStrUpperMin: 50f, useExtendedCatchFall: true,
                reachForWound: true, fling: false);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, kMult4Legs: 0.3f, cStrUpperMax: 50f, cStrUpperMin: 50f, useExtendedCatchFall: true,
                reachForWound: true, fling: false);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, kMult4Legs: 0.2f, cStrUpperMax: 50f, cStrUpperMin: 50f, useExtendedCatchFall: true,
                reachForWound: true, fling: false);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped);
        }
        catch (Exception e)
        {
            Error(e);
        }

    }

    internal static void ApplyPelvisEuphoria(Ped ped)
    {
        try
        {

            SendEuphoriaMessage(ped, bodyStiffness:16f, fallingReaction:1);
            GameFiber.Wait(250);

            SendEuphoriaMessage(ped, bodyStiffness:15f);
            GameFiber.Wait(250);

            SendEuphoriaMessage(ped, bodyStiffness:14f);
            GameFiber.Wait(250);

            SendEuphoriaMessage(ped, bodyStiffness:10f);
            GameFiber.Wait(250);

            SendEuphoriaMessage(ped, bodyStiffness:8f);
            GameFiber.Wait(250);
            
            SendEuphoriaMessage(ped, bodyStiffness:2f);
        }
        catch (Exception e)
        {
            Error(e);
        }

    }

    // Body Regions
    internal static void ApplyTorsoEuphoria(Ped ped)
    {
        try
        {
            SendEuphoriaMessage(ped, useExtendedCatchFall:true, fling:false, bodyStiffness:16f);
            GameFiber.Wait(250);
            
            SendEuphoriaMessage(ped, bodyStiffness:15f);
            GameFiber.Wait(250);
            
            SendEuphoriaMessage(ped, bodyStiffness:14f);
            GameFiber.Wait(250);
            
            SendEuphoriaMessage(ped, bodyStiffness:13f);
            GameFiber.Wait(250);
            
            SendEuphoriaMessage(ped, bodyStiffness:12f);
            GameFiber.Wait(250);

            SendEuphoriaMessage(ped, bodyStiffness:11f);
        }
        catch (Exception e)
        {
            Error(e);
        }

    }

    internal static void ApplyLegEuphoria(Ped ped)
    {
        try
        {
            
            SendEuphoriaMessage(ped, kMult4Legs:16f, loosenessAmount:0f, fling:false, fallingReaction:3);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, kMult4Legs:14f);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, kMult4Legs:13f);
            GameFiber.Wait(150);

            SendEuphoriaMessage(ped, kMult4Legs:12f);
            GameFiber.Wait(150);

            SendEuphoriaMessage(ped, kMult4Legs:10f);
            GameFiber.Wait(150);

            SendEuphoriaMessage(ped, kMult4Legs:9f);
            GameFiber.Wait(150);

            SendEuphoriaMessage(ped, kMult4Legs:8f);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped, kMult4Legs:7f);
            GameFiber.Wait(150);

            SendEuphoriaMessage(ped, kMult4Legs:6f);
            GameFiber.Wait(150);

            SendEuphoriaMessage(ped, kMult4Legs:5f);
            GameFiber.Wait(150);

            SendEuphoriaMessage(ped, kMult4Legs:2f);
        }
        catch (Exception e)
        {
            Error(e);
        }
    }

    internal static void ApplyArmEuphoria(Ped ped)
    {
        try
        {
            MakePedDropWeapon(ped);
            SendEuphoriaMessage(ped, armStiffness: 16f, timeBeforeReachForWound: 0f, reachForWound: true);
            GameFiber.Wait(150);

            SendEuphoriaMessage(ped, armStiffness: 14f, timeBeforeReachForWound: 0f, reachForWound: true);
            GameFiber.Wait(150);

            SendEuphoriaMessage(ped, armStiffness: 12f, timeBeforeReachForWound: 0f, reachForWound: true);
            GameFiber.Wait(150);

            SendEuphoriaMessage(ped, armStiffness: 10f, timeBeforeReachForWound: 0f, reachForWound: true);
            GameFiber.Wait(150);
            
            SendEuphoriaMessage(ped);
        }
        catch (Exception e)
        {
            Error(e);
        }
    }
}