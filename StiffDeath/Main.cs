using System.Security.Cryptography;
using BetterHitReactions.EuphoriaHandling;

[assembly: Rage.Attributes.Plugin("Better Hit Reactions", Description = "BRUTALITY", Author = "Astro")]

namespace BetterHitReactions;

public class EntryPoint
{
    private static readonly RNGCryptoServiceProvider ImprovedRandom = new();
    
    public static void Main()
    {
        Game.DisplayNotification("mpwizardssleeveitemsandfx", "fx_blood_red_3", "Better Hit Reactions", "~b~By Astro", "~y~This plugin may be disturbing to some people");

        Settings.SetupIniFile();
        DamageTrackerService.Start();
        GameFiber.StartNew(DamageHandler.InitializeEuphoria);
        //GameFiber.StartNew(Stabbed.StabbedMain);

        GameFiber.Hibernate();
    }

    public static void OnUnload(bool exit)
    {
        DamageTrackerService.Stop();
    }
    
    internal static long GenerateChance()
    {
        byte[] randomBytes = new byte[8]; // Using 8 bytes for more randomization ig
        ImprovedRandom.GetBytes(randomBytes);
 
        long randomNumber = BitConverter.ToInt64(randomBytes, 0) & 0x7FFFFFFFFFFFFFFF; // Convert to positive integer

        var convertedChance = randomNumber % 100;
        
        return convertedChance;
    }
}