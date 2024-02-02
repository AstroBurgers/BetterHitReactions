// TODO

// using DamageTrackerLib;
// using DamageTrackerLib.DamageInfo;
// using Rage;
// using Rage.Euphoria;
//
// namespace BetterHitReactions;
//
// internal class Stabbed
// {
//     internal static void StabbedMain()
//     {
//             DamageTrackerService.OnPedTookDamage += OnStabbed;
//         }
//
//     private static void OnStabbed(Rage.Ped victimPed, Rage.Ped attackerPed, DamageTrackerLib.DamageInfo.PedDamageInfo damageInfo)
//     {
//             if (damageInfo.WeaponInfo.Group.Equals(DamageGroup.Melee))
//             {
//                 if (damageInfo.BoneInfo.BoneId.Equals(PedBoneId.Neck))
//                 {
//                     EuphoriaMessageShot stiffness = new EuphoriaMessageShot
//                     {
//                         ReachForWound = true,
//                         DeathTime = 2500f,
//                         ExagDuration = 50f,
//                         KMult4Legs = 100f,
//                         BodyStiffness = 100f,
//                         ArmStiffness = 100f
//                     };
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 90f;
//                     stiffness.ArmStiffness = 90f;
//                     stiffness.KMult4Legs = 90f;
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 80f;
//                     stiffness.ArmStiffness = 80f;
//                     stiffness.KMult4Legs = 80f;
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 60f;
//                     stiffness.ArmStiffness = 60f;
//                     stiffness.KMult4Legs = 60f;
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 50f;
//                     stiffness.BodyStiffness = 50f;
//                     stiffness.KMult4Legs = 50f;
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 35f;
//                     stiffness.ArmStiffness = 35f;
//                     stiffness.KMult4Legs = 35f;
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 25f;
//                     stiffness.ArmStiffness = 25f;
//                     stiffness.KMult4Legs = 25f;
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 15f;
//                     stiffness.ArmStiffness = 15f;
//                     stiffness.KMult4Legs = 15f;
//                     GameFiber.Wait(150);
//                     stiffness.ArmStiffness = 0f;
//                     stiffness.BodyStiffness = 0f;
//                     stiffness.KMult4Legs = 0f;
//                 }
//                 else if (damageInfo.BoneInfo.BodyRegion.Equals(BodyRegion.Torso))
//                 {
//                     EuphoriaMessageShot stiffness = new EuphoriaMessageShot
//                     {
//                         ReachForWound = true,
//                         DeathTime = 2500f,
//                         ExagDuration = 50f,
//                         KMult4Legs = 100f,
//                         BodyStiffness = 100f,
//                         ArmStiffness = 100f
//                     };
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 90f;
//                     stiffness.ArmStiffness = 90f;
//                     stiffness.KMult4Legs = 90f;
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 80f;
//                     stiffness.ArmStiffness = 80f;
//                     stiffness.KMult4Legs = 80f;
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 60f;
//                     stiffness.ArmStiffness = 60f;
//                     stiffness.KMult4Legs = 60f;
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 50f;
//                     stiffness.BodyStiffness = 50f;
//                     stiffness.KMult4Legs = 50f;
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 35f;
//                     stiffness.ArmStiffness = 35f;
//                     stiffness.KMult4Legs = 35f;
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 25f;
//                     stiffness.ArmStiffness = 25f;
//                     stiffness.KMult4Legs = 25f;
//                     GameFiber.Wait(150);
//                     stiffness.BodyStiffness = 15f;
//                     stiffness.ArmStiffness = 15f;
//                     stiffness.KMult4Legs = 15f;
//                     GameFiber.Wait(150);
//                     stiffness.ArmStiffness = 0f;
//                     stiffness.BodyStiffness = 0f;
//                     stiffness.KMult4Legs = 0f;
//                 }
//             }
//         }
// }