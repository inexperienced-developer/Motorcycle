using UnityEngine;

public class RoadChunk : MonoBehaviour
{
    public SpawnEnvironmentProps EnvSpawner { get; private set; }

    private void Awake()
    {
        EnvSpawner = GetComponentInChildren<SpawnEnvironmentProps>(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.WHEELS)) return;
        PlayerSingleton player = other.GetComponentInParent<PlayerSingleton>();
        if (player == null) return;
        //EventsRoad.OnHitTrigger(this);
    }
}
