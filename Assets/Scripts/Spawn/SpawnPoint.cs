using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool Closed { get; private set; }

    private void Awake()
    {
        SpawnManager.SpawnPoints.Add(this);
    }

    public IObstacle SpawnObstacle(IObstacle obstacleType)
    {
        Closed = true;
        // Instantiate the obstacle
        IObstacle obstacle = Instantiate(obstacleType.transform.gameObject, RoadManagerMono.Segments[2]?.transform).GetComponent<IObstacle>();
        obstacle.SetSpawnPoint(this);
        return obstacle;
    }

    public void Unblock()
    {
        Closed = false;
    }
}
