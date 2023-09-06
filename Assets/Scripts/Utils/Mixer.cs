using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mixer
{
    public const float MIN_VOL = -80f;
    public const float MAX_VOL = 20f;

    // Params
    public const string MASTER_VOLUME = "volume_master";
    public const string MUSIC_VOLUME = "volume_music";
    public const string CAR_VOLUME = "volume_cars";
    public const string PLAYER_VOLUME = "volume_player";
    public const string ENEMY_VOLUME = "volume_enemies";

    // Groups
    public const string CAR_SOUNDS = "CarSounds";
    public const string PLAYER_SOUNDS = "PlayerSounds";
    public const string ENEMY_SOUNDS = "EnemySounds";
    public const string MUSIC = "Music";
}
