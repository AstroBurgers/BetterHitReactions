using static BetterHitReactions.EuphoriaHandling.EuphoriaHelper;

namespace BetterHitReactions.EuphoriaHandling;

internal class DamageHandler
{
    internal static void InitializeEuphoria()
    {
        Game.LogTrivial("Initialized euphoria...");
        DamageTrackerService.OnPedTookDamage += OnPedTookDamage;

        // TODO Fix this shit
        // if (!Settings.DoesEuphoriaEffectPlayer) return;
        // Game.LogTrivial("Initializing player euphoria");
        // DamageTrackerService.OnPlayerTookDamage += OnPlayerTookDamage;
    }

    
    // TODO Fix this shit as well
    // private static void OnPlayerTookDamage(Ped victimped, Ped attackerped, PedDamageInfo damageInfo)
    // {
    //     try
    //     {
    //         Game.LogTrivial($"Injured Ped: {victimped.Model.Name}");
    //         Game.LogTrivial("Ped was shot in: " + damageInfo.BoneInfo.BodyRegion);
    //
    //         NativeFunction.Natives.SET_PED_CONFIG_FLAG(victimped, 281, false);
    //         EuphoriaMessage msg = new EuphoriaMessage("NM_STOP_ALL_MSG", true);
    //         msg.SendTo(victimped);
    //
    //         bool IsPedBeingTazed = false;
    //
    //         EuphoriaMessageShot euphoriaMessage = new EuphoriaMessageShot
    //         {
    //             TimeBeforeReachForWound = 0f,
    //             ReachForWound = true
    //         };
    //         euphoriaMessage.SendTo(victimped);
    //
    //         switch (damageInfo.WeaponInfo.Group)
    //         {
    //             case DamageGroup.LessThanLethal:
    //                 IsPedBeingTazed = true;
    //                 GameFiber.StartNew(() => ApplyTazerEuphoria(victimped, euphoriaMessage));
    //                 break;
    //         }
    //
    //         if (!IsPedBeingTazed)
    //         {
    //             MakePedRagdoll(victimped, 4000, 5000);
    //         }
    //
    //         switch (damageInfo.BoneInfo.BoneId)
    //         {
    //             case (BoneId)PedBoneId.Head:
    //                 GameFiber.StartNew(() => ApplyHeadshotEuphoria(victimped, euphoriaMessage));
    //                 break;
    //             case (BoneId)PedBoneId.Neck:
    //                 GameFiber.StartNew(() => ApplyNeckEuphoria(victimped, euphoriaMessage));
    //                 break;
    //             case (BoneId)PedBoneId.Pelvis:
    //                 GameFiber.StartNew(() => ApplyPelvisEuphoria(victimped, euphoriaMessage));
    //                 break;
    //             default:
    //                 Game.LogTrivial("Ped was not shot in a specific bone, checking body regions...");
    //                 break;
    //         }
    //
    //         switch (damageInfo.BoneInfo.BodyRegion)
    //         {
    //             case BodyRegion.Torso:
    //                 GameFiber.StartNew(() => ApplyTorsoEuphoria(victimped, euphoriaMessage));
    //                 break;
    //             case BodyRegion.Legs:
    //                 GameFiber.StartNew(() => ApplyLegEuphoria(victimped, euphoriaMessage));
    //                 break;
    //             case BodyRegion.Arms:
    //                 GameFiber.StartNew(() => ApplyArmEuphoria(victimped, euphoriaMessage));
    //                 break;
    //             default:
    //                 Game.LogTrivial("Ped was not injured in a valid bodyregion");
    //                 break;
    //         }
    //
    //         IsPedBeingTazed = false;
    //     }
    //     catch (Exception e)
    //     {
    //         Game.LogTrivial("BHR Threw an error:  " + e);
    //     }
    // }

    private static void OnPedTookDamage(Ped victimPed, Ped attackerPed, PedDamageInfo damageInfo)
    {
        try
        {
            Game.LogTrivial($"Injured Ped: {victimPed.Model.Name}");
            Game.LogTrivial("Ped was shot in: " + damageInfo.BoneInfo.BodyRegion);

            NativeFunction.Natives.SET_PED_CONFIG_FLAG(victimPed, 281, false);
            EuphoriaMessage msg = new EuphoriaMessage("NM_STOP_ALL_MSG", true);
            msg.SendTo(victimPed);

            bool isPedBeingTazed = false;

            EuphoriaMessageShot euphoriaMessage = new EuphoriaMessageShot
            {
                TimeBeforeReachForWound = 0f,
                ReachForWound = true
            };
            euphoriaMessage.SendTo(victimPed);

            switch (damageInfo.WeaponInfo.Group)
            {
                case DamageGroup.LessThanLethal:
                    isPedBeingTazed = true;
                    GameFiber.StartNew(() => ApplyTazerEuphoria(victimPed, euphoriaMessage));
                    break;
            }

            if (!isPedBeingTazed)
            {
                MakePedRagdoll(victimPed, 4000, 5000);
            }

            switch (damageInfo.BoneInfo.BoneId)
            {
                case (BoneId)PedBoneId.Head:
                    GameFiber.StartNew(() => ApplyHeadshotEuphoria(victimPed, euphoriaMessage));
                    break;
                case (BoneId)PedBoneId.Neck:
                    GameFiber.StartNew(() => ApplyNeckEuphoria(victimPed, euphoriaMessage));
                    break;
                case (BoneId)PedBoneId.Pelvis:
                    GameFiber.StartNew(() => ApplyPelvisEuphoria(victimPed, euphoriaMessage));
                    break;
                default:
                    Game.LogTrivial("Ped was not shot in a specific bone, checking body regions...");
                    break;
            }

            switch (damageInfo.BoneInfo.BodyRegion)
            {
                case BodyRegion.Torso:
                    GameFiber.StartNew(() => ApplyTorsoEuphoria(victimPed, euphoriaMessage));
                    break;
                case BodyRegion.Legs:
                    GameFiber.StartNew(() => ApplyLegEuphoria(victimPed, euphoriaMessage));
                    break;
                case BodyRegion.Arms:
                    GameFiber.StartNew(() => ApplyArmEuphoria(victimPed, euphoriaMessage));
                    break;
                default:
                    Game.LogTrivial("Ped was not injured in a valid bodyregion");
                    break;
            }

            isPedBeingTazed = false;
        }
        catch (Exception e)
        {
            EntryPoint.Error(e);
        }
    }
}