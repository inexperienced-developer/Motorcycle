using InexperiencedDeveloper.Core;
using InexperiencedDeveloper.Helper;
using System;
using UnityEngine;

public class RoadManagerMono : MonoBehaviour
{
    // Just keep adding more road segments -- when you get to something like 1000 or 2000 on the z then just teleport the entire place back
    // 1: Initialize road - 3 segments (prev, current, next)
    // 2: When you hit next then shift (prev -> next, current -> prev, next -> current) -- This will prevent constant deleting

    //Refactor into separate Settings reference -- My way for prefabs being accessible
    [SerializeField] private RoadChunk m_roadChunkPrefab;
    [SerializeField] private Vector3 m_boxColliderCenter;
    [SerializeField] private Vector3 m_boxColliderSize;

    public Transform RoadParent { get; private set; }
    public static RoadChunk[] Segments { get; private set; } = new RoadChunk[7];

    protected void Awake()
    {
        // Initialize Road segments
        RoadParent = new GameObject().transform;
        RoadParent.gameObject.name = "road_parent";
        RoadParent.tag = Tags.GROUND;
        BoxCollider col = RoadParent.gameObject.AddComponent<BoxCollider>();
        col.center = m_boxColliderCenter;
        col.size = m_boxColliderSize;
        for(int i = 0; i < Segments.Length; i++)
        {
            Segments[i] = Instantiate(m_roadChunkPrefab, RoadParent);
            Vector3 pos = Vector3.zero;
            // 100 is the length of the road chunk - I want 1 behind, 1 with us, and 1 in front to begin
            pos.z = i * 100 - 300;
            Segments[i].transform.position = pos;
        }

        // Subscribe to events
        EventsRoad.HitTrigger += OnHitTrigger;
        EventsRoad.EnemyHitTrigger += OnEnemyHitTrigger;
        EventsGame.GameOver += OnGameOver;
    }

    protected  void OnDestroy()
    {
        // Unsubscribe to events
        EventsRoad.HitTrigger -= OnHitTrigger;
        EventsRoad.EnemyHitTrigger -= OnEnemyHitTrigger;
        EventsGame.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        Segments = new RoadChunk[7];
    }

    private void OnEnemyHitTrigger(EnemyCar car)
    {

    }

    private void OnHitTrigger(RoadChunk chunk)
    {
        // Move prev to next.pos.z + 100
        foreach(var seg in Segments)
        {
            if(seg == chunk)
            {
                PlayerSingleton.Instance.transform.SetParent(seg.transform);
            }
            Vector3 adjPos = seg.transform.position;
            adjPos.z -= 100;
            seg.transform.position = adjPos;
            if (seg == chunk)
            {
                PlayerSingleton.Instance.transform.SetParent(null);
            }
        }
        RoadChunk prev = Segments[0];
        Vector3 newPos = Segments[Segments.Length - 1].transform.position;
        newPos.z += 100;
        prev.transform.position = newPos;
        for(int i = 1; i < Segments.Length; i++)
        {
            Segments[i - 1] = Segments[i];
        }
        Segments[Segments.Length - 1] = prev;
    }


    #region RemovableLater
    // Remove later - used to create road chunk
    private GameObject m_roadPrefab;
    //[ContextMenu("Create road chunk")]
    public void CreateRoadChunk()
    {
        GameObject chunk = new GameObject();
        chunk.name = "road_chunk";

        for(int i = 0; i < 20; i++)
        {
            GameObject road = Instantiate(m_roadPrefab, chunk.transform);
            Vector3 pos = Vector3.zero;
            pos.z = i * 5;
            road.transform.position = pos;
        }
    }
    #endregion
}
