using UnityEngine;

public class RoadChunk : MonoBehaviour
{
    private SpawnEnvironmentProps m_envSpawner;

    private void Awake()
    {
        m_envSpawner = GetComponentInChildren<SpawnEnvironmentProps>(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.WHEELS)) return;
        PlayerSingleton player = other.GetComponentInParent<PlayerSingleton>();
        if (player == null) return;
        EventsRoad.OnHitTrigger(this);
    }
}
