using UnityEngine;

public class BoostPickup : MonoBehaviour, ICollectible
{
    [SerializeField] private float m_rotationSpeed = 10;

    private Vector3 m_lastRot, m_nextRot;
    private float m_lerp;

    private void Awake()
    {
        transform.SetParent(RoadManagerMono.Segments[2]?.transform);
    }

    private void Update()
    {
        m_lerp += Time.deltaTime * m_rotationSpeed;
        // Rotate can in circle
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(m_lastRot), Quaternion.Euler(m_nextRot), m_lerp);
        if (m_lerp > 1)
        {
            m_lerp = 0;
            m_lastRot = transform.localEulerAngles;
            m_nextRot = m_lastRot;
            m_nextRot.y += 90;
        }
    }
    public void Collect()
    {
        EventsPlayer.OnPickupBoost();
        gameObject.SetActive(false);
    }
}
