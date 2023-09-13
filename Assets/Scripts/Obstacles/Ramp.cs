using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour, IObstacle
{
    public SpawnPoint SpawnPoint { get; private set; }

    private void Awake()
    {
        EventsRoad.HitTrigger += OnHitTrigger;
    }

    private void OnDestroy()
    {
        EventsRoad.HitTrigger -= OnHitTrigger;
    }

    private void OnHitTrigger(RoadChunk chunk)
    {
        // Compare our z pos to player z position - if we are less than player.z - 100 then unblock
        if(transform.position.z < PlayerSingleton.Instance.transform.position.z - 100 && SpawnPoint != null) 
        {
            UnblockSpawnPoint();
        }
    }

    public void SetSpawnPoint(SpawnPoint spawnPoint)
    {
        SpawnPoint = spawnPoint;
    }

    public void UnblockSpawnPoint()
    {
        SpawnPoint.Unblock();
        SpawnPoint = null;
    }
}
