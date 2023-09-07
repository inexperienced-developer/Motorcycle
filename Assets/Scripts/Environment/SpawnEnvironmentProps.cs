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

    private List<GameObject> m_objs = new List<GameObject>();

    // TODO: Pool the objects -- don't destroy instead turn them off -- that way we can maintain a pool of spawned objects

    private void Spawn()
    {
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
                valid = !(randomPos.x >= m_xRangeToIgnore.x && randomPos.x <= m_xRangeToIgnore.y);
            }
            // TODO: Add random rotation as well
            var go = Instantiate(obj, transform);
            go.transform.localPosition = randomPos;
        }
    }
}
