using InexperiencedDeveloper.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-998)]
public class SpawnManagerMono : MonoBehaviour
{
    [SerializeField] private Vector2 m_spawnDelay = new Vector2(1, 3);
    [SerializeField] private EnemyCar m_enemyPrefab;

    private List<EnemyCar> m_enemyPool;

    private bool m_runSpawner = true;

    protected void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private async void Start()
    {
        m_enemyPool = new EnemyCar[25].ToList();
        SpawnPlayer();
        await SpawnCarAsync();
    }

    private void SpawnPlayer()
    {
        Debug.Log($"Spawn Player: {SpawnManager.PlayerSpawned}");
        if (!SpawnManager.PlayerSpawned)
        {
            SpawnManager.PlayerSpawned = true;
            Instantiate(Settings.Player.PlayerPrefab);
            Debug.Log("Instantiated player");
        }
        PlayerSingleton.Instance.transform.position = Settings.Player.OriginalPos;
        PlayerSingleton.Instance.transform.rotation = Quaternion.identity;
    }

    protected void OnDestroy()
    {
        m_runSpawner = false;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != Scenes.GAME) return;
    }

    private int GetFirstOpenIndex()
    {
        for(int i = 0; i < m_enemyPool.Count; i++)
        {
            if (m_enemyPool[i] == null || !m_enemyPool[i].gameObject.activeSelf) return i;
        }
        return m_enemyPool.Count;
    }

    private async Task SpawnCarAsync()
    {
        while(m_runSpawner)
        {
            int nextIndex = GetFirstOpenIndex();
            EnemyCar car = null;
            if (nextIndex < m_enemyPool.Count && m_enemyPool[nextIndex] == null)
            {
                m_enemyPool[nextIndex] = Instantiate(m_enemyPrefab);
                car = m_enemyPool[nextIndex];
            }
            else if (nextIndex < m_enemyPool.Count && !m_enemyPool[nextIndex].gameObject.activeSelf)
            {
                car = m_enemyPool[nextIndex];
            }
            else
            {
                m_enemyPool.Add(Instantiate(m_enemyPrefab));
            }
            SpawnPoint point = SpawnManager.SpawnPoints[Random.Range(0, SpawnManager.SpawnPoints.Count)];
            car.transform.position = point.transform.position;
            car.transform.rotation = point.transform.rotation;
            car.gameObject.SetActive(true);
            await Task.Delay((int)Random.Range(m_spawnDelay.x, m_spawnDelay.y));
        }
    }
}
