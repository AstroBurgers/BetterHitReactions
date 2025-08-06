using static BetterHitReactions.EuphoriaHandling.EuphoriaHelper;

namespace BetterHitReactions.EuphoriaHandling;

internal static class DamageHandler
{
    internal static readonly Random rndm = new(DateTime.Now.Millisecond);

    private static void DampenPedVelocity(Ped ped, DamageType type)
    {
        if (!IsValidPed(ped) || ped.IsRunning)
            return;

        var multiplier = type switch
        {
            DamageType.Unarmed => 0.01f,
            DamageType.MeleeBlunt => 0.03f,
            DamageType.MeleeStab => 0.05f,
            
            DamageType.Pistol => 0.07f,
            
            DamageType.SMG => 0.08f,
            
            DamageType.Rifle => 0.15f,
            
            DamageType.MG => 0.2f,
            
            DamageType.Shotgun => 0.4f,

            DamageType.Sniper => 0.6f,

            DamageType.Explosive => 1.0f,

            DamageType.Launcher => 1.0f,

            DamageType.LessThanLethal => 0.02f,

            DamageType.Fire => 0.01f,
            DamageType.Gas => 0.01f,
            DamageType.Fall => 0.01f,
            DamageType.Drowning => 0.01f,
            DamageType.Bodily => 0.01f,
            DamageType.BarbedWire => 0.01f,
            DamageType.Electric => 0.01f,
            
            DamageType.VehicleFirearm => 0.25f,
            DamageType.VehicleLauncher => 1.0f,
            
            _ => 0.05f
        };

        ped.Velocity *= multiplier;
    }

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
            var chance = rndm.Next(1, 101);
            if (chance < 20 && victimPed.Armor == 0)
            {
                victimPed.IsRagdoll = true;
                MakePedRagdoll(victimPed, 4000, 5000, 2);
            }
            else
            {
                return;
            }

            if (damageInfo.WeaponInfo.Group == DamageGroup.LessThanLethal)
            {
                GameFiber.StartNew(() =>
                {
                    if (!IsValidPed(victimPed)) return;
                    ApplyTazerEuphoria(victimPed);
                });
            }

            switch (damageInfo.BoneInfo.BoneId)
            {
                case (BoneId)PedBoneId.Head:
                    victimPed.Health = 100;
                    GameFiber.StartNew(() =>
                    {
                        if (!IsValidPed(victimPed)) return;
                        ApplyHeadshotEuphoria(victimPed);
                    });
                    break;

                case (BoneId)PedBoneId.Neck:
                    GameFiber.StartNew(() =>
                    {
                        if (!IsValidPed(victimPed)) return;
                        ApplyNeckEuphoria(victimPed);
                    });
                    break;

                case (BoneId)PedBoneId.Pelvis:
                    GameFiber.StartNew(() =>
                    {
                        if (!IsValidPed(victimPed)) return;
                        ApplyTorsoEuphoria(victimPed);
                    });
                    break;

                default:
                    Game.LogTrivial("Ped was not shot in a specific bone, checking body regions...");
                    break;
            }

            switch (damageInfo.BoneInfo.BodyRegion)
            {
                case BodyRegion.Torso:
                    GameFiber.StartNew(() =>
                    {
                        if (!IsValidPed(victimPed)) return;
                        ApplyTorsoEuphoria(victimPed);
                    });
                    break;

                case BodyRegion.Legs:
                    GameFiber.StartNew(() =>
                    {
                        if (!IsValidPed(victimPed)) return;
                        ApplyLegEuphoria(victimPed);
                    });
                    break;

                case BodyRegion.Arms:
                    GameFiber.StartNew(() =>
                    {
                        if (!IsValidPed(victimPed)) return;
                        ApplyArmEuphoria(victimPed, damageInfo);
                    });
                    break;
            }

            GameFiber.StartNew(() =>
            {
                GameFiber.Wait(750);
                if (IsValidPed(victimPed))
                    victimPed.IsRagdoll = false;
            });
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
            NativeFunction.Natives.SET_PED_CONFIG_FLAG(victimPed, 281, true);

            DampenPedVelocity(victimPed, damageInfo.WeaponInfo.Type);

            if (damageInfo.WeaponInfo.Group == DamageGroup.LessThanLethal)
            {
                GameFiber.StartNew(() =>
                {
                    if (!IsValidPed(victimPed)) return;
                    ApplyTazerEuphoria(victimPed);
                });
                return;
            }

            switch (damageInfo.BoneInfo.BoneId)
            {
                case (BoneId)PedBoneId.Head:
                    victimPed.Health = 100;
                    GameFiber.StartNew(() =>
                    {
                        if (!IsValidPed(victimPed)) return;
                        ApplyHeadshotEuphoria(victimPed);
                    });
                    break;

                case (BoneId)PedBoneId.Neck:
                    victimPed.Health = 100;
                    GameFiber.StartNew(() =>
                    {
                        if (!IsValidPed(victimPed)) return;
                        ApplyNeckEuphoria(victimPed);
                    });
                    break;

                case (BoneId)PedBoneId.Pelvis:
                    GameFiber.StartNew(() =>
                    {
                        if (!IsValidPed(victimPed)) return;
                        ApplyTorsoEuphoria(victimPed);
                    });
                    break;
            }

            switch (damageInfo.BoneInfo.BodyRegion)
            {
                case BodyRegion.Torso:
                    GameFiber.StartNew(() =>
                    {
                        if (!IsValidPed(victimPed)) return;
                        ApplyTorsoEuphoria(victimPed);
                    });
                    break;

                case BodyRegion.Legs:
                    GameFiber.StartNew(() =>
                    {
                        if (!IsValidPed(victimPed)) return;
                        ApplyLegEuphoria(victimPed);
                    });
                    break;

                case BodyRegion.Arms:
                    GameFiber.StartNew(() =>
                    {
                        if (!IsValidPed(victimPed)) return;
                        ApplyArmEuphoria(victimPed, damageInfo);
                    });
                    break;
            }
        }
        catch (Exception e)
        {
            EntryPoint.Error(e);
        }
    }
}