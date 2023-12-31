using UnityEngine;

public static class Settings
{
    private static SettingsPlayer s_player;
    public static SettingsPlayer Player
    {
        get
        {
            if(s_player == null)
            {
                s_player = Resources.Load<SettingsPlayer>("Settings/settings_player");
            }
            return s_player;
        }
    }

    private static SettingsCollectibles s_collectibles;
    public static SettingsCollectibles Collectibles
    {
        get
        {
            if (s_collectibles == null)
            {
                s_collectibles = Resources.Load<SettingsCollectibles>("Settings/settings_collectibles");
            }
            return s_collectibles;
        }
    }

    private static SettingsScooterColor s_scooterColors;
    public static SettingsScooterColor ScooterColors
    {
        get
        {
            if (s_scooterColors == null)
            {
                s_scooterColors = Resources.Load<SettingsScooterColor>("Settings/settings_scooterColors");
            }
            return s_scooterColors;
        }
    }
}
