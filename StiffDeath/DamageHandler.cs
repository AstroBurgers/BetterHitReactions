using System;
using DamageTrackerLib;
using DamageTrackerLib.DamageInfo;
using Rage;
using Rage.Euphoria;
using Rage.Native;

namespace BetterHitReactions;

internal class DamageHandler
{
    internal static void InitializeEuphoria()
    {
        Game.LogTrivial("Initialized euphoria...");
        DamageTrackerService.OnPedTookDamage += OnPedTookDamage;
    }

    private static void OnPedTookDamage(Ped victimPed, Ped attackerPed, PedDamageInfo damageInfo)
    {
        try
        {
            Game.LogTrivial("Ped was shot in: " + damageInfo.BoneInfo.BodyRegion);

            NativeFunction.Natives.SET_PED_CONFIG_FLAG(victimPed, 281, false);
            EuphoriaMessage msg = new EuphoriaMessage("NM_STOP_ALL_MSG", true);
            msg.SendTo(victimPed);
            
            bool dropWeapon = Settings.DoesPedDropWeapon && (int)EntryPoint.GenerateChance() <= Settings.Chance;
            if (dropWeapon && victimPed.Exists() && victimPed.IsAlive && NativeFunction.Natives.x475768A975D5AD17<bool>(victimPed, 1 | 2 | 4)) // IS_PED_ARMED
            {
                Game.LogTrivial("Making ped drop weapon...");
                NativeFunction.Natives.x6B7513D9966FBEC0(victimPed); // SET_PED_DROPS_WEAPON
            }
            
            EuphoriaMessageShot euphoriaMessage = new EuphoriaMessageShot
            {
                TimeBeforeReachForWound = 0f,
                ReachForWound = true
            };
            euphoriaMessage.SendTo(victimPed);

            switch (damageInfo.WeaponInfo.Group)
            {
                case DamageGroup.LessThanLethal:
                {
                    Vector3 dir = new Vector3(victimPed.Velocity.X,
                        victimPed.Velocity.Y + (victimPed.Speed + 1.5f), victimPed.Velocity.Z);
                    NativeFunction.Natives.SET_PED_TO_RAGDOLL_WITH_FALL(victimPed, 5500, 6500, 0, dir,
                        World.GetGroundZ(victimPed.Position, true, false), Vector3.Zero, Vector3.Zero);

                    euphoriaMessage.ArmStiffness = 16f;
                    euphoriaMessage.BodyStiffness = 16f;
                    euphoriaMessage.KMult4Legs = 0.6f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.ArmStiffness = 14f;
                    euphoriaMessage.BodyStiffness = 14f;
                    euphoriaMessage.KMult4Legs = 0.4f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.ArmStiffness = 12f;
                    euphoriaMessage.BodyStiffness = 12f;
                    euphoriaMessage.KMult4Legs = 0.2f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.ArmStiffness = 10f;
                    euphoriaMessage.BodyStiffness = 10f;
                    euphoriaMessage.KMult4Legs = 0f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.ArmStiffness = 0f;
                    euphoriaMessage.BodyStiffness = 0f;
                    euphoriaMessage.KMult4Legs = 0f;
                    euphoriaMessage.SendTo(victimPed);
                    return;
                }
            }

            NativeFunction.Natives.SET_PED_TO_RAGDOLL(victimPed, 4000, 5000, 1, 1, 1, 0);

            switch (damageInfo.BoneInfo.BoneId)
            {
                case (BoneId)PedBoneId.Head:
                {
                    euphoriaMessage.KMult4Legs = 1f;
                    euphoriaMessage.BodyStiffness = 16f;
                    euphoriaMessage.ArmStiffness = 16f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.BodyStiffness = 15f;
                    euphoriaMessage.ArmStiffness = 15f;
                    euphoriaMessage.KMult4Legs = 0.9f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.BodyStiffness = 14f;
                    euphoriaMessage.ArmStiffness = 14f;
                    euphoriaMessage.KMult4Legs = 0.8f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.BodyStiffness = 13f;
                    euphoriaMessage.ArmStiffness = 13f;
                    euphoriaMessage.KMult4Legs = 0.7f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.BodyStiffness = 12f;
                    euphoriaMessage.BodyStiffness = 12f;
                    euphoriaMessage.KMult4Legs = 0.6f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.BodyStiffness = 10f;
                    euphoriaMessage.ArmStiffness = 10f;
                    euphoriaMessage.KMult4Legs = 0.4f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.BodyStiffness = 9f;
                    euphoriaMessage.ArmStiffness = 9f;
                    euphoriaMessage.KMult4Legs = 0.3f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.BodyStiffness = 5f;
                    euphoriaMessage.ArmStiffness = 5f;
                    euphoriaMessage.KMult4Legs = 0.1f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.ArmStiffness = 0f;
                    euphoriaMessage.BodyStiffness = 0f;
                    euphoriaMessage.KMult4Legs = 0f;
                    euphoriaMessage.SendTo(victimPed);
                    break;
                }
                case (BoneId)PedBoneId.Neck:
                {

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
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    //Stiffness.BodyStiffness = 90f;
                    //Stiffness.NeckStiffness = 90f;
                    euphoriaMessage.KMult4Legs = 0.9f;
                    euphoriaMessage.UseExtendedCatchFall = true;
                    euphoriaMessage.ReachForWound = true;
                    euphoriaMessage.Fling = false;
                    euphoriaMessage.CStrUpperMax += 50f;
                    euphoriaMessage.CStrUpperMin += 50f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    // Stiffness.BodyStiffness = 80f;
                    // Stiffness.NeckStiffness = 80f;
                    euphoriaMessage.KMult4Legs = 0.8f;
                    euphoriaMessage.UseExtendedCatchFall = true;
                    euphoriaMessage.ReachForWound = true;
                    euphoriaMessage.Fling = false;
                    euphoriaMessage.CStrUpperMax += 50f;
                    euphoriaMessage.CStrUpperMin += 50f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    // Stiffness.BodyStiffness = 60f;
                    // Stiffness.NeckStiffness = 60f;
                    euphoriaMessage.KMult4Legs = 0.7f;
                    euphoriaMessage.UseExtendedCatchFall = true;
                    euphoriaMessage.ReachForWound = true;
                    euphoriaMessage.Fling = false;
                    euphoriaMessage.CStrUpperMax += 50f;
                    euphoriaMessage.CStrUpperMin += 50f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    // Stiffness.BodyStiffness = 50f;
                    // Stiffness.NeckStiffness = 50f;
                    euphoriaMessage.KMult4Legs = 0.5f;
                    euphoriaMessage.UseExtendedCatchFall = true;
                    euphoriaMessage.ReachForWound = true;
                    euphoriaMessage.Fling = false;
                    euphoriaMessage.CStrUpperMax += 50f;
                    euphoriaMessage.CStrUpperMin += 50f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    // Stiffness.BodyStiffness = 35f;
                    // Stiffness.NeckStiffness = 35f;
                    euphoriaMessage.KMult4Legs = 0.4f;
                    euphoriaMessage.UseExtendedCatchFall = true;
                    euphoriaMessage.ReachForWound = true;
                    euphoriaMessage.Fling = false;
                    euphoriaMessage.CStrUpperMax += 50f;
                    euphoriaMessage.CStrUpperMin += 50f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    // Stiffness.BodyStiffness = 25f;
                    // Stiffness.NeckStiffness = 25f;
                    euphoriaMessage.KMult4Legs = 0.3f;
                    euphoriaMessage.UseExtendedCatchFall = true;
                    euphoriaMessage.ReachForWound = true;
                    euphoriaMessage.Fling = false;
                    euphoriaMessage.CStrUpperMax += 50f;
                    euphoriaMessage.CStrUpperMin += 50f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    // Stiffness.BodyStiffness = 15f;
                    // Stiffness.NeckStiffness = 15f;
                    euphoriaMessage.KMult4Legs = 0.2f;
                    euphoriaMessage.UseExtendedCatchFall = true;
                    euphoriaMessage.ReachForWound = true;
                    euphoriaMessage.Fling = false;
                    euphoriaMessage.CStrUpperMax += 50f;
                    euphoriaMessage.CStrUpperMin += 50f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    // Stiffness.BodyStiffness = 0f;
                    // Stiffness.NeckStiffness = 0f;
                    euphoriaMessage.KMult4Legs = 0f;
                    euphoriaMessage.UseExtendedCatchFall = true;
                    euphoriaMessage.ReachForWound = true;
                    euphoriaMessage.Fling = false;
                    euphoriaMessage.CStrUpperMax += 50f;
                    euphoriaMessage.CStrUpperMin += 50f;
                    euphoriaMessage.SendTo(victimPed);
                    
                    break;
                }
                case (BoneId)PedBoneId.Pelvis:
                {
                    euphoriaMessage.Fling = false;
                    euphoriaMessage.FallingReaction = 1;
                    euphoriaMessage.BodyStiffness = 16f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.BodyStiffness = 15f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.BodyStiffness = 14f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.SendTo(victimPed);
                    euphoriaMessage.BodyStiffness = 10f;
                    GameFiber.Wait(250);

                    euphoriaMessage.BodyStiffness = 8f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.BodyStiffness = 2f;
                    euphoriaMessage.SendTo(victimPed);
                    break;
                }
                default:
                    Game.LogTrivial("Ped was not shot in a specific bone, checking body regions...");
                    break;
            }

            switch (damageInfo.BoneInfo.BodyRegion)
            {
                case BodyRegion.Torso:
                {
                    euphoriaMessage.UseExtendedCatchFall = true;
                    euphoriaMessage.Fling = false;
                    euphoriaMessage.BodyStiffness = 16f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.BodyStiffness = 15f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.BodyStiffness = 14f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.BodyStiffness = 13f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.BodyStiffness = 12f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(250);

                    euphoriaMessage.BodyStiffness = 11f;
                    euphoriaMessage.SendTo(victimPed);
                    break;
                }
                case BodyRegion.Legs:
                {
                    euphoriaMessage.FallingReaction = 3;
                    euphoriaMessage.Fling = false;
                    euphoriaMessage.LoosenessAmount = 0f;
                    euphoriaMessage.KMult4Legs = 16f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.KMult4Legs = 14f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.KMult4Legs = 13f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.KMult4Legs = 12f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.KMult4Legs = 10f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.KMult4Legs = 9f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.KMult4Legs = 8f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.KMult4Legs = 7f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.KMult4Legs = 6f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.KMult4Legs = 5f;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);

                    euphoriaMessage.KMult4Legs = 2f;
                    euphoriaMessage.SendTo(victimPed);
                    break;
                }
                case BodyRegion.Arms:
                {
                    euphoriaMessage.ArmStiffness = 16f;
                    euphoriaMessage.TimeBeforeReachForWound = 0f;
                    euphoriaMessage.ReachForWound = true;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);
                    
                    euphoriaMessage.ArmStiffness = 14f;
                    euphoriaMessage.TimeBeforeReachForWound = 0f;
                    euphoriaMessage.ReachForWound = true;
                    euphoriaMessage.SendTo(victimPed);
                    GameFiber.Wait(150);
                    
                    euphoriaMessage.TimeBeforeReachForWound = 0f;
                    euphoriaMessage.ReachForWound = true;
                    euphoriaMessage.SendTo(victimPed);
                    euphoriaMessage.ArmStiffness = 12f;
                    GameFiber.Wait(150);
                    
                    euphoriaMessage.TimeBeforeReachForWound = 0f;
                    euphoriaMessage.ReachForWound = true;
                    euphoriaMessage.SendTo(victimPed);
                    euphoriaMessage.ArmStiffness = 10f;
                    GameFiber.Wait(150);
                    
                    euphoriaMessage.ArmStiffness = 0f;
                    euphoriaMessage.ReachForWound = false;
                    euphoriaMessage.SendTo(victimPed);
                    break;
                }
                default:
                    Game.LogTrivial("Ped was not injured in a valid bodyregion");
                    break;
            }
        }
        catch (Exception e)
        {
            Game.LogTrivial("BHR Threw an error:  " + e);
        }
    }
}