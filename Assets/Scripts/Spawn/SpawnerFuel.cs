using System.Threading.Tasks;
using UnityEngine;

public class SpawnerFuel : MonoBehaviour
{
    private bool m_shouldSpawn = true;

    private async void Start()
    {
        await SpawnFuelAndBoostAsync();
    }

    private void OnDestroy()
    {
        m_shouldSpawn = false;
    }

    private async Task SpawnFuelAsync()
    {
        while (m_shouldSpawn)
        {
            FuelCan fuelCan = Instantiate(Settings.Collectibles.FuelCanPrefab);
            Vector3 pos = SpawnManager.SpawnPoints[Random.Range(0, SpawnManager.SpawnPoints.Count)].transform.position;
            pos.x = Random.Range(Settings.Collectibles.XSpawnBounds.x, Settings.Collectibles.XSpawnBounds.y);
            fuelCan.transform.position = pos; 
            await Task.Delay((int)Random.Range(Settings.Collectibles.Fuel_SpawnTime_ms.x, Settings.Collectibles.Fuel_SpawnTime_ms.y));
        }
    }

    private async Task SpawnFuelAndBoostAsync()
    {
        while (m_shouldSpawn)
        {
            float random = Random.Range(0f, 100f);
            ICollectible spawnedObj = random < Settings.Collectibles.Fuel_ChanceToSpawn_percent ?
                Instantiate(Settings.Collectibles.FuelCanPrefab) :
                Instantiate(Settings.Collectibles.BoostPrefab);
            Vector3 pos = SpawnManager.SpawnPoints[Random.Range(0, SpawnManager.SpawnPoints.Count)].transform.position;
            pos.x = Random.Range(Settings.Collectibles.XSpawnBounds.x, Settings.Collectibles.XSpawnBounds.y);
            spawnedObj.transform.position = pos;
            await Task.Delay((int)Random.Range(Settings.Collectibles.Fuel_SpawnTime_ms.x, Settings.Collectibles.Fuel_SpawnTime_ms.y));
        }
    }

}
