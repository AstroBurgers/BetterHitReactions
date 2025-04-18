using static BetterHitReactions.EuphoriaHandling.EuphoriaHelper;

namespace BetterHitReactions.EuphoriaHandling;

internal class DamageHandler
{
    internal static Random rndm = new Random(DateTime.Now.Millisecond);
    internal static void InitializeEuphoria()
    {
        Game.LogTrivial("Initialized euphoria...");
        DamageTrackerService.OnPedTookDamage += OnPedTookDamage;

        // TODO Fix this shit
         if (!Settings.DoesEuphoriaEffectPlayer) return;
         Game.LogTrivial("Initializing player euphoria");
         DamageTrackerService.OnPlayerTookDamage += OnPlayerTookDamage;
    }

    
    // TODO Fix this shit as well
    private static void OnPlayerTookDamage(Ped victimPed, Ped attackerPed, PedDamageInfo damageInfo)
    {
        try
        {
            Game.LogTrivial($"Injured Ped: {victimPed.Model.Name}");
            Game.LogTrivial("Ped was shot in: " + damageInfo.BoneInfo.BodyRegion);

            var chance = rndm.Next(1, 101);
            if (chance < 20 && victimPed.Armor == 0)
            {
                victimPed.IsRagdoll = true;
                MakePedRagdoll(victimPed, 4000, 5000, 2);
            }
            else {
                return;
            }
            
            //SendEuphoriaMessage(victimPed, reachForWound:true, timeBeforeReachForWound:0f);
            
            if (damageInfo.WeaponInfo.Group == DamageGroup.LessThanLethal)
            {
                GameFiber.StartNew(() => ApplyTazerEuphoria(victimPed));
            }

            switch (damageInfo.BoneInfo.BoneId)
            {
                case (BoneId)PedBoneId.Head:
                    //victimPed.Resurrect();
                    victimPed.Health = 100;
                    GameFiber.StartNew(() => ApplyHeadshotEuphoria(victimPed));
                    break;
                case (BoneId)PedBoneId.Neck:
                    GameFiber.StartNew(() => ApplyNeckEuphoria(victimPed));
                    break;
                case (BoneId)PedBoneId.Pelvis:
                    GameFiber.StartNew(() => ApplyPelvisEuphoria(victimPed));
                    break;
                default:
                    Game.LogTrivial("Ped was not shot in a specific bone, checking body regions...");
                    break;
            }

            switch (damageInfo.BoneInfo.BodyRegion)
            {
                case BodyRegion.Torso:
                    GameFiber.StartNew(() => ApplyTorsoEuphoria(victimPed));
                    break;
                case BodyRegion.Legs:
                    GameFiber.StartNew(() => ApplyLegEuphoria(victimPed));
                    break;
                case BodyRegion.Arms:
                    GameFiber.StartNew(() => ApplyArmEuphoria(victimPed));
                    break;
                default:
                    Game.LogTrivial("Ped was not injured in a valid bodyregion");
                    break;
            }
            GameFiber.Wait(750);
            victimPed.IsRagdoll = false;
        }
        catch (Exception e)
        {
            EntryPoint.Error(e);
        }
    }

    private static void OnPedTookDamage(Ped victimPed, Ped attackerPed, PedDamageInfo damageInfo)
    {
        try
        {
            Game.LogTrivial($"Injured Ped: {victimPed.Model.Name}");
            Game.LogTrivial("Ped was shot in: " + damageInfo.BoneInfo.BodyRegion);

            NativeFunction.Natives.SET_PED_CONFIG_FLAG(victimPed, 281, true);
            victimPed.Velocity *= 0.1f;
            
            bool isPedBeingTazed = false;
            
            //SendEuphoriaMessage(victimPed, reachForWound:true, timeBeforeReachForWound:0f);
            
            if (damageInfo.WeaponInfo.Group == DamageGroup.LessThanLethal)
            {
                isPedBeingTazed = true;
                GameFiber.StartNew(() => ApplyTazerEuphoria(victimPed));
            }

            if (!isPedBeingTazed)
            {
                //MakePedRagdoll(victimPed, 4000, 5000, 2);
            }

            switch (damageInfo.BoneInfo.BoneId)
            {
                case (BoneId)PedBoneId.Head:
                    //victimPed.Resurrect();
                    victimPed.Health = 100;
                    GameFiber.StartNew(() => ApplyHeadshotEuphoria(victimPed));
                    break;
                case (BoneId)PedBoneId.Neck:
                    GameFiber.StartNew(() => ApplyNeckEuphoria(victimPed));
                    break;
                case (BoneId)PedBoneId.Pelvis:
                    GameFiber.StartNew(() => ApplyPelvisEuphoria(victimPed));
                    break;
                default:
                    Game.LogTrivial("Ped was not shot in a specific bone, checking body regions...");
                    break;
            }

            switch (damageInfo.BoneInfo.BodyRegion)
            {
                case BodyRegion.Torso:
                    GameFiber.StartNew(() => ApplyTorsoEuphoria(victimPed));
                    break;
                case BodyRegion.Legs:
                    GameFiber.StartNew(() => ApplyLegEuphoria(victimPed));
                    break;
                case BodyRegion.Arms:
                    GameFiber.StartNew(() => ApplyArmEuphoria(victimPed));
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