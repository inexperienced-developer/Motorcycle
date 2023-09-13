using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacle
{
    Transform transform { get; }
    SpawnPoint SpawnPoint { get; }
    void SetSpawnPoint(SpawnPoint spawnPoint);
    void UnblockSpawnPoint();
}
