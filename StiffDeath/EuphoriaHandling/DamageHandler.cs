using static BetterHitReactions.EuphoriaHandling.EuphoriaHelper;

namespace BetterHitReactions.EuphoriaHandling;

internal class DamageHandler
{
    internal static Random rndm = new Random(DateTime.Now.Millisecond);
    internal static void InitializeEuphoria()
    {
        Game.LogTrivial("Initialized euphoria...");
        DamageTrackerService.OnPedTookDamage += OnPedTookDamage;
        
         if (!Settings.DoesEuphoriaEffectPlayer) return;
         Game.LogTrivial("Initializing player euphoria");
         DamageTrackerService.OnPlayerTookDamage += OnPlayerTookDamage;
    }

    
    private static void OnPlayerTookDamage(Ped victimPed, Ped attackerPed, PedDamageInfo damageInfo)
    {
        try
        {
            /*Game.DisplayHelp($"~w~Ped: {victimPed.Model.Name} (~r~{damageInfo.Damage} ~b~{damageInfo.ArmourDamage} ~w~Dmg ({(victimPed.IsAlive ? "~g~Alive" : "~r~Dead")}~w~) " +
                             $"\n~w~Health: ~g~{victimPed.Health}/{victimPed.MaxHealth} Armor: ~b~{victimPed.Armor})" +
                             $"\n~w~Attacker: ~r~{attackerPed?.Model.Name ?? "None"}" +
                             $"\n~w~Weapon: ~y~{damageInfo.WeaponInfo.Hash.ToString()} {damageInfo.WeaponInfo.Type.ToString()} {damageInfo.WeaponInfo.Group.ToString()}" +
                             $"\n~w~Bone: ~r~{damageInfo.BoneInfo.BoneId.ToString()} {damageInfo.BoneInfo.Limb.ToString()} {damageInfo.BoneInfo.BodyRegion.ToString()}");*/


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
                    victimPed.Health = 100;
                    GameFiber.StartNew(() => ApplyHeadshotEuphoria(victimPed));
                    break;
                case (BoneId)PedBoneId.Neck:
                    GameFiber.StartNew(() => ApplyNeckEuphoria(victimPed));
                    break;
                case (BoneId)PedBoneId.Pelvis:
                    GameFiber.StartNew(() => ApplyTorsoEuphoria(victimPed));
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
                    GameFiber.StartNew(() => ApplyArmEuphoria(victimPed, damageInfo));
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
            /*Game.DisplayHelp($"~w~Ped: {victimPed.Model.Name} (~r~{damageInfo.Damage} ~b~{damageInfo.ArmourDamage} ~w~Dmg ({(victimPed.IsAlive ? "~g~Alive" : "~r~Dead")}~w~) " +
                             $"\n~w~Health: ~g~{victimPed.Health}/{victimPed.MaxHealth} Armor: ~b~{victimPed.Armor})" +
                             $"\n~w~Attacker: ~r~{attackerPed?.Model.Name ?? "None"}" +
                             $"\n~w~Weapon: ~y~{damageInfo.WeaponInfo.Hash.ToString()} {damageInfo.WeaponInfo.Type.ToString()} {damageInfo.WeaponInfo.Group.ToString()}" +
                             $"\n~w~Bone: ~r~{damageInfo.BoneInfo.BoneId.ToString()} {damageInfo.BoneInfo.Limb.ToString()} {damageInfo.BoneInfo.BodyRegion.ToString()}");
                             */

            NativeFunction.Natives.SET_PED_CONFIG_FLAG(victimPed, 281, true);

            if (!victimPed.IsRunning)
            {
                switch (damageInfo.WeaponInfo.Type)
                {
                    case DamageType.SMG:
                    case DamageType.Pistol:
                        victimPed.Velocity *= 0.05f;
                        break;
                    case DamageType.Rifle:
                        victimPed.Velocity *= 0.11f;
                        break;
                    case DamageType.Sniper:
                    case DamageType.Shotgun:
                        victimPed.Velocity *= 0.75f;
                        break;
                    case DamageType.MG:
                        victimPed.Velocity *= 0.15f;
                        break;
                }
            }

            //SendEuphoriaMessage(victimPed, reachForWound:true, timeBeforeReachForWound:0f);
            
            if (damageInfo.WeaponInfo.Group == DamageGroup.LessThanLethal)
            {
                GameFiber.StartNew(() => ApplyTazerEuphoria(victimPed));
                return;
            }

            switch (damageInfo.BoneInfo.BoneId)
            {
                case (BoneId)PedBoneId.Head:
                    //victimPed.Resurrect();
                    victimPed.Health = 100;
                    GameFiber.StartNew(() => ApplyHeadshotEuphoria(victimPed));
                    break;
                case (BoneId)PedBoneId.Neck:
                    victimPed.Health = 100;
                    GameFiber.StartNew(() => ApplyNeckEuphoria(victimPed));
                    break;
                case (BoneId)PedBoneId.Pelvis:
                    GameFiber.StartNew(() => ApplyTorsoEuphoria(victimPed));
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
                    GameFiber.StartNew(() => ApplyArmEuphoria(victimPed, damageInfo));
                    break;
            }
        }
        catch (Exception e)
        {
            EntryPoint.Error(e);
        }
    }
}