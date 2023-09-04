using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpawnManager
{
    public static bool PlayerSpawned;
    public static List<SpawnPoint> SpawnPoints {  get; private set; } = new List<SpawnPoint>();
}
