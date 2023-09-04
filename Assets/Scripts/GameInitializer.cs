using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class GameInitializer : MonoBehaviour
{
    private void Awake()
    {
        SpawnManager.SpawnPoints.Clear();
    }
}
