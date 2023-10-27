using InexperiencedDeveloper.Extensions;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    private Rigidbody m_rb;

    [SerializeField] private GameObject[] m_possibleCars;
    private GameObject m_selectedGfx;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        transform.SetParent(RoadManagerMono.Segments[2].transform);
        foreach(var car in m_possibleCars)
        {
            GameObject c = Instantiate(car, transform);
            c.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        m_selectedGfx = transform.GetChild(Random.Range(0, transform.childCount)).gameObject;
        m_selectedGfx.SetActive(true);
        EventsRoad.HitTrigger += OnPlayerHitTrigger;
        Invoke("Disable", 10);
    }

    private void OnDisable()
    {
        m_selectedGfx?.SetActive(false);
        EventsRoad.HitTrigger -= OnPlayerHitTrigger;
    }

    private void OnDestroy()
    {
    }

    private void OnPlayerHitTrigger(RoadChunk chunk)
    {
        transform.SetParent(RoadManagerMono.Segments[2].transform);
    }

    private void Disable() => gameObject.SetActive(false);

    private void FixedUpdate()
    {
        Vector3 forwardForce = transform.forward * Settings.Player.FwdSpeed;
        if (m_rb.velocity.magnitude > Settings.Player.MaxSpeed)
        {
            forwardForce = -transform.forward * Settings.Player.FwdSpeed / 2;
        }
        m_rb.SafeAddForce(forwardForce * Time.fixedDeltaTime, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (!other.CompareTag(Tags.GROUND)) return;
        //EventsRoad.OnEnemyHitTrigger(this); 
    }
}
