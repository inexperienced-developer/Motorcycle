using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private Vector2 m_spawnDelay = new Vector2(1000, 3000);
    [SerializeField] private SpawnManagerMono m_spawnManager;

    private bool m_isSpawned = false;

    private async void Start()
    {
        await SpawnObstaclesAsync();
    }

    private async Task SpawnObstaclesAsync()
    {
        while (m_spawnManager.RunSpawner)
        {
            // Check if any closed Spawn Points then wait and continue
            bool allOpen = true;
            foreach (var spawnPoint in SpawnManager.SpawnPoints)
            {
                if (spawnPoint.Closed)
                {
                    allOpen = false;
                    break;
                }
            }
            if (!allOpen && Random.Range(0, 100) < 0)
            {
                // Turn this into some other value - but for now it's ok
                await Task.Delay(2000);
                continue;
            }

            SpawnPoint random = SpawnManager.RandomSpawnPoint;
            // Spawn a random obstacle?
            if (!m_isSpawned)
            {
                IObstacle obstacle = random.SpawnObstacle(Settings.Obstacles.RampPrefab);
                m_isSpawned = true;
                obstacle.transform.position = random.transform.position;
                obstacle.transform.rotation = random.transform.rotation;
                Debug.Log("Spawned obstacle");
                await Task.Delay((int)Random.Range(m_spawnDelay.x, m_spawnDelay.y));
            }
            else
            {
                await Task.Delay(3000);
                m_isSpawned = false;
            }
        }
    }
}
