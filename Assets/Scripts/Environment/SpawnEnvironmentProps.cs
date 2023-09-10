using InexperiencedDeveloper.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnvironmentProps : MonoBehaviour
{
    // TODO: Move to a settings object
    [SerializeField] private Vector2 m_rangeOfNumberToSpawn;
    [SerializeField] private Vector2 m_xRangeToIgnore;
    [SerializeField] private Vector2 m_xRangeToSpawn;
    [SerializeField] private Vector2 m_yRangeToSpawn;
    [SerializeField] private Vector2 m_zRangeToSpawn;

    [SerializeField] private LayerMask m_groundLayer;

    [Header("Rotation")]
    [SerializeField] private Vector2 m_yRot;
    [SerializeField] private Vector2 m_xRot;
    [SerializeField] private Vector2 m_zRot;

    private List<GameObject> m_objs = new List<GameObject>();

    private void Awake()
    {
        Spawn();
    }

    public void Activate(bool val) 
    {
        foreach(var obj in m_objs) obj.SetActive(val);
    }

    public void Spawn()
    {
        // TODO: Pool the objects -- don't destroy instead turn them off -- that way we can maintain a pool of spawned objects
        foreach (var obj in m_objs) Destroy(obj);
        m_objs.Clear();

        // SAFETY -- ENSURE m_xRangeToSpawn.x < m_xRangeToIgnore.x and m_xRangeToSpawn.y > m_xRangeToIgnore.y
        m_xRangeToSpawn.x = Mathf.Clamp(m_xRangeToSpawn.x, float.NegativeInfinity, m_xRangeToIgnore.x - 1);
        m_xRangeToSpawn.y = Mathf.Clamp(m_xRangeToSpawn.y, m_xRangeToIgnore.y + 1, float.PositiveInfinity);

        int numToSpawn = Mathf.FloorToInt(RandomUtils.Range(m_rangeOfNumberToSpawn));
        GameObject[] objs = Container.Environment.Objs;
        for(int i = 0; i < numToSpawn; i++)
        {
            GameObject obj = objs[Random.Range(0, objs.Length)];
            Vector3 randomPos = Vector3.zero;
            bool valid = false;
            while(!valid)
            {
                randomPos = new Vector3(RandomUtils.Range(m_xRangeToSpawn), RandomUtils.Range(m_yRangeToSpawn), RandomUtils.Range(m_zRangeToSpawn));
                Debug.Log($"RandomPos: {randomPos}");
                valid = !(randomPos.x >= m_xRangeToIgnore.x && randomPos.x <= m_xRangeToIgnore.y);
            }
            // Raycast down to see if we are on ground
            Vector3 randRot = new Vector3(RandomUtils.Range(m_xRot).NormalizeAngleTo360(), RandomUtils.Range(m_yRot).NormalizeAngleTo360(), RandomUtils.Range(m_zRot).NormalizeAngleTo360());
            var go = Instantiate(obj, transform);
            go.transform.localPosition = randomPos;
            //bool raycastHit = Physics.Raycast(go.transform.position + go.transform.up, -go.transform.up, out RaycastHit hit, 10, m_groundLayer);
            //if (raycastHit) randomPos.y = hit.point.y + RandomUtils.Range(m_yRangeToSpawn);
            //go.transform.localPosition = randomPos;

            go.transform.localRotation = Quaternion.Euler(randRot);
            m_objs.Add(go);
        }
    }
}
