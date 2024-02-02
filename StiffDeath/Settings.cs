namespace BetterHitReactions;

internal static class Settings
{
    internal static int Chance = 90;
    private static InitializationFile _inifile; // Defining a new INI File

    internal static bool DoesPedDropWeapon = true;
    internal static bool DoesEuphoriaEffectPlayer = true;
    
    
    internal static void SetupIniFile()
    {
        _inifile = new InitializationFile(@"plugins/BetterHitReactions.ini");
        _inifile.Create();

        Chance = _inifile.ReadInt32("Settings", "Chance", Chance);
        Game.LogTrivial("Chance = " + Chance);
        DoesPedDropWeapon = _inifile.ReadBoolean("Settings", "Drop_Weapons", DoesPedDropWeapon);
        Game.LogTrivial("DoesPedDropWeapon = " + DoesPedDropWeapon);
        DoesEuphoriaEffectPlayer = _inifile.ReadBoolean("Settings", "Effect_Player", DoesEuphoriaEffectPlayer);
        Game.LogTrivial("DoesEuphoriaEffectPlayer: " + DoesEuphoriaEffectPlayer);
        
        ValidateIniFile();
    }

    private static void ValidateIniFile()
    {
        if (Chance > 100)
        {
            Game.LogTrivial("Chance was greater than 100, defaulting to 100");
            Chance = 100;
        }
    }
}