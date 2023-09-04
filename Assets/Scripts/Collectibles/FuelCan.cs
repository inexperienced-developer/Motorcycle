using UnityEngine;

public class FuelCan : MonoBehaviour, ICollectible
{
    [SerializeField] private float m_rotationSpeed = 10;
    private bool m_isLarge;

    private Vector3 m_lastRot, m_nextRot;
    private float m_lerp;

    private void Awake()
    {
        // 20% chance to become large
        m_isLarge = Random.Range(0, 100) < 20;
        if (m_isLarge)
        {
            transform.localScale *= 2;
        }
        transform.SetParent(RoadManagerMono.Segments[2]?.transform);
    }

    private void Update()
    {
        m_lerp += Time.deltaTime * m_rotationSpeed;
        // Rotate can in circle
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(m_lastRot), Quaternion.Euler(m_nextRot), m_lerp);
        if(m_lerp > 1)
        {
            m_lerp = 0;
            m_lastRot = transform.localEulerAngles;
            m_nextRot = m_lastRot;
            m_nextRot.y += 90;
        }
    }

    public void Collect()
    {
        int fuelToGain = m_isLarge ? Settings.Collectibles.Fuel_LargeAmtToGain : Settings.Collectibles.Fuel_SmallAmtToGain;
        EventsGame.OnUpdateFuelLevel(fuelToGain);
        gameObject.SetActive(false);
    }
}
