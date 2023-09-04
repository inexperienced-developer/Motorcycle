using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void Awake()
    {
        SpawnManager.SpawnPoints.Add(this);
    }
}
